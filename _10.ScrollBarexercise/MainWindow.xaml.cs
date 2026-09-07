using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace _10.ScrollBarexercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _scrollBarMaximum;

        public double ScrollBarMaximum
        {
            get { return _scrollBarMaximum; }
            set { _scrollBarMaximum =value; OnPropertyChanged(); }
        }

        private double _x;

        public double X
        {
            get { return _x; }
            set { _x = value; CanvasLeft = -value; OnPropertyChanged(); }
        }
        private double _canvasLeft;

        public double CanvasLeft
        {
            get { return _canvasLeft; }
            set { _canvasLeft = value; OnPropertyChanged(); }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Loaded += UpdateScrollBarMaximum;
            SizeChanged += UpdateScrollBarMaximum;
        }

        private void UpdateScrollBarMaximum(object sender, RoutedEventArgs e)
        {
            if (myStackPanel!=null && myGrid!=null)
            {
                double max= myStackPanel.ActualWidth - myGrid.ActualWidth;
                max = max < 0 ? 0 : max;
                ScrollBarMaximum = max;
            }
            X = X > ScrollBarMaximum ? ScrollBarMaximum : X;
        }
    }
}