using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA Entity
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
    /// Clones the current GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA
    /// </summary>
    /// <returns>A cloned GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA object</returns>
    public GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA entity to clone</param>
    /// <returns>A cloned GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA object</returns>
    public GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA CloneEntity(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA entityToClone)
    {
      GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA newEntity = new GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA();

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
      
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.OutputDeviceUid, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA_OutputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.OutputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA class.
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
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
