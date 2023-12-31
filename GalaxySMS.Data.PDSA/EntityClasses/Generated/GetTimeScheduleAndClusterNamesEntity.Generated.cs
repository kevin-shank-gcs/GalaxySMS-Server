using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the GetTimeScheduleAndClusterNamesPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class GetTimeScheduleAndClusterNamesPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _TimeScheduleName = string.Empty;
    private string _ClusterName = string.Empty;
    private Guid _timeScheduleUid = Guid.Empty;
    private Guid _clusterUid = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Time Schedule Name value
    /// </summary>
    
    [DataMember]
    
    public string TimeScheduleName 
    { 
      get { return _TimeScheduleName; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleName, value, "TimeScheduleName"))
        {
          _TimeScheduleName = value; 
          RaisePropertyChanged("TimeScheduleName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Cluster Name value
    /// </summary>
    
    [DataMember]
    
    public string ClusterName 
    { 
      get { return _ClusterName; }
      set 
      { 
        if(HasValueChanged(_ClusterName, value, "ClusterName"))
        {
          _ClusterName = value; 
          RaisePropertyChanged("ClusterName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the time Schedule Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid timeScheduleUid 
    { 
      get { return _timeScheduleUid; }
      set 
      { 
        if(HasValueChanged(_timeScheduleUid, value, "@timeScheduleUid"))
        {
          _timeScheduleUid = value; 
          RaisePropertyChanged("timeScheduleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the cluster Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid clusterUid 
    { 
      get { return _clusterUid; }
      set 
      { 
        if(HasValueChanged(_clusterUid, value, "@clusterUid"))
        {
          _clusterUid = value; 
          RaisePropertyChanged("clusterUid");
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
