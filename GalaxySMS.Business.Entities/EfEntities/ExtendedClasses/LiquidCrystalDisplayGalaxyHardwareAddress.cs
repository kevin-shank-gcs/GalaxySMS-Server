using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class LiquidCrystalDisplayGalaxyHardwareAddress
    {
        public LiquidCrystalDisplayGalaxyHardwareAddress()
        {
            Initialize();
        }

        public LiquidCrystalDisplayGalaxyHardwareAddress(LiquidCrystalDisplayGalaxyHardwareAddress e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(LiquidCrystalDisplayGalaxyHardwareAddress e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.LiquidCrystalDisplayGalaxyHardwareAddressUid = e.LiquidCrystalDisplayGalaxyHardwareAddressUid;
            this.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public LiquidCrystalDisplayGalaxyHardwareAddress Clone(LiquidCrystalDisplayGalaxyHardwareAddress e)
        {
            return new LiquidCrystalDisplayGalaxyHardwareAddress(e);
        }

        public bool Equals(LiquidCrystalDisplayGalaxyHardwareAddress other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(LiquidCrystalDisplayGalaxyHardwareAddress other)
        {
            if (other == null)
                return false;

            if (other.LiquidCrystalDisplayGalaxyHardwareAddressUid != this.LiquidCrystalDisplayGalaxyHardwareAddressUid)
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