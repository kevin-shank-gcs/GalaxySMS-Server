////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\SignedToUnsignedConverter.cs
//
// summary:	Implements the signed to unsigned converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A signed to unsigned converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SignedToUnsignedConverter : IValueConverter
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

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((int)value == 0)
                return value;

            if (value is sbyte)

                return (byte) value;
            if (value is short)
                return (ushort) value;
            if ( value is int)
                return (uint)value;
            if (value is long)
                return (ulong) value;

            return value;
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

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((uint) value == 0)
                return value;

            if (value is byte)
                return (sbyte) value;
            if (value is ushort)
                return (short) value;
            if (value is uint)
                return (int) value;
            if (value is ulong)
                return (long) value;
            return (int) value;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An unsigned to signed converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UnsignedToSignedConverter : IValueConverter
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

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((int) value == 0)
                return value;

            if (value is byte)
                return (sbyte) value;
            if (value is ushort)
                return (short) value;
            if (value is uint)
                return (int) value;
            if (value is ulong)
                return (long) value;

            return value;
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

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((uint) value == 0)
                return value;

            if (value is sbyte)
                return (byte) value;
            if (value is short)
                return (ushort) value;
            if (value is int)
                return (uint) value;
            if (value is long)
                return (ulong) value;
            return (int) value;
        }
    }
}
