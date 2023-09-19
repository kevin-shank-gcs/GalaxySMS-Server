using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the AcknowledgedAlarms_ByDeviceUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AcknowledgedAlarms_ByDeviceUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ActivityEventUid = Guid.Empty;
    private int _clusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _CpuId = 0;
    private int _BoardNumber = 0;
    private int _SectionNumber = 0;
    private int _ModuleNumber = 0;
    private int _NodeNumber = 0;
    private int _CpuModel = 0;
    private DateTimeOffset _DateTime_x = DateTimeOffset.Now;
    private int _BufferIndex = 0;
    private string _PanelActivityType = string.Empty;
    private int _InputOutputGroupNumber = 0;
    private int _MultiFactorMode = 0;
    private string _DeviceDescription = string.Empty;
    private string _EventDescription = string.Empty;
    private Guid _DeviceEntityId = Guid.Empty;
    private Guid _DeviceUid = Guid.Empty;
    private Guid _CpuUid = Guid.Empty;
    private string _ClusterName = string.Empty;
    private int _IsAlarmEvent = 0;
    private int _AlarmPriority = 0;
    private string _Instructions = string.Empty;
    private Guid _InstructionsNoteUid = Guid.Empty;
    private Guid _AudioBinaryResourceUid = Guid.Empty;
    private int _RawData = 0;
    private int _Color = 0;
    private Guid _PersonUid = Guid.Empty;
    private Guid _CredentialUid = Guid.Empty;
    private string _PersonDescription = string.Empty;
    private string _CredentialDescription = string.Empty;
    private bool _Trace = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Activity Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ActivityEventUid 
    { 
      get { return _ActivityEventUid; }
      set 
      { 
        if(HasValueChanged(_ActivityEventUid, value, "ActivityEventUid"))
        {
          _ActivityEventUid = value; 
          RaisePropertyChanged("ActivityEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Account Code value
    /// </summary>
    
    [DataMember]
    
    public int ClusterGroupId 
    { 
      get { return _clusterGroupId; }
      set 
      { 
        if(HasValueChanged(_clusterGroupId, value, "ClusterGroupId"))
        {
          _clusterGroupId = value; 
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
    /// Get/Set the Cpu Id value
    /// </summary>
    
    [DataMember]
    
    public short CpuId 
    { 
      get { return _CpuId; }
      set 
      { 
        if(HasValueChanged(_CpuId, value, "CpuId"))
        {
          _CpuId = value; 
          RaisePropertyChanged("CpuId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Board Number value
    /// </summary>
    
    [DataMember]
    
    public int BoardNumber 
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
    
    public int SectionNumber 
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
    
    public int ModuleNumber 
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
    
    public int NodeNumber 
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
    /// Get/Set the Cpu Model value
    /// </summary>
    
    [DataMember]
    
    public int CpuModel 
    { 
      get { return _CpuModel; }
      set 
      { 
        if(HasValueChanged(_CpuModel, value, "CpuModel"))
        {
          _CpuModel = value; 
          RaisePropertyChanged("CpuModel");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset DateTime_x 
    { 
      get { return _DateTime_x; }
      set 
      { 
        if(HasValueChanged(_DateTime_x, value, "DateTimeOffset"))
        {
          _DateTime_x = value; 
          RaisePropertyChanged("DateTime_x");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Buffer Index value
    /// </summary>
    
    [DataMember]
    
    public int BufferIndex 
    { 
      get { return _BufferIndex; }
      set 
      { 
        if(HasValueChanged(_BufferIndex, value, "BufferIndex"))
        {
          _BufferIndex = value; 
          RaisePropertyChanged("BufferIndex");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Activity Type value
    /// </summary>
    
    [DataMember]
    
    public string PanelActivityType 
    { 
      get { return _PanelActivityType; }
      set 
      { 
        if(HasValueChanged(_PanelActivityType, value, "PanelActivityType"))
        {
          _PanelActivityType = value; 
          RaisePropertyChanged("PanelActivityType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group Number value
    /// </summary>
    
    [DataMember]
    
    public int InputOutputGroupNumber 
    { 
      get { return _InputOutputGroupNumber; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroupNumber, value, "InputOutputGroupNumber"))
        {
          _InputOutputGroupNumber = value; 
          RaisePropertyChanged("InputOutputGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Multi Factor Mode value
    /// </summary>
    
    [DataMember]
    
    public int MultiFactorMode 
    { 
      get { return _MultiFactorMode; }
      set 
      { 
        if(HasValueChanged(_MultiFactorMode, value, "MultiFactorMode"))
        {
          _MultiFactorMode = value; 
          RaisePropertyChanged("MultiFactorMode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Description value
    /// </summary>
    
    [DataMember]
    
    public string DeviceDescription 
    { 
      get { return _DeviceDescription; }
      set 
      { 
        if(HasValueChanged(_DeviceDescription, value, "DeviceDescription"))
        {
          _DeviceDescription = value; 
          RaisePropertyChanged("DeviceDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Event Description value
    /// </summary>
    
    [DataMember]
    
    public string EventDescription 
    { 
      get { return _EventDescription; }
      set 
      { 
        if(HasValueChanged(_EventDescription, value, "EventDescription"))
        {
          _EventDescription = value; 
          RaisePropertyChanged("EventDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Entity Id value
    /// </summary>
    
    [DataMember]
    
    public Guid DeviceEntityId 
    { 
      get { return _DeviceEntityId; }
      set 
      { 
        if(HasValueChanged(_DeviceEntityId, value, "DeviceEntityId"))
        {
          _DeviceEntityId = value; 
          RaisePropertyChanged("DeviceEntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DeviceUid 
    { 
      get { return _DeviceUid; }
      set 
      { 
        if(HasValueChanged(_DeviceUid, value, "DeviceUid"))
        {
          _DeviceUid = value; 
          RaisePropertyChanged("DeviceUid");
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
    /// Get/Set the Cluster Name value
    /// </summary>
    
    [DataMember]
    
    public string ClusterName 
    { 
      get { return _ClusterName; }
      set 
      { 
        if(HasValueChanged(_ClusterName, value, "ClusterName"))
        {
          _ClusterName = value; 
          RaisePropertyChanged("ClusterName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Alarm Event value
    /// </summary>
    
    [DataMember]
    
    public int IsAlarmEvent 
    { 
      get { return _IsAlarmEvent; }
      set 
      { 
        if(HasValueChanged(_IsAlarmEvent, value, "IsAlarmEvent"))
        {
          _IsAlarmEvent = value; 
          RaisePropertyChanged("IsAlarmEvent");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Alarm Priority value
    /// </summary>
    
    [DataMember]
    
    public int AlarmPriority 
    { 
      get { return _AlarmPriority; }
      set 
      { 
        if(HasValueChanged(_AlarmPriority, value, "AlarmPriority"))
        {
          _AlarmPriority = value; 
          RaisePropertyChanged("AlarmPriority");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Instructions value
    /// </summary>
    
    [DataMember]
    
    public string Instructions 
    { 
      get { return _Instructions; }
      set 
      { 
        if(HasValueChanged(_Instructions, value, "Instructions"))
        {
          _Instructions = value; 
          RaisePropertyChanged("Instructions");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Instructions Note Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InstructionsNoteUid 
    { 
      get { return _InstructionsNoteUid; }
      set 
      { 
        if(HasValueChanged(_InstructionsNoteUid, value, "InstructionsNoteUid"))
        {
          _InstructionsNoteUid = value; 
          RaisePropertyChanged("InstructionsNoteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Audio Binary Resource Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AudioBinaryResourceUid 
    { 
      get { return _AudioBinaryResourceUid; }
      set 
      { 
        if(HasValueChanged(_AudioBinaryResourceUid, value, "AudioBinaryResourceUid"))
        {
          _AudioBinaryResourceUid = value; 
          RaisePropertyChanged("AudioBinaryResourceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Raw Data value
    /// </summary>
    
    [DataMember]
    
    public int RawData 
    { 
      get { return _RawData; }
      set 
      { 
        if(HasValueChanged(_RawData, value, "RawData"))
        {
          _RawData = value; 
          RaisePropertyChanged("RawData");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Color value
    /// </summary>
    
    [DataMember]
    
    public int Color 
    { 
      get { return _Color; }
      set 
      { 
        if(HasValueChanged(_Color, value, "Color"))
        {
          _Color = value; 
          RaisePropertyChanged("Color");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonUid 
    { 
      get { return _PersonUid; }
      set 
      { 
        if(HasValueChanged(_PersonUid, value, "PersonUid"))
        {
          _PersonUid = value; 
          RaisePropertyChanged("PersonUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialUid 
    { 
      get { return _CredentialUid; }
      set 
      { 
        if(HasValueChanged(_CredentialUid, value, "CredentialUid"))
        {
          _CredentialUid = value; 
          RaisePropertyChanged("CredentialUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Description value
    /// </summary>
    
    [DataMember]
    
    public string PersonDescription 
    { 
      get { return _PersonDescription; }
      set 
      { 
        if(HasValueChanged(_PersonDescription, value, "PersonDescription"))
        {
          _PersonDescription = value; 
          RaisePropertyChanged("PersonDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Description value
    /// </summary>
    
    [DataMember]
    
    public string CredentialDescription 
    { 
      get { return _CredentialDescription; }
      set 
      { 
        if(HasValueChanged(_CredentialDescription, value, "CredentialDescription"))
        {
          _CredentialDescription = value; 
          RaisePropertyChanged("CredentialDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Trace value
    /// </summary>
    
    [DataMember]
    
    public bool Trace 
    { 
      get { return _Trace; }
      set 
      { 
        if(HasValueChanged(_Trace, value, "Trace"))
        {
          _Trace = value; 
          RaisePropertyChanged("Trace");
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
