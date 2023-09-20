using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the insert_ActivityEventPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class insert_ActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private insert_ActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new insert_ActivityEventPDSA Entity
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
    /// Clones the current insert_ActivityEventPDSA
    /// </summary>
    /// <returns>A cloned insert_ActivityEventPDSA object</returns>
    public insert_ActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in insert_ActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The insert_ActivityEventPDSA entity to clone</param>
    /// <returns>A cloned insert_ActivityEventPDSA object</returns>
    public insert_ActivityEventPDSA CloneEntity(insert_ActivityEventPDSA entityToClone)
    {
      insert_ActivityEventPDSA newEntity = new insert_ActivityEventPDSA();


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
      
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ActivityEventUid, GetResourceMessage("GCS_insert_ActivityEventPDSA_ActivityEventUid_Header", "Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_insert_ActivityEventPDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeMessage, GetResourceMessage("GCS_insert_ActivityEventPDSA_EventTypeMessage_Header", "Event Type Message"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_EventTypeMessage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ForeColor, GetResourceMessage("GCS_insert_ActivityEventPDSA_ForeColor_Header", "Fore Color"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ForeColor_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.DeviceName, GetResourceMessage("GCS_insert_ActivityEventPDSA_DeviceName_Header", "Device Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_DeviceName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.SiteName, GetResourceMessage("GCS_insert_ActivityEventPDSA_SiteName_Header", "Site Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_SiteName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_insert_ActivityEventPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.DeviceUid, GetResourceMessage("GCS_insert_ActivityEventPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_DeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeUid, GetResourceMessage("GCS_insert_ActivityEventPDSA_EventTypeUid_Header", "Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_EventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.DeviceType, GetResourceMessage("GCS_insert_ActivityEventPDSA_DeviceType_Header", "Device Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_DeviceType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.LastName, GetResourceMessage("GCS_insert_ActivityEventPDSA_LastName_Header", "Last Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_LastName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.FirstName, GetResourceMessage("GCS_insert_ActivityEventPDSA_FirstName_Header", "First Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_FirstName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.IsTraced, GetResourceMessage("GCS_insert_ActivityEventPDSA_IsTraced_Header", "Is Traced"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_IsTraced_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.CredentialDescription, GetResourceMessage("GCS_insert_ActivityEventPDSA_CredentialDescription_Header", "Credential Description"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_CredentialDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_insert_ActivityEventPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_insert_ActivityEventPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ClusterName, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupName, GetResourceMessage("GCS_insert_ActivityEventPDSA_InputOutputGroupName_Header", "Input Output Group Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_InputOutputGroupName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_InputOutputGroupNumber_Header", "Input Output Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_InputOutputGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_BoardNumber_Header", "Board Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.SectionNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_SectionNumber_Header", "Section Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ModuleNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_ModuleNumber_Header", "Module Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ModuleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.NodeNumber, GetResourceMessage("GCS_insert_ActivityEventPDSA_NodeNumber_Header", "Node Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.AlarmPriority, GetResourceMessage("GCS_insert_ActivityEventPDSA_AlarmPriority_Header", "Alarm Priority"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.ResponseRequired, GetResourceMessage("GCS_insert_ActivityEventPDSA_ResponseRequired_Header", "Response Required"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_ResponseRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.EntityName, GetResourceMessage("GCS_insert_ActivityEventPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.EntityType, GetResourceMessage("GCS_insert_ActivityEventPDSA_EntityType_Header", "Entity Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_ActivityEventPDSA_EntityType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_insert_ActivityEventPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.CredentialBytes, GetResourceMessage("GCS_insert_ActivityEventPDSA_CredentialBytes_Header", "Credential Bytes"), false, typeof(byte[]), 32, GetResourceMessage("GCS_insert_ActivityEventPDSA_CredentialBytes_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_insert_ActivityEventPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.IsAlarmEvent, GetResourceMessage("GCS_insert_ActivityEventPDSA_IsAlarmEvent_Header", "Is Alarm Event"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_IsAlarmEvent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent, GetResourceMessage("GCS_insert_ActivityEventPDSA_IsAccessGrantedEvent_Header", "Is Access Granted Event"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_IsAccessGrantedEvent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_ActivityEventPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_insert_ActivityEventPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_insert_ActivityEventPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeMessage).Value = Entity.EventTypeMessage;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ForeColor).Value = Entity.ForeColor;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceName).Value = Entity.DeviceName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.SiteName).Value = Entity.SiteName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceUid).Value = Entity.DeviceUid;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeUid).Value = Entity.EventTypeUid;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceType).Value = Entity.DeviceType;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.LastName).Value = Entity.LastName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.FirstName).Value = Entity.FirstName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsTraced).Value = Entity.IsTraced;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialDescription).Value = Entity.CredentialDescription;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterName).Value = Entity.ClusterName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupName).Value = Entity.InputOutputGroupName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).Value = Entity.InputOutputGroupNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ModuleNumber).Value = Entity.ModuleNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.AlarmPriority).Value = Entity.AlarmPriority;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ResponseRequired).Value = Entity.ResponseRequired;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityName).Value = Entity.EntityName;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityType).Value = Entity.EntityType;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialBytes).Value = Entity.CredentialBytes;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).Value = Entity.IsAlarmEvent;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent).Value = Entity.IsAccessGrantedEvent;
      Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ActivityEventUid).IsNull == false)
        Entity.ActivityEventUid = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ActivityEventUid).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeMessage).IsNull == false)
        Entity.EventTypeMessage = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeMessage).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ForeColor).IsNull == false)
        Entity.ForeColor = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ForeColor).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceName).IsNull == false)
        Entity.DeviceName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.SiteName).IsNull == false)
        Entity.SiteName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.SiteName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceUid).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeUid).IsNull == false)
        Entity.EventTypeUid = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EventTypeUid).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceType).IsNull == false)
        Entity.DeviceType = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.DeviceType).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.LastName).IsNull == false)
        Entity.LastName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.LastName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.FirstName).IsNull == false)
        Entity.FirstName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.FirstName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsTraced).IsNull == false)
        Entity.IsTraced = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsTraced).GetAsBool();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialDescription).IsNull == false)
        Entity.CredentialDescription = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialDescription).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupName).IsNull == false)
        Entity.InputOutputGroupName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).IsNull == false)
        Entity.InputOutputGroupNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.BoardNumber).GetAsShort();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.SectionNumber).GetAsShort();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ModuleNumber).IsNull == false)
        Entity.ModuleNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ModuleNumber).GetAsShort();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.NodeNumber).GetAsShort();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ResponseRequired).IsNull == false)
        Entity.ResponseRequired = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.ResponseRequired).GetAsBool();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityName).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityType).IsNull == false)
        Entity.EntityType = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.EntityType).GetAsString();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialBytes).IsNull == false)
        Entity.CredentialBytes = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.CredentialBytes).GetAsByteArray();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).IsNull == false)
        Entity.IsAlarmEvent = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).GetAsBool();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent).IsNull == false)
        Entity.IsAccessGrantedEvent = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent).GetAsBool();
      if(Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(insert_ActivityEventPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_ActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ActivityEventUid'
    /// </summary>
    public static string ActivityEventUid = "@ActivityEventUid";
    /// <summary>
    /// Returns '@ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "@ActivityDateTime";
    /// <summary>
    /// Returns '@EventTypeMessage'
    /// </summary>
    public static string EventTypeMessage = "@EventTypeMessage";
    /// <summary>
    /// Returns '@ForeColor'
    /// </summary>
    public static string ForeColor = "@ForeColor";
    /// <summary>
    /// Returns '@DeviceName'
    /// </summary>
    public static string DeviceName = "@DeviceName";
    /// <summary>
    /// Returns '@SiteName'
    /// </summary>
    public static string SiteName = "@SiteName";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@DeviceUid'
    /// </summary>
    public static string DeviceUid = "@DeviceUid";
    /// <summary>
    /// Returns '@EventTypeUid'
    /// </summary>
    public static string EventTypeUid = "@EventTypeUid";
    /// <summary>
    /// Returns '@DeviceType'
    /// </summary>
    public static string DeviceType = "@DeviceType";
    /// <summary>
    /// Returns '@LastName'
    /// </summary>
    public static string LastName = "@LastName";
    /// <summary>
    /// Returns '@FirstName'
    /// </summary>
    public static string FirstName = "@FirstName";
    /// <summary>
    /// Returns '@IsTraced'
    /// </summary>
    public static string IsTraced = "@IsTraced";
    /// <summary>
    /// Returns '@CredentialDescription'
    /// </summary>
    public static string CredentialDescription = "@CredentialDescription";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@ClusterName'
    /// </summary>
    public static string ClusterName = "@ClusterName";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@PanelNumber'
    /// </summary>
    public static string PanelNumber = "@PanelNumber";
    /// <summary>
    /// Returns '@InputOutputGroupName'
    /// </summary>
    public static string InputOutputGroupName = "@InputOutputGroupName";
    /// <summary>
    /// Returns '@InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "@InputOutputGroupNumber";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
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
    /// Returns '@AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "@AlarmPriority";
    /// <summary>
    /// Returns '@ResponseRequired'
    /// </summary>
    public static string ResponseRequired = "@ResponseRequired";
    /// <summary>
    /// Returns '@EntityName'
    /// </summary>
    public static string EntityName = "@EntityName";
    /// <summary>
    /// Returns '@EntityType'
    /// </summary>
    public static string EntityType = "@EntityType";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
    /// <summary>
    /// Returns '@CredentialBytes'
    /// </summary>
    public static string CredentialBytes = "@CredentialBytes";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@IsAlarmEvent'
    /// </summary>
    public static string IsAlarmEvent = "@IsAlarmEvent";
    /// <summary>
    /// Returns '@IsAccessGrantedEvent'
    /// </summary>
    public static string IsAccessGrantedEvent = "@IsAccessGrantedEvent";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
