using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA Entity
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
    /// Clones the current IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA object</returns>
    public IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA object</returns>
    public IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA CloneEntity(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA entityToClone)
    {
      IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA newEntity = new IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeGalaxyTimePeriodUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_TimeScheduleDayTypeGalaxyTimePeriodUid_Header", "Time Schedule Day Type Galaxy Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_TimeScheduleDayTypeGalaxyTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_DayTypeUid_Header", "Day Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_DayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_GalaxyTimePeriodUid_Header", "Galaxy Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_GalaxyTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeGalaxyTimePeriodUid).Value = Entity.TimeScheduleDayTypeGalaxyTimePeriodUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).Value = Entity.DayTypeUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid).Value = Entity.GalaxyTimePeriodUid;
      this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeGalaxyTimePeriodUid).IsNull == false)
        Entity.TimeScheduleDayTypeGalaxyTimePeriodUid = this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeGalaxyTimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).IsNull == false)
        Entity.DayTypeUid = this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid).IsNull == false)
        Entity.GalaxyTimePeriodUid = this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA class.
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
    /// Returns '@TimeScheduleDayTypeGalaxyTimePeriodUid'
    /// </summary>
    public static string TimeScheduleDayTypeGalaxyTimePeriodUid = "@TimeScheduleDayTypeGalaxyTimePeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@GalaxyTimePeriodUid'
    /// </summary>
    public static string GalaxyTimePeriodUid = "@GalaxyTimePeriodUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeScheduleDayTypeGalaxyTimePeriodUid'
    /// </summary>
    public static string TimeScheduleDayTypeGalaxyTimePeriodUid = "@TimeScheduleDayTypeGalaxyTimePeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@GalaxyTimePeriodUid'
    /// </summary>
    public static string GalaxyTimePeriodUid = "@GalaxyTimePeriodUid";
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
