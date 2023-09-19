using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanel
    {
        public GalaxyPanel()
        {
            Initialize();
        }

        public GalaxyPanel(GalaxyPanel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyPanel e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelIUid = e.GalaxyPanelIUid;
            this.ClusterUid = e.ClusterUid;
            this.PanelNumber = e.PanelNumber;
            this.PanelName = e.PanelName;
            this.Location = e.Location;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyPanel Clone(GalaxyPanel e)
        {
            return new GalaxyPanel(e);
        }

        public bool Equals(GalaxyPanel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanel other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelIUid != this.GalaxyPanelIUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
