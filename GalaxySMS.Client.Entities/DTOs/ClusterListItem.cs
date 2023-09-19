using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
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
                Image = o.gcsBinaryResource?.BinaryResource;
            }
        }

        [DataMember]
        public Guid Uid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int ClusterNumber { get; set; }

        [DataMember]
        public int ClusterGroupId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public ClusterCounts Counts { get; set; }

        public Cluster ToCluster()
        {
            var c = new Cluster()
            {
                ClusterUid = Uid,
                ClusterName = Name,
                Description = this.Description,
                ClusterGroupId = ClusterGroupId,
                ClusterNumber = ClusterNumber,
                IsActive = IsActive
            };
            if (Image != null)
                c.gcsBinaryResource = new gcsBinaryResource()
                {
                    BinaryResource = Image
                };
            return c;
        }
    }

}
