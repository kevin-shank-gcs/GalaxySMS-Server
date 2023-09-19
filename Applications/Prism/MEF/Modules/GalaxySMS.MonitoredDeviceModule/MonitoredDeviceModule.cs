using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.MonitoredDevice
{
    [ModuleExport(typeof(MonitoredDeviceModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class MonitoredDeviceModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public MonitoredDeviceModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}