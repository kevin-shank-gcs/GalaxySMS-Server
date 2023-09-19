using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
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

        [DataMember]
        public Guid OwnerUid { get; set; }

        [DataMember]
        public OwnerType TypeOfOwner { get; set; }

        [DataMember]
        public byte[] FileBinaryData { get; set; }

        [DataMember]
        public FileType TypeOfFile { get; set; }

        [DataMember]
        public string OriginalFilename { get; set; }

        [DataMember]
        public string OriginalContentType { get; set; }

        [DataMember]
        public string SaveToFilename { get; set; }

        [DataMember]
        public string Tag { get; set; }

        [DataMember]
        public bool GenerateRandomFilename { get; set; }

        [DataMember]
        public int RandomFilenameLength { get; set; }

    }

    [DataContract]
    public class ScaleImageParameters
    {
        [DataMember]
        public int ScaleToWidth { get; set; }

        [DataMember]
        public string Tag { get; set; }
    }


    [DataContract]
    public class SavePhotoParameters : SaveFileParameters
    {
        public SavePhotoParameters()
        {
            ScaleImages = new HashSet<ScaleImageParameters>();
        }

        [DataMember]
        public ICollection<ScaleImageParameters> ScaleImages { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public int JpgQuality { get; set; }

        [DataMember]
        public bool UseMagick { get; set; }
    }
}
