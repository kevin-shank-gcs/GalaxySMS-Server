using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;

namespace GalaxySMS.PersonCredential
{
    [ModuleExport(typeof(PersonCredentialModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class PersonCredentialModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public PersonCredentialModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}