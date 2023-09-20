using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsAccessPortalNoServerReplyBehaviorUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsAccessPortalNoServerReplyBehaviorUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _AccessPortalNoServerReplyBehaviorUid = Guid.NewGuid();
    private string _Display = string.Empty;
    private short _Code = 0;
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
    /// Get/Set the Access Portal No Server Reply Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid AccessPortalNoServerReplyBehaviorUid 
    { 
      get { return _AccessPortalNoServerReplyBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_AccessPortalNoServerReplyBehaviorUid, value, "@AccessPortalNoServerReplyBehaviorUid"))
        {
          _AccessPortalNoServerReplyBehaviorUid = value; 
          RaisePropertyChanged("AccessPortalNoServerReplyBehaviorUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Display value
    /// </summary>
    
    [DataMember]
    
    public string Display 
    { 
      get { return _Display; }
      set 
      { 
        if(HasValueChanged(_Display, value, "@Display"))
        {
          _Display = value; 
          RaisePropertyChanged("Display");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Code value
    /// </summary>
    
    [DataMember]
    
    public short Code 
    { 
      get { return _Code; }
      set 
      { 
        if(HasValueChanged(_Code, value, "@Code"))
        {
          _Code = value; 
          RaisePropertyChanged("Code");
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
