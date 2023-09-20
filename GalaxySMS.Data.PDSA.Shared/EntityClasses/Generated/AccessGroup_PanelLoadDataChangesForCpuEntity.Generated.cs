using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a AccessGroup_PanelLoadDataChangesForCpuPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class AccessGroup_PanelLoadDataChangesForCpuPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _AccessGroupUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private string _AccessGroupName = string.Empty;
    private int _AccessGroupNumber = 0;
    private DateTimeOffset _ActivationDate = DateTimeOffset.MinValue;
    private DateTimeOffset _ExpirationDate = DateTimeOffset.MaxValue;
    private bool _IsEnabled = false;
    private Guid _CrisisModeAccessGroupUid = Guid.Empty;
    private string _CrisisModeAccessGroupName = string.Empty;
    private int _CrisisModeAccessGroupNumber = 0;
    private DateTimeOffset _CurrentTimeForCluster = DateTimeOffset.Now;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private short _CpuNumber = 0;
    private Guid _CpuUid = Guid.Empty;
    private Guid _AccessGroupLoadToCpuUid = Guid.Empty;
    private string _ServerAddress = string.Empty;
    private bool _IsConnected = false;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Activation Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset ActivationDate 
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
    
    public DateTimeOffset ExpirationDate 
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
    /// Get/Set the Crisis Mode Access Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CrisisModeAccessGroupUid 
    { 
      get { return _CrisisModeAccessGroupUid; }
      set 
      { 
        if(HasValueChanged(_CrisisModeAccessGroupUid, value, "CrisisModeAccessGroupUid"))
        {
          _CrisisModeAccessGroupUid = value; 
          RaisePropertyChanged("CrisisModeAccessGroupUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Crisis Mode Access Group Name value
    /// </summary>
    
    [DataMember]
    
    public string CrisisModeAccessGroupName 
    { 
      get { return _CrisisModeAccessGroupName; }
      set 
      { 
        if(HasValueChanged(_CrisisModeAccessGroupName, value, "CrisisModeAccessGroupName"))
        {
          _CrisisModeAccessGroupName = value; 
          RaisePropertyChanged("CrisisModeAccessGroupName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Crisis Mode Access Group Number value
    /// </summary>
    
    [DataMember]
    
    public int CrisisModeAccessGroupNumber 
    { 
      get { return _CrisisModeAccessGroupNumber; }
      set 
      { 
        if(HasValueChanged(_CrisisModeAccessGroupNumber, value, "CrisisModeAccessGroupNumber"))
        {
          _CrisisModeAccessGroupNumber = value; 
          RaisePropertyChanged("CrisisModeAccessGroupNumber");
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
    
    public short CpuNumber 
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
    /// Get/Set the Access Group Load To Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessGroupLoadToCpuUid 
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
    /// Get/Set the Is Connected value
    /// </summary>
    
    [DataMember]
    
    public bool IsConnected 
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
