using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the SelectParentAndChildEntitiesPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class SelectParentAndChildEntitiesPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private SelectParentAndChildEntitiesPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new SelectParentAndChildEntitiesPDSA Entity
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
    /// Clones the current SelectParentAndChildEntitiesPDSA
    /// </summary>
    /// <returns>A cloned SelectParentAndChildEntitiesPDSA object</returns>
    public SelectParentAndChildEntitiesPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in SelectParentAndChildEntitiesPDSA
    /// </summary>
    /// <param name="entityToClone">The SelectParentAndChildEntitiesPDSA entity to clone</param>
    /// <returns>A cloned SelectParentAndChildEntitiesPDSA object</returns>
    public SelectParentAndChildEntitiesPDSA CloneEntity(SelectParentAndChildEntitiesPDSA entityToClone)
    {
      SelectParentAndChildEntitiesPDSA newEntity = new SelectParentAndChildEntitiesPDSA();

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
      newEntity.ParentEntityId = entityToClone.ParentEntityId;
      newEntity.ParentEntityName = entityToClone.ParentEntityName;

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
      
      props.Add(PDSAProperty.Create(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.rootEntityId, GetResourceMessage("GCS_SelectParentAndChildEntitiesPDSA_rootEntityId_Header", "root Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_SelectParentAndChildEntitiesPDSA_rootEntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_SelectParentAndChildEntitiesPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_SelectParentAndChildEntitiesPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.rootEntityId).Value = Entity.rootEntityId;
      this.Properties.GetByName(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.rootEntityId).IsNull == false)
        Entity.rootEntityId = this.Properties.GetByName(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.rootEntityId).GetAsGuid();
      if(this.Properties.GetByName(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(SelectParentAndChildEntitiesPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the SelectParentAndChildEntitiesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
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
    /// Returns 'ParentEntityId'
    /// </summary>
    public static string ParentEntityId = "ParentEntityId";
    /// <summary>
    /// Returns 'ParentEntityName'
    /// </summary>
    public static string ParentEntityName = "ParentEntityName";
    /// <summary>
    /// Returns '@rootEntityId'
    /// </summary>
    public static string rootEntityId = "@rootEntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the SelectParentAndChildEntitiesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@rootEntityId'
    /// </summary>
    public static string rootEntityId = "@rootEntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
