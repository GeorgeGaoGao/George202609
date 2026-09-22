using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _59.CodeAnimationExercise
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

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(myGrid);
            double scale = (mousePoint.X + mousePoint.Y) / 500;

          
            
            //动画就是一条时间线，能输出值。把这个输出值赋给某个DP，就可以实现动画效果。
            ScaleTransform scaleTransform=myEllipse.RenderTransform as ScaleTransform;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = new TimeSpan(0,0,0,0,250);
            doubleAnimation.To = scale;
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, doubleAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, doubleAnimation);
        }

        private void myGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(myGrid);

            var gradientOrigin = new Point(mousePoint.X / myGrid.ActualWidth, mousePoint.Y / myGrid.ActualHeight);

            PointAnimation pointAnimation = new PointAnimation();
            pointAnimation.To = gradientOrigin;
            RadialGradientBrush radialGradientBrush = myEllipse.Fill as RadialGradientBrush;
            radialGradientBrush.BeginAnimation(RadialGradientBrush.GradientOriginProperty, pointAnimation);
        }
    }
}