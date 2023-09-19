using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the OutputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class OutputDevice_GetPanelLoadDataByGalaxyHardwareModuleUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _OutputDeviceUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardSectionUid = Guid.Empty;
    private Guid _GalaxyHardwareModuleUid = Guid.Empty;
    private Guid _GalaxyInterfaceBoardSectionNodeUid = Guid.Empty;
    private string _OutputName = string.Empty;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _BoardNumber = 0;
    private short _SectionNumber = 0;
    private short _ModuleNumber = 0;
    private short _NodeNumber = 0;
    private bool _IsOutputActive = false;
    private bool _IsNodeActive = false;
    private bool _IsModuleActive = false;
    private short _OutputDeviceBoardSectionMode = 0;
    private string _OutputDeviceBoardSectionModeDisplay = string.Empty;
    private string _OutputDevicePanelModelTypeCode = string.Empty;
    private string _OutputDeviceCpuTypeCode = string.Empty;
    private string _OutputDeviceBoardTypeModel = string.Empty;
    private short _OutputDeviceBoardTypeTypeCode = 0;
    private string _OutputDeviceBoardTypeDisplay = string.Empty;
    private string _GalaxyOutputModeDisplay = string.Empty;
    private short _GalaxyOutputModeCode = 0;
    private string _InputSourceRelationshipDisplay = string.Empty;
    private short _InputSourceRelationshipCode = 0;
    private int _TimeoutDuration = 0;
    private int _Limit = 0;
    private bool _InvertOutput = false;
    private string _ScheduleDisplay = string.Empty;
    private int _ScheduleNumber = 0;
    private DateTimeOffset _GalaxyOutputDevicePropertiesLastUpdated = DateTimeOffset.Now;
    private int _CpuNumber = 0;
    private Guid _CpuUid = Guid.Empty;
    private string _ServerAddress = string.Empty;
    private int _IsConnected = 0;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Output Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid OutputDeviceUid 
    { 
      get { return _OutputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceUid, value, "OutputDeviceUid"))
        {
          _OutputDeviceUid = value; 
          RaisePropertyChanged("OutputDeviceUid");
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
    /// Get/Set the Output Name value
    /// </summary>
    
    [DataMember]
    
    public string OutputName 
    { 
      get { return _OutputName; }
      set 
      { 
        if(HasValueChanged(_OutputName, value, "OutputName"))
        {
          _OutputName = value; 
          RaisePropertyChanged("OutputName");
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
    /// Get/Set the Is Output Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsOutputActive 
    { 
      get { return _IsOutputActive; }
      set 
      { 
        if(HasValueChanged(_IsOutputActive, value, "IsOutputActive"))
        {
          _IsOutputActive = value; 
          RaisePropertyChanged("IsOutputActive");
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
    /// Get/Set the Output Device Board Section Mode value
    /// </summary>
    
    [DataMember]
    
    public short OutputDeviceBoardSectionMode 
    { 
      get { return _OutputDeviceBoardSectionMode; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceBoardSectionMode, value, "OutputDeviceBoardSectionMode"))
        {
          _OutputDeviceBoardSectionMode = value; 
          RaisePropertyChanged("OutputDeviceBoardSectionMode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Board Section Mode Display value
    /// </summary>
    
    [DataMember]
    
    public string OutputDeviceBoardSectionModeDisplay 
    { 
      get { return _OutputDeviceBoardSectionModeDisplay; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceBoardSectionModeDisplay, value, "OutputDeviceBoardSectionModeDisplay"))
        {
          _OutputDeviceBoardSectionModeDisplay = value; 
          RaisePropertyChanged("OutputDeviceBoardSectionModeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Panel Model Type Code value
    /// </summary>
    
    [DataMember]
    
    public string OutputDevicePanelModelTypeCode 
    { 
      get { return _OutputDevicePanelModelTypeCode; }
      set 
      { 
        if(HasValueChanged(_OutputDevicePanelModelTypeCode, value, "OutputDevicePanelModelTypeCode"))
        {
          _OutputDevicePanelModelTypeCode = value; 
          RaisePropertyChanged("OutputDevicePanelModelTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Cpu Type Code value
    /// </summary>
    
    [DataMember]
    
    public string OutputDeviceCpuTypeCode 
    { 
      get { return _OutputDeviceCpuTypeCode; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceCpuTypeCode, value, "OutputDeviceCpuTypeCode"))
        {
          _OutputDeviceCpuTypeCode = value; 
          RaisePropertyChanged("OutputDeviceCpuTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Board Type Model value
    /// </summary>
    
    [DataMember]
    
    public string OutputDeviceBoardTypeModel 
    { 
      get { return _OutputDeviceBoardTypeModel; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceBoardTypeModel, value, "OutputDeviceBoardTypeModel"))
        {
          _OutputDeviceBoardTypeModel = value; 
          RaisePropertyChanged("OutputDeviceBoardTypeModel");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Board Type Type Code value
    /// </summary>
    
    [DataMember]
    
    public short OutputDeviceBoardTypeTypeCode 
    { 
      get { return _OutputDeviceBoardTypeTypeCode; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceBoardTypeTypeCode, value, "OutputDeviceBoardTypeTypeCode"))
        {
          _OutputDeviceBoardTypeTypeCode = value; 
          RaisePropertyChanged("OutputDeviceBoardTypeTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Output Device Board Type Display value
    /// </summary>
    
    [DataMember]
    
    public string OutputDeviceBoardTypeDisplay 
    { 
      get { return _OutputDeviceBoardTypeDisplay; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceBoardTypeDisplay, value, "OutputDeviceBoardTypeDisplay"))
        {
          _OutputDeviceBoardTypeDisplay = value; 
          RaisePropertyChanged("OutputDeviceBoardTypeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Output Mode Display value
    /// </summary>
    
    [DataMember]
    
    public string GalaxyOutputModeDisplay 
    { 
      get { return _GalaxyOutputModeDisplay; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputModeDisplay, value, "GalaxyOutputModeDisplay"))
        {
          _GalaxyOutputModeDisplay = value; 
          RaisePropertyChanged("GalaxyOutputModeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Output Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short GalaxyOutputModeCode 
    { 
      get { return _GalaxyOutputModeCode; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputModeCode, value, "GalaxyOutputModeCode"))
        {
          _GalaxyOutputModeCode = value; 
          RaisePropertyChanged("GalaxyOutputModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Source Relationship Display value
    /// </summary>
    
    [DataMember]
    
    public string InputSourceRelationshipDisplay 
    { 
      get { return _InputSourceRelationshipDisplay; }
      set 
      { 
        if(HasValueChanged(_InputSourceRelationshipDisplay, value, "InputSourceRelationshipDisplay"))
        {
          _InputSourceRelationshipDisplay = value; 
          RaisePropertyChanged("InputSourceRelationshipDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Source Relationship Code value
    /// </summary>
    
    [DataMember]
    
    public short InputSourceRelationshipCode 
    { 
      get { return _InputSourceRelationshipCode; }
      set 
      { 
        if(HasValueChanged(_InputSourceRelationshipCode, value, "InputSourceRelationshipCode"))
        {
          _InputSourceRelationshipCode = value; 
          RaisePropertyChanged("InputSourceRelationshipCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Timeout Duration value
    /// </summary>
    
    [DataMember]
    
    public int TimeoutDuration 
    { 
      get { return _TimeoutDuration; }
      set 
      { 
        if(HasValueChanged(_TimeoutDuration, value, "TimeoutDuration"))
        {
          _TimeoutDuration = value; 
          RaisePropertyChanged("TimeoutDuration");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Limit value
    /// </summary>
    
    [DataMember]
    
    public int Limit 
    { 
      get { return _Limit; }
      set 
      { 
        if(HasValueChanged(_Limit, value, "Limit"))
        {
          _Limit = value; 
          RaisePropertyChanged("Limit");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Invert Output value
    /// </summary>
    
    [DataMember]
    
    public bool InvertOutput 
    { 
      get { return _InvertOutput; }
      set 
      { 
        if(HasValueChanged(_InvertOutput, value, "InvertOutput"))
        {
          _InvertOutput = value; 
          RaisePropertyChanged("InvertOutput");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Schedule Display value
    /// </summary>
    
    [DataMember]
    
    public string ScheduleDisplay 
    { 
      get { return _ScheduleDisplay; }
      set 
      { 
        if(HasValueChanged(_ScheduleDisplay, value, "ScheduleDisplay"))
        {
          _ScheduleDisplay = value; 
          RaisePropertyChanged("ScheduleDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Schedule Number value
    /// </summary>
    
    [DataMember]
    
    public int ScheduleNumber 
    { 
      get { return _ScheduleNumber; }
      set 
      { 
        if(HasValueChanged(_ScheduleNumber, value, "ScheduleNumber"))
        {
          _ScheduleNumber = value; 
          RaisePropertyChanged("ScheduleNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Output Device Properties Last Updated value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset GalaxyOutputDevicePropertiesLastUpdated 
    { 
      get { return _GalaxyOutputDevicePropertiesLastUpdated; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputDevicePropertiesLastUpdated, value, "GalaxyOutputDevicePropertiesLastUpdated"))
        {
          _GalaxyOutputDevicePropertiesLastUpdated = value; 
          RaisePropertyChanged("GalaxyOutputDevicePropertiesLastUpdated");
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
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
    [DataMember]
    
    public int RETURNVALUE 
    { 
      get { return _RETURNVALUE; }
      set 
      { 
        if(HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
        {
          _RETURNVALUE = value; 
          RaisePropertyChanged("RETURNVALUE");
        }
      } 
    }
        

    #endregion
  }
}
