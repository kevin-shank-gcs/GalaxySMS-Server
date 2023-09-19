////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\ByteArrayToHexStringConverter.cs
//
// summary:	Implements the byte array to hexadecimal string converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A byte array to hexadecimal string converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public class ByteArrayToHexStringConverter:IValueConverter
	{
		#region IValueConverter Members

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
			byte[] data = (byte[])value;
			StringBuilder byteString = new StringBuilder();

			int idx;
			for (idx = 0; idx < data.Length; idx++)
			{
				if ((idx % 4) == 0)
					byteString.Append(' ');
				byteString.AppendFormat("{0:X2}", data[idx]);
			}
//			byteString.Append(data[idx]);

			return byteString.ToString();
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

		#endregion
	}
}
