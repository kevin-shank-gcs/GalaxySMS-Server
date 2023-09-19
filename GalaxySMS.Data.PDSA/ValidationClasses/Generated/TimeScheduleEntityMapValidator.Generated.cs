using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the TimeScheduleEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimeScheduleEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimeScheduleEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimeScheduleEntityMapPDSA Entity
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
    /// Clones the current TimeScheduleEntityMapPDSA
    /// </summary>
    /// <returns>A cloned TimeScheduleEntityMapPDSA object</returns>
    public TimeScheduleEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimeScheduleEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The TimeScheduleEntityMapPDSA entity to clone</param>
    /// <returns>A cloned TimeScheduleEntityMapPDSA object</returns>
    public TimeScheduleEntityMapPDSA CloneEntity(TimeScheduleEntityMapPDSA entityToClone)
    {
      TimeScheduleEntityMapPDSA newEntity = new TimeScheduleEntityMapPDSA();

      newEntity.TimeScheduleEntityMapUid = entityToClone.TimeScheduleEntityMapUid;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
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
      
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleEntityMapUid, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_TimeScheduleEntityMapUid_Header", "Time Schedule Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_TimeScheduleEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleUid, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_TimeScheduleUid_Header", "Time Schedule Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(TimeScheduleEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_TimeScheduleEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.TimeScheduleEntityMapUid = Guid.NewGuid();
      Entity.TimeScheduleUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleEntityMapUid).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleEntityMapUid).Value = Entity.TimeScheduleEntityMapUid;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleUid).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleEntityMapUid).IsNull == false)
        Entity.TimeScheduleEntityMapUid = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleEntityMapUid).GetAsGuid();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.TimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(TimeScheduleEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeScheduleEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'TimeScheduleEntityMapUid'
    /// </summary>
    public static string TimeScheduleEntityMapUid = "TimeScheduleEntityMapUid";
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
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
