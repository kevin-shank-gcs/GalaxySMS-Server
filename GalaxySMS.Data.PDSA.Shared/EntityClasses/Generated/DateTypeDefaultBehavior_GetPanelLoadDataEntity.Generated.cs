using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
  /// <summary>
  /// This class contains properties for each data value returned, or parameter to be input/output from the DateTypeDefaultBehavior_GetPanelLoadDataPDSA stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
  /// </summary>
  
  public partial class DateTypeDefaultBehavior_GetPanelLoadDataPDSA : PDSAEntityBase
  {
    #region Private Variables
    private Guid _DateTypeDefaultBehaviorUid = Guid.Empty;
    private Guid _EntityId = Guid.Empty;
    private string _EntityName = string.Empty;
    private short _SundayDayCode = 0;
    private short _MondayDayCode = 0;
    private short _TuesdayDayCode = 0;
    private short _WednesdayDayCode = 0;
    private short _ThursdayDayCode = 0;
    private short _FridayDayCode = 0;
    private short _SaturdayDayCode = 0;
    private int _RETURNVALUE = 0;
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
    /// Get/Set the Entity Name value
    /// </summary>
    
    [DataMember]
    
    public string EntityName 
    { 
      get { return _EntityName; }
      set 
      { 
        if(HasValueChanged(_EntityName, value, "EntityName"))
        {
          _EntityName = value; 
          RaisePropertyChanged("EntityName");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Sunday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short SundayDayCode 
    { 
      get { return _SundayDayCode; }
      set 
      { 
        if(HasValueChanged(_SundayDayCode, value, "SundayDayCode"))
        {
          _SundayDayCode = value; 
          RaisePropertyChanged("SundayDayCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Monday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short MondayDayCode 
    { 
      get { return _MondayDayCode; }
      set 
      { 
        if(HasValueChanged(_MondayDayCode, value, "MondayDayCode"))
        {
          _MondayDayCode = value; 
          RaisePropertyChanged("MondayDayCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Tuesday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short TuesdayDayCode 
    { 
      get { return _TuesdayDayCode; }
      set 
      { 
        if(HasValueChanged(_TuesdayDayCode, value, "TuesdayDayCode"))
        {
          _TuesdayDayCode = value; 
          RaisePropertyChanged("TuesdayDayCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Wednesday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short WednesdayDayCode 
    { 
      get { return _WednesdayDayCode; }
      set 
      { 
        if(HasValueChanged(_WednesdayDayCode, value, "WednesdayDayCode"))
        {
          _WednesdayDayCode = value; 
          RaisePropertyChanged("WednesdayDayCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Thursday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short ThursdayDayCode 
    { 
      get { return _ThursdayDayCode; }
      set 
      { 
        if(HasValueChanged(_ThursdayDayCode, value, "ThursdayDayCode"))
        {
          _ThursdayDayCode = value; 
          RaisePropertyChanged("ThursdayDayCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Friday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short FridayDayCode 
    { 
      get { return _FridayDayCode; }
      set 
      { 
        if(HasValueChanged(_FridayDayCode, value, "FridayDayCode"))
        {
          _FridayDayCode = value; 
          RaisePropertyChanged("FridayDayCode");
        }
      } 
    }
        
    /// <summary>
    /// Get/Set the Saturday Day Code value
    /// </summary>
    
    [DataMember]
    
    public short SaturdayDayCode 
    { 
      get { return _SaturdayDayCode; }
      set 
      { 
        if(HasValueChanged(_SaturdayDayCode, value, "SaturdayDayCode"))
        {
          _SaturdayDayCode = value; 
          RaisePropertyChanged("SaturdayDayCode");
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
