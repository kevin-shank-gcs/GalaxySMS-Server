using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a InputDeviceAlertEventPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDeviceAlertEventPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _InputDeviceAlertEventUid = Guid.Empty;
    private Guid _InputDeviceUid = Guid.Empty;
    private Guid _InputOutputGroupUid = Guid.Empty;
    private Guid _InputOutputGroupAssignmentUid = Guid.Empty;
    private Guid _InputDeviceAlertEventTypeUid = Guid.Empty;
    private string _Tag = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _InputDeviceAlertEventUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Input Device Alert Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceAlertEventUid 
    { 
      get { return _InputDeviceAlertEventUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceAlertEventUid, value, "InputDeviceAlertEventUid"))
        {
          _InputDeviceAlertEventUid = value; 
          RaisePropertyChanged("InputDeviceAlertEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceUid 
    { 
      get { return _InputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceUid, value, "InputDeviceUid"))
        {
          _InputDeviceUid = value; 
          RaisePropertyChanged("InputDeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputOutputGroupUid 
    { 
      get { return _InputOutputGroupUid; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroupUid, value, "InputOutputGroupUid"))
        {
          _InputOutputGroupUid = value; 
          RaisePropertyChanged("InputOutputGroupUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group Assignment Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputOutputGroupAssignmentUid 
    { 
      get { return _InputOutputGroupAssignmentUid; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroupAssignmentUid, value, "InputOutputGroupAssignmentUid"))
        {
          _InputOutputGroupAssignmentUid = value; 
          RaisePropertyChanged("InputOutputGroupAssignmentUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Alert Event Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceAlertEventTypeUid 
    { 
      get { return _InputDeviceAlertEventTypeUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceAlertEventTypeUid, value, "InputDeviceAlertEventTypeUid"))
        {
          _InputDeviceAlertEventTypeUid = value; 
          RaisePropertyChanged("InputDeviceAlertEventTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tag value
    /// </summary>
    
    [DataMember]
    
    public string Tag 
    { 
      get { return _Tag; }
      set 
      { 
        if(HasValueChanged(_Tag, value, "Tag"))
        {
          _Tag = value; 
          RaisePropertyChanged("Tag");
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
    /// Get/Set the Input Device Alert Event UidOld value
    /// </summary>
    
    public Guid InputDeviceAlertEventUidOld
    { 
      get { return _InputDeviceAlertEventUidOld; }
      set 
      { 
        if(HasValueChanged(_InputDeviceAlertEventUidOld, value, "InputDeviceAlertEventUid"))
        {
          _InputDeviceAlertEventUidOld = value; 
          RaisePropertyChanged("InputDeviceAlertEventUidOld");
        }
      } 
    }
    #endregion
  }
}
