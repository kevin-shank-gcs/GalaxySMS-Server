﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace GCS.Core.Common.UI.Converters
{
    public class ParameterAndAnyValueToBooleanConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return parameter == null;
            }
            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return parameter == null;
            }
            return value.ToString() == parameter.ToString();
        }
    }
}
