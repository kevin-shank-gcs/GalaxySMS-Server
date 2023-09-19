using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the DeviceAlertEventSettings_ByEntityIdPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DeviceAlertEventSettings_ByEntityIdPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DeviceAlertEventSettings_ByEntityIdPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DeviceAlertEventSettings_ByEntityIdPDSA Entity
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
    /// Clones the current DeviceAlertEventSettings_ByEntityIdPDSA
    /// </summary>
    /// <returns>A cloned DeviceAlertEventSettings_ByEntityIdPDSA object</returns>
    public DeviceAlertEventSettings_ByEntityIdPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DeviceAlertEventSettings_ByEntityIdPDSA
    /// </summary>
    /// <param name="entityToClone">The DeviceAlertEventSettings_ByEntityIdPDSA entity to clone</param>
    /// <returns>A cloned DeviceAlertEventSettings_ByEntityIdPDSA object</returns>
    public DeviceAlertEventSettings_ByEntityIdPDSA CloneEntity(DeviceAlertEventSettings_ByEntityIdPDSA entityToClone)
    {
      DeviceAlertEventSettings_ByEntityIdPDSA newEntity = new DeviceAlertEventSettings_ByEntityIdPDSA();

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
      
      props.Add(PDSAProperty.Create(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_DeviceAlertEventSettings_ByEntityIdPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_DeviceAlertEventSettings_ByEntityIdPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.IsActive, GetResourceMessage("GCS_DeviceAlertEventSettings_ByEntityIdPDSA_IsActive_Header", "Is Active"), false, typeof(bool), 0, GetResourceMessage("GCS_DeviceAlertEventSettings_ByEntityIdPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_DeviceAlertEventSettings_ByEntityIdPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_DeviceAlertEventSettings_ByEntityIdPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.IsActive).Value = Entity.IsActive;
      this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.IsActive).IsNull == false)
        Entity.IsActive = this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.IsActive).GetAsBool();
      if(this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(DeviceAlertEventSettings_ByEntityIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DeviceAlertEventSettings_ByEntityIdPDSA class.
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
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DeviceAlertEventSettings_ByEntityIdPDSA class.
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
    /// Returns '@IsActive'
    /// </summary>
    public static string IsActive = "@IsActive";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
