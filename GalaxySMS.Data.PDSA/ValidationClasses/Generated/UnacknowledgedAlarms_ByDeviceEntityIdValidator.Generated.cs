using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the UnacknowledgedAlarms_ByDeviceEntityIdPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private UnacknowledgedAlarms_ByDeviceEntityIdPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new UnacknowledgedAlarms_ByDeviceEntityIdPDSA Entity
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
    /// Clones the current UnacknowledgedAlarms_ByDeviceEntityIdPDSA
    /// </summary>
    /// <returns>A cloned UnacknowledgedAlarms_ByDeviceEntityIdPDSA object</returns>
    public UnacknowledgedAlarms_ByDeviceEntityIdPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in UnacknowledgedAlarms_ByDeviceEntityIdPDSA
    /// </summary>
    /// <param name="entityToClone">The UnacknowledgedAlarms_ByDeviceEntityIdPDSA entity to clone</param>
    /// <returns>A cloned UnacknowledgedAlarms_ByDeviceEntityIdPDSA object</returns>
    public UnacknowledgedAlarms_ByDeviceEntityIdPDSA CloneEntity(UnacknowledgedAlarms_ByDeviceEntityIdPDSA entityToClone)
    {
      UnacknowledgedAlarms_ByDeviceEntityIdPDSA newEntity = new UnacknowledgedAlarms_ByDeviceEntityIdPDSA();

      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
      newEntity.AlarmPriority = entityToClone.AlarmPriority;
      newEntity.AudioBinaryResourceUid = entityToClone.AudioBinaryResourceUid;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.BufferIndex = entityToClone.BufferIndex;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.Color = entityToClone.Color;
      newEntity.CpuId = entityToClone.CpuId;
      newEntity.CpuModel = entityToClone.CpuModel;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.DateTime_x = entityToClone.DateTime_x;
      newEntity.DeviceDescription = entityToClone.DeviceDescription;
      newEntity.DeviceEntityId = entityToClone.DeviceEntityId;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.EventDescription = entityToClone.EventDescription;
      newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
      newEntity.Instructions = entityToClone.Instructions;
      newEntity.InstructionsNoteUid = entityToClone.InstructionsNoteUid;
      newEntity.IsAlarmEvent = entityToClone.IsAlarmEvent;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.MultiFactorMode = entityToClone.MultiFactorMode;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.PanelActivityType = entityToClone.PanelActivityType;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.PersonDescription = entityToClone.PersonDescription;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.RawData = entityToClone.RawData;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.Trace = entityToClone.Trace;

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
      
      props.Add(PDSAProperty.Create(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.DeviceEntityId, GetResourceMessage("GCS_UnacknowledgedAlarms_ByDeviceEntityIdPDSA_DeviceEntityId_Header", "Device Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_UnacknowledgedAlarms_ByDeviceEntityIdPDSA_DeviceEntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_UnacknowledgedAlarms_ByDeviceEntityIdPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_UnacknowledgedAlarms_ByDeviceEntityIdPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.DeviceEntityId).Value = Entity.DeviceEntityId;
      this.Properties.GetByName(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.DeviceEntityId).IsNull == false)
        Entity.DeviceEntityId = this.Properties.GetByName(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.DeviceEntityId).GetAsGuid();
      if(this.Properties.GetByName(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(UnacknowledgedAlarms_ByDeviceEntityIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the UnacknowledgedAlarms_ByDeviceEntityIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ActivityEventUid'
    /// </summary>
    public static string ActivityEventUid = "ActivityEventUid";
    /// <summary>
    /// Returns 'AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "AlarmPriority";
    /// <summary>
    /// Returns 'AudioBinaryResourceUid'
    /// </summary>
    public static string AudioBinaryResourceUid = "AudioBinaryResourceUid";
    /// <summary>
    /// Returns 'BoardNumber'
    /// </summary>
    public static string BoardNumber = "BoardNumber";
    /// <summary>
    /// Returns 'BufferIndex'
    /// </summary>
    public static string BufferIndex = "BufferIndex";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'Color'
    /// </summary>
    public static string Color = "Color";
    /// <summary>
    /// Returns 'CpuId'
    /// </summary>
    public static string CpuId = "CpuId";
    /// <summary>
    /// Returns 'CpuModel'
    /// </summary>
    public static string CpuModel = "CpuModel";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'CredentialDescription'
    /// </summary>
    public static string CredentialDescription = "CredentialDescription";
    /// <summary>
    /// Returns 'CredentialUid'
    /// </summary>
    public static string CredentialUid = "CredentialUid";
    /// <summary>
    /// Returns 'DateTimeOffset'
    /// </summary>
    public static string DateTime_x = "DateTimeOffset";
    /// <summary>
    /// Returns 'DeviceDescription'
    /// </summary>
    public static string DeviceDescription = "DeviceDescription";
    /// <summary>
    /// Returns 'DeviceEntityId'
    /// </summary>
    public static string DeviceEntityId = "DeviceEntityId";
    /// <summary>
    /// Returns 'DeviceUid'
    /// </summary>
    public static string DeviceUid = "DeviceUid";
    /// <summary>
    /// Returns 'EventDescription'
    /// </summary>
    public static string EventDescription = "EventDescription";
    /// <summary>
    /// Returns 'InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "InputOutputGroupNumber";
    /// <summary>
    /// Returns 'Instructions'
    /// </summary>
    public static string Instructions = "Instructions";
    /// <summary>
    /// Returns 'InstructionsNoteUid'
    /// </summary>
    public static string InstructionsNoteUid = "InstructionsNoteUid";
    /// <summary>
    /// Returns 'IsAlarmEvent'
    /// </summary>
    public static string IsAlarmEvent = "IsAlarmEvent";
    /// <summary>
    /// Returns 'ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "ModuleNumber";
    /// <summary>
    /// Returns 'MultiFactorMode'
    /// </summary>
    public static string MultiFactorMode = "MultiFactorMode";
    /// <summary>
    /// Returns 'NodeNumber'
    /// </summary>
    public static string NodeNumber = "NodeNumber";
    /// <summary>
    /// Returns 'PanelActivityType'
    /// </summary>
    public static string PanelActivityType = "PanelActivityType";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'PersonDescription'
    /// </summary>
    public static string PersonDescription = "PersonDescription";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'RawData'
    /// </summary>
    public static string RawData = "RawData";
    /// <summary>
    /// Returns 'SectionNumber'
    /// </summary>
    public static string SectionNumber = "SectionNumber";
    /// <summary>
    /// Returns 'Trace'
    /// </summary>
    public static string Trace = "Trace";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the UnacknowledgedAlarms_ByDeviceEntityIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@DeviceEntityId'
    /// </summary>
    public static string DeviceEntityId = "@DeviceEntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
