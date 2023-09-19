using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the DateTypeEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateTypeEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DateTypeEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DateTypeEntityMapPDSA Entity
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
    /// Clones the current DateTypeEntityMapPDSA
    /// </summary>
    /// <returns>A cloned DateTypeEntityMapPDSA object</returns>
    public DateTypeEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateTypeEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The DateTypeEntityMapPDSA entity to clone</param>
    /// <returns>A cloned DateTypeEntityMapPDSA object</returns>
    public DateTypeEntityMapPDSA CloneEntity(DateTypeEntityMapPDSA entityToClone)
    {
      DateTypeEntityMapPDSA newEntity = new DateTypeEntityMapPDSA();

      newEntity.DateTypeEntityMapUid = entityToClone.DateTypeEntityMapUid;
      newEntity.DateTypeUid = entityToClone.DateTypeUid;
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
      
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeEntityMapUid, GetResourceMessage("GCS_DateTypeEntityMapPDSA_DateTypeEntityMapUid_Header", "Date Type Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeEntityMapPDSA_DateTypeEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeUid, GetResourceMessage("GCS_DateTypeEntityMapPDSA_DateTypeUid_Header", "Date Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeEntityMapPDSA_DateTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_DateTypeEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_DateTypeEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_DateTypeEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_DateTypeEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_DateTypeEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_DateTypeEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_DateTypeEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_DateTypeEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_DateTypeEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_DateTypeEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_DateTypeEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.DateTypeEntityMapUid = Guid.NewGuid();
      Entity.DateTypeUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeEntityMapUid).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeEntityMapUid).Value = Entity.DateTypeEntityMapUid;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeUid).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeUid).Value = Entity.DateTypeUid;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeEntityMapUid).IsNull == false)
        Entity.DateTypeEntityMapUid = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeEntityMapUid).GetAsGuid();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeUid).IsNull == false)
        Entity.DateTypeUid = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.DateTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(DateTypeEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateTypeEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DateTypeEntityMapUid'
    /// </summary>
    public static string DateTypeEntityMapUid = "DateTypeEntityMapUid";
    /// <summary>
    /// Returns 'DateTypeUid'
    /// </summary>
    public static string DateTypeUid = "DateTypeUid";
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
