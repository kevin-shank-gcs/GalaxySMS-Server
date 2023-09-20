using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class OutputDeviceGalaxyHardwareAddress
    {
        public OutputDeviceGalaxyHardwareAddress()
        {
            Initialize();
        }

        public OutputDeviceGalaxyHardwareAddress(OutputDeviceGalaxyHardwareAddress e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(OutputDeviceGalaxyHardwareAddress e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.OutputDeviceGalaxyHardwareAddressUid = e.OutputDeviceGalaxyHardwareAddressUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
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

        public OutputDeviceGalaxyHardwareAddress Clone(OutputDeviceGalaxyHardwareAddress e)
        {
            return new OutputDeviceGalaxyHardwareAddress(e);
        }

        public bool Equals(OutputDeviceGalaxyHardwareAddress other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(OutputDeviceGalaxyHardwareAddress other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceGalaxyHardwareAddressUid != this.OutputDeviceGalaxyHardwareAddressUid)
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