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

namespace _64.RoutedEventExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.gridRoot.AddHandler(Button.ClickEvent,new RoutedEventHandler(ButtonClicked));
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"发送者名字: {(sender as FrameworkElement).Name},最初的发送者名字为： {(e.OriginalSource as FrameworkElement).Name}");
        }



       

        private void ReportTimeHandler(object sender, RoutedEventArgs e)
        {
            if (e is ReportTimeEventArgs reportTimeArgs)
            {
                string timeString = reportTimeArgs.ClickTime.ToString();
                string content = $"{timeString} 到达 {(sender as FrameworkElement).Name}";
                myListBox.Items.Add(content);

                if ((sender as FrameworkElement)==this.gridA)
                {
                    e.Handled = true;
                }
            }


        }
    }

    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }

        public DateTime ClickTime { get; set; }
    }
    public class TimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TimeButton));

        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;

            this.RaiseEvent(args);
        }
    }
}