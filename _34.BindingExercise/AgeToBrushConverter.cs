using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace _34.BindingExercise
{
    public class AgeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush solidColorBrush = Brushes.Black;
            if (value != null && int.TryParse(value.ToString(), out int age))
            {
                if (age < 20)
                {
                    solidColorBrush = Brushes.LightGreen;
                }else if (age < 40)
                {
                    solidColorBrush= Brushes.Green;
                }else if(age < 60)
                {
                    solidColorBrush = Brushes.LightBlue;
                }else if (age < 80)
                {
                    solidColorBrush = Brushes.Blue;
                }
                else
                {
                    solidColorBrush = Brushes.Gray;
                }
            }
            return solidColorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
