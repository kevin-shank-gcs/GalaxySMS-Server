using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaDayPeriodTimePeriodUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaDayPeriodTimePeriodUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaDayPeriodTimePeriodUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaDayPeriodTimePeriodUniquePDSA Entity
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
    /// Clones the current IsAssaDayPeriodTimePeriodUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaDayPeriodTimePeriodUniquePDSA object</returns>
    public IsAssaDayPeriodTimePeriodUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaDayPeriodTimePeriodUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaDayPeriodTimePeriodUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaDayPeriodTimePeriodUniquePDSA object</returns>
    public IsAssaDayPeriodTimePeriodUniquePDSA CloneEntity(IsAssaDayPeriodTimePeriodUniquePDSA entityToClone)
    {
      IsAssaDayPeriodTimePeriodUniquePDSA newEntity = new IsAssaDayPeriodTimePeriodUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodTimePeriodUid, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_AssaDayPeriodTimePeriodUid_Header", "Assa Day Period Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_AssaDayPeriodTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_AssaDayPeriodUid_Header", "Assa Day Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_AssaDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_TimePeriodUid_Header", "Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDayPeriodTimePeriodUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodTimePeriodUid).Value = Entity.AssaDayPeriodTimePeriodUid;
      this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).Value = Entity.AssaDayPeriodUid;
      this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodTimePeriodUid).IsNull == false)
        Entity.AssaDayPeriodTimePeriodUid = this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodTimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).IsNull == false)
        Entity.AssaDayPeriodUid = this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaDayPeriodTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDayPeriodTimePeriodUniquePDSA class.
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
    /// Returns '@AssaDayPeriodTimePeriodUid'
    /// </summary>
    public static string AssaDayPeriodTimePeriodUid = "@AssaDayPeriodTimePeriodUid";
    /// <summary>
    /// Returns '@AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "@AssaDayPeriodUid";
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
    /// Contains static string properties that represent the name of each property in the IsAssaDayPeriodTimePeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaDayPeriodTimePeriodUid'
    /// </summary>
    public static string AssaDayPeriodTimePeriodUid = "@AssaDayPeriodTimePeriodUid";
    /// <summary>
    /// Returns '@AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "@AssaDayPeriodUid";
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
