using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class MercScpGroupListItem
    {
        public MercScpGroupListItem()
        {
            Uid = Guid.Empty;
        }

        public MercScpGroupListItem(MercScpGroup o)
        {
            Uid = Guid.Empty;
            Name = String.Empty;
            if (o != null)
            {
                Uid = o.MercScpGroupUid;
                Name = o.Name;
                Description = o.Description;
                IsActive = o.IsActive;
                //Image = o.gcsBinaryResource?.BinaryResource;
            }
        }

        [DataMember]
        public Guid Uid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        //[DataMember]
        //public int ClusterNumber { get; set; }

        //[DataMember]
        //public int ClusterGroupId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public MercScpGroupCounts Counts { get; set; }

        public MercScpGroup ToMercScpGroup()
        {
            var c = new MercScpGroup()
            {
                MercScpGroupUid = Uid,
                Name = Name,
                Description = this.Description,
                //ClusterGroupId = ClusterGroupId,
                //ClusterNumber = ClusterNumber,
                IsActive = IsActive
            };
            //if (Image != null)
            //    c.gcsBinaryResource = new gcsBinaryResource()
            //    {
            //        BinaryResource = Image
            //    };
            return c;
        }
    }

}
