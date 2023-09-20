using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
  
    #region Clone Entity Class
    /// <summary>
    /// Clones the current AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA
    /// </summary>
    /// <returns>A cloned AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA object</returns>
    public AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA entity to clone</param>
    /// <returns>A cloned AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA object</returns>
    public AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA CloneEntity(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA entityToClone)
    {
      AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA newEntity = new AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA();

      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
      newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
      newEntity.PortalName = entityToClone.PortalName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.DoorNumber = entityToClone.DoorNumber;
      newEntity.AccessPortalTypeDescription = entityToClone.AccessPortalTypeDescription;
      newEntity.ReaderTypeName = entityToClone.ReaderTypeName;
      newEntity.PanelDataFormatCode = entityToClone.PanelDataFormatCode;
      newEntity.DataFormatName = entityToClone.DataFormatName;
      newEntity.AccessPortalBoardSectionMode = entityToClone.AccessPortalBoardSectionMode;
      newEntity.AccessPortalBoardSectionModeDisplay = entityToClone.AccessPortalBoardSectionModeDisplay;
      newEntity.AccessPortalPanelModelTypeCode = entityToClone.AccessPortalPanelModelTypeCode;
      newEntity.AccessPortalCpuTypeCode = entityToClone.AccessPortalCpuTypeCode;
      newEntity.AccessPortalBoardTypeModel = entityToClone.AccessPortalBoardTypeModel;
      newEntity.AccessPortalBoardTypeTypeCode = entityToClone.AccessPortalBoardTypeTypeCode;
      newEntity.AccessPortalBoardTypeDisplay = entityToClone.AccessPortalBoardTypeDisplay;
      newEntity.UnlockDelay = entityToClone.UnlockDelay;
      newEntity.UnlockDuration = entityToClone.UnlockDuration;
      newEntity.RecloseDuration = entityToClone.RecloseDuration;
      newEntity.AllowPassbackAccess = entityToClone.AllowPassbackAccess;
      newEntity.RequireTwoValidCredentials = entityToClone.RequireTwoValidCredentials;
      newEntity.UnlockOnREX = entityToClone.UnlockOnREX;
      newEntity.SuppressIllegalOpenLog = entityToClone.SuppressIllegalOpenLog;
      newEntity.SuppressOpenTooLongLog = entityToClone.SuppressOpenTooLongLog;
      newEntity.SuppressClosedLog = entityToClone.SuppressClosedLog;
      newEntity.SuppressREXLog = entityToClone.SuppressREXLog;
      newEntity.GenerateDoorContactChangeLogs = entityToClone.GenerateDoorContactChangeLogs;
      newEntity.LockWhenDoorCloses = entityToClone.LockWhenDoorCloses;
      newEntity.EnableDuress = entityToClone.EnableDuress;
      newEntity.DoorGroupNotify = entityToClone.DoorGroupNotify;
      newEntity.DoorGroupCanDisable = entityToClone.DoorGroupCanDisable;
      newEntity.RelayOneOnDuringArmDelay = entityToClone.RelayOneOnDuringArmDelay;
      newEntity.RequireValidAccessForAutoUnlock = entityToClone.RequireValidAccessForAutoUnlock;
      newEntity.ValidAccessRequiresDoorOpen = entityToClone.ValidAccessRequiresDoorOpen;
      newEntity.DontDecrementLimitedSwipeExpireCount = entityToClone.DontDecrementLimitedSwipeExpireCount;
      newEntity.IgnoreNotInSystem = entityToClone.IgnoreNotInSystem;
      newEntity.ReaderSendsHeartbeat = entityToClone.ReaderSendsHeartbeat;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.PropertiesLastUpdated = entityToClone.PropertiesLastUpdated;
      newEntity.AutoForgivePassbackCode = entityToClone.AutoForgivePassbackCode;
      newEntity.AutoForgivePassbackDisplay = entityToClone.AutoForgivePassbackDisplay;
      newEntity.PinRequiredModeCode = entityToClone.PinRequiredModeCode;
      newEntity.PinRequiredModeDisplay = entityToClone.PinRequiredModeDisplay;
      newEntity.ContactSupervisionCode = entityToClone.ContactSupervisionCode;
      newEntity.ContactSupervisionDisplay = entityToClone.ContactSupervisionDisplay;
      newEntity.DeferToServerCode = entityToClone.DeferToServerCode;
      newEntity.DeferToServerDisplay = entityToClone.DeferToServerDisplay;
      newEntity.NoServerReplyCode = entityToClone.NoServerReplyCode;
      newEntity.NoServerReplyDisplay = entityToClone.NoServerReplyDisplay;
      newEntity.LockPushButtonCode = entityToClone.LockPushButtonCode;
      newEntity.LockPushButtonDisplay = entityToClone.LockPushButtonDisplay;
      newEntity.MultiFactorMode = entityToClone.MultiFactorMode;
      newEntity.MultiFactorModeDisplay = entityToClone.MultiFactorModeDisplay;
      newEntity.ElevatorControlTypeCode = entityToClone.ElevatorControlTypeCode;
      newEntity.ElevatorControlTypeDisplay = entityToClone.ElevatorControlTypeDisplay;
      newEntity.ElevatorRelayBoardNumber = entityToClone.ElevatorRelayBoardNumber;
      newEntity.ElevatorRelaySectionNumber = entityToClone.ElevatorRelaySectionNumber;
      newEntity.PassbackIntoAreaNumber = entityToClone.PassbackIntoAreaNumber;
      newEntity.PassbackFromAreaNumber = entityToClone.PassbackFromAreaNumber;
      newEntity.FreeAccessScheduleNumber = entityToClone.FreeAccessScheduleNumber;
      newEntity.FreeAccessScheduleDisplay = entityToClone.FreeAccessScheduleDisplay;
      newEntity.CrisisFreeAccessScheduleNumber = entityToClone.CrisisFreeAccessScheduleNumber;
      newEntity.CrisisFreeAccessScheduleDisplay = entityToClone.CrisisFreeAccessScheduleDisplay;
      newEntity.PinRequiredScheduleNumber = entityToClone.PinRequiredScheduleNumber;
      newEntity.PinRequiredScheduleDisplay = entityToClone.PinRequiredScheduleDisplay;
      newEntity.DisableForcedOpenScheduleNumber = entityToClone.DisableForcedOpenScheduleNumber;
      newEntity.DisableForcedOpenScheduleDisplay = entityToClone.DisableForcedOpenScheduleDisplay;
      newEntity.DisableOpenTooLongScheduleNumber = entityToClone.DisableOpenTooLongScheduleNumber;
      newEntity.DisableOpenTooLongScheduleDisplay = entityToClone.DisableOpenTooLongScheduleDisplay;
      newEntity.AuxiliaryOutputScheduleNumber = entityToClone.AuxiliaryOutputScheduleNumber;
      newEntity.AuxiliaryOutputScheduleDisplay = entityToClone.AuxiliaryOutputScheduleDisplay;
      newEntity.Relay2ActivationDelay = entityToClone.Relay2ActivationDelay;
      newEntity.Relay2ActivationDuration = entityToClone.Relay2ActivationDuration;
      newEntity.Relay2TriggerAccessGranted = entityToClone.Relay2TriggerAccessGranted;
      newEntity.Relay2TriggerDuress = entityToClone.Relay2TriggerDuress;
      newEntity.Relay2TriggerForcedOpen = entityToClone.Relay2TriggerForcedOpen;
      newEntity.Relay2TriggerInvalidAttempt = entityToClone.Relay2TriggerInvalidAttempt;
      newEntity.Relay2TriggerOpenTooLong = entityToClone.Relay2TriggerOpenTooLong;
      newEntity.Relay2TriggerPassbackViolation = entityToClone.Relay2TriggerPassbackViolation;
      newEntity.Relay2ModeCode = entityToClone.Relay2ModeCode;
      newEntity.Relay2ModeDisplay = entityToClone.Relay2ModeDisplay;
      newEntity.Relay2ScheduleNumber = entityToClone.Relay2ScheduleNumber;
      newEntity.Relay2ScheduleDisplay = entityToClone.Relay2ScheduleDisplay;
      newEntity.ForcedOpenIOGroupNumber = entityToClone.ForcedOpenIOGroupNumber;
      newEntity.ForcedOpenIOGroupOffset = entityToClone.ForcedOpenIOGroupOffset;
      newEntity.OpenTooLongIOGroupNumber = entityToClone.OpenTooLongIOGroupNumber;
      newEntity.OpenTooLongIOGroupOffset = entityToClone.OpenTooLongIOGroupOffset;
      newEntity.InvalidAccessAttemptIOGroupNumber = entityToClone.InvalidAccessAttemptIOGroupNumber;
      newEntity.InvalidAccessAttemptIOGroupOffset = entityToClone.InvalidAccessAttemptIOGroupOffset;
      newEntity.PassbackViolationIOGroupNumber = entityToClone.PassbackViolationIOGroupNumber;
      newEntity.PassbackViolationIOGroupOffset = entityToClone.PassbackViolationIOGroupOffset;
      newEntity.DuressIOGroupNumber = entityToClone.DuressIOGroupNumber;
      newEntity.DuressIOGroupOffset = entityToClone.DuressIOGroupOffset;
      newEntity.MissedHeartbeatIOGroupNumber = entityToClone.MissedHeartbeatIOGroupNumber;
      newEntity.MissedHeartbeatIOGroupOffset = entityToClone.MissedHeartbeatIOGroupOffset;
      newEntity.AccessGrantedIOGroupNumber = entityToClone.AccessGrantedIOGroupNumber;
      newEntity.AccessGrantedIOGroupOffset = entityToClone.AccessGrantedIOGroupOffset;
      newEntity.DoorGroupIOGroupNumber = entityToClone.DoorGroupIOGroupNumber;
      newEntity.DoorGroupIOGroupOffset = entityToClone.DoorGroupIOGroupOffset;
      newEntity.LockedByIOGroupNumber = entityToClone.LockedByIOGroupNumber;
      newEntity.UnlockedByIOGroupNumber = entityToClone.UnlockedByIOGroupNumber;
      newEntity.DisarmIOGroupNumber1 = entityToClone.DisarmIOGroupNumber1;
      newEntity.DisarmIOGroupNumber2 = entityToClone.DisarmIOGroupNumber2;
      newEntity.DisarmIOGroupNumber3 = entityToClone.DisarmIOGroupNumber3;
      newEntity.DisarmIOGroupNumber4 = entityToClone.DisarmIOGroupNumber4;
      newEntity.AccessPortalLastUpdated = entityToClone.AccessPortalLastUpdated;
      newEntity.HardwareAddressLastUpdated = entityToClone.HardwareAddressLastUpdated;
      newEntity.PassbackIntoAreaLastUpdated = entityToClone.PassbackIntoAreaLastUpdated;
      newEntity.PassbackFromAreaLastUpdated = entityToClone.PassbackFromAreaLastUpdated;
      newEntity.FreeAccessSchLastUpdated = entityToClone.FreeAccessSchLastUpdated;
      newEntity.CrisisFreeAccessSchLastUpdated = entityToClone.CrisisFreeAccessSchLastUpdated;
      newEntity.PinRequiredSchLastUpdated = entityToClone.PinRequiredSchLastUpdated;
      newEntity.DisableForcedOpenSchLastUpdated = entityToClone.DisableForcedOpenSchLastUpdated;
      newEntity.DisableOpenTooLongSchLastUpdated = entityToClone.DisableOpenTooLongSchLastUpdated;
      newEntity.AuxOutputSchLastUpdated = entityToClone.AuxOutputSchLastUpdated;
      newEntity.AuxOutputLastUpdated = entityToClone.AuxOutputLastUpdated;
      newEntity.Relay2SchLastUpdated = entityToClone.Relay2SchLastUpdated;
      newEntity.ForcedOpenAlertLastUpdated = entityToClone.ForcedOpenAlertLastUpdated;
      newEntity.OpenTooLongAlertLastUpdated = entityToClone.OpenTooLongAlertLastUpdated;
      newEntity.InvalidAccessAttemptAlertLastUpdated = entityToClone.InvalidAccessAttemptAlertLastUpdated;
      newEntity.PassbackViolationAlertLastUpdated = entityToClone.PassbackViolationAlertLastUpdated;
      newEntity.DuressAlertLastUpdated = entityToClone.DuressAlertLastUpdated;
      newEntity.MissedHeartbeatAlertLastUpdated = entityToClone.MissedHeartbeatAlertLastUpdated;
      newEntity.AccessGrantedAlertLastUpdated = entityToClone.AccessGrantedAlertLastUpdated;
      newEntity.DoorGroupAlertLastUpdated = entityToClone.DoorGroupAlertLastUpdated;
      newEntity.UnlockedByIogLastUpdated = entityToClone.UnlockedByIogLastUpdated;
      newEntity.LockedByIogLastUpdated = entityToClone.LockedByIogLastUpdated;
      newEntity.DisarmIog1LastUpdated = entityToClone.DisarmIog1LastUpdated;
      newEntity.DisarmIog2LastUpdated = entityToClone.DisarmIog2LastUpdated;
      newEntity.DisarmIog3LastUpdated = entityToClone.DisarmIog3LastUpdated;
      newEntity.DisarmIog4LastUpdated = entityToClone.DisarmIog4LastUpdated;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.IsConnected = entityToClone.IsConnected;
      newEntity.ForcedOpenAlertEventIsActive = entityToClone.ForcedOpenAlertEventIsActive;
      newEntity.OpenTooLongAlertEventIsActive = entityToClone.OpenTooLongAlertEventIsActive;
      newEntity.InvalidAccessAttemptAlertEventIsActive = entityToClone.InvalidAccessAttemptAlertEventIsActive;
      newEntity.PassbackViolationAlertEventIsActive = entityToClone.PassbackViolationAlertEventIsActive;
      newEntity.DuressAlertEventIsActive = entityToClone.DuressAlertEventIsActive;
      newEntity.MissedHeartbeatAlertEventIsActive = entityToClone.MissedHeartbeatAlertEventIsActive;
      newEntity.AccessGrantedAlertEventIsActive = entityToClone.AccessGrantedAlertEventIsActive;
      newEntity.DoorGroupAlertEventIsActive = entityToClone.DoorGroupAlertEventIsActive;
      newEntity.UnlockedByAlertEventIsActive = entityToClone.UnlockedByAlertEventIsActive;
      newEntity.LockedByAlertEventIsActive = entityToClone.LockedByAlertEventIsActive;
      newEntity.Disarm1AlertEventIsActive = entityToClone.Disarm1AlertEventIsActive;
      newEntity.Disarm2AlertEventIsActive = entityToClone.Disarm2AlertEventIsActive;
      newEntity.Disarm3AlertEventIsActive = entityToClone.Disarm3AlertEventIsActive;
      newEntity.Disarm4AlertEventIsActive = entityToClone.Disarm4AlertEventIsActive;

      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.GalaxyHardwareModuleUid, GetResourceMessage("GCS_AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA_GalaxyHardwareModuleUid_Header", "Galaxy Hardware Module Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA_GalaxyHardwareModuleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.GalaxyHardwareModuleUid).Value = Entity.GalaxyHardwareModuleUid;
      this.Properties.GetByName(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.GalaxyHardwareModuleUid).IsNull == false)
        Entity.GalaxyHardwareModuleUid = this.Properties.GetByName(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.GalaxyHardwareModuleUid).GetAsGuid();
      if(this.Properties.GetByName(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns 'GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns 'PortalName'
    /// </summary>
    public static string PortalName = "PortalName";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'BoardNumber'
    /// </summary>
    public static string BoardNumber = "BoardNumber";
    /// <summary>
    /// Returns 'SectionNumber'
    /// </summary>
    public static string SectionNumber = "SectionNumber";
    /// <summary>
    /// Returns 'ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "ModuleNumber";
    /// <summary>
    /// Returns 'NodeNumber'
    /// </summary>
    public static string NodeNumber = "NodeNumber";
    /// <summary>
    /// Returns 'DoorNumber'
    /// </summary>
    public static string DoorNumber = "DoorNumber";
    /// <summary>
    /// Returns 'AccessPortalTypeDescription'
    /// </summary>
    public static string AccessPortalTypeDescription = "AccessPortalTypeDescription";
    /// <summary>
    /// Returns 'ReaderTypeName'
    /// </summary>
    public static string ReaderTypeName = "ReaderTypeName";
    /// <summary>
    /// Returns 'PanelDataFormatCode'
    /// </summary>
    public static string PanelDataFormatCode = "PanelDataFormatCode";
    /// <summary>
    /// Returns 'DataFormatName'
    /// </summary>
    public static string DataFormatName = "DataFormatName";
    /// <summary>
    /// Returns 'AccessPortalBoardSectionMode'
    /// </summary>
    public static string AccessPortalBoardSectionMode = "AccessPortalBoardSectionMode";
    /// <summary>
    /// Returns 'AccessPortalBoardSectionModeDisplay'
    /// </summary>
    public static string AccessPortalBoardSectionModeDisplay = "AccessPortalBoardSectionModeDisplay";
    /// <summary>
    /// Returns 'AccessPortalPanelModelTypeCode'
    /// </summary>
    public static string AccessPortalPanelModelTypeCode = "AccessPortalPanelModelTypeCode";
    /// <summary>
    /// Returns 'AccessPortalCpuTypeCode'
    /// </summary>
    public static string AccessPortalCpuTypeCode = "AccessPortalCpuTypeCode";
    /// <summary>
    /// Returns 'AccessPortalBoardTypeModel'
    /// </summary>
    public static string AccessPortalBoardTypeModel = "AccessPortalBoardTypeModel";
    /// <summary>
    /// Returns 'AccessPortalBoardTypeTypeCode'
    /// </summary>
    public static string AccessPortalBoardTypeTypeCode = "AccessPortalBoardTypeTypeCode";
    /// <summary>
    /// Returns 'AccessPortalBoardTypeDisplay'
    /// </summary>
    public static string AccessPortalBoardTypeDisplay = "AccessPortalBoardTypeDisplay";
    /// <summary>
    /// Returns 'UnlockDelay'
    /// </summary>
    public static string UnlockDelay = "UnlockDelay";
    /// <summary>
    /// Returns 'UnlockDuration'
    /// </summary>
    public static string UnlockDuration = "UnlockDuration";
    /// <summary>
    /// Returns 'RecloseDuration'
    /// </summary>
    public static string RecloseDuration = "RecloseDuration";
    /// <summary>
    /// Returns 'AllowPassbackAccess'
    /// </summary>
    public static string AllowPassbackAccess = "AllowPassbackAccess";
    /// <summary>
    /// Returns 'RequireTwoValidCredentials'
    /// </summary>
    public static string RequireTwoValidCredentials = "RequireTwoValidCredentials";
    /// <summary>
    /// Returns 'UnlockOnREX'
    /// </summary>
    public static string UnlockOnREX = "UnlockOnREX";
    /// <summary>
    /// Returns 'SuppressIllegalOpenLog'
    /// </summary>
    public static string SuppressIllegalOpenLog = "SuppressIllegalOpenLog";
    /// <summary>
    /// Returns 'SuppressOpenTooLongLog'
    /// </summary>
    public static string SuppressOpenTooLongLog = "SuppressOpenTooLongLog";
    /// <summary>
    /// Returns 'SuppressClosedLog'
    /// </summary>
    public static string SuppressClosedLog = "SuppressClosedLog";
    /// <summary>
    /// Returns 'SuppressREXLog'
    /// </summary>
    public static string SuppressREXLog = "SuppressREXLog";
    /// <summary>
    /// Returns 'GenerateDoorContactChangeLogs'
    /// </summary>
    public static string GenerateDoorContactChangeLogs = "GenerateDoorContactChangeLogs";
    /// <summary>
    /// Returns 'LockWhenDoorCloses'
    /// </summary>
    public static string LockWhenDoorCloses = "LockWhenDoorCloses";
    /// <summary>
    /// Returns 'EnableDuress'
    /// </summary>
    public static string EnableDuress = "EnableDuress";
    /// <summary>
    /// Returns 'DoorGroupNotify'
    /// </summary>
    public static string DoorGroupNotify = "DoorGroupNotify";
    /// <summary>
    /// Returns 'DoorGroupCanDisable'
    /// </summary>
    public static string DoorGroupCanDisable = "DoorGroupCanDisable";
    /// <summary>
    /// Returns 'RelayOneOnDuringArmDelay'
    /// </summary>
    public static string RelayOneOnDuringArmDelay = "RelayOneOnDuringArmDelay";
    /// <summary>
    /// Returns 'RequireValidAccessForAutoUnlock'
    /// </summary>
    public static string RequireValidAccessForAutoUnlock = "RequireValidAccessForAutoUnlock";
    /// <summary>
    /// Returns 'ValidAccessRequiresDoorOpen'
    /// </summary>
    public static string ValidAccessRequiresDoorOpen = "ValidAccessRequiresDoorOpen";
    /// <summary>
    /// Returns 'DontDecrementLimitedSwipeExpireCount'
    /// </summary>
    public static string DontDecrementLimitedSwipeExpireCount = "DontDecrementLimitedSwipeExpireCount";
    /// <summary>
    /// Returns 'IgnoreNotInSystem'
    /// </summary>
    public static string IgnoreNotInSystem = "IgnoreNotInSystem";
    /// <summary>
    /// Returns 'ReaderSendsHeartbeat'
    /// </summary>
    public static string ReaderSendsHeartbeat = "ReaderSendsHeartbeat";
    /// <summary>
    /// Returns 'IsEnabled'
    /// </summary>
    public static string IsEnabled = "IsEnabled";
    /// <summary>
    /// Returns 'PropertiesLastUpdated'
    /// </summary>
    public static string PropertiesLastUpdated = "PropertiesLastUpdated";
    /// <summary>
    /// Returns 'AutoForgivePassbackCode'
    /// </summary>
    public static string AutoForgivePassbackCode = "AutoForgivePassbackCode";
    /// <summary>
    /// Returns 'AutoForgivePassbackDisplay'
    /// </summary>
    public static string AutoForgivePassbackDisplay = "AutoForgivePassbackDisplay";
    /// <summary>
    /// Returns 'PinRequiredModeCode'
    /// </summary>
    public static string PinRequiredModeCode = "PinRequiredModeCode";
    /// <summary>
    /// Returns 'PinRequiredModeDisplay'
    /// </summary>
    public static string PinRequiredModeDisplay = "PinRequiredModeDisplay";
    /// <summary>
    /// Returns 'ContactSupervisionCode'
    /// </summary>
    public static string ContactSupervisionCode = "ContactSupervisionCode";
    /// <summary>
    /// Returns 'ContactSupervisionDisplay'
    /// </summary>
    public static string ContactSupervisionDisplay = "ContactSupervisionDisplay";
    /// <summary>
    /// Returns 'DeferToServerCode'
    /// </summary>
    public static string DeferToServerCode = "DeferToServerCode";
    /// <summary>
    /// Returns 'DeferToServerDisplay'
    /// </summary>
    public static string DeferToServerDisplay = "DeferToServerDisplay";
    /// <summary>
    /// Returns 'NoServerReplyCode'
    /// </summary>
    public static string NoServerReplyCode = "NoServerReplyCode";
    /// <summary>
    /// Returns 'NoServerReplyDisplay'
    /// </summary>
    public static string NoServerReplyDisplay = "NoServerReplyDisplay";
    /// <summary>
    /// Returns 'LockPushButtonCode'
    /// </summary>
    public static string LockPushButtonCode = "LockPushButtonCode";
    /// <summary>
    /// Returns 'LockPushButtonDisplay'
    /// </summary>
    public static string LockPushButtonDisplay = "LockPushButtonDisplay";
    /// <summary>
    /// Returns 'MultiFactorMode'
    /// </summary>
    public static string MultiFactorMode = "MultiFactorMode";
    /// <summary>
    /// Returns 'MultiFactorModeDisplay'
    /// </summary>
    public static string MultiFactorModeDisplay = "MultiFactorModeDisplay";
    /// <summary>
    /// Returns 'ElevatorControlTypeCode'
    /// </summary>
    public static string ElevatorControlTypeCode = "ElevatorControlTypeCode";
    /// <summary>
    /// Returns 'ElevatorControlTypeDisplay'
    /// </summary>
    public static string ElevatorControlTypeDisplay = "ElevatorControlTypeDisplay";
    /// <summary>
    /// Returns 'ElevatorRelayBoardNumber'
    /// </summary>
    public static string ElevatorRelayBoardNumber = "ElevatorRelayBoardNumber";
    /// <summary>
    /// Returns 'ElevatorRelaySectionNumber'
    /// </summary>
    public static string ElevatorRelaySectionNumber = "ElevatorRelaySectionNumber";
    /// <summary>
    /// Returns 'PassbackIntoAreaNumber'
    /// </summary>
    public static string PassbackIntoAreaNumber = "PassbackIntoAreaNumber";
    /// <summary>
    /// Returns 'PassbackFromAreaNumber'
    /// </summary>
    public static string PassbackFromAreaNumber = "PassbackFromAreaNumber";
    /// <summary>
    /// Returns 'FreeAccessScheduleNumber'
    /// </summary>
    public static string FreeAccessScheduleNumber = "FreeAccessScheduleNumber";
    /// <summary>
    /// Returns 'FreeAccessScheduleDisplay'
    /// </summary>
    public static string FreeAccessScheduleDisplay = "FreeAccessScheduleDisplay";
    /// <summary>
    /// Returns 'CrisisFreeAccessScheduleNumber'
    /// </summary>
    public static string CrisisFreeAccessScheduleNumber = "CrisisFreeAccessScheduleNumber";
    /// <summary>
    /// Returns 'CrisisFreeAccessScheduleDisplay'
    /// </summary>
    public static string CrisisFreeAccessScheduleDisplay = "CrisisFreeAccessScheduleDisplay";
    /// <summary>
    /// Returns 'PinRequiredScheduleNumber'
    /// </summary>
    public static string PinRequiredScheduleNumber = "PinRequiredScheduleNumber";
    /// <summary>
    /// Returns 'PinRequiredScheduleDisplay'
    /// </summary>
    public static string PinRequiredScheduleDisplay = "PinRequiredScheduleDisplay";
    /// <summary>
    /// Returns 'DisableForcedOpenScheduleNumber'
    /// </summary>
    public static string DisableForcedOpenScheduleNumber = "DisableForcedOpenScheduleNumber";
    /// <summary>
    /// Returns 'DisableForcedOpenScheduleDisplay'
    /// </summary>
    public static string DisableForcedOpenScheduleDisplay = "DisableForcedOpenScheduleDisplay";
    /// <summary>
    /// Returns 'DisableOpenTooLongScheduleNumber'
    /// </summary>
    public static string DisableOpenTooLongScheduleNumber = "DisableOpenTooLongScheduleNumber";
    /// <summary>
    /// Returns 'DisableOpenTooLongScheduleDisplay'
    /// </summary>
    public static string DisableOpenTooLongScheduleDisplay = "DisableOpenTooLongScheduleDisplay";
    /// <summary>
    /// Returns 'AuxiliaryOutputScheduleNumber'
    /// </summary>
    public static string AuxiliaryOutputScheduleNumber = "AuxiliaryOutputScheduleNumber";
    /// <summary>
    /// Returns 'AuxiliaryOutputScheduleDisplay'
    /// </summary>
    public static string AuxiliaryOutputScheduleDisplay = "AuxiliaryOutputScheduleDisplay";
    /// <summary>
    /// Returns 'Relay2ActivationDelay'
    /// </summary>
    public static string Relay2ActivationDelay = "Relay2ActivationDelay";
    /// <summary>
    /// Returns 'Relay2ActivationDuration'
    /// </summary>
    public static string Relay2ActivationDuration = "Relay2ActivationDuration";
    /// <summary>
    /// Returns 'Relay2TriggerAccessGranted'
    /// </summary>
    public static string Relay2TriggerAccessGranted = "Relay2TriggerAccessGranted";
    /// <summary>
    /// Returns 'Relay2TriggerDuress'
    /// </summary>
    public static string Relay2TriggerDuress = "Relay2TriggerDuress";
    /// <summary>
    /// Returns 'Relay2TriggerForcedOpen'
    /// </summary>
    public static string Relay2TriggerForcedOpen = "Relay2TriggerForcedOpen";
    /// <summary>
    /// Returns 'Relay2TriggerInvalidAttempt'
    /// </summary>
    public static string Relay2TriggerInvalidAttempt = "Relay2TriggerInvalidAttempt";
    /// <summary>
    /// Returns 'Relay2TriggerOpenTooLong'
    /// </summary>
    public static string Relay2TriggerOpenTooLong = "Relay2TriggerOpenTooLong";
    /// <summary>
    /// Returns 'Relay2TriggerPassbackViolation'
    /// </summary>
    public static string Relay2TriggerPassbackViolation = "Relay2TriggerPassbackViolation";
    /// <summary>
    /// Returns 'Relay2ModeCode'
    /// </summary>
    public static string Relay2ModeCode = "Relay2ModeCode";
    /// <summary>
    /// Returns 'Relay2ModeDisplay'
    /// </summary>
    public static string Relay2ModeDisplay = "Relay2ModeDisplay";
    /// <summary>
    /// Returns 'Relay2ScheduleNumber'
    /// </summary>
    public static string Relay2ScheduleNumber = "Relay2ScheduleNumber";
    /// <summary>
    /// Returns 'Relay2ScheduleDisplay'
    /// </summary>
    public static string Relay2ScheduleDisplay = "Relay2ScheduleDisplay";
    /// <summary>
    /// Returns 'ForcedOpenIOGroupNumber'
    /// </summary>
    public static string ForcedOpenIOGroupNumber = "ForcedOpenIOGroupNumber";
    /// <summary>
    /// Returns 'ForcedOpenIOGroupOffset'
    /// </summary>
    public static string ForcedOpenIOGroupOffset = "ForcedOpenIOGroupOffset";
    /// <summary>
    /// Returns 'OpenTooLongIOGroupNumber'
    /// </summary>
    public static string OpenTooLongIOGroupNumber = "OpenTooLongIOGroupNumber";
    /// <summary>
    /// Returns 'OpenTooLongIOGroupOffset'
    /// </summary>
    public static string OpenTooLongIOGroupOffset = "OpenTooLongIOGroupOffset";
    /// <summary>
    /// Returns 'InvalidAccessAttemptIOGroupNumber'
    /// </summary>
    public static string InvalidAccessAttemptIOGroupNumber = "InvalidAccessAttemptIOGroupNumber";
    /// <summary>
    /// Returns 'InvalidAccessAttemptIOGroupOffset'
    /// </summary>
    public static string InvalidAccessAttemptIOGroupOffset = "InvalidAccessAttemptIOGroupOffset";
    /// <summary>
    /// Returns 'PassbackViolationIOGroupNumber'
    /// </summary>
    public static string PassbackViolationIOGroupNumber = "PassbackViolationIOGroupNumber";
    /// <summary>
    /// Returns 'PassbackViolationIOGroupOffset'
    /// </summary>
    public static string PassbackViolationIOGroupOffset = "PassbackViolationIOGroupOffset";
    /// <summary>
    /// Returns 'DuressIOGroupNumber'
    /// </summary>
    public static string DuressIOGroupNumber = "DuressIOGroupNumber";
    /// <summary>
    /// Returns 'DuressIOGroupOffset'
    /// </summary>
    public static string DuressIOGroupOffset = "DuressIOGroupOffset";
    /// <summary>
    /// Returns 'MissedHeartbeatIOGroupNumber'
    /// </summary>
    public static string MissedHeartbeatIOGroupNumber = "MissedHeartbeatIOGroupNumber";
    /// <summary>
    /// Returns 'MissedHeartbeatIOGroupOffset'
    /// </summary>
    public static string MissedHeartbeatIOGroupOffset = "MissedHeartbeatIOGroupOffset";
    /// <summary>
    /// Returns 'AccessGrantedIOGroupNumber'
    /// </summary>
    public static string AccessGrantedIOGroupNumber = "AccessGrantedIOGroupNumber";
    /// <summary>
    /// Returns 'AccessGrantedIOGroupOffset'
    /// </summary>
    public static string AccessGrantedIOGroupOffset = "AccessGrantedIOGroupOffset";
    /// <summary>
    /// Returns 'DoorGroupIOGroupNumber'
    /// </summary>
    public static string DoorGroupIOGroupNumber = "DoorGroupIOGroupNumber";
    /// <summary>
    /// Returns 'DoorGroupIOGroupOffset'
    /// </summary>
    public static string DoorGroupIOGroupOffset = "DoorGroupIOGroupOffset";
    /// <summary>
    /// Returns 'LockedByIOGroupNumber'
    /// </summary>
    public static string LockedByIOGroupNumber = "LockedByIOGroupNumber";
    /// <summary>
    /// Returns 'UnlockedByIOGroupNumber'
    /// </summary>
    public static string UnlockedByIOGroupNumber = "UnlockedByIOGroupNumber";
    /// <summary>
    /// Returns 'DisarmIOGroupNumber1'
    /// </summary>
    public static string DisarmIOGroupNumber1 = "DisarmIOGroupNumber1";
    /// <summary>
    /// Returns 'DisarmIOGroupNumber2'
    /// </summary>
    public static string DisarmIOGroupNumber2 = "DisarmIOGroupNumber2";
    /// <summary>
    /// Returns 'DisarmIOGroupNumber3'
    /// </summary>
    public static string DisarmIOGroupNumber3 = "DisarmIOGroupNumber3";
    /// <summary>
    /// Returns 'DisarmIOGroupNumber4'
    /// </summary>
    public static string DisarmIOGroupNumber4 = "DisarmIOGroupNumber4";
    /// <summary>
    /// Returns 'AccessPortalLastUpdated'
    /// </summary>
    public static string AccessPortalLastUpdated = "AccessPortalLastUpdated";
    /// <summary>
    /// Returns 'HardwareAddressLastUpdated'
    /// </summary>
    public static string HardwareAddressLastUpdated = "HardwareAddressLastUpdated";
    /// <summary>
    /// Returns 'PassbackIntoAreaLastUpdated'
    /// </summary>
    public static string PassbackIntoAreaLastUpdated = "PassbackIntoAreaLastUpdated";
    /// <summary>
    /// Returns 'PassbackFromAreaLastUpdated'
    /// </summary>
    public static string PassbackFromAreaLastUpdated = "PassbackFromAreaLastUpdated";
    /// <summary>
    /// Returns 'FreeAccessSchLastUpdated'
    /// </summary>
    public static string FreeAccessSchLastUpdated = "FreeAccessSchLastUpdated";
    /// <summary>
    /// Returns 'CrisisFreeAccessSchLastUpdated'
    /// </summary>
    public static string CrisisFreeAccessSchLastUpdated = "CrisisFreeAccessSchLastUpdated";
    /// <summary>
    /// Returns 'PinRequiredSchLastUpdated'
    /// </summary>
    public static string PinRequiredSchLastUpdated = "PinRequiredSchLastUpdated";
    /// <summary>
    /// Returns 'DisableForcedOpenSchLastUpdated'
    /// </summary>
    public static string DisableForcedOpenSchLastUpdated = "DisableForcedOpenSchLastUpdated";
    /// <summary>
    /// Returns 'DisableOpenTooLongSchLastUpdated'
    /// </summary>
    public static string DisableOpenTooLongSchLastUpdated = "DisableOpenTooLongSchLastUpdated";
    /// <summary>
    /// Returns 'AuxOutputSchLastUpdated'
    /// </summary>
    public static string AuxOutputSchLastUpdated = "AuxOutputSchLastUpdated";
    /// <summary>
    /// Returns 'AuxOutputLastUpdated'
    /// </summary>
    public static string AuxOutputLastUpdated = "AuxOutputLastUpdated";
    /// <summary>
    /// Returns 'Relay2SchLastUpdated'
    /// </summary>
    public static string Relay2SchLastUpdated = "Relay2SchLastUpdated";
    /// <summary>
    /// Returns 'ForcedOpenAlertLastUpdated'
    /// </summary>
    public static string ForcedOpenAlertLastUpdated = "ForcedOpenAlertLastUpdated";
    /// <summary>
    /// Returns 'OpenTooLongAlertLastUpdated'
    /// </summary>
    public static string OpenTooLongAlertLastUpdated = "OpenTooLongAlertLastUpdated";
    /// <summary>
    /// Returns 'InvalidAccessAttemptAlertLastUpdated'
    /// </summary>
    public static string InvalidAccessAttemptAlertLastUpdated = "InvalidAccessAttemptAlertLastUpdated";
    /// <summary>
    /// Returns 'PassbackViolationAlertLastUpdated'
    /// </summary>
    public static string PassbackViolationAlertLastUpdated = "PassbackViolationAlertLastUpdated";
    /// <summary>
    /// Returns 'DuressAlertLastUpdated'
    /// </summary>
    public static string DuressAlertLastUpdated = "DuressAlertLastUpdated";
    /// <summary>
    /// Returns 'MissedHeartbeatAlertLastUpdated'
    /// </summary>
    public static string MissedHeartbeatAlertLastUpdated = "MissedHeartbeatAlertLastUpdated";
    /// <summary>
    /// Returns 'AccessGrantedAlertLastUpdated'
    /// </summary>
    public static string AccessGrantedAlertLastUpdated = "AccessGrantedAlertLastUpdated";
    /// <summary>
    /// Returns 'DoorGroupAlertLastUpdated'
    /// </summary>
    public static string DoorGroupAlertLastUpdated = "DoorGroupAlertLastUpdated";
    /// <summary>
    /// Returns 'UnlockedByIogLastUpdated'
    /// </summary>
    public static string UnlockedByIogLastUpdated = "UnlockedByIogLastUpdated";
    /// <summary>
    /// Returns 'LockedByIogLastUpdated'
    /// </summary>
    public static string LockedByIogLastUpdated = "LockedByIogLastUpdated";
    /// <summary>
    /// Returns 'DisarmIog1LastUpdated'
    /// </summary>
    public static string DisarmIog1LastUpdated = "DisarmIog1LastUpdated";
    /// <summary>
    /// Returns 'DisarmIog2LastUpdated'
    /// </summary>
    public static string DisarmIog2LastUpdated = "DisarmIog2LastUpdated";
    /// <summary>
    /// Returns 'DisarmIog3LastUpdated'
    /// </summary>
    public static string DisarmIog3LastUpdated = "DisarmIog3LastUpdated";
    /// <summary>
    /// Returns 'DisarmIog4LastUpdated'
    /// </summary>
    public static string DisarmIog4LastUpdated = "DisarmIog4LastUpdated";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    /// <summary>
    /// Returns 'ForcedOpenAlertEventIsActive'
    /// </summary>
    public static string ForcedOpenAlertEventIsActive = "ForcedOpenAlertEventIsActive";
    /// <summary>
    /// Returns 'OpenTooLongAlertEventIsActive'
    /// </summary>
    public static string OpenTooLongAlertEventIsActive = "OpenTooLongAlertEventIsActive";
    /// <summary>
    /// Returns 'InvalidAccessAttemptAlertEventIsActive'
    /// </summary>
    public static string InvalidAccessAttemptAlertEventIsActive = "InvalidAccessAttemptAlertEventIsActive";
    /// <summary>
    /// Returns 'PassbackViolationAlertEventIsActive'
    /// </summary>
    public static string PassbackViolationAlertEventIsActive = "PassbackViolationAlertEventIsActive";
    /// <summary>
    /// Returns 'DuressAlertEventIsActive'
    /// </summary>
    public static string DuressAlertEventIsActive = "DuressAlertEventIsActive";
    /// <summary>
    /// Returns 'MissedHeartbeatAlertEventIsActive'
    /// </summary>
    public static string MissedHeartbeatAlertEventIsActive = "MissedHeartbeatAlertEventIsActive";
    /// <summary>
    /// Returns 'AccessGrantedAlertEventIsActive'
    /// </summary>
    public static string AccessGrantedAlertEventIsActive = "AccessGrantedAlertEventIsActive";
    /// <summary>
    /// Returns 'DoorGroupAlertEventIsActive'
    /// </summary>
    public static string DoorGroupAlertEventIsActive = "DoorGroupAlertEventIsActive";
    /// <summary>
    /// Returns 'UnlockedByAlertEventIsActive'
    /// </summary>
    public static string UnlockedByAlertEventIsActive = "UnlockedByAlertEventIsActive";
    /// <summary>
    /// Returns 'LockedByAlertEventIsActive'
    /// </summary>
    public static string LockedByAlertEventIsActive = "LockedByAlertEventIsActive";
    /// <summary>
    /// Returns 'Disarm1AlertEventIsActive'
    /// </summary>
    public static string Disarm1AlertEventIsActive = "Disarm1AlertEventIsActive";
    /// <summary>
    /// Returns 'Disarm2AlertEventIsActive'
    /// </summary>
    public static string Disarm2AlertEventIsActive = "Disarm2AlertEventIsActive";
    /// <summary>
    /// Returns 'Disarm3AlertEventIsActive'
    /// </summary>
    public static string Disarm3AlertEventIsActive = "Disarm3AlertEventIsActive";
    /// <summary>
    /// Returns 'Disarm4AlertEventIsActive'
    /// </summary>
    public static string Disarm4AlertEventIsActive = "Disarm4AlertEventIsActive";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortal_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "@GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
