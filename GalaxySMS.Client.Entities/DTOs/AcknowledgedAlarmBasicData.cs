using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
  public partial class AcknowledgedAlarmBasicData : DtoObjectBase
  {
    #region Private Variables
    private Guid _ActivityEventUid = Guid.Empty;
    private Guid _DeviceEntityId = Guid.Empty;
    private Guid _DeviceUid = Guid.Empty;
    private Guid _AccessPortalAlarmEventAcknowledgmentUid = Guid.Empty;
    private string _Response = string.Empty;
    private Guid _AckedByUserId = Guid.Empty;
    private string _AckedByUserDisplayName = string.Empty;
    private DateTimeOffset _AckedDateTime = DateTimeOffset.Now;
    private DateTimeOffset _AckedUpdatedDateTime = DateTimeOffset.Now;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Activity Event Uid value
    /// </summary>
    [DataMember]
    
    public Guid ActivityEventUid 
    { 
      get { return _ActivityEventUid; }
      set 
      { 
        if(_ActivityEventUid != value)
        {
          _ActivityEventUid = value; 
           OnPropertyChanged(() => ActivityEventUid);
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
        if(_DeviceEntityId != value)
        {
          _DeviceEntityId = value; 
           OnPropertyChanged(() => DeviceEntityId);
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
        if(_DeviceUid != value)
        {
          _DeviceUid = value; 
           OnPropertyChanged(() => DeviceUid);
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Alarm Event Acknowledgment Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalAlarmEventAcknowledgmentUid 
    { 
      get { return _AccessPortalAlarmEventAcknowledgmentUid; }
      set 
      { 
        if(_AccessPortalAlarmEventAcknowledgmentUid != value)
        {
          _AccessPortalAlarmEventAcknowledgmentUid = value; 
           OnPropertyChanged(() => AccessPortalAlarmEventAcknowledgmentUid);
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
        if(_Response != value)
        {
          _Response = value; 
           OnPropertyChanged(() => Response);
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
        if(_AckedByUserId != value)
        {
          _AckedByUserId = value; 
           OnPropertyChanged(() => AckedByUserId);
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
        if(_AckedByUserDisplayName != value)
        {
          _AckedByUserDisplayName = value; 
           OnPropertyChanged(() => AckedByUserDisplayName);
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
        if(_AckedDateTime != value)
        {
          _AckedDateTime = value; 
           OnPropertyChanged(() => AckedDateTime);
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Acked Updated Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset AckedUpdatedDateTime 
    { 
      get { return _AckedUpdatedDateTime; }
      set 
      { 
        if(_AckedUpdatedDateTime != value)
        {
          _AckedUpdatedDateTime = value; 
           OnPropertyChanged(() => AckedUpdatedDateTime);
        }
      } 
    }
        

    #endregion
  }

}
