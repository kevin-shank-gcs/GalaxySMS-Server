using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsBiometricSystemTypeUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsBiometricSystemTypeUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _BiometricSystemTypeUid = Guid.Empty;
    private string _Name = string.Empty;
    private string _TypeCode = string.Empty;
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
    /// Get/Set the Biometric System Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid BiometricSystemTypeUid 
    { 
      get { return _BiometricSystemTypeUid; }
      set 
      { 
        if(HasValueChanged(_BiometricSystemTypeUid, value, "@BiometricSystemTypeUid"))
        {
          _BiometricSystemTypeUid = value; 
          RaisePropertyChanged("BiometricSystemTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Name value
    /// </summary>
    
    [DataMember]
    
    public string Name 
    { 
      get { return _Name; }
      set 
      { 
        if(HasValueChanged(_Name, value, "@Name"))
        {
          _Name = value; 
          RaisePropertyChanged("Name");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Type Code value
    /// </summary>
    
    [DataMember]
    
    public string TypeCode 
    { 
      get { return _TypeCode; }
      set 
      { 
        if(HasValueChanged(_TypeCode, value, "@TypeCode"))
        {
          _TypeCode = value; 
          RaisePropertyChanged("TypeCode");
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
