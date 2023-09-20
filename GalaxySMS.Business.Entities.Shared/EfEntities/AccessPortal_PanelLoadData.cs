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
    public partial class AccessPortal_PanelLoadData : ObjectBase, IHasGalaxyBoardSectionAddress
    {
        #region Public Properties
        public Guid AccessPortalUid { get; set; }
        public Guid ClusterUid { get; set; }
        public Guid GalaxyPanelUid { get; set; }
        public Guid GalaxyInterfaceBoardUid { get; set; }
        public Guid GalaxyInterfaceBoardSectionUid { get; set; }
        public Guid GalaxyHardwareModuleUid { get; set; }
        public Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }
        public string PortalName { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int PanelNumber { get; set; }
        public short BoardNumber { get; set; }
        public short SectionNumber { get; set; }
        public short ModuleNumber { get; set; }
        public short NodeNumber { get; set; }
        public short DoorNumber { get; set; }
        public string AccessPortalTypeDescription { get; set; }
        public string ReaderTypeName { get; set; }
        public int PanelDataFormatCode { get; set; }
        public string DataFormatName { get; set; }
        public short AccessPortalBoardSectionMode { get; set; }
        public string AccessPortalBoardSectionModeDisplay { get; set; }
        public string AccessPortalPanelModelTypeCode { get; set; }
        public string AccessPortalCpuTypeCode { get; set; }
        public string AccessPortalBoardTypeModel { get; set; }
        public short AccessPortalBoardTypeTypeCode { get; set; }
        public string AccessPortalBoardTypeDisplay { get; set; }
        public int UnlockDelay { get; set; }
        public int UnlockDuration { get; set; }
        public int RecloseDuration { get; set; }
        public bool? AllowPassbackAccess { get; set; }
        public bool? RequireTwoValidCredentials { get; set; }
        public bool? UnlockOnREX { get; set; }
        public bool? SuppressIllegalOpenLog { get; set; }
        public bool? SuppressOpenTooLongLog { get; set; }
        public bool? SuppressClosedLog { get; set; }
        public bool? SuppressREXLog { get; set; }
        public bool? GenerateDoorContactChangeLogs { get; set; }
        public bool? LockWhenDoorCloses { get; set; }
        public bool? EnableDuress { get; set; }
        public bool? DoorGroupNotify { get; set; }
        public bool? DoorGroupCanDisable { get; set; }
        public bool? RelayOneOnDuringArmDelay { get; set; }
        public bool? RequireValidAccessForAutoUnlock { get; set; }
        public bool? PINSpecifiesRecloseDuration { get; set; }
        public bool? ValidAccessRequiresDoorOpen { get; set; }
        public bool? DontDecrementLimitedSwipeExpireCount { get; set; }
        public bool? IgnoreNotInSystem { get; set; }
        public bool? ReaderSendsHeartbeat { get; set; }
        public DateTimeOffset PropertiesLastUpdated { get; set; }
        public short AutoForgivePassbackCode { get; set; }
        public string AutoForgivePassbackDisplay { get; set; }
        public short PinRequiredModeCode { get; set; }
        public string PinRequiredModeDisplay { get; set; }
        public short ContactSupervisionCode { get; set; }
        public string ContactSupervisionDisplay { get; set; }
        public short DeferToServerCode { get; set; }
        public string DeferToServerDisplay { get; set; }
        public short NoServerReplyCode { get; set; }
        public string NoServerReplyDisplay { get; set; }
        public short LockPushButtonCode { get; set; }
        public string LockPushButtonDisplay { get; set; }
        public short MultiFactorMode { get; set; }
        public string MultiFactorModeDisplay { get; set; }
        public short LCDBoardNumber { get; set; }
        public short LCDSectionNumber { get; set; }
        public short LCDNodeNumber { get; set; }
        public short ElevatorControlTypeCode { get; set; }
        public string ElevatorControlTypeDisplay { get; set; }
        public short ElevatorRelayBoardNumber { get; set; }
        public short ElevatorRelaySectionNumber { get; set; }
        public int PassbackIntoAreaNumber { get; set; }
        public int PassbackFromAreaNumber { get; set; }
        public int FreeAccessScheduleNumber { get; set; }
        public string FreeAccessScheduleDisplay { get; set; }
        public int CrisisFreeAccessScheduleNumber { get; set; }
        public string CrisisFreeAccessScheduleDisplay { get; set; }
        public int PinRequiredScheduleNumber { get; set; }
        public string PinRequiredScheduleDisplay { get; set; }
        public int DisableForcedOpenScheduleNumber { get; set; }
        public string DisableForcedOpenScheduleDisplay { get; set; }
        public int DisableOpenTooLongScheduleNumber { get; set; }
        public string DisableOpenTooLongScheduleDisplay { get; set; }
        public int AuxiliaryOutputScheduleNumber { get; set; }
        public string AuxiliaryOutputScheduleDisplay { get; set; }
        public int Relay2ActivationDelay { get; set; }
        public int Relay2ActivationDuration { get; set; }
        public bool? Relay2TriggerAccessGranted { get; set; }
        public bool? Relay2TriggerDuress { get; set; }
        public bool? Relay2TriggerForcedOpen { get; set; }
        public bool? Relay2TriggerInvalidAttempt { get; set; }
        public bool? Relay2TriggerOpenTooLong { get; set; }
        public bool? Relay2TriggerPassbackViolation { get; set; }
        public short Relay2ModeCode { get; set; }
        public string Relay2ModeDisplay { get; set; }
        public int Relay2ScheduleNumber { get; set; }
        public string Relay2ScheduleDisplay { get; set; }
        public int ForcedOpenIOGroupNumber { get; set; }
        public short ForcedOpenIOGroupOffset { get; set; }
        public int OpenTooLongIOGroupNumber { get; set; }
        public short OpenTooLongIOGroupOffset { get; set; }
        public int InvalidAccessAttemptIOGroupNumber { get; set; }
        public short InvalidAccessAttemptIOGroupOffset { get; set; }
        public int PassbackViolationIOGroupNumber { get; set; }
        public short PassbackViolationIOGroupOffset { get; set; }
        public int DuressIOGroupNumber { get; set; }
        public short DuressIOGroupOffset { get; set; }
        public int MissedHeartbeatIOGroupNumber { get; set; }
        public short MissedHeartbeatIOGroupOffset { get; set; }
        public int AccessGrantedIOGroupNumber { get; set; }
        public short AccessGrantedIOGroupOffset { get; set; }
        public int DoorGroupIOGroupNumber { get; set; }
        public short DoorGroupIOGroupOffset { get; set; }
        public int LockedByIOGroupNumber { get; set; }
        public int UnlockedByIOGroupNumber { get; set; }
        public int DisarmIOGroupNumber1 { get; set; }
        public int DisarmIOGroupNumber2 { get; set; }
        public int DisarmIOGroupNumber3 { get; set; }
        public int DisarmIOGroupNumber4 { get; set; }
        public DateTimeOffset AccessPortalLastUpdated { get; set; }
        public ICollection<AccessGroupAccessPortal_PanelLoadData> AccessGroupData { get; set; }

        public DateTimeOffset HardwareAddressLastUpdated { get; set; }
        public DateTimeOffset PassbackIntoAreaLastUpdated { get; set; }
        public DateTimeOffset PassbackFromAreaLastUpdated { get; set; }
        public DateTimeOffset FreeAccessSchLastUpdated { get; set; }
        public DateTimeOffset CrisisFreeAccessSchLastUpdated { get; set; }
        public DateTimeOffset PinRequiredSchLastUpdated { get; set; }
        public DateTimeOffset DisableForcedOpenSchLastUpdated { get; set; }
        public DateTimeOffset DisableOpenTooLongSchLastUpdated { get; set; }
        public DateTimeOffset AuxOutputSchLastUpdated { get; set; }
        public DateTimeOffset AuxOutputLastUpdated { get; set; }
        public DateTimeOffset Relay2SchLastUpdated { get; set; }
        public DateTimeOffset ForcedOpenAlertLastUpdated { get; set; }
        public DateTimeOffset OpenTooLongAlertLastUpdated { get; set; }
        public DateTimeOffset InvalidAccessAttemptAlertLastUpdated { get; set; }
        public DateTimeOffset PassbackViolationAlertLastUpdated { get; set; }
        public DateTimeOffset DuressAlertLastUpdated { get; set; }
        public DateTimeOffset MissedHeartbeatAlertLastUpdated { get; set; }
        public DateTimeOffset AccessGrantedAlertLastUpdated { get; set; }
        public DateTimeOffset DoorGroupAlertLastUpdated { get; set; }
        public DateTimeOffset UnlockedByIogLastUpdated { get; set; }
        public DateTimeOffset LockedByIogLastUpdated { get; set; }
        public DateTimeOffset DisarmIog1LastUpdated { get; set; }
        public DateTimeOffset DisarmIog2LastUpdated { get; set; }
        public DateTimeOffset DisarmIog3LastUpdated { get; set; }
        public DateTimeOffset DisarmIog4LastUpdated { get; set; }
        public int CpuNumber { get; set; }
        public Guid CpuUid { get; set; }
        public bool ForcedOpenAlertEventIsActive { get; set; }
        public bool OpenTooLongAlertEventIsActive { get; set; }
        public bool InvalidAccessAttemptAlertEventIsActive { get; set; }
        public bool PassbackViolationAlertEventIsActive { get; set; }
        public bool DuressAlertEventIsActive { get; set; }
        public bool MissedHeartbeatAlertEventIsActive { get; set; }
        public bool AccessGrantedAlertEventIsActive { get; set; }
        public bool DoorGroupAlertEventIsActive { get; set; }
        public bool UnlockedByAlertEventIsActive { get; set; }
        public bool LockedByAlertEventIsActive { get; set; }
        public bool Disarm1AlertEventIsActive { get; set; }
        public bool Disarm2AlertEventIsActive { get; set; }
        public bool Disarm3AlertEventIsActive { get; set; }
        public bool Disarm4AlertEventIsActive { get; set; }

        #endregion

    }
}
