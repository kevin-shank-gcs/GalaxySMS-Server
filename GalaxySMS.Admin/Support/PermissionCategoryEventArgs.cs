using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.Support
{
    public class PermissionCategoryEventArgs : EventArgs
    {
        public PermissionCategoryEventArgs(gcsPermissionCategory permissionCategory, bool isNew)
        {
            PermissionCategory = permissionCategory;
            IsNew = isNew;
        }

        public gcsPermissionCategory PermissionCategory { get; set; }
        public bool IsNew { get; set; }    }
}
