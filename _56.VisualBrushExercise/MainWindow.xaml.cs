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

namespace _56.VisualBrushExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void myImage_MouseEnter(object sender, MouseEventArgs e)
        {
            myEllipse.Visibility = Visibility.Visible;
        }

        private void myImage_MouseLeave(object sender, MouseEventArgs e)
        {
            myEllipse.Visibility=Visibility.Collapsed;
        }

        private void myImage_MouseMove(object sender, MouseEventArgs e)
        {

            /* 明确这个方法的功能
             * 1。设定viewbox,根据Tag中存的放大倍数zoom
             * 2。让显示区域跟随鼠标。
             */

            if (double.TryParse(myEllipse.Tag.ToString(),out double zoom))
            {
                Point mousePoint = e.GetPosition(myCanvas);
                var viewportRadius = myEllipse.Width / 2.0;
                var viewboxSize = myEllipse.Width / zoom;
                var viewboxRadius = viewboxSize / 2.0;

                double viewboxX = mousePoint.X - viewboxRadius;
                double viewboxY= mousePoint.Y - viewboxRadius;
                myVisualBrush.Viewbox = new Rect(viewboxX, viewboxY, viewboxSize, viewboxSize);

                Canvas.SetLeft(myEllipse, mousePoint.X - viewportRadius);
                Canvas.SetTop(myEllipse, mousePoint.Y - viewportRadius);
            }






            //Point imagePoint = e.GetPosition(myCanvas);
            //Point canvasPoint = e.GetPosition(myCanvas);

            //double ellipseRadius = myEllipse.Width / 2;   // 100
            //double zoom = 2.0;                            // 放大 2 倍
            //double viewBoxSize = myEllipse.Width / zoom;  // 源区域宽高 = 100
            //double viewBoxRadius = viewBoxSize / 2;       // 50

            //double x = imagePoint.X - viewBoxRadius;
            //double y = imagePoint.Y - viewBoxRadius;

            //myVisualBrush.Viewbox = new Rect(x, y, viewBoxSize, viewBoxSize);

            //Canvas.SetLeft(myEllipse, canvasPoint.X - ellipseRadius);
            //Canvas.SetTop(myEllipse, canvasPoint.Y - ellipseRadius);
        }
    }
}