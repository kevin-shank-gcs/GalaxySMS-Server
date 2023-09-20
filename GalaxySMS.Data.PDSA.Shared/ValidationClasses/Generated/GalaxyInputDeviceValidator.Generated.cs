using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyInputDevicePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyInputDevicePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyInputDevicePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyInputDevicePDSA Entity
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
    /// Clones the current GalaxyInputDevicePDSA
    /// </summary>
    /// <returns>A cloned GalaxyInputDevicePDSA object</returns>
    public GalaxyInputDevicePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyInputDevicePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyInputDevicePDSA entity to clone</param>
    /// <returns>A cloned GalaxyInputDevicePDSA object</returns>
    public GalaxyInputDevicePDSA CloneEntity(GalaxyInputDevicePDSA entityToClone)
    {
      GalaxyInputDevicePDSA newEntity = new GalaxyInputDevicePDSA();

      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
      newEntity.InputDeviceSupervisionTypeUid = entityToClone.InputDeviceSupervisionTypeUid;
      newEntity.GalaxyInputModeUid = entityToClone.GalaxyInputModeUid;
      newEntity.DelayDuration = entityToClone.DelayDuration;
      newEntity.GalaxyInputDelayTypeUid = entityToClone.GalaxyInputDelayTypeUid;
      newEntity.DisableDisarmedOnOffLogEvents = entityToClone.DisableDisarmedOnOffLogEvents;
      newEntity.IsNormalOpen = entityToClone.IsNormalOpen;
      newEntity.NormalChangeThreshold = entityToClone.NormalChangeThreshold;
      newEntity.TroubleOpenThreshold = entityToClone.TroubleOpenThreshold;
      newEntity.AlternateVoltagesEnabled = entityToClone.AlternateVoltagesEnabled;
      newEntity.AlternateTroubleShortThreshold = entityToClone.AlternateTroubleShortThreshold;
      newEntity.AlternateNormalChangeThreshold = entityToClone.AlternateNormalChangeThreshold;
      newEntity.AlternateTroubleOpenThreshold = entityToClone.AlternateTroubleOpenThreshold;
      newEntity.TroubleShortThreshold = entityToClone.TroubleShortThreshold;
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
      
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceUid, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InputDeviceUid_Header", "Input Device Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InputDeviceSupervisionTypeUid_Header", "Input Device Supervision Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InputDeviceSupervisionTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputModeUid, GetResourceMessage("GCS_GalaxyInputDevicePDSA_GalaxyInputModeUid_Header", "Galaxy Input Mode Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_GalaxyInputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.DelayDuration, GetResourceMessage("GCS_GalaxyInputDevicePDSA_DelayDuration_Header", "Delay Duration"), true, typeof(int), 10, GetResourceMessage("GCS_GalaxyInputDevicePDSA_DelayDuration_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputDelayTypeUid, GetResourceMessage("GCS_GalaxyInputDevicePDSA_GalaxyInputDelayTypeUid_Header", "Galaxy Input Delay Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_GalaxyInputDelayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents, GetResourceMessage("GCS_GalaxyInputDevicePDSA_DisableDisarmedOnOffLogEvents_Header", "Disable Disarmed On Off Log Events"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_DisableDisarmedOnOffLogEvents_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.IsNormalOpen, GetResourceMessage("GCS_GalaxyInputDevicePDSA_IsNormalOpen_Header", "Is Normal Open"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_IsNormalOpen_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.NormalChangeThreshold, GetResourceMessage("GCS_GalaxyInputDevicePDSA_NormalChangeThreshold_Header", "Normal Change Threshold"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_NormalChangeThreshold_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleOpenThreshold, GetResourceMessage("GCS_GalaxyInputDevicePDSA_TroubleOpenThreshold_Header", "Trouble Open Threshold"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_TroubleOpenThreshold_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateVoltagesEnabled, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateVoltagesEnabled_Header", "Alternate Voltages Enabled"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateVoltagesEnabled_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleShortThreshold, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateTroubleShortThreshold_Header", "Alternate Trouble Short Threshold"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateTroubleShortThreshold_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateNormalChangeThreshold, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateNormalChangeThreshold_Header", "Alternate Normal Change Threshold"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateNormalChangeThreshold_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateTroubleOpenThreshold_Header", "Alternate Trouble Open Threshold"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_AlternateTroubleOpenThreshold_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleShortThreshold, GetResourceMessage("GCS_GalaxyInputDevicePDSA_TroubleShortThreshold_Header", "Trouble Short Threshold"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_TroubleShortThreshold_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyInputDevicePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyInputDevicePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyInputDevicePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyInputDevicePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInputDevicePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyInputDevicePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInputDevicePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputDeviceUid = Guid.Empty;
      Entity.InputDeviceSupervisionTypeUid = Guid.Empty;
      Entity.GalaxyInputModeUid = Guid.Empty;
      Entity.DelayDuration = 0;
      Entity.GalaxyInputDelayTypeUid = Guid.Empty;
      Entity.DisableDisarmedOnOffLogEvents = false;
      Entity.IsNormalOpen = false;
      Entity.NormalChangeThreshold = 0;
      Entity.TroubleOpenThreshold = 0;
      Entity.AlternateVoltagesEnabled = false;
      Entity.AlternateTroubleShortThreshold = 0;
      Entity.AlternateNormalChangeThreshold = 0;
      Entity.AlternateTroubleOpenThreshold = 0;
      Entity.TroubleShortThreshold = 0;
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
      
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceUid).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid).Value = Entity.InputDeviceSupervisionTypeUid;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputModeUid).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputModeUid).Value = Entity.GalaxyInputModeUid;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DelayDuration).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DelayDuration).Value = Entity.DelayDuration;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputDelayTypeUid).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputDelayTypeUid).Value = Entity.GalaxyInputDelayTypeUid;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents).Value = Entity.DisableDisarmedOnOffLogEvents;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.IsNormalOpen).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.IsNormalOpen).Value = Entity.IsNormalOpen;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.NormalChangeThreshold).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.NormalChangeThreshold).Value = Entity.NormalChangeThreshold;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleOpenThreshold).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleOpenThreshold).Value = Entity.TroubleOpenThreshold;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateVoltagesEnabled).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateVoltagesEnabled).Value = Entity.AlternateVoltagesEnabled;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleShortThreshold).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleShortThreshold).Value = Entity.AlternateTroubleShortThreshold;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateNormalChangeThreshold).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateNormalChangeThreshold).Value = Entity.AlternateNormalChangeThreshold;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold).Value = Entity.AlternateTroubleOpenThreshold;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleShortThreshold).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleShortThreshold).Value = Entity.TroubleShortThreshold;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid).IsNull == false)
        Entity.InputDeviceSupervisionTypeUid = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputModeUid).IsNull == false)
        Entity.GalaxyInputModeUid = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputModeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DelayDuration).IsNull == false)
        Entity.DelayDuration = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DelayDuration).GetAsInteger();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputDelayTypeUid).IsNull == false)
        Entity.GalaxyInputDelayTypeUid = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.GalaxyInputDelayTypeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents).IsNull == false)
        Entity.DisableDisarmedOnOffLogEvents = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents).GetAsBool();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.IsNormalOpen).IsNull == false)
        Entity.IsNormalOpen = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.IsNormalOpen).GetAsBool();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.NormalChangeThreshold).IsNull == false)
        Entity.NormalChangeThreshold = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.NormalChangeThreshold).GetAsShort();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleOpenThreshold).IsNull == false)
        Entity.TroubleOpenThreshold = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleOpenThreshold).GetAsShort();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateVoltagesEnabled).IsNull == false)
        Entity.AlternateVoltagesEnabled = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateVoltagesEnabled).GetAsBool();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleShortThreshold).IsNull == false)
        Entity.AlternateTroubleShortThreshold = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleShortThreshold).GetAsShort();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateNormalChangeThreshold).IsNull == false)
        Entity.AlternateNormalChangeThreshold = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateNormalChangeThreshold).GetAsShort();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold).IsNull == false)
        Entity.AlternateTroubleOpenThreshold = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold).GetAsShort();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleShortThreshold).IsNull == false)
        Entity.TroubleShortThreshold = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.TroubleShortThreshold).GetAsShort();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyInputDevicePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyInputDevicePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "InputDeviceUid";
    /// <summary>
    /// Returns 'InputDeviceSupervisionTypeUid'
    /// </summary>
    public static string InputDeviceSupervisionTypeUid = "InputDeviceSupervisionTypeUid";
    /// <summary>
    /// Returns 'GalaxyInputModeUid'
    /// </summary>
    public static string GalaxyInputModeUid = "GalaxyInputModeUid";
    /// <summary>
    /// Returns 'DelayDuration'
    /// </summary>
    public static string DelayDuration = "DelayDuration";
    /// <summary>
    /// Returns 'GalaxyInputDelayTypeUid'
    /// </summary>
    public static string GalaxyInputDelayTypeUid = "GalaxyInputDelayTypeUid";
    /// <summary>
    /// Returns 'DisableDisarmedOnOffLogEvents'
    /// </summary>
    public static string DisableDisarmedOnOffLogEvents = "DisableDisarmedOnOffLogEvents";
    /// <summary>
    /// Returns 'IsNormalOpen'
    /// </summary>
    public static string IsNormalOpen = "IsNormalOpen";
    /// <summary>
    /// Returns 'NormalChangeThreshold'
    /// </summary>
    public static string NormalChangeThreshold = "NormalChangeThreshold";
    /// <summary>
    /// Returns 'TroubleOpenThreshold'
    /// </summary>
    public static string TroubleOpenThreshold = "TroubleOpenThreshold";
    /// <summary>
    /// Returns 'AlternateVoltagesEnabled'
    /// </summary>
    public static string AlternateVoltagesEnabled = "AlternateVoltagesEnabled";
    /// <summary>
    /// Returns 'AlternateTroubleShortThreshold'
    /// </summary>
    public static string AlternateTroubleShortThreshold = "AlternateTroubleShortThreshold";
    /// <summary>
    /// Returns 'AlternateNormalChangeThreshold'
    /// </summary>
    public static string AlternateNormalChangeThreshold = "AlternateNormalChangeThreshold";
    /// <summary>
    /// Returns 'AlternateTroubleOpenThreshold'
    /// </summary>
    public static string AlternateTroubleOpenThreshold = "AlternateTroubleOpenThreshold";
    /// <summary>
    /// Returns 'TroubleShortThreshold'
    /// </summary>
    public static string TroubleShortThreshold = "TroubleShortThreshold";
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
