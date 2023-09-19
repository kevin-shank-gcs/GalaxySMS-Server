using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _GalaxyOutputDeviceInputSourceAssignmentUid = Guid.Empty;
    private Guid _GalaxyOutputDeviceInputSourceUid = Guid.Empty;
    private Guid _InputOutputGroupAssignmentUid = Guid.Empty;
    private short _OffsetIndex = 0;
    private string _DeviceName = string.Empty;
    private string _EventType = string.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Galaxy Output Device Input Source Assignment Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyOutputDeviceInputSourceAssignmentUid 
    { 
      get { return _GalaxyOutputDeviceInputSourceAssignmentUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputDeviceInputSourceAssignmentUid, value, "GalaxyOutputDeviceInputSourceAssignmentUid"))
        {
          _GalaxyOutputDeviceInputSourceAssignmentUid = value; 
          RaisePropertyChanged("GalaxyOutputDeviceInputSourceAssignmentUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Output Device Input Source Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyOutputDeviceInputSourceUid 
    { 
      get { return _GalaxyOutputDeviceInputSourceUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputDeviceInputSourceUid, value, "GalaxyOutputDeviceInputSourceUid"))
        {
          _GalaxyOutputDeviceInputSourceUid = value; 
          RaisePropertyChanged("GalaxyOutputDeviceInputSourceUid");
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
    /// Get/Set the Offset Index value
    /// </summary>
    
    [DataMember]
    
    public short OffsetIndex 
    { 
      get { return _OffsetIndex; }
      set 
      { 
        if(HasValueChanged(_OffsetIndex, value, "OffsetIndex"))
        {
          _OffsetIndex = value; 
          RaisePropertyChanged("OffsetIndex");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Name value
    /// </summary>
    
    [DataMember]
    
    public string DeviceName 
    { 
      get { return _DeviceName; }
      set 
      { 
        if(HasValueChanged(_DeviceName, value, "DeviceName"))
        {
          _DeviceName = value; 
          RaisePropertyChanged("DeviceName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Event Type value
    /// </summary>
    
    [DataMember]
    
    public string EventType 
    { 
      get { return _EventType; }
      set 
      { 
        if(HasValueChanged(_EventType, value, "EventType"))
        {
          _EventType = value; 
          RaisePropertyChanged("EventType");
        }
      } 
    }
        

    #endregion
  }
}
