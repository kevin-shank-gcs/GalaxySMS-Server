using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyPanelActivityAlarmEventPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyPanelActivityAlarmEventPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyPanelActivityEventUid = Guid.Empty;
    private Guid _NoteUid = Guid.Empty;
    private Guid _BinaryResourceUid = Guid.Empty;
    private int _AlarmPriority = 0;
    private Guid _GalaxyPanelUid = Guid.Empty;
    private Guid _GalaxyPanelActivityEventUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Panel Activity Event Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelActivityEventUid 
    { 
      get { return _GalaxyPanelActivityEventUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelActivityEventUid, value, "GalaxyPanelActivityEventUid"))
        {
          _GalaxyPanelActivityEventUid = value; 
          RaisePropertyChanged("GalaxyPanelActivityEventUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Note Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid NoteUid 
    { 
      get { return _NoteUid; }
      set 
      { 
        if(HasValueChanged(_NoteUid, value, "NoteUid"))
        {
          _NoteUid = value; 
          RaisePropertyChanged("NoteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Binary Resource Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid BinaryResourceUid 
    { 
      get { return _BinaryResourceUid; }
      set 
      { 
        if(HasValueChanged(_BinaryResourceUid, value, "BinaryResourceUid"))
        {
          _BinaryResourceUid = value; 
          RaisePropertyChanged("BinaryResourceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Alarm Priority value
    /// </summary>
    
    [DataMember]
    
    public int AlarmPriority 
    { 
      get { return _AlarmPriority; }
      set 
      { 
        if(HasValueChanged(_AlarmPriority, value, "AlarmPriority"))
        {
          _AlarmPriority = value; 
          RaisePropertyChanged("AlarmPriority");
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
    /// Get/Set the Galaxy Panel Activity Event UidOld value
    /// </summary>
    
    public Guid GalaxyPanelActivityEventUidOld
    { 
      get { return _GalaxyPanelActivityEventUidOld; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelActivityEventUidOld, value, "GalaxyPanelActivityEventUid"))
        {
          _GalaxyPanelActivityEventUidOld = value; 
          RaisePropertyChanged("GalaxyPanelActivityEventUidOld");
        }
      } 
    }
    #endregion
  }
}
