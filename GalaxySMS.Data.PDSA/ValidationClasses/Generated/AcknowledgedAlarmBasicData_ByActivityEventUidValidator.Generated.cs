using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AcknowledgedAlarmBasicData_ByActivityEventUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AcknowledgedAlarmBasicData_ByActivityEventUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AcknowledgedAlarmBasicData_ByActivityEventUidPDSA Entity
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
    /// Clones the current AcknowledgedAlarmBasicData_ByActivityEventUidPDSA
    /// </summary>
    /// <returns>A cloned AcknowledgedAlarmBasicData_ByActivityEventUidPDSA object</returns>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AcknowledgedAlarmBasicData_ByActivityEventUidPDSA
    /// </summary>
    /// <param name="entityToClone">The AcknowledgedAlarmBasicData_ByActivityEventUidPDSA entity to clone</param>
    /// <returns>A cloned AcknowledgedAlarmBasicData_ByActivityEventUidPDSA object</returns>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSA CloneEntity(AcknowledgedAlarmBasicData_ByActivityEventUidPDSA entityToClone)
    {
      AcknowledgedAlarmBasicData_ByActivityEventUidPDSA newEntity = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSA();

      newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
      newEntity.DeviceEntityId = entityToClone.DeviceEntityId;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.AccessPortalAlarmEventAcknowledgmentUid = entityToClone.AccessPortalAlarmEventAcknowledgmentUid;
      newEntity.GalaxyPanelAlarmEventAcknowledgmentUid = entityToClone.GalaxyPanelAlarmEventAcknowledgmentUid;
      newEntity.InputDeviceAlarmEventAcknowledgmentUid = entityToClone.InputDeviceAlarmEventAcknowledgmentUid;
      newEntity.Response = entityToClone.Response;
      newEntity.AckedByUserId = entityToClone.AckedByUserId;
      newEntity.AckedByUserDisplayName = entityToClone.AckedByUserDisplayName;
      newEntity.AckedDateTime = entityToClone.AckedDateTime;
      newEntity.AckedUpdatedDateTime = entityToClone.AckedUpdatedDateTime;

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
      
      props.Add(PDSAProperty.Create(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_ActivityEventUid_Header", "Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_ActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      this.Properties.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid).IsNull == false)
        Entity.ActivityEventUid = this.Properties.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid).GetAsGuid();
      if(this.Properties.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AcknowledgedAlarmBasicData_ByActivityEventUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ActivityEventUid'
    /// </summary>
    public static string ActivityEventUid = "ActivityEventUid";
    /// <summary>
    /// Returns 'DeviceEntityId'
    /// </summary>
    public static string DeviceEntityId = "DeviceEntityId";
    /// <summary>
    /// Returns 'DeviceUid'
    /// </summary>
    public static string DeviceUid = "DeviceUid";
    /// <summary>
    /// Returns 'AccessPortalAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string AccessPortalAlarmEventAcknowledgmentUid = "AccessPortalAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns 'GalaxyPanelAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string GalaxyPanelAlarmEventAcknowledgmentUid = "GalaxyPanelAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns 'InputDeviceAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string InputDeviceAlarmEventAcknowledgmentUid = "InputDeviceAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns 'Response'
    /// </summary>
    public static string Response = "Response";
    /// <summary>
    /// Returns 'AckedByUserId'
    /// </summary>
    public static string AckedByUserId = "AckedByUserId";
    /// <summary>
    /// Returns 'AckedByUserDisplayName'
    /// </summary>
    public static string AckedByUserDisplayName = "AckedByUserDisplayName";
    /// <summary>
    /// Returns 'AckedDateTime'
    /// </summary>
    public static string AckedDateTime = "AckedDateTime";
    /// <summary>
    /// Returns 'AckedUpdatedDateTime'
    /// </summary>
    public static string AckedUpdatedDateTime = "AckedUpdatedDateTime";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AcknowledgedAlarmBasicData_ByActivityEventUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ActivityEventUid'
    /// </summary>
    public static string ActivityEventUid = "@ActivityEventUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
