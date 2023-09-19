using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace GCS.Framework.Imaging.Helpers
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
}
