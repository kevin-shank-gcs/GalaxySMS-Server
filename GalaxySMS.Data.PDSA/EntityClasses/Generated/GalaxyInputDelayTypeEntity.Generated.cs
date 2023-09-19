using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyInputDelayTypePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyInputDelayTypePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyInputDelayTypeUid = Guid.NewGuid();
    private string _Display = string.Empty;
    private Guid _DisplayResourceKey = Guid.NewGuid();
    private string _Description = string.Empty;
    private Guid _DescriptionResourceKey = Guid.NewGuid();
    private short _Code = 0;
    private int _DisplayOrder = 0;
    private bool? _IsDefault = false;
    private bool? _IsActive = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private string _CultureName = string.Empty;
    private Guid _GalaxyInputDelayTypeUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Input Delay Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyInputDelayTypeUid 
    { 
      get { return _GalaxyInputDelayTypeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputDelayTypeUid, value, "GalaxyInputDelayTypeUid"))
        {
          _GalaxyInputDelayTypeUid = value; 
          RaisePropertyChanged("GalaxyInputDelayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Display value
    /// </summary>
    
    [DataMember]
    
    public string Display 
    { 
      get { return _Display; }
      set 
      { 
        if(HasValueChanged(_Display, value, "Display"))
        {
          _Display = value; 
          RaisePropertyChanged("Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Display Resource Key value
    /// </summary>
    
    [DataMember]
    
    public Guid DisplayResourceKey 
    { 
      get { return _DisplayResourceKey; }
      set 
      { 
        if(HasValueChanged(_DisplayResourceKey, value, "DisplayResourceKey"))
        {
          _DisplayResourceKey = value; 
          RaisePropertyChanged("DisplayResourceKey");
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
    /// Get/Set the Description Resource Key value
    /// </summary>
    
    [DataMember]
    
    public Guid DescriptionResourceKey 
    { 
      get { return _DescriptionResourceKey; }
      set 
      { 
        if(HasValueChanged(_DescriptionResourceKey, value, "DescriptionResourceKey"))
        {
          _DescriptionResourceKey = value; 
          RaisePropertyChanged("DescriptionResourceKey");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Code value
    /// </summary>
    
    [DataMember]
    
    public short Code 
    { 
      get { return _Code; }
      set 
      { 
        if(HasValueChanged(_Code, value, "Code"))
        {
          _Code = value; 
          RaisePropertyChanged("Code");
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
    /// Get/Set the Galaxy Input Delay Type UidOld value
    /// </summary>
    
    public Guid GalaxyInputDelayTypeUidOld
    { 
      get { return _GalaxyInputDelayTypeUidOld; }
      set 
      { 
        if(HasValueChanged(_GalaxyInputDelayTypeUidOld, value, "GalaxyInputDelayTypeUid"))
        {
          _GalaxyInputDelayTypeUidOld = value; 
          RaisePropertyChanged("GalaxyInputDelayTypeUidOld");
        }
      } 
    }
    #endregion
  }
}
