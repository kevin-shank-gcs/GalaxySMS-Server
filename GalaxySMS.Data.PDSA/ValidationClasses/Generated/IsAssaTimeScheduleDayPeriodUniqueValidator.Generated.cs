using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaTimeScheduleDayPeriodUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaTimeScheduleDayPeriodUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaTimeScheduleDayPeriodUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaTimeScheduleDayPeriodUniquePDSA Entity
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
    /// Clones the current IsAssaTimeScheduleDayPeriodUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaTimeScheduleDayPeriodUniquePDSA object</returns>
    public IsAssaTimeScheduleDayPeriodUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaTimeScheduleDayPeriodUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaTimeScheduleDayPeriodUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaTimeScheduleDayPeriodUniquePDSA object</returns>
    public IsAssaTimeScheduleDayPeriodUniquePDSA CloneEntity(IsAssaTimeScheduleDayPeriodUniquePDSA entityToClone)
    {
      IsAssaTimeScheduleDayPeriodUniquePDSA newEntity = new IsAssaTimeScheduleDayPeriodUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaTimeScheduleDayPeriodUid, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_AssaTimeScheduleDayPeriodUid_Header", "Assa Time Schedule Day Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_AssaTimeScheduleDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_AssaDayPeriodUid_Header", "Assa Day Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_AssaDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaTimeScheduleDayPeriodUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaTimeScheduleDayPeriodUid).Value = Entity.AssaTimeScheduleDayPeriodUid;
      this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).Value = Entity.AssaDayPeriodUid;
      this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaTimeScheduleDayPeriodUid).IsNull == false)
        Entity.AssaTimeScheduleDayPeriodUid = this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaTimeScheduleDayPeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).IsNull == false)
        Entity.AssaDayPeriodUid = this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaTimeScheduleDayPeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaTimeScheduleDayPeriodUniquePDSA class.
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
    /// Returns '@AssaTimeScheduleDayPeriodUid'
    /// </summary>
    public static string AssaTimeScheduleDayPeriodUid = "@AssaTimeScheduleDayPeriodUid";
    /// <summary>
    /// Returns '@AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "@AssaDayPeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaTimeScheduleDayPeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaTimeScheduleDayPeriodUid'
    /// </summary>
    public static string AssaTimeScheduleDayPeriodUid = "@AssaTimeScheduleDayPeriodUid";
    /// <summary>
    /// Returns '@AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "@AssaDayPeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
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
