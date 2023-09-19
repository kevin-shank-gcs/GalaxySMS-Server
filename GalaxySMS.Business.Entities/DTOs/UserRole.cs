using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class UserRole : EntityBase
    {
        public UserRole()
        {
            Init();
        }

        public UserRole(gcsRole role)
        {
            Init();
            if (role != null)
            {
                RoleId = role.RoleId;
                RoleName = role.RoleName;
                IsActive = role.IsActive;
                IsAdministratorRole = role.IsAdministratorRole;
            }
        }


        private void Init()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdministratorRole { get; set; }
        
    }
}
