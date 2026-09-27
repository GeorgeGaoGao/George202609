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

namespace _65.AttachedEventExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myGrid.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(StudentNameChangedHandler));

        }

        private void StudentNameChangedHandler(object sender, RoutedEventArgs e)
        {
            Student student=e.OriginalSource as Student;
            string newItem = $"{student.StudentId} {student.Name}";
            myListBox.Items.Add(newItem);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student() { Name="Tom",StudentId=10};
            student.Name = "tim";
            RoutedEventArgs args= new RoutedEventArgs(Student.NameChangedEvent,student);
            myButton.RaiseEvent(args);

            //Button button = (Button)sender;
            //StudentNameChangedEventArgs eventArgs = new StudentNameChangedEventArgs(Student.NameChangedEvent,this);
            //Student student=new Student();
            //Random random = new Random();
            //student.Name = $"George{random.NextInt64(1,100).ToString()}";
            //eventArgs.NewName = student.Name;
            //button.RaiseEvent(eventArgs);
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }

        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent(
            name: "NameChanged",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(Student)
            );

    }
    public class StudentNameChangedEventArgs : RoutedEventArgs
    {
        public string NewName { get; set; }
        public StudentNameChangedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }
       
        
    }
}