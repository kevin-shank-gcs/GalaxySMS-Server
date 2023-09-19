using Prism.Modularity;
using Prism.Regions;
using System;
using GalaxySMS.Prism.Infrastructure;
using Microsoft.Practices.Unity;

namespace GalaxySMS.Services
{
    public class ServicesModule : IModule
    {
        private readonly IUnityContainer _container;

        public ServicesModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IClientServices, ClientServices>(new ContainerControlledLifetimeManager());
        }
    }
}