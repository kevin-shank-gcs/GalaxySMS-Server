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
    public partial class RoleOutputDevicePermission
    {
        public RoleOutputDevicePermission()
        {
            Initialize();
        }

        public RoleOutputDevicePermission(RoleOutputDevicePermission e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleOutputDevicePermission e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleOutputDevicePermissionUid = e.RoleOutputDevicePermissionUid;
            this.RoleOutputDeviceUid = e.RoleOutputDeviceUid;
            this.PermissionId = e.PermissionId;
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

        public RoleOutputDevicePermission Clone(RoleOutputDevicePermission e)
        {
            return new RoleOutputDevicePermission(e);
        }

        public bool Equals(RoleOutputDevicePermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleOutputDevicePermission other)
        {
            if (other == null)
                return false;

            if (other.RoleOutputDevicePermissionUid != this.RoleOutputDevicePermissionUid)
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
