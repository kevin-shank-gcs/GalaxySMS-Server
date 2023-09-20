﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class InputDeviceEditingData : EntityBase
    {
        public InputDeviceEditingData()
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

        public ICollection<AutomaticForgivePassbackFrequency> AutomaticForgivePassbackFrequencies { get; set; }
        public ICollection<PinRequiredMode> PinRequiredModes { get; set; }
        public ICollection<AccessPortalContactSupervisionType> ContactSupervisionTypesTypes { get; set; }
        public ICollection<AccessPortalDeferToServerBehavior> DeferToServerBehaviors { get; set; }
        public ICollection<AccessPortalNoServerReplyBehavior> NoServerReplyBehaviors { get; set; }
        public ICollection<AccessPortalLockPushButtonBehavior> LockPushButtonBehaviors { get; set; }
        public ICollection<LiquidCrystalDisplay> LiquidCrystalDisplays { get; set; }
        public ICollection<AccessPortalElevatorControlType> ElevatorControlTypes {get;set; }
        public ICollection<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections {get;set; }
        public ICollection<AccessPortalAuxiliaryOutputMode> AuxiliaryOutputModes {get;set; }
        public ICollection<Area> Areas {get;set; }
        public ICollection<TimeSchedule> TimeSchedules {get;set; }
        public ICollection<InputOutputGroup> InputOutputGroups {get;set; }
        public ICollection<AccessPortalAlertEventType> AccessPortalAlertEventTypes {get;set; }    }
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }    }
}
