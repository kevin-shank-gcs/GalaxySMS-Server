using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the TimeSchedule_IsScheduleActivePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimeSchedule_IsScheduleActivePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimeSchedule_IsScheduleActivePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimeSchedule_IsScheduleActivePDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
  
    #region Clone Entity Class
    /// <summary>
    /// Clones the current TimeSchedule_IsScheduleActivePDSA
    /// </summary>
    /// <returns>A cloned TimeSchedule_IsScheduleActivePDSA object</returns>
    public TimeSchedule_IsScheduleActivePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimeSchedule_IsScheduleActivePDSA
    /// </summary>
    /// <param name="entityToClone">The TimeSchedule_IsScheduleActivePDSA entity to clone</param>
    /// <returns>A cloned TimeSchedule_IsScheduleActivePDSA object</returns>
    public TimeSchedule_IsScheduleActivePDSA CloneEntity(TimeSchedule_IsScheduleActivePDSA entityToClone)
    {
      TimeSchedule_IsScheduleActivePDSA newEntity = new TimeSchedule_IsScheduleActivePDSA();

      newEntity.IsActive = entityToClone.IsActive;

      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ScheduleTypeCode, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_ScheduleTypeCode_Header", "Schedule Type Code"), false, typeof(short), 0, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_ScheduleTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.dt, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_dt_Header", "dt"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_dt_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.result, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_result_Header", "result"), false, typeof(bool), 0, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_result_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_TimeSchedule_IsScheduleActivePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ScheduleTypeCode).Value = Entity.ScheduleTypeCode;
      this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.dt).Value = Entity.dt;
      this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.result).Value = Entity.result;
      this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ScheduleTypeCode).IsNull == false)
        Entity.ScheduleTypeCode = this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ScheduleTypeCode).GetAsShort();
      if(this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.dt).IsNull == false)
        Entity.dt = this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.dt).GetAsDateTimeOffset();
      if(this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.result).IsNull == false)
        Entity.result = this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.result).GetAsBool();
      if(this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(TimeSchedule_IsScheduleActivePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_IsScheduleActivePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "@ScheduleTypeCode";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@dt'
    /// </summary>
    public static string dt = "@dt";
    /// <summary>
    /// Returns '@result'
    /// </summary>
    public static string result = "@result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_IsScheduleActivePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "@ScheduleTypeCode";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@dt'
    /// </summary>
    public static string dt = "@dt";
    /// <summary>
    /// Returns '@result'
    /// </summary>
    public static string result = "@result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
