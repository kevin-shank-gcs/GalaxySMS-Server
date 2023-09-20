using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a PersonListPropertyItemPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class PersonListPropertyItemPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PersonListPropertyItemUid = Guid.Empty;
    private Guid _PersonUid = Guid.Empty;
    private Guid _UserDefinedPropertyUid = Guid.Empty;
    private Guid _UserDefinedListPropertyItemUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _PersonListPropertyItemUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Person List Property Item Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonListPropertyItemUid 
    { 
      get { return _PersonListPropertyItemUid; }
      set 
      { 
        if(HasValueChanged(_PersonListPropertyItemUid, value, "PersonListPropertyItemUid"))
        {
          _PersonListPropertyItemUid = value; 
          RaisePropertyChanged("PersonListPropertyItemUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Person Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonUid 
    { 
      get { return _PersonUid; }
      set 
      { 
        if(HasValueChanged(_PersonUid, value, "PersonUid"))
        {
          _PersonUid = value; 
          RaisePropertyChanged("PersonUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Defined Property Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid UserDefinedPropertyUid 
    { 
      get { return _UserDefinedPropertyUid; }
      set 
      { 
        if(HasValueChanged(_UserDefinedPropertyUid, value, "UserDefinedPropertyUid"))
        {
          _UserDefinedPropertyUid = value; 
          RaisePropertyChanged("UserDefinedPropertyUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Defined List Property Item Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid UserDefinedListPropertyItemUid 
    { 
      get { return _UserDefinedListPropertyItemUid; }
      set 
      { 
        if(HasValueChanged(_UserDefinedListPropertyItemUid, value, "UserDefinedListPropertyItemUid"))
        {
          _UserDefinedListPropertyItemUid = value; 
          RaisePropertyChanged("UserDefinedListPropertyItemUid");
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
    /// Get/Set the Person List Property Item UidOld value
    /// </summary>
    
    public Guid PersonListPropertyItemUidOld
    { 
      get { return _PersonListPropertyItemUidOld; }
      set 
      { 
        if(HasValueChanged(_PersonListPropertyItemUidOld, value, "PersonListPropertyItemUid"))
        {
          _PersonListPropertyItemUidOld = value; 
          RaisePropertyChanged("PersonListPropertyItemUidOld");
        }
      } 
    }
    #endregion
  }
}
