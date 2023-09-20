using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.Support
{
    public class RoleEventArgs : EventArgs
    {
        public RoleEventArgs(gcsRole role, bool isNew)
        {
            Role = role;
            IsNew = isNew;
        }

        public gcsRole Role { get; set; }
        public bool IsNew { get; set; }    }
}
