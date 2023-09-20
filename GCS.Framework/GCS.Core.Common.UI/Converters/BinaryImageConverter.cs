////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Converters\BinaryImageConverter.cs
//
// summary:	Implements the binary image converter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GCS.Core.Common.UI.Converters
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A binary image converter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public class BinaryImageConverter : IValueConverter
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

		object IValueConverter.Convert(object value,
			 Type targetType,
			 object parameter,
			 System.Globalization.CultureInfo culture)
		{
			if (value != null && value is byte[])
			{
				byte[] bytes = value as byte[];

				MemoryStream stream = new MemoryStream(bytes);

				BitmapImage image = new BitmapImage();
				image.BeginInit();
				image.StreamSource = stream;
				image.EndInit();

				return image;
			}

			return null;
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

		object IValueConverter.ConvertBack(object value,
			 Type targetType,
			 object parameter,
			 System.Globalization.CultureInfo culture)
		{
			if (value != null && value is System.Windows.Media.Imaging.BitmapImage)
			{
				//BitmapImage source = value as BitmapImage;
				//MemoryStream ms = new MemoryStream();
				//source(ms, System.Drawing.Imaging.ImageFormat.Gif);
				//return ms.ToArray();
			}
			return null;
		}
	}
}
