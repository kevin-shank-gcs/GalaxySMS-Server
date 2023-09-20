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
    public class PersonLastUsageData
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
        public string SiteName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string AccessPortalName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialName { get; set; }

    }
}
