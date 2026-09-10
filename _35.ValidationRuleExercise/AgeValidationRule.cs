using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace _35.ValidationRuleExercise
{
    public class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(),out int age)&& age >= 0 && age <= 120)
            {
                    return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "年龄值不是0到120间的整数");
            }
        }
    }
}
