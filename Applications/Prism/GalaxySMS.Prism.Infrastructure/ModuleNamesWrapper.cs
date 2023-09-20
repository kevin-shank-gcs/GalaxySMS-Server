using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Prism.Infrastructure
{
    /// <summary>
    /// Exposes ModuleNames' constants as properties - needed in XAML files, as we cannot use static/constants there.
    /// </summary>
    public class ModuleNamesWrapper
    {
        public static string ContactsModule
        {
            get
            {
                return ModuleNames.ContactsModule;
            }
        }

        public static string OpportunitiesModule
        {
            get
            {
                return ModuleNames.OpportunitiesModule;
            }
        }

        public static string CompaniesModule
        {
            get
            {
                return ModuleNames.CompaniesModule;
            }
        }

        public static string DashboardModule
        {
            get
            {
                return ModuleNames.DashboardModule;
            }
        }

        public static string ActivitiesModule
        {
            get
            {
                return ModuleNames.ActivitiesModule;
            }
        }
    }
}
