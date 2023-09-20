using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanelModelGalaxyPanelCommand
    {
        public GalaxyPanelModelGalaxyPanelCommand()
        {
            Initialize();
        }

        public GalaxyPanelModelGalaxyPanelCommand(GalaxyPanelModelGalaxyPanelCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyPanelModelGalaxyPanelCommand e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelModelGalaxyPanelCommandUid = e.GalaxyPanelModelGalaxyPanelCommandUid;
            this.GalaxyPanelCommandUid = e.GalaxyPanelCommandUid;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyPanelModelGalaxyPanelCommand Clone(GalaxyPanelModelGalaxyPanelCommand e)
        {
            return new GalaxyPanelModelGalaxyPanelCommand(e);
        }

        public bool Equals(GalaxyPanelModelGalaxyPanelCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelModelGalaxyPanelCommand other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelModelGalaxyPanelCommandUid != this.GalaxyPanelModelGalaxyPanelCommandUid)
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
