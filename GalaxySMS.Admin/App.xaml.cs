using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Themes;
using GalaxySMS.Client.Bootstrapper;
using GalaxySMS.Client.UI.ViewModels;
using GCS.Core.Common.Core;
using GCS.Core.Common.Localization;
using GCS.Core.Common.Logger;
using PDSA.MessageBroker;

namespace GalaxySMS.Admin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string LogFilename = "GalaxySMS.Admin.log";

        public void SwitchTheme(ThemeNameValuePair themeInfo)
        {
            ThemeSwitcher.SwitchTheme(themeInfo);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            this.Log().InfoFormat("OnStartup entered");
            base.OnStartup(e);
            var catalog = new List<ComposablePartCatalog>() 
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            };
            var uiAssembly = typeof(SignInOutViewModel).Assembly;
            catalog.Add(new AssemblyCatalog(uiAssembly));

//            ObjectBase.Container = MEFLoader.Init(catalog);
            StaticObjects.Container = MEFLoader.Init(catalog);
            this.Log().InfoFormat("OnStartup finished");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }


        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            string culture = Settings.Default.Culture;//ConfigurationManager.AppSettings["Culture"];
            string uiCulture = Settings.Default.UICulture;//ConfigurationManager.AppSettings["UICulture"];

            Localizer.SetCulture(culture, uiCulture);
            //ConfigurationManager.AppSettings["Culture"] = Thread.CurrentThread.CurrentCulture.ToString();
            //ConfigurationManager.AppSettings["UICulture"] = Thread.CurrentThread.CurrentUICulture.ToString();


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
            File.AppendAllText(LogFilename, logText);

            //// EQATEC: cancel application startup timing if ongoing, report app crash and exception
            //EqatecMonitor.Instance.TrackFeatureCancel(EqatecConstants.ApplicationStartupTime);
            //EqatecMonitor.Instance.TrackFeatureCancel(EqatecConstants.ApplicationUptime);
            //EqatecMonitor.Instance.TrackFeature(EqatecConstants.ApplicationCrash);
            //EqatecMonitor.Instance.TrackException(e.Exception, logText);

            MessageBox.Show(e.Exception.Message, "Error");
            e.Handled = true;
        }
    }
}
