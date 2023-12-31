using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the BadgeTemplateEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class BadgeTemplateEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private BadgeTemplateEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new BadgeTemplateEntityMapPDSA Entity
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
    /// Clones the current BadgeTemplateEntityMapPDSA
    /// </summary>
    /// <returns>A cloned BadgeTemplateEntityMapPDSA object</returns>
    public BadgeTemplateEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in BadgeTemplateEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The BadgeTemplateEntityMapPDSA entity to clone</param>
    /// <returns>A cloned BadgeTemplateEntityMapPDSA object</returns>
    public BadgeTemplateEntityMapPDSA CloneEntity(BadgeTemplateEntityMapPDSA entityToClone)
    {
      BadgeTemplateEntityMapPDSA newEntity = new BadgeTemplateEntityMapPDSA();

      newEntity.BadgeTemplateEntityMapUid = entityToClone.BadgeTemplateEntityMapUid;
      newEntity.BadgeTemplateUid = entityToClone.BadgeTemplateUid;
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
      
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateEntityMapUid, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_BadgeTemplateEntityMapUid_Header", "Badge Template Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_BadgeTemplateEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateUid, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_BadgeTemplateUid_Header", "Badge Template Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_BadgeTemplateUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(BadgeTemplateEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_BadgeTemplateEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.BadgeTemplateEntityMapUid = Guid.Empty;
      Entity.BadgeTemplateUid = Guid.Empty;
      Entity.EntityId = Guid.Empty;
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
      
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateEntityMapUid).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateEntityMapUid).Value = Entity.BadgeTemplateEntityMapUid;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateUid).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateUid).Value = Entity.BadgeTemplateUid;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateEntityMapUid).IsNull == false)
        Entity.BadgeTemplateEntityMapUid = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateEntityMapUid).GetAsGuid();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateUid).IsNull == false)
        Entity.BadgeTemplateUid = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.BadgeTemplateUid).GetAsGuid();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(BadgeTemplateEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the BadgeTemplateEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'BadgeTemplateEntityMapUid'
    /// </summary>
    public static string BadgeTemplateEntityMapUid = "BadgeTemplateEntityMapUid";
    /// <summary>
    /// Returns 'BadgeTemplateUid'
    /// </summary>
    public static string BadgeTemplateUid = "BadgeTemplateUid";
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
