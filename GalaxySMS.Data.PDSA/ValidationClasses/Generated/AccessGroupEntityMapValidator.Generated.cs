using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessGroupEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroupEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroupEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroupEntityMapPDSA Entity
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
    /// Clones the current AccessGroupEntityMapPDSA
    /// </summary>
    /// <returns>A cloned AccessGroupEntityMapPDSA object</returns>
    public AccessGroupEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroupEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroupEntityMapPDSA entity to clone</param>
    /// <returns>A cloned AccessGroupEntityMapPDSA object</returns>
    public AccessGroupEntityMapPDSA CloneEntity(AccessGroupEntityMapPDSA entityToClone)
    {
      AccessGroupEntityMapPDSA newEntity = new AccessGroupEntityMapPDSA();

      newEntity.AccessGroupEntityMapUid = entityToClone.AccessGroupEntityMapUid;
      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;

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
      
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupEntityMapUid, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_AccessGroupEntityMapUid_Header", "Access Group Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_AccessGroupEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupUid, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_AccessGroupUid_Header", "Access Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessGroupEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessGroupEntityMapUid = Guid.NewGuid();
      Entity.AccessGroupUid = Guid.NewGuid();
      Entity.EntityId = Guid.NewGuid();
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;

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
      
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupEntityMapUid).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupEntityMapUid).Value = Entity.AccessGroupEntityMapUid;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupUid).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupEntityMapUid).IsNull == false)
        Entity.AccessGroupEntityMapUid = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupEntityMapUid).GetAsGuid();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.AccessGroupUid).GetAsGuid();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessGroupEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessGroupEntityMapUid'
    /// </summary>
    public static string AccessGroupEntityMapUid = "AccessGroupEntityMapUid";
    /// <summary>
    /// Returns 'AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "AccessGroupUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
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
    }
    #endregion
  }
}
