using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a ActivityEventPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class ActivityEventPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ActivityEventUid = Guid.Empty;
    private DateTimeOffset _ActivityDateTime = DateTimeOffset.Now;
    private DateTimeOffset _ActivityDateTimeUTC = DateTimeOffset.Now;
    private string _EventTypeMessage = string.Empty;
    private int _ForeColor = 0;
    private string _ForeColorHex = string.Empty;
    private string _DeviceName = string.Empty;
    private string _SiteName = string.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _DeviceUid = Guid.Empty;
    private Guid _EventTypeUid = Guid.Empty;
    private string _DeviceType = string.Empty;
    private string _LastName = string.Empty;
    private string _FirstName = string.Empty;
    private bool _IsTraced = false;
    private string _CredentialDescription = string.Empty;
    private Guid? _PersonUid = null;
    private Guid? _CredentialUid = null;
    private Guid? _ClusterUid = null;
    private int? _ClusterNumber = null;
    private string _ClusterName = string.Empty;
    private int? _ClusterGroupId = null;
    private int? _PanelNumber = null;
    private string _InputOutputGroupName = string.Empty;
    private int? _InputOutputGroupNumber = null;
    private short? _CpuNumber = null;
    private short? _BoardNumber = null;
    private short? _SectionNumber = null;
    private short? _ModuleNumber = null;
    private short? _NodeNumber = null;
    private int? _AlarmPriority = null;
    private bool? _ResponseRequired = null;
    private string _EntityName = string.Empty;
    private string _EntityType = string.Empty;
    private int _BufferIndex = 0;
    private byte[] _CredentialBytes = null;
    private Guid _ActivityEventUidOld = Guid.Empty;
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
    /// Get/Set the Activity Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset ActivityDateTime 
    { 
      get { return _ActivityDateTime; }
      set 
      { 
        if(HasValueChanged(_ActivityDateTime, value, "ActivityDateTime"))
        {
          _ActivityDateTime = value; 
          RaisePropertyChanged("ActivityDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activity Date Time UTC value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset ActivityDateTimeUTC 
    { 
      get { return _ActivityDateTimeUTC; }
      set 
      { 
        if(HasValueChanged(_ActivityDateTimeUTC, value, "ActivityDateTimeUTC"))
        {
          _ActivityDateTimeUTC = value; 
          RaisePropertyChanged("ActivityDateTimeUTC");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Event Type Message value
    /// </summary>
    
    [DataMember]
    
    public string EventTypeMessage 
    { 
      get { return _EventTypeMessage; }
      set 
      { 
        if(HasValueChanged(_EventTypeMessage, value, "EventTypeMessage"))
        {
          _EventTypeMessage = value; 
          RaisePropertyChanged("EventTypeMessage");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Fore Color value
    /// </summary>
    
    [DataMember]
    
    public int ForeColor 
    { 
      get { return _ForeColor; }
      set 
      { 
        if(HasValueChanged(_ForeColor, value, "ForeColor"))
        {
          _ForeColor = value; 
          RaisePropertyChanged("ForeColor");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Fore Color Hex value
    /// </summary>
    
    [DataMember]
    
    public string ForeColorHex 
    { 
      get { return _ForeColorHex; }
      set 
      { 
        if(HasValueChanged(_ForeColorHex, value, "ForeColorHex"))
        {
          _ForeColorHex = value; 
          RaisePropertyChanged("ForeColorHex");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Name value
    /// </summary>
    
    [DataMember]
    
    public string DeviceName 
    { 
      get { return _DeviceName; }
      set 
      { 
        if(HasValueChanged(_DeviceName, value, "DeviceName"))
        {
          _DeviceName = value; 
          RaisePropertyChanged("DeviceName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Site Name value
    /// </summary>
    
    [DataMember]
    
    public string SiteName 
    { 
      get { return _SiteName; }
      set 
      { 
        if(HasValueChanged(_SiteName, value, "SiteName"))
        {
          _SiteName = value; 
          RaisePropertyChanged("SiteName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Id value
    /// </summary>
    
    [DataMember]
    
    public Guid EntityId 
    { 
      get { return _EntityId; }
      set 
      { 
        if(HasValueChanged(_EntityId, value, "EntityId"))
        {
          _EntityId = value; 
          RaisePropertyChanged("EntityId");
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
    /// Get/Set the Event Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid EventTypeUid 
    { 
      get { return _EventTypeUid; }
      set 
      { 
        if(HasValueChanged(_EventTypeUid, value, "EventTypeUid"))
        {
          _EventTypeUid = value; 
          RaisePropertyChanged("EventTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Type value
    /// </summary>
    
    [DataMember]
    
    public string DeviceType 
    { 
      get { return _DeviceType; }
      set 
      { 
        if(HasValueChanged(_DeviceType, value, "DeviceType"))
        {
          _DeviceType = value; 
          RaisePropertyChanged("DeviceType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Last Name value
    /// </summary>
    
    [DataMember]
    
    public string LastName 
    { 
      get { return _LastName; }
      set 
      { 
        if(HasValueChanged(_LastName, value, "LastName"))
        {
          _LastName = value; 
          RaisePropertyChanged("LastName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the First Name value
    /// </summary>
    
    [DataMember]
    
    public string FirstName 
    { 
      get { return _FirstName; }
      set 
      { 
        if(HasValueChanged(_FirstName, value, "FirstName"))
        {
          _FirstName = value; 
          RaisePropertyChanged("FirstName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Traced value
    /// </summary>
    
    [DataMember]
    
    public bool IsTraced 
    { 
      get { return _IsTraced; }
      set 
      { 
        if(HasValueChanged(_IsTraced, value, "IsTraced"))
        {
          _IsTraced = value; 
          RaisePropertyChanged("IsTraced");
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
    /// Get/Set the Person Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid? PersonUid 
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
    
    public Guid? CredentialUid 
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
    /// Get/Set the Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid? ClusterUid 
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
    /// Get/Set the Cluster Number value
    /// </summary>
    
    [DataMember]
    
    public int? ClusterNumber 
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
    /// Get/Set the Cluster Group Id value
    /// </summary>
    
    [DataMember]
    
    public int? ClusterGroupId 
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
    /// Get/Set the Panel Number value
    /// </summary>
    
    [DataMember]
    
    public int? PanelNumber 
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
    /// Get/Set the Input Output Group Name value
    /// </summary>
    
    [DataMember]
    
    public string InputOutputGroupName 
    { 
      get { return _InputOutputGroupName; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroupName, value, "InputOutputGroupName"))
        {
          _InputOutputGroupName = value; 
          RaisePropertyChanged("InputOutputGroupName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group Number value
    /// </summary>
    
    [DataMember]
    
    public int? InputOutputGroupNumber 
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
    /// Get/Set the Cpu Number value
    /// </summary>
    
    [DataMember]
    
    public short? CpuNumber 
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
    /// Get/Set the Board Number value
    /// </summary>
    
    [DataMember]
    
    public short? BoardNumber 
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
    
    public short? SectionNumber 
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
    
    public short? ModuleNumber 
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
    
    public short? NodeNumber 
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
    /// Get/Set the Alarm Priority value
    /// </summary>
    
    [DataMember]
    
    public int? AlarmPriority 
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
    /// Get/Set the Response Required value
    /// </summary>
    
    [DataMember]
    
    public bool? ResponseRequired 
    { 
      get { return _ResponseRequired; }
      set 
      { 
        if(HasValueChanged(_ResponseRequired, value, "ResponseRequired"))
        {
          _ResponseRequired = value; 
          RaisePropertyChanged("ResponseRequired");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Name value
    /// </summary>
    
    [DataMember]
    
    public string EntityName 
    { 
      get { return _EntityName; }
      set 
      { 
        if(HasValueChanged(_EntityName, value, "EntityName"))
        {
          _EntityName = value; 
          RaisePropertyChanged("EntityName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Type value
    /// </summary>
    
    [DataMember]
    
    public string EntityType 
    { 
      get { return _EntityType; }
      set 
      { 
        if(HasValueChanged(_EntityType, value, "EntityType"))
        {
          _EntityType = value; 
          RaisePropertyChanged("EntityType");
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
    /// Get/Set the Credential Bytes value
    /// </summary>
    
    [DataMember]
    
    public byte[] CredentialBytes 
    { 
      get { return _CredentialBytes; }
      set 
      { 
        if(HasValueChanged(_CredentialBytes, value, "CredentialBytes"))
        {
          _CredentialBytes = value; 
          RaisePropertyChanged("CredentialBytes");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Activity Event UidOld value
    /// </summary>
    
    public Guid ActivityEventUidOld
    { 
      get { return _ActivityEventUidOld; }
      set 
      { 
        if(HasValueChanged(_ActivityEventUidOld, value, "ActivityEventUid"))
        {
          _ActivityEventUidOld = value; 
          RaisePropertyChanged("ActivityEventUidOld");
        }
      } 
    }
    #endregion
  }
}
