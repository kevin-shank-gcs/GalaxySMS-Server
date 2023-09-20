using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.GalaxyHardware
{
    [ModuleExport(typeof(GalaxyHardwareModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class GalaxyHardwareModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public GalaxyHardwareModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}