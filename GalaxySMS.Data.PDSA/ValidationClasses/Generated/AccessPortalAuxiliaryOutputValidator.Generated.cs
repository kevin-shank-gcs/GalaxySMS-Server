using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalAuxiliaryOutputPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalAuxiliaryOutputPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalAuxiliaryOutputPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalAuxiliaryOutputPDSA Entity
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
    /// Clones the current AccessPortalAuxiliaryOutputPDSA
    /// </summary>
    /// <returns>A cloned AccessPortalAuxiliaryOutputPDSA object</returns>
    public AccessPortalAuxiliaryOutputPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalAuxiliaryOutputPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalAuxiliaryOutputPDSA entity to clone</param>
    /// <returns>A cloned AccessPortalAuxiliaryOutputPDSA object</returns>
    public AccessPortalAuxiliaryOutputPDSA CloneEntity(AccessPortalAuxiliaryOutputPDSA entityToClone)
    {
      AccessPortalAuxiliaryOutputPDSA newEntity = new AccessPortalAuxiliaryOutputPDSA();

      newEntity.AccessPortalAuxiliaryOutputUid = entityToClone.AccessPortalAuxiliaryOutputUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.AccessPortalAuxiliaryOutputModeUid = entityToClone.AccessPortalAuxiliaryOutputModeUid;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.Description = entityToClone.Description;
      newEntity.Tag = entityToClone.Tag;
      newEntity.ActivationDelay = entityToClone.ActivationDelay;
      newEntity.ActivationDuration = entityToClone.ActivationDuration;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.IllegalOpen = entityToClone.IllegalOpen;
      newEntity.OpenTooLong = entityToClone.OpenTooLong;
      newEntity.InvalidAttempt = entityToClone.InvalidAttempt;
      newEntity.AccessGranted = entityToClone.AccessGranted;
      newEntity.Duress = entityToClone.Duress;
      newEntity.PassbackViolation = entityToClone.PassbackViolation;

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
      
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputUid, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessPortalAuxiliaryOutputUid_Header", "Access Portal Auxiliary Output Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessPortalAuxiliaryOutputUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessPortalUid_Header", "Access Portal Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessPortalAuxiliaryOutputModeUid_Header", "Access Portal Auxiliary Output Mode Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessPortalAuxiliaryOutputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.TimeScheduleUid, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_TimeScheduleUid_Header", "Time Schedule Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_Tag_Header", "Tag"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDelay, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_ActivationDelay_Header", "Activation Delay"), true, typeof(int), 10, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_ActivationDelay_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDuration, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_ActivationDuration_Header", "Activation Duration"), true, typeof(int), 10, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_ActivationDuration_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.IllegalOpen, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_IllegalOpen_Header", "Illegal Open"), true, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_IllegalOpen_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.OpenTooLong, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_OpenTooLong_Header", "Open Too Long"), true, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_OpenTooLong_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InvalidAttempt, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_InvalidAttempt_Header", "Invalid Attempt"), true, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_InvalidAttempt_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessGranted, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessGranted_Header", "Access Granted"), true, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_AccessGranted_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Duress, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_Duress_Header", "Duress"), true, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_Duress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.PassbackViolation, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_PassbackViolation_Header", "Passback Violation"), true, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputPDSA_PassbackViolation_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalAuxiliaryOutputUid = Guid.NewGuid();
      Entity.AccessPortalUid = Guid.NewGuid();
      Entity.AccessPortalAuxiliaryOutputModeUid = Guid.NewGuid();
      Entity.TimeScheduleUid = Guid.NewGuid();
      Entity.Description = string.Empty;
      Entity.Tag = string.Empty;
      Entity.ActivationDelay = 0;
      Entity.ActivationDuration = 0;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.IllegalOpen = false;
      Entity.OpenTooLong = false;
      Entity.InvalidAttempt = false;
      Entity.AccessGranted = false;
      Entity.Duress = false;
      Entity.PassbackViolation = false;

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
      
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputUid).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputUid).Value = Entity.AccessPortalAuxiliaryOutputUid;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).Value = Entity.AccessPortalAuxiliaryOutputModeUid;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.TimeScheduleUid).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDelay).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDelay).Value = Entity.ActivationDelay;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDuration).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDuration).Value = Entity.ActivationDuration;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.IllegalOpen).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.IllegalOpen).Value = Entity.IllegalOpen;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.OpenTooLong).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.OpenTooLong).Value = Entity.OpenTooLong;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InvalidAttempt).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InvalidAttempt).Value = Entity.InvalidAttempt;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessGranted).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessGranted).Value = Entity.AccessGranted;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Duress).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Duress).Value = Entity.Duress;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.PassbackViolation).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.PassbackViolation).Value = Entity.PassbackViolation;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputUid).IsNull == false)
        Entity.AccessPortalAuxiliaryOutputUid = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).IsNull == false)
        Entity.AccessPortalAuxiliaryOutputModeUid = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.TimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDelay).IsNull == false)
        Entity.ActivationDelay = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDelay).GetAsInteger();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDuration).IsNull == false)
        Entity.ActivationDuration = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ActivationDuration).GetAsInteger();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.IllegalOpen).IsNull == false)
        Entity.IllegalOpen = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.IllegalOpen).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.OpenTooLong).IsNull == false)
        Entity.OpenTooLong = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.OpenTooLong).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InvalidAttempt).IsNull == false)
        Entity.InvalidAttempt = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.InvalidAttempt).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessGranted).IsNull == false)
        Entity.AccessGranted = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.AccessGranted).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Duress).IsNull == false)
        Entity.Duress = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.Duress).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.PassbackViolation).IsNull == false)
        Entity.PassbackViolation = Properties.GetByName(AccessPortalAuxiliaryOutputPDSAValidator.ColumnNames.PassbackViolation).GetValueAsBoolean();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalAuxiliaryOutputPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalAuxiliaryOutputUid'
    /// </summary>
    public static string AccessPortalAuxiliaryOutputUid = "AccessPortalAuxiliaryOutputUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'AccessPortalAuxiliaryOutputModeUid'
    /// </summary>
    public static string AccessPortalAuxiliaryOutputModeUid = "AccessPortalAuxiliaryOutputModeUid";
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'ActivationDelay'
    /// </summary>
    public static string ActivationDelay = "ActivationDelay";
    /// <summary>
    /// Returns 'ActivationDuration'
    /// </summary>
    public static string ActivationDuration = "ActivationDuration";
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
    /// Returns 'IllegalOpen'
    /// </summary>
    public static string IllegalOpen = "IllegalOpen";
    /// <summary>
    /// Returns 'OpenTooLong'
    /// </summary>
    public static string OpenTooLong = "OpenTooLong";
    /// <summary>
    /// Returns 'InvalidAttempt'
    /// </summary>
    public static string InvalidAttempt = "InvalidAttempt";
    /// <summary>
    /// Returns 'AccessGranted'
    /// </summary>
    public static string AccessGranted = "AccessGranted";
    /// <summary>
    /// Returns 'Duress'
    /// </summary>
    public static string Duress = "Duress";
    /// <summary>
    /// Returns 'PassbackViolation'
    /// </summary>
    public static string PassbackViolation = "PassbackViolation";
    }
    #endregion
  }
}
