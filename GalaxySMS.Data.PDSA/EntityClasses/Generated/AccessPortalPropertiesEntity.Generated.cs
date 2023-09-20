using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessPortalPropertiesPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessPortalPropertiesPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessPortalPropertiesUid = Guid.Empty;
    private Guid _AccessPortalUid = Guid.Empty;
    private Guid _AutomaticForgivePassbackFrequencyUid = Guid.Empty;
    private Guid _PinRequiredModeUid = Guid.Empty;
    private Guid _AccessPortalContactSupervisionTypeUid = Guid.Empty;
    private Guid _AccessPortalDeferToServerBehaviorUid = Guid.Empty;
    private Guid _AccessPortalNoServerReplyBehaviorUid = Guid.Empty;
    private Guid _AccessPortalLockPushButtonBehaviorUid = Guid.Empty;
    private Guid _LiquidCrystalDisplayUid = Guid.Empty;
    private Guid _AccessPortalElevatorControlTypeUid = Guid.Empty;
    private Guid _OtisElevatorDecUid = Guid.Empty;
    private Guid _ElevatorRelayInterfaceBoardSectionUid = Guid.Empty;
    private Guid _AccessPortalMultiFactorModeUid = Guid.Empty;
    private int _UnlockDelay = 0;
    private int _UnlockDuration = 0;
    private int _RecloseDuration = 0;
    private bool _AllowPassbackAccess = false;
    private bool _RequireTwoValidCredentials = false;
    private bool _UnlockOnREX = false;
    private bool _SuppressIllegalOpenLog = false;
    private bool _SuppressOpenTooLongLog = false;
    private bool _SuppressClosedLog = false;
    private bool _SuppressREXLog = false;
    private bool _GenerateDoorContactChangeLogs = false;
    private bool _LockWhenDoorCloses = false;
    private bool _EnableDuress = false;
    private bool _DoorGroupNotify = false;
    private bool _DoorGroupCanDisable = false;
    private bool _RelayOneOnDuringArmDelay = false;
    private bool _RequireValidAccessForAutoUnlock = false;
    private bool _ValidAccessRequiresDoorOpen = false;
    private bool _DontDecrementLimitedSwipeExpireCount = false;
    private bool _IgnoreNotInSystem = false;
    private bool _ReaderSendsHeartbeat = false;
    private bool _PhotoVerificationEnabled = false;
    private bool _TimeAttendancePortal = false;
    private bool _EMailEventsEnabled = false;
    private bool _TransmitEventsEnabled = false;
    private bool _FileOutputEnabled = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _AccessPortalPropertiesUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Access Portal Properties Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalPropertiesUid 
    { 
      get { return _AccessPortalPropertiesUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalPropertiesUid, value, "AccessPortalPropertiesUid"))
        {
          _AccessPortalPropertiesUid = value; 
          RaisePropertyChanged("AccessPortalPropertiesUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalUid 
    { 
      get { return _AccessPortalUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalUid, value, "AccessPortalUid"))
        {
          _AccessPortalUid = value; 
          RaisePropertyChanged("AccessPortalUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Automatic Forgive Passback Frequency Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AutomaticForgivePassbackFrequencyUid 
    { 
      get { return _AutomaticForgivePassbackFrequencyUid; }
      set 
      { 
        if(HasValueChanged(_AutomaticForgivePassbackFrequencyUid, value, "AutomaticForgivePassbackFrequencyUid"))
        {
          _AutomaticForgivePassbackFrequencyUid = value; 
          RaisePropertyChanged("AutomaticForgivePassbackFrequencyUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Pin Required Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PinRequiredModeUid 
    { 
      get { return _PinRequiredModeUid; }
      set 
      { 
        if(HasValueChanged(_PinRequiredModeUid, value, "PinRequiredModeUid"))
        {
          _PinRequiredModeUid = value; 
          RaisePropertyChanged("PinRequiredModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Contact Supervision Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalContactSupervisionTypeUid 
    { 
      get { return _AccessPortalContactSupervisionTypeUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalContactSupervisionTypeUid, value, "AccessPortalContactSupervisionTypeUid"))
        {
          _AccessPortalContactSupervisionTypeUid = value; 
          RaisePropertyChanged("AccessPortalContactSupervisionTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Defer To Server Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalDeferToServerBehaviorUid 
    { 
      get { return _AccessPortalDeferToServerBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalDeferToServerBehaviorUid, value, "AccessPortalDeferToServerBehaviorUid"))
        {
          _AccessPortalDeferToServerBehaviorUid = value; 
          RaisePropertyChanged("AccessPortalDeferToServerBehaviorUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal No Server Reply Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalNoServerReplyBehaviorUid 
    { 
      get { return _AccessPortalNoServerReplyBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalNoServerReplyBehaviorUid, value, "AccessPortalNoServerReplyBehaviorUid"))
        {
          _AccessPortalNoServerReplyBehaviorUid = value; 
          RaisePropertyChanged("AccessPortalNoServerReplyBehaviorUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Lock Push Button Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalLockPushButtonBehaviorUid 
    { 
      get { return _AccessPortalLockPushButtonBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalLockPushButtonBehaviorUid, value, "AccessPortalLockPushButtonBehaviorUid"))
        {
          _AccessPortalLockPushButtonBehaviorUid = value; 
          RaisePropertyChanged("AccessPortalLockPushButtonBehaviorUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Liquid Crystal Display Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid LiquidCrystalDisplayUid 
    { 
      get { return _LiquidCrystalDisplayUid; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayUid, value, "LiquidCrystalDisplayUid"))
        {
          _LiquidCrystalDisplayUid = value; 
          RaisePropertyChanged("LiquidCrystalDisplayUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Elevator Control Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalElevatorControlTypeUid 
    { 
      get { return _AccessPortalElevatorControlTypeUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalElevatorControlTypeUid, value, "AccessPortalElevatorControlTypeUid"))
        {
          _AccessPortalElevatorControlTypeUid = value; 
          RaisePropertyChanged("AccessPortalElevatorControlTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Otis Elevator Dec Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid OtisElevatorDecUid 
    { 
      get { return _OtisElevatorDecUid; }
      set 
      { 
        if(HasValueChanged(_OtisElevatorDecUid, value, "OtisElevatorDecUid"))
        {
          _OtisElevatorDecUid = value; 
          RaisePropertyChanged("OtisElevatorDecUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Elevator Relay Interface Board Section Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ElevatorRelayInterfaceBoardSectionUid 
    { 
      get { return _ElevatorRelayInterfaceBoardSectionUid; }
      set 
      { 
        if(HasValueChanged(_ElevatorRelayInterfaceBoardSectionUid, value, "ElevatorRelayInterfaceBoardSectionUid"))
        {
          _ElevatorRelayInterfaceBoardSectionUid = value; 
          RaisePropertyChanged("ElevatorRelayInterfaceBoardSectionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Multi Factor Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalMultiFactorModeUid 
    { 
      get { return _AccessPortalMultiFactorModeUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalMultiFactorModeUid, value, "AccessPortalMultiFactorModeUid"))
        {
          _AccessPortalMultiFactorModeUid = value; 
          RaisePropertyChanged("AccessPortalMultiFactorModeUid");
        }
      } 
    }
        
       
    /// <summary>
    /// Get/Set the Unlock Delay value
    /// </summary>
    
    [DataMember]
    
    public int UnlockDelay 
    { 
      get { return _UnlockDelay; }
      set 
      { 
        if(HasValueChanged(_UnlockDelay, value, "UnlockDelay"))
        {
          _UnlockDelay = value; 
          RaisePropertyChanged("UnlockDelay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Unlock Duration value
    /// </summary>
    
    [DataMember]
    
    public int UnlockDuration 
    { 
      get { return _UnlockDuration; }
      set 
      { 
        if(HasValueChanged(_UnlockDuration, value, "UnlockDuration"))
        {
          _UnlockDuration = value; 
          RaisePropertyChanged("UnlockDuration");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Reclose Duration value
    /// </summary>
    
    [DataMember]
    
    public int RecloseDuration 
    { 
      get { return _RecloseDuration; }
      set 
      { 
        if(HasValueChanged(_RecloseDuration, value, "RecloseDuration"))
        {
          _RecloseDuration = value; 
          RaisePropertyChanged("RecloseDuration");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Allow Passback Access value
    /// </summary>
    
    [DataMember]
    
    public bool AllowPassbackAccess 
    { 
      get { return _AllowPassbackAccess; }
      set 
      { 
        if(HasValueChanged(_AllowPassbackAccess, value, "AllowPassbackAccess"))
        {
          _AllowPassbackAccess = value; 
          RaisePropertyChanged("AllowPassbackAccess");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Require Two Valid Credentials value
    /// </summary>
    
    [DataMember]
    
    public bool RequireTwoValidCredentials 
    { 
      get { return _RequireTwoValidCredentials; }
      set 
      { 
        if(HasValueChanged(_RequireTwoValidCredentials, value, "RequireTwoValidCredentials"))
        {
          _RequireTwoValidCredentials = value; 
          RaisePropertyChanged("RequireTwoValidCredentials");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Unlock On REX value
    /// </summary>
    
    [DataMember]
    
    public bool UnlockOnREX 
    { 
      get { return _UnlockOnREX; }
      set 
      { 
        if(HasValueChanged(_UnlockOnREX, value, "UnlockOnREX"))
        {
          _UnlockOnREX = value; 
          RaisePropertyChanged("UnlockOnREX");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Suppress Illegal Open Log value
    /// </summary>
    
    [DataMember]
    
    public bool SuppressIllegalOpenLog 
    { 
      get { return _SuppressIllegalOpenLog; }
      set 
      { 
        if(HasValueChanged(_SuppressIllegalOpenLog, value, "SuppressIllegalOpenLog"))
        {
          _SuppressIllegalOpenLog = value; 
          RaisePropertyChanged("SuppressIllegalOpenLog");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Suppress Open Too Long Log value
    /// </summary>
    
    [DataMember]
    
    public bool SuppressOpenTooLongLog 
    { 
      get { return _SuppressOpenTooLongLog; }
      set 
      { 
        if(HasValueChanged(_SuppressOpenTooLongLog, value, "SuppressOpenTooLongLog"))
        {
          _SuppressOpenTooLongLog = value; 
          RaisePropertyChanged("SuppressOpenTooLongLog");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Suppress Closed Log value
    /// </summary>
    
    [DataMember]
    
    public bool SuppressClosedLog 
    { 
      get { return _SuppressClosedLog; }
      set 
      { 
        if(HasValueChanged(_SuppressClosedLog, value, "SuppressClosedLog"))
        {
          _SuppressClosedLog = value; 
          RaisePropertyChanged("SuppressClosedLog");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Suppress REX Log value
    /// </summary>
    
    [DataMember]
    
    public bool SuppressREXLog 
    { 
      get { return _SuppressREXLog; }
      set 
      { 
        if(HasValueChanged(_SuppressREXLog, value, "SuppressREXLog"))
        {
          _SuppressREXLog = value; 
          RaisePropertyChanged("SuppressREXLog");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Generate Door Contact Change Logs value
    /// </summary>
    
    [DataMember]
    
    public bool GenerateDoorContactChangeLogs 
    { 
      get { return _GenerateDoorContactChangeLogs; }
      set 
      { 
        if(HasValueChanged(_GenerateDoorContactChangeLogs, value, "GenerateDoorContactChangeLogs"))
        {
          _GenerateDoorContactChangeLogs = value; 
          RaisePropertyChanged("GenerateDoorContactChangeLogs");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lock When Door Closes value
    /// </summary>
    
    [DataMember]
    
    public bool LockWhenDoorCloses 
    { 
      get { return _LockWhenDoorCloses; }
      set 
      { 
        if(HasValueChanged(_LockWhenDoorCloses, value, "LockWhenDoorCloses"))
        {
          _LockWhenDoorCloses = value; 
          RaisePropertyChanged("LockWhenDoorCloses");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Enable Duress value
    /// </summary>
    
    [DataMember]
    
    public bool EnableDuress 
    { 
      get { return _EnableDuress; }
      set 
      { 
        if(HasValueChanged(_EnableDuress, value, "EnableDuress"))
        {
          _EnableDuress = value; 
          RaisePropertyChanged("EnableDuress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Door Group Notify value
    /// </summary>
    
    [DataMember]
    
    public bool DoorGroupNotify 
    { 
      get { return _DoorGroupNotify; }
      set 
      { 
        if(HasValueChanged(_DoorGroupNotify, value, "DoorGroupNotify"))
        {
          _DoorGroupNotify = value; 
          RaisePropertyChanged("DoorGroupNotify");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Door Group Can Disable value
    /// </summary>
    
    [DataMember]
    
    public bool DoorGroupCanDisable 
    { 
      get { return _DoorGroupCanDisable; }
      set 
      { 
        if(HasValueChanged(_DoorGroupCanDisable, value, "DoorGroupCanDisable"))
        {
          _DoorGroupCanDisable = value; 
          RaisePropertyChanged("DoorGroupCanDisable");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Relay One On During Arm Delay value
    /// </summary>
    
    [DataMember]
    
    public bool RelayOneOnDuringArmDelay 
    { 
      get { return _RelayOneOnDuringArmDelay; }
      set 
      { 
        if(HasValueChanged(_RelayOneOnDuringArmDelay, value, "RelayOneOnDuringArmDelay"))
        {
          _RelayOneOnDuringArmDelay = value; 
          RaisePropertyChanged("RelayOneOnDuringArmDelay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Require Valid Access For Auto Unlock value
    /// </summary>
    
    [DataMember]
    
    public bool RequireValidAccessForAutoUnlock 
    { 
      get { return _RequireValidAccessForAutoUnlock; }
      set 
      { 
        if(HasValueChanged(_RequireValidAccessForAutoUnlock, value, "RequireValidAccessForAutoUnlock"))
        {
          _RequireValidAccessForAutoUnlock = value; 
          RaisePropertyChanged("RequireValidAccessForAutoUnlock");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Valid Access Requires Door Open value
    /// </summary>
    
    [DataMember]
    
    public bool ValidAccessRequiresDoorOpen 
    { 
      get { return _ValidAccessRequiresDoorOpen; }
      set 
      { 
        if(HasValueChanged(_ValidAccessRequiresDoorOpen, value, "ValidAccessRequiresDoorOpen"))
        {
          _ValidAccessRequiresDoorOpen = value; 
          RaisePropertyChanged("ValidAccessRequiresDoorOpen");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dont Decrement Limited Swipe Expire Count value
    /// </summary>
    
    [DataMember]
    
    public bool DontDecrementLimitedSwipeExpireCount 
    { 
      get { return _DontDecrementLimitedSwipeExpireCount; }
      set 
      { 
        if(HasValueChanged(_DontDecrementLimitedSwipeExpireCount, value, "DontDecrementLimitedSwipeExpireCount"))
        {
          _DontDecrementLimitedSwipeExpireCount = value; 
          RaisePropertyChanged("DontDecrementLimitedSwipeExpireCount");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Ignore Not In System value
    /// </summary>
    
    [DataMember]
    
    public bool IgnoreNotInSystem 
    { 
      get { return _IgnoreNotInSystem; }
      set 
      { 
        if(HasValueChanged(_IgnoreNotInSystem, value, "IgnoreNotInSystem"))
        {
          _IgnoreNotInSystem = value; 
          RaisePropertyChanged("IgnoreNotInSystem");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Reader Sends Heartbeat value
    /// </summary>
    
    [DataMember]
    
    public bool ReaderSendsHeartbeat 
    { 
      get { return _ReaderSendsHeartbeat; }
      set 
      { 
        if(HasValueChanged(_ReaderSendsHeartbeat, value, "ReaderSendsHeartbeat"))
        {
          _ReaderSendsHeartbeat = value; 
          RaisePropertyChanged("ReaderSendsHeartbeat");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Photo Verification Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool PhotoVerificationEnabled 
    { 
      get { return _PhotoVerificationEnabled; }
      set 
      { 
        if(HasValueChanged(_PhotoVerificationEnabled, value, "PhotoVerificationEnabled"))
        {
          _PhotoVerificationEnabled = value; 
          RaisePropertyChanged("PhotoVerificationEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Attendance Portal value
    /// </summary>
    
    [DataMember]
    
    public bool TimeAttendancePortal 
    { 
      get { return _TimeAttendancePortal; }
      set 
      { 
        if(HasValueChanged(_TimeAttendancePortal, value, "TimeAttendancePortal"))
        {
          _TimeAttendancePortal = value; 
          RaisePropertyChanged("TimeAttendancePortal");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the E Mail Events Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool EMailEventsEnabled 
    { 
      get { return _EMailEventsEnabled; }
      set 
      { 
        if(HasValueChanged(_EMailEventsEnabled, value, "EMailEventsEnabled"))
        {
          _EMailEventsEnabled = value; 
          RaisePropertyChanged("EMailEventsEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Transmit Events Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool TransmitEventsEnabled 
    { 
      get { return _TransmitEventsEnabled; }
      set 
      { 
        if(HasValueChanged(_TransmitEventsEnabled, value, "TransmitEventsEnabled"))
        {
          _TransmitEventsEnabled = value; 
          RaisePropertyChanged("TransmitEventsEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the File Output Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool FileOutputEnabled 
    { 
      get { return _FileOutputEnabled; }
      set 
      { 
        if(HasValueChanged(_FileOutputEnabled, value, "FileOutputEnabled"))
        {
          _FileOutputEnabled = value; 
          RaisePropertyChanged("FileOutputEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Name value
    /// </summary>
    
    [DataMember]
    
    public string InsertName 
    { 
      get { return _InsertName; }
      set 
      { 
        if(HasValueChanged(_InsertName, value, "InsertName"))
        {
          _InsertName = value; 
          RaisePropertyChanged("InsertName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset InsertDate 
    { 
      get { return _InsertDate; }
      set 
      { 
        if(HasValueChanged(_InsertDate, value, "InsertDate"))
        {
          _InsertDate = value; 
          RaisePropertyChanged("InsertDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Name value
    /// </summary>
    
    [DataMember]
    
    public string UpdateName 
    { 
      get { return _UpdateName; }
      set 
      { 
        if(HasValueChanged(_UpdateName, value, "UpdateName"))
        {
          _UpdateName = value; 
          RaisePropertyChanged("UpdateName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset UpdateDate 
    { 
      get { return _UpdateDate; }
      set 
      { 
        if(HasValueChanged(_UpdateDate, value, "UpdateDate"))
        {
          _UpdateDate = value; 
          RaisePropertyChanged("UpdateDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Concurrency Value value
    /// </summary>
    
    [DataMember]
    
    public short ConcurrencyValue 
    { 
      get { return _ConcurrencyValue; }
      set 
      { 
        if(HasValueChanged(_ConcurrencyValue, value, "ConcurrencyValue"))
        {
          _ConcurrencyValue = value; 
          RaisePropertyChanged("ConcurrencyValue");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Access Portal Properties UidOld value
    /// </summary>
    
    public Guid AccessPortalPropertiesUidOld
    { 
      get { return _AccessPortalPropertiesUidOld; }
      set 
      { 
        if(HasValueChanged(_AccessPortalPropertiesUidOld, value, "AccessPortalPropertiesUid"))
        {
          _AccessPortalPropertiesUidOld = value; 
          RaisePropertyChanged("AccessPortalPropertiesUidOld");
        }
      } 
    }
    #endregion
  }
}
