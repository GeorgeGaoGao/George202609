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

namespace _49.RoutedEventExercise.Controls
{
    /// <summary>
    /// Widget.xaml 的交互逻辑
    /// </summary>
    public partial class Widget : UserControl
    {
        public Widget()
        {
            InitializeComponent();
            //this.DataContext = this;
        }

        public static readonly RoutedEvent CompletedEvent=EventManager.RegisterRoutedEvent(
            name:"CompletedEvent",
            routingStrategy:RoutingStrategy.Bubble,
            handlerType:typeof(RoutedEventHandler),
            ownerType:typeof(Widget)
            );
        public event RoutedEventHandler Completed
        {
            add { AddHandler(CompletedEvent, value); }
            remove { RemoveHandler(CompletedEvent, value); }
        }
        public void RaiseCompleted()
        {
            RoutedEventArgs args=new RoutedEventArgs(CompletedEvent,this);
            RaiseEvent(args);
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(string), typeof(Widget), new PropertyMetadata("*"));



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(Widget), new PropertyMetadata("请输入标题"));



        public double Target
        {
            get { return (double)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register(nameof(Target), typeof(double), typeof(Widget), new PropertyMetadata(0.0));




        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(Widget), 
                new PropertyMetadata(0.0,new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Widget widget) return;
            if (e.NewValue is double realValue)
            {
                if (widget.Target>0&&realValue>widget.Target)
                {
                    widget.Icon = "***真棒***";
                    widget.RaiseCompleted();
                }
                else
                {
                    widget.Icon = "*";
                }
            }
        }
    }
}
