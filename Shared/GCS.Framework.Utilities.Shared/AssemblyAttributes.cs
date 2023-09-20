using System;

namespace GCS.Framework.Utilities
{
    public class AssemblyAttributes
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Configuration { get; set; }
        public string Company { get; set; }
        public string Product { get; set; }
        public string Copyright { get; set; }
        public string Trademark { get; set; }
        public string Culture { get; set; }
        public string AssemblyFileVersion { get; set; }
        //        public ThemeInfoAttribute ThemeInfo { get; set; }
        public Version Version { get; set; }
        public Guid Guid { get; set; }
        public string MajorMinorVersion
        {
            get { return string.Format("{0}.{1}", Version.Major, Version.Minor); }
            set { ;}
        }
    }

}
