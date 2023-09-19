using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimeScheduleDayTypeTimePeriodUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimeScheduleDayTypeTimePeriodUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimeScheduleDayTypeTimePeriodUniquePDSA Entity
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
    /// Clones the current IsTimeScheduleDayTypeTimePeriodUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimeScheduleDayTypeTimePeriodUniquePDSA object</returns>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimeScheduleDayTypeTimePeriodUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimeScheduleDayTypeTimePeriodUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimeScheduleDayTypeTimePeriodUniquePDSA object</returns>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSA CloneEntity(IsTimeScheduleDayTypeTimePeriodUniquePDSA entityToClone)
    {
      IsTimeScheduleDayTypeTimePeriodUniquePDSA newEntity = new IsTimeScheduleDayTypeTimePeriodUniquePDSA();

      newEntity.Result = entityToClone.Result;

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
      
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_TimeScheduleDayTypeTimePeriodUid_Header", "Time Schedule Day Type Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_TimeScheduleDayTypeTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_DayTypeUid_Header", "Day Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_DayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_TimePeriodUid_Header", "Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid).Value = Entity.TimeScheduleDayTypeTimePeriodUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).Value = Entity.DayTypeUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid).IsNull == false)
        Entity.TimeScheduleDayTypeTimePeriodUid = this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).IsNull == false)
        Entity.DayTypeUid = this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleDayTypeTimePeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@TimeScheduleDayTypeTimePeriodUid'
    /// </summary>
    public static string TimeScheduleDayTypeTimePeriodUid = "@TimeScheduleDayTypeTimePeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleDayTypeTimePeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeScheduleDayTypeTimePeriodUid'
    /// </summary>
    public static string TimeScheduleDayTypeTimePeriodUid = "@TimeScheduleDayTypeTimePeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
