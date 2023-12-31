using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsLiquidCrystalDisplayUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsLiquidCrystalDisplayUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _LiquidCrystalDisplayUid = Guid.Empty;
    private Guid _SiteUid = Guid.Empty;
    private string _LcdName = string.Empty;
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
    /// Get/Set the Liquid Crystal Display Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid LiquidCrystalDisplayUid 
    { 
      get { return _LiquidCrystalDisplayUid; }
      set 
      { 
        if(HasValueChanged(_LiquidCrystalDisplayUid, value, "@LiquidCrystalDisplayUid"))
        {
          _LiquidCrystalDisplayUid = value; 
          RaisePropertyChanged("LiquidCrystalDisplayUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Site Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid SiteUid 
    { 
      get { return _SiteUid; }
      set 
      { 
        if(HasValueChanged(_SiteUid, value, "@SiteUid"))
        {
          _SiteUid = value; 
          RaisePropertyChanged("SiteUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Lcd Name value
    /// </summary>
    
    [DataMember]
    
    public string LcdName 
    { 
      get { return _LcdName; }
      set 
      { 
        if(HasValueChanged(_LcdName, value, "@LcdName"))
        {
          _LcdName = value; 
          RaisePropertyChanged("LcdName");
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
