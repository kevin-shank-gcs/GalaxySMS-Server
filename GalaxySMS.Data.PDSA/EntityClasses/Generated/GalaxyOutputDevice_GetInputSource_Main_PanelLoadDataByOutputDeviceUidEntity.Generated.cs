using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _OutputDeviceUid = Guid.Empty;
    private Guid _GalaxyOutputDeviceInputSourceUid = Guid.Empty;
    private Guid _GalaxyOutputInputSourceTriggerConditionUid = Guid.Empty;
    private Guid _GalaxyOutputInputSourceModeUid = Guid.Empty;
    private Guid _InputOutputGroupUid = Guid.Empty;
    private short _SourceNumber = 0;
    private bool _InputOutputGroupMode = false;
    private short _TriggerConditionCode = 0;
    private string _TriggerConditionDisplay = string.Empty;
    private short _SourceModeCode = 0;
    private string _SourceModeDisplay = string.Empty;
    private int _IOGroupNumber = 0;
    private string _IOGroupDisplay = string.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Output Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid OutputDeviceUid 
    { 
      get { return _OutputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceUid, value, "OutputDeviceUid"))
        {
          _OutputDeviceUid = value; 
          RaisePropertyChanged("OutputDeviceUid");
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
    /// Get/Set the Galaxy Output Input Source Trigger Condition Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyOutputInputSourceTriggerConditionUid 
    { 
      get { return _GalaxyOutputInputSourceTriggerConditionUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputInputSourceTriggerConditionUid, value, "GalaxyOutputInputSourceTriggerConditionUid"))
        {
          _GalaxyOutputInputSourceTriggerConditionUid = value; 
          RaisePropertyChanged("GalaxyOutputInputSourceTriggerConditionUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Output Input Source Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyOutputInputSourceModeUid 
    { 
      get { return _GalaxyOutputInputSourceModeUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyOutputInputSourceModeUid, value, "GalaxyOutputInputSourceModeUid"))
        {
          _GalaxyOutputInputSourceModeUid = value; 
          RaisePropertyChanged("GalaxyOutputInputSourceModeUid");
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
    /// Get/Set the Source Number value
    /// </summary>
    
    [DataMember]
    
    public short SourceNumber 
    { 
      get { return _SourceNumber; }
      set 
      { 
        if(HasValueChanged(_SourceNumber, value, "SourceNumber"))
        {
          _SourceNumber = value; 
          RaisePropertyChanged("SourceNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Output Group Mode value
    /// </summary>
    
    [DataMember]
    
    public bool InputOutputGroupMode 
    { 
      get { return _InputOutputGroupMode; }
      set 
      { 
        if(HasValueChanged(_InputOutputGroupMode, value, "InputOutputGroupMode"))
        {
          _InputOutputGroupMode = value; 
          RaisePropertyChanged("InputOutputGroupMode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Trigger Condition Code value
    /// </summary>
    
    [DataMember]
    
    public short TriggerConditionCode 
    { 
      get { return _TriggerConditionCode; }
      set 
      { 
        if(HasValueChanged(_TriggerConditionCode, value, "TriggerConditionCode"))
        {
          _TriggerConditionCode = value; 
          RaisePropertyChanged("TriggerConditionCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Trigger Condition Display value
    /// </summary>
    
    [DataMember]
    
    public string TriggerConditionDisplay 
    { 
      get { return _TriggerConditionDisplay; }
      set 
      { 
        if(HasValueChanged(_TriggerConditionDisplay, value, "TriggerConditionDisplay"))
        {
          _TriggerConditionDisplay = value; 
          RaisePropertyChanged("TriggerConditionDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Source Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short SourceModeCode 
    { 
      get { return _SourceModeCode; }
      set 
      { 
        if(HasValueChanged(_SourceModeCode, value, "SourceModeCode"))
        {
          _SourceModeCode = value; 
          RaisePropertyChanged("SourceModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Source Mode Display value
    /// </summary>
    
    [DataMember]
    
    public string SourceModeDisplay 
    { 
      get { return _SourceModeDisplay; }
      set 
      { 
        if(HasValueChanged(_SourceModeDisplay, value, "SourceModeDisplay"))
        {
          _SourceModeDisplay = value; 
          RaisePropertyChanged("SourceModeDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the IO Group Number value
    /// </summary>
    
    [DataMember]
    
    public int IOGroupNumber 
    { 
      get { return _IOGroupNumber; }
      set 
      { 
        if(HasValueChanged(_IOGroupNumber, value, "IOGroupNumber"))
        {
          _IOGroupNumber = value; 
          RaisePropertyChanged("IOGroupNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the IO Group Display value
    /// </summary>
    
    [DataMember]
    
    public string IOGroupDisplay 
    { 
      get { return _IOGroupDisplay; }
      set 
      { 
        if(HasValueChanged(_IOGroupDisplay, value, "IOGroupDisplay"))
        {
          _IOGroupDisplay = value; 
          RaisePropertyChanged("IOGroupDisplay");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
    [DataMember]
    
    public int RETURNVALUE 
    { 
      get { return _RETURNVALUE; }
      set 
      { 
        if(HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
        {
          _RETURNVALUE = value; 
          RaisePropertyChanged("RETURNVALUE");
        }
      } 
    }
        

    #endregion
  }
}
