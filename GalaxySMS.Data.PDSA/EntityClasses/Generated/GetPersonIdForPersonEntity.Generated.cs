using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GetPersonIdForPersonPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GetPersonIdForPersonPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _PersonId = string.Empty;
    private Guid _personUid = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Person Id value
    /// </summary>
    
    [DataMember]
    
    public string PersonId 
    { 
      get { return _PersonId; }
      set 
      { 
        if(HasValueChanged(_PersonId, value, "PersonId"))
        {
          _PersonId = value; 
          RaisePropertyChanged("PersonId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the person Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid personUid 
    { 
      get { return _personUid; }
      set 
      { 
        if(HasValueChanged(_personUid, value, "@personUid"))
        {
          _personUid = value; 
          RaisePropertyChanged("personUid");
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
