using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA Entity
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
    /// Clones the current GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA object</returns>
    public GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA object</returns>
    public GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA CloneEntity(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA entityToClone)
    {
      GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA newEntity = new GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA();

      newEntity.OutputDeviceUid = entityToClone.OutputDeviceUid;
      newEntity.GalaxyOutputDeviceInputSourceUid = entityToClone.GalaxyOutputDeviceInputSourceUid;
      newEntity.GalaxyOutputInputSourceTriggerConditionUid = entityToClone.GalaxyOutputInputSourceTriggerConditionUid;
      newEntity.GalaxyOutputInputSourceModeUid = entityToClone.GalaxyOutputInputSourceModeUid;
      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
      newEntity.SourceNumber = entityToClone.SourceNumber;
      newEntity.InputOutputGroupMode = entityToClone.InputOutputGroupMode;
      newEntity.TriggerConditionCode = entityToClone.TriggerConditionCode;
      newEntity.TriggerConditionDisplay = entityToClone.TriggerConditionDisplay;
      newEntity.SourceModeCode = entityToClone.SourceModeCode;
      newEntity.SourceModeDisplay = entityToClone.SourceModeDisplay;
      newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
      newEntity.IOGroupDisplay = entityToClone.IOGroupDisplay;

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
      
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.OutputDeviceUid, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_OutputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_GalaxyOutputDeviceInputSourceUid_Header", "Galaxy Output Device Input Source Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_GalaxyOutputDeviceInputSourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceTriggerConditionUid, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_GalaxyOutputInputSourceTriggerConditionUid_Header", "Galaxy Output Input Source Trigger Condition Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_GalaxyOutputInputSourceTriggerConditionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceModeUid, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_GalaxyOutputInputSourceModeUid_Header", "Galaxy Output Input Source Mode Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_GalaxyOutputInputSourceModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceNumber, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_SourceNumber_Header", "Source Number"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_SourceNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupMode, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_InputOutputGroupMode_Header", "Input Output Group Mode"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_InputOutputGroupMode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionCode, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_TriggerConditionCode_Header", "Trigger Condition Code"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_TriggerConditionCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionDisplay, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_TriggerConditionDisplay_Header", "Trigger Condition Display"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_TriggerConditionDisplay_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeCode, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_SourceModeCode_Header", "Source Mode Code"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_SourceModeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeDisplay, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_SourceModeDisplay_Header", "Source Mode Display"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_SourceModeDisplay_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_IOGroupNumber_Header", "IO Group Number"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_IOGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupDisplay, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_IOGroupDisplay_Header", "IO Group Display"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA_IOGroupDisplay_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.OutputDeviceUid = Guid.Empty;
      Entity.GalaxyOutputDeviceInputSourceUid = Guid.Empty;
      Entity.GalaxyOutputInputSourceTriggerConditionUid = Guid.Empty;
      Entity.GalaxyOutputInputSourceModeUid = Guid.Empty;
      Entity.InputOutputGroupUid = Guid.Empty;
      Entity.SourceNumber = 0;
      Entity.InputOutputGroupMode = false;
      Entity.TriggerConditionCode = 0;
      Entity.TriggerConditionDisplay = string.Empty;
      Entity.SourceModeCode = 0;
      Entity.SourceModeDisplay = string.Empty;
      Entity.IOGroupNumber = 0;
      Entity.IOGroupDisplay = string.Empty;

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
      
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.OutputDeviceUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).Value = Entity.GalaxyOutputDeviceInputSourceUid;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceTriggerConditionUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceTriggerConditionUid).Value = Entity.GalaxyOutputInputSourceTriggerConditionUid;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceModeUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceModeUid).Value = Entity.GalaxyOutputInputSourceModeUid;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceNumber).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceNumber).Value = Entity.SourceNumber;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupMode).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupMode).Value = Entity.InputOutputGroupMode;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionCode).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionCode).Value = Entity.TriggerConditionCode;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionDisplay).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionDisplay).Value = Entity.TriggerConditionDisplay;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeCode).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeCode).Value = Entity.SourceModeCode;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeDisplay).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeDisplay).Value = Entity.SourceModeDisplay;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).Value = Entity.IOGroupNumber;
      if(!Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupDisplay).SetAsNull)
        Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupDisplay).Value = Entity.IOGroupDisplay;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.OutputDeviceUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).IsNull == false)
        Entity.GalaxyOutputDeviceInputSourceUid = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceTriggerConditionUid).IsNull == false)
        Entity.GalaxyOutputInputSourceTriggerConditionUid = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceTriggerConditionUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceModeUid).IsNull == false)
        Entity.GalaxyOutputInputSourceModeUid = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputInputSourceModeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceNumber).IsNull == false)
        Entity.SourceNumber = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceNumber).GetAsShort();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupMode).IsNull == false)
        Entity.InputOutputGroupMode = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupMode).GetAsBool();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionCode).IsNull == false)
        Entity.TriggerConditionCode = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionCode).GetAsShort();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionDisplay).IsNull == false)
        Entity.TriggerConditionDisplay = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.TriggerConditionDisplay).GetAsString();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeCode).IsNull == false)
        Entity.SourceModeCode = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeCode).GetAsShort();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeDisplay).IsNull == false)
        Entity.SourceModeDisplay = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.SourceModeDisplay).GetAsString();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).IsNull == false)
        Entity.IOGroupNumber = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupDisplay).IsNull == false)
        Entity.IOGroupDisplay = Properties.GetByName(GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSAValidator.ColumnNames.IOGroupDisplay).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyOutputDevice_InputSource_Main_PanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "OutputDeviceUid";
    /// <summary>
    /// Returns 'GalaxyOutputDeviceInputSourceUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceUid = "GalaxyOutputDeviceInputSourceUid";
    /// <summary>
    /// Returns 'GalaxyOutputInputSourceTriggerConditionUid'
    /// </summary>
    public static string GalaxyOutputInputSourceTriggerConditionUid = "GalaxyOutputInputSourceTriggerConditionUid";
    /// <summary>
    /// Returns 'GalaxyOutputInputSourceModeUid'
    /// </summary>
    public static string GalaxyOutputInputSourceModeUid = "GalaxyOutputInputSourceModeUid";
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
    /// <summary>
    /// Returns 'SourceNumber'
    /// </summary>
    public static string SourceNumber = "SourceNumber";
    /// <summary>
    /// Returns 'InputOutputGroupMode'
    /// </summary>
    public static string InputOutputGroupMode = "InputOutputGroupMode";
    /// <summary>
    /// Returns 'TriggerConditionCode'
    /// </summary>
    public static string TriggerConditionCode = "TriggerConditionCode";
    /// <summary>
    /// Returns 'TriggerConditionDisplay'
    /// </summary>
    public static string TriggerConditionDisplay = "TriggerConditionDisplay";
    /// <summary>
    /// Returns 'SourceModeCode'
    /// </summary>
    public static string SourceModeCode = "SourceModeCode";
    /// <summary>
    /// Returns 'SourceModeDisplay'
    /// </summary>
    public static string SourceModeDisplay = "SourceModeDisplay";
    /// <summary>
    /// Returns 'IOGroupNumber'
    /// </summary>
    public static string IOGroupNumber = "IOGroupNumber";
    /// <summary>
    /// Returns 'IOGroupDisplay'
    /// </summary>
    public static string IOGroupDisplay = "IOGroupDisplay";
    }
    #endregion
  }
}
