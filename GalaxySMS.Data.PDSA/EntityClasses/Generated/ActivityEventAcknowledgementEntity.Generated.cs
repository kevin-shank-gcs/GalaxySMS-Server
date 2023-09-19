using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a ActivityEventAcknowledgementPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class ActivityEventAcknowledgementPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _ActivityEventAcknowledgementUid = Guid.Empty;
    private Guid _ActivityEventUid = Guid.Empty;
    private Guid _DeviceEntityId = Guid.Empty;
    private Guid _DeviceUid = Guid.Empty;
    private string _ActivityEventCategory = string.Empty;
    private string _Response = string.Empty;
    private Guid _AckedByUserId = Guid.Empty;
    private string _AckedByUserDisplayName = string.Empty;
    private DateTimeOffset _AckedDateTime = DateTimeOffset.MinValue;
    private DateTimeOffset? _AckedUpdatedDateTime = null;
    private Guid _ActivityEventAcknowledgementUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Activity Event Acknowledgement Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ActivityEventAcknowledgementUid 
    { 
      get { return _ActivityEventAcknowledgementUid; }
      set 
      { 
        if(HasValueChanged(_ActivityEventAcknowledgementUid, value, "ActivityEventAcknowledgementUid"))
        {
          _ActivityEventAcknowledgementUid = value; 
          RaisePropertyChanged("ActivityEventAcknowledgementUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activity Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ActivityEventUid 
    { 
      get { return _ActivityEventUid; }
      set 
      { 
        if(HasValueChanged(_ActivityEventUid, value, "ActivityEventUid"))
        {
          _ActivityEventUid = value; 
          RaisePropertyChanged("ActivityEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Entity Id value
    /// </summary>
    
    [DataMember]
    
    public Guid DeviceEntityId 
    { 
      get { return _DeviceEntityId; }
      set 
      { 
        if(HasValueChanged(_DeviceEntityId, value, "DeviceEntityId"))
        {
          _DeviceEntityId = value; 
          RaisePropertyChanged("DeviceEntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DeviceUid 
    { 
      get { return _DeviceUid; }
      set 
      { 
        if(HasValueChanged(_DeviceUid, value, "DeviceUid"))
        {
          _DeviceUid = value; 
          RaisePropertyChanged("DeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activity Event Category value
    /// </summary>
    
    [DataMember]
    
    public string ActivityEventCategory 
    { 
      get { return _ActivityEventCategory; }
      set 
      { 
        if(HasValueChanged(_ActivityEventCategory, value, "ActivityEventCategory"))
        {
          _ActivityEventCategory = value; 
          RaisePropertyChanged("ActivityEventCategory");
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
    /// Get/Set the Acked By User Id value
    /// </summary>
    
    [DataMember]
    
    public Guid AckedByUserId 
    { 
      get { return _AckedByUserId; }
      set 
      { 
        if(HasValueChanged(_AckedByUserId, value, "AckedByUserId"))
        {
          _AckedByUserId = value; 
          RaisePropertyChanged("AckedByUserId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Acked By User Display Name value
    /// </summary>
    
    [DataMember]
    
    public string AckedByUserDisplayName 
    { 
      get { return _AckedByUserDisplayName; }
      set 
      { 
        if(HasValueChanged(_AckedByUserDisplayName, value, "AckedByUserDisplayName"))
        {
          _AckedByUserDisplayName = value; 
          RaisePropertyChanged("AckedByUserDisplayName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Acked Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset AckedDateTime 
    { 
      get { return _AckedDateTime; }
      set 
      { 
        if(HasValueChanged(_AckedDateTime, value, "AckedDateTime"))
        {
          _AckedDateTime = value; 
          RaisePropertyChanged("AckedDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Acked Updated Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset? AckedUpdatedDateTime 
    { 
      get { return _AckedUpdatedDateTime; }
      set 
      { 
        if(HasValueChanged(_AckedUpdatedDateTime, value, "AckedUpdatedDateTime"))
        {
          _AckedUpdatedDateTime = value; 
          RaisePropertyChanged("AckedUpdatedDateTime");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Activity Event Acknowledgement UidOld value
    /// </summary>
    
    public Guid ActivityEventAcknowledgementUidOld
    { 
      get { return _ActivityEventAcknowledgementUidOld; }
      set 
      { 
        if(HasValueChanged(_ActivityEventAcknowledgementUidOld, value, "ActivityEventAcknowledgementUid"))
        {
          _ActivityEventAcknowledgementUidOld = value; 
          RaisePropertyChanged("ActivityEventAcknowledgementUidOld");
        }
      } 
    }
    #endregion
  }
}
