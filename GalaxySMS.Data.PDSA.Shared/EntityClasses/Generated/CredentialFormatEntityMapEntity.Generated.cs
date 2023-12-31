using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a CredentialFormatEntityMapPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class CredentialFormatEntityMapPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _CredentialFormatEntityMapUid = Guid.Empty;
    private Guid _CredentialFormatUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private bool _IsAllowed = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _CredentialFormatEntityMapUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Credential Format Entity Map Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialFormatEntityMapUid 
    { 
      get { return _CredentialFormatEntityMapUid; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatEntityMapUid, value, "CredentialFormatEntityMapUid"))
        {
          _CredentialFormatEntityMapUid = value; 
          RaisePropertyChanged("CredentialFormatEntityMapUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Credential Format Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CredentialFormatUid 
    { 
      get { return _CredentialFormatUid; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatUid, value, "CredentialFormatUid"))
        {
          _CredentialFormatUid = value; 
          RaisePropertyChanged("CredentialFormatUid");
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
    /// Get/Set the Is Allowed value
    /// </summary>
    
    [DataMember]
    
    public bool IsAllowed 
    { 
      get { return _IsAllowed; }
      set 
      { 
        if(HasValueChanged(_IsAllowed, value, "IsAllowed"))
        {
          _IsAllowed = value; 
          RaisePropertyChanged("IsAllowed");
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
    /// Get/Set the Credential Format Entity Map UidOld value
    /// </summary>
    
    public Guid CredentialFormatEntityMapUidOld
    { 
      get { return _CredentialFormatEntityMapUidOld; }
      set 
      { 
        if(HasValueChanged(_CredentialFormatEntityMapUidOld, value, "CredentialFormatEntityMapUid"))
        {
          _CredentialFormatEntityMapUidOld = value; 
          RaisePropertyChanged("CredentialFormatEntityMapUidOld");
        }
      } 
    }
    #endregion
  }
}
