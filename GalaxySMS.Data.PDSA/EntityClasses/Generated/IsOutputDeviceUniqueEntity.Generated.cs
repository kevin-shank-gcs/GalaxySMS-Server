using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsOutputDeviceUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsOutputDeviceUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _OutputDeviceUid = Guid.NewGuid();
    private Guid _SiteUid = Guid.NewGuid();
    private string _OutputName = string.Empty;
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
    /// Get/Set the Output Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid OutputDeviceUid 
    { 
      get { return _OutputDeviceUid; }
      set 
      { 
        if(HasValueChanged(_OutputDeviceUid, value, "@OutputDeviceUid"))
        {
          _OutputDeviceUid = value; 
          RaisePropertyChanged("OutputDeviceUid");
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
    /// Get/Set the Output Name value
    /// </summary>
    
    [DataMember]
    
    public string OutputName 
    { 
      get { return _OutputName; }
      set 
      { 
        if(HasValueChanged(_OutputName, value, "@OutputName"))
        {
          _OutputName = value; 
          RaisePropertyChanged("OutputName");
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
