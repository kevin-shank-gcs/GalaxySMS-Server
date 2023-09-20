using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputDevice_GetPanelLoadDataChangesByCpuUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDevice_GetPanelLoadDataChangesByCpuUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDevice_GetPanelLoadDataChangesByCpuUidPDSA Entity
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
    /// Clones the current InputDevice_GetPanelLoadDataChangesByCpuUidPDSA
    /// </summary>
    /// <returns>A cloned InputDevice_GetPanelLoadDataChangesByCpuUidPDSA object</returns>
    public InputDevice_GetPanelLoadDataChangesByCpuUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDevice_GetPanelLoadDataChangesByCpuUidPDSA
    /// </summary>
    /// <param name="entityToClone">The InputDevice_GetPanelLoadDataChangesByCpuUidPDSA entity to clone</param>
    /// <returns>A cloned InputDevice_GetPanelLoadDataChangesByCpuUidPDSA object</returns>
    public InputDevice_GetPanelLoadDataChangesByCpuUidPDSA CloneEntity(InputDevice_GetPanelLoadDataChangesByCpuUidPDSA entityToClone)
    {
      InputDevice_GetPanelLoadDataChangesByCpuUidPDSA newEntity = new InputDevice_GetPanelLoadDataChangesByCpuUidPDSA();

      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
      newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
      newEntity.InputName = entityToClone.InputName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.IsInputActive = entityToClone.IsInputActive;
      newEntity.IsNodeActive = entityToClone.IsNodeActive;
      newEntity.IsModuleActive = entityToClone.IsModuleActive;
      newEntity.InputDeviceBoardSectionMode = entityToClone.InputDeviceBoardSectionMode;
      newEntity.InputDeviceBoardSectionModeDisplay = entityToClone.InputDeviceBoardSectionModeDisplay;
      newEntity.InputDevicePanelModelTypeCode = entityToClone.InputDevicePanelModelTypeCode;
      newEntity.InputDeviceCpuTypeCode = entityToClone.InputDeviceCpuTypeCode;
      newEntity.InputDeviceBoardTypeModel = entityToClone.InputDeviceBoardTypeModel;
      newEntity.InputDeviceBoardTypeTypeCode = entityToClone.InputDeviceBoardTypeTypeCode;
      newEntity.InputDeviceBoardTypeDisplay = entityToClone.InputDeviceBoardTypeDisplay;
      newEntity.SupervisionTypeDisplay = entityToClone.SupervisionTypeDisplay;
      newEntity.HasSeriesResistor = entityToClone.HasSeriesResistor;
      newEntity.HasParallelResistor = entityToClone.HasParallelResistor;
      newEntity.IsNormalOpen = entityToClone.IsNormalOpen;
      newEntity.TroubleShortThreshold = entityToClone.TroubleShortThreshold;
      newEntity.TroubleOpenThreshold = entityToClone.TroubleOpenThreshold;
      newEntity.NormalChangeThreshold = entityToClone.NormalChangeThreshold;
      newEntity.AlternateNormalChangeThreshold = entityToClone.AlternateNormalChangeThreshold;
      newEntity.AlternateTroubleOpenThreshold = entityToClone.AlternateTroubleOpenThreshold;
      newEntity.AlternateTroubleShortThreshold = entityToClone.AlternateTroubleShortThreshold;
      newEntity.AlternateVoltagesEnabled = entityToClone.AlternateVoltagesEnabled;
      newEntity.GalaxyInputModeDisplay = entityToClone.GalaxyInputModeDisplay;
      newEntity.GalaxyInputModeCode = entityToClone.GalaxyInputModeCode;
      newEntity.GalaxyInputDelayTypeDisplay = entityToClone.GalaxyInputDelayTypeDisplay;
      newEntity.GalaxyInputDelayTypeCode = entityToClone.GalaxyInputDelayTypeCode;
      newEntity.MainIOGroupTag = entityToClone.MainIOGroupTag;
      newEntity.MainIOGroupDisplay = entityToClone.MainIOGroupDisplay;
      newEntity.MainIOGroupNumber = entityToClone.MainIOGroupNumber;
      newEntity.MainIOGroupIsLocal = entityToClone.MainIOGroupIsLocal;
      newEntity.MainIOGroupOffset = entityToClone.MainIOGroupOffset;
      newEntity.DelayDuration = entityToClone.DelayDuration;
      newEntity.DisableDisarmedOnOffLogEvents = entityToClone.DisableDisarmedOnOffLogEvents;
      newEntity.ArmControlScheduleDisplay = entityToClone.ArmControlScheduleDisplay;
      newEntity.ArmControlScheduleNumber = entityToClone.ArmControlScheduleNumber;
      newEntity.ArmingIOGroup1Display = entityToClone.ArmingIOGroup1Display;
      newEntity.ArmingIOGroupNumber1 = entityToClone.ArmingIOGroupNumber1;
      newEntity.ArmingIOGroup1IsLocal = entityToClone.ArmingIOGroup1IsLocal;
      newEntity.ArmingIOGroup2Display = entityToClone.ArmingIOGroup2Display;
      newEntity.ArmingIOGroupNumber2 = entityToClone.ArmingIOGroupNumber2;
      newEntity.ArmingIOGroup2IsLocal = entityToClone.ArmingIOGroup2IsLocal;
      newEntity.ArmingIOGroup3Display = entityToClone.ArmingIOGroup3Display;
      newEntity.ArmingIOGroupNumber3 = entityToClone.ArmingIOGroupNumber3;
      newEntity.ArmingIOGroup3IsLocal = entityToClone.ArmingIOGroup3IsLocal;
      newEntity.ArmingIOGroup4Display = entityToClone.ArmingIOGroup4Display;
      newEntity.ArmingIOGroupNumber4 = entityToClone.ArmingIOGroupNumber4;
      newEntity.ArmingIOGroup4IsLocal = entityToClone.ArmingIOGroup4IsLocal;
      newEntity.GalaxyInputDevicePropertiesLastUpdated = entityToClone.GalaxyInputDevicePropertiesLastUpdated;
      newEntity.MainIOGroupLastUpdated = entityToClone.MainIOGroupLastUpdated;
      newEntity.ArmingIOGroup1LastUpdated = entityToClone.ArmingIOGroup1LastUpdated;
      newEntity.ArmingIOGroup2LastUpdated = entityToClone.ArmingIOGroup2LastUpdated;
      newEntity.ArmingIOGroup3LastUpdated = entityToClone.ArmingIOGroup3LastUpdated;
      newEntity.ArmingIOGroup4LastUpdated = entityToClone.ArmingIOGroup4LastUpdated;
      newEntity.MainScheduleLastUpdated = entityToClone.MainScheduleLastUpdated;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.IsConnected = entityToClone.IsConnected;

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
      
      props.Add(PDSAProperty.Create(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.ServerAddress, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_ServerAddress_Header", "Server Address"), false, typeof(string), 8000, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_ServerAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.IsConnected, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), 0, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_IsConnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputDevice_GetPanelLoadDataChangesByCpuUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.ServerAddress).Value = Entity.ServerAddress;
      this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.IsConnected).Value = Entity.IsConnected;
      this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.ServerAddress).IsNull == false)
        Entity.ServerAddress = this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.ServerAddress).GetAsString();
      if(this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.IsConnected).IsNull == false)
        Entity.IsConnected = this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.IsConnected).GetAsBool();
      if(this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputDevice_GetPanelLoadDataChangesByCpuUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetPanelLoadDataChangesByCpuUidPDSA class.
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
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns 'GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns 'InputName'
    /// </summary>
    public static string InputName = "InputName";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'BoardNumber'
    /// </summary>
    public static string BoardNumber = "BoardNumber";
    /// <summary>
    /// Returns 'SectionNumber'
    /// </summary>
    public static string SectionNumber = "SectionNumber";
    /// <summary>
    /// Returns 'ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "ModuleNumber";
    /// <summary>
    /// Returns 'NodeNumber'
    /// </summary>
    public static string NodeNumber = "NodeNumber";
    /// <summary>
    /// Returns 'IsInputActive'
    /// </summary>
    public static string IsInputActive = "IsInputActive";
    /// <summary>
    /// Returns 'IsNodeActive'
    /// </summary>
    public static string IsNodeActive = "IsNodeActive";
    /// <summary>
    /// Returns 'IsModuleActive'
    /// </summary>
    public static string IsModuleActive = "IsModuleActive";
    /// <summary>
    /// Returns 'InputDeviceBoardSectionMode'
    /// </summary>
    public static string InputDeviceBoardSectionMode = "InputDeviceBoardSectionMode";
    /// <summary>
    /// Returns 'InputDeviceBoardSectionModeDisplay'
    /// </summary>
    public static string InputDeviceBoardSectionModeDisplay = "InputDeviceBoardSectionModeDisplay";
    /// <summary>
    /// Returns 'InputDevicePanelModelTypeCode'
    /// </summary>
    public static string InputDevicePanelModelTypeCode = "InputDevicePanelModelTypeCode";
    /// <summary>
    /// Returns 'InputDeviceCpuTypeCode'
    /// </summary>
    public static string InputDeviceCpuTypeCode = "InputDeviceCpuTypeCode";
    /// <summary>
    /// Returns 'InputDeviceBoardTypeModel'
    /// </summary>
    public static string InputDeviceBoardTypeModel = "InputDeviceBoardTypeModel";
    /// <summary>
    /// Returns 'InputDeviceBoardTypeTypeCode'
    /// </summary>
    public static string InputDeviceBoardTypeTypeCode = "InputDeviceBoardTypeTypeCode";
    /// <summary>
    /// Returns 'InputDeviceBoardTypeDisplay'
    /// </summary>
    public static string InputDeviceBoardTypeDisplay = "InputDeviceBoardTypeDisplay";
    /// <summary>
    /// Returns 'SupervisionTypeDisplay'
    /// </summary>
    public static string SupervisionTypeDisplay = "SupervisionTypeDisplay";
    /// <summary>
    /// Returns 'HasSeriesResistor'
    /// </summary>
    public static string HasSeriesResistor = "HasSeriesResistor";
    /// <summary>
    /// Returns 'HasParallelResistor'
    /// </summary>
    public static string HasParallelResistor = "HasParallelResistor";
    /// <summary>
    /// Returns 'IsNormalOpen'
    /// </summary>
    public static string IsNormalOpen = "IsNormalOpen";
    /// <summary>
    /// Returns 'TroubleShortThreshold'
    /// </summary>
    public static string TroubleShortThreshold = "TroubleShortThreshold";
    /// <summary>
    /// Returns 'TroubleOpenThreshold'
    /// </summary>
    public static string TroubleOpenThreshold = "TroubleOpenThreshold";
    /// <summary>
    /// Returns 'NormalChangeThreshold'
    /// </summary>
    public static string NormalChangeThreshold = "NormalChangeThreshold";
    /// <summary>
    /// Returns 'AlternateNormalChangeThreshold'
    /// </summary>
    public static string AlternateNormalChangeThreshold = "AlternateNormalChangeThreshold";
    /// <summary>
    /// Returns 'AlternateTroubleOpenThreshold'
    /// </summary>
    public static string AlternateTroubleOpenThreshold = "AlternateTroubleOpenThreshold";
    /// <summary>
    /// Returns 'AlternateTroubleShortThreshold'
    /// </summary>
    public static string AlternateTroubleShortThreshold = "AlternateTroubleShortThreshold";
    /// <summary>
    /// Returns 'AlternateVoltagesEnabled'
    /// </summary>
    public static string AlternateVoltagesEnabled = "AlternateVoltagesEnabled";
    /// <summary>
    /// Returns 'GalaxyInputModeDisplay'
    /// </summary>
    public static string GalaxyInputModeDisplay = "GalaxyInputModeDisplay";
    /// <summary>
    /// Returns 'GalaxyInputModeCode'
    /// </summary>
    public static string GalaxyInputModeCode = "GalaxyInputModeCode";
    /// <summary>
    /// Returns 'GalaxyInputDelayTypeDisplay'
    /// </summary>
    public static string GalaxyInputDelayTypeDisplay = "GalaxyInputDelayTypeDisplay";
    /// <summary>
    /// Returns 'GalaxyInputDelayTypeCode'
    /// </summary>
    public static string GalaxyInputDelayTypeCode = "GalaxyInputDelayTypeCode";
    /// <summary>
    /// Returns 'MainIOGroupTag'
    /// </summary>
    public static string MainIOGroupTag = "MainIOGroupTag";
    /// <summary>
    /// Returns 'MainIOGroupDisplay'
    /// </summary>
    public static string MainIOGroupDisplay = "MainIOGroupDisplay";
    /// <summary>
    /// Returns 'MainIOGroupNumber'
    /// </summary>
    public static string MainIOGroupNumber = "MainIOGroupNumber";
    /// <summary>
    /// Returns 'MainIOGroupIsLocal'
    /// </summary>
    public static string MainIOGroupIsLocal = "MainIOGroupIsLocal";
    /// <summary>
    /// Returns 'MainIOGroupOffset'
    /// </summary>
    public static string MainIOGroupOffset = "MainIOGroupOffset";
    /// <summary>
    /// Returns 'DelayDuration'
    /// </summary>
    public static string DelayDuration = "DelayDuration";
    /// <summary>
    /// Returns 'DisableDisarmedOnOffLogEvents'
    /// </summary>
    public static string DisableDisarmedOnOffLogEvents = "DisableDisarmedOnOffLogEvents";
    /// <summary>
    /// Returns 'ArmControlScheduleDisplay'
    /// </summary>
    public static string ArmControlScheduleDisplay = "ArmControlScheduleDisplay";
    /// <summary>
    /// Returns 'ArmControlScheduleNumber'
    /// </summary>
    public static string ArmControlScheduleNumber = "ArmControlScheduleNumber";
    /// <summary>
    /// Returns 'ArmingIOGroup1Display'
    /// </summary>
    public static string ArmingIOGroup1Display = "ArmingIOGroup1Display";
    /// <summary>
    /// Returns 'ArmingIOGroupNumber1'
    /// </summary>
    public static string ArmingIOGroupNumber1 = "ArmingIOGroupNumber1";
    /// <summary>
    /// Returns 'ArmingIOGroup1IsLocal'
    /// </summary>
    public static string ArmingIOGroup1IsLocal = "ArmingIOGroup1IsLocal";
    /// <summary>
    /// Returns 'ArmingIOGroup2Display'
    /// </summary>
    public static string ArmingIOGroup2Display = "ArmingIOGroup2Display";
    /// <summary>
    /// Returns 'ArmingIOGroupNumber2'
    /// </summary>
    public static string ArmingIOGroupNumber2 = "ArmingIOGroupNumber2";
    /// <summary>
    /// Returns 'ArmingIOGroup2IsLocal'
    /// </summary>
    public static string ArmingIOGroup2IsLocal = "ArmingIOGroup2IsLocal";
    /// <summary>
    /// Returns 'ArmingIOGroup3Display'
    /// </summary>
    public static string ArmingIOGroup3Display = "ArmingIOGroup3Display";
    /// <summary>
    /// Returns 'ArmingIOGroupNumber3'
    /// </summary>
    public static string ArmingIOGroupNumber3 = "ArmingIOGroupNumber3";
    /// <summary>
    /// Returns 'ArmingIOGroup3IsLocal'
    /// </summary>
    public static string ArmingIOGroup3IsLocal = "ArmingIOGroup3IsLocal";
    /// <summary>
    /// Returns 'ArmingIOGroup4Display'
    /// </summary>
    public static string ArmingIOGroup4Display = "ArmingIOGroup4Display";
    /// <summary>
    /// Returns 'ArmingIOGroupNumber4'
    /// </summary>
    public static string ArmingIOGroupNumber4 = "ArmingIOGroupNumber4";
    /// <summary>
    /// Returns 'ArmingIOGroup4IsLocal'
    /// </summary>
    public static string ArmingIOGroup4IsLocal = "ArmingIOGroup4IsLocal";
    /// <summary>
    /// Returns 'GalaxyInputDevicePropertiesLastUpdated'
    /// </summary>
    public static string GalaxyInputDevicePropertiesLastUpdated = "GalaxyInputDevicePropertiesLastUpdated";
    /// <summary>
    /// Returns 'MainIOGroupLastUpdated'
    /// </summary>
    public static string MainIOGroupLastUpdated = "MainIOGroupLastUpdated";
    /// <summary>
    /// Returns 'ArmingIOGroup1LastUpdated'
    /// </summary>
    public static string ArmingIOGroup1LastUpdated = "ArmingIOGroup1LastUpdated";
    /// <summary>
    /// Returns 'ArmingIOGroup2LastUpdated'
    /// </summary>
    public static string ArmingIOGroup2LastUpdated = "ArmingIOGroup2LastUpdated";
    /// <summary>
    /// Returns 'ArmingIOGroup3LastUpdated'
    /// </summary>
    public static string ArmingIOGroup3LastUpdated = "ArmingIOGroup3LastUpdated";
    /// <summary>
    /// Returns 'ArmingIOGroup4LastUpdated'
    /// </summary>
    public static string ArmingIOGroup4LastUpdated = "ArmingIOGroup4LastUpdated";
    /// <summary>
    /// Returns 'MainScheduleLastUpdated'
    /// </summary>
    public static string MainScheduleLastUpdated = "MainScheduleLastUpdated";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetPanelLoadDataChangesByCpuUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@ServerAddress'
    /// </summary>
    public static string ServerAddress = "@ServerAddress";
    /// <summary>
    /// Returns '@IsConnected'
    /// </summary>
    public static string IsConnected = "@IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
