using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a PersonAccessGroupPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class PersonAccessGroupPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PersonAccessGroupUid = Guid.Empty;
    private Guid _AccessGroupUid = Guid.Empty;
    private Guid _PersonClusterPermissionUid = Guid.Empty;
    private short _OrderNumber = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _PersonUid = Guid.Empty;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _PersonCredentialUid = Guid.Empty;
    private int _AccessGroupNumber = 0;
    private string _AccessGroupName = string.Empty;
    private Guid _PersonAccessGroupUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Person Access Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonAccessGroupUid 
    { 
      get { return _PersonAccessGroupUid; }
      set 
      { 
        if(HasValueChanged(_PersonAccessGroupUid, value, "PersonAccessGroupUid"))
        {
          _PersonAccessGroupUid = value; 
          RaisePropertyChanged("PersonAccessGroupUid");
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
    /// Get/Set the Person Cluster Permission Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonClusterPermissionUid 
    { 
      get { return _PersonClusterPermissionUid; }
      set 
      { 
        if(HasValueChanged(_PersonClusterPermissionUid, value, "PersonClusterPermissionUid"))
        {
          _PersonClusterPermissionUid = value; 
          RaisePropertyChanged("PersonClusterPermissionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Order Number value
    /// </summary>
    
    [DataMember]
    
    public short OrderNumber 
    { 
      get { return _OrderNumber; }
      set 
      { 
        if(HasValueChanged(_OrderNumber, value, "OrderNumber"))
        {
          _OrderNumber = value; 
          RaisePropertyChanged("OrderNumber");
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
    /// Get/Set the Person Credential Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonCredentialUid 
    { 
      get { return _PersonCredentialUid; }
      set 
      { 
        if(HasValueChanged(_PersonCredentialUid, value, "PersonCredentialUid"))
        {
          _PersonCredentialUid = value; 
          RaisePropertyChanged("PersonCredentialUid");
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
    /// Get/Set the Person Access Group UidOld value
    /// </summary>
    
    public Guid PersonAccessGroupUidOld
    { 
      get { return _PersonAccessGroupUidOld; }
      set 
      { 
        if(HasValueChanged(_PersonAccessGroupUidOld, value, "PersonAccessGroupUid"))
        {
          _PersonAccessGroupUidOld = value; 
          RaisePropertyChanged("PersonAccessGroupUidOld");
        }
      } 
    }
    #endregion
  }
}
