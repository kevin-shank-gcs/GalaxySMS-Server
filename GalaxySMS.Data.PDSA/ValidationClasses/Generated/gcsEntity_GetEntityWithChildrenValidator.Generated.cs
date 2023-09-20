using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsEntity_GetEntityWithChildrenPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsEntity_GetEntityWithChildrenPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsEntity_GetEntityWithChildrenPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsEntity_GetEntityWithChildrenPDSA Entity
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
    /// Clones the current gcsEntity_GetEntityWithChildrenPDSA
    /// </summary>
    /// <returns>A cloned gcsEntity_GetEntityWithChildrenPDSA object</returns>
    public gcsEntity_GetEntityWithChildrenPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsEntity_GetEntityWithChildrenPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsEntity_GetEntityWithChildrenPDSA entity to clone</param>
    /// <returns>A cloned gcsEntity_GetEntityWithChildrenPDSA object</returns>
    public gcsEntity_GetEntityWithChildrenPDSA CloneEntity(gcsEntity_GetEntityWithChildrenPDSA entityToClone)
    {
      gcsEntity_GetEntityWithChildrenPDSA newEntity = new gcsEntity_GetEntityWithChildrenPDSA();

      newEntity.ParentEntityId = entityToClone.ParentEntityId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityDescription = entityToClone.EntityDescription;
      newEntity.EntityKey = entityToClone.EntityKey;
      newEntity.IsDefault = entityToClone.IsDefault;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.BinaryResourceUid = entityToClone.BinaryResourceUid;
      newEntity.License = entityToClone.License;
      newEntity.PublicKey = entityToClone.PublicKey;
      newEntity.EntityType = entityToClone.EntityType;
      newEntity.AutoMapTimeSchedules = entityToClone.AutoMapTimeSchedules;

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
      
      props.Add(PDSAProperty.Create(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcsEntity_GetEntityWithChildrenPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsEntity_GetEntityWithChildrenPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsEntity_GetEntityWithChildrenPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsEntity_GetEntityWithChildrenPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcsEntity_GetEntityWithChildrenPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsEntity_GetEntityWithChildrenPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ParentEntityId'
    /// </summary>
    public static string ParentEntityId = "ParentEntityId";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'EntityDescription'
    /// </summary>
    public static string EntityDescription = "EntityDescription";
    /// <summary>
    /// Returns 'EntityKey'
    /// </summary>
    public static string EntityKey = "EntityKey";
    /// <summary>
    /// Returns 'IsDefault'
    /// </summary>
    public static string IsDefault = "IsDefault";
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
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
    /// Returns 'BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "BinaryResourceUid";
    /// <summary>
    /// Returns 'License'
    /// </summary>
    public static string License = "License";
    /// <summary>
    /// Returns 'PublicKey'
    /// </summary>
    public static string PublicKey = "PublicKey";
    /// <summary>
    /// Returns 'EntityType'
    /// </summary>
    public static string EntityType = "EntityType";
    /// <summary>
    /// Returns 'AutoMapTimeSchedules'
    /// </summary>
    public static string AutoMapTimeSchedules = "AutoMapTimeSchedules";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsEntity_GetEntityWithChildrenPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
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
