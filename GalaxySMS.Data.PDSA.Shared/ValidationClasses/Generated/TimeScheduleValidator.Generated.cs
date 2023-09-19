using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the TimeSchedulePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimeSchedulePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimeSchedulePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimeSchedulePDSA Entity
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
    /// Clones the current TimeSchedulePDSA
    /// </summary>
    /// <returns>A cloned TimeSchedulePDSA object</returns>
    public TimeSchedulePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimeSchedulePDSA
    /// </summary>
    /// <param name="entityToClone">The TimeSchedulePDSA entity to clone</param>
    /// <returns>A cloned TimeSchedulePDSA object</returns>
    public TimeSchedulePDSA CloneEntity(TimeSchedulePDSA entityToClone)
    {
      TimeSchedulePDSA newEntity = new TimeSchedulePDSA();

      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.Display = entityToClone.Display;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.Description = entityToClone.Description;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.GalaxyClusterUid = entityToClone.GalaxyClusterUid;
      newEntity.AssaAbloyDSRId = entityToClone.AssaAbloyDSRId;
      newEntity.AssaDsrUid = entityToClone.AssaDsrUid;
      newEntity.CultureName = entityToClone.CultureName;

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
      
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.TimeScheduleUid, GetResourceMessage("GCS_TimeSchedulePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimeSchedulePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_TimeSchedulePDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_TimeSchedulePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_TimeSchedulePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_TimeSchedulePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_TimeSchedulePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_TimeSchedulePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_TimeSchedulePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_TimeSchedulePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_TimeSchedulePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_TimeSchedulePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_TimeSchedulePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_TimeSchedulePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_TimeSchedulePDSA_Description_Header", "Description"), false, typeof(string), 1000, GetResourceMessage("GCS_TimeSchedulePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_TimeSchedulePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_TimeSchedulePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_TimeSchedulePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_TimeSchedulePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_TimeSchedulePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_TimeSchedulePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.GalaxyClusterUid, GetResourceMessage("GCS_TimeSchedulePDSA_GalaxyClusterUid_Header", "Galaxy Cluster Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_TimeSchedulePDSA_GalaxyClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.AssaAbloyDSRId, GetResourceMessage("GCS_TimeSchedulePDSA_AssaAbloyDSRId_Header", "Assa Abloy DSR Id"), false, typeof(string), 2147483647, GetResourceMessage("GCS_TimeSchedulePDSA_AssaAbloyDSRId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.AssaDsrUid, GetResourceMessage("GCS_TimeSchedulePDSA_AssaDsrUid_Header", "Assa Dsr Uid"), false, typeof(string), 2147483647, GetResourceMessage("GCS_TimeSchedulePDSA_AssaDsrUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedulePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_TimeSchedulePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_TimeSchedulePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.TimeScheduleUid = Guid.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.InsertName = string.Empty;
      Entity.Display = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.Description = string.Empty;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.GalaxyClusterUid = Guid.Empty;
      Entity.AssaAbloyDSRId = string.Empty;
      Entity.AssaDsrUid = string.Empty;
      Entity.CultureName = string.Empty;

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
      
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.TimeScheduleUid).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.GalaxyClusterUid).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.GalaxyClusterUid).Value = Entity.GalaxyClusterUid;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaAbloyDSRId).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaAbloyDSRId).Value = Entity.AssaAbloyDSRId;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaDsrUid).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      if(!Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.TimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.GalaxyClusterUid).IsNull == false)
        Entity.GalaxyClusterUid = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.GalaxyClusterUid).GetAsGuid();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaAbloyDSRId).IsNull == false)
        Entity.AssaAbloyDSRId = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaAbloyDSRId).GetAsString();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaDsrUid).IsNull == false)
        Entity.AssaDsrUid = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.AssaDsrUid).GetAsString();
      if(Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(TimeSchedulePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedulePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
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
    /// Returns 'GalaxyClusterUid'
    /// </summary>
    public static string GalaxyClusterUid = "GalaxyClusterUid";
    /// <summary>
    /// Returns 'AssaAbloyDSRId'
    /// </summary>
    public static string AssaAbloyDSRId = "AssaAbloyDSRId";
    /// <summary>
    /// Returns 'AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "AssaDsrUid";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    }
    #endregion
  }
}
