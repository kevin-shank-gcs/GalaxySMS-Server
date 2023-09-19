using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the DateType_GetDayTypeInfoPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class DateType_GetDayTypeInfoPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _DayTypeUid = Guid.Empty;
    private string _Name = string.Empty;
    private Guid _EntityId = Guid.Empty;
    private DateTimeOffset _Date = DateTimeOffset.Now;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DayTypeUid 
    { 
      get { return _DayTypeUid; }
      set 
      { 
        if(HasValueChanged(_DayTypeUid, value, "DayTypeUid"))
        {
          _DayTypeUid = value; 
          RaisePropertyChanged("DayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Name value
    /// </summary>
    
    [DataMember]
    
    public string Name 
    { 
      get { return _Name; }
      set 
      { 
        if(HasValueChanged(_Name, value, "Name"))
        {
          _Name = value; 
          RaisePropertyChanged("Name");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Entity Id value
    /// </summary>
    
    [DataMember]
    
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
    /// Get/Set the Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset Date 
    { 
      get { return _Date; }
      set 
      { 
        if(HasValueChanged(_Date, value, "@Date"))
        {
          _Date = value; 
          RaisePropertyChanged("Date");
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
