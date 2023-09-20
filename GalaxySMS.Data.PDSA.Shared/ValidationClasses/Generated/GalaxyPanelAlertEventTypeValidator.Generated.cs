using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyPanelAlertEventTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelAlertEventTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelAlertEventTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelAlertEventTypePDSA Entity
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
    /// Clones the current GalaxyPanelAlertEventTypePDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelAlertEventTypePDSA object</returns>
    public GalaxyPanelAlertEventTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelAlertEventTypePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelAlertEventTypePDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelAlertEventTypePDSA object</returns>
    public GalaxyPanelAlertEventTypePDSA CloneEntity(GalaxyPanelAlertEventTypePDSA entityToClone)
    {
      GalaxyPanelAlertEventTypePDSA newEntity = new GalaxyPanelAlertEventTypePDSA();

      newEntity.GalaxyPanelAlertEventTypeUid = entityToClone.GalaxyPanelAlertEventTypeUid;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Display = entityToClone.Display;
      newEntity.Description = entityToClone.Description;
      newEntity.Tag = entityToClone.Tag;
      newEntity.CanAcknowledge = entityToClone.CanAcknowledge;
      newEntity.CanHaveInputOutputGroupOffset = entityToClone.CanHaveInputOutputGroupOffset;
      newEntity.CanHaveSchedule = entityToClone.CanHaveSchedule;
      newEntity.CanHaveAudio = entityToClone.CanHaveAudio;
      newEntity.CanHaveInstructions = entityToClone.CanHaveInstructions;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
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
      
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.GalaxyPanelAlertEventTypeUid, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_GalaxyPanelAlertEventTypeUid_Header", "Galaxy Panel Alert Event Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_GalaxyPanelAlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_Tag_Header", "Tag"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanAcknowledge_Header", "Can Acknowledge"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanAcknowledge_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveInputOutputGroupOffset_Header", "Can Have Input Output Group Offset"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveInputOutputGroupOffset_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveSchedule_Header", "Can Have Schedule"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveSchedule_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveAudio_Header", "Can Have Audio"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveAudio_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveInstructions_Header", "Can Have Instructions"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CanHaveInstructions_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_GalaxyPanelAlertEventTypePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyPanelAlertEventTypeUid = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.Description = string.Empty;
      Entity.Tag = string.Empty;
      Entity.CanAcknowledge = false;
      Entity.CanHaveInputOutputGroupOffset = false;
      Entity.CanHaveSchedule = false;
      Entity.CanHaveAudio = false;
      Entity.CanHaveInstructions = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
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
      
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.GalaxyPanelAlertEventTypeUid).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.GalaxyPanelAlertEventTypeUid).Value = Entity.GalaxyPanelAlertEventTypeUid;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge).Value = Entity.CanAcknowledge;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset).Value = Entity.CanHaveInputOutputGroupOffset;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule).Value = Entity.CanHaveSchedule;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio).Value = Entity.CanHaveAudio;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions).Value = Entity.CanHaveInstructions;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.GalaxyPanelAlertEventTypeUid).IsNull == false)
        Entity.GalaxyPanelAlertEventTypeUid = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.GalaxyPanelAlertEventTypeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge).IsNull == false)
        Entity.CanAcknowledge = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge).GetAsBool();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset).IsNull == false)
        Entity.CanHaveInputOutputGroupOffset = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset).GetAsBool();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule).IsNull == false)
        Entity.CanHaveSchedule = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule).GetAsBool();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio).IsNull == false)
        Entity.CanHaveAudio = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio).GetAsBool();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions).IsNull == false)
        Entity.CanHaveInstructions = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions).GetAsBool();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(GalaxyPanelAlertEventTypePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelAlertEventTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyPanelAlertEventTypeUid'
    /// </summary>
    public static string GalaxyPanelAlertEventTypeUid = "GalaxyPanelAlertEventTypeUid";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'CanAcknowledge'
    /// </summary>
    public static string CanAcknowledge = "CanAcknowledge";
    /// <summary>
    /// Returns 'CanHaveInputOutputGroupOffset'
    /// </summary>
    public static string CanHaveInputOutputGroupOffset = "CanHaveInputOutputGroupOffset";
    /// <summary>
    /// Returns 'CanHaveSchedule'
    /// </summary>
    public static string CanHaveSchedule = "CanHaveSchedule";
    /// <summary>
    /// Returns 'CanHaveAudio'
    /// </summary>
    public static string CanHaveAudio = "CanHaveAudio";
    /// <summary>
    /// Returns 'CanHaveInstructions'
    /// </summary>
    public static string CanHaveInstructions = "CanHaveInstructions";
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
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    }
    #endregion
  }
}
