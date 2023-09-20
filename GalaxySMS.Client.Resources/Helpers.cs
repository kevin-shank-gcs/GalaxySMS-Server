using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GalaxySMS.Resources
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            return null;
        }

        public static byte[] ToByteArray(this BitmapImage imageIn)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            encoder.Save(memStream);
            return memStream.ToArray();
        }


    }


    public static class Helpers
    {
        public static byte[] GetImageAsBytes(string path)
        {
            //try
            //{
            if (!UriParser.IsKnownScheme("pack"))
                new System.Windows.Application();

            var imageSource =
              new BitmapImage(
                  new Uri(
                     $"pack://application:,,,/GalaxySMS.Resources;component/Images/{path}",
                      UriKind.RelativeOrAbsolute));
            return imageSource.ToByteArray();
            //}
            //catch (Exception e)
            //{
            //    Trace.WriteLine(e.ToString());
            //    throw;
            //}
        }
    }
}
