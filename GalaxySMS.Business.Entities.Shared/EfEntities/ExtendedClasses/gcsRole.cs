using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            //this.gcsEntityApplicationRoles = new HashSet<gcsEntityApplicationRole>();
            this.RolePermissions = new HashSet<gcsRolePermission>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsRole e)
        {
            Initialize();
            if (e == null)
                return;
            this.RoleId = e.RoleId;
            this.EntityId = e.EntityId;
            this.RoleName = e.RoleName;
            this.RoleDescription = e.RoleDescription;
            this.IsActive = e.IsActive;
            this.IsDefault = e.IsDefault;
            this.IsAdministratorRole = e.IsAdministratorRole;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.gcsEntityApplicationRoles = e.gcsEntityApplicationRoles.ToCollection();
            if (e.RolePermissions != null)
                this.RolePermissions = e.RolePermissions.ToCollection();
            this.DeviceFilters = e.DeviceFilters;
            this.IsAuthorized = e.IsAuthorized;
            //this.EntityApplicationRoleId = e.EntityApplicationRoleId;
            this.TotalRowCount = e.TotalRowCount;
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAuthorized { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityApplicationRoleId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }
    }
}
