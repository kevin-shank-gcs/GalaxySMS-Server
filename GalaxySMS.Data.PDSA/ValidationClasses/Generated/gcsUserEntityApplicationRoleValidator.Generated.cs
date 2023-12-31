using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsUserEntityApplicationRolePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsUserEntityApplicationRolePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsUserEntityApplicationRolePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsUserEntityApplicationRolePDSA Entity
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
    /// Clones the current gcsUserEntityApplicationRolePDSA
    /// </summary>
    /// <returns>A cloned gcsUserEntityApplicationRolePDSA object</returns>
    public gcsUserEntityApplicationRolePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsUserEntityApplicationRolePDSA
    /// </summary>
    /// <param name="entityToClone">The gcsUserEntityApplicationRolePDSA entity to clone</param>
    /// <returns>A cloned gcsUserEntityApplicationRolePDSA object</returns>
    public gcsUserEntityApplicationRolePDSA CloneEntity(gcsUserEntityApplicationRolePDSA entityToClone)
    {
      gcsUserEntityApplicationRolePDSA newEntity = new gcsUserEntityApplicationRolePDSA();

      newEntity.UserEntityApplicationRoleId = entityToClone.UserEntityApplicationRoleId;
      newEntity.UserEntityId = entityToClone.UserEntityId;
      newEntity.EntityApplicationRoleId = entityToClone.EntityApplicationRoleId;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.UserId = entityToClone.UserId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ApplicationId = entityToClone.ApplicationId;
      newEntity.RoleId = entityToClone.RoleId;

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
      
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityApplicationRoleId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UserEntityApplicationRoleId_Header", "User Entity Application Role Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UserEntityApplicationRoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UserEntityId_Header", "User Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UserEntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityApplicationRoleId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_EntityApplicationRoleId_Header", "Entity Application Role Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_EntityApplicationRoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UserId_Header", "User Id"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ApplicationId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_ApplicationId_Header", "Application Id"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.RoleId, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_gcsUserEntityApplicationRolePDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.UserEntityApplicationRoleId = Guid.NewGuid();
      Entity.UserEntityId = Guid.NewGuid();
      Entity.EntityApplicationRoleId = Guid.NewGuid();
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.UserId = Guid.NewGuid();
      Entity.EntityId = Guid.NewGuid();
      Entity.ApplicationId = Guid.NewGuid();
      Entity.RoleId = Guid.NewGuid();

      Entity.ResetAllIsDirtyProperties();
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
      if (Properties == null)
        InitProperties();
      
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityApplicationRoleId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityApplicationRoleId).Value = Entity.UserEntityApplicationRoleId;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityId).Value = Entity.UserEntityId;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityApplicationRoleId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityApplicationRoleId).Value = Entity.EntityApplicationRoleId;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserId).Value = Entity.UserId;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ApplicationId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ApplicationId).Value = Entity.ApplicationId;
      if(!Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.RoleId).SetAsNull)
        Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.RoleId).Value = Entity.RoleId;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityApplicationRoleId).IsNull == false)
        Entity.UserEntityApplicationRoleId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityApplicationRoleId).GetAsGuid();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityId).IsNull == false)
        Entity.UserEntityId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserEntityId).GetAsGuid();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityApplicationRoleId).IsNull == false)
        Entity.EntityApplicationRoleId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityApplicationRoleId).GetAsGuid();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.UserId).GetAsGuid();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.ApplicationId).GetAsGuid();
      if(Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.RoleId).IsNull == false)
        Entity.RoleId = Properties.GetByName(gcsUserEntityApplicationRolePDSAValidator.ColumnNames.RoleId).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUserEntityApplicationRolePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'UserEntityApplicationRoleId'
    /// </summary>
    public static string UserEntityApplicationRoleId = "UserEntityApplicationRoleId";
    /// <summary>
    /// Returns 'UserEntityId'
    /// </summary>
    public static string UserEntityId = "UserEntityId";
    /// <summary>
    /// Returns 'EntityApplicationRoleId'
    /// </summary>
    public static string EntityApplicationRoleId = "EntityApplicationRoleId";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ApplicationId'
    /// </summary>
    public static string ApplicationId = "ApplicationId";
    /// <summary>
    /// Returns 'RoleId'
    /// </summary>
    public static string RoleId = "RoleId";
    }
    #endregion
  }
}
