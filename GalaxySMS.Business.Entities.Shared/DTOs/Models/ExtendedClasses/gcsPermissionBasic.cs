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
	public partial class gcsPermissionBasic
    {
        public gcsPermissionBasic()
        {
            Initialize();
        }

        public gcsPermissionBasic(gcsPermission e)
        {
            Initialize(e);
        }
        public gcsPermissionBasic(gcsPermissionBasic e)
        {
            Initialize(e);
        }


        public void Initialize()
        {
        }

        public void Initialize(gcsPermission e)
        {
            Initialize();
            if (e == null)
                return;
            this.PermissionCategoryId = e.PermissionCategoryId;
            this.PermissionDescription = e.PermissionDescription;
            this.PermissionId = e.PermissionId;
            this.PermissionName = e.PermissionName;
            this.PermissionTypeId = e.PermissionTypeId;
            this.IsActive = e.IsActive;
            this.Code = e.Code;
        }
        public void Initialize(gcsPermissionBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.PermissionCategoryId = e.PermissionCategoryId;
            this.PermissionDescription = e.PermissionDescription;
            this.PermissionId = e.PermissionId;
            this.PermissionName = e.PermissionName;
            this.PermissionTypeId = e.PermissionTypeId;
            this.IsActive = e.IsActive;
            this.Code = e.Code;
        }

        public gcsPermissionBasic Clone(gcsPermissionBasic e)
        {
            return new gcsPermissionBasic(e);
        }

        public bool Equals(gcsPermissionBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsPermissionBasic other)
        {
            if (other == null)
                return false;

            if (other.PermissionId != this.PermissionId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return PermissionName;
        }


    }
}
