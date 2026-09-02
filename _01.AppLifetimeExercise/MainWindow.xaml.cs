using System.Diagnostics;
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

namespace _01.AppLifetimeExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += (s, e) => Debug.WriteLine("001 SouceInitialized is activated.");
            this.Activated += (s, e) => Debug.WriteLine("002 Activated is activated");
            this.Loaded += MainWindow_Loaded;
            this.ContentRendered += MainWindow_ContentRendered;
            this.Deactivated += (s, e) => Debug.WriteLine("005 deactivated is activated");
            this.Closing += (s, e) => Debug.WriteLine("006 closing is activated");
            this.Closed += (s, e) => Debug.WriteLine("007 closed is activated");
        }

        private void MainWindow_ContentRendered(object? sender, EventArgs e)
        {
            //Task.Run(async () => {
            //    myListBox.Background = Brushes.Red;
            //});
            //这种看似不报错，但deepseek分析，可能报错被忽略。

            //Dispatcher.Invoke(() =>
            //{
            //    myListBox.Background = Brushes.Red;
            //});
            // 这种写法直接占用UI线程，也不是好写法。

           
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    //myListBox.Background = Brushes.Red;
                });
            });
        }

        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Grid 被点击了。");
        }
    }
    public class MyClass:DependencyObject
    {


        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(nameof(MyProperty), typeof(int), typeof(MyClass), new PropertyMetadata(0));


    }
}