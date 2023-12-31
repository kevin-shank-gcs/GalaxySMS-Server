using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a FeaturePDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class FeaturePDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _FeatureUid = Guid.NewGuid();
    private string _CategoryCode = string.Empty;
    private string _FeatureCode = string.Empty;
    private string _Description = string.Empty;
    private string _FeatureType = string.Empty;
    private string _DefaultValue = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _FeatureUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Feature Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid FeatureUid 
    { 
      get { return _FeatureUid; }
      set 
      { 
        if(HasValueChanged(_FeatureUid, value, "FeatureUid"))
        {
          _FeatureUid = value; 
          RaisePropertyChanged("FeatureUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Category Code value
    /// </summary>
    
    [DataMember]
    
    public string CategoryCode 
    { 
      get { return _CategoryCode; }
      set 
      { 
        if(HasValueChanged(_CategoryCode, value, "CategoryCode"))
        {
          _CategoryCode = value; 
          RaisePropertyChanged("CategoryCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Feature Code value
    /// </summary>
    
    [DataMember]
    
    public string FeatureCode 
    { 
      get { return _FeatureCode; }
      set 
      { 
        if(HasValueChanged(_FeatureCode, value, "FeatureCode"))
        {
          _FeatureCode = value; 
          RaisePropertyChanged("FeatureCode");
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
    /// Get/Set the Feature Type value
    /// </summary>
    
    [DataMember]
    
    public string FeatureType 
    { 
      get { return _FeatureType; }
      set 
      { 
        if(HasValueChanged(_FeatureType, value, "FeatureType"))
        {
          _FeatureType = value; 
          RaisePropertyChanged("FeatureType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Default Value value
    /// </summary>
    
    [DataMember]
    
    public string DefaultValue 
    { 
      get { return _DefaultValue; }
      set 
      { 
        if(HasValueChanged(_DefaultValue, value, "DefaultValue"))
        {
          _DefaultValue = value; 
          RaisePropertyChanged("DefaultValue");
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
    /// Get/Set the Feature UidOld value
    /// </summary>
    
    public Guid FeatureUidOld
    { 
      get { return _FeatureUidOld; }
      set 
      { 
        if(HasValueChanged(_FeatureUidOld, value, "FeatureUid"))
        {
          _FeatureUidOld = value; 
          RaisePropertyChanged("FeatureUidOld");
        }
      } 
    }
    #endregion
  }
}
