using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the gcs_IsUserEntityUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcs_IsUserEntityUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _UserEntityId = Guid.NewGuid();
    private Guid _UserId = Guid.NewGuid();
    private Guid _EntityId = Guid.NewGuid();
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Result value
    /// </summary>
    
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
    /// Get/Set the User Entity Id value
    /// </summary>
    
    public Guid UserEntityId 
    { 
      get { return _UserEntityId; }
      set 
      { 
        if(HasValueChanged(_UserEntityId, value, "@UserEntityId"))
        {
          _UserEntityId = value; 
          RaisePropertyChanged("UserEntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the User Id value
    /// </summary>
    
    public Guid UserId 
    { 
      get { return _UserId; }
      set 
      { 
        if(HasValueChanged(_UserId, value, "@UserId"))
        {
          _UserId = value; 
          RaisePropertyChanged("UserId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Id value
    /// </summary>
    
    public Guid EntityId 
    { 
      get { return _EntityId; }
      set 
      { 
        if(HasValueChanged(_EntityId, value, "@EntityId"))
        {
          _EntityId = value; 
          RaisePropertyChanged("EntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the return value value
    /// </summary>
    
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
