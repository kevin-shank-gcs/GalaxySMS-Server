using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Site
    {
        public Site()
        {
            Initialize();
        }

        public Site(Site e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Site e)
        {
            Initialize();
            if (e == null)
                return;
            this.SiteUid = e.SiteUid;
            this.RegionUid = e.RegionUid;
            this.SiteName = e.SiteName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.SiteId = e.SiteId;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.gcsBinaryResource = e.gcsBinaryResource;

        }

        public Site Clone(Site e)
        {
            return new Site(e);
        }

        public bool Equals(Site other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Site other)
        {
            if (other == null)
                return false;

            if (other.SiteUid != this.SiteUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
