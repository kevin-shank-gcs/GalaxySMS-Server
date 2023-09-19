using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a RoleAccessPortalPermissionPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class RoleAccessPortalPermissionPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _RoleAccessPortalPermissionUid = Guid.Empty;
    private Guid _RoleAccessPortalUid = Guid.Empty;
    private Guid _PermissionId = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _RoleAccessPortalPermissionUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Role Access Portal Permission Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleAccessPortalPermissionUid 
    { 
      get { return _RoleAccessPortalPermissionUid; }
      set 
      { 
        if(HasValueChanged(_RoleAccessPortalPermissionUid, value, "RoleAccessPortalPermissionUid"))
        {
          _RoleAccessPortalPermissionUid = value; 
          RaisePropertyChanged("RoleAccessPortalPermissionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Role Access Portal Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid RoleAccessPortalUid 
    { 
      get { return _RoleAccessPortalUid; }
      set 
      { 
        if(HasValueChanged(_RoleAccessPortalUid, value, "RoleAccessPortalUid"))
        {
          _RoleAccessPortalUid = value; 
          RaisePropertyChanged("RoleAccessPortalUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Permission Id value
    /// </summary>
    
    [DataMember]
    
    public Guid PermissionId 
    { 
      get { return _PermissionId; }
      set 
      { 
        if(HasValueChanged(_PermissionId, value, "PermissionId"))
        {
          _PermissionId = value; 
          RaisePropertyChanged("PermissionId");
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
    /// Get/Set the Role Access Portal Permission UidOld value
    /// </summary>
    
    public Guid RoleAccessPortalPermissionUidOld
    { 
      get { return _RoleAccessPortalPermissionUidOld; }
      set 
      { 
        if(HasValueChanged(_RoleAccessPortalPermissionUidOld, value, "RoleAccessPortalPermissionUid"))
        {
          _RoleAccessPortalPermissionUidOld = value; 
          RaisePropertyChanged("RoleAccessPortalPermissionUidOld");
        }
      } 
    }
    #endregion
  }
}
