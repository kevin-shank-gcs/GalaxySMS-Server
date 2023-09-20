////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\ObjectToUpperCaseStringConverter.cs
//
// summary:	Implements the object to upper case string converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An object to upper case string converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ObjectToUpperCaseStringConverter : IValueConverter
    {
        /// <summary>   The instance. </summary>
        public static readonly ObjectToUpperCaseStringConverter Instance = new ObjectToUpperCaseStringConverter();

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

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return String.Empty;
            }
            string stringValue = value.ToString();
            string processedValue = Regex.Replace(stringValue, "([A-Z])", " $1").Trim().ToUpper();

            return processedValue;
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

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string stringValue = value.ToString().Trim();
            string[] splittedValues = Regex.Split(stringValue, " ");
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < splittedValues.Length; i++)
            {
                char[] letters = splittedValues[i].ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                result.Append(letters);
            }
            return result.ToString();
        }
    }
}