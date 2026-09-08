using GeorgeWpfDLL;
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

namespace _22.DataGridExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "George01", Age = 51, Address = "wuhan" });
            people.Add(new Person() { Name = "George02", Age = 52, Address = "wuhan" });
            people.Add(new Person() { Name = "George03", Age = 53, Address = "wuhan" });
            myListBox.ItemsSource = people;
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            var person = dataGrid.SelectedItem as Person;

            if (dataGrid == null) return;
            if (person == null) return;
            
            nameTextBlock.Text = person.Name;
            ageTextBlock.Text = person.Age.ToString();
            addressTextBlock.Text = person.Address;
        }
    }
}