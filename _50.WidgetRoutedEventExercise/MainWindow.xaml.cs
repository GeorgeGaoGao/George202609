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
            myListBox.Items.Add(widget.SalesValue);
            widget.RaiseEvent(new RoutedEventArgs(SalesManager.CheckEvent));
        }

        private void Widget_Check(object sender, RoutedEventArgs e)
        {
            Widget widget = sender as Widget;
            if ((int)(widget.SalesValue) % 50000 < 5000)
            {
                myListBox.Items.Add($"该分红了，当前销售额{widget.SalesValue}");
            }
        }
    }
}