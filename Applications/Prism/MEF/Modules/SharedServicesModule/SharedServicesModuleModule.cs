using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.SharedServicesModule
{
    [ModuleExport(typeof(SharedServicesModuleModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class SharedServicesModuleModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public SharedServicesModuleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
        }
    }
}