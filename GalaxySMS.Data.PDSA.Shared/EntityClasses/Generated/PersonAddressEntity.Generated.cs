using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a PersonAddressPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class PersonAddressPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _PersonAddressUid = Guid.Empty;
    private Guid _PersonUid = Guid.Empty;
    private Guid _AddressUid = Guid.Empty;
    private string _Label = string.Empty;
    private bool _IsCurrent = false;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _PersonAddressUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Person Address Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid PersonAddressUid 
    { 
      get { return _PersonAddressUid; }
      set 
      { 
        if(HasValueChanged(_PersonAddressUid, value, "PersonAddressUid"))
        {
          _PersonAddressUid = value; 
          RaisePropertyChanged("PersonAddressUid");
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
    /// Get/Set the Address Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AddressUid 
    { 
      get { return _AddressUid; }
      set 
      { 
        if(HasValueChanged(_AddressUid, value, "AddressUid"))
        {
          _AddressUid = value; 
          RaisePropertyChanged("AddressUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Label value
    /// </summary>
    
    [DataMember]
    
    public string Label 
    { 
      get { return _Label; }
      set 
      { 
        if(HasValueChanged(_Label, value, "Label"))
        {
          _Label = value; 
          RaisePropertyChanged("Label");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Is Current value
    /// </summary>
    
    [DataMember]
    
    public bool IsCurrent 
    { 
      get { return _IsCurrent; }
      set 
      { 
        if(HasValueChanged(_IsCurrent, value, "IsCurrent"))
        {
          _IsCurrent = value; 
          RaisePropertyChanged("IsCurrent");
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
    /// Get/Set the Person Address UidOld value
    /// </summary>
    
    public Guid PersonAddressUidOld
    { 
      get { return _PersonAddressUidOld; }
      set 
      { 
        if(HasValueChanged(_PersonAddressUidOld, value, "PersonAddressUid"))
        {
          _PersonAddressUidOld = value; 
          RaisePropertyChanged("PersonAddressUidOld");
        }
      } 
    }
    #endregion
  }
}
