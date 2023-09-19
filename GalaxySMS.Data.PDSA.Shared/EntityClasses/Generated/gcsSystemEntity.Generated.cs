using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsSystemPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsSystemPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _SystemId = Guid.Empty;
    private string _SystemName = string.Empty;
    private string _CompanyName = string.Empty;
    private string _SupportCompany = string.Empty;
    private string _SupportContact = string.Empty;
    private string _SupportPhone = string.Empty;
    private string _SupportEmail = string.Empty;
    private string _SupportUrl = string.Empty;
    private byte[] _SupportImage = null;
    private byte[] _SystemImage = null;
    private string _License = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _PublicKey = string.Empty;
    private Guid _SystemIdOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the System Id value
    /// </summary>
    
    [DataMember]
    
    public Guid SystemId 
    { 
      get { return _SystemId; }
      set 
      { 
        if(HasValueChanged(_SystemId, value, "SystemId"))
        {
          _SystemId = value; 
          RaisePropertyChanged("SystemId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the System Name value
    /// </summary>
    
    [DataMember]
    
    public string SystemName 
    { 
      get { return _SystemName; }
      set 
      { 
        if(HasValueChanged(_SystemName, value, "SystemName"))
        {
          _SystemName = value; 
          RaisePropertyChanged("SystemName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Company Name value
    /// </summary>
    
    [DataMember]
    
    public string CompanyName 
    { 
      get { return _CompanyName; }
      set 
      { 
        if(HasValueChanged(_CompanyName, value, "CompanyName"))
        {
          _CompanyName = value; 
          RaisePropertyChanged("CompanyName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Support Company value
    /// </summary>
    
    [DataMember]
    
    public string SupportCompany 
    { 
      get { return _SupportCompany; }
      set 
      { 
        if(HasValueChanged(_SupportCompany, value, "SupportCompany"))
        {
          _SupportCompany = value; 
          RaisePropertyChanged("SupportCompany");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Support Contact value
    /// </summary>
    
    [DataMember]
    
    public string SupportContact 
    { 
      get { return _SupportContact; }
      set 
      { 
        if(HasValueChanged(_SupportContact, value, "SupportContact"))
        {
          _SupportContact = value; 
          RaisePropertyChanged("SupportContact");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Support Phone value
    /// </summary>
    
    [DataMember]
    
    public string SupportPhone 
    { 
      get { return _SupportPhone; }
      set 
      { 
        if(HasValueChanged(_SupportPhone, value, "SupportPhone"))
        {
          _SupportPhone = value; 
          RaisePropertyChanged("SupportPhone");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Support Email value
    /// </summary>
    
    [DataMember]
    
    public string SupportEmail 
    { 
      get { return _SupportEmail; }
      set 
      { 
        if(HasValueChanged(_SupportEmail, value, "SupportEmail"))
        {
          _SupportEmail = value; 
          RaisePropertyChanged("SupportEmail");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Support Url value
    /// </summary>
    
    [DataMember]
    
    public string SupportUrl 
    { 
      get { return _SupportUrl; }
      set 
      { 
        if(HasValueChanged(_SupportUrl, value, "SupportUrl"))
        {
          _SupportUrl = value; 
          RaisePropertyChanged("SupportUrl");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Support Image value
    /// </summary>
    
    [DataMember]
    
    public byte[] SupportImage 
    { 
      get { return _SupportImage; }
      set 
      { 
        if(HasValueChanged(_SupportImage, value, "SupportImage"))
        {
          _SupportImage = value; 
          RaisePropertyChanged("SupportImage");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the System Image value
    /// </summary>
    
    [DataMember]
    
    public byte[] SystemImage 
    { 
      get { return _SystemImage; }
      set 
      { 
        if(HasValueChanged(_SystemImage, value, "SystemImage"))
        {
          _SystemImage = value; 
          RaisePropertyChanged("SystemImage");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the License value
    /// </summary>
    
    [DataMember]
    
    public string License 
    { 
      get { return _License; }
      set 
      { 
        if(HasValueChanged(_License, value, "License"))
        {
          _License = value; 
          RaisePropertyChanged("License");
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
    /// Get/Set the Public Key value
    /// </summary>
    
    [DataMember]
    
    public string PublicKey 
    { 
      get { return _PublicKey; }
      set 
      { 
        if(HasValueChanged(_PublicKey, value, "PublicKey"))
        {
          _PublicKey = value; 
          RaisePropertyChanged("PublicKey");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the System IdOld value
    /// </summary>
    
    public Guid SystemIdOld
    { 
      get { return _SystemIdOld; }
      set 
      { 
        if(HasValueChanged(_SystemIdOld, value, "SystemId"))
        {
          _SystemIdOld = value; 
          RaisePropertyChanged("SystemIdOld");
        }
      } 
    }
    #endregion
  }
}
