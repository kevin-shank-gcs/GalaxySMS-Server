using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsPermissionCategory
    {
        public gcsPermissionCategory()
        {
            Initialize();
        }

        public gcsPermissionCategory(gcsPermissionCategory e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsPermissions = new HashSet<gcsPermission>();
        }

        public void Initialize(gcsPermissionCategory e)
        {
            Initialize();
            if (e == null)
                return;
            this.PermissionCategoryId = e.PermissionCategoryId;
            this.ApplicationId = e.ApplicationId;
            this.CategoryName = e.CategoryName;
            this.PermissionCategoryDescription = e.PermissionCategoryDescription;
            this.IsSystemCategory = e.IsSystemCategory;
            this.IsEntityCategory = e.IsEntityCategory;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsPermissions = e.gcsPermissions.ToCollection();
        }

        public gcsPermissionCategory Clone(gcsPermissionCategory e)
        {
            return new gcsPermissionCategory(e);
        }

        public bool Equals(gcsPermissionCategory other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsPermissionCategory other)
        {
            if (other == null)
                return false;

            if (other.PermissionCategoryId != this.PermissionCategoryId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
