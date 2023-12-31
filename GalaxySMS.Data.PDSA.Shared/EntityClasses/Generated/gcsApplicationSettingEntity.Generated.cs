using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a gcsApplicationSettingPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcsApplicationSettingPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ApplicationSettingId = Guid.NewGuid();
    private Guid _ApplicationId = Guid.NewGuid();
    private string _Category = string.Empty;
    private string _SettingKey = string.Empty;
    private string _SettingValue = string.Empty;
    private string _SettingDescription = string.Empty;
    private bool? _IsActive = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _ApplicationSettingIdOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Application Setting Id value
    /// </summary>
    
    public Guid ApplicationSettingId 
    { 
      get { return _ApplicationSettingId; }
      set 
      { 
        if(HasValueChanged(_ApplicationSettingId, value, "ApplicationSettingId"))
        {
          _ApplicationSettingId = value; 
          RaisePropertyChanged("ApplicationSettingId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Id value
    /// </summary>
    
    public Guid ApplicationId 
    { 
      get { return _ApplicationId; }
      set 
      { 
        if(HasValueChanged(_ApplicationId, value, "ApplicationId"))
        {
          _ApplicationId = value; 
          RaisePropertyChanged("ApplicationId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Category value
    /// </summary>
    
    public string Category 
    { 
      get { return _Category; }
      set 
      { 
        if(HasValueChanged(_Category, value, "Category"))
        {
          _Category = value; 
          RaisePropertyChanged("Category");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Setting Key value
    /// </summary>
    
    public string SettingKey 
    { 
      get { return _SettingKey; }
      set 
      { 
        if(HasValueChanged(_SettingKey, value, "SettingKey"))
        {
          _SettingKey = value; 
          RaisePropertyChanged("SettingKey");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Setting Value value
    /// </summary>
    
    public string SettingValue 
    { 
      get { return _SettingValue; }
      set 
      { 
        if(HasValueChanged(_SettingValue, value, "SettingValue"))
        {
          _SettingValue = value; 
          RaisePropertyChanged("SettingValue");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Setting Description value
    /// </summary>
    
    public string SettingDescription 
    { 
      get { return _SettingDescription; }
      set 
      { 
        if(HasValueChanged(_SettingDescription, value, "SettingDescription"))
        {
          _SettingDescription = value; 
          RaisePropertyChanged("SettingDescription");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Active value
    /// </summary>
    
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
    /// Get/Set the Insert Name value
    /// </summary>
    
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
    /// Get/Set the Application Setting IdOld value
    /// </summary>
    
    public Guid ApplicationSettingIdOld
    { 
      get { return _ApplicationSettingIdOld; }
      set 
      { 
        if(HasValueChanged(_ApplicationSettingIdOld, value, "ApplicationSettingId"))
        {
          _ApplicationSettingIdOld = value; 
          RaisePropertyChanged("ApplicationSettingIdOld");
        }
      } 
    }
    #endregion
  }
}
