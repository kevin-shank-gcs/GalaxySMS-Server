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

    public class ClusterTimeZone: ClusterAddress
    {
        public ClusterTimeZone():base()
        {
        }

        public ClusterTimeZone(Int32 clusterId):base(clusterId)
        {
        }

        public ClusterTimeZone(Int32 clusterId, int clusterGroupId):base(clusterId, clusterGroupId)
        {
        }

        public ClusterTimeZone(ClusterAddress o):base(o)
        {

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TimeZoneId { get; set; }
    }

}
