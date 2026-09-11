using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace _36.DatatriggerExercise
{
    public class AgeToLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string level = string.Empty;
            if (value != null&&int.TryParse(value.ToString(),out int age)){
                if (age>52)
                {
                    level= "0";
                }
                if (age < 52)
                {
                    level = "1";
                }
            }
            return level;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
