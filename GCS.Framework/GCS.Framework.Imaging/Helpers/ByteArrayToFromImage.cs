using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GCS.Framework.Imaging.Helpers;

namespace GCS.Framework.Imaging
{
    public partial class ByteArrayToFromImage
    {
        //public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        //{
        //    if (imageIn != null)
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        return ms.ToArray();
        //    }
        //    return null;
        //}

        //public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        //{
        //    if (byteArrayIn != null && byteArrayIn.Length > 0)
        //    {
        //        MemoryStream ms = new MemoryStream(byteArrayIn);
        //        System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //        return returnImage;
        //    }
        //    return null;
        //}

        public static System.Windows.Media.ImageSource ConvertByteArrayToImageSource(byte[] byteArrayIn)
        {
            var image = ByteArrayToImage(byteArrayIn);
            if (image != null)
                return ConvertImageToImageSource(image);
            return null;
        }

        public static System.Windows.Media.ImageSource ConvertImageToImageSource(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                var bitmap = new System.Windows.Media.Imaging.BitmapImage();
                bitmap.BeginInit();

                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                return bitmap;
            }
        }

        public static byte[] UriToByteArray(Uri uriIn)
        {
            if( uriIn == null)
                return null;
            var imageSource = new BitmapImage(uriIn);
            return imageSource.ToByteArray();
        }
    }

}
