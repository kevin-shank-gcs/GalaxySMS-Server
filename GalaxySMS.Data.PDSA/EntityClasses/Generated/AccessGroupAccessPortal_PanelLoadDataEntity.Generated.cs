using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessGroupAccessPortal_PanelLoadDataPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessGroupAccessPortal_PanelLoadDataPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessGroupAccessPortalUid = Guid.Empty;
    private string _AccessGroupName = string.Empty;
    private string _TimeScheduleName = string.Empty;
    private string _AccessPortalName = string.Empty;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private short _BoardNumber = 0;
    private short _SectionNumber = 0;
    private short _ModuleNumber = 0;
    private short _NodeNumber = 0;
    private int _AccessGroupNumber = 0;
    private int? _PanelScheduleNumber = null;
    private DateTime? _ActivationDate = null;
    private DateTime? _ExpirationDate = null;
    private bool _IsEnabled = false;
    private Guid _AccessPortalUid = Guid.Empty;
    private Guid? _TimeScheduleUid = null;
    private Guid _AccessGroupUid = Guid.Empty;
    private short _AccessPortalBoardTypeTypeCode = 0;
    private DateTimeOffset _CurrentTimeForCluster = DateTimeOffset.Now;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private int _CpuNumber = 0;
    private string _CpuUid = string.Empty;
    private string _AccessGroupLoadToCpuUid = string.Empty;
    private string _ServerAddress = string.Empty;
    private string _DefaultTimeScheduleName = string.Empty;
    private int _DefaultTimeScheduleNumber = 0;
    private int _IsConnected = 0;
    private bool _IsNodeActive = false;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Access Group Access Portal Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessGroupAccessPortalUid 
    { 
      get { return _AccessGroupAccessPortalUid; }
      set 
      { 
        if(HasValueChanged(_AccessGroupAccessPortalUid, value, "AccessGroupAccessPortalUid"))
        {
          _AccessGroupAccessPortalUid = value; 
          RaisePropertyChanged("AccessGroupAccessPortalUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group Name value
    /// </summary>
    
    [DataMember]
    
    public string AccessGroupName 
    { 
      get { return _AccessGroupName; }
      set 
      { 
        if(HasValueChanged(_AccessGroupName, value, "AccessGroupName"))
        {
          _AccessGroupName = value; 
          RaisePropertyChanged("AccessGroupName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Schedule Name value
    /// </summary>
    
    [DataMember]
    
    public string TimeScheduleName 
    { 
      get { return _TimeScheduleName; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleName, value, "TimeScheduleName"))
        {
          _TimeScheduleName = value; 
          RaisePropertyChanged("TimeScheduleName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Name value
    /// </summary>
    
    [DataMember]
    
    public string AccessPortalName 
    { 
      get { return _AccessPortalName; }
      set 
      { 
        if(HasValueChanged(_AccessPortalName, value, "AccessPortalName"))
        {
          _AccessPortalName = value; 
          RaisePropertyChanged("AccessPortalName");
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
    /// Get/Set the Access Group Number value
    /// </summary>
    
    [DataMember]
    
    public int AccessGroupNumber 
    { 
      get { return _AccessGroupNumber; }
      set 
      { 
        if(HasValueChanged(_AccessGroupNumber, value, "AccessGroupNumber"))
        {
          _AccessGroupNumber = value; 
          RaisePropertyChanged("AccessGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Panel Schedule Number value
    /// </summary>
    
    [DataMember]
    
    public int? PanelScheduleNumber 
    { 
      get { return _PanelScheduleNumber; }
      set 
      { 
        if(HasValueChanged(_PanelScheduleNumber, value, "PanelScheduleNumber"))
        {
          _PanelScheduleNumber = value; 
          RaisePropertyChanged("PanelScheduleNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activation Date value
    /// </summary>
    
    [DataMember]
    
    public DateTime? ActivationDate 
    { 
      get { return _ActivationDate; }
      set 
      { 
        if(HasValueChanged(_ActivationDate, value, "ActivationDate"))
        {
          _ActivationDate = value; 
          RaisePropertyChanged("ActivationDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Expiration Date value
    /// </summary>
    
    [DataMember]
    
    public DateTime? ExpirationDate 
    { 
      get { return _ExpirationDate; }
      set 
      { 
        if(HasValueChanged(_ExpirationDate, value, "ExpirationDate"))
        {
          _ExpirationDate = value; 
          RaisePropertyChanged("ExpirationDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Enabled value
    /// </summary>
    
    [DataMember]
    
    public bool IsEnabled 
    { 
      get { return _IsEnabled; }
      set 
      { 
        if(HasValueChanged(_IsEnabled, value, "IsEnabled"))
        {
          _IsEnabled = value; 
          RaisePropertyChanged("IsEnabled");
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
    /// Get/Set the Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid? TimeScheduleUid 
    { 
      get { return _TimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleUid, value, "TimeScheduleUid"))
        {
          _TimeScheduleUid = value; 
          RaisePropertyChanged("TimeScheduleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessGroupUid 
    { 
      get { return _AccessGroupUid; }
      set 
      { 
        if(HasValueChanged(_AccessGroupUid, value, "AccessGroupUid"))
        {
          _AccessGroupUid = value; 
          RaisePropertyChanged("AccessGroupUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Board Type Type Code value
    /// </summary>
    
    [DataMember]
    
    public short AccessPortalBoardTypeTypeCode 
    { 
      get { return _AccessPortalBoardTypeTypeCode; }
      set 
      { 
        if(HasValueChanged(_AccessPortalBoardTypeTypeCode, value, "AccessPortalBoardTypeTypeCode"))
        {
          _AccessPortalBoardTypeTypeCode = value; 
          RaisePropertyChanged("AccessPortalBoardTypeTypeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Current Time For Cluster value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset CurrentTimeForCluster 
    { 
      get { return _CurrentTimeForCluster; }
      set 
      { 
        if(HasValueChanged(_CurrentTimeForCluster, value, "CurrentTimeForCluster"))
        {
          _CurrentTimeForCluster = value; 
          RaisePropertyChanged("CurrentTimeForCluster");
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
    
    public string CpuUid 
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
    /// Get/Set the Access Group Load To Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public string AccessGroupLoadToCpuUid 
    { 
      get { return _AccessGroupLoadToCpuUid; }
      set 
      { 
        if(HasValueChanged(_AccessGroupLoadToCpuUid, value, "AccessGroupLoadToCpuUid"))
        {
          _AccessGroupLoadToCpuUid = value; 
          RaisePropertyChanged("AccessGroupLoadToCpuUid");
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
    /// Get/Set the Default Time Schedule Name value
    /// </summary>
    
    [DataMember]
    
    public string DefaultTimeScheduleName 
    { 
      get { return _DefaultTimeScheduleName; }
      set 
      { 
        if(HasValueChanged(_DefaultTimeScheduleName, value, "DefaultTimeScheduleName"))
        {
          _DefaultTimeScheduleName = value; 
          RaisePropertyChanged("DefaultTimeScheduleName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Default Time Schedule Number value
    /// </summary>
    
    [DataMember]
    
    public int DefaultTimeScheduleNumber 
    { 
      get { return _DefaultTimeScheduleNumber; }
      set 
      { 
        if(HasValueChanged(_DefaultTimeScheduleNumber, value, "DefaultTimeScheduleNumber"))
        {
          _DefaultTimeScheduleNumber = value; 
          RaisePropertyChanged("DefaultTimeScheduleNumber");
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
        

    #endregion
  }
}
