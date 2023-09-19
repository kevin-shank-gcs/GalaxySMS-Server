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
	public partial class GalaxyPanelModelInterfaceBoardType
    {
        public GalaxyPanelModelInterfaceBoardType()
        {
            Initialize();
        }

        public GalaxyPanelModelInterfaceBoardType(GalaxyPanelModelInterfaceBoardType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyPanelModelInterfaceBoardType e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelModelInterfaceBoardTypeUid = e.GalaxyPanelModelInterfaceBoardTypeUid;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyPanelModelInterfaceBoardType Clone(GalaxyPanelModelInterfaceBoardType e)
        {
            return new GalaxyPanelModelInterfaceBoardType(e);
        }

        public bool Equals(GalaxyPanelModelInterfaceBoardType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelModelInterfaceBoardType other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelModelInterfaceBoardTypeUid != this.GalaxyPanelModelInterfaceBoardTypeUid)
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
