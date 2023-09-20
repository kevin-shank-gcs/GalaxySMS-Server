using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
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
    public partial class PersonPhotoScaled : EntityBase, IIdentifiableEntity, IEquatable<PersonPhotoScaled>, ITableEntityBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PersonPhotoScaledUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PersonPhotoUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UniqueFilename { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string PublicUrl { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] PhotoImage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }


    }
}
