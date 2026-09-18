using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;

namespace _50.WidgetRoutedEventExercise
{
    public class SalesManager
    {
        public static readonly RoutedEvent CheckEvent = EventManager.RegisterRoutedEvent(
            name: "CheckEvent",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(SalesManager)
            );
        public static void AddCheckHandler(DependencyObject obj, RoutedEventHandler handler)
        {
            if (obj is UIElement element)
            {
                element.AddHandler(CheckEvent, handler);
            }
        }
        public static void RemoveCheckHandler(DependencyObject obj, RoutedEventHandler handler)
        {
            if (obj is UIElement element)
            {
                element.RemoveHandler(CheckEvent, handler);
            }
        }
    }
}
