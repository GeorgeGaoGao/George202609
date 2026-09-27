using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace _63.BookReadingExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student Student { get; set; }
        public static string _windowTitle = "山高路远";
        public static string ShowText { get; set; } = "小心为上";
        public MainWindow()
        {
            InitializeComponent();
            Student= new Student();

            Binding binding = new Binding();
            binding.Source = Student;
            binding.Path=new PropertyPath("Name");

           BindingOperations.SetBinding(this.myTextBox,TextBox.TextProperty, binding);

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string theString = this.FindResource("myString") as string;
            StackPanel theContent = this.Content as StackPanel;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = theString;
            textBlock.FontSize = 50;
            textBlock.Foreground = Brushes.Green;
            theContent.Children.Add(textBlock);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button =sender as Button;
            DependencyObject lever1 = VisualTreeHelper.GetParent(button);
            DependencyObject lever2= VisualTreeHelper.GetParent(lever1);
            DependencyObject lever3= VisualTreeHelper.GetParent(lever2);
            MessageBox.Show(lever3.GetType().ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Student.Name += "Name";
        }
    }

    public class MyButton : Button
    {
        public Type UserWindowType { get; set; }
        protected override void OnClick()
        {
            base.OnClick();
            if (this.UserWindowType != null)
            {
                Window window = Activator.CreateInstance(UserWindowType) as Window; if (window != null)
                {
                    window.Title = "这是我们新显示的一个窗口";
                    window.Show();
                }
            }


        }
    }

    public class Student:INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}