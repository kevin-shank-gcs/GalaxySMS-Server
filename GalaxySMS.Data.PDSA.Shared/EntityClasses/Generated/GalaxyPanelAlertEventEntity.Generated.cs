using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyPanelAlertEventPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyPanelAlertEventPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyPanelAlertEventUid = Guid.Empty;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _GalaxyPanelAlertEventTypeUid = Guid.Empty;
    private Guid _AcknowledgeTimeScheduleUid = Guid.Empty;
    private Guid _AudioBinaryResourceUid = Guid.Empty;
    private Guid _UserInstructionsNoteUid = Guid.Empty;
    private Guid _InputOutputGroupAssignmentUid = Guid.Empty;
    private Guid _InputOutputGroupUid = Guid.Empty;
    private int _AcknowledgePriority = 0;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _GalaxyPanelAlertEventUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Panel Alert Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelAlertEventUid 
    { 
      get { return _GalaxyPanelAlertEventUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelAlertEventUid, value, "GalaxyPanelAlertEventUid"))
        {
          _GalaxyPanelAlertEventUid = value; 
          RaisePropertyChanged("GalaxyPanelAlertEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelUid 
    { 
      get { return _GalaxyPanelUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelUid, value, "GalaxyPanelUid"))
        {
          _GalaxyPanelUid = value; 
          RaisePropertyChanged("GalaxyPanelUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Alert Event Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelAlertEventTypeUid 
    { 
      get { return _GalaxyPanelAlertEventTypeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelAlertEventTypeUid, value, "GalaxyPanelAlertEventTypeUid"))
        {
          _GalaxyPanelAlertEventTypeUid = value; 
          RaisePropertyChanged("GalaxyPanelAlertEventTypeUid");
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
    /// Get/Set the User Instructions Note Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid UserInstructionsNoteUid 
    { 
      get { return _UserInstructionsNoteUid; }
      set 
      { 
        if(HasValueChanged(_UserInstructionsNoteUid, value, "UserInstructionsNoteUid"))
        {
          _UserInstructionsNoteUid = value; 
          RaisePropertyChanged("UserInstructionsNoteUid");
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
    /// Get/Set the Galaxy Panel Alert Event UidOld value
    /// </summary>
    
    public Guid GalaxyPanelAlertEventUidOld
    { 
      get { return _GalaxyPanelAlertEventUidOld; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelAlertEventUidOld, value, "GalaxyPanelAlertEventUid"))
        {
          _GalaxyPanelAlertEventUidOld = value; 
          RaisePropertyChanged("GalaxyPanelAlertEventUidOld");
        }
      } 
    }
    #endregion
  }
}
