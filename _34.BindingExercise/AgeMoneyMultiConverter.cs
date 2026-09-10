using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace _34.BindingExercise
{
    public class AgeMoneyMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string title = string.Empty;
            if (values!=null&&values.Length==2)
            {
                var ageResult = int.TryParse(values[0].ToString(), out int age);
                var moneyResult= int.TryParse(values[1].ToString(),out int money);

                if (ageResult&&moneyResult)
                {
                    if (age<20&&money<100)
                    {
                        title = "没钱的年轻人";
                    }
                    else if (age<20&&money>10000)
                    {
                        title = "富有的年轻人";
                    }else if (age > 60 && money > 100000)
                    {
                        title = "有钱的老登";
                    }
                    else
                    {
                        title = "平凡人";
                    }
                    
                }
            }
            return title;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
