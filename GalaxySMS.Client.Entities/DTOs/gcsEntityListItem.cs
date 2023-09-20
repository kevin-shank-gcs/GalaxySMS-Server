using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]

    public class gcsEntityListItem
    {

        public gcsEntityListItem()
        {
            EntityId = Guid.Empty;
            EntityName = string.Empty;
            Regions = new List<RegionListItem>();
        }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string EntityName { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]

        public IList<RegionListItem> Regions { get; set; }
    }
}
