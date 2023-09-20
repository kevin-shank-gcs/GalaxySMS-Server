using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class RegionListItem
    {

        public RegionListItem()
        {
            RegionUid = Guid.Empty;
            RegionName = string.Empty;
            Sites = new List<SiteListItem>();

        }

        [DataMember]
        public Guid RegionUid { get; set; }

        [DataMember]
        public string RegionName { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]

        public IList<SiteListItem> Sites { get; set; }
    }
}
