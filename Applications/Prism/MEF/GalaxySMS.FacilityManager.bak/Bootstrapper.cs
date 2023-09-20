using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Bootstrapper;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.FacilityManager.Prism;
using GalaxySMS.FacilityManager.Properties;
using GalaxySMS.FacilityManager.Views;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.SharedServicesModule;
using GCS.Core.Prism;
using Prism.Mef;
using Prism.Regions;
using GalaxySMS.UserAuthentication;
using GalaxySMS.UserAuthentication.ViewModels;
using GCS.Core.Common.Core;
using GCS.Framework.Utilities;
using Prism.Modularity;
using Telerik.Windows.Controls;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Site;
using GalaxySMS.TelerikWPF.Infrastructure.Prism;

namespace GalaxySMS.FacilityManager
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.GetExportedValue<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();


            var currentUserPrincipal = UserPrincipal.Current;
            var cupType = currentUserPrincipal.GetType();
            PrincipalSearchResult<Principal> groups = UserPrincipal.Current.GetGroups();
            IEnumerable<string> groupNames = groups.Select(x => x.SamAccountName);
            var ident = WindowsIdentity.GetCurrent();
            if (ident != null)
            {
                //var p = new GenericPrincipal(ident, new string[] { "User" });
                var p = new GenericPrincipal(ident, groupNames.ToArray());
                Thread.CurrentPrincipal = p;
            }


            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var clientServices = Container.GetExportedValue<IClientServices>();

            var serverConnectionSettings = new GalaxySiteServerConnectionSettings();
            serverConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            serverConnectionSettings.ServerName = Settings.Default.ServerAddress;
            serverConnectionSettings.ServerAddress = Settings.Default.ServerAddress;
            serverConnectionSettings.PortNumber = Settings.Default.ServerPort;

            var siteServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);

            clientServices.Initialize(siteServerConnection, SystemUtilities.GetEntryAssemblyAttributes());
        }
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StackPanelRegionAdapter).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(SharedServicesModuleModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(DockingRegionAdapter).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ApplicationManager).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(UserAuthenticationModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(RegionModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(SiteModule).Assembly));

            var catalog = new List<ComposablePartCatalog>()
            {
                this.AggregateCatalog
            };

            ObjectBase.Container = MEFLoader.Init(catalog);
            //Container = ObjectBase.Container;
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.GetExportedValue<StackPanelRegionAdapter>());
            mappings.RegisterMapping(typeof(RadRibbonView), Container.GetExportedValue<RadRibbonRegionAdapter>());
            var regionBehaviorFactory = Container.GetExportedValue<IRegionBehaviorFactory>();
            mappings.RegisterMapping(typeof(RadDocking), Container.GetExportedValue<DockingRegionAdapter>());
            return mappings;
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(DependentViewRegionBehavior.BehaviorKey, typeof(DependentViewRegionBehavior));
            return behaviors;
        }
    }
}
