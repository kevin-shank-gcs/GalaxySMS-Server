using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using GalaxySMS.UserAuthentication.Views;
using GalaxySMS.Prism.Infrastructure;

namespace GalaxySMS.UserAuthentication
{
    [ModuleExport(typeof(UserAuthenticationModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class UserAuthenticationModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public UserAuthenticationModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(SignInOutView));
        }
    }
}