using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the SelectUserEffectivePermissionsPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class SelectUserEffectivePermissionsPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private SelectUserEffectivePermissionsPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new SelectUserEffectivePermissionsPDSA Entity
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
    /// Clones the current SelectUserEffectivePermissionsPDSA
    /// </summary>
    /// <returns>A cloned SelectUserEffectivePermissionsPDSA object</returns>
    public SelectUserEffectivePermissionsPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in SelectUserEffectivePermissionsPDSA
    /// </summary>
    /// <param name="entityToClone">The SelectUserEffectivePermissionsPDSA entity to clone</param>
    /// <returns>A cloned SelectUserEffectivePermissionsPDSA object</returns>
    public SelectUserEffectivePermissionsPDSA CloneEntity(SelectUserEffectivePermissionsPDSA entityToClone)
    {
      SelectUserEffectivePermissionsPDSA newEntity = new SelectUserEffectivePermissionsPDSA();

      newEntity.UserId = entityToClone.UserId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ParentEntityId = entityToClone.ParentEntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityDescription = entityToClone.EntityDescription;
      newEntity.RoleId = entityToClone.RoleId;
      newEntity.RoleName = entityToClone.RoleName;
      newEntity.IsAdministratorRole = entityToClone.IsAdministratorRole;
      newEntity.PermissionCategoryId = entityToClone.PermissionCategoryId;
      newEntity.CategoryName = entityToClone.CategoryName;
      newEntity.PermissionId = entityToClone.PermissionId;
      newEntity.PermissionName = entityToClone.PermissionName;
      newEntity.PermissionCode = entityToClone.PermissionCode;

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
      
      props.Add(PDSAProperty.Create(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.entityId, GetResourceMessage("GCS_SelectUserEffectivePermissionsPDSA_entityId_Header", "entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_SelectUserEffectivePermissionsPDSA_entityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.userId, GetResourceMessage("GCS_SelectUserEffectivePermissionsPDSA_userId_Header", "user Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_SelectUserEffectivePermissionsPDSA_userId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_SelectUserEffectivePermissionsPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_SelectUserEffectivePermissionsPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.entityId).Value = Entity.entityId;
      this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.userId).Value = Entity.userId;
      this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.entityId).IsNull == false)
        Entity.entityId = this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.entityId).GetAsGuid();
      if(this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.userId).IsNull == false)
        Entity.userId = this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.userId).GetAsGuid();
      if(this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(SelectUserEffectivePermissionsPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the SelectUserEffectivePermissionsPDSA class.
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
    /// Returns 'PermissionCategoryId'
    /// </summary>
    public static string PermissionCategoryId = "PermissionCategoryId";
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
    /// Returns 'PermissionCode'
    /// </summary>
    public static string PermissionCode = "PermissionCode";
    /// <summary>
    /// Returns '@entityId'
    /// </summary>
    public static string entityId = "@entityId";
    /// <summary>
    /// Returns '@userId'
    /// </summary>
    public static string userId = "@userId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the SelectUserEffectivePermissionsPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@entityId'
    /// </summary>
    public static string entityId = "@entityId";
    /// <summary>
    /// Returns '@userId'
    /// </summary>
    public static string userId = "@userId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
