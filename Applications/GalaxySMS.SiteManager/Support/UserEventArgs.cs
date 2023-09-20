using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.SiteManager.Support
{
    public class UserEventArgs : EventArgs
    {
        public UserEventArgs(gcsUser user, bool isNew)
        {
            User = user;
            IsNew = isNew;
        }

        public gcsUser User { get; set; }
        public bool IsNew { get; set; }
    }
}
