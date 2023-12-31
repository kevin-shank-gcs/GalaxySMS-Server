using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyInterfaceBoardPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyInterfaceBoardPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyInterfaceBoardUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _InterfaceBoardTypeUid = Guid.Empty;
    private short _BoardNumber = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _ClusterUid = Guid.Empty;
    private int _ClusterNumber = 0;
    private int _PanelNumber = 0;
    private string _AccountCode = string.Empty;
    private string _ClusterName = string.Empty;
    private string _PanelName = string.Empty;
    private int _ClusterGroupId = 0;
    private Guid _GalaxyInterfaceBoardUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Account Code value
    /// </summary>
    
    [DataMember]
    
    public string AccountCode 
    { 
      get { return _AccountCode; }
      set 
      { 
        if(HasValueChanged(_AccountCode, value, "AccountCode"))
        {
          _AccountCode = value; 
          RaisePropertyChanged("AccountCode");
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
    /// Get/Set the Panel Name value
    /// </summary>
    
    [DataMember]
    
    public string PanelName 
    { 
      get { return _PanelName; }
      set 
      { 
        if(HasValueChanged(_PanelName, value, "PanelName"))
        {
          _PanelName = value; 
          RaisePropertyChanged("PanelName");
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
    /// Get/Set the Galaxy Interface Board UidOld value
    /// </summary>
    
    public Guid GalaxyInterfaceBoardUidOld
    { 
      get { return _GalaxyInterfaceBoardUidOld; }
      set 
      { 
        if(HasValueChanged(_GalaxyInterfaceBoardUidOld, value, "GalaxyInterfaceBoardUid"))
        {
          _GalaxyInterfaceBoardUidOld = value; 
          RaisePropertyChanged("GalaxyInterfaceBoardUidOld");
        }
      } 
    }
    #endregion
  }
}
