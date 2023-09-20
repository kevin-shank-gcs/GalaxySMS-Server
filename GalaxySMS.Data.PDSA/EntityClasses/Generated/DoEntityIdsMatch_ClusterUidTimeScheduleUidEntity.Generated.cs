using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class DoEntityIdsMatch_ClusterUidTimeScheduleUidPDSA : PDSAEntityBase
  {
    #region Private Variables
    private bool _Result = false;
    private Guid _ClusterUid = Guid.Empty;
    private Guid _TimeScheduleUid = Guid.Empty;
    private bool _PreventSystemEntityMatches = false;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Result value
    /// </summary>
    
    [DataMember]
    
    public bool Result 
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
    /// Get/Set the Cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ClusterUid 
    { 
      get { return _ClusterUid; }
      set 
      { 
        if(HasValueChanged(_ClusterUid, value, "@ClusterUid"))
        {
          _ClusterUid = value; 
          RaisePropertyChanged("ClusterUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid TimeScheduleUid 
    { 
      get { return _TimeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleUid, value, "@TimeScheduleUid"))
        {
          _TimeScheduleUid = value; 
          RaisePropertyChanged("TimeScheduleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Prevent System Entity Matches value
    /// </summary>
    
    [DataMember]
    
    public bool PreventSystemEntityMatches 
    { 
      get { return _PreventSystemEntityMatches; }
      set 
      { 
        if(HasValueChanged(_PreventSystemEntityMatches, value, "@PreventSystemEntityMatches"))
        {
          _PreventSystemEntityMatches = value; 
          RaisePropertyChanged("PreventSystemEntityMatches");
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
