using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsResourceStringLanguagePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsResourceStringLanguagePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ResourceStringLanguageId = Guid.NewGuid();
    private Guid _ResourceId = Guid.NewGuid();
    private Guid _LanguageId = Guid.NewGuid();
    private string _StringValue = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _CultureName = string.Empty;
    private Guid _ResourceStringLanguageIdOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Resource String Language Id value
    /// </summary>
    
    [DataMember]
    
    public Guid ResourceStringLanguageId 
    { 
      get { return _ResourceStringLanguageId; }
      set 
      { 
        if(HasValueChanged(_ResourceStringLanguageId, value, "ResourceStringLanguageId"))
        {
          _ResourceStringLanguageId = value; 
          RaisePropertyChanged("ResourceStringLanguageId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Resource Id value
    /// </summary>
    
    [DataMember]
    
    public Guid ResourceId 
    { 
      get { return _ResourceId; }
      set 
      { 
        if(HasValueChanged(_ResourceId, value, "ResourceId"))
        {
          _ResourceId = value; 
          RaisePropertyChanged("ResourceId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Language Id value
    /// </summary>
    
    [DataMember]
    
    public Guid LanguageId 
    { 
      get { return _LanguageId; }
      set 
      { 
        if(HasValueChanged(_LanguageId, value, "LanguageId"))
        {
          _LanguageId = value; 
          RaisePropertyChanged("LanguageId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the String Value value
    /// </summary>
    
    [DataMember]
    
    public string StringValue 
    { 
      get { return _StringValue; }
      set 
      { 
        if(HasValueChanged(_StringValue, value, "StringValue"))
        {
          _StringValue = value; 
          RaisePropertyChanged("StringValue");
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
    /// Get/Set the Culture Name value
    /// </summary>
    
    [DataMember]
    
    public string CultureName 
    { 
      get { return _CultureName; }
      set 
      { 
        if(HasValueChanged(_CultureName, value, "CultureName"))
        {
          _CultureName = value; 
          RaisePropertyChanged("CultureName");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Resource String Language IdOld value
    /// </summary>
    
    public Guid ResourceStringLanguageIdOld
    { 
      get { return _ResourceStringLanguageIdOld; }
      set 
      { 
        if(HasValueChanged(_ResourceStringLanguageIdOld, value, "ResourceStringLanguageId"))
        {
          _ResourceStringLanguageIdOld = value; 
          RaisePropertyChanged("ResourceStringLanguageIdOld");
        }
      } 
    }
    #endregion
  }
}
