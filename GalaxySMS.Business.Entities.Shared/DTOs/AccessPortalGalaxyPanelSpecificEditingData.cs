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
    public class AccessPortalGalaxyPanelSpecificEditingData : EntityBase
    {
        public AccessPortalGalaxyPanelSpecificEditingData()
        {
            ContactSupervisionTypes = new HashSet<AccessPortalContactSupervisionType>();
            LiquidCrystalDisplays  = new HashSet<LiquidCrystalDisplay>();
//            ElevatorControlTypes = new HashSet<AccessPortalElevatorControlType>();
            ElevatorRelaysInterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSection>();
            Areas = new HashSet<Area>();
            TimeSchedules = new HashSet<TimeSchedule>();
            InputOutputGroups = new HashSet<InputOutputGroup>();
            AccessGroups = new HashSet<AccessGroup>();
            //OtisElevatorDecs = new HashSet<OtisElevatorDec>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalContactSupervisionType> ContactSupervisionTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<LiquidCrystalDisplay> LiquidCrystalDisplays { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<AccessPortalElevatorControlType> ElevatorControlTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections {get;set; }
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }    

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Area> Areas { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeSchedule> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroup> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessGroup> AccessGroups { get; set; }
    }
}
