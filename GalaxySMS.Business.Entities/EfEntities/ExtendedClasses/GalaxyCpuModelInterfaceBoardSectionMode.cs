using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyCpuModelInterfaceBoardSectionMode
    {
        public GalaxyCpuModelInterfaceBoardSectionMode()
        {
            Initialize();
        }

        public GalaxyCpuModelInterfaceBoardSectionMode(GalaxyCpuModelInterfaceBoardSectionMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyCpuModelInterfaceBoardSectionMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyCpuModelInterfaceBoardSectionModeUid = e.GalaxyCpuModelInterfaceBoardSectionModeUid;
            this.GalaxyCpuModelUid = e.GalaxyCpuModelUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyCpuModelInterfaceBoardSectionMode Clone(GalaxyCpuModelInterfaceBoardSectionMode e)
        {
            return new GalaxyCpuModelInterfaceBoardSectionMode(e);
        }

        public bool Equals(GalaxyCpuModelInterfaceBoardSectionMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpuModelInterfaceBoardSectionMode other)
        {
            if (other == null)
                return false;

            if (other.GalaxyCpuModelInterfaceBoardSectionModeUid != this.GalaxyCpuModelInterfaceBoardSectionModeUid)
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
