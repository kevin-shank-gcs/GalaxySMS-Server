using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a OutputDevicePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class OutputDevicePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _OutputDeviceUid = Guid.Empty;
    private Guid _BinaryResourceUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _SiteUid = Guid.Empty;
    private string _OutputName = string.Empty;
    private string _Location = string.Empty;
    private string _ServiceComment = string.Empty;
    private string _CriticalityComment = string.Empty;
    private string _Comment = string.Empty;
    private bool _EMailEventsEnabled = false;
    private bool _TransmitEventsEnabled = false;
    private bool _FileOutputEnabled = false;
    private bool _IsActive = false;
    private bool _IsTemplate = false;
    private string _InsertName = string.Empty;
    private string _RegionName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _CustomColumn = string.Empty;
    private string _UpdateName = string.Empty;
    private Guid _RegionUid = Guid.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _BoardNumber = 0;
    private short _SectionNumber = 0;
    private short _ModuleNumber = 0;
    private short _NodeNumber = 0;
    private Guid _ClusterTypeUid = Guid.Empty;
    private int _TypeCode = 0;
    private string _ClusterTypeCode = string.Empty;
    private Guid _GalaxyPanelModelUid = Guid.Empty;
    private string _GalaxyPanelTypeCode = string.Empty;
    private Guid _InterfaceBoardTypeUid = Guid.Empty;
    private short _InterfaceBoardTypeCode = 0;
    private string _InterfaceBoardModel = string.Empty;
    private Guid _InterfaceBoardSectionModeUid = Guid.Empty;
    private short _InterfaceBoardSectionModeCode = 0;
    private Guid _GalaxyHardwareModuleTypeUid = Guid.Empty;
    private short _ModuleTypeCode = 0;
    private bool _IsNodeActive = false;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _OutputDeviceUidOld = Guid.Empty;
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
    /// Get/Set the Binary Resource Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid BinaryResourceUid 
    { 
      get { return _BinaryResourceUid; }
      set 
      { 
        if(HasValueChanged(_BinaryResourceUid, value, "BinaryResourceUid"))
        {
          _BinaryResourceUid = value; 
          RaisePropertyChanged("BinaryResourceUid");
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
    /// Get/Set the Site Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid SiteUid 
    { 
      get { return _SiteUid; }
      set 
      { 
        if(HasValueChanged(_SiteUid, value, "SiteUid"))
        {
          _SiteUid = value; 
          RaisePropertyChanged("SiteUid");
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
    /// Get/Set the Location value
    /// </summary>
    
    [DataMember]
    
    public string Location 
    { 
      get { return _Location; }
      set 
      { 
        if(HasValueChanged(_Location, value, "Location"))
        {
          _Location = value; 
          RaisePropertyChanged("Location");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Service Comment value
    /// </summary>
    
    [DataMember]
    
    public string ServiceComment 
    { 
      get { return _ServiceComment; }
      set 
      { 
        if(HasValueChanged(_ServiceComment, value, "ServiceComment"))
        {
          _ServiceComment = value; 
          RaisePropertyChanged("ServiceComment");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Criticality Comment value
    /// </summary>
    
    [DataMember]
    
    public string CriticalityComment 
    { 
      get { return _CriticalityComment; }
      set 
      { 
        if(HasValueChanged(_CriticalityComment, value, "CriticalityComment"))
        {
          _CriticalityComment = value; 
          RaisePropertyChanged("CriticalityComment");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Comment value
    /// </summary>
    
    [DataMember]
    
    public string Comment 
    { 
      get { return _Comment; }
      set 
      { 
        if(HasValueChanged(_Comment, value, "Comment"))
        {
          _Comment = value; 
          RaisePropertyChanged("Comment");
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
    /// Get/Set the Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool IsActive 
    { 
      get { return _IsActive; }
      set 
      { 
        if(HasValueChanged(_IsActive, value, "IsActive"))
        {
          _IsActive = value; 
          RaisePropertyChanged("IsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Template value
    /// </summary>
    
    [DataMember]
    
    public bool IsTemplate 
    { 
      get { return _IsTemplate; }
      set 
      { 
        if(HasValueChanged(_IsTemplate, value, "IsTemplate"))
        {
          _IsTemplate = value; 
          RaisePropertyChanged("IsTemplate");
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
    /// Get/Set the Region Name value
    /// </summary>
    
    [DataMember]
    
    public string RegionName 
    { 
      get { return _RegionName; }
      set 
      { 
        if(HasValueChanged(_RegionName, value, "RegionName"))
        {
          _RegionName = value; 
          RaisePropertyChanged("RegionName");
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
    /// Get/Set the Custom Column value
    /// </summary>
    
    [DataMember]
    
    public string CustomColumn 
    { 
      get { return _CustomColumn; }
      set 
      { 
        if(HasValueChanged(_CustomColumn, value, "SiteName"))
        {
          _CustomColumn = value; 
          RaisePropertyChanged("CustomColumn");
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
    /// Get/Set the Region Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RegionUid 
    { 
      get { return _RegionUid; }
      set 
      { 
        if(HasValueChanged(_RegionUid, value, "RegionUid"))
        {
          _RegionUid = value; 
          RaisePropertyChanged("RegionUid");
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
    /// Get/Set the Cluster Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ClusterTypeUid 
    { 
      get { return _ClusterTypeUid; }
      set 
      { 
        if(HasValueChanged(_ClusterTypeUid, value, "ClusterTypeUid"))
        {
          _ClusterTypeUid = value; 
          RaisePropertyChanged("ClusterTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Type Code value
    /// </summary>
    
    [DataMember]
    
    public int TypeCode 
    { 
      get { return _TypeCode; }
      set 
      { 
        if(HasValueChanged(_TypeCode, value, "TypeCode"))
        {
          _TypeCode = value; 
          RaisePropertyChanged("TypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Type Code value
    /// </summary>
    
    [DataMember]
    
    public string ClusterTypeCode 
    { 
      get { return _ClusterTypeCode; }
      set 
      { 
        if(HasValueChanged(_ClusterTypeCode, value, "ClusterTypeCode"))
        {
          _ClusterTypeCode = value; 
          RaisePropertyChanged("ClusterTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Model Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelModelUid 
    { 
      get { return _GalaxyPanelModelUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelModelUid, value, "GalaxyPanelModelUid"))
        {
          _GalaxyPanelModelUid = value; 
          RaisePropertyChanged("GalaxyPanelModelUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Type Code value
    /// </summary>
    
    [DataMember]
    
    public string GalaxyPanelTypeCode 
    { 
      get { return _GalaxyPanelTypeCode; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelTypeCode, value, "GalaxyPanelTypeCode"))
        {
          _GalaxyPanelTypeCode = value; 
          RaisePropertyChanged("GalaxyPanelTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InterfaceBoardTypeUid 
    { 
      get { return _InterfaceBoardTypeUid; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardTypeUid, value, "InterfaceBoardTypeUid"))
        {
          _InterfaceBoardTypeUid = value; 
          RaisePropertyChanged("InterfaceBoardTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Type Code value
    /// </summary>
    
    [DataMember]
    
    public short InterfaceBoardTypeCode 
    { 
      get { return _InterfaceBoardTypeCode; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardTypeCode, value, "InterfaceBoardTypeCode"))
        {
          _InterfaceBoardTypeCode = value; 
          RaisePropertyChanged("InterfaceBoardTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Model value
    /// </summary>
    
    [DataMember]
    
    public string InterfaceBoardModel 
    { 
      get { return _InterfaceBoardModel; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardModel, value, "InterfaceBoardModel"))
        {
          _InterfaceBoardModel = value; 
          RaisePropertyChanged("InterfaceBoardModel");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Section Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InterfaceBoardSectionModeUid 
    { 
      get { return _InterfaceBoardSectionModeUid; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardSectionModeUid, value, "InterfaceBoardSectionModeUid"))
        {
          _InterfaceBoardSectionModeUid = value; 
          RaisePropertyChanged("InterfaceBoardSectionModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Section Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short InterfaceBoardSectionModeCode 
    { 
      get { return _InterfaceBoardSectionModeCode; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardSectionModeCode, value, "InterfaceBoardSectionModeCode"))
        {
          _InterfaceBoardSectionModeCode = value; 
          RaisePropertyChanged("InterfaceBoardSectionModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Hardware Module Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyHardwareModuleTypeUid 
    { 
      get { return _GalaxyHardwareModuleTypeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyHardwareModuleTypeUid, value, "GalaxyHardwareModuleTypeUid"))
        {
          _GalaxyHardwareModuleTypeUid = value; 
          RaisePropertyChanged("GalaxyHardwareModuleTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Module Type Code value
    /// </summary>
    
    [DataMember]
    
    public short ModuleTypeCode 
    { 
      get { return _ModuleTypeCode; }
      set 
      { 
        if(HasValueChanged(_ModuleTypeCode, value, "ModuleTypeCode"))
        {
          _ModuleTypeCode = value; 
          RaisePropertyChanged("ModuleTypeCode");
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
    /// Get/Set the Output Device UidOld value
    /// </summary>
    
    public Guid OutputDeviceUidOld
    { 
      get { return _OutputDeviceUidOld; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceUidOld, value, "OutputDeviceUid"))
        {
          _OutputDeviceUidOld = value; 
          RaisePropertyChanged("OutputDeviceUidOld");
        }
      } 
    }
    #endregion
  }
}
