using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a FeatureItemPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class FeatureItemPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _FeatureItemUid = Guid.NewGuid();
    private Guid _FeatureUid = Guid.NewGuid();
    private string _Value = string.Empty;
    private string _Code = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _FeatureItemUidOld = Guid.NewGuid();
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Feature Item Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid FeatureItemUid 
    { 
      get { return _FeatureItemUid; }
      set 
      { 
        if(HasValueChanged(_FeatureItemUid, value, "FeatureItemUid"))
        {
          _FeatureItemUid = value; 
          RaisePropertyChanged("FeatureItemUid");
        }
      } 
    }
        
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
    /// Get/Set the Value value
    /// </summary>
    
    [DataMember]
    
    public string Value 
    { 
      get { return _Value; }
      set 
      { 
        if(HasValueChanged(_Value, value, "Value"))
        {
          _Value = value; 
          RaisePropertyChanged("Value");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Code value
    /// </summary>
    
    [DataMember]
    
    public string Code 
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
    /// Get/Set the Feature Item UidOld value
    /// </summary>
    
    public Guid FeatureItemUidOld
    { 
      get { return _FeatureItemUidOld; }
      set 
      { 
        if(HasValueChanged(_FeatureItemUidOld, value, "FeatureItemUid"))
        {
          _FeatureItemUidOld = value; 
          RaisePropertyChanged("FeatureItemUidOld");
        }
      } 
    }
    #endregion
  }
}
