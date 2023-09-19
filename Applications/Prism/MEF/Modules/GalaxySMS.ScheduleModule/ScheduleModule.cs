using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using Prism.Mef.Modularity;

namespace GalaxySMS.Schedule
{
    [ModuleExport(typeof(ScheduleModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ScheduleModule : IModule
    {
        IRegionManager _regionManager;

        [ImportingConstructor]
        public ScheduleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}