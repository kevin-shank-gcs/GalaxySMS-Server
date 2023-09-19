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

    public class ClusterAddress : EntityBaseSimple
    {
        public ClusterAddress()
        {
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = 0;
        }

        public ClusterAddress(Int32 clusterId)
        {
            ClusterNumber = clusterId;
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = 0;
        }

        public ClusterAddress(Int32 clusterId, int clusterGroupId)
        {
            ClusterNumber = clusterId;
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = clusterGroupId;
        }

        public ClusterAddress(ClusterAddress o)
        {
            ClusterNumber = o.ClusterNumber;
            //Region = o.Region;
            //Site = o.Site;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;
        }

        public String UniqueId { get { return string.Format("{0}:{1:D5}", ClusterGroupId, ClusterNumber); } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 ClusterNumber { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string ClusterGroupId { get; set; }
        //        
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public GalaxyRegion Region { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public GalaxySite Site { get; set; }
        public override string ToString()
        {
            return UniqueId;
        }
    }

#if NetCoreApi
#else
    [DataContract]
#endif

    public class ClusterAddressSimple
    {
        public ClusterAddressSimple()
        {
            ClusterGroupId = 0;
        }

        public ClusterAddressSimple(Int32 clusterId)
        {
            ClusterNumber = clusterId;
            ClusterGroupId = 0;
        }

        public ClusterAddressSimple(Int32 clusterId, int clusterGroupId)
        {
            ClusterNumber = clusterId;
            ClusterGroupId = clusterGroupId;
        }

        public ClusterAddressSimple(ClusterAddress o)
        {
            ClusterNumber = o.ClusterNumber;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;
        }
        public ClusterAddressSimple(ClusterAddressSimple o)
        {
            ClusterNumber = o.ClusterNumber;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;
        }

        //public String UniqueId { get { return string.Format("{0}:{1:D5}", ClusterGroupId, ClusterNumber); } }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 ClusterNumber { get; set; }
      

        //public override string ToString()
        //{
        //    return UniqueId;
        //}
    }
}
