using GeorgeWpfDLL;
using System.IO.Pipes;
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

namespace _20.ListBoxExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myListBox.Items.Add(new Person() { Name="George01",Age=51,Address="wuhan"} );
            myListBox.Items.Add(new Person() { Name="George02",Age=52,Address="wuhan"} );
            myListBox.Items.Add(new Person() { Name="George03",Age=53,Address="wuhan"} );
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var selectedItem=myListBox.SelectedItem as Person;
            var selectedValue = myListBox.SelectedValue;
            myTextBlock.Text = $"item:{selectedItem} - value: {selectedValue}";
        }
    }
}