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

namespace _55.ImageBrushExercise
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

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = e.Delta / 3600.0;
            if (myGrid.Background is ImageBrush imageBrush)
            {
                Rect rect = imageBrush.Viewport;
                double newWidth = rect.Width + delta;
                double newHeight = rect.Height + delta;
                if (newWidth>0.1 &&newHeight>0.1)
                {
                    rect.Width = newWidth;
                    rect.Height = newHeight;
                    imageBrush.Viewport = rect;
                }
              


            }
        }
    }
}