using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the insert_GalaxyPanelActivityEventPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class insert_GalaxyPanelActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private insert_GalaxyPanelActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new insert_GalaxyPanelActivityEventPDSA Entity
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
    /// Clones the current insert_GalaxyPanelActivityEventPDSA
    /// </summary>
    /// <returns>A cloned insert_GalaxyPanelActivityEventPDSA object</returns>
    public insert_GalaxyPanelActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in insert_GalaxyPanelActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The insert_GalaxyPanelActivityEventPDSA entity to clone</param>
    /// <returns>A cloned insert_GalaxyPanelActivityEventPDSA object</returns>
    public insert_GalaxyPanelActivityEventPDSA CloneEntity(insert_GalaxyPanelActivityEventPDSA entityToClone)
    {
      insert_GalaxyPanelActivityEventPDSA newEntity = new insert_GalaxyPanelActivityEventPDSA();


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
      
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelActivityEventUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyPanelActivityEventUid_Header", "Galaxy Panel Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyPanelActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyActivityEventTypeUid_Header", "Galaxy Activity Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyActivityEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyInterfaceBoardUid_Header", "Galaxy Interface Board Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyInterfaceBoardUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyInterfaceBoardSectionUid_Header", "Galaxy Interface Board Section Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyInterfaceBoardSectionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyHardwareModuleUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyHardwareModuleUid_Header", "Galaxy Hardware Module Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyHardwareModuleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyInterfaceBoardSectionNodeUid_Header", "Galaxy Interface Board Section Node Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_GalaxyInterfaceBoardSectionNodeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_InputOutputGroupNumber_Header", "Input Output Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_InputOutputGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_BoardNumber_Header", "Board Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.SectionNumber, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_SectionNumber_Header", "Section Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ModuleNumber, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_ModuleNumber_Header", "Module Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_ModuleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NodeNumber, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_NodeNumber_Header", "Node Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.eventType, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_eventType_Header", "event Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_eventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.IsAlarmEvent, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_IsAlarmEvent_Header", "Is Alarm Event"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_IsAlarmEvent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.AlarmPriority, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_AlarmPriority_Header", "Alarm Priority"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ResponseRequired, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_ResponseRequired_Header", "Response Required"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_ResponseRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NoteUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_NoteUid_Header", "Note Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_NoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BinaryResourceUid, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyPanelActivityEventPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelActivityEventUid).Value = Entity.GalaxyPanelActivityEventUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).Value = Entity.GalaxyInterfaceBoardUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid).Value = Entity.GalaxyInterfaceBoardSectionUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyHardwareModuleUid).Value = Entity.GalaxyHardwareModuleUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).Value = Entity.GalaxyInterfaceBoardSectionNodeUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).Value = Entity.InputOutputGroupNumber;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ModuleNumber).Value = Entity.ModuleNumber;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.eventType).Value = Entity.eventType;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).Value = Entity.IsAlarmEvent;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.AlarmPriority).Value = Entity.AlarmPriority;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ResponseRequired).Value = Entity.ResponseRequired;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NoteUid).Value = Entity.NoteUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelActivityEventUid).IsNull == false)
        Entity.GalaxyPanelActivityEventUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelActivityEventUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).IsNull == false)
        Entity.GalaxyInterfaceBoardUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyHardwareModuleUid).IsNull == false)
        Entity.GalaxyHardwareModuleUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyHardwareModuleUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionNodeUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).IsNull == false)
        Entity.InputOutputGroupNumber = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BoardNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.SectionNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ModuleNumber).IsNull == false)
        Entity.ModuleNumber = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ModuleNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NodeNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.eventType).IsNull == false)
        Entity.eventType = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.eventType).GetAsString();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).IsNull == false)
        Entity.IsAlarmEvent = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).GetAsBool();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ResponseRequired).IsNull == false)
        Entity.ResponseRequired = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.ResponseRequired).GetAsBool();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NoteUid).IsNull == false)
        Entity.NoteUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.NoteUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(insert_GalaxyPanelActivityEventPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_GalaxyPanelActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelActivityEventUid'
    /// </summary>
    public static string GalaxyPanelActivityEventUid = "@GalaxyPanelActivityEventUid";
    /// <summary>
    /// Returns '@GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "@GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "@GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "@GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns '@GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "@GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns '@ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "@ActivityDateTime";
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
    /// <summary>
    /// Returns '@InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "@InputOutputGroupNumber";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@SectionNumber'
    /// </summary>
    public static string SectionNumber = "@SectionNumber";
    /// <summary>
    /// Returns '@ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "@ModuleNumber";
    /// <summary>
    /// Returns '@NodeNumber'
    /// </summary>
    public static string NodeNumber = "@NodeNumber";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@eventType'
    /// </summary>
    public static string eventType = "@eventType";
    /// <summary>
    /// Returns '@IsAlarmEvent'
    /// </summary>
    public static string IsAlarmEvent = "@IsAlarmEvent";
    /// <summary>
    /// Returns '@AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "@AlarmPriority";
    /// <summary>
    /// Returns '@ResponseRequired'
    /// </summary>
    public static string ResponseRequired = "@ResponseRequired";
    /// <summary>
    /// Returns '@NoteUid'
    /// </summary>
    public static string NoteUid = "@NoteUid";
    /// <summary>
    /// Returns '@BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "@BinaryResourceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
