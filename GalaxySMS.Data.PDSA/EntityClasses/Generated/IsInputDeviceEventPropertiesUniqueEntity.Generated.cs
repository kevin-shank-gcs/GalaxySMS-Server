using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsInputDeviceEventPropertiesUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsInputDeviceEventPropertiesUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _InputDeviceEventPropertiesUid = Guid.Empty;
    private Guid _InputDeviceUid = Guid.Empty;
    private Guid _InputDeviceAlertEventTypeUid = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Result value
    /// </summary>
    
    [DataMember]
    
    public int Result 
    { 
      get { return _Result; }
      set 
      { 
        if(HasValueChanged(_Result, value, "Result"))
        {
          _Result = value; 
          RaisePropertyChanged("Result");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Event Properties Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceEventPropertiesUid 
    { 
      get { return _InputDeviceEventPropertiesUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceEventPropertiesUid, value, "@InputDeviceEventPropertiesUid"))
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
        if(HasValueChanged(_InputDeviceUid, value, "@InputDeviceUid"))
        {
          _InputDeviceUid = value; 
          RaisePropertyChanged("InputDeviceUid");
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
        if(HasValueChanged(_InputDeviceAlertEventTypeUid, value, "@InputDeviceAlertEventTypeUid"))
        {
          _InputDeviceAlertEventTypeUid = value; 
          RaisePropertyChanged("InputDeviceAlertEventTypeUid");
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
