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

namespace _53.TranslateTransformExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isMouseDown;
        private Point _pointMouseDown;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (myButton.RenderTransform is TranslateTransform translateTransform)
            {
                if (_isMouseDown)
                {
                    var t = e.GetPosition(this);
                    translateTransform.X = t.X - _pointMouseDown.X;
                    translateTransform.Y = t.Y - _pointMouseDown.Y;
                }

            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            _pointMouseDown = e.GetPosition(this);
        }
    }
}