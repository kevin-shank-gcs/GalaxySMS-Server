using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Themes
{
    public class ThemeNameValuePair
    {
        public ThemeNameValuePair(string assemblyName, string displayName, string variationName)
        {
            AssemblyName = assemblyName;
            DisplayName = displayName;
            VariationName = variationName;
        }

        public string AssemblyName { get; set; }
        public string DisplayName { get; set; }
        public string VariationName { get; set; }
    }
}
