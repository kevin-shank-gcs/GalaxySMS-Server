using System;
using System.Linq;

namespace GalaxySMS.TelerikWPF.Infrastructure.Analytics
{
    public static class EqatecConstants
    {
        public const string EqatecProductKey = "eqatecProductKey";

        // crashes
        public const string ApplicationCrash = "Application.Crash";

        // features to get time
        public const string ApplicationStartupTime = "Application.StartUpTime"; // the time between the app launch and the home view loaded
        public const string ApplicationUptime = "Application.UpTime";

        // themes to track
        public const string Theme = "Theme";

        // views to track
        public const string ViewDashboardUpTime = "Views.DashboardUpTime";
        public const string ViewCompaniesUpTime = "Views.CompaniesUpTime";
        public const string ViewContactsUpTime = "Views.ContactsUpTime";
        public const string ViewOpportunitiesUpTime = "Views.OpportunitiesUpTime";
        public const string ViewActivitiesUpTime = "Views.ActivitiesUpTime";
    }
}