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
	public partial class GalaxyPanelModelInterfaceBoardSectionMode
    {
        public GalaxyPanelModelInterfaceBoardSectionMode()
        {
            Initialize();
        }

        public GalaxyPanelModelInterfaceBoardSectionMode(GalaxyPanelModelInterfaceBoardSectionMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyPanelModelInterfaceBoardSectionMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelModelInterfaceBoardSectionModeUid = e.GalaxyPanelModelInterfaceBoardSectionModeUid;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyPanelModelInterfaceBoardSectionMode Clone(GalaxyPanelModelInterfaceBoardSectionMode e)
        {
            return new GalaxyPanelModelInterfaceBoardSectionMode(e);
        }

        public bool Equals(GalaxyPanelModelInterfaceBoardSectionMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelModelInterfaceBoardSectionMode other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelModelInterfaceBoardSectionModeUid != this.GalaxyPanelModelInterfaceBoardSectionModeUid)
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
