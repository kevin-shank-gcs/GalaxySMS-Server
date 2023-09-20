using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaxySMS.FacilityManager.Properties;
using GalaxySMS.FacilityManager.Themes;
using GCS.Core.Common.Localization;
using GCS.Core.Common.Logger;

namespace GalaxySMS.FacilityManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            string culture = Settings.Default.Culture;//ConfigurationManager.AppSettings["Culture"];
            string uiCulture = Settings.Default.UICulture;//ConfigurationManager.AppSettings["UICulture"];

            Localizer.SetCulture(culture, uiCulture);

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            this.Log().InfoFormat("OnStartup entered");

            base.OnStartup(e);
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            /* More detailed error message display */
            string exception = string.Empty;
            Exception ex = e.Exception;
            while (ex != null)
            {
                exception += String.Format("----------------\n{0}\n", ex.Message);
                exception += String.Format("{0}\n", ex.StackTrace);
                ex = ex.InnerException;
            }

            string logExceptionHeader = string.Format("Exception at {0}.{1} :", DateTimeOffset.Now, DateTimeOffset.Now.Millisecond);
            string logExceptionFooter = "End of exception.";
            string logText = string.Join(Environment.NewLine, logExceptionHeader, exception, logExceptionFooter, Environment.NewLine);
            this.Log().InfoFormat(logText);

            //// EQATEC: cancel application startup timing if ongoing, report app crash and exception
            //EqatecMonitor.Instance.TrackFeatureCancel(EqatecConstants.ApplicationStartupTime);
            //EqatecMonitor.Instance.TrackFeatureCancel(EqatecConstants.ApplicationUptime);
            //EqatecMonitor.Instance.TrackFeature(EqatecConstants.ApplicationCrash);
            //EqatecMonitor.Instance.TrackException(e.Exception, logText);

            MessageBox.Show(e.Exception.Message, "Error");
            e.Handled = true;
        }

        public void SwitchTheme(ThemeNameValuePair themeInfo)
        {
            ThemeSwitcher.SwitchTheme(themeInfo);
        }

    }
}
