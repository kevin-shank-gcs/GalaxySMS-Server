using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimePeriodUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimePeriodUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimePeriodUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimePeriodUniquePDSA Entity
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
    /// Clones the current IsTimePeriodUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimePeriodUniquePDSA object</returns>
    public IsTimePeriodUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimePeriodUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimePeriodUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimePeriodUniquePDSA object</returns>
    public IsTimePeriodUniquePDSA CloneEntity(IsTimePeriodUniquePDSA entityToClone)
    {
      IsTimePeriodUniquePDSA newEntity = new IsTimePeriodUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_TimePeriodUid_Header", "Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.Name, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_Name_Header", "Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_Name_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            //props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.StartTime, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_StartTime_Header", "Start Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_StartTime_Req", PDSAValidationMessages.MustBeFilledIn), PDSAProperty.ConvertToTimeSpan("1753-01-01 00:00:00"), PDSAProperty.ConvertToTimeSpan("9999-12-31 23:59:59"), 0, DateTimeOffset.MinValue, @"", ""));
            //props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.EndTime, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_EndTime_Header", "End Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_EndTime_Req", PDSAValidationMessages.MustBeFilledIn), PDSAProperty.ConvertToTimeSpan("1753-01-01 00:00:00"), PDSAProperty.ConvertToTimeSpan("9999-12-31 23:59:59"), 0, DateTimeOffset.MinValue, @"", ""));
            props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.StartTime, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_StartTime_Header", "Start Time"), false, typeof(TimeSpan), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_StartTime_Req", PDSAValidationMessages.MustBeFilledIn), PDSAProperty.ConvertToTimeSpan("1753-01-01 00:00:00"), PDSAProperty.ConvertToTimeSpan("9999-12-31 23:59:59"), 0, DateTimeOffset.MinValue, @"", ""));
            props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.EndTime, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_EndTime_Header", "End Time"), false, typeof(TimeSpan), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_EndTime_Req", PDSAValidationMessages.MustBeFilledIn), PDSAProperty.ConvertToTimeSpan("1753-01-01 00:00:00"), PDSAProperty.ConvertToTimeSpan("9999-12-31 23:59:59"), 0, DateTimeOffset.MinValue, @"", ""));
            props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimePeriodUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.Name).Value = Entity.Name;
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.StartTime).Value = Entity.StartTime;
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.EndTime).Value = Entity.EndTime;
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.Name).IsNull == false)
        Entity.Name = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.Name).GetAsString();
      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.StartTime).IsNull == false)
        Entity.StartTime = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.StartTime).GetAsTimeSpan();
      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.EndTime).IsNull == false)
        Entity.EndTime = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.EndTime).GetAsTimeSpan();
      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimePeriodUniquePDSA class.
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
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Name'
    /// </summary>
    public static string Name = "@Name";
    /// <summary>
    /// Returns '@StartTime'
    /// </summary>
    public static string StartTime = "@StartTime";
    /// <summary>
    /// Returns '@EndTime'
    /// </summary>
    public static string EndTime = "@EndTime";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimePeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Name'
    /// </summary>
    public static string Name = "@Name";
    /// <summary>
    /// Returns '@StartTime'
    /// </summary>
    public static string StartTime = "@StartTime";
    /// <summary>
    /// Returns '@EndTime'
    /// </summary>
    public static string EndTime = "@EndTime";
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
