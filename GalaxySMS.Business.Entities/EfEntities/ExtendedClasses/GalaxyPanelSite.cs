using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanelSite
    {
        public GalaxyPanelSite()
        {
            Initialize();
        }

        public GalaxyPanelSite(GalaxyPanelSite e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyPanelSite e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelSiteUid = e.GalaxyPanelSiteUid;
            this.GalaxyPanelIUid = e.GalaxyPanelIUid;
            this.SiteUid = e.SiteUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyPanelSite Clone(GalaxyPanelSite e)
        {
            return new GalaxyPanelSite(e);
        }

        public bool Equals(GalaxyPanelSite other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelSite other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelSiteUid != this.GalaxyPanelSiteUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
