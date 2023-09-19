using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class GalaxyPanelModel
    {
        public GalaxyPanelModel()
        {
            Initialize();
        }

        public GalaxyPanelModel(GalaxyPanelModel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.GalaxyPanels = new HashSet<GalaxyPanel>();
            //this.GalaxyPanelModelGalaxyPanelCommands = new HashSet<GalaxyPanelModelGalaxyPanelCommand>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyPanelModel e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.TypeCode = e.TypeCode;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            //this.GalaxyPanels = e.GalaxyPanels.ToCollection();
            //this.GalaxyPanelModelGalaxyPanelCommands = e.GalaxyPanelModelGalaxyPanelCommands.ToCollection();

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

        public GalaxyPanelModel Clone(GalaxyPanelModel e)
        {
            return new GalaxyPanelModel(e);
        }

        public bool Equals(GalaxyPanelModel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelModel other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelModelUid != this.GalaxyPanelModelUid)
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
