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
    public partial class AccessGroupLoadToCpu
    {
        public AccessGroupLoadToCpu()
        {
            Initialize();
        }

        public AccessGroupLoadToCpu(AccessGroupLoadToCpu e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessGroupLoadToCpu e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessGroupLoadToCpuUid = e.AccessGroupLoadToCpuUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.CpuUid = e.CpuUid;
            this.LastLoadedDate = e.LastLoadedDate;
            this.LastForceLoadDate = e.LastForceLoadDate;

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

        public AccessGroupLoadToCpu Clone(AccessGroupLoadToCpu e)
        {
            return new AccessGroupLoadToCpu(e);
        }

        public bool Equals(AccessGroupLoadToCpu other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroupLoadToCpu other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupLoadToCpuUid != this.AccessGroupLoadToCpuUid)
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
