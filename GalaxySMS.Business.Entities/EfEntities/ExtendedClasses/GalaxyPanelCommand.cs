using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanelCommand
    {
        public GalaxyPanelCommand()
        {
            Initialize();
        }

        public GalaxyPanelCommand(GalaxyPanelCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyPanelModelGalaxyPanelCommands = new HashSet<GalaxyPanelModelGalaxyPanelCommand>();
            this.GalaxyPanelModelIds = new HashSet<Guid>();
        }

        public void Initialize(GalaxyPanelCommand e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelCommandUid = e.GalaxyPanelCommandUid;
            this.CommandCode = e.CommandCode;
            this.IsActive = e.IsActive;
            this.IsFlashingCommand = e.IsFlashingCommand;

            this.GalaxyPanelModelGalaxyPanelCommands = e.GalaxyPanelModelGalaxyPanelCommands.ToCollection();
            this.GalaxyPanelModelIds = e.GalaxyPanelModelIds.ToCollection();

            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
        }

        public GalaxyPanelCommand Clone(GalaxyPanelCommand e)
        {
            return new GalaxyPanelCommand(e);
        }

        public bool Equals(GalaxyPanelCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelCommand other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelCommandUid != this.GalaxyPanelCommandUid)
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
