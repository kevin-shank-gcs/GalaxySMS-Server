using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
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
    public class AccessPortalGalaxyPanelSpecificEditingDataBasic //: EntityBaseSimple
    {
        public AccessPortalGalaxyPanelSpecificEditingDataBasic()
        {
            ContactSupervisionTypes = new HashSet<AccessPortalContactSupervisionTypeBasic>();
//            LiquidCrystalDisplays  = new HashSet<LiquidCrystalDisplayBasic>();
            //ElevatorControlTypes = new HashSet<AccessPortalElevatorControlTypeBasic>();
            ElevatorRelaysInterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSectionMinimal>();
            Areas = new HashSet<AreaBasic>();
            TimeSchedules = new HashSet<TimeScheduleMinimal>();
            InputOutputGroups = new HashSet<InputOutputGroupMinimal>();
            AccessGroups = new HashSet<AccessGroupMinimal>();
            //OtisElevatorDecs = new HashSet<OtisElevatorDec>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalContactSupervisionTypeBasic> ContactSupervisionTypes { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<LiquidCrystalDisplayBasic> LiquidCrystalDisplays { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<AccessPortalElevatorControlTypeBasic> ElevatorControlTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInterfaceBoardSectionMinimal> ElevatorRelaysInterfaceBoardSections {get;set; }
        
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }    

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AreaBasic> Areas { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleMinimal> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroupMinimal> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessGroupMinimal> AccessGroups { get; set; }
    }
}
