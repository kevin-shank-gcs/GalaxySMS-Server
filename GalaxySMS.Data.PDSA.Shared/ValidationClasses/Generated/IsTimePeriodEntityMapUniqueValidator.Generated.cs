using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimePeriodEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimePeriodEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimePeriodEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimePeriodEntityMapUniquePDSA Entity
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
    /// Clones the current IsTimePeriodEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimePeriodEntityMapUniquePDSA object</returns>
    public IsTimePeriodEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimePeriodEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimePeriodEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimePeriodEntityMapUniquePDSA object</returns>
    public IsTimePeriodEntityMapUniquePDSA CloneEntity(IsTimePeriodEntityMapUniquePDSA entityToClone)
    {
      IsTimePeriodEntityMapUniquePDSA newEntity = new IsTimePeriodEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodEntityMapUid, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_TimePeriodEntityMapUid_Header", "Time Period Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_TimePeriodEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodUid, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_TimePeriodUid_Header", "Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimePeriodEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodEntityMapUid).Value = Entity.TimePeriodEntityMapUid;
      this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodEntityMapUid).IsNull == false)
        Entity.TimePeriodEntityMapUid = this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.TimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimePeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimePeriodEntityMapUniquePDSA class.
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
    /// Returns '@TimePeriodEntityMapUid'
    /// </summary>
    public static string TimePeriodEntityMapUid = "@TimePeriodEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
    /// Contains static string properties that represent the name of each property in the IsTimePeriodEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimePeriodEntityMapUid'
    /// </summary>
    public static string TimePeriodEntityMapUid = "@TimePeriodEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
