using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the TimePeriodEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimePeriodEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimePeriodEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimePeriodEntityMapPDSA Entity
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
    /// Clones the current TimePeriodEntityMapPDSA
    /// </summary>
    /// <returns>A cloned TimePeriodEntityMapPDSA object</returns>
    public TimePeriodEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimePeriodEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The TimePeriodEntityMapPDSA entity to clone</param>
    /// <returns>A cloned TimePeriodEntityMapPDSA object</returns>
    public TimePeriodEntityMapPDSA CloneEntity(TimePeriodEntityMapPDSA entityToClone)
    {
      TimePeriodEntityMapPDSA newEntity = new TimePeriodEntityMapPDSA();

      newEntity.TimePeriodEntityMapUid = entityToClone.TimePeriodEntityMapUid;
      newEntity.TimePeriodUid = entityToClone.TimePeriodUid;
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
      
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodEntityMapUid, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_TimePeriodEntityMapUid_Header", "Time Period Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_TimePeriodEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodUid, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_TimePeriodUid_Header", "Time Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(TimePeriodEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_TimePeriodEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.TimePeriodEntityMapUid = Guid.NewGuid();
      Entity.TimePeriodUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodEntityMapUid).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodEntityMapUid).Value = Entity.TimePeriodEntityMapUid;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodUid).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodEntityMapUid).IsNull == false)
        Entity.TimePeriodEntityMapUid = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodEntityMapUid).GetAsGuid();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.TimePeriodUid).GetAsGuid();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(TimePeriodEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimePeriodEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'TimePeriodEntityMapUid'
    /// </summary>
    public static string TimePeriodEntityMapUid = "TimePeriodEntityMapUid";
    /// <summary>
    /// Returns 'TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "TimePeriodUid";
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
