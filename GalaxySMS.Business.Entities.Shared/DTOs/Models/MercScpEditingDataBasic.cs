using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

#if NetCoreApi
#else
	[DataContract]
#endif
    public class MercScpEditingDataBasic : EntityBaseSimple
    {
        public MercScpEditingDataBasic()
        {
            //PanelModels = new HashSet<GalaxyPanelModel>();
            //CpuModels = new HashSet<GalaxyCpuModel>();
            //InterfaceBoardTypes = new HashSet<InterfaceBoardType>();
            //InterfaceBoardSectionModes = new HashSet<InterfaceBoardSectionMode>();
            //GalaxyHardwareModuleTypes = new HashSet<GalaxyHardwareModuleType>();
            //TimeSchedules = new HashSet<TimeSchedule>();
            //InputOutputGroups = new HashSet<InputOutputGroup>();
            //AlertEventTypes = new HashSet<GalaxyPanelAlertEventType>();
            //GalaxyPanelModel635Commands = new HashSet<GalaxyPanelCommand>();
            ////GalaxyPanelModel600Commands = new HashSet<GalaxyPanelCommand>();
        }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<GalaxyPanelModel> PanelModels { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<GalaxyCpuModel> CpuModels { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<InterfaceBoardType> InterfaceBoardTypes { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<InterfaceBoardSectionMode> InterfaceBoardSectionModes { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<GalaxyHardwareModuleType> GalaxyHardwareModuleTypes { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<TimeSchedule> TimeSchedules { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<InputOutputGroup> InputOutputGroups { get; set; }

//#if NetCoreApi
//#else
//		[DataMember]
//#endif
//        public ICollection<GalaxyPanelAlertEventType> AlertEventTypes { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<GalaxyPanelCommand> GalaxyPanelModel635Commands { get; set; }

////#if NetCoreApi
////#else
////        [DataMember]
////#endif
////        public ICollection<GalaxyPanelCommand> GalaxyPanelModel600Commands { get; set; }

    }
}
