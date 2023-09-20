using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using SystemGalaxyDataImporter.Properties;
using GalaSoft.MvvmLight.Threading;
using GalaxySMS.Client.Bootstrapper;
using GCS.Core.Common.Core;
using GCS.Core.Common.Localization;
using GCS.Core.Common.Logger;

namespace SystemGalaxyDataImporter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        private const string LogFilename = "GalaxySMS.ClientAPI.Sample.log";
        
        static App()
        {
            DispatcherHelper.Initialize();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            this.Log().InfoFormat("OnStartup entered");
            base.OnStartup(e);

            // Define an unhandled exception handler method so the application doesn't crash
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

            // Setup the thread Culture and UICulture properties.
            string culture = "en-US";//Settings.Default.Culture;
            string uiCulture = "en-US";//Settings.Default.UICulture;
            Localizer.SetCulture(culture, uiCulture);

            // Setup MEF for proper functionality. Without this, the Globals.GetManager<T> (which relies on Helpers.GetManager<T>) helper method will not be able to resolve manager classes
            SetupMEF();
            this.Log().InfoFormat("OnStartup finished");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets up MEF Dependency Injection. </summary>
        ///
        /// <remarks>   Kevin, 12/28/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetupMEF()
        {
            // Define a catalog for MEF DI and add the current executing assembly to it
            var catalog = new List<ComposablePartCatalog>()
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            };

            // Add any additional assemblies which contain classes that MEF needs to be able to resolve
            //var mefAssembly = typeof(ClassName).Assembly;
            //catalog.Add(new AssemblyCatalog(mefAssembly));

            // Call the GalaxySMS.Client.Bootstrapper.MEFLoader.Init() method. This will take care of registering all the GalaxySMS.Client.SDK manager classes with MEF
            // The result must be saved as a static (singleton) property so that it can be used throughout the application
            // ObjectBase is found in the GCS.Core.Common.Core namespace
//            ObjectBase.Container = MEFLoader.Init(catalog);
            StaticObjects.Container = MEFLoader.Init(catalog);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by App for dispatcher unhandled exception events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/28/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Dispatcher unhandled exception event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

            MessageBox.Show(e.Exception.Message, "Error");
            e.Handled = true;
        }
    }
}
