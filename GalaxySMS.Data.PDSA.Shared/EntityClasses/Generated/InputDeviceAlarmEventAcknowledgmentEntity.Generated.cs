using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a InputDeviceAlarmEventAcknowledgmentPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDeviceAlarmEventAcknowledgmentPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _InputDeviceAlarmEventAcknowledgmentUid = Guid.Empty;
    private Guid _InputDeviceActivityEventUid = Guid.Empty;
    private Guid _UserId = Guid.Empty;
    private string _Response = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _InputDeviceAlarmEventAcknowledgmentUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Input Device Alarm Event Acknowledgment Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceAlarmEventAcknowledgmentUid 
    { 
      get { return _InputDeviceAlarmEventAcknowledgmentUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceAlarmEventAcknowledgmentUid, value, "InputDeviceAlarmEventAcknowledgmentUid"))
        {
          _InputDeviceAlarmEventAcknowledgmentUid = value; 
          RaisePropertyChanged("InputDeviceAlarmEventAcknowledgmentUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Activity Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceActivityEventUid 
    { 
      get { return _InputDeviceActivityEventUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceActivityEventUid, value, "InputDeviceActivityEventUid"))
        {
          _InputDeviceActivityEventUid = value; 
          RaisePropertyChanged("InputDeviceActivityEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Id value
    /// </summary>
    
    [DataMember]
    
    public Guid UserId 
    { 
      get { return _UserId; }
      set 
      { 
        if(HasValueChanged(_UserId, value, "UserId"))
        {
          _UserId = value; 
          RaisePropertyChanged("UserId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Response value
    /// </summary>
    
    [DataMember]
    
    public string Response 
    { 
      get { return _Response; }
      set 
      { 
        if(HasValueChanged(_Response, value, "Response"))
        {
          _Response = value; 
          RaisePropertyChanged("Response");
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
    /// Get/Set the Input Device Alarm Event Acknowledgment UidOld value
    /// </summary>
    
    public Guid InputDeviceAlarmEventAcknowledgmentUidOld
    { 
      get { return _InputDeviceAlarmEventAcknowledgmentUidOld; }
      set 
      { 
        if(HasValueChanged(_InputDeviceAlarmEventAcknowledgmentUidOld, value, "InputDeviceAlarmEventAcknowledgmentUid"))
        {
          _InputDeviceAlarmEventAcknowledgmentUidOld = value; 
          RaisePropertyChanged("InputDeviceAlarmEventAcknowledgmentUidOld");
        }
      } 
    }
    #endregion
  }
}
