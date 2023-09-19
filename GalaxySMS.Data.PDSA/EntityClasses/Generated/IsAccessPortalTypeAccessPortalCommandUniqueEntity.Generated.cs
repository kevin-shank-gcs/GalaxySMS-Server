using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessPortalTypeAccessPortalCommandUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessPortalTypeAccessPortalCommandUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _AccessPortalTypeAccessPortalCommandUid = Guid.Empty;
    private Guid _AccessPortalTypeUid = Guid.Empty;
    private Guid _AccessPortalCommandUid = Guid.Empty;
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
    /// Get/Set the Access Portal Type Access Portal Command Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalTypeAccessPortalCommandUid 
    { 
      get { return _AccessPortalTypeAccessPortalCommandUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalTypeAccessPortalCommandUid, value, "@AccessPortalTypeAccessPortalCommandUid"))
        {
          _AccessPortalTypeAccessPortalCommandUid = value; 
          RaisePropertyChanged("AccessPortalTypeAccessPortalCommandUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalTypeUid 
    { 
      get { return _AccessPortalTypeUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalTypeUid, value, "@AccessPortalTypeUid"))
        {
          _AccessPortalTypeUid = value; 
          RaisePropertyChanged("AccessPortalTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Access Portal Command Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalCommandUid 
    { 
      get { return _AccessPortalCommandUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalCommandUid, value, "@AccessPortalCommandUid"))
        {
          _AccessPortalCommandUid = value; 
          RaisePropertyChanged("AccessPortalCommandUid");
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
