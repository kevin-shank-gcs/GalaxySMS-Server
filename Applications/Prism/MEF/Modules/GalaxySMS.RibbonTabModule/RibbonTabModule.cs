using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.RibbonTabModule
{
    [ModuleExport(typeof(RibbonTabModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class RibbonTabModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public RibbonTabModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}