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

namespace _48.RoutedEventExercise
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

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Window_PreviewMouseUp");
        }

        private void Border_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Border_PreviewMouseUp");
        }

        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Canvas_PreviewMouseUp");
        }

       

        private void ButtonConfirm_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("ButtonConfirm_PreviewMouseUp");
        }



        private void CancelButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("CancelBorder_MouseUp");
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Canvas_MouseUp");
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Border_MouseUp");
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Window_MouseUp");
        }

        

        
    }
}