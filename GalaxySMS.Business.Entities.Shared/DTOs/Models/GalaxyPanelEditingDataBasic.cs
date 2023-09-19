using System.Collections.Generic;
using System.Runtime.Serialization;

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
    public class GalaxyPanelEditingDataBasic// : EntityBaseSimple
    {
        public GalaxyPanelEditingDataBasic()
        {
            //PanelModels = new HashSet<GalaxyPanelModelBasic>();
            //CpuModels = new HashSet<GalaxyCpuModelBasic>();
            //InterfaceBoardTypes = new HashSet<InterfaceBoardTypeBasic>();
            //InterfaceBoardSectionModes = new HashSet<InterfaceBoardSectionModeBasic>();
            //GalaxyHardwareModuleTypes = new HashSet<GalaxyHardwareModuleTypeBasic>();
            TimeSchedules = new HashSet<TimeScheduleBasic>();
            InputOutputGroups = new HashSet<InputOutputGroupBasic>();
            //AlertEventTypes = new HashSet<GalaxyPanelAlertEventTypeBasic>();
        }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyPanelModelBasic> PanelModels { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyCpuModelBasic> CpuModels { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<InterfaceBoardTypeBasic> InterfaceBoardTypes { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<InterfaceBoardSectionModeBasic> InterfaceBoardSectionModes { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyHardwareModuleTypeBasic> GalaxyHardwareModuleTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleBasic> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroupBasic> InputOutputGroups { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyPanelAlertEventTypeBasic> AlertEventTypes { get; set; }

    }
}
