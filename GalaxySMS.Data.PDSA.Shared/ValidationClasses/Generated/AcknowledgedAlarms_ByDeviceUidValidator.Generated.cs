using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AcknowledgedAlarms_ByDeviceUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AcknowledgedAlarms_ByDeviceUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AcknowledgedAlarms_ByDeviceUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AcknowledgedAlarms_ByDeviceUidPDSA Entity
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
    /// Clones the current AcknowledgedAlarms_ByDeviceUidPDSA
    /// </summary>
    /// <returns>A cloned AcknowledgedAlarms_ByDeviceUidPDSA object</returns>
    public AcknowledgedAlarms_ByDeviceUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AcknowledgedAlarms_ByDeviceUidPDSA
    /// </summary>
    /// <param name="entityToClone">The AcknowledgedAlarms_ByDeviceUidPDSA entity to clone</param>
    /// <returns>A cloned AcknowledgedAlarms_ByDeviceUidPDSA object</returns>
    public AcknowledgedAlarms_ByDeviceUidPDSA CloneEntity(AcknowledgedAlarms_ByDeviceUidPDSA entityToClone)
    {
      AcknowledgedAlarms_ByDeviceUidPDSA newEntity = new AcknowledgedAlarms_ByDeviceUidPDSA();

      newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.CpuId = entityToClone.CpuId;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.CpuModel = entityToClone.CpuModel;
      newEntity.DateTime_x = entityToClone.DateTime_x;
      newEntity.BufferIndex = entityToClone.BufferIndex;
      newEntity.PanelActivityType = entityToClone.PanelActivityType;
      newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
      newEntity.MultiFactorMode = entityToClone.MultiFactorMode;
      newEntity.DeviceDescription = entityToClone.DeviceDescription;
      newEntity.EventDescription = entityToClone.EventDescription;
      newEntity.DeviceEntityId = entityToClone.DeviceEntityId;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.IsAlarmEvent = entityToClone.IsAlarmEvent;
      newEntity.AlarmPriority = entityToClone.AlarmPriority;
      newEntity.Instructions = entityToClone.Instructions;
      newEntity.InstructionsNoteUid = entityToClone.InstructionsNoteUid;
      newEntity.AudioBinaryResourceUid = entityToClone.AudioBinaryResourceUid;
      newEntity.RawData = entityToClone.RawData;
      newEntity.Color = entityToClone.Color;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.PersonDescription = entityToClone.PersonDescription;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
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
      
      props.Add(PDSAProperty.Create(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.DeviceUid, GetResourceMessage("GCS_AcknowledgedAlarms_ByDeviceUidPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AcknowledgedAlarms_ByDeviceUidPDSA_DeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AcknowledgedAlarms_ByDeviceUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AcknowledgedAlarms_ByDeviceUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.DeviceUid).Value = Entity.DeviceUid;
      this.Properties.GetByName(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = this.Properties.GetByName(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.DeviceUid).GetAsGuid();
      if(this.Properties.GetByName(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AcknowledgedAlarms_ByDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AcknowledgedAlarms_ByDeviceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ActivityEventUid'
    /// </summary>
    public static string ActivityEventUid = "ActivityEventUid";
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
    /// Returns 'CpuId'
    /// </summary>
    public static string CpuId = "CpuId";
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
    /// Returns 'CpuModel'
    /// </summary>
    public static string CpuModel = "CpuModel";
    /// <summary>
    /// Returns 'DateTimeOffset'
    /// </summary>
    public static string DateTime_x = "DateTimeOffset";
    /// <summary>
    /// Returns 'BufferIndex'
    /// </summary>
    public static string BufferIndex = "BufferIndex";
    /// <summary>
    /// Returns 'PanelActivityType'
    /// </summary>
    public static string PanelActivityType = "PanelActivityType";
    /// <summary>
    /// Returns 'InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "InputOutputGroupNumber";
    /// <summary>
    /// Returns 'MultiFactorMode'
    /// </summary>
    public static string MultiFactorMode = "MultiFactorMode";
    /// <summary>
    /// Returns 'DeviceDescription'
    /// </summary>
    public static string DeviceDescription = "DeviceDescription";
    /// <summary>
    /// Returns 'EventDescription'
    /// </summary>
    public static string EventDescription = "EventDescription";
    /// <summary>
    /// Returns 'DeviceEntityId'
    /// </summary>
    public static string DeviceEntityId = "DeviceEntityId";
    /// <summary>
    /// Returns 'DeviceUid'
    /// </summary>
    public static string DeviceUid = "DeviceUid";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'IsAlarmEvent'
    /// </summary>
    public static string IsAlarmEvent = "IsAlarmEvent";
    /// <summary>
    /// Returns 'AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "AlarmPriority";
    /// <summary>
    /// Returns 'Instructions'
    /// </summary>
    public static string Instructions = "Instructions";
    /// <summary>
    /// Returns 'InstructionsNoteUid'
    /// </summary>
    public static string InstructionsNoteUid = "InstructionsNoteUid";
    /// <summary>
    /// Returns 'AudioBinaryResourceUid'
    /// </summary>
    public static string AudioBinaryResourceUid = "AudioBinaryResourceUid";
    /// <summary>
    /// Returns 'RawData'
    /// </summary>
    public static string RawData = "RawData";
    /// <summary>
    /// Returns 'Color'
    /// </summary>
    public static string Color = "Color";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'CredentialUid'
    /// </summary>
    public static string CredentialUid = "CredentialUid";
    /// <summary>
    /// Returns 'PersonDescription'
    /// </summary>
    public static string PersonDescription = "PersonDescription";
    /// <summary>
    /// Returns 'CredentialDescription'
    /// </summary>
    public static string CredentialDescription = "CredentialDescription";
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
    /// Contains static string properties that represent the name of each property in the AcknowledgedAlarms_ByDeviceUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@DeviceUid'
    /// </summary>
    public static string DeviceUid = "@DeviceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
