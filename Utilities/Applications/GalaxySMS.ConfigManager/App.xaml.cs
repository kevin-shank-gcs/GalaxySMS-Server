using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using GalaxySMS.ConfigManager.Bootstrapper;
using GalaxySMS.ConfigManager.Properties;
using GalaxySMS.ConfigManager.Themes;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;

namespace GalaxySMS.ConfigManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string culture = Settings.Default.Culture;
            string uiCulture = Settings.Default.UICulture;

            GCS.Core.Common.Localization.Localizer.SetCulture(culture, uiCulture);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            this.Log().Info("App.OnStartup entered");
            base.OnStartup(e);
            var catalog = new List<ComposablePartCatalog>()
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            };

            // Add additional assemblies to the catalog as needed
            //catalog.Add(new AssemblyCatalog(uiAssembly));

            ObjectBase.Container = MEFLoader.Init(catalog);
            new MainWindow().Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            this.Log().InfoFormat("App.OnExit entered. ExitCode:{0}", e.ApplicationExitCode);
            base.OnExit(e);
        }

        public void SwitchTheme(ThemeNameValuePair themeInfo)
        {
            ThemeSwitcher.SwitchTheme(themeInfo);
        }


    }
}
