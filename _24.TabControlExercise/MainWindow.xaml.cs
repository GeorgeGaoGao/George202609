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

namespace _24.TabControlExercise
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

        private void myTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tab=sender as TabControl;
            if (tab!=null)
            {
               TabItem item= tab.SelectedItem as TabItem;
                var content = tab.SelectedContent;
                myTextBlock.Text = $"标题：{item.Header}    内容：{content}";
            }
        }
    }
}