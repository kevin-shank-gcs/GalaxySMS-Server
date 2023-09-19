using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.Support
{
    public class PermissionEventArgs : EventArgs
    {
        public PermissionEventArgs(gcsPermission permission, bool isNew)
        {
            Permission = permission;
            IsNew = isNew;
        }

        public gcsPermission Permission { get; set; }
        public bool IsNew { get; set; }    }
}
