////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\ColorConverter.cs
//
// summary:	Implements the color converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GCS.Core.Common.UI.Converters
{
    //class ColorConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //    }


    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //    }
    //}

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A color utilities. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ColorUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contrast color. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="color">    The color. </param>
        ///
        /// <returns>   A Color. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Color ContrastColor(Color color)
        {
            byte d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(color.A, d, d, d);
        }
    }
}
