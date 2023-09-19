using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsInputDeviceSupervisionTypeInterfaceBoardSectionModeUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsInputDeviceSupervisionTypeInterfaceBoardSectionModeUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _InputDeviceSupervisionTypeInterfaceBoardSectionModeUid = Guid.NewGuid();
    private Guid _InterfaceBoardSectionModeUid = Guid.NewGuid();
    private Guid _InputDeviceSupervisionTypeUid = Guid.NewGuid();
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
    /// Get/Set the Input Device Supervision Type Interface Board Section Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceSupervisionTypeInterfaceBoardSectionModeUid 
    { 
      get { return _InputDeviceSupervisionTypeInterfaceBoardSectionModeUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceSupervisionTypeInterfaceBoardSectionModeUid, value, "@InputDeviceSupervisionTypeInterfaceBoardSectionModeUid"))
        {
          _InputDeviceSupervisionTypeInterfaceBoardSectionModeUid = value; 
          RaisePropertyChanged("InputDeviceSupervisionTypeInterfaceBoardSectionModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Interface Board Section Mode Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InterfaceBoardSectionModeUid 
    { 
      get { return _InterfaceBoardSectionModeUid; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardSectionModeUid, value, "@InterfaceBoardSectionModeUid"))
        {
          _InterfaceBoardSectionModeUid = value; 
          RaisePropertyChanged("InterfaceBoardSectionModeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Input Device Supervision Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InputDeviceSupervisionTypeUid 
    { 
      get { return _InputDeviceSupervisionTypeUid; }
      set 
      { 
        if(HasValueChanged(_InputDeviceSupervisionTypeUid, value, "@InputDeviceSupervisionTypeUid"))
        {
          _InputDeviceSupervisionTypeUid = value; 
          RaisePropertyChanged("InputDeviceSupervisionTypeUid");
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
