using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _57.DropShadowEffectExercise
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

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Point centerPoint=new Point(myGrid.ActualWidth/2, myGrid.ActualHeight/2);
            Point mousePoint = e.GetPosition(myGrid);

            double angle=Math.Atan2(mousePoint.Y-centerPoint.Y, mousePoint.X-centerPoint.X);
            double direction = angle * 180 / Math.PI;

            DropShadowEffect dropShadowEffect=myButton.Effect as DropShadowEffect;
            dropShadowEffect.Direction=-direction;
        }
    }
}