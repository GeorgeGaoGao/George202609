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
            this.Loaded += (s, e) => Debug.WriteLine("003 loaded is activated");
            this.ContentRendered += (s, e) => Debug.WriteLine("004 contentrendered is activated");
            this.Deactivated += (s, e) => Debug.WriteLine("005 deactivated is activated");
            this.Closing += (s, e) => Debug.WriteLine("006 closing is activated");
            this.Closed += (s, e) => Debug.WriteLine("007 closed is activated");
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}