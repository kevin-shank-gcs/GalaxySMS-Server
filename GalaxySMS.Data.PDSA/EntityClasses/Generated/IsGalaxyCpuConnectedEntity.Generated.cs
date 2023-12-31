using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsGalaxyCpuConnectedPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsGalaxyCpuConnectedPDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _IsConnected = 0;
    private Guid _cpuUid = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Is Connected value
    /// </summary>
    
    [DataMember]
    
    public int IsConnected 
    { 
      get { return _IsConnected; }
      set 
      { 
        if(HasValueChanged(_IsConnected, value, "IsConnected"))
        {
          _IsConnected = value; 
          RaisePropertyChanged("IsConnected");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid cpuUid 
    { 
      get { return _cpuUid; }
      set 
      { 
        if(HasValueChanged(_cpuUid, value, "@cpuUid"))
        {
          _cpuUid = value; 
          RaisePropertyChanged("cpuUid");
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
