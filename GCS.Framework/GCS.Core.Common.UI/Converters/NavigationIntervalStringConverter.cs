////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\NavigationIntervalStringConverter.cs
//
// summary:	Implements the navigation interval string converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A navigation interval string converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class NavigationIntervalStringConverter:IValueConverter
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
            string str = value.ToString();
            string[] strArr = str.Split(new string[]{"Start: ","End: ",", "},StringSplitOptions.RemoveEmptyEntries);

            DateTimeOffset start = DateTimeOffset.Now;
            DateTimeOffset end = DateTimeOffset.Now;

            DateTimeOffset.TryParse(strArr[0],out start);
            DateTimeOffset.TryParse(strArr[1],out end);

            if (start.Date == end.Date)
            {
                return String.Empty;
            }
            return String.Format(" - {0:dd MMM yy}", end);
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
            return null;
        }
    }
}
