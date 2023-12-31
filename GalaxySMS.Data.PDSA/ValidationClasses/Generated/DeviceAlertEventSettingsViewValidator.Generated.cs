using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the DeviceAlertEventSettingsViewPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DeviceAlertEventSettingsViewPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DeviceAlertEventSettingsViewPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DeviceAlertEventSettingsViewPDSA Entity
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
    /// Clones the current DeviceAlertEventSettingsViewPDSA
    /// </summary>
    /// <returns>A cloned DeviceAlertEventSettingsViewPDSA object</returns>
    public DeviceAlertEventSettingsViewPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DeviceAlertEventSettingsViewPDSA
    /// </summary>
    /// <param name="entityToClone">The DeviceAlertEventSettingsViewPDSA entity to clone</param>
    /// <returns>A cloned DeviceAlertEventSettingsViewPDSA object</returns>
    public DeviceAlertEventSettingsViewPDSA CloneEntity(DeviceAlertEventSettingsViewPDSA entityToClone)
    {
      DeviceAlertEventSettingsViewPDSA newEntity = new DeviceAlertEventSettingsViewPDSA();

      newEntity.Pk = entityToClone.Pk;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.DeviceId = entityToClone.DeviceId;
      newEntity.DeviceName = entityToClone.DeviceName;
      newEntity.EventType = entityToClone.EventType;
      newEntity.DeviceType = entityToClone.DeviceType;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.TimeSchedule = entityToClone.TimeSchedule;
      newEntity.AlertEventTypeUid = entityToClone.AlertEventTypeUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.AcknowledgeTimeScheduleUid = entityToClone.AcknowledgeTimeScheduleUid;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.Flag = entityToClone.Flag;
      newEntity.AlertEventsFlag = entityToClone.AlertEventsFlag;

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
      
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_Pk_Header", "Pk"), false, typeof(Guid), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_Pk_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 65, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_DeviceId_Header", "Device Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_DeviceId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_DeviceName_Header", "Device Name"), false, typeof(string), 65, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_DeviceName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_EventType_Header", "Event Type"), false, typeof(string), 65, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_EventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_DeviceType_Header", "Device Type"), false, typeof(string), 12, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_DeviceType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 65, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_TimeSchedule_Header", "Time Schedule"), false, typeof(string), 65, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_TimeSchedule_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_AlertEventTypeUid_Header", "Alert Event Type Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_AlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_AcknowledgeTimeScheduleUid_Header", "Acknowledge Time Schedule Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_AcknowledgeTimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_IsActive_Header", "Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_Flag_Header", "Flag"), false, typeof(int), 10, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_Flag_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_AlertEventsFlag_Header", "Alert Events Flag"), false, typeof(int), 10, GetResourceMessage("GCS_DeviceAlertEventSettingsViewPDSA_AlertEventsFlag_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.Pk = Guid.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.EntityName = string.Empty;
      Entity.DeviceId = Guid.Empty;
      Entity.DeviceName = string.Empty;
      Entity.EventType = string.Empty;
      Entity.DeviceType = string.Empty;
      Entity.ClusterName = string.Empty;
      Entity.TimeSchedule = string.Empty;
      Entity.AlertEventTypeUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.AcknowledgeTimeScheduleUid = Guid.Empty;
      Entity.IsActive = false;
      Entity.Flag = 0;
      Entity.AlertEventsFlag = 0;

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
      
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk).Value = Entity.Pk;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId).Value = Entity.DeviceId;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName).Value = Entity.DeviceName;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType).Value = Entity.EventType;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType).Value = Entity.DeviceType;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule).Value = Entity.TimeSchedule;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid).Value = Entity.AlertEventTypeUid;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).Value = Entity.AcknowledgeTimeScheduleUid;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag).Value = Entity.Flag;
      if(!Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag).SetAsNull)
        Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag).Value = Entity.AlertEventsFlag;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk).IsNull == false)
        Entity.Pk = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Pk).GetAsGuid();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EntityName).GetAsString();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId).IsNull == false)
        Entity.DeviceId = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceId).GetAsGuid();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName).IsNull == false)
        Entity.DeviceName = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceName).GetAsString();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType).IsNull == false)
        Entity.EventType = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.EventType).GetAsString();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType).IsNull == false)
        Entity.DeviceType = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.DeviceType).GetAsString();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterName).GetAsString();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule).IsNull == false)
        Entity.TimeSchedule = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.TimeSchedule).GetAsString();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid).IsNull == false)
        Entity.AlertEventTypeUid = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventTypeUid).GetAsGuid();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).IsNull == false)
        Entity.AcknowledgeTimeScheduleUid = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag).IsNull == false)
        Entity.Flag = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.Flag).GetAsInteger();
      if(Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag).IsNull == false)
        Entity.AlertEventsFlag = Properties.GetByName(DeviceAlertEventSettingsViewPDSAValidator.ColumnNames.AlertEventsFlag).GetAsInteger();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DeviceAlertEventSettingsViewPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Pk'
    /// </summary>
    public static string Pk = "Pk";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'DeviceId'
    /// </summary>
    public static string DeviceId = "DeviceId";
    /// <summary>
    /// Returns 'DeviceName'
    /// </summary>
    public static string DeviceName = "DeviceName";
    /// <summary>
    /// Returns 'EventType'
    /// </summary>
    public static string EventType = "EventType";
    /// <summary>
    /// Returns 'DeviceType'
    /// </summary>
    public static string DeviceType = "DeviceType";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'TimeSchedule'
    /// </summary>
    public static string TimeSchedule = "TimeSchedule";
    /// <summary>
    /// Returns 'AlertEventTypeUid'
    /// </summary>
    public static string AlertEventTypeUid = "AlertEventTypeUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'AcknowledgeTimeScheduleUid'
    /// </summary>
    public static string AcknowledgeTimeScheduleUid = "AcknowledgeTimeScheduleUid";
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns 'Flag'
    /// </summary>
    public static string Flag = "Flag";
    /// <summary>
    /// Returns 'AlertEventsFlag'
    /// </summary>
    public static string AlertEventsFlag = "AlertEventsFlag";
    }
    #endregion
  }
}
