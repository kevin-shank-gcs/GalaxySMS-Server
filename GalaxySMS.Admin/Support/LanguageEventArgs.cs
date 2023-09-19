using System;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin.Support
{
    public class LanguageEventArgs : EventArgs
    {
        public LanguageEventArgs(gcsLanguage language, bool isNew)
        {
            Language = language;
            IsNew = isNew;
        }

        public gcsLanguage Language { get; set; }
        public bool IsNew { get; set; }    }
}
