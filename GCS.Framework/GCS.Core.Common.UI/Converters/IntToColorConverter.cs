////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\IntToColorConverter.cs
//
// summary:	Implements the int to color converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An int to color converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class IntToColorConverter : IValueConverter
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
            if (value == null)
                return Colors.White;

            int iValue = 0;
            if (int.TryParse(value.ToString(), out iValue))
            {
                var color = (Color)ColorConverter.ConvertFromString(string.Format("#{0:X8}", iValue));
                return color;
            }
            return Colors.White;
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
            if (value is Color)
            {

                byte[] bytes = new byte[4];
                bytes[3] = ((Color)value).A;
                bytes[2] = ((Color)value).R;
                bytes[1] = ((Color)value).G;
                bytes[0] = ((Color)value).B;
                var iValue = BitConverter.ToInt32(bytes, 0);
                return iValue;
            }
            return 0;
        }
    }

}
