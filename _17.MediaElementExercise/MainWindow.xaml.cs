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

namespace _17.MediaElementExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string mediaFilePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer=new DispatcherTimer();
            timer.Interval=TimeSpan.FromMilliseconds(500);
            timer.Tick += (s, e) =>
            {
                myProgressBar.Value = myMediaElement.Position.TotalMilliseconds;
            };
            timer.Start();
        }

       

        private void OpenMedia(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "媒体文件|*.mp4",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == true)
            {
                mediaFilePath = openFileDialog.FileName;
                myMediaElement.MediaOpened -= MyMediaElement_MediaOpened;
                myMediaElement.MediaOpened += MyMediaElement_MediaOpened;
                myMediaElement.Source=new Uri(mediaFilePath);
                this.Title = openFileDialog.FileName;
                this.myTextBlockMask.Text = openFileDialog.FileName;
            }
        }

        private void MyMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (myMediaElement.NaturalDuration.HasTimeSpan)
            {

                TimeSpan timeSpan = myMediaElement.NaturalDuration.TimeSpan;
                myProgressBar.Maximum = timeSpan.TotalMilliseconds;
            }
        }

        private void PlayMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
            myBorder.Visibility= Visibility.Collapsed;
        }

        private void StopMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void BackwardMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Position = myMediaElement.Position - TimeSpan.FromSeconds(10);
        }

        private void ForwardMedia(object sender, RoutedEventArgs e)
        {
            myMediaElement.Position=myMediaElement.Position+TimeSpan.FromSeconds(10);
        }

        private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider=sender as Slider;
            myMediaElement.Volume = slider.Value;
        }
    }
}