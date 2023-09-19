using Prism.Modularity;
using Prism.Regions;
using System;
using GalaxySMS.SignInOut.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace GalaxySMS.SignInOut
{
    public class SignInOutModule : IModule
    {
        private readonly IUnityContainer _container;
        IRegionManager _regionManager;

        public SignInOutModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<SignInOutView>();
        }
    }
}