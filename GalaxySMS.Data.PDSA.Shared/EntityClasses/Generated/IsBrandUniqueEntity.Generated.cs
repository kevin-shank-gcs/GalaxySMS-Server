using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsBrandUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsBrandUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _BrandUid = Guid.NewGuid();
    private string _BrandName = string.Empty;
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
    /// Get/Set the Brand Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid BrandUid 
    { 
      get { return _BrandUid; }
      set 
      { 
        if(HasValueChanged(_BrandUid, value, "@BrandUid"))
        {
          _BrandUid = value; 
          RaisePropertyChanged("BrandUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Brand Name value
    /// </summary>
    
    [DataMember]
    
    public string BrandName 
    { 
      get { return _BrandName; }
      set 
      { 
        if(HasValueChanged(_BrandName, value, "@BrandName"))
        {
          _BrandName = value; 
          RaisePropertyChanged("BrandName");
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
