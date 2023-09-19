using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

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

        public String UniqueId { get { return SiteId; } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String SiteId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String SiteName { get; set; }

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
