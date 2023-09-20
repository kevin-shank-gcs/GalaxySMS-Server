using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the DateTypeDefaultBehaviorPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateTypeDefaultBehaviorPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DateTypeDefaultBehaviorPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DateTypeDefaultBehaviorPDSA Entity
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
    /// Clones the current DateTypeDefaultBehaviorPDSA
    /// </summary>
    /// <returns>A cloned DateTypeDefaultBehaviorPDSA object</returns>
    public DateTypeDefaultBehaviorPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateTypeDefaultBehaviorPDSA
    /// </summary>
    /// <param name="entityToClone">The DateTypeDefaultBehaviorPDSA entity to clone</param>
    /// <returns>A cloned DateTypeDefaultBehaviorPDSA object</returns>
    public DateTypeDefaultBehaviorPDSA CloneEntity(DateTypeDefaultBehaviorPDSA entityToClone)
    {
      DateTypeDefaultBehaviorPDSA newEntity = new DateTypeDefaultBehaviorPDSA();

      newEntity.EntityId = entityToClone.EntityId;
      newEntity.SundayDayTypeUid = entityToClone.SundayDayTypeUid;
      newEntity.MondayDayTypeUid = entityToClone.MondayDayTypeUid;
      newEntity.TuesdayDayTypeUid = entityToClone.TuesdayDayTypeUid;
      newEntity.WednesdayDayTypeUid = entityToClone.WednesdayDayTypeUid;
      newEntity.ThursdayDayTypeUid = entityToClone.ThursdayDayTypeUid;
      newEntity.FridayDayTypeUid = entityToClone.FridayDayTypeUid;
      newEntity.SaturdayDayTypeUid = entityToClone.SaturdayDayTypeUid;
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
      
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SundayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_SundayDayTypeUid_Header", "Sunday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_SundayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.MondayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_MondayDayTypeUid_Header", "Monday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_MondayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.TuesdayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_TuesdayDayTypeUid_Header", "Tuesday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_TuesdayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.WednesdayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_WednesdayDayTypeUid_Header", "Wednesday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_WednesdayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ThursdayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_ThursdayDayTypeUid_Header", "Thursday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_ThursdayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.FridayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_FridayDayTypeUid_Header", "Friday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_FridayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SaturdayDayTypeUid, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_SaturdayDayTypeUid_Header", "Saturday Day Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_SaturdayDayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_DateTypeDefaultBehaviorPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.EntityId = Guid.Empty;
      Entity.SundayDayTypeUid = Guid.Empty;
      Entity.MondayDayTypeUid = Guid.Empty;
      Entity.TuesdayDayTypeUid = Guid.Empty;
      Entity.WednesdayDayTypeUid = Guid.Empty;
      Entity.ThursdayDayTypeUid = Guid.Empty;
      Entity.FridayDayTypeUid = Guid.Empty;
      Entity.SaturdayDayTypeUid = Guid.Empty;
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
      
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SundayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SundayDayTypeUid).Value = Entity.SundayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.MondayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.MondayDayTypeUid).Value = Entity.MondayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.TuesdayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.TuesdayDayTypeUid).Value = Entity.TuesdayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.WednesdayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.WednesdayDayTypeUid).Value = Entity.WednesdayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ThursdayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ThursdayDayTypeUid).Value = Entity.ThursdayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.FridayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.FridayDayTypeUid).Value = Entity.FridayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SaturdayDayTypeUid).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SaturdayDayTypeUid).Value = Entity.SaturdayDayTypeUid;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SundayDayTypeUid).IsNull == false)
        Entity.SundayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SundayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.MondayDayTypeUid).IsNull == false)
        Entity.MondayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.MondayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.TuesdayDayTypeUid).IsNull == false)
        Entity.TuesdayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.TuesdayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.WednesdayDayTypeUid).IsNull == false)
        Entity.WednesdayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.WednesdayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ThursdayDayTypeUid).IsNull == false)
        Entity.ThursdayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ThursdayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.FridayDayTypeUid).IsNull == false)
        Entity.FridayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.FridayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SaturdayDayTypeUid).IsNull == false)
        Entity.SaturdayDayTypeUid = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.SaturdayDayTypeUid).GetAsGuid();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(DateTypeDefaultBehaviorPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateTypeDefaultBehaviorPDSA class.
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
    /// Returns 'SundayDayTypeUid'
    /// </summary>
    public static string SundayDayTypeUid = "SundayDayTypeUid";
    /// <summary>
    /// Returns 'MondayDayTypeUid'
    /// </summary>
    public static string MondayDayTypeUid = "MondayDayTypeUid";
    /// <summary>
    /// Returns 'TuesdayDayTypeUid'
    /// </summary>
    public static string TuesdayDayTypeUid = "TuesdayDayTypeUid";
    /// <summary>
    /// Returns 'WednesdayDayTypeUid'
    /// </summary>
    public static string WednesdayDayTypeUid = "WednesdayDayTypeUid";
    /// <summary>
    /// Returns 'ThursdayDayTypeUid'
    /// </summary>
    public static string ThursdayDayTypeUid = "ThursdayDayTypeUid";
    /// <summary>
    /// Returns 'FridayDayTypeUid'
    /// </summary>
    public static string FridayDayTypeUid = "FridayDayTypeUid";
    /// <summary>
    /// Returns 'SaturdayDayTypeUid'
    /// </summary>
    public static string SaturdayDayTypeUid = "SaturdayDayTypeUid";
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
