using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetPermissionsForUserEntityApplicationPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetPermissionsForUserEntityApplicationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetPermissionsForUserEntityApplicationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetPermissionsForUserEntityApplicationPDSA Entity
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
    /// Clones the current GetPermissionsForUserEntityApplicationPDSA
    /// </summary>
    /// <returns>A cloned GetPermissionsForUserEntityApplicationPDSA object</returns>
    public GetPermissionsForUserEntityApplicationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetPermissionsForUserEntityApplicationPDSA
    /// </summary>
    /// <param name="entityToClone">The GetPermissionsForUserEntityApplicationPDSA entity to clone</param>
    /// <returns>A cloned GetPermissionsForUserEntityApplicationPDSA object</returns>
    public GetPermissionsForUserEntityApplicationPDSA CloneEntity(GetPermissionsForUserEntityApplicationPDSA entityToClone)
    {
      GetPermissionsForUserEntityApplicationPDSA newEntity = new GetPermissionsForUserEntityApplicationPDSA();

      newEntity.UserId = entityToClone.UserId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ParentEntityId = entityToClone.ParentEntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityDescription = entityToClone.EntityDescription;
      newEntity.ApplicationName = entityToClone.ApplicationName;
      newEntity.RoleId = entityToClone.RoleId;
      newEntity.RoleName = entityToClone.RoleName;
      newEntity.IsAdministratorRole = entityToClone.IsAdministratorRole;
      newEntity.CategoryName = entityToClone.CategoryName;
      newEntity.PermissionId = entityToClone.PermissionId;
      newEntity.PermissionName = entityToClone.PermissionName;

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
      
      props.Add(PDSAProperty.Create(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.userId, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_userId_Header", "user Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_userId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.entityId, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_entityId_Header", "entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_entityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.applicationId, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_applicationId_Header", "application Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_applicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetPermissionsForUserEntityApplicationPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.userId).Value = Entity.userId;
      this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.entityId).Value = Entity.entityId;
      this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.applicationId).Value = Entity.applicationId;
      this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.userId).IsNull == false)
        Entity.userId = this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.userId).GetAsGuid();
      if(this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.entityId).IsNull == false)
        Entity.entityId = this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.entityId).GetAsGuid();
      if(this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.applicationId).IsNull == false)
        Entity.applicationId = this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.applicationId).GetAsGuid();
      if(this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetPermissionsForUserEntityApplicationPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetPermissionsForUserEntityApplicationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ParentEntityId'
    /// </summary>
    public static string ParentEntityId = "ParentEntityId";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'EntityDescription'
    /// </summary>
    public static string EntityDescription = "EntityDescription";
    /// <summary>
    /// Returns 'ApplicationName'
    /// </summary>
    public static string ApplicationName = "ApplicationName";
    /// <summary>
    /// Returns 'RoleId'
    /// </summary>
    public static string RoleId = "RoleId";
    /// <summary>
    /// Returns 'RoleName'
    /// </summary>
    public static string RoleName = "RoleName";
    /// <summary>
    /// Returns 'IsAdministratorRole'
    /// </summary>
    public static string IsAdministratorRole = "IsAdministratorRole";
    /// <summary>
    /// Returns 'CategoryName'
    /// </summary>
    public static string CategoryName = "CategoryName";
    /// <summary>
    /// Returns 'PermissionId'
    /// </summary>
    public static string PermissionId = "PermissionId";
    /// <summary>
    /// Returns 'PermissionName'
    /// </summary>
    public static string PermissionName = "PermissionName";
    /// <summary>
    /// Returns '@userId'
    /// </summary>
    public static string userId = "@userId";
    /// <summary>
    /// Returns '@entityId'
    /// </summary>
    public static string entityId = "@entityId";
    /// <summary>
    /// Returns '@applicationId'
    /// </summary>
    public static string applicationId = "@applicationId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetPermissionsForUserEntityApplicationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@userId'
    /// </summary>
    public static string userId = "@userId";
    /// <summary>
    /// Returns '@entityId'
    /// </summary>
    public static string entityId = "@entityId";
    /// <summary>
    /// Returns '@applicationId'
    /// </summary>
    public static string applicationId = "@applicationId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
