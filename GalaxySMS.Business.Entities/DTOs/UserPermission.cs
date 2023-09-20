using System;
using System.Collections.Generic;
using System.Security;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class UserPermission : EntityBase
    {
        public UserPermission()
        {
            Init();
        }

        public UserPermission(gcsPermission permission)
        {
            Init();
            if (permission != null)
            {
                PermissionId = permission.PermissionId;
                PermissionName = permission.PermissionName;
            }
        }

        private void Init()
        {
        }

        public Guid PermissionId { get; set; }

        public string PermissionName { get; set; }



    }
}
