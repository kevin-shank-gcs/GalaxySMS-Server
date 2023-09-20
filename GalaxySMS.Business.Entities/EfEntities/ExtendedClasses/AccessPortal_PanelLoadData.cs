using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortal_PanelLoadData
    {
        public AccessPortal_PanelLoadData()
        {
            Initialize();
        }

        public AccessPortal_PanelLoadData(AccessPortal_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            AccessGroupData = new HashSet<AccessGroupAccessPortal_PanelLoadData>();
        }

        public void Initialize(AccessPortal_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.AccessPortalUid = e.AccessPortalUid;
            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.PortalName = e.PortalName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.DoorNumber = e.DoorNumber;
            this.AccessPortalTypeDescription = e.AccessPortalTypeDescription;
            this.ReaderTypeName = e.ReaderTypeName;
            this.PanelDataFormatCode = e.PanelDataFormatCode;
            this.DataFormatName = e.DataFormatName;
            this.AccessPortalBoardSectionMode = e.AccessPortalBoardSectionMode;
            this.AccessPortalBoardSectionModeDisplay = e.AccessPortalBoardSectionModeDisplay;
            this.AccessPortalPanelModelTypeCode = e.AccessPortalPanelModelTypeCode;
            this.AccessPortalCpuTypeCode = e.AccessPortalCpuTypeCode;
            this.AccessPortalBoardTypeModel = e.AccessPortalBoardTypeModel;
            this.AccessPortalBoardTypeTypeCode = e.AccessPortalBoardTypeTypeCode;
            this.AccessPortalBoardTypeDisplay = e.AccessPortalBoardTypeDisplay;
            this.UnlockDelay = e.UnlockDelay;
            this.UnlockDuration = e.UnlockDuration;
            this.RecloseDuration = e.RecloseDuration;
            this.AllowPassbackAccess = e.AllowPassbackAccess;
            this.RequireTwoValidCredentials = e.RequireTwoValidCredentials;
            this.UnlockOnREX = e.UnlockOnREX;
            this.SuppressIllegalOpenLog = e.SuppressIllegalOpenLog;
            this.SuppressOpenTooLongLog = e.SuppressOpenTooLongLog;
            this.SuppressClosedLog = e.SuppressClosedLog;
            this.SuppressREXLog = e.SuppressREXLog;
            this.GenerateDoorContactChangeLogs = e.GenerateDoorContactChangeLogs;
            this.LockWhenDoorCloses = e.LockWhenDoorCloses;
            this.EnableDuress = e.EnableDuress;
            this.DoorGroupNotify = e.DoorGroupNotify;
            this.DoorGroupCanDisable = e.DoorGroupCanDisable;
            this.RelayOneOnDuringArmDelay = e.RelayOneOnDuringArmDelay;
            this.RequireValidAccessForAutoUnlock = e.RequireValidAccessForAutoUnlock;
            this.PINSpecifiesRecloseDuration = e.PINSpecifiesRecloseDuration;
            this.ValidAccessRequiresDoorOpen = e.ValidAccessRequiresDoorOpen;
            this.DontDecrementLimitedSwipeExpireCount = e.DontDecrementLimitedSwipeExpireCount;
            this.IgnoreNotInSystem = e.IgnoreNotInSystem;
            this.ReaderSendsHeartbeat = e.ReaderSendsHeartbeat;
            this.PropertiesLastUpdated = e.PropertiesLastUpdated;
            this.AutoForgivePassbackCode = e.AutoForgivePassbackCode;
            this.AutoForgivePassbackDisplay = e.AutoForgivePassbackDisplay;
            this.PinRequiredModeCode = e.PinRequiredModeCode;
            this.PinRequiredModeDisplay = e.PinRequiredModeDisplay;
            this.ContactSupervisionCode = e.ContactSupervisionCode;
            this.ContactSupervisionDisplay = e.ContactSupervisionDisplay;
            this.DeferToServerCode = e.DeferToServerCode;
            this.DeferToServerDisplay = e.DeferToServerDisplay;
            this.NoServerReplyCode = e.NoServerReplyCode;
            this.NoServerReplyDisplay = e.NoServerReplyDisplay;
            this.LockPushButtonCode = e.LockPushButtonCode;
            this.LockPushButtonDisplay = e.LockPushButtonDisplay;
            this.MultiFactorMode = e.MultiFactorMode;
            this.MultiFactorModeDisplay = e.MultiFactorModeDisplay;
            this.LCDBoardNumber = e.LCDBoardNumber;
            this.LCDSectionNumber = e.LCDSectionNumber;
            this.LCDNodeNumber = e.LCDNodeNumber;
            this.ElevatorControlTypeCode = e.ElevatorControlTypeCode;
            this.ElevatorControlTypeDisplay = e.ElevatorControlTypeDisplay;
            this.ElevatorRelayBoardNumber = e.ElevatorRelayBoardNumber;
            this.ElevatorRelaySectionNumber = e.ElevatorRelaySectionNumber;
            this.PassbackIntoAreaNumber = e.PassbackIntoAreaNumber;
            this.PassbackFromAreaNumber = e.PassbackFromAreaNumber;
            this.FreeAccessScheduleNumber = e.FreeAccessScheduleNumber;
            this.FreeAccessScheduleDisplay = e.FreeAccessScheduleDisplay;
            this.CrisisFreeAccessScheduleNumber = e.CrisisFreeAccessScheduleNumber;
            this.CrisisFreeAccessScheduleDisplay = e.CrisisFreeAccessScheduleDisplay;
            this.PinRequiredScheduleNumber = e.PinRequiredScheduleNumber;
            this.PinRequiredScheduleDisplay = e.PinRequiredScheduleDisplay;
            this.DisableForcedOpenScheduleNumber = e.DisableForcedOpenScheduleNumber;
            this.DisableForcedOpenScheduleDisplay = e.DisableForcedOpenScheduleDisplay;
            this.DisableOpenTooLongScheduleNumber = e.DisableOpenTooLongScheduleNumber;
            this.DisableOpenTooLongScheduleDisplay = e.DisableOpenTooLongScheduleDisplay;
            this.AuxiliaryOutputScheduleNumber = e.AuxiliaryOutputScheduleNumber;
            this.AuxiliaryOutputScheduleDisplay = e.AuxiliaryOutputScheduleDisplay;
            this.Relay2ActivationDelay = e.Relay2ActivationDelay;
            this.Relay2ActivationDuration = e.Relay2ActivationDuration;
            this.Relay2TriggerAccessGranted = e.Relay2TriggerAccessGranted;
            this.Relay2TriggerDuress = e.Relay2TriggerDuress;
            this.Relay2TriggerForcedOpen = e.Relay2TriggerForcedOpen;
            this.Relay2TriggerInvalidAttempt = e.Relay2TriggerInvalidAttempt;
            this.Relay2TriggerOpenTooLong = e.Relay2TriggerOpenTooLong;
            this.Relay2TriggerPassbackViolation = e.Relay2TriggerPassbackViolation;
            this.Relay2ModeCode = e.Relay2ModeCode;
            this.Relay2ModeDisplay = e.Relay2ModeDisplay;
            this.Relay2ScheduleNumber = e.Relay2ScheduleNumber;
            this.Relay2ScheduleDisplay = e.Relay2ScheduleDisplay;
            this.ForcedOpenIOGroupNumber = e.ForcedOpenIOGroupNumber;
            this.ForcedOpenIOGroupOffset = e.ForcedOpenIOGroupOffset;
            this.OpenTooLongIOGroupNumber = e.OpenTooLongIOGroupNumber;
            this.OpenTooLongIOGroupOffset = e.OpenTooLongIOGroupOffset;
            this.InvalidAccessAttemptIOGroupNumber = e.InvalidAccessAttemptIOGroupNumber;
            this.InvalidAccessAttemptIOGroupOffset = e.InvalidAccessAttemptIOGroupOffset;
            this.PassbackViolationIOGroupNumber = e.PassbackViolationIOGroupNumber;
            this.PassbackViolationIOGroupOffset = e.PassbackViolationIOGroupOffset;
            this.DuressIOGroupNumber = e.DuressIOGroupNumber;
            this.DuressIOGroupOffset = e.DuressIOGroupOffset;
            this.MissedHeartbeatIOGroupNumber = e.MissedHeartbeatIOGroupNumber;
            this.MissedHeartbeatIOGroupOffset = e.MissedHeartbeatIOGroupOffset;
            this.AccessGrantedIOGroupNumber = e.AccessGrantedIOGroupNumber;
            this.AccessGrantedIOGroupOffset = e.AccessGrantedIOGroupOffset;
            this.DoorGroupIOGroupNumber = e.DoorGroupIOGroupNumber;
            this.DoorGroupIOGroupOffset = e.DoorGroupIOGroupOffset;
            this.LockedByIOGroupNumber = e.LockedByIOGroupNumber;
            this.UnlockedByIOGroupNumber = e.UnlockedByIOGroupNumber;
            this.DisarmIOGroupNumber1 = e.DisarmIOGroupNumber1;
            this.DisarmIOGroupNumber2 = e.DisarmIOGroupNumber2;
            this.DisarmIOGroupNumber3 = e.DisarmIOGroupNumber3;
            this.DisarmIOGroupNumber4 = e.DisarmIOGroupNumber4;

            if (e.AccessGroupData != null)
                this.AccessGroupData = e.AccessGroupData.ToCollection();
        }

        public AccessPortal_PanelLoadData Clone(AccessPortal_PanelLoadData e)
        {
            return new AccessPortal_PanelLoadData(e);
        }

        public bool Equals(AccessPortal_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortal_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalUid != this.AccessPortalUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
