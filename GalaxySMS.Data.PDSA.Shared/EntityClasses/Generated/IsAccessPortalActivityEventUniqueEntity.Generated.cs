using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessPortalActivityEventUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessPortalActivityEventUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private short _CpuNumber = 0;
    private DateTimeOffset _ActivityDateTime = DateTimeOffset.Now;
    private int _BufferIndex = 0;
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
    /// Get/Set the Cpu Number value
    /// </summary>
    
    [DataMember]
    
    public short CpuNumber 
    { 
      get { return _CpuNumber; }
      set 
      { 
        if(HasValueChanged(_CpuNumber, value, "@CpuNumber"))
        {
          _CpuNumber = value; 
          RaisePropertyChanged("CpuNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Activity Date Time value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset ActivityDateTime 
    { 
      get { return _ActivityDateTime; }
      set 
      { 
        if(HasValueChanged(_ActivityDateTime, value, "@ActivityDateTime"))
        {
          _ActivityDateTime = value; 
          RaisePropertyChanged("ActivityDateTime");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Buffer Index value
    /// </summary>
    
    [DataMember]
    
    public int BufferIndex 
    { 
      get { return _BufferIndex; }
      set 
      { 
        if(HasValueChanged(_BufferIndex, value, "@BufferIndex"))
        {
          _BufferIndex = value; 
          RaisePropertyChanged("BufferIndex");
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
