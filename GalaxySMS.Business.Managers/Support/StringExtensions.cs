
using GalaxySMS.Business.Entities;
using GCS.Core.Common.File;

namespace GalaxySMS.Business.Managers.Support
{
    public static class StringExtensions
    {
        public static SaveFileParameters.FileType ContentTypeToFileType(this string s)
        {
            var sLower = s.ToLower();
            if (s == FileContentTypes.ImageJpeg)
                return SaveFileParameters.FileType.Jpeg;

            if (s == FileContentTypes.ImagePng)
                return SaveFileParameters.FileType.Png;

            if (s == FileContentTypes.ImageAvif)
                return SaveFileParameters.FileType.Avif;

            if (s == FileContentTypes.ImageWebP)
                return SaveFileParameters.FileType.WebP;

            return SaveFileParameters.FileType.Raw;
        }

    }
}
