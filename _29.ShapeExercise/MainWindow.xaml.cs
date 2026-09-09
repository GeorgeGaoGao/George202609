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

namespace _29.ShapeExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                Task.Run(async () =>
                {

                    int number = 5;
                    while (true)
                    {
                        if (number == 0) number = 5;

                        Dispatcher.Invoke(() =>
                        {
                            myLine.StrokeDashOffset = number;

                        });
                        number--;
                        await Task.Delay(250);
                    }

                });
            };
        }
    }
}