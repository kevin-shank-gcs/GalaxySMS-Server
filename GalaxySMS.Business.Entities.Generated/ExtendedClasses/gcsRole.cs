using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsRole
    {
        public gcsRole()
        {
            Initialize();
        }

        public gcsRole(gcsRole e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsEntityApplicationRoles = new HashSet<gcsEntityApplicationRole>();
            this.RolePermissions = new HashSet<gcsRolePermission>();
        }

        public void Initialize(gcsRole e)
        {
            Initialize();
            if (e == null)
                return;
            this.RoleId = e.RoleId;
            this.ApplicationId = e.ApplicationId;
            this.RoleName = e.RoleName;
            this.RoleDescription = e.RoleDescription;
            this.IsActive = e.IsActive;
            this.IsDefault = e.IsDefault;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsEntityApplicationRoles = e.gcsEntityApplicationRoles.ToCollection();
            this.RolePermissions = e.RolePermissions.ToCollection();
            this.IsAuthorized = e.IsAuthorized;

        }

        public gcsRole Clone(gcsRole e)
        {
            return new gcsRole(e);
        }

        public bool Equals(gcsRole other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsRole other)
        {
            if (other == null)
                return false;

            if (other.RoleId != this.RoleId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return RoleName;
        }

        // Custom properties
        public bool IsAuthorized { get; set; }
    }
}
