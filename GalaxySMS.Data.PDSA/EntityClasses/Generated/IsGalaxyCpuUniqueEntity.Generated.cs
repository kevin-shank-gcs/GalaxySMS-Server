using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsGalaxyCpuUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsGalaxyCpuUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _CpuUid = Guid.NewGuid();
    private Guid _GalaxyPanelUid = Guid.NewGuid();
    private short _CpuNumber = 0;
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
    /// Get/Set the Cpu Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid CpuUid 
    { 
      get { return _CpuUid; }
      set 
      { 
        if(HasValueChanged(_CpuUid, value, "@CpuUid"))
        {
          _CpuUid = value; 
          RaisePropertyChanged("CpuUid");
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
        if(HasValueChanged(_GalaxyPanelUid, value, "@GalaxyPanelUid"))
        {
          _GalaxyPanelUid = value; 
          RaisePropertyChanged("GalaxyPanelUid");
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
