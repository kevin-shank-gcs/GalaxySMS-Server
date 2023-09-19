using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GetTimeScheduleUidsForClusterPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GetTimeScheduleUidsForClusterPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _TimeScheduleUid = Guid.Empty;
    private Guid _uid = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid TimeScheduleUid 
    { 
      get { return _TimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleUid, value, "TimeScheduleUid"))
        {
          _TimeScheduleUid = value; 
          RaisePropertyChanged("TimeScheduleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the uid value
    /// </summary>
    
    [DataMember]
    
    public Guid uid 
    { 
      get { return _uid; }
      set 
      { 
        if(HasValueChanged(_uid, value, "@uid"))
        {
          _uid = value; 
          RaisePropertyChanged("uid");
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
