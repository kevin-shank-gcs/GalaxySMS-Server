using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public class SiteListItem
    {
        public SiteListItem()
        {
            SiteUid = Guid.Empty;
            SiteName = String.Empty;
        }

        [DataMember]
        public Guid SiteUid { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public byte[] Image { get; set; }
    }
}
