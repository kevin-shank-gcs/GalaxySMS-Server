using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _GalaxyPanelModelGalaxyPanelCommandUid = Guid.NewGuid();
    private Guid _GalaxyPanelCommandUid = Guid.Empty;
    private Guid _GalaxyPanelModelUid = Guid.Empty;
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
    /// Get/Set the Galaxy Panel Model Galaxy Panel Command Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelModelGalaxyPanelCommandUid 
    { 
      get { return _GalaxyPanelModelGalaxyPanelCommandUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelModelGalaxyPanelCommandUid, value, "@GalaxyPanelModelGalaxyPanelCommandUid"))
        {
          _GalaxyPanelModelGalaxyPanelCommandUid = value; 
          RaisePropertyChanged("GalaxyPanelModelGalaxyPanelCommandUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Command Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelCommandUid 
    { 
      get { return _GalaxyPanelCommandUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelCommandUid, value, "@GalaxyPanelCommandUid"))
        {
          _GalaxyPanelCommandUid = value; 
          RaisePropertyChanged("GalaxyPanelCommandUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Galaxy Panel Model Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyPanelModelUid 
    { 
      get { return _GalaxyPanelModelUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyPanelModelUid, value, "@GalaxyPanelModelUid"))
        {
          _GalaxyPanelModelUid = value; 
          RaisePropertyChanged("GalaxyPanelModelUid");
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
