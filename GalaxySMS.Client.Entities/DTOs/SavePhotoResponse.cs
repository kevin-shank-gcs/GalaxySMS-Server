using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class SaveFileResponse
    {
        [DataMember]
        public string Original { get; set; }

    }

    [DataContract]
    public class SavePhotoResponse : SaveFileResponse
    {
        [DataMember]
        public string Default { get; set; }

        [DataMember]
        public string Small { get; set; }

        [DataMember]
        public string UniqueFilename { get; set; }
    }


    [DataContract]
    public class SaveDefaultPhotoResponse : SavePhotoResponse
    {

        [DataMember]
        public bool IsDefault { get; set; }
    }

    [DataContract]
    public class PersonSavePhotoResponse : SaveDefaultPhotoResponse
    {

        [DataMember]
        public System.Guid PersonUid { get; set; }
    }

}
