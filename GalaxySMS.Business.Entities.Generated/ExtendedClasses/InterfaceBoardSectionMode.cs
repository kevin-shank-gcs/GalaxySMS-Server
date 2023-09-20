using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InterfaceBoardSectionMode
    {
        public InterfaceBoardSectionMode()
        {
            Initialize();
        }

        public InterfaceBoardSectionMode(InterfaceBoardSectionMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InterfaceBoardSectionMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.ModeCode = e.ModeCode;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public InterfaceBoardSectionMode Clone(InterfaceBoardSectionMode e)
        {
            return new InterfaceBoardSectionMode(e);
        }

        public bool Equals(InterfaceBoardSectionMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InterfaceBoardSectionMode other)
        {
            if (other == null)
                return false;

            if (other.InterfaceBoardSectionModeUid != this.InterfaceBoardSectionModeUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
