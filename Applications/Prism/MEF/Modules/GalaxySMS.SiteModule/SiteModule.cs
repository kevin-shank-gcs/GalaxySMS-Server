using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.Site
{
    [ModuleExport(typeof(SiteModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class SiteModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public SiteModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}