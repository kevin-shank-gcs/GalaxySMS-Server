using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.OutputDevice
{
    [ModuleExport(typeof(OutputDeviceModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class OutputDeviceModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public OutputDeviceModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}