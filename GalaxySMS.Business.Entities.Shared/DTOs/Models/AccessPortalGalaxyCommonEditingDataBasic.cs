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
    public class AccessPortalGalaxyCommonEditingDataBasic //: EntityBaseSimple
    {
        public AccessPortalGalaxyCommonEditingDataBasic()
        {
            AutomaticForgivePassbackFrequencies = new HashSet<AutomaticForgivePassbackFrequencyBasic>();
            PinRequiredModes = new HashSet<PinRequiredModeBasic>();
            MultiFactorModes = new HashSet<AccessPortalMultiFactorModeBasic>();
            //ContactSupervisionTypes = new HashSet<AccessPortalContactSupervisionType>();
            DeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehaviorBasic>();
            NoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehaviorBasic>();
            LockPushButtonBehaviors = new HashSet<AccessPortalLockPushButtonBehaviorBasic>();
            //LiquidCrystalDisplays  = new HashSet<LiquidCrystalDisplay>();
            ElevatorControlTypes = new HashSet<AccessPortalElevatorControlType>();
            //ElevatorRelaysInterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSection>();
            AuxiliaryOutputModes = new HashSet<AccessPortalAuxiliaryOutputModeBasic>();
            //Areas = new HashSet<Area>();
            //TimeSchedules = new HashSet<TimeSchedule>();
            //InputOutputGroups = new HashSet<InputOutputGroup>();
            AlertEventTypes = new HashSet<AccessPortalAlertEventTypeBasic>();
            AreaTypes = new HashSet<AccessPortalAreaTypeBasic>();
            TimeScheduleTypes = new HashSet<AccessPortalScheduleTypeBasic>();
            AccessPortalTypes = new HashSet<AccessPortalTypeBasic>();
            Commands = new HashSet<AccessPortalCommandBasic>();
            //DisabledCommandIds = new HashSet<Guid>();
            //OtisElevatorDecs = new HashSet<OtisElevatorDec>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AutomaticForgivePassbackFrequencyBasic> AutomaticForgivePassbackFrequencies { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PinRequiredModeBasic> PinRequiredModes { get; set; }
        //public ICollection<AccessPortalContactSupervisionType> ContactSupervisionTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalMultiFactorModeBasic> MultiFactorModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalDeferToServerBehaviorBasic> DeferToServerBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalNoServerReplyBehaviorBasic> NoServerReplyBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalLockPushButtonBehaviorBasic> LockPushButtonBehaviors { get; set; }
        //public ICollection<LiquidCrystalDisplay> LiquidCrystalDisplays { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalElevatorControlType> ElevatorControlTypes { get; set; }
        //public ICollection<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAuxiliaryOutputModeBasic> AuxiliaryOutputModes {get;set; }
        //public ICollection<Area> Areas {get;set; }
        //public ICollection<TimeSchedule> TimeSchedules {get;set; }
        //public ICollection<InputOutputGroup> InputOutputGroups {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAlertEventTypeBasic> AlertEventTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAreaTypeBasic> AreaTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalScheduleTypeBasic> TimeScheduleTypes { get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalTypeBasic> AccessPortalTypes { get; set; }
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }  

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalCommandBasic> Commands { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<Guid> DisabledCommandIds { get; set; }

    }
}
