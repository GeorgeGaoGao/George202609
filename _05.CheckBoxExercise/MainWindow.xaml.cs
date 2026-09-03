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

namespace _05.CheckBoxExercise
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> orders = new List<string>();
            if (checkbox1.IsChecked.Value)
            {
                orders.Add(checkbox1.Content.ToString());
            }
            if (checkbox2.IsChecked==true)
            {
                orders.Add(checkbox2.Content.ToString());
            }
            if (checkbox3.IsChecked==true)
            {
                orders.Add(checkbox3.Content.ToString());
            }
            if (checkbox4.IsChecked==true)
            {
                orders.Add(checkbox4.Content.ToString());
            }
            string chosenOrders = string.Join(',', orders);
            MessageBox.Show($"你选择的菜品是:{chosenOrders}");
        }
    }
}