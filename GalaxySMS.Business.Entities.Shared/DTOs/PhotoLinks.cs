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

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PhotoLinks
    {
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid Uid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UniqueFilename { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Original { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Default { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Small { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PhotoLink> Others { get; set; } = new HashSet<PhotoLink>();

    }
}
