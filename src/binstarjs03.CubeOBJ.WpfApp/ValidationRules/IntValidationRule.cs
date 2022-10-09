﻿using System.Globalization;
using System.Windows.Controls;

namespace binstarjs03.CubeOBJ.WpfApp.ValidationRules;

public class IntValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string stringValue = (string)value;
        if (int.TryParse(stringValue, out _) || string.IsNullOrEmpty(stringValue))
            return ValidationResult.ValidResult;
        return new ValidationResult(false, "Number format is invalid");
    }
}
