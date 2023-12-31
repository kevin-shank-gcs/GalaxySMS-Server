using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a RoleClusterPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class RoleClusterPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _RoleClusterUid = Guid.Empty;
    private Guid _RoleId = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private bool _IncludeAllAccessPortals = false;
    private string _ClusterName = string.Empty;
    private bool _IncludeAllInputOutputGroups = false;
    private bool _IncludeAllInputDevices = false;
    private bool _IncludeAllOutputDevices = false;
    private int _ClusterGroupId = 0;
    private int _ClusterNumber = 0;
    private Guid _SiteUid = Guid.Empty;
    private Guid _RoleClusterUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Role Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleClusterUid 
    { 
      get { return _RoleClusterUid; }
      set 
      { 
        if(HasValueChanged(_RoleClusterUid, value, "RoleClusterUid"))
        {
          _RoleClusterUid = value; 
          RaisePropertyChanged("RoleClusterUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Role Id value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleId 
    { 
      get { return _RoleId; }
      set 
      { 
        if(HasValueChanged(_RoleId, value, "RoleId"))
        {
          _RoleId = value; 
          RaisePropertyChanged("RoleId");
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
    /// Get/Set the Include All Access Portals value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllAccessPortals 
    { 
      get { return _IncludeAllAccessPortals; }
      set 
      { 
        if(HasValueChanged(_IncludeAllAccessPortals, value, "IncludeAllAccessPortals"))
        {
          _IncludeAllAccessPortals = value; 
          RaisePropertyChanged("IncludeAllAccessPortals");
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
    /// Get/Set the Include All Input Output Groups value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllInputOutputGroups 
    { 
      get { return _IncludeAllInputOutputGroups; }
      set 
      { 
        if(HasValueChanged(_IncludeAllInputOutputGroups, value, "IncludeAllInputOutputGroups"))
        {
          _IncludeAllInputOutputGroups = value; 
          RaisePropertyChanged("IncludeAllInputOutputGroups");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Input Devices value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllInputDevices 
    { 
      get { return _IncludeAllInputDevices; }
      set 
      { 
        if(HasValueChanged(_IncludeAllInputDevices, value, "IncludeAllInputDevices"))
        {
          _IncludeAllInputDevices = value; 
          RaisePropertyChanged("IncludeAllInputDevices");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Include All Output Devices value
    /// </summary>
    
    [DataMember]
    
    public bool IncludeAllOutputDevices 
    { 
      get { return _IncludeAllOutputDevices; }
      set 
      { 
        if(HasValueChanged(_IncludeAllOutputDevices, value, "IncludeAllOutputDevices"))
        {
          _IncludeAllOutputDevices = value; 
          RaisePropertyChanged("IncludeAllOutputDevices");
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
    /// Get/Set the Role Cluster UidOld value
    /// </summary>
    
    public Guid RoleClusterUidOld
    { 
      get { return _RoleClusterUidOld; }
      set 
      { 
        if(HasValueChanged(_RoleClusterUidOld, value, "RoleClusterUid"))
        {
          _RoleClusterUidOld = value; 
          RaisePropertyChanged("RoleClusterUidOld");
        }
      } 
    }
    #endregion
  }
}
