using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputDeviceEventPropertiesPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDeviceEventPropertiesPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDeviceEventPropertiesPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDeviceEventPropertiesPDSA Entity
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
    /// Clones the current InputDeviceEventPropertiesPDSA
    /// </summary>
    /// <returns>A cloned InputDeviceEventPropertiesPDSA object</returns>
    public InputDeviceEventPropertiesPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDeviceEventPropertiesPDSA
    /// </summary>
    /// <param name="entityToClone">The InputDeviceEventPropertiesPDSA entity to clone</param>
    /// <returns>A cloned InputDeviceEventPropertiesPDSA object</returns>
    public InputDeviceEventPropertiesPDSA CloneEntity(InputDeviceEventPropertiesPDSA entityToClone)
    {
      InputDeviceEventPropertiesPDSA newEntity = new InputDeviceEventPropertiesPDSA();

      newEntity.InputDeviceEventPropertiesUid = entityToClone.InputDeviceEventPropertiesUid;
      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
      newEntity.AudioBinaryResourceUid = entityToClone.AudioBinaryResourceUid;
      newEntity.ResponseInstructionsUid = entityToClone.ResponseInstructionsUid;
      newEntity.AcknowledgeTimeScheduleUid = entityToClone.AcknowledgeTimeScheduleUid;
      newEntity.InputDeviceAlertEventTypeUid = entityToClone.InputDeviceAlertEventTypeUid;
      newEntity.AcknowledgePriority = entityToClone.AcknowledgePriority;
      newEntity.Tag = entityToClone.Tag;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.ResponseRequired = entityToClone.ResponseRequired;
      newEntity.EntityId = entityToClone.EntityId;

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
      
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceEventPropertiesUid, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InputDeviceEventPropertiesUid_Header", "Input Device Event Properties Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InputDeviceEventPropertiesUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceUid, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InputDeviceUid_Header", "Input Device Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AudioBinaryResourceUid, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_AudioBinaryResourceUid_Header", "Audio Binary Resource Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_AudioBinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseInstructionsUid, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_ResponseInstructionsUid_Header", "Response Instructions Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_ResponseInstructionsUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_AcknowledgeTimeScheduleUid_Header", "Acknowledge Time Schedule Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_AcknowledgeTimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InputDeviceAlertEventTypeUid_Header", "Input Device Alert Event Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InputDeviceAlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgePriority, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_AcknowledgePriority_Header", "Acknowledge Priority"), true, typeof(int), 10, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_AcknowledgePriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_Tag_Header", "Tag"), true, typeof(string), 65, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_IsActive_Header", "Is Active"), true, typeof(bool), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseRequired, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_ResponseRequired_Header", "Response Required"), true, typeof(bool), -1, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_ResponseRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceEventPropertiesPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_InputDeviceEventPropertiesPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputDeviceEventPropertiesUid = Guid.Empty;
      Entity.InputDeviceUid = Guid.Empty;
      Entity.AudioBinaryResourceUid = Guid.Empty;
      Entity.ResponseInstructionsUid = Guid.Empty;
      Entity.AcknowledgeTimeScheduleUid = Guid.Empty;
      Entity.InputDeviceAlertEventTypeUid = Guid.Empty;
      Entity.AcknowledgePriority = 0;
      Entity.Tag = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.IsActive = false;
      Entity.ResponseRequired = false;
      Entity.EntityId = Guid.Empty;

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
      
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceEventPropertiesUid).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceEventPropertiesUid).Value = Entity.InputDeviceEventPropertiesUid;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceUid).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AudioBinaryResourceUid).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AudioBinaryResourceUid).Value = Entity.AudioBinaryResourceUid;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseInstructionsUid).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseInstructionsUid).Value = Entity.ResponseInstructionsUid;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).Value = Entity.AcknowledgeTimeScheduleUid;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid).Value = Entity.InputDeviceAlertEventTypeUid;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgePriority).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgePriority).Value = Entity.AcknowledgePriority;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseRequired).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseRequired).Value = Entity.ResponseRequired;
      if(!Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceEventPropertiesUid).IsNull == false)
        Entity.InputDeviceEventPropertiesUid = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceEventPropertiesUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AudioBinaryResourceUid).IsNull == false)
        Entity.AudioBinaryResourceUid = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AudioBinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseInstructionsUid).IsNull == false)
        Entity.ResponseInstructionsUid = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseInstructionsUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).IsNull == false)
        Entity.AcknowledgeTimeScheduleUid = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgeTimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid).IsNull == false)
        Entity.InputDeviceAlertEventTypeUid = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgePriority).IsNull == false)
        Entity.AcknowledgePriority = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.AcknowledgePriority).GetAsInteger();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseRequired).IsNull == false)
        Entity.ResponseRequired = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.ResponseRequired).GetAsBool();
      if(Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(InputDeviceEventPropertiesPDSAValidator.ColumnNames.EntityId).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDeviceEventPropertiesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputDeviceEventPropertiesUid'
    /// </summary>
    public static string InputDeviceEventPropertiesUid = "InputDeviceEventPropertiesUid";
    /// <summary>
    /// Returns 'InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "InputDeviceUid";
    /// <summary>
    /// Returns 'AudioBinaryResourceUid'
    /// </summary>
    public static string AudioBinaryResourceUid = "AudioBinaryResourceUid";
    /// <summary>
    /// Returns 'ResponseInstructionsUid'
    /// </summary>
    public static string ResponseInstructionsUid = "ResponseInstructionsUid";
    /// <summary>
    /// Returns 'AcknowledgeTimeScheduleUid'
    /// </summary>
    public static string AcknowledgeTimeScheduleUid = "AcknowledgeTimeScheduleUid";
    /// <summary>
    /// Returns 'InputDeviceAlertEventTypeUid'
    /// </summary>
    public static string InputDeviceAlertEventTypeUid = "InputDeviceAlertEventTypeUid";
    /// <summary>
    /// Returns 'AcknowledgePriority'
    /// </summary>
    public static string AcknowledgePriority = "AcknowledgePriority";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
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
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns 'ResponseRequired'
    /// </summary>
    public static string ResponseRequired = "ResponseRequired";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    }
    #endregion
  }
}
