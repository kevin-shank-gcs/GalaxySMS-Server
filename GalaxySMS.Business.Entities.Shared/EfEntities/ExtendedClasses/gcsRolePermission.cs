using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
	public partial class gcsRolePermission
    {
        public gcsRolePermission()
        {
            Initialize();
        }

        public gcsRolePermission(gcsRolePermission e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsRolePermission e)
        {
            Initialize();
            if (e == null)
                return;
            this.RolePermissionId = e.RolePermissionId;
            this.RoleId = e.RoleId;
            this.PermissionId = e.PermissionId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.PermissionName = e.PermissionName;
        }

        public gcsRolePermission Clone(gcsRolePermission e)
        {
            return new gcsRolePermission(e);
        }

        public bool Equals(gcsRolePermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsRolePermission other)
        {
            if (other == null)
                return false;

            if (other.RolePermissionId != this.RolePermissionId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string PermissionName { get; set; }

    }
}
