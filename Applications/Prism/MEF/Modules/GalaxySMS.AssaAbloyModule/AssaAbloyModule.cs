using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.AssaAbloy
{
    [ModuleExport(typeof(AssaAbloyModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class AssaAbloyModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public AssaAbloyModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}