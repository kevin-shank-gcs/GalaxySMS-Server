
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyInterfaceBoard
    {
        public GalaxyInterfaceBoard()
        {
            Initialize();
        }

        public GalaxyInterfaceBoard(GalaxyInterfaceBoard e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyInterfaceBoard e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyPanelIUid = e.GalaxyPanelIUid;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.BoardNumber = e.BoardNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyInterfaceBoard Clone(GalaxyInterfaceBoard e)
        {
            return new GalaxyInterfaceBoard(e);
        }

        public bool Equals(GalaxyInterfaceBoard other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoard other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardUid != this.GalaxyInterfaceBoardUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
