using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the gcs_IsApplicationUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class gcs_IsApplicationUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _ApplicationId = Guid.NewGuid();
    private string _ApplicationName = string.Empty;
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
    /// Get/Set the Application Id value
    /// </summary>
    
    public Guid ApplicationId 
    { 
      get { return _ApplicationId; }
      set 
      { 
        if(HasValueChanged(_ApplicationId, value, "@ApplicationId"))
        {
          _ApplicationId = value; 
          RaisePropertyChanged("ApplicationId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Application Name value
    /// </summary>
    
    public string ApplicationName 
    { 
      get { return _ApplicationName; }
      set 
      { 
        if(HasValueChanged(_ApplicationName, value, "@ApplicationName"))
        {
          _ApplicationName = value; 
          RaisePropertyChanged("ApplicationName");
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
