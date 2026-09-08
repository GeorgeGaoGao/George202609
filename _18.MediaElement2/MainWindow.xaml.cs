using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _18.MediaElement2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _mediaFilePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
           
            DispatcherTimer timer= new DispatcherTimer();
            timer.Interval=TimeSpan.FromMilliseconds(500);
            timer.Tick+=(s, e) =>
            {
                myProgressBar.Value = myMediaElement.Position.TotalMilliseconds;
            };
           
            timer.Start();
        }

        private void OpenMedia(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "媒体文件 |*.mp4",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog()==true)
            {
                _mediaFilePath = openFileDialog.FileName;
                this.maskTextBlock.Text = openFileDialog.FileName;
                this.Title=openFileDialog.FileName;
                myMediaElement.Source=new Uri(_mediaFilePath);
                myMediaElement.MediaOpened -= MyMediaElement_MediaOpened;
                myMediaElement.MediaOpened += MyMediaElement_MediaOpened;

                
            }
        }

        private void MyMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (myMediaElement.NaturalDuration.HasTimeSpan)
            {
                myProgressBar.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
        }

        private void PlayMedia(object sender, RoutedEventArgs e)
        {
            maskBorder.Visibility = Visibility.Collapsed;
            myMediaElement.Play();
        }

        private void PauseMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void BackwardMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Position -=TimeSpan.FromSeconds(10);
        }

        private void ForwardMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Position += TimeSpan.FromSeconds(10);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume=mySlider.Value;
        }
    }
}