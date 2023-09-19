using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMSModule_MEF
{
    [ModuleExport(typeof(GalaxySMSModule_MEFModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class GalaxySMSModule_MEFModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public GalaxySMSModule_MEFModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}