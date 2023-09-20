namespace GCS.Core.Common.File
{
    public class FileContentTypes
    {
        public static string ImageJpeg = "image/jpeg";
        public static string ImagePng = "image/png";
        public static string ImageWebP = "image/webp";
        public static string ImageAvif = "image/avif";

    }

    public static class StringExtensions
    {
        public static bool IsAcceptableImageContentType(this string s)
        {
            var sLower = s.ToLower();
            return s == FileContentTypes.ImageJpeg ||
                s == FileContentTypes.ImagePng ||
                s == FileContentTypes.ImageAvif ||
                s == FileContentTypes.ImageWebP;
        }
    }
}
