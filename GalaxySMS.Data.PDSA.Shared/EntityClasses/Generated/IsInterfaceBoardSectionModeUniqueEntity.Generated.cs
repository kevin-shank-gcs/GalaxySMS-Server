using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsInterfaceBoardSectionModeUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsInterfaceBoardSectionModeUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
        private Guid _InterfaceBoardSectionModeUid = Guid.Empty;
    private Guid _InterfaceBoardTypeUid = Guid.Empty;
    private short _ModeCode = 0;
    private string _Description = string.Empty;
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
    /// Get/Set the Interface Board Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid InterfaceBoardTypeUid 
    { 
      get { return _InterfaceBoardTypeUid; }
      set 
      { 
        if(HasValueChanged(_InterfaceBoardTypeUid, value, "@InterfaceBoardTypeUid"))
        {
          _InterfaceBoardTypeUid = value; 
          RaisePropertyChanged("InterfaceBoardTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Mode Code value
    /// </summary>
    
    [DataMember]
    
    public short ModeCode 
    { 
      get { return _ModeCode; }
      set 
      { 
        if(HasValueChanged(_ModeCode, value, "@ModeCode"))
        {
          _ModeCode = value; 
          RaisePropertyChanged("ModeCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Description value
    /// </summary>
    
    [DataMember]
    
    public string Description 
    { 
      get { return _Description; }
      set 
      { 
        if(HasValueChanged(_Description, value, "@Description"))
        {
          _Description = value; 
          RaisePropertyChanged("Description");
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
