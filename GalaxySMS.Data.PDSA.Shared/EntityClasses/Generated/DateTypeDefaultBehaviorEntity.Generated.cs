using System;
using System.ComponentModel;
using System.Runtime.Serialization;


using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value that makes up a DateTypeDefaultBehaviorPDSA.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class DateTypeDefaultBehaviorPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _DateTypeDefaultBehaviorUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private Guid _SundayDayTypeUid = Guid.Empty;
    private Guid _MondayDayTypeUid = Guid.Empty;
    private Guid _TuesdayDayTypeUid = Guid.Empty;
    private Guid _WednesdayDayTypeUid = Guid.Empty;
    private Guid _ThursdayDayTypeUid = Guid.Empty;
    private Guid _FridayDayTypeUid = Guid.Empty;
    private Guid _SaturdayDayTypeUid = Guid.Empty;
    private string _InsertName = string.Empty;
    private DateTimeOffset _InsertDate = DateTimeOffset.Now;
    private string _UpdateName = string.Empty;
    private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
    private short _ConcurrencyValue = 0;
    private Guid _DateTypeDefaultBehaviorUidOld = Guid.Empty;
    #endregion
    
    #region Public Properties
    /// <summary>
    /// Get/Set the Date Type Default Behavior Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid DateTypeDefaultBehaviorUid 
    { 
      get { return _DateTypeDefaultBehaviorUid; }
      set 
      { 
        if(HasValueChanged(_DateTypeDefaultBehaviorUid, value, "DateTypeDefaultBehaviorUid"))
        {
          _DateTypeDefaultBehaviorUid = value; 
          RaisePropertyChanged("DateTypeDefaultBehaviorUid");
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
        if(HasValueChanged(_EntityId, value, "EntityId"))
        {
          _EntityId = value; 
          RaisePropertyChanged("EntityId");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Sunday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid SundayDayTypeUid 
    { 
      get { return _SundayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_SundayDayTypeUid, value, "SundayDayTypeUid"))
        {
          _SundayDayTypeUid = value; 
          RaisePropertyChanged("SundayDayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Monday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid MondayDayTypeUid 
    { 
      get { return _MondayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_MondayDayTypeUid, value, "MondayDayTypeUid"))
        {
          _MondayDayTypeUid = value; 
          RaisePropertyChanged("MondayDayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tuesday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid TuesdayDayTypeUid 
    { 
      get { return _TuesdayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_TuesdayDayTypeUid, value, "TuesdayDayTypeUid"))
        {
          _TuesdayDayTypeUid = value; 
          RaisePropertyChanged("TuesdayDayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Wednesday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid WednesdayDayTypeUid 
    { 
      get { return _WednesdayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_WednesdayDayTypeUid, value, "WednesdayDayTypeUid"))
        {
          _WednesdayDayTypeUid = value; 
          RaisePropertyChanged("WednesdayDayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Thursday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid ThursdayDayTypeUid 
    { 
      get { return _ThursdayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_ThursdayDayTypeUid, value, "ThursdayDayTypeUid"))
        {
          _ThursdayDayTypeUid = value; 
          RaisePropertyChanged("ThursdayDayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Friday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid FridayDayTypeUid 
    { 
      get { return _FridayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_FridayDayTypeUid, value, "FridayDayTypeUid"))
        {
          _FridayDayTypeUid = value; 
          RaisePropertyChanged("FridayDayTypeUid");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Saturday Day Type Uid value
    /// </summary>
    
    [DataMember]
    
    public Guid SaturdayDayTypeUid 
    { 
      get { return _SaturdayDayTypeUid; }
      set 
      { 
        if(HasValueChanged(_SaturdayDayTypeUid, value, "SaturdayDayTypeUid"))
        {
          _SaturdayDayTypeUid = value; 
          RaisePropertyChanged("SaturdayDayTypeUid");
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
    /// Get/Set the Date Type Default Behavior UidOld value
    /// </summary>
    
    public Guid DateTypeDefaultBehaviorUidOld
    { 
      get { return _DateTypeDefaultBehaviorUidOld; }
      set 
      { 
        if(HasValueChanged(_DateTypeDefaultBehaviorUidOld, value, "DateTypeDefaultBehaviorUid"))
        {
          _DateTypeDefaultBehaviorUidOld = value; 
          RaisePropertyChanged("DateTypeDefaultBehaviorUidOld");
        }
      } 
    }
    #endregion
  }
}
