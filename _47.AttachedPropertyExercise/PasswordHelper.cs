using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace _47.AttachedPropertyExercise
{
    public class PasswordHelper : DependencyObject
    {


        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), 
                new PropertyMetadata(string.Empty,new PropertyChangedCallback(OnPasswordChanged)));

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not PasswordBox box) return;

            box.PasswordChanged -= Box_PasswordChanged;
            var newPassword=e.NewValue as string??string.Empty;
            if (box.Password!=newPassword)
            {
                box.Password = newPassword;
            }
            box.PasswordChanged += Box_PasswordChanged;
        }

        private static void Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox box)
            {
                SetPassword(box, box.Password);
            }
        }
    }
}
