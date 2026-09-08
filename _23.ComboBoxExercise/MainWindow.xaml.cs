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

namespace _23.ComboBoxExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
           
            people.Add(new Person() { Name = "George01", Age = 51, Address = "wuhan" });
            people.Add(new Person() { Name = "George02", Age = 52, Address = "wuhan" });
            people.Add(new Person() { Name = "George03", Age = 53, Address = "wuhan" });
            myComboBox.ItemsSource = people;
        }

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Person person=comboBox.SelectedItem as Person;

            if (comboBox == null) return;
            if (person == null) return;

            nameTextBlock.Text = person.Name;
            ageTextBlock.Text = person.Age.ToString();
            addressTextBlock.Text = person.Address;

        }

        private void myComboBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox == null) return;
            telephoneTextBlock.Text= comboBox.Text;
        }
    }
}