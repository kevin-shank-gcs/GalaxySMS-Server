using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA : PDSAEntityBase
  {
    #region Private Variables
    private string _DataType = string.Empty;
    private Guid _Id = Guid.Empty;
    private string _Name = string.Empty;
    private Guid _DeviceUid = Guid.Empty;
    private string _DeviceName = string.Empty;
    private string _Type_x = string.Empty;
    private Guid _timeScheduleUid = Guid.Empty;
    private Guid _clusterUid = Guid.Empty;
    private int _RETURNVALUE = 0;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Data Type value
    /// </summary>
    
    [DataMember]
    
    public string DataType 
    { 
      get { return _DataType; }
      set 
      { 
        if(HasValueChanged(_DataType, value, "DataType"))
        {
          _DataType = value; 
          RaisePropertyChanged("DataType");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Id value
    /// </summary>
    
    [DataMember]
    
    public Guid Id 
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
    /// Get/Set the Device Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DeviceUid 
    { 
      get { return _DeviceUid; }
      set 
      { 
        if(HasValueChanged(_DeviceUid, value, "DeviceUid"))
        {
          _DeviceUid = value; 
          RaisePropertyChanged("DeviceUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Device Name value
    /// </summary>
    
    [DataMember]
    
    public string DeviceName 
    { 
      get { return _DeviceName; }
      set 
      { 
        if(HasValueChanged(_DeviceName, value, "DeviceName"))
        {
          _DeviceName = value; 
          RaisePropertyChanged("DeviceName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Type value
    /// </summary>
    
    [DataMember]
    
    public string Type_x 
    { 
      get { return _Type_x; }
      set 
      { 
        if(HasValueChanged(_Type_x, value, "Type"))
        {
          _Type_x = value; 
          RaisePropertyChanged("Type_x");
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
