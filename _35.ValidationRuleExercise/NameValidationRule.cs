using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace _35.ValidationRuleExercise
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null && value.ToString().Length > 1 && value.ToString().Length < 10)
            {


                return new ValidationResult(true, null);

            }
            else
            {
                return new ValidationResult(false, "用户名为空或长度不正确");
            }
        }
    }
}
