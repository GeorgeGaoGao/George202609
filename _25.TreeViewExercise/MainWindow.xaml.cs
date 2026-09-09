using Microsoft.Win32;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
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

namespace _25.TreeViewExercise
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
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            if (openFolderDialog.ShowDialog()==true)
            {
                myTextBox.Text = openFolderDialog.FolderName;
                //TreeViewItem rootItem = new TreeViewItem();
                //这种写法确实可以减少一个方法，但这个方法承担的逻辑不简洁，不值得
                //还是把装载树的方法独立出来更简洁清晰。
                //rootItem.Header = "根目录";
                //BuildTreeView(rootItem,openFolderDialog.FolderName);
                //myTreeView.Items.Add(rootItem);
                myTreeView.Items.Clear();
                LoadTreeView(openFolderDialog.FolderName);

                //TreeViewItem rootItem = new TreeViewItem();
                //rootItem.Header = openFolderDialog.FolderName;
                //BuildTreeView(rootItem,openFolderDialog.FolderName);



                //把根目录与其它目录区分开来逻辑上也清晰，根目录的处理与其它目录处理稍有不同。
            }

        }

      

        private void LoadTreeView(string folderName)
        {
            TreeViewItem rootItem = new TreeViewItem();
            rootItem.Header = "根目录";
            BuildTreeView(rootItem, folderName);
            myTreeView.Items.Add(rootItem);
        }

        private void BuildTreeView(TreeViewItem rootItem, string folderName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header= file.Name;
                rootItem.Items.Add(item);
            }
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = directory.Name;
                BuildTreeView(item, directory.FullName);
                rootItem.Items.Add(item);
            }
        }

        private void myTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeView = sender as TreeView;
            MessageBox.Show($"当前选中的节点标题是{(treeView.SelectedItem as TreeViewItem).Header}");
        }
    }
}