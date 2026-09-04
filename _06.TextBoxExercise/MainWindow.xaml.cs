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

namespace _06.TextBoxExercise
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"文本框内容已改变");
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            var selectedText = textBox.SelectedText;
            //if (selectedText != null)
            //{
            //    var selectionIndex = textBox.CaretIndex;
            //    MessageBox.Show($"文本框中选择的内容已改变 选中内容为{selectedText} 开始序号为{selectionIndex}");
            //}


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange=new TextRange(myRichTextBox.Document.ContentStart, myRichTextBox.Document.ContentEnd);
            MessageBox.Show(textRange.Text);

            Run run = new Run($"当前时间 {DateTime.Now}");
            run.Foreground = Brushes.Red; 
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(run);

            myRichTextBox.Document.Blocks.Add(paragraph);
        }
    }
}