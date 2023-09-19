using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.AccessPortal
{
    [ModuleExport(typeof(AccessPortalModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class AccessPortalModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public AccessPortalModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}