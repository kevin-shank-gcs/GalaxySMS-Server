using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a InputDevice_PanelLoadDataPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDevice_PanelLoadDataPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _InputDeviceUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardSectionUid = Guid.Empty;
    private Guid _GalaxyHardwareModuleUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardSectionNodeUid = Guid.Empty;
    private string _InputName = string.Empty;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _BoardNumber = 0;
    private short _SectionNumber = 0;
    private short _ModuleNumber = 0;
    private short _NodeNumber = 0;
    private bool _IsInputActive = false;
    private short _InputDeviceBoardSectionMode = 0;
    private bool _IsNodeActive = false;
    private string _InputDeviceBoardSectionModeDisplay = string.Empty;
    private bool _IsModuleActive = false;
    private string _InputDevicePanelModelTypeCode = string.Empty;
    private string _InputDeviceCpuTypeCode = string.Empty;
    private string _InputDeviceBoardTypeModel = string.Empty;
    private short _InputDeviceBoardTypeTypeCode = 0;
    private string _InputDeviceBoardTypeDisplay = string.Empty;
    private string _SupervisionTypeDisplay = string.Empty;
    private bool _HasSeriesResistor = false;
    private bool _HasParallelResistor = false;
    private bool _IsNormalOpen = false;
    private short _TroubleShortThreshold = 0;
    private short _TroubleOpenThreshold = 0;
    private short _NormalChangeThreshold = 0;
    private short _AlternateNormalChangeThreshold = 0;
    private short _AlternateTroubleOpenThreshold = 0;
    private short _AlternateTroubleShortThreshold = 0;
    private bool _AlternateVoltagesEnabled = false;
    private string _GalaxyInputModeDisplay = string.Empty;
    private short _GalaxyInputModeCode = 0;
    private string _GalaxyInputDelayTypeDisplay = string.Empty;
    private short _GalaxyInputDelayTypeCode = 0;
    private string _MainIOGroupTag = string.Empty;
    private string _MainIOGroupDisplay = string.Empty;
    private int _MainIOGroupNumber = 0;
    private bool _MainIOGroupIsLocal = false;
    private short _MainIOGroupOffset = 0;
    private int _DelayDuration = 0;
    private bool _DisableDisarmedOnOffLogEvents = false;
    private string _ArmControlScheduleDisplay = string.Empty;
    private DateTimeOffset? _GalaxyInputDevicePropertiesLastUpdated = null;
    private DateTimeOffset? _MainIOGroupLastUpdated =null;
    private DateTimeOffset? _ArmingIOGroup1LastUpdated =null;
    private DateTimeOffset? _ArmingIOGroup2LastUpdated = null;
    private int _ArmControlScheduleNumber = 0;
    private DateTimeOffset? _ArmingIOGroup3LastUpdated = null;
    private DateTimeOffset? _ArmingIOGroup4LastUpdated = null;
    private DateTimeOffset? _MainScheduleLastUpdated = null;
    private string _ArmingIOGroup1Display = string.Empty;
    private int _ArmingIOGroupNumber1 = 0;
    private bool _ArmingIOGroup1IsLocal = false;
    private string _ArmingIOGroup2Display = string.Empty;
    private int _ArmingIOGroupNumber2 = 0;
    private bool _ArmingIOGroup2IsLocal = false;
    private string _ArmingIOGroup3Display = string.Empty;
    private int _ArmingIOGroupNumber3 = 0;
    private bool _ArmingIOGroup3IsLocal = false;
    private string _ArmingIOGroup4Display = string.Empty;
    private int _ArmingIOGroupNumber4 = 0;
    private bool _ArmingIOGroup4IsLocal = false;
    private int _CpuNumber = 0;
    private Guid _CpuUid = Guid.Empty;
    private string _ServerAddress = string.Empty;
    private int _IsConnected = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Input Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceUid 
    { 
      get { return _InputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceUid, value, "InputDeviceUid"))
        {
          _InputDeviceUid = value; 
          RaisePropertyChanged("InputDeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ClusterUid 
    { 
      get { return _ClusterUid; }
      set 
      { 
        if(HasValueChanged(_ClusterUid, value, "ClusterUid"))
        {
          _ClusterUid = value; 
          RaisePropertyChanged("ClusterUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelUid 
    { 
      get { return _GalaxyPanelUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelUid, value, "GalaxyPanelUid"))
        {
          _GalaxyPanelUid = value; 
          RaisePropertyChanged("GalaxyPanelUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardUid 
    { 
      get { return _GalaxyInterfaceBoardUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardUid, value, "GalaxyInterfaceBoardUid"))
        {
          _GalaxyInterfaceBoardUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionUid 
    { 
      get { return _GalaxyInterfaceBoardSectionUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionUid, value, "GalaxyInterfaceBoardSectionUid"))
        {
          _GalaxyInterfaceBoardSectionUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Hardware Module Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyHardwareModuleUid 
    { 
      get { return _GalaxyHardwareModuleUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyHardwareModuleUid, value, "GalaxyHardwareModuleUid"))
        {
          _GalaxyHardwareModuleUid = value; 
          RaisePropertyChanged("GalaxyHardwareModuleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Interface Board Section Node Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInterfaceBoardSectionNodeUid 
    { 
      get { return _GalaxyInterfaceBoardSectionNodeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardSectionNodeUid, value, "GalaxyInterfaceBoardSectionNodeUid"))
        {
          _GalaxyInterfaceBoardSectionNodeUid = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardSectionNodeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Name value
    /// </summary>
    
    [DataMember]
    
    public string InputName 
    { 
      get { return _InputName; }
      set 
      { 
        if(HasValueChanged(_InputName, value, "InputName"))
        {
          _InputName = value; 
          RaisePropertyChanged("InputName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Group Id value
    /// </summary>
    
    [DataMember]
    
    public int ClusterGroupId 
    { 
      get { return _ClusterGroupId; }
      set 
      { 
        if(HasValueChanged(_ClusterGroupId, value, "ClusterGroupId"))
        {
          _ClusterGroupId = value; 
          RaisePropertyChanged("ClusterGroupId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Number value
    /// </summary>
    
    [DataMember]
    
    public int ClusterNumber 
    { 
      get { return _ClusterNumber; }
      set 
      { 
        if(HasValueChanged(_ClusterNumber, value, "ClusterNumber"))
        {
          _ClusterNumber = value; 
          RaisePropertyChanged("ClusterNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelNumber 
    { 
      get { return _PanelNumber; }
      set 
      { 
        if(HasValueChanged(_PanelNumber, value, "PanelNumber"))
        {
          _PanelNumber = value; 
          RaisePropertyChanged("PanelNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Number value
    /// </summary>
    
    [DataMember]
    
    public short BoardNumber 
    { 
      get { return _BoardNumber; }
      set 
      { 
        if(HasValueChanged(_BoardNumber, value, "BoardNumber"))
        {
          _BoardNumber = value; 
          RaisePropertyChanged("BoardNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Section Number value
    /// </summary>
    
    [DataMember]
    
    public short SectionNumber 
    { 
      get { return _SectionNumber; }
      set 
      { 
        if(HasValueChanged(_SectionNumber, value, "SectionNumber"))
        {
          _SectionNumber = value; 
          RaisePropertyChanged("SectionNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Module Number value
    /// </summary>
    
    [DataMember]
    
    public short ModuleNumber 
    { 
      get { return _ModuleNumber; }
      set 
      { 
        if(HasValueChanged(_ModuleNumber, value, "ModuleNumber"))
        {
          _ModuleNumber = value; 
          RaisePropertyChanged("ModuleNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Node Number value
    /// </summary>
    
    [DataMember]
    
    public short NodeNumber 
    { 
      get { return _NodeNumber; }
      set 
      { 
        if(HasValueChanged(_NodeNumber, value, "NodeNumber"))
        {
          _NodeNumber = value; 
          RaisePropertyChanged("NodeNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Input Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsInputActive 
    { 
      get { return _IsInputActive; }
      set 
      { 
        if(HasValueChanged(_IsInputActive, value, "IsInputActive"))
        {
          _IsInputActive = value; 
          RaisePropertyChanged("IsInputActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Board Section Mode value
    /// </summary>
    
    [DataMember]
    
    public short InputDeviceBoardSectionMode 
    { 
      get { return _InputDeviceBoardSectionMode; }
      set 
      { 
        if(HasValueChanged(_InputDeviceBoardSectionMode, value, "InputDeviceBoardSectionMode"))
        {
          _InputDeviceBoardSectionMode = value; 
          RaisePropertyChanged("InputDeviceBoardSectionMode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Node Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsNodeActive 
    { 
      get { return _IsNodeActive; }
      set 
      { 
        if(HasValueChanged(_IsNodeActive, value, "IsNodeActive"))
        {
          _IsNodeActive = value; 
          RaisePropertyChanged("IsNodeActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Board Section Mode Display value
    /// </summary>
    
    [DataMember]
    
    public string InputDeviceBoardSectionModeDisplay 
    { 
      get { return _InputDeviceBoardSectionModeDisplay; }
      set 
      { 
        if(HasValueChanged(_InputDeviceBoardSectionModeDisplay, value, "InputDeviceBoardSectionModeDisplay"))
        {
          _InputDeviceBoardSectionModeDisplay = value; 
          RaisePropertyChanged("InputDeviceBoardSectionModeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Module Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsModuleActive 
    { 
      get { return _IsModuleActive; }
      set 
      { 
        if(HasValueChanged(_IsModuleActive, value, "IsModuleActive"))
        {
          _IsModuleActive = value; 
          RaisePropertyChanged("IsModuleActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Panel Model Type Code value
    /// </summary>
    
    [DataMember]
    
    public string InputDevicePanelModelTypeCode 
    { 
      get { return _InputDevicePanelModelTypeCode; }
      set 
      { 
        if(HasValueChanged(_InputDevicePanelModelTypeCode, value, "InputDevicePanelModelTypeCode"))
        {
          _InputDevicePanelModelTypeCode = value; 
          RaisePropertyChanged("InputDevicePanelModelTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Cpu Type Code value
    /// </summary>
    
    [DataMember]
    
    public string InputDeviceCpuTypeCode 
    { 
      get { return _InputDeviceCpuTypeCode; }
      set 
      { 
        if(HasValueChanged(_InputDeviceCpuTypeCode, value, "InputDeviceCpuTypeCode"))
        {
          _InputDeviceCpuTypeCode = value; 
          RaisePropertyChanged("InputDeviceCpuTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Board Type Model value
    /// </summary>
    
    [DataMember]
    
    public string InputDeviceBoardTypeModel 
    { 
      get { return _InputDeviceBoardTypeModel; }
      set 
      { 
        if(HasValueChanged(_InputDeviceBoardTypeModel, value, "InputDeviceBoardTypeModel"))
        {
          _InputDeviceBoardTypeModel = value; 
          RaisePropertyChanged("InputDeviceBoardTypeModel");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Board Type Type Code value
    /// </summary>
    
    [DataMember]
    
    public short InputDeviceBoardTypeTypeCode 
    { 
      get { return _InputDeviceBoardTypeTypeCode; }
      set 
      { 
        if(HasValueChanged(_InputDeviceBoardTypeTypeCode, value, "InputDeviceBoardTypeTypeCode"))
        {
          _InputDeviceBoardTypeTypeCode = value; 
          RaisePropertyChanged("InputDeviceBoardTypeTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Board Type Display value
    /// </summary>
    
    [DataMember]
    
    public string InputDeviceBoardTypeDisplay 
    { 
      get { return _InputDeviceBoardTypeDisplay; }
      set 
      { 
        if(HasValueChanged(_InputDeviceBoardTypeDisplay, value, "InputDeviceBoardTypeDisplay"))
        {
          _InputDeviceBoardTypeDisplay = value; 
          RaisePropertyChanged("InputDeviceBoardTypeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Supervision Type Display value
    /// </summary>
    
    [DataMember]
    
    public string SupervisionTypeDisplay 
    { 
      get { return _SupervisionTypeDisplay; }
      set 
      { 
        if(HasValueChanged(_SupervisionTypeDisplay, value, "SupervisionTypeDisplay"))
        {
          _SupervisionTypeDisplay = value; 
          RaisePropertyChanged("SupervisionTypeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Has Series Resistor value
    /// </summary>
    
    [DataMember]
    
    public bool HasSeriesResistor 
    { 
      get { return _HasSeriesResistor; }
      set 
      { 
        if(HasValueChanged(_HasSeriesResistor, value, "HasSeriesResistor"))
        {
          _HasSeriesResistor = value; 
          RaisePropertyChanged("HasSeriesResistor");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Has Parallel Resistor value
    /// </summary>
    
    [DataMember]
    
    public bool HasParallelResistor 
    { 
      get { return _HasParallelResistor; }
      set 
      { 
        if(HasValueChanged(_HasParallelResistor, value, "HasParallelResistor"))
        {
          _HasParallelResistor = value; 
          RaisePropertyChanged("HasParallelResistor");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Normal Open value
    /// </summary>
    
    [DataMember]
    
    public bool IsNormalOpen 
    { 
      get { return _IsNormalOpen; }
      set 
      { 
        if(HasValueChanged(_IsNormalOpen, value, "IsNormalOpen"))
        {
          _IsNormalOpen = value; 
          RaisePropertyChanged("IsNormalOpen");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Trouble Short Threshold value
    /// </summary>
    
    [DataMember]
    
    public short TroubleShortThreshold 
    { 
      get { return _TroubleShortThreshold; }
      set 
      { 
        if(HasValueChanged(_TroubleShortThreshold, value, "TroubleShortThreshold"))
        {
          _TroubleShortThreshold = value; 
          RaisePropertyChanged("TroubleShortThreshold");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Trouble Open Threshold value
    /// </summary>
    
    [DataMember]
    
    public short TroubleOpenThreshold 
    { 
      get { return _TroubleOpenThreshold; }
      set 
      { 
        if(HasValueChanged(_TroubleOpenThreshold, value, "TroubleOpenThreshold"))
        {
          _TroubleOpenThreshold = value; 
          RaisePropertyChanged("TroubleOpenThreshold");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Normal Change Threshold value
    /// </summary>
    
    [DataMember]
    
    public short NormalChangeThreshold 
    { 
      get { return _NormalChangeThreshold; }
      set 
      { 
        if(HasValueChanged(_NormalChangeThreshold, value, "NormalChangeThreshold"))
        {
          _NormalChangeThreshold = value; 
          RaisePropertyChanged("NormalChangeThreshold");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Alternate Normal Change Threshold value
    /// </summary>
    
    [DataMember]
    
    public short AlternateNormalChangeThreshold 
    { 
      get { return _AlternateNormalChangeThreshold; }
      set 
      { 
        if(HasValueChanged(_AlternateNormalChangeThreshold, value, "AlternateNormalChangeThreshold"))
        {
          _AlternateNormalChangeThreshold = value; 
          RaisePropertyChanged("AlternateNormalChangeThreshold");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Alternate Trouble Open Threshold value
    /// </summary>
    
    [DataMember]
    
    public short AlternateTroubleOpenThreshold 
    { 
      get { return _AlternateTroubleOpenThreshold; }
      set 
      { 
        if(HasValueChanged(_AlternateTroubleOpenThreshold, value, "AlternateTroubleOpenThreshold"))
        {
          _AlternateTroubleOpenThreshold = value; 
          RaisePropertyChanged("AlternateTroubleOpenThreshold");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Alternate Trouble Short Threshold value
    /// </summary>
    
    [DataMember]
    
    public short AlternateTroubleShortThreshold 
    { 
      get { return _AlternateTroubleShortThreshold; }
      set 
      { 
        if(HasValueChanged(_AlternateTroubleShortThreshold, value, "AlternateTroubleShortThreshold"))
        {
          _AlternateTroubleShortThreshold = value; 
          RaisePropertyChanged("AlternateTroubleShortThreshold");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Alternate Voltages Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool AlternateVoltagesEnabled 
    { 
      get { return _AlternateVoltagesEnabled; }
      set 
      { 
        if(HasValueChanged(_AlternateVoltagesEnabled, value, "AlternateVoltagesEnabled"))
        {
          _AlternateVoltagesEnabled = value; 
          RaisePropertyChanged("AlternateVoltagesEnabled");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Input Mode Display value
    /// </summary>
    
    [DataMember]
    
    public string GalaxyInputModeDisplay 
    { 
      get { return _GalaxyInputModeDisplay; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputModeDisplay, value, "GalaxyInputModeDisplay"))
        {
          _GalaxyInputModeDisplay = value; 
          RaisePropertyChanged("GalaxyInputModeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Input Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short GalaxyInputModeCode 
    { 
      get { return _GalaxyInputModeCode; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputModeCode, value, "GalaxyInputModeCode"))
        {
          _GalaxyInputModeCode = value; 
          RaisePropertyChanged("GalaxyInputModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Input Delay Type Display value
    /// </summary>
    
    [DataMember]
    
    public string GalaxyInputDelayTypeDisplay 
    { 
      get { return _GalaxyInputDelayTypeDisplay; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputDelayTypeDisplay, value, "GalaxyInputDelayTypeDisplay"))
        {
          _GalaxyInputDelayTypeDisplay = value; 
          RaisePropertyChanged("GalaxyInputDelayTypeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Input Delay Type Code value
    /// </summary>
    
    [DataMember]
    
    public short GalaxyInputDelayTypeCode 
    { 
      get { return _GalaxyInputDelayTypeCode; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputDelayTypeCode, value, "GalaxyInputDelayTypeCode"))
        {
          _GalaxyInputDelayTypeCode = value; 
          RaisePropertyChanged("GalaxyInputDelayTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main IO Group Tag value
    /// </summary>
    
    [DataMember]
    
    public string MainIOGroupTag 
    { 
      get { return _MainIOGroupTag; }
      set 
      { 
        if(HasValueChanged(_MainIOGroupTag, value, "MainIOGroupTag"))
        {
          _MainIOGroupTag = value; 
          RaisePropertyChanged("MainIOGroupTag");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main IO Group Display value
    /// </summary>
    
    [DataMember]
    
    public string MainIOGroupDisplay 
    { 
      get { return _MainIOGroupDisplay; }
      set 
      { 
        if(HasValueChanged(_MainIOGroupDisplay, value, "MainIOGroupDisplay"))
        {
          _MainIOGroupDisplay = value; 
          RaisePropertyChanged("MainIOGroupDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main IO Group Number value
    /// </summary>
    
    [DataMember]
    
    public int MainIOGroupNumber 
    { 
      get { return _MainIOGroupNumber; }
      set 
      { 
        if(HasValueChanged(_MainIOGroupNumber, value, "MainIOGroupNumber"))
        {
          _MainIOGroupNumber = value; 
          RaisePropertyChanged("MainIOGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main IO Group Is Local value
    /// </summary>
    
    [DataMember]
    
    public bool MainIOGroupIsLocal 
    { 
      get { return _MainIOGroupIsLocal; }
      set 
      { 
        if(HasValueChanged(_MainIOGroupIsLocal, value, "MainIOGroupIsLocal"))
        {
          _MainIOGroupIsLocal = value; 
          RaisePropertyChanged("MainIOGroupIsLocal");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main IO Group Offset value
    /// </summary>
    
    [DataMember]
    
    public short MainIOGroupOffset 
    { 
      get { return _MainIOGroupOffset; }
      set 
      { 
        if(HasValueChanged(_MainIOGroupOffset, value, "MainIOGroupOffset"))
        {
          _MainIOGroupOffset = value; 
          RaisePropertyChanged("MainIOGroupOffset");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Delay Duration value
    /// </summary>
    
    [DataMember]
    
    public int DelayDuration 
    { 
      get { return _DelayDuration; }
      set 
      { 
        if(HasValueChanged(_DelayDuration, value, "DelayDuration"))
        {
          _DelayDuration = value; 
          RaisePropertyChanged("DelayDuration");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Disable Disarmed On Off Log Events value
    /// </summary>
    
    [DataMember]
    
    public bool DisableDisarmedOnOffLogEvents 
    { 
      get { return _DisableDisarmedOnOffLogEvents; }
      set 
      { 
        if(HasValueChanged(_DisableDisarmedOnOffLogEvents, value, "DisableDisarmedOnOffLogEvents"))
        {
          _DisableDisarmedOnOffLogEvents = value; 
          RaisePropertyChanged("DisableDisarmedOnOffLogEvents");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arm Control Schedule Display value
    /// </summary>
    
    [DataMember]
    
    public string ArmControlScheduleDisplay 
    { 
      get { return _ArmControlScheduleDisplay; }
      set 
      { 
        if(HasValueChanged(_ArmControlScheduleDisplay, value, "ArmControlScheduleDisplay"))
        {
          _ArmControlScheduleDisplay = value; 
          RaisePropertyChanged("ArmControlScheduleDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Input Device Properties Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? GalaxyInputDevicePropertiesLastUpdated 
    { 
      get { return _GalaxyInputDevicePropertiesLastUpdated; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputDevicePropertiesLastUpdated, value, "GalaxyInputDevicePropertiesLastUpdated"))
        {
          _GalaxyInputDevicePropertiesLastUpdated = value; 
          RaisePropertyChanged("GalaxyInputDevicePropertiesLastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main IO Group Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? MainIOGroupLastUpdated 
    { 
      get { return _MainIOGroupLastUpdated; }
      set 
      { 
        if(HasValueChanged(_MainIOGroupLastUpdated, value, "MainIOGroupLastUpdated"))
        {
          _MainIOGroupLastUpdated = value; 
          RaisePropertyChanged("MainIOGroupLastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 1 Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? ArmingIOGroup1LastUpdated 
    { 
      get { return _ArmingIOGroup1LastUpdated; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup1LastUpdated, value, "ArmingIOGroup1LastUpdated"))
        {
          _ArmingIOGroup1LastUpdated = value; 
          RaisePropertyChanged("ArmingIOGroup1LastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 2 Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? ArmingIOGroup2LastUpdated 
    { 
      get { return _ArmingIOGroup2LastUpdated; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup2LastUpdated, value, "ArmingIOGroup2LastUpdated"))
        {
          _ArmingIOGroup2LastUpdated = value; 
          RaisePropertyChanged("ArmingIOGroup2LastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arm Control Schedule Number value
    /// </summary>
    
    [DataMember]
    
    public int ArmControlScheduleNumber 
    { 
      get { return _ArmControlScheduleNumber; }
      set 
      { 
        if(HasValueChanged(_ArmControlScheduleNumber, value, "ArmControlScheduleNumber"))
        {
          _ArmControlScheduleNumber = value; 
          RaisePropertyChanged("ArmControlScheduleNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 3 Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? ArmingIOGroup3LastUpdated 
    { 
      get { return _ArmingIOGroup3LastUpdated; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup3LastUpdated, value, "ArmingIOGroup3LastUpdated"))
        {
          _ArmingIOGroup3LastUpdated = value; 
          RaisePropertyChanged("ArmingIOGroup3LastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 4 Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? ArmingIOGroup4LastUpdated 
    { 
      get { return _ArmingIOGroup4LastUpdated; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup4LastUpdated, value, "ArmingIOGroup4LastUpdated"))
        {
          _ArmingIOGroup4LastUpdated = value; 
          RaisePropertyChanged("ArmingIOGroup4LastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Main Schedule Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? MainScheduleLastUpdated 
    { 
      get { return _MainScheduleLastUpdated; }
      set 
      { 
        if(HasValueChanged(_MainScheduleLastUpdated, value, "MainScheduleLastUpdated"))
        {
          _MainScheduleLastUpdated = value; 
          RaisePropertyChanged("MainScheduleLastUpdated");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 1 Display value
    /// </summary>
    
    [DataMember]
    
    public string ArmingIOGroup1Display 
    { 
      get { return _ArmingIOGroup1Display; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup1Display, value, "ArmingIOGroup1Display"))
        {
          _ArmingIOGroup1Display = value; 
          RaisePropertyChanged("ArmingIOGroup1Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group Number 1 value
    /// </summary>
    
    [DataMember]
    
    public int ArmingIOGroupNumber1 
    { 
      get { return _ArmingIOGroupNumber1; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroupNumber1, value, "ArmingIOGroupNumber1"))
        {
          _ArmingIOGroupNumber1 = value; 
          RaisePropertyChanged("ArmingIOGroupNumber1");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 1 Is Local value
    /// </summary>
    
    [DataMember]
    
    public bool ArmingIOGroup1IsLocal 
    { 
      get { return _ArmingIOGroup1IsLocal; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup1IsLocal, value, "ArmingIOGroup1IsLocal"))
        {
          _ArmingIOGroup1IsLocal = value; 
          RaisePropertyChanged("ArmingIOGroup1IsLocal");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 2 Display value
    /// </summary>
    
    [DataMember]
    
    public string ArmingIOGroup2Display 
    { 
      get { return _ArmingIOGroup2Display; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup2Display, value, "ArmingIOGroup2Display"))
        {
          _ArmingIOGroup2Display = value; 
          RaisePropertyChanged("ArmingIOGroup2Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group Number 2 value
    /// </summary>
    
    [DataMember]
    
    public int ArmingIOGroupNumber2 
    { 
      get { return _ArmingIOGroupNumber2; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroupNumber2, value, "ArmingIOGroupNumber2"))
        {
          _ArmingIOGroupNumber2 = value; 
          RaisePropertyChanged("ArmingIOGroupNumber2");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 2 Is Local value
    /// </summary>
    
    [DataMember]
    
    public bool ArmingIOGroup2IsLocal 
    { 
      get { return _ArmingIOGroup2IsLocal; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup2IsLocal, value, "ArmingIOGroup2IsLocal"))
        {
          _ArmingIOGroup2IsLocal = value; 
          RaisePropertyChanged("ArmingIOGroup2IsLocal");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 3 Display value
    /// </summary>
    
    [DataMember]
    
    public string ArmingIOGroup3Display 
    { 
      get { return _ArmingIOGroup3Display; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup3Display, value, "ArmingIOGroup3Display"))
        {
          _ArmingIOGroup3Display = value; 
          RaisePropertyChanged("ArmingIOGroup3Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group Number 3 value
    /// </summary>
    
    [DataMember]
    
    public int ArmingIOGroupNumber3 
    { 
      get { return _ArmingIOGroupNumber3; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroupNumber3, value, "ArmingIOGroupNumber3"))
        {
          _ArmingIOGroupNumber3 = value; 
          RaisePropertyChanged("ArmingIOGroupNumber3");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 3 Is Local value
    /// </summary>
    
    [DataMember]
    
    public bool ArmingIOGroup3IsLocal 
    { 
      get { return _ArmingIOGroup3IsLocal; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup3IsLocal, value, "ArmingIOGroup3IsLocal"))
        {
          _ArmingIOGroup3IsLocal = value; 
          RaisePropertyChanged("ArmingIOGroup3IsLocal");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 4 Display value
    /// </summary>
    
    [DataMember]
    
    public string ArmingIOGroup4Display 
    { 
      get { return _ArmingIOGroup4Display; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup4Display, value, "ArmingIOGroup4Display"))
        {
          _ArmingIOGroup4Display = value; 
          RaisePropertyChanged("ArmingIOGroup4Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group Number 4 value
    /// </summary>
    
    [DataMember]
    
    public int ArmingIOGroupNumber4 
    { 
      get { return _ArmingIOGroupNumber4; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroupNumber4, value, "ArmingIOGroupNumber4"))
        {
          _ArmingIOGroupNumber4 = value; 
          RaisePropertyChanged("ArmingIOGroupNumber4");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Arming IO Group 4 Is Local value
    /// </summary>
    
    [DataMember]
    
    public bool ArmingIOGroup4IsLocal 
    { 
      get { return _ArmingIOGroup4IsLocal; }
      set 
      { 
        if(HasValueChanged(_ArmingIOGroup4IsLocal, value, "ArmingIOGroup4IsLocal"))
        {
          _ArmingIOGroup4IsLocal = value; 
          RaisePropertyChanged("ArmingIOGroup4IsLocal");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Number value
    /// </summary>
    
    [DataMember]
    
    public int CpuNumber 
    { 
      get { return _CpuNumber; }
      set 
      { 
        if(HasValueChanged(_CpuNumber, value, "CpuNumber"))
        {
          _CpuNumber = value; 
          RaisePropertyChanged("CpuNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CpuUid 
    { 
      get { return _CpuUid; }
      set 
      { 
        if(HasValueChanged(_CpuUid, value, "CpuUid"))
        {
          _CpuUid = value; 
          RaisePropertyChanged("CpuUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Server Address value
    /// </summary>
    
    [DataMember]
    
    public string ServerAddress 
    { 
      get { return _ServerAddress; }
      set 
      { 
        if(HasValueChanged(_ServerAddress, value, "ServerAddress"))
        {
          _ServerAddress = value; 
          RaisePropertyChanged("ServerAddress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Connected value
    /// </summary>
    
    [DataMember]
    
    public int IsConnected 
    { 
      get { return _IsConnected; }
      set 
      { 
        if(HasValueChanged(_IsConnected, value, "IsConnected"))
        {
          _IsConnected = value; 
          RaisePropertyChanged("IsConnected");
        }
      } 
    }
        

    #endregion
  }
}
