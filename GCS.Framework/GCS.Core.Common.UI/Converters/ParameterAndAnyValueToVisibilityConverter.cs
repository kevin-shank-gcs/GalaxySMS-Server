////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\ParameterAndAnyValueToVisibilityConverter.cs
//
// summary:	Implements the parameter and any value to visibility converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;
using GCS.Core.Common.Extensions;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A parameter and any value to visibility converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ParameterAndAnyValueToVisibilityConverter : IValueConverter
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">        The value produced by the binding source. </param>
        /// <param name="targetType">   The type of the binding target property. </param>
        /// <param name="parameter">    The converter parameter to use. </param>
        /// <param name="culture">      The culture to use in the converter. </param>
        ///
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null || !parameter.IsEnumerable() || value == null)
                return Visibility.Collapsed;

            if (parameter.IsEnumerable())
            {
                foreach (var o in (IEnumerable)parameter)
                {
                    if (value.ToString() == o.ToString())
                        return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">        The value that is produced by the binding target. </param>
        /// <param name="targetType">   The type to convert to. </param>
        /// <param name="parameter">    The converter parameter to use. </param>
        /// <param name="culture">      The culture to use in the converter. </param>
        ///
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
