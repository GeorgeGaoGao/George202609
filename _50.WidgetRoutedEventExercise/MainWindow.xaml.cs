using _50.WidgetRoutedEventExercise.Controls;
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

namespace _50.WidgetRoutedEventExercise
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

        private void Widget_Completed(object sender, RoutedEventArgs e)
        {
            Widget widget = sender as Widget;
            if (widget.SalesValue > widget.SalesTarget)
            {
                widget.Icon = "@@@";
               
            }
         

        }
    }
}