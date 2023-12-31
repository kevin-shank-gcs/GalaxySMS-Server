using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a TimeScheduleDayTypeTimePeriodPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class TimeScheduleDayTypeTimePeriodPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _TimeScheduleDayTypeTimePeriodUid = Guid.Empty;
    private Guid _DayTypeUid = Guid.Empty;
    private Guid _TimePeriodUid = Guid.Empty;
    private Guid _TimeScheduleUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _TimeScheduleDayTypeTimePeriodUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Time Schedule Day Type Time Period Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid TimeScheduleDayTypeTimePeriodUid 
    { 
      get { return _TimeScheduleDayTypeTimePeriodUid; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleDayTypeTimePeriodUid, value, "TimeScheduleDayTypeTimePeriodUid"))
        {
          _TimeScheduleDayTypeTimePeriodUid = value; 
          RaisePropertyChanged("TimeScheduleDayTypeTimePeriodUid");
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
        if(HasValueChanged(_DayTypeUid, value, "DayTypeUid"))
        {
          _DayTypeUid = value; 
          RaisePropertyChanged("DayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Time Period Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid TimePeriodUid 
    { 
      get { return _TimePeriodUid; }
      set 
      { 
        if(HasValueChanged(_TimePeriodUid, value, "TimePeriodUid"))
        {
          _TimePeriodUid = value; 
          RaisePropertyChanged("TimePeriodUid");
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
        if(HasValueChanged(_TimeScheduleUid, value, "TimeScheduleUid"))
        {
          _TimeScheduleUid = value; 
          RaisePropertyChanged("TimeScheduleUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Name value
    /// </summary>
    
    [DataMember]
    
    public string InsertName 
    { 
      get { return _InsertName; }
      set 
      { 
        if(HasValueChanged(_InsertName, value, "InsertName"))
        {
          _InsertName = value; 
          RaisePropertyChanged("InsertName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Insert Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset InsertDate 
    { 
      get { return _InsertDate; }
      set 
      { 
        if(HasValueChanged(_InsertDate, value, "InsertDate"))
        {
          _InsertDate = value; 
          RaisePropertyChanged("InsertDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Name value
    /// </summary>
    
    [DataMember]
    
    public string UpdateName 
    { 
      get { return _UpdateName; }
      set 
      { 
        if(HasValueChanged(_UpdateName, value, "UpdateName"))
        {
          _UpdateName = value; 
          RaisePropertyChanged("UpdateName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Update Date value
    /// </summary>
    
    [DataMember]
    
    public DateTimeOffset UpdateDate 
    { 
      get { return _UpdateDate; }
      set 
      { 
        if(HasValueChanged(_UpdateDate, value, "UpdateDate"))
        {
          _UpdateDate = value; 
          RaisePropertyChanged("UpdateDate");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Concurrency Value value
    /// </summary>
    
    [DataMember]
    
    public short ConcurrencyValue 
    { 
      get { return _ConcurrencyValue; }
      set 
      { 
        if(HasValueChanged(_ConcurrencyValue, value, "ConcurrencyValue"))
        {
          _ConcurrencyValue = value; 
          RaisePropertyChanged("ConcurrencyValue");
        }
      } 
    }
        

        /// <summary>
    /// Get/Set the Time Schedule Day Type Time Period UidOld value
    /// </summary>
    
    public Guid TimeScheduleDayTypeTimePeriodUidOld
    { 
      get { return _TimeScheduleDayTypeTimePeriodUidOld; }
      set 
      { 
        if(HasValueChanged(_TimeScheduleDayTypeTimePeriodUidOld, value, "TimeScheduleDayTypeTimePeriodUid"))
        {
          _TimeScheduleDayTypeTimePeriodUidOld = value; 
          RaisePropertyChanged("TimeScheduleDayTypeTimePeriodUidOld");
        }
      } 
    }
    #endregion
  }
}
