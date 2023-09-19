using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class GalaxySite : EntityBase
    {
        public GalaxySite()
            : base()
        {
            SiteId = string.Empty;
            SiteName = string.Empty;
        }

        public GalaxySite(String siteId, String siteName)
            : base()
        {
            SiteId = siteId;
            SiteName = siteName;
        }

        public GalaxySite(GalaxySite o)
            : base(o)
        {
            SiteId = o.SiteId;
            SiteName = o.SiteName;
        }

        //		[DataMember]
        public String UniqueId { get { return SiteId; } }

        [DataMember]
        public String SiteId { get; set; }

        [DataMember]
        public String SiteName { get; set; }

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
