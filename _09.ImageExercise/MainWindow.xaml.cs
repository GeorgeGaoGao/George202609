using System.DirectoryServices.ActiveDirectory;
using System.IO.Packaging;
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

namespace _09.ImageExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/Images/002.jpg"));
            string baseDirectory=AppDomain.CurrentDomain.BaseDirectory;
            string filePath = System.IO.Path.Combine(baseDirectory, "Images", "004.jpg");
            BitmapImage bitmapImage = new BitmapImage(new Uri(filePath));

            //this.myImage.Source = bitmapImage;
        }
    }
}