using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GalaxyCpu_UpdateInformationPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GalaxyCpu_UpdateInformationPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _CpuUid = Guid.Empty;
    private string _SerialNumber = string.Empty;
    private string _IpAddress = string.Empty;
    private int _Model = 0;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
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
    /// Get/Set the Serial Number value
    /// </summary>
    
    [DataMember]
    
    public string SerialNumber 
    { 
      get { return _SerialNumber; }
      set 
      { 
        if(HasValueChanged(_SerialNumber, value, "@SerialNumber"))
        {
          _SerialNumber = value; 
          RaisePropertyChanged("SerialNumber");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Ip Address value
    /// </summary>
    
    [DataMember]
    
    public string IpAddress 
    { 
      get { return _IpAddress; }
      set 
      { 
        if(HasValueChanged(_IpAddress, value, "@IpAddress"))
        {
          _IpAddress = value; 
          RaisePropertyChanged("IpAddress");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Model value
    /// </summary>
    
    [DataMember]
    
    public int Model 
    { 
      get { return _Model; }
      set 
      { 
        if(HasValueChanged(_Model, value, "@Model"))
        {
          _Model = value; 
          RaisePropertyChanged("Model");
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
