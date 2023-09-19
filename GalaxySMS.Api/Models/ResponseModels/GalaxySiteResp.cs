using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{

    public class GalaxySiteResp
    {
        public GalaxySiteResp()
            : base()
        {
            SiteId = string.Empty;
            SiteName = string.Empty;
        }

        public GalaxySiteResp(String siteId, String siteName)
            : base()
        {
            SiteId = siteId;
            SiteName = siteName;
        }

        public GalaxySiteResp(GalaxySiteResp o)
        {
            SiteId = o.SiteId;
            SiteName = o.SiteName;
        }

        public String UniqueId { get { return SiteId; } }
        public String SiteId { get; set; }
        public String SiteName { get; set; }

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
