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
    public class AccessPortalGalaxyCommonEditingData : EntityBase
    {
        public AccessPortalGalaxyCommonEditingData()
        {
            AutomaticForgivePassbackFrequencies = new HashSet<AutomaticForgivePassbackFrequency>();
            PinRequiredModes = new HashSet<PinRequiredMode>();
            MultiFactorModes = new HashSet<AccessPortalMultiFactorMode>();
            //ContactSupervisionTypes = new HashSet<AccessPortalContactSupervisionType>();
            DeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehavior>();
            NoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehavior>();
            LockPushButtonBehaviors = new HashSet<AccessPortalLockPushButtonBehavior>();
            //LiquidCrystalDisplays  = new HashSet<LiquidCrystalDisplay>();
            ElevatorControlTypes = new HashSet<AccessPortalElevatorControlType>();
            //ElevatorRelaysInterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSection>();
            AuxiliaryOutputModes = new HashSet<AccessPortalAuxiliaryOutputMode>();
            //Areas = new HashSet<Area>();
            //TimeSchedules = new HashSet<TimeSchedule>();
            //InputOutputGroups = new HashSet<InputOutputGroup>();
            AlertEventTypes = new HashSet<AccessPortalAlertEventType>();
            AreaTypes = new HashSet<AccessPortalAreaType>();
            TimeScheduleTypes = new HashSet<AccessPortalScheduleType>();
            AccessPortalTypes = new HashSet<AccessPortalType>();
            //OtisElevatorDecs = new HashSet<OtisElevatorDec>();
            Commands = new HashSet<AccessPortalCommand>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AutomaticForgivePassbackFrequency> AutomaticForgivePassbackFrequencies { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PinRequiredMode> PinRequiredModes { get; set; }
        //public ICollection<AccessPortalContactSupervisionType> ContactSupervisionTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalMultiFactorMode> MultiFactorModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalDeferToServerBehavior> DeferToServerBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalNoServerReplyBehavior> NoServerReplyBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalLockPushButtonBehavior> LockPushButtonBehaviors { get; set; }
        //public ICollection<LiquidCrystalDisplay> LiquidCrystalDisplays { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalElevatorControlType> ElevatorControlTypes {get;set; }
        //public ICollection<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAuxiliaryOutputMode> AuxiliaryOutputModes {get;set; }
        //public ICollection<Area> Areas {get;set; }
        //public ICollection<TimeSchedule> TimeSchedules {get;set; }
        //public ICollection<InputOutputGroup> InputOutputGroups {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAlertEventType> AlertEventTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAreaType> AreaTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalScheduleType> TimeScheduleTypes { get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalType> AccessPortalTypes { get; set; }
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalCommand> Commands { get; set; }
    }
}
