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
            double scale = (mousePoint.X + mousePoint.Y) / 100;

            ScaleTransform scaleTransform=myGrid.RenderTransform as ScaleTransform;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = new TimeSpan(0,0,0,0,250);
            doubleAnimation.To = 300;
            myEllipse.BeginAnimation(ScaleTransform.ScaleXProperty, doubleAnimation);
            BeginAnimation(ScaleTransform.ScaleYProperty, doubleAnimation);
        }
    }
}