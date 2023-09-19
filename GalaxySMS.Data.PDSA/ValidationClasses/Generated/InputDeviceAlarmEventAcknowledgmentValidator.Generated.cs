using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputDeviceAlarmEventAcknowledgmentPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDeviceAlarmEventAcknowledgmentPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDeviceAlarmEventAcknowledgmentPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDeviceAlarmEventAcknowledgmentPDSA Entity
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
    /// Clones the current InputDeviceAlarmEventAcknowledgmentPDSA
    /// </summary>
    /// <returns>A cloned InputDeviceAlarmEventAcknowledgmentPDSA object</returns>
    public InputDeviceAlarmEventAcknowledgmentPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDeviceAlarmEventAcknowledgmentPDSA
    /// </summary>
    /// <param name="entityToClone">The InputDeviceAlarmEventAcknowledgmentPDSA entity to clone</param>
    /// <returns>A cloned InputDeviceAlarmEventAcknowledgmentPDSA object</returns>
    public InputDeviceAlarmEventAcknowledgmentPDSA CloneEntity(InputDeviceAlarmEventAcknowledgmentPDSA entityToClone)
    {
      InputDeviceAlarmEventAcknowledgmentPDSA newEntity = new InputDeviceAlarmEventAcknowledgmentPDSA();

      newEntity.InputDeviceAlarmEventAcknowledgmentUid = entityToClone.InputDeviceAlarmEventAcknowledgmentUid;
      newEntity.InputDeviceActivityEventUid = entityToClone.InputDeviceActivityEventUid;
      newEntity.UserId = entityToClone.UserId;
      newEntity.Response = entityToClone.Response;
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
      
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InputDeviceAlarmEventAcknowledgmentUid_Header", "Input Device Alarm Event Acknowledgment Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InputDeviceAlarmEventAcknowledgmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceActivityEventUid, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InputDeviceActivityEventUid_Header", "Input Device Activity Event Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InputDeviceActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_UserId_Header", "User Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_Response_Header", "Response"), false, typeof(string), 1000, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_Response_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputDeviceAlarmEventAcknowledgmentPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputDeviceAlarmEventAcknowledgmentUid = Guid.Empty;
      Entity.InputDeviceActivityEventUid = Guid.Empty;
      Entity.UserId = Guid.Empty;
      Entity.Response = string.Empty;
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
      
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).Value = Entity.InputDeviceAlarmEventAcknowledgmentUid;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceActivityEventUid).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceActivityEventUid).Value = Entity.InputDeviceActivityEventUid;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId).Value = Entity.UserId;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response).Value = Entity.Response;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.InputDeviceAlarmEventAcknowledgmentUid = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceActivityEventUid).IsNull == false)
        Entity.InputDeviceActivityEventUid = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InputDeviceActivityEventUid).GetAsGuid();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId).GetAsGuid();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response).IsNull == false)
        Entity.Response = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response).GetAsString();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputDeviceAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDeviceAlarmEventAcknowledgmentPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputDeviceAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string InputDeviceAlarmEventAcknowledgmentUid = "InputDeviceAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns 'InputDeviceActivityEventUid'
    /// </summary>
    public static string InputDeviceActivityEventUid = "InputDeviceActivityEventUid";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'Response'
    /// </summary>
    public static string Response = "Response";
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
