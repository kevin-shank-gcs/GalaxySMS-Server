using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaDayPeriodEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaDayPeriodEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaDayPeriodEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaDayPeriodEntityMapUniquePDSA Entity
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
    /// Clones the current IsAssaDayPeriodEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaDayPeriodEntityMapUniquePDSA object</returns>
    public IsAssaDayPeriodEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaDayPeriodEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaDayPeriodEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaDayPeriodEntityMapUniquePDSA object</returns>
    public IsAssaDayPeriodEntityMapUniquePDSA CloneEntity(IsAssaDayPeriodEntityMapUniquePDSA entityToClone)
    {
      IsAssaDayPeriodEntityMapUniquePDSA newEntity = new IsAssaDayPeriodEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodEntityMapUid, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_AssaDayPeriodEntityMapUid_Header", "Assa Day Period Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_AssaDayPeriodEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodUid, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_AssaDayPeriodUid_Header", "Assa Day Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_AssaDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDayPeriodEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodEntityMapUid).Value = Entity.AssaDayPeriodEntityMapUid;
      this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).Value = Entity.AssaDayPeriodUid;
      this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodEntityMapUid).IsNull == false)
        Entity.AssaDayPeriodEntityMapUid = this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).IsNull == false)
        Entity.AssaDayPeriodUid = this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.AssaDayPeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaDayPeriodEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDayPeriodEntityMapUniquePDSA class.
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
    /// Returns '@AssaDayPeriodEntityMapUid'
    /// </summary>
    public static string AssaDayPeriodEntityMapUid = "@AssaDayPeriodEntityMapUid";
    /// <summary>
    /// Returns '@AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "@AssaDayPeriodUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDayPeriodEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaDayPeriodEntityMapUid'
    /// </summary>
    public static string AssaDayPeriodEntityMapUid = "@AssaDayPeriodEntityMapUid";
    /// <summary>
    /// Returns '@AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "@AssaDayPeriodUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
