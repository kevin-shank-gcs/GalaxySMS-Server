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
    public partial class AccessPortalLoadToCpu
    {
        public AccessPortalLoadToCpu()
        {
            Initialize();
        }

        public AccessPortalLoadToCpu(AccessPortalLoadToCpu e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalLoadToCpu e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalLoadToCpuUid = e.AccessPortalLoadToCpuUid;
            this.AccessPortalGalaxyHardwareAddressUid = e.AccessPortalGalaxyHardwareAddressUid;
            this.CpuUid = e.CpuUid;
            this.LastForceLoadDate = e.LastForceLoadDate;
            this.LastLoadedDate = e.LastLoadedDate;

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

        public AccessPortalLoadToCpu Clone(AccessPortalLoadToCpu e)
        {
            return new AccessPortalLoadToCpu(e);
        }

        public bool Equals(AccessPortalLoadToCpu other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalLoadToCpu other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalLoadToCpuUid != this.AccessPortalLoadToCpuUid)
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
