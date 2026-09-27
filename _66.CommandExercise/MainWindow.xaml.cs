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

namespace _66.CommandExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RoutedCommand _clearCommand = new RoutedCommand("Clear", typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }

        private void InitializeCommand()
        {
            //指定命令源，键盘快捷键
            myButton.Command = this._clearCommand;
            this._clearCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //指定命令目标
            myButton.CommandTarget = myTextBox;

            //创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = this._clearCommand;
            cb.CanExecute += Cb_CanExecute;
            cb.Executed += Cb_Executed;

            //安置命令关联
            myStackpanel.CommandBindings.Add(cb);

        }

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myTextBox.Clear();
            e.Handled = true;
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(myTextBox.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            e.Handled = true;
        }
    }
}