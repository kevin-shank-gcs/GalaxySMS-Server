using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_UserEntityApplicationRolesForUserIdPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_UserEntityApplicationRolesForUserIdPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_UserEntityApplicationRolesForUserIdPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_UserEntityApplicationRolesForUserIdPDSA Entity
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
    /// Clones the current gcs_UserEntityApplicationRolesForUserIdPDSA
    /// </summary>
    /// <returns>A cloned gcs_UserEntityApplicationRolesForUserIdPDSA object</returns>
    public gcs_UserEntityApplicationRolesForUserIdPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_UserEntityApplicationRolesForUserIdPDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_UserEntityApplicationRolesForUserIdPDSA entity to clone</param>
    /// <returns>A cloned gcs_UserEntityApplicationRolesForUserIdPDSA object</returns>
    public gcs_UserEntityApplicationRolesForUserIdPDSA CloneEntity(gcs_UserEntityApplicationRolesForUserIdPDSA entityToClone)
    {
      gcs_UserEntityApplicationRolesForUserIdPDSA newEntity = new gcs_UserEntityApplicationRolesForUserIdPDSA();

      newEntity.UserName = entityToClone.UserName;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.ApplicationName = entityToClone.ApplicationName;
      newEntity.RoleName = entityToClone.RoleName;
      newEntity.UserEntityApplicationRoleId = entityToClone.UserEntityApplicationRoleId;
      newEntity.EntityApplicationRoleId = entityToClone.EntityApplicationRoleId;
      newEntity.UserId = entityToClone.UserId;
      newEntity.ApplicationId = entityToClone.ApplicationId;
      newEntity.RoleId = entityToClone.RoleId;
      newEntity.EntityId = entityToClone.EntityId;

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
      
      props.Add(PDSAProperty.Create(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcs_UserEntityApplicationRolesForUserIdPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_UserEntityApplicationRolesForUserIdPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_UserEntityApplicationRolesForUserIdPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_UserEntityApplicationRolesForUserIdPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_UserEntityApplicationRolesForUserIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_UserEntityApplicationRolesForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'UserName'
    /// </summary>
    public static string UserName = "UserName";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'ApplicationName'
    /// </summary>
    public static string ApplicationName = "ApplicationName";
    /// <summary>
    /// Returns 'RoleName'
    /// </summary>
    public static string RoleName = "RoleName";
    /// <summary>
    /// Returns 'UserEntityApplicationRoleId'
    /// </summary>
    public static string UserEntityApplicationRoleId = "UserEntityApplicationRoleId";
    /// <summary>
    /// Returns 'EntityApplicationRoleId'
    /// </summary>
    public static string EntityApplicationRoleId = "EntityApplicationRoleId";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'ApplicationId'
    /// </summary>
    public static string ApplicationId = "ApplicationId";
    /// <summary>
    /// Returns 'RoleId'
    /// </summary>
    public static string RoleId = "RoleId";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_UserEntityApplicationRolesForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
