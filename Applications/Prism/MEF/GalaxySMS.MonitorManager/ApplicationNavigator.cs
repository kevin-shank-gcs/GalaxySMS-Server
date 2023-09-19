using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Prism.Infrastructure;
using Prism.Modularity;
using Prism.Regions;

namespace GalaxySMS.MonitorManager
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class ApplicationNavigator
    {
        [Import]
        public AtomicModuleLoader ModuleLoader { private get; set; }

        [Import]
        public IModuleManager ModuleManager { private get; set; }

        [Import]
        public IRegionManager RegionManager { private get; set; }

        [Import]
        public IModuleCatalog ModuleCatalog { private get; set; }

        private readonly IDictionary<string, string> moduleDefaultViewNames = new Dictionary<string, string>()
        {
            { ModuleNames.DashboardModule, "DashboardView" },
            { ModuleNames.CompaniesModule, "CompaniesView" },
            { ModuleNames.ActivitiesModule, "ActivitiesView" },
            { ModuleNames.ContactsModule, "ContactsView" },
            { ModuleNames.OpportunitiesModule, "OpportunitiesView" }
        };

        private string currentUri;
        public void NavigateToModule(string uri, Action<int> progressChangedCallback = null, Action completedCallback = null)
        {
            this.currentUri = uri;

            if (this.ModuleLoader.IsModuleLoaded(uri))
            {
                this.NavigateToDefaultRegion(uri);
                completedCallback();
            }
            else
            {
                EventHandler completed = null;
                EventHandler<ProgressChangedEventArgs> progressChanged = null;
                completed = (s, e) =>
                {
                    this.ModuleLoader.PriorityOperationCompleted -= completed;
                    this.NavigateToDefaultRegion(this.currentUri);
                    completedCallback();
                };

                progressChanged = (s, e) =>
                {
                    progressChangedCallback(e.ProgressPercentage);
                };

                this.ModuleLoader.PriorityOperationCompleted += completed;
                this.ModuleLoader.PriorityOperationProgressChanged += progressChanged;

                this.ModuleLoader.ProcessWithPriority(uri);
            }
        }

        private void NavigateToDefaultRegion(string moduleName)
        {
            if (this.moduleDefaultViewNames.ContainsKey(moduleName))
            {
                var viewName = this.moduleDefaultViewNames[moduleName];
                this.RegionManager.RequestNavigate(RegionNames.ContentRegion, viewName);
            }
            else
            {
                throw new InvalidOperationException("Cannot navigate to unknown module name.");
            }
        }
    }
}
