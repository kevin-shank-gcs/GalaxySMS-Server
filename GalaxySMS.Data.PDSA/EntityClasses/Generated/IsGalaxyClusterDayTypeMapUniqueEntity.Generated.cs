using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the IsGalaxyClusterDayTypeMapUniquePDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class IsGalaxyClusterDayTypeMapUniquePDSA : PDSAEntityBase
  {
    #region Private Variables
    private int _Result = 0;
    private Guid _GalaxyClusterDayTypeMapUid = Guid.NewGuid();
    private Guid _DayTypeUid = Guid.NewGuid();
    private Guid _ClusterUid = Guid.NewGuid();
    private int _PanelDayTypeNumber = 0;
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
    /// Get/Set the Galaxy Cluster Day Type Map Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid GalaxyClusterDayTypeMapUid 
    { 
      get { return _GalaxyClusterDayTypeMapUid; }
      set 
      { 
        if(HasValueChanged(_GalaxyClusterDayTypeMapUid, value, "@GalaxyClusterDayTypeMapUid"))
        {
          _GalaxyClusterDayTypeMapUid = value; 
          RaisePropertyChanged("GalaxyClusterDayTypeMapUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DayTypeUid 
    { 
      get { return _DayTypeUid; }
      set 
      { 
        if(HasValueChanged(_DayTypeUid, value, "@DayTypeUid"))
        {
          _DayTypeUid = value; 
          RaisePropertyChanged("DayTypeUid");
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
    /// Get/Set the Panel Day Type Number value
    /// </summary>
    
    [DataMember]
    
    public int PanelDayTypeNumber 
    { 
      get { return _PanelDayTypeNumber; }
      set 
      { 
        if(HasValueChanged(_PanelDayTypeNumber, value, "@PanelDayTypeNumber"))
        {
          _PanelDayTypeNumber = value; 
          RaisePropertyChanged("PanelDayTypeNumber");
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
