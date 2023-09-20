using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsPermission
    {
        public gcsPermission()
        {
            Initialize();
        }

        public gcsPermission(gcsPermission e)
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
            this.PermissionId = e.PermissionId;
            this.PermissionCategoryId = e.PermissionCategoryId;
            this.PermissionTypeId = e.PermissionTypeId;
            this.PermissionName = e.PermissionName;
            this.PermissionDescription = e.PermissionDescription;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsPermission Clone(gcsPermission e)
        {
            return new gcsPermission(e);
        }

        public bool Equals(gcsPermission other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsPermission other)
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
    }
}
