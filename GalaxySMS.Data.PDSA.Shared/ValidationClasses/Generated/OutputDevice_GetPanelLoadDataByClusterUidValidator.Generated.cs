using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the OutputDevice_GetPanelLoadDataByClusterUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private OutputDevice_GetPanelLoadDataByClusterUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new OutputDevice_GetPanelLoadDataByClusterUidPDSA Entity
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
    /// Clones the current OutputDevice_GetPanelLoadDataByClusterUidPDSA
    /// </summary>
    /// <returns>A cloned OutputDevice_GetPanelLoadDataByClusterUidPDSA object</returns>
    public OutputDevice_GetPanelLoadDataByClusterUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in OutputDevice_GetPanelLoadDataByClusterUidPDSA
    /// </summary>
    /// <param name="entityToClone">The OutputDevice_GetPanelLoadDataByClusterUidPDSA entity to clone</param>
    /// <returns>A cloned OutputDevice_GetPanelLoadDataByClusterUidPDSA object</returns>
    public OutputDevice_GetPanelLoadDataByClusterUidPDSA CloneEntity(OutputDevice_GetPanelLoadDataByClusterUidPDSA entityToClone)
    {
      OutputDevice_GetPanelLoadDataByClusterUidPDSA newEntity = new OutputDevice_GetPanelLoadDataByClusterUidPDSA();

      newEntity.OutputDeviceUid = entityToClone.OutputDeviceUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
      newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
      newEntity.OutputName = entityToClone.OutputName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.IsOutputActive = entityToClone.IsOutputActive;
      newEntity.IsNodeActive = entityToClone.IsNodeActive;
      newEntity.IsModuleActive = entityToClone.IsModuleActive;
      newEntity.OutputDeviceBoardSectionMode = entityToClone.OutputDeviceBoardSectionMode;
      newEntity.OutputDeviceBoardSectionModeDisplay = entityToClone.OutputDeviceBoardSectionModeDisplay;
      newEntity.OutputDevicePanelModelTypeCode = entityToClone.OutputDevicePanelModelTypeCode;
      newEntity.OutputDeviceCpuTypeCode = entityToClone.OutputDeviceCpuTypeCode;
      newEntity.OutputDeviceBoardTypeModel = entityToClone.OutputDeviceBoardTypeModel;
      newEntity.OutputDeviceBoardTypeTypeCode = entityToClone.OutputDeviceBoardTypeTypeCode;
      newEntity.OutputDeviceBoardTypeDisplay = entityToClone.OutputDeviceBoardTypeDisplay;
      newEntity.GalaxyOutputModeDisplay = entityToClone.GalaxyOutputModeDisplay;
      newEntity.GalaxyOutputModeCode = entityToClone.GalaxyOutputModeCode;
      newEntity.InputSourceRelationshipDisplay = entityToClone.InputSourceRelationshipDisplay;
      newEntity.InputSourceRelationshipCode = entityToClone.InputSourceRelationshipCode;
      newEntity.TimeoutDuration = entityToClone.TimeoutDuration;
      newEntity.Limit = entityToClone.Limit;
      newEntity.InvertOutput = entityToClone.InvertOutput;
      newEntity.ScheduleDisplay = entityToClone.ScheduleDisplay;
      newEntity.ScheduleNumber = entityToClone.ScheduleNumber;
      newEntity.GalaxyOutputDevicePropertiesLastUpdated = entityToClone.GalaxyOutputDevicePropertiesLastUpdated;
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
      
      props.Add(PDSAProperty.Create(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_OutputDevice_GetPanelLoadDataByClusterUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_OutputDevice_GetPanelLoadDataByClusterUidPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_OutputDevice_GetPanelLoadDataByClusterUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_OutputDevice_GetPanelLoadDataByClusterUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(OutputDevice_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDevice_GetPanelLoadDataByClusterUidPDSA class.
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
    /// Returns 'OutputName'
    /// </summary>
    public static string OutputName = "OutputName";
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
    /// Returns 'IsOutputActive'
    /// </summary>
    public static string IsOutputActive = "IsOutputActive";
    /// <summary>
    /// Returns 'IsNodeActive'
    /// </summary>
    public static string IsNodeActive = "IsNodeActive";
    /// <summary>
    /// Returns 'IsModuleActive'
    /// </summary>
    public static string IsModuleActive = "IsModuleActive";
    /// <summary>
    /// Returns 'OutputDeviceBoardSectionMode'
    /// </summary>
    public static string OutputDeviceBoardSectionMode = "OutputDeviceBoardSectionMode";
    /// <summary>
    /// Returns 'OutputDeviceBoardSectionModeDisplay'
    /// </summary>
    public static string OutputDeviceBoardSectionModeDisplay = "OutputDeviceBoardSectionModeDisplay";
    /// <summary>
    /// Returns 'OutputDevicePanelModelTypeCode'
    /// </summary>
    public static string OutputDevicePanelModelTypeCode = "OutputDevicePanelModelTypeCode";
    /// <summary>
    /// Returns 'OutputDeviceCpuTypeCode'
    /// </summary>
    public static string OutputDeviceCpuTypeCode = "OutputDeviceCpuTypeCode";
    /// <summary>
    /// Returns 'OutputDeviceBoardTypeModel'
    /// </summary>
    public static string OutputDeviceBoardTypeModel = "OutputDeviceBoardTypeModel";
    /// <summary>
    /// Returns 'OutputDeviceBoardTypeTypeCode'
    /// </summary>
    public static string OutputDeviceBoardTypeTypeCode = "OutputDeviceBoardTypeTypeCode";
    /// <summary>
    /// Returns 'OutputDeviceBoardTypeDisplay'
    /// </summary>
    public static string OutputDeviceBoardTypeDisplay = "OutputDeviceBoardTypeDisplay";
    /// <summary>
    /// Returns 'GalaxyOutputModeDisplay'
    /// </summary>
    public static string GalaxyOutputModeDisplay = "GalaxyOutputModeDisplay";
    /// <summary>
    /// Returns 'GalaxyOutputModeCode'
    /// </summary>
    public static string GalaxyOutputModeCode = "GalaxyOutputModeCode";
    /// <summary>
    /// Returns 'InputSourceRelationshipDisplay'
    /// </summary>
    public static string InputSourceRelationshipDisplay = "InputSourceRelationshipDisplay";
    /// <summary>
    /// Returns 'InputSourceRelationshipCode'
    /// </summary>
    public static string InputSourceRelationshipCode = "InputSourceRelationshipCode";
    /// <summary>
    /// Returns 'TimeoutDuration'
    /// </summary>
    public static string TimeoutDuration = "TimeoutDuration";
    /// <summary>
    /// Returns 'Limit'
    /// </summary>
    public static string Limit = "Limit";
    /// <summary>
    /// Returns 'InvertOutput'
    /// </summary>
    public static string InvertOutput = "InvertOutput";
    /// <summary>
    /// Returns 'ScheduleDisplay'
    /// </summary>
    public static string ScheduleDisplay = "ScheduleDisplay";
    /// <summary>
    /// Returns 'ScheduleNumber'
    /// </summary>
    public static string ScheduleNumber = "ScheduleNumber";
    /// <summary>
    /// Returns 'GalaxyOutputDevicePropertiesLastUpdated'
    /// </summary>
    public static string GalaxyOutputDevicePropertiesLastUpdated = "GalaxyOutputDevicePropertiesLastUpdated";
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
    /// Contains static string properties that represent the name of each property in the OutputDevice_GetPanelLoadDataByClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
