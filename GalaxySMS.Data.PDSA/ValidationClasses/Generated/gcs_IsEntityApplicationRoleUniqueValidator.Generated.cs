using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsEntityApplicationRoleUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsEntityApplicationRoleUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsEntityApplicationRoleUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsEntityApplicationRoleUniquePDSA Entity
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
    /// Clones the current gcs_IsEntityApplicationRoleUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsEntityApplicationRoleUniquePDSA object</returns>
    public gcs_IsEntityApplicationRoleUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsEntityApplicationRoleUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsEntityApplicationRoleUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsEntityApplicationRoleUniquePDSA object</returns>
    public gcs_IsEntityApplicationRoleUniquePDSA CloneEntity(gcs_IsEntityApplicationRoleUniquePDSA entityToClone)
    {
      gcs_IsEntityApplicationRoleUniquePDSA newEntity = new gcs_IsEntityApplicationRoleUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationRoleId, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_EntityApplicationRoleId_Header", "Entity Application Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_EntityApplicationRoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationId, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_EntityApplicationId_Header", "Entity Application Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_EntityApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RoleId, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsEntityApplicationRoleUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationRoleId).Value = Entity.EntityApplicationRoleId;
      this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationId).Value = Entity.EntityApplicationId;
      this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationRoleId).IsNull == false)
        Entity.EntityApplicationRoleId = this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationRoleId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationId).IsNull == false)
        Entity.EntityApplicationId = this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.EntityApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RoleId).IsNull == false)
        Entity.RoleId = this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RoleId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsEntityApplicationRoleUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityApplicationRoleUniquePDSA class.
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
    /// Returns '@EntityApplicationRoleId'
    /// </summary>
    public static string EntityApplicationRoleId = "@EntityApplicationRoleId";
    /// <summary>
    /// Returns '@EntityApplicationId'
    /// </summary>
    public static string EntityApplicationId = "@EntityApplicationId";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityApplicationRoleUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityApplicationRoleId'
    /// </summary>
    public static string EntityApplicationRoleId = "@EntityApplicationRoleId";
    /// <summary>
    /// Returns '@EntityApplicationId'
    /// </summary>
    public static string EntityApplicationId = "@EntityApplicationId";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
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
