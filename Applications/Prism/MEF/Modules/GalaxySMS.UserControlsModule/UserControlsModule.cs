using Prism.Modularity;
using Prism.Regions;
using System;

namespace GalaxySMS.UserControls
{
    public class UserControlsModule : IModule
    {
        IRegionManager _regionManager;

        public UserControlsModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}