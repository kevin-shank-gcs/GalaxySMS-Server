using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a CredentialCorporate1K48BitPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class CredentialCorporate1K48BitPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _CredentialUid = Guid.Empty;
    private int _CompanyCode = 0;
    private int _IdCode = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _CredentialUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Company Code value
    /// </summary>
    
    [DataMember]
    
    public int CompanyCode 
    { 
      get { return _CompanyCode; }
      set 
      { 
        if(HasValueChanged(_CompanyCode, value, "CompanyCode"))
        {
          _CompanyCode = value; 
          RaisePropertyChanged("CompanyCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Id Code value
    /// </summary>
    
    [DataMember]
    
    public int IdCode 
    { 
      get { return _IdCode; }
      set 
      { 
        if(HasValueChanged(_IdCode, value, "IdCode"))
        {
          _IdCode = value; 
          RaisePropertyChanged("IdCode");
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
    /// Get/Set the Credential UidOld value
    /// </summary>
    
    public Guid CredentialUidOld
    { 
      get { return _CredentialUidOld; }
      set 
      { 
        if(HasValueChanged(_CredentialUidOld, value, "CredentialUid"))
        {
          _CredentialUidOld = value; 
          RaisePropertyChanged("CredentialUidOld");
        }
      } 
    }
    #endregion
  }
}
