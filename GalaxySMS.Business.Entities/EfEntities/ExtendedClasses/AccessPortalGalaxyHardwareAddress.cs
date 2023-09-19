using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalGalaxyHardwareAddress
    {
        public AccessPortalGalaxyHardwareAddress()
        {
            Initialize();
        }

        public AccessPortalGalaxyHardwareAddress(AccessPortalGalaxyHardwareAddress e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalGalaxyHardwareAddress e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalGalaxyHardwareAddressUid = e.AccessPortalGalaxyHardwareAddressUid;
            this.AccessPortalUid = e.AccessPortalUid;
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

        public AccessPortalGalaxyHardwareAddress Clone(AccessPortalGalaxyHardwareAddress e)
        {
            return new AccessPortalGalaxyHardwareAddress(e);
        }

        public bool Equals(AccessPortalGalaxyHardwareAddress other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalGalaxyHardwareAddress other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalGalaxyHardwareAddressUid != this.AccessPortalGalaxyHardwareAddressUid)
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
