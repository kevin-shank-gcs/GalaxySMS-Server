using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class PushBlobToCdnParameters
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        [Required]
        public Guid OwnerUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        [Required]
        public BlobOwnerType TypeOfOwner { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        [Required]
        public BlobDataType DataType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        [Required]
        public byte[] Data { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        [Required]
        public string Filename { get; set; }

    }
}
