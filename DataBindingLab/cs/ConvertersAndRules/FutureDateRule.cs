using System;
using System.Globalization;
using System.Windows.Controls;

namespace DataBindingLab
{
    class FutureDateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime date;

            if (!DateTime.TryParse(value.ToString(), out date))
                return new ValidationResult(false, "Value is not a valid date.");

            if (DateTime.Now.Date > date)
                return new ValidationResult(false, "Please enter a date in the future.");

            return ValidationResult.ValidResult;
        }
    }
}


