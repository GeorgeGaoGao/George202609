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

namespace _60.CodeKeyFramesExercise
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

      

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LinearGradientBrush brush = myCanvas.Background as LinearGradientBrush;

            Random random= new Random();

            PointAnimationUsingKeyFrames startAnimation= new PointAnimationUsingKeyFrames();
            PointAnimationUsingKeyFrames endAnimation= new PointAnimationUsingKeyFrames();
            LinearPointKeyFrame startKeyFrame = new LinearPointKeyFrame();
            LinearPointKeyFrame endKeyFrame = new LinearPointKeyFrame();
            startAnimation.KeyFrames.Add(startKeyFrame);
            endAnimation.KeyFrames.Add(endKeyFrame);

            double x = random.NextDouble();
            double y = random.NextDouble();
            startKeyFrame.KeyTime = TimeSpan.FromMilliseconds(2500);
            startKeyFrame.Value = new Point(x, y);

            x = random.NextDouble();
            y = random.NextDouble();
            endKeyFrame.KeyTime = TimeSpan.FromMilliseconds(1500);
            endKeyFrame.Value = new Point(x, y);

            brush.BeginAnimation(LinearGradientBrush.StartPointProperty, startAnimation);
            brush.BeginAnimation(LinearGradientBrush.EndPointProperty, endAnimation);
        }

        private void myCanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}