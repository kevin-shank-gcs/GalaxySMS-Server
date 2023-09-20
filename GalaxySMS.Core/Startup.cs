using GalaxySMS.Core;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace GalaxySMS.Core
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //GlobalConfiguration.Configuration
            //    .UseSqlServerStorage(@"GalaxySMS-Hangfire");
            //app.UseHangfireDashboard();
        }
    }
}
