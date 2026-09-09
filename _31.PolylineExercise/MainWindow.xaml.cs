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

namespace _31.PolylineExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline _polyline;
        private int _count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_count++==0)
            {
                _polyline = new Polyline();
                _polyline.Stroke = Brushes.Red;
                _polyline.StrokeThickness = 2;
                myCanvas.Children.Add(_polyline);
            }
            Point point=e.GetPosition(myCanvas);
            _polyline.Points.Add(point);
        }

        private void Window_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _count = 0;
        }
    }
}