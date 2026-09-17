using System;
using System.Collections.Generic;
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

namespace _46.TrayControlProject.Controls
{
    /// <summary>
    /// TrayControl.xaml 的交互逻辑
    /// </summary>
    public partial class TrayControl : UserControl
    {
        public TrayControl()
        {
            InitializeComponent();
        }



        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register(nameof(Size), typeof(int), typeof(TrayControl),
                new PropertyMetadata(60, new PropertyChangedCallback(OnSizeChanged)));

        private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TrayControl control = d as TrayControl;
        }



        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(nameof(Count), typeof(int), typeof(TrayControl),
                new PropertyMetadata(0, new PropertyChangedCallback(OnCountChanged)));

        private static void OnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TrayControl control = d as TrayControl;
            control.Initialize();
        }



        public int SelectedCount
        {
            get { return (int)GetValue(SelectedCountProperty); }
            set { SetValue(SelectedCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCountProperty =
            DependencyProperty.Register(nameof(SelectedCount), typeof(int), typeof(TrayControl), new PropertyMetadata(0));








        public List<CheckBox> SelectedItems
        {
            get { return (List<CheckBox>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(nameof(SelectedItems), typeof(List<CheckBox>), typeof(TrayControl), new PropertyMetadata(new List<CheckBox>()));




        public static int GetLeftMargin(DependencyObject obj)
        {
            return (int)obj.GetValue(LeftMarginProperty);
        }

        public static void SetLeftMargin(DependencyObject obj, int value)
        {
            obj.SetValue(LeftMarginProperty, value);
        }

        // Using a DependencyProperty as the backing store for LeftMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftMarginProperty =
            DependencyProperty.RegisterAttached("LeftMargin", typeof(int), typeof(TrayControl), new PropertyMetadata(0));




        public void Initialize()
        {
            SelectedCount = 0;
            SelectedItems = new List<CheckBox>();
            this.container.Children.Clear();
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Style = Application.Current.Resources["CheckBoxTrayControl"] as Style;
                    checkBox.Width = Size;
                    checkBox.Height = Size;
                    checkBox.Name = "_" + i;
                    checkBox.Tag = new Point(i * 10, Size + i * 2);
                    checkBox.Checked += (s, e) => { SelectedCount++; SelectedItems.Add(checkBox); };
                    checkBox.Unchecked += (s, e) => { SelectedCount--; SelectedItems.Remove(checkBox); };
                    this.container.Children.Add(checkBox);
                }


            }
        }


    }
}
