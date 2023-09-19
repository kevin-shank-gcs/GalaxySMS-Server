using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Prism;
using GalaxySMS.Prism.Properties;
using GalaxySMS.Prism.Views;
using GCS.Core.Prism;
using GCS.Framework.Utilities;
using Prism.Modularity;
using Prism.Regions;
using Telerik.Windows.Controls;

namespace GalaxySMS.Prism
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            //TODO: get your login/role information from your source and set the IIdentity/IPrincipal
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

            //create an instance of our module manager
            var moduleManager = Container.Resolve<IModuleManager>();
            moduleManager.LoadModule("ServicesModule");

            var clientServices = Container.Resolve<IClientServices>();
            clientServices.MyAssemblyAttributes = SystemUtilities.GetEntryAssemblyAttributes();

            clientServices.ServerConnections = new ObservableCollection<IGalaxySiteServerConnection>();

            var serverConnectionSettings = new GalaxySiteServerConnectionSettings();
            serverConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            serverConnectionSettings.ServerName = Settings.Default.ServerAddress;
            serverConnectionSettings.ServerAddress = Settings.Default.ServerAddress;
            serverConnectionSettings.PortNumber = Settings.Default.ServerPort;

            var siteServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);
            clientServices.ServerConnections.Add(siteServerConnection);

            Application.Current.MainWindow.Show();
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            //// By Directory
            //return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };

            // In Code - Application must have reference to the module assemblies
            ModuleCatalog catalog = new ModuleCatalog();

            catalog.AddModule(typeof(GalaxySMS.Services.ServicesModule));
            catalog.AddModule(typeof(GalaxySMS.SignInOut.SignInOutModule));
            
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IModuleInitializer, GCS.Core.Prism.RoleBasedModuleInitializer>(new ContainerControlledLifetimeManager());
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(RadRibbonView), Container.Resolve<RadRibbonRegionAdapter>());
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
