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
    public class ClusterListItem
    {
        public ClusterListItem()
        {
            Uid = Guid.Empty;
        }

        public ClusterListItem(Cluster o)
        {
            Uid = Guid.Empty;
            Name = String.Empty;
            if (o != null)
            {
                Uid = o.ClusterUid;
                Name = o.ClusterName;
                Description = o.Description;
                ClusterNumber = o.ClusterNumber;
                ClusterGroupId = o.ClusterGroupId;
                IsActive = o.IsActive;
#if NetCoreApi
#else
                Image = o.gcsBinaryResource?.BinaryResource;
#endif
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid Uid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
        public byte[] Image { get; set; }
#endif

#if NetCoreApi
#else
        [DataMember]
#endif
        public ClusterCounts Counts { get; set; }
    }

}
