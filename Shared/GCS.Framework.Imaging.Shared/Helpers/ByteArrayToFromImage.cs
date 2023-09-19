using System;
using System.Diagnostics;
using System.IO;

namespace GCS.Framework.Imaging
{
    public partial class ByteArrayToFromImage
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            try
            {
                if (imageIn != null)
                {
                    MemoryStream ms = new MemoryStream();
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return null;
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                if (byteArrayIn != null && byteArrayIn.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(byteArrayIn);
                    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                    return returnImage;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        //public static System.Windows.Media.ImageSource ConvertByteArrayToImageSource(byte[] byteArrayIn)
        //{
        //    var image = ByteArrayToImage(byteArrayIn);
        //    if (image != null)
        //        return ConvertImageToImageSource(image);
        //    return null;
        //}

        //public static System.Windows.Media.ImageSource ConvertImageToImageSource(System.Drawing.Image image)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var bitmap = new System.Windows.Media.Imaging.BitmapImage();
        //        bitmap.BeginInit();

        //        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        ms.Seek(0, System.IO.SeekOrigin.Begin);
        //        bitmap.StreamSource = ms;
        //        bitmap.EndInit();
        //        return bitmap;
        //    }
        //}
    }

}
