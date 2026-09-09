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

namespace _26.MenuExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<MenuModel> Menus { get; set; } = new List<MenuModel>();
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                MenuModel parent = new MenuModel();
                parent.MenuName = $"一级菜单{i}";
                for (int j = 0; j < 10; j++)
                {
                    MenuModel child= new MenuModel();
                    child.MenuName = $"二级菜单{j}";
                    for (int k = 0; k < 5; k++)
                    {
                        MenuModel grandChild = new MenuModel();
                        grandChild.MenuName = $"三级菜单{k}";
                        child.Children.Add(grandChild);
                    }
                    parent.Children.Add(child);
                }
                Menus.Add(parent);
            }
            myMenu.ItemsSource = Menus;
        }
    }

    public class MenuModel
    {
        public string MenuName {  get; set; }
        public DateTime TimeCreated { get; set; }
        public List<MenuModel> Children { get; set; } = new List<MenuModel>();

    }
}