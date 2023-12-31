using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputCommandAuditPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputCommandAuditPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputCommandAuditPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputCommandAuditPDSA Entity
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
    /// Clones the current InputCommandAuditPDSA
    /// </summary>
    /// <returns>A cloned InputCommandAuditPDSA object</returns>
    public InputCommandAuditPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputCommandAuditPDSA
    /// </summary>
    /// <param name="entityToClone">The InputCommandAuditPDSA entity to clone</param>
    /// <returns>A cloned InputCommandAuditPDSA object</returns>
    public InputCommandAuditPDSA CloneEntity(InputCommandAuditPDSA entityToClone)
    {
      InputCommandAuditPDSA newEntity = new InputCommandAuditPDSA();

      newEntity.InputCommandAuditUid = entityToClone.InputCommandAuditUid;
      newEntity.UserId = entityToClone.UserId;
      newEntity.InputCommandUid = entityToClone.InputCommandUid;
      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
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
      
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.InputCommandAuditUid, GetResourceMessage("GCS_InputCommandAuditPDSA_InputCommandAuditUid_Header", "Input Command Audit Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandAuditPDSA_InputCommandAuditUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.UserId, GetResourceMessage("GCS_InputCommandAuditPDSA_UserId_Header", "User Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandAuditPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.InputCommandUid, GetResourceMessage("GCS_InputCommandAuditPDSA_InputCommandUid_Header", "Input Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandAuditPDSA_InputCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.InputDeviceUid, GetResourceMessage("GCS_InputCommandAuditPDSA_InputDeviceUid_Header", "Input Device Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandAuditPDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputCommandAuditPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_InputCommandAuditPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputCommandAuditPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputCommandAuditPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputCommandAuditPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_InputCommandAuditPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputCommandAuditPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputCommandAuditPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputCommandAuditPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputCommandAuditPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputCommandAuditUid = Guid.Empty;
      Entity.UserId = Guid.Empty;
      Entity.InputCommandUid = Guid.Empty;
      Entity.InputDeviceUid = Guid.Empty;
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
      
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandAuditUid).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandAuditUid).Value = Entity.InputCommandAuditUid;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UserId).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UserId).Value = Entity.UserId;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandUid).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandUid).Value = Entity.InputCommandUid;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputDeviceUid).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandAuditUid).IsNull == false)
        Entity.InputCommandAuditUid = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandAuditUid).GetAsGuid();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UserId).GetAsGuid();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandUid).IsNull == false)
        Entity.InputCommandUid = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputCommandUid).GetAsGuid();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InputDeviceUid).GetAsGuid();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputCommandAuditPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputCommandAuditUid'
    /// </summary>
    public static string InputCommandAuditUid = "InputCommandAuditUid";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'InputCommandUid'
    /// </summary>
    public static string InputCommandUid = "InputCommandUid";
    /// <summary>
    /// Returns 'InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "InputDeviceUid";
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
