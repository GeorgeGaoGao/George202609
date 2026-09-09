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

namespace _27.ContextMenuExercise
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem=sender as MenuItem;
            MessageBox.Show($"被点击的这个上下文菜单的标题是 {menuItem.Header.ToString()}");
        }

       

        private void MenuItem_Click_Clear(object sender, RoutedEventArgs e)
        {
            myContextMemu.Items.Clear();
        }
    }
}