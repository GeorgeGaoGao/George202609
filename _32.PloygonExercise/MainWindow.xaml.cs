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

namespace _32.PloygonExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polygon _polygon;
        private int _count;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //for (int i = 0; i < myCanvas.Children.Count; i++)
            //{
            //    if (myCanvas.Children[i] is not Button)
            //    {
            //        myCanvas.Children.Remove(myCanvas.Children[i]);
            //    }
            //}
            for (int i = 0; i < myCanvas.Children.Count; i++)
            {
                if (!ReferenceEquals( myCanvas.Children[i] ,sender))
                {
                    myCanvas.Children.Remove(myCanvas.Children[i]);
                }
            }
            //foreach (var item in myCanvas.Children)
            //{
            //    if (item is not Button)
            //    {
            //        myCanvas.Children.Remove(item as UIElement);
            //    }
            //}
            //myCanvas.Children.Clear();
            _count = 0;
        }

        private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_count++==0)
            {
                _polygon = new Polygon();
                _polygon.Stroke = Brushes.Green;
                _polygon.StrokeThickness = 1;
                myCanvas.Children.Add(_polygon);
            }
            Point point = e.GetPosition(myCanvas);
            _polygon.Points.Add(point);
        }

        private void Window_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _count = 0;
        }
    }
}