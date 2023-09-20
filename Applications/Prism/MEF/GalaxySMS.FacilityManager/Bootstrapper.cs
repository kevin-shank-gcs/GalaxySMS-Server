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
using GalaxySMS.AccessPortal;
using GalaxySMS.AssaAbloy;
using GalaxySMS.Client.Bootstrapper;
using GalaxySMS.Client.Proxies;
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
using GalaxySMS.Region;
using GalaxySMS.Site;
using GalaxySMS.UserControls;
using GalaxySMS.TelerikWPF.Infrastructure.Prism;
using GCS.Core.Common.Logger;
using GalaxySMS.Schedule;
using GalaxySMS.GalaxyHardware;
using GalaxySMS.MonitoredDevice;
using GalaxySMS.OutputDevice;
using GalaxySMS.PersonCredential;
using GCS.Core.Common.Extensions;

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

            try
            {
                var c = WindowsIdentity.GetCurrent();
                Thread.CurrentPrincipal = new GenericPrincipal(WindowsIdentity.GetCurrent(), GetGroups(c.Name));

                //var currentUserPrincipal = UserPrincipal.Current;
                //var cupType = currentUserPrincipal.GetType();
                ////The GetGroups() call times out
                //PrincipalSearchResult<Principal> groups = UserPrincipal.Current.GetGroups();
                //IEnumerable<string> groupNames = groups.Select(x => x.SamAccountName);
                //var ident = WindowsIdentity.GetCurrent();
                //if (ident != null)
                //{
                //    //var p = new GenericPrincipal(ident, new string[] { "User" });
                //    var p = new GenericPrincipal(ident, groupNames.ToArray());
                //    Thread.CurrentPrincipal = p;
                //}
            }
            catch (InvalidOperationException ex)
            {
                this.Log().ErrorFormat("Bootstrapper::InitializeShell: {0}", ex.ToString());
            }
            catch (NoMatchingPrincipalException ex)
            {
                this.Log().ErrorFormat("Bootstrapper::InitializeShell: {0}", ex.ToString());
            }
            catch (MultipleMatchesException ex)
            {
                this.Log().ErrorFormat("Bootstrapper::InitializeShell: {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("Bootstrapper::InitializeShell: {0}", ex.ToString());
            }

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }


        public static string[] GetGroups(string username)
        {
            string[] output = null;
            return new List<string>().ToStringArray();
            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (var user = UserPrincipal.FindByIdentity(ctx, username))
            {
                if (user != null)
                {
                    output = user.GetGroups() //this returns a collection of principal objects
                        .Select(x => x.SamAccountName) // select the name.  you may change this to choose the display name or whatever you want
                        .ToArray(); // convert to string array
                }
            }

            return output;
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
            serverConnectionSettings.ApiServerUrl = Settings.Default.ApiServerUrl;
            serverConnectionSettings.SignalRServerUrl = Settings.Default.SignalRServerUrl;

            var siteServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);

            clientServices.Initialize(siteServerConnection, SystemUtilities.GetEntryAssemblyAttributes());
            clientServices.DefaultGridPageSize = Settings.Default.DefaultGridPageSize;
            clientServices.ThumbnailPixelWidth = Settings.Default.ThumbnailPixelWidth;
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
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(UserControlsModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AccessPortalModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AssaAbloyModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ScheduleModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(GalaxyHardwareModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(PersonCredentialModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MonitoredDeviceModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(OutputDeviceModule).Assembly));
            var catalog = new List<ComposablePartCatalog>()
            {
                this.AggregateCatalog
            };

//            ObjectBase.Container = MEFLoader.Init(catalog);
            StaticObjects.Container = MEFLoader.Init(catalog);
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
