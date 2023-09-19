using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A search property. </summary>
    ///
    /// <remarks>   Kevin, 4/10/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SaveFileParameters
    {
        public enum FileType
        {
            Raw,
            Jpeg,
            Png,
            Avif,
            WebP,
            Pdf,
            Txt,
            Rtf,
        }

        public enum OwnerType
        {
            Generic,
            Person,
            Entity,
            User,
            AccessPortal,
            Cluster,
            Site,
            InputDevice,
            OutputDevice,
        }

#if NetCoreApi
#else
        [DataMember]
#endif

        public Guid OwnerUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public OwnerType TypeOfOwner { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] FileBinaryData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public FileType TypeOfFile { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string OriginalFilename { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string OriginalContentType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SaveToFilename { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool GenerateRandomFilename { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int RandomFilenameLength { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class ScaleImageParameters
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ScaleToWidth { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class SavePhotoParameters : SaveFileParameters
    {
        public SavePhotoParameters()
        {
            ScaleImages = new HashSet<ScaleImageParameters>();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ScaleImageParameters> ScaleImages { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int JpgQuality { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool UseMagick { get; set; }
    }

}
