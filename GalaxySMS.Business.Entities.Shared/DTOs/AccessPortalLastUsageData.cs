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
    public class AccessPortalLastUsageData
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? Time { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? AccessGrantedTime { get; set; }

    }
}
