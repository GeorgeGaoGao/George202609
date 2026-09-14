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

namespace _38.TemplateExercise
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myTreeView.Items.Clear();
            LoadTreeView(this);
        }

        private void LoadTreeView(object element)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            //item.Header = "根目录";
            BuildLogicalTree(item, element);
            myTreeView.Items.Add(item);
        }

        private void BuildLogicalTree(TreeViewItem item, object element)
        {
            if (element is DependencyObject)
            {
                var children = LogicalTreeHelper.GetChildren(element as DependencyObject);
                foreach (var child in children)
                {
                    TreeViewItem treeViewItem = new TreeViewItem();
                    treeViewItem.Header = child.GetType().Name;

                    BuildLogicalTree(treeViewItem, child);
                    item.Items.Add(treeViewItem);
                }
            }


        }

        private void Button_Click_Visual(object sender, RoutedEventArgs e)
        {
            myTreeView.Items.Clear();
            LoadVisualTreeView(this);
        }

        private void LoadVisualTreeView(DependencyObject element)
        {
            if (element!=null)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = element.GetType().Name;

                BuildVisualTreeView(item, element);
                myTreeView.Items.Add(item);
            }
        }

        private void BuildVisualTreeView(TreeViewItem item, DependencyObject element)
        {
            if (element!=null)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(element as DependencyObject);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child=VisualTreeHelper.GetChild(element as DependencyObject, i);
                    TreeViewItem childItem = new TreeViewItem();
                    childItem.Header = child.GetType().Name;
                    item.Items.Add(childItem); 
                    BuildVisualTreeView(childItem, child);
                    
                }
            }
        }
    }
}