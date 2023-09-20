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
	public class LiquidCrystalDisplayEditingData : EntityBase
    {
        public LiquidCrystalDisplayEditingData()
        {
            AutomaticForgivePassbackFrequencies = new HashSet<AutomaticForgivePassbackFrequency>();
            PinRequiredModes = new HashSet<PinRequiredMode>();
            ContactSupervisionTypesTypes = new HashSet<AccessPortalContactSupervisionType>();
            DeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehavior>();
            NoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehavior>();
            LockPushButtonBehaviors = new HashSet<AccessPortalLockPushButtonBehavior>();
            LiquidCrystalDisplays  = new HashSet<LiquidCrystalDisplay>();
            ElevatorControlTypes = new HashSet<AccessPortalElevatorControlType>();
            ElevatorRelaysInterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSection>();
            AuxiliaryOutputModes = new HashSet<AccessPortalAuxiliaryOutputMode>();
            Areas = new HashSet<Area>();
            TimeSchedules = new HashSet<TimeSchedule>();
            InputOutputGroups = new HashSet<InputOutputGroup>();
            AccessPortalAlertEventTypes = new HashSet<AccessPortalAlertEventType>();

            //OtisElevatorDecs = new HashSet<OtisElevatorDec>();
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalContactSupervisionType> ContactSupervisionTypesTypes { get; set; }

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

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<LiquidCrystalDisplay> LiquidCrystalDisplays { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalElevatorControlType> ElevatorControlTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAuxiliaryOutputMode> AuxiliaryOutputModes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Area> Areas {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeSchedule> TimeSchedules {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroup> InputOutputGroups {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalAlertEventType> AccessPortalAlertEventTypes {get;set; }    }
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }    }
}
