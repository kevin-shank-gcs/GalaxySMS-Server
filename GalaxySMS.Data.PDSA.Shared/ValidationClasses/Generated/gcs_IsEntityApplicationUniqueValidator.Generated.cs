using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsEntityApplicationUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsEntityApplicationUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsEntityApplicationUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsEntityApplicationUniquePDSA Entity
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
    /// Clones the current gcs_IsEntityApplicationUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsEntityApplicationUniquePDSA object</returns>
    public gcs_IsEntityApplicationUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsEntityApplicationUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsEntityApplicationUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsEntityApplicationUniquePDSA object</returns>
    public gcs_IsEntityApplicationUniquePDSA CloneEntity(gcs_IsEntityApplicationUniquePDSA entityToClone)
    {
      gcs_IsEntityApplicationUniquePDSA newEntity = new gcs_IsEntityApplicationUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityApplicationId, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_EntityApplicationId_Header", "Entity Application Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_EntityApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.ApplicationId, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_ApplicationId_Header", "Application Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityApplicationId).Value = Entity.EntityApplicationId;
      this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityApplicationId).IsNull == false)
        Entity.EntityApplicationId = this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.ApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsEntityApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityApplicationUniquePDSA class.
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
    /// Returns '@EntityApplicationId'
    /// </summary>
    public static string EntityApplicationId = "@EntityApplicationId";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityApplicationUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityApplicationId'
    /// </summary>
    public static string EntityApplicationId = "@EntityApplicationId";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
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
