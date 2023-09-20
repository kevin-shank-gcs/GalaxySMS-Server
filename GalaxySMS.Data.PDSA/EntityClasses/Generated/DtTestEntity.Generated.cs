using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a DtTestPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class DtTestPDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Id = 0;
    private DateTimeOffset _Dt = DateTimeOffset.Now;
    private DateTimeOffset _Dto = DateTimeOffset.Now;
    private DateTimeOffset _DtUtc = DateTimeOffset.Now;
    private DateTimeOffset _DtoUtc = DateTimeOffset.Now;
    private DateTimeOffset _CalculatedUtc = DateTimeOffset.Now;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Id value
    /// </summary>
    
    [DataMember]
    
    public int Id 
    { 
      get { return _Id; }
      set 
      { 
        if(HasValueChanged(_Id, value, "Id"))
        {
          _Id = value; 
          RaisePropertyChanged("Id");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dt value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset Dt 
    { 
      get { return _Dt; }
      set 
      { 
        if(HasValueChanged(_Dt, value, "Dt"))
        {
          _Dt = value; 
          RaisePropertyChanged("Dt");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dto value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset Dto 
    { 
      get { return _Dto; }
      set 
      { 
        if(HasValueChanged(_Dto, value, "Dto"))
        {
          _Dto = value; 
          RaisePropertyChanged("Dto");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dt Utc value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset DtUtc 
    { 
      get { return _DtUtc; }
      set 
      { 
        if(HasValueChanged(_DtUtc, value, "DtUtc"))
        {
          _DtUtc = value; 
          RaisePropertyChanged("DtUtc");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Dto Utc value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset DtoUtc 
    { 
      get { return _DtoUtc; }
      set 
      { 
        if(HasValueChanged(_DtoUtc, value, "DtoUtc"))
        {
          _DtoUtc = value; 
          RaisePropertyChanged("DtoUtc");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Calculated Utc value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset CalculatedUtc 
    { 
      get { return _CalculatedUtc; }
      set 
      { 
        if(HasValueChanged(_CalculatedUtc, value, "CalculatedUtc"))
        {
          _CalculatedUtc = value; 
          RaisePropertyChanged("CalculatedUtc");
        }
      } 
    }
        

    #endregion
  }
}
