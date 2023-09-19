using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.Support
{
    public class ApplicationEventArgs : EventArgs
    {
        public ApplicationEventArgs(gcsApplication application, bool isNew)
        {
            Application = application;
            IsNew = isNew;
        }

        public gcsApplication Application { get; set; }
        public bool IsNew { get; set; }    }
}
