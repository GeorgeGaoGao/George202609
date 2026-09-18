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

namespace _50.WidgetRoutedEventExercise.Controls
{
    /// <summary>
    /// Widget.xaml 的交互逻辑
    /// </summary>
    public partial class Widget : UserControl
    {
        public Widget()
        {
            InitializeComponent();
        }



        public double SalesTarget
        {
            get { return (double)GetValue(SalesTargetProperty); }
            set { SetValue(SalesTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SalesTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalesTargetProperty =
            DependencyProperty.Register(nameof(SalesTarget), typeof(double), typeof(Widget), new PropertyMetadata(0.0));



        public double SalesValue
        {
            get { return (double)GetValue(SalesValueProperty); }
            set { SetValue(SalesValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SalesValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalesValueProperty =
            DependencyProperty.Register(nameof(SalesValue), typeof(double), typeof(Widget), 
                new PropertyMetadata(0.0,new PropertyChangedCallback(OnSalesValueChanged)));

        private static void OnSalesValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Widget widget) return;
            if (e.NewValue is not double realValue) return;

            if (realValue>widget.SalesTarget)
            {
                widget.Icon = "@@棒@@";
                widget.RaiseCompletedEvent();
            }
            else
            {
                widget.Icon = "***";
            }
          


        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(string), typeof(Widget), new PropertyMetadata("***"));



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(Widget), new PropertyMetadata("标题"));



        public static readonly RoutedEvent CompletedEvent = EventManager.RegisterRoutedEvent(
            name: "CompletedEvent",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(Widget)
            );

        public event RoutedEventHandler Completed
        {
            add { AddHandler(CompletedEvent, value); }
            remove { RemoveHandler(CompletedEvent, value); }
        }
        public void RaiseCompletedEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(CompletedEvent, this);
            RaiseEvent(args);
        }



    }
}
