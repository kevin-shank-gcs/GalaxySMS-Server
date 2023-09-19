using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the UnacknowledgedAlarmsPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class UnacknowledgedAlarmsPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private UnacknowledgedAlarmsPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new UnacknowledgedAlarmsPDSA Entity
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
    /// Clones the current UnacknowledgedAlarmsPDSA
    /// </summary>
    /// <returns>A cloned UnacknowledgedAlarmsPDSA object</returns>
    public UnacknowledgedAlarmsPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in UnacknowledgedAlarmsPDSA
    /// </summary>
    /// <param name="entityToClone">The UnacknowledgedAlarmsPDSA entity to clone</param>
    /// <returns>A cloned UnacknowledgedAlarmsPDSA object</returns>
    public UnacknowledgedAlarmsPDSA CloneEntity(UnacknowledgedAlarmsPDSA entityToClone)
    {
      UnacknowledgedAlarmsPDSA newEntity = new UnacknowledgedAlarmsPDSA();

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
      
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ActivityEventUid_Header", "Activity Event Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_AccountCode_Header", "Account Code"), false, typeof(string), 16, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_AccountCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CpuId_Header", "Cpu Id"), false, typeof(short), 5, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CpuId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_BoardNumber_Header", "Board Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_SectionNumber_Header", "Section Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ModuleNumber_Header", "Module Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ModuleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_NodeNumber_Header", "Node Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CpuModel_Header", "Cpu Model"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CpuModel_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DateTime_x_Header", "Date Time"), false, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DateTime_x_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PanelActivityType_Header", "Panel Activity Type"), false, typeof(string), 50, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PanelActivityType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_InputOutputGroupNumber_Header", "Input Output Group Number"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_InputOutputGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_MultiFactorMode_Header", "Multi Factor Mode"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_MultiFactorMode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DeviceDescription_Header", "Device Description"), false, typeof(string), 128, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DeviceDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_EventDescription_Header", "Event Description"), false, typeof(string), 65, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_EventDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DeviceEntityId_Header", "Device Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DeviceEntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_DeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 65, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_IsAlarmEvent_Header", "Is Alarm Event"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_IsAlarmEvent_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_AlarmPriority_Header", "Alarm Priority"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_Instructions_Header", "Instructions"), false, typeof(string), 1073741823, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_Instructions_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_InstructionsNoteUid_Header", "Instructions Note Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_InstructionsNoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_AudioBinaryResourceUid_Header", "Audio Binary Resource Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_AudioBinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_RawData_Header", "Raw Data"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_RawData_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_Color_Header", "Color"), false, typeof(int), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_Color_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PersonDescription_Header", "Person Description"), false, typeof(string), 131, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_PersonDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CredentialDescription_Header", "Credential Description"), false, typeof(string), 65, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_CredentialDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_Trace_Header", "Trace"), false, typeof(bool), 10, GetResourceMessage("GCS_UnacknowledgedAlarmsPDSA_Trace_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ActivityEventUid = Guid.Empty;
      Entity.ClusterGroupId = 0;
      Entity.ClusterNumber = 0;
      Entity.PanelNumber = 0;
      Entity.CpuId = 0;
      Entity.BoardNumber = 0;
      Entity.SectionNumber = 0;
      Entity.ModuleNumber = 0;
      Entity.NodeNumber = 0;
      Entity.CpuModel = 0;
      Entity.DateTime_x = DateTimeOffset.Now;
      Entity.BufferIndex = 0;
      Entity.PanelActivityType = string.Empty;
      Entity.InputOutputGroupNumber = 0;
      Entity.MultiFactorMode = 0;
      Entity.DeviceDescription = string.Empty;
      Entity.EventDescription = string.Empty;
      Entity.DeviceEntityId = Guid.Empty;
      Entity.DeviceUid = Guid.Empty;
      Entity.CpuUid = Guid.Empty;
      Entity.ClusterName = string.Empty;
      Entity.IsAlarmEvent = 0;
      Entity.AlarmPriority = 0;
      Entity.Instructions = string.Empty;
      Entity.InstructionsNoteUid = Guid.Empty;
      Entity.AudioBinaryResourceUid = Guid.Empty;
      Entity.RawData = 0;
      Entity.Color = 0;
      Entity.PersonUid = Guid.Empty;
      Entity.CredentialUid = Guid.Empty;
      Entity.PersonDescription = string.Empty;
      Entity.CredentialDescription = string.Empty;
      Entity.Trace = false;

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
      
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId).Value = Entity.CpuId;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber).Value = Entity.BoardNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber).Value = Entity.SectionNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber).Value = Entity.ModuleNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber).Value = Entity.NodeNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel).Value = Entity.CpuModel;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x).Value = Entity.DateTime_x;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex).Value = Entity.BufferIndex;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType).Value = Entity.PanelActivityType;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber).Value = Entity.InputOutputGroupNumber;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode).Value = Entity.MultiFactorMode;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription).Value = Entity.DeviceDescription;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription).Value = Entity.EventDescription;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId).Value = Entity.DeviceEntityId;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid).Value = Entity.DeviceUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent).Value = Entity.IsAlarmEvent;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority).Value = Entity.AlarmPriority;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions).Value = Entity.Instructions;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid).Value = Entity.InstructionsNoteUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid).Value = Entity.AudioBinaryResourceUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData).Value = Entity.RawData;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color).Value = Entity.Color;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription).Value = Entity.PersonDescription;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription).Value = Entity.CredentialDescription;
      if(!Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace).SetAsNull)
        Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace).Value = Entity.Trace;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid).IsNull == false)
        Entity.ActivityEventUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ActivityEventUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId).IsNull == false)
        Entity.CpuId = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuId).GetAsShort();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BoardNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.SectionNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber).IsNull == false)
        Entity.ModuleNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ModuleNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.NodeNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel).IsNull == false)
        Entity.CpuModel = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuModel).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x).IsNull == false)
        Entity.DateTime_x = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DateTime_x).GetAsDateTimeOffset();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType).IsNull == false)
        Entity.PanelActivityType = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PanelActivityType).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber).IsNull == false)
        Entity.InputOutputGroupNumber = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InputOutputGroupNumber).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode).IsNull == false)
        Entity.MultiFactorMode = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.MultiFactorMode).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription).IsNull == false)
        Entity.DeviceDescription = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceDescription).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription).IsNull == false)
        Entity.EventDescription = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.EventDescription).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId).IsNull == false)
        Entity.DeviceEntityId = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceEntityId).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.DeviceUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.ClusterName).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent).IsNull == false)
        Entity.IsAlarmEvent = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.IsAlarmEvent).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions).IsNull == false)
        Entity.Instructions = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Instructions).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid).IsNull == false)
        Entity.InstructionsNoteUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.InstructionsNoteUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid).IsNull == false)
        Entity.AudioBinaryResourceUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.AudioBinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData).IsNull == false)
        Entity.RawData = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.RawData).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color).IsNull == false)
        Entity.Color = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Color).GetAsInteger();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription).IsNull == false)
        Entity.PersonDescription = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.PersonDescription).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription).IsNull == false)
        Entity.CredentialDescription = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.CredentialDescription).GetAsString();
      if(Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace).IsNull == false)
        Entity.Trace = Properties.GetByName(UnacknowledgedAlarmsPDSAValidator.ColumnNames.Trace).GetAsBool();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the UnacknowledgedAlarmsPDSA class.
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
    }
    #endregion
  }
}
