using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA Entity
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
    /// Clones the current gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA
    /// </summary>
    /// <returns>A cloned gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA object</returns>
    public gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA entity to clone</param>
    /// <returns>A cloned gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA object</returns>
    public gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA CloneEntity(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA entityToClone)
    {
      gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA newEntity = new gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA();

      newEntity.EntityName = entityToClone.EntityName;
      newEntity.IsAdministrator = entityToClone.IsAdministrator;
      newEntity.RoleName = entityToClone.RoleName;
      newEntity.UserId = entityToClone.UserId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.RoleId = entityToClone.RoleId;
      newEntity.InheritParentRoles = entityToClone.InheritParentRoles;

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
      
      props.Add(PDSAProperty.Create(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'IsAdministrator'
    /// </summary>
    public static string IsAdministrator = "IsAdministrator";
    /// <summary>
    /// Returns 'RoleName'
    /// </summary>
    public static string RoleName = "RoleName";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'RoleId'
    /// </summary>
    public static string RoleId = "RoleId";
    /// <summary>
    /// Returns 'InheritParentRoles'
    /// </summary>
    public static string InheritParentRoles = "InheritParentRoles";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUserEntityRoles_GetMinimalInfoForUserIdPDSA class.
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
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
