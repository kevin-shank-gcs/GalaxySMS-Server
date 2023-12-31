using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsLanguagePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsLanguagePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _LanguageId = Guid.NewGuid();
    private string _CultureName = string.Empty;
    private string _LanguageName = string.Empty;
    private string _Description = string.Empty;
    private string _Notes = string.Empty;
    private bool? _IsActive = false;
    private bool? _IsDisplay = false;
    private bool? _IsDefault = false;
    private byte[] _FlagImage = null;
    private int _DisplayOrder = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _LanguageIdOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Language Name value
    /// </summary>
    
    [DataMember]
    
    public string LanguageName 
    { 
      get { return _LanguageName; }
      set 
      { 
        if(HasValueChanged(_LanguageName, value, "LanguageName"))
        {
          _LanguageName = value; 
          RaisePropertyChanged("LanguageName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Description value
    /// </summary>
    
    [DataMember]
    
    public string Description 
    { 
      get { return _Description; }
      set 
      { 
        if(HasValueChanged(_Description, value, "Description"))
        {
          _Description = value; 
          RaisePropertyChanged("Description");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Notes value
    /// </summary>
    
    [DataMember]
    
    public string Notes 
    { 
      get { return _Notes; }
      set 
      { 
        if(HasValueChanged(_Notes, value, "Notes"))
        {
          _Notes = value; 
          RaisePropertyChanged("Notes");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Active value
    /// </summary>
    
    [DataMember]
    
    public bool? IsActive 
    { 
      get { return _IsActive; }
      set 
      { 
        if(HasValueChanged(_IsActive, value, "IsActive"))
        {
          _IsActive = value; 
          RaisePropertyChanged("IsActive");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Display value
    /// </summary>
    
    [DataMember]
    
    public bool? IsDisplay 
    { 
      get { return _IsDisplay; }
      set 
      { 
        if(HasValueChanged(_IsDisplay, value, "IsDisplay"))
        {
          _IsDisplay = value; 
          RaisePropertyChanged("IsDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Default value
    /// </summary>
    
    [DataMember]
    
    public bool? IsDefault 
    { 
      get { return _IsDefault; }
      set 
      { 
        if(HasValueChanged(_IsDefault, value, "IsDefault"))
        {
          _IsDefault = value; 
          RaisePropertyChanged("IsDefault");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Flag Image value
    /// </summary>
    
    [DataMember]
    
    public byte[] FlagImage 
    { 
      get { return _FlagImage; }
      set 
      { 
        if(HasValueChanged(_FlagImage, value, "FlagImage"))
        {
          _FlagImage = value; 
          RaisePropertyChanged("FlagImage");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Display Order value
    /// </summary>
    
    [DataMember]
    
    public int DisplayOrder 
    { 
      get { return _DisplayOrder; }
      set 
      { 
        if(HasValueChanged(_DisplayOrder, value, "DisplayOrder"))
        {
          _DisplayOrder = value; 
          RaisePropertyChanged("DisplayOrder");
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
    /// Get/Set the Language IdOld value
    /// </summary>
    
    public Guid LanguageIdOld
    { 
      get { return _LanguageIdOld; }
      set 
      { 
        if(HasValueChanged(_LanguageIdOld, value, "LanguageId"))
        {
          _LanguageIdOld = value; 
          RaisePropertyChanged("LanguageIdOld");
        }
      } 
    }
    #endregion
  }
}
