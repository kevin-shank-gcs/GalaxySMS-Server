using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a InputDeviceEventPropertiesPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class InputDeviceEventPropertiesPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _InputDeviceEventPropertiesUid = Guid.Empty;
    private Guid _InputDeviceUid = Guid.Empty;
    private Guid _AudioBinaryResourceUid = Guid.Empty;
    private Guid _ResponseInstructionsUid = Guid.Empty;
    private Guid _AcknowledgeTimeScheduleUid = Guid.Empty;
    private Guid _InputDeviceAlertEventTypeUid = Guid.Empty;
    private int _AcknowledgePriority = 0;
    private string _Tag = string.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _InputDeviceEventPropertiesUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Input Device Event Properties Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceEventPropertiesUid 
    { 
      get { return _InputDeviceEventPropertiesUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceEventPropertiesUid, value, "InputDeviceEventPropertiesUid"))
        {
          _InputDeviceEventPropertiesUid = value; 
          RaisePropertyChanged("InputDeviceEventPropertiesUid");
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
    /// Get/Set the Audio Binary Resource Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AudioBinaryResourceUid 
    { 
      get { return _AudioBinaryResourceUid; }
      set 
      { 
        if(HasValueChanged(_AudioBinaryResourceUid, value, "AudioBinaryResourceUid"))
        {
          _AudioBinaryResourceUid = value; 
          RaisePropertyChanged("AudioBinaryResourceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Response Instructions Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ResponseInstructionsUid 
    { 
      get { return _ResponseInstructionsUid; }
      set 
      { 
        if(HasValueChanged(_ResponseInstructionsUid, value, "ResponseInstructionsUid"))
        {
          _ResponseInstructionsUid = value; 
          RaisePropertyChanged("ResponseInstructionsUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Acknowledge Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AcknowledgeTimeScheduleUid 
    { 
      get { return _AcknowledgeTimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_AcknowledgeTimeScheduleUid, value, "AcknowledgeTimeScheduleUid"))
        {
          _AcknowledgeTimeScheduleUid = value; 
          RaisePropertyChanged("AcknowledgeTimeScheduleUid");
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
    /// Get/Set the Acknowledge Priority value
    /// </summary>
    
    [DataMember]
    
    public int AcknowledgePriority 
    { 
      get { return _AcknowledgePriority; }
      set 
      { 
        if(HasValueChanged(_AcknowledgePriority, value, "AcknowledgePriority"))
        {
          _AcknowledgePriority = value; 
          RaisePropertyChanged("AcknowledgePriority");
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
    /// Get/Set the Input Device Event Properties UidOld value
    /// </summary>
    
    public Guid InputDeviceEventPropertiesUidOld
    { 
      get { return _InputDeviceEventPropertiesUidOld; }
      set 
      { 
        if(HasValueChanged(_InputDeviceEventPropertiesUidOld, value, "InputDeviceEventPropertiesUid"))
        {
          _InputDeviceEventPropertiesUidOld = value; 
          RaisePropertyChanged("InputDeviceEventPropertiesUidOld");
        }
      } 
    }
    #endregion
  }
}
