using ImageMagick;
using System.IO;

namespace GCS.Framework.Magick
{
    public static class Imaging
    {
        public static byte[] ConvertImageFromOneFormatToAnother(byte[] sourceImage, MagickFormat sourceFormat, MagickFormat outputFormat, ref int newWidth, ref int newHeight, ResizeOptions resizeOptions = null)
        {
            using (var image = new MagickImage(sourceImage, (ImageMagick.MagickFormat)sourceFormat))
            {
                if (resizeOptions != null && resizeOptions.Width + resizeOptions.Height != 0)
                {
                    var size = new MagickGeometry(resizeOptions.Width, resizeOptions.Height);
                    // This will resize the image to a fixed size without maintaining the aspect ratio.
                    // Normally an image will be resized to fit inside the specified size.
                    size.IgnoreAspectRatio = resizeOptions.IngoreAspectRatio;

                    image.Resize(size);
                    newWidth = image.Width;
                    newHeight = image.Height;
                }

                var returnBytes = image.ToByteArray(ImageMagick.MagickFormat.Jpg);

                if (resizeOptions != null && resizeOptions.Compress)
                {
                    var compressedImage = Compress(returnBytes);
                    return compressedImage;
                }

                return returnBytes;
            }
        }


        public static void ConvertImageFromOneFormatToAnother(string sourceFilename, string outputFilename, ResizeOptions resizeOptions = null)
        {
            using (var image = new MagickImage(sourceFilename))
            {
                if (resizeOptions != null && resizeOptions.Width + resizeOptions.Height != 0)
                {
                    var size = new MagickGeometry(resizeOptions.Width, resizeOptions.Height);
                    // This will resize the image to a fixed size without maintaining the aspect ratio.
                    // Normally an image will be resized to fit inside the specified size.
                    size.IgnoreAspectRatio = resizeOptions.IngoreAspectRatio;

                    image.Resize(size);
                }

                image.Write(outputFilename);
            }


        }

        public static byte[] Compress(byte[] sourceImage)
        {
            using (var stream = new MemoryStream(sourceImage))
            {
                var optimizer = new ImageOptimizer();
                optimizer.LosslessCompress(stream);
                var outputStream = new MemoryStream();
                stream.CopyTo(outputStream);
                var compressedBytes = outputStream.GetBuffer();
                return compressedBytes;
            }

        }

        public static void Compress(string sourceFilename, string outputFilename)
        {
            var compressedOutput = new FileInfo(outputFilename);
            File.Copy(sourceFilename, compressedOutput.FullName, true);

            //Console.WriteLine("Bytes before: " + snakewareLogo.Length);

            var optimizer = new ImageOptimizer();
            optimizer.LosslessCompress(compressedOutput);

            compressedOutput.Refresh();
            //Console.WriteLine("Bytes after:  " + compressedOutput.Length);
        }

        //var settings = new MagickReadSettings();
        //// Tells the xc: reader the image to create should be 800x600
        //settings.Width = 800;
        //settings.Height = 600;

        //using (var memStream = new MemoryStream())
        //{
        //    // Create image that is completely purple and 800x600
        //    using (var image = new MagickImage("xc:purple", settings))
        //    {
        //        // Sets the output format to png
        //        image.Format = MagickFormat.Png;

        //        // Write the image to the memorystream
        //        image.Write(memStream);
        //    }
        //}

        //// Read image from file
        //using (var image = new MagickImage(SampleFiles.SnakewarePng))
        //{
        //    // Sets the output format to jpeg
        //    image.Format = MagickFormat.Jpeg;

        //    // Create byte array that contains a jpeg file
        //    byte[] data = image.ToByteArray();
        //}
    }
}
