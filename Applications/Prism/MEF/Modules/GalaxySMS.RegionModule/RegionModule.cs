using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.Region
{
    [ModuleExport(typeof(RegionModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class RegionModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public RegionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}