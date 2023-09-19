using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the ActivityEventPDSA_InsertPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ActivityEventPDSA_InsertPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ActivityEventPDSA_InsertPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ActivityEventPDSA_InsertPDSA Entity
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
    /// Clones the current ActivityEventPDSA_InsertPDSA
    /// </summary>
    /// <returns>A cloned ActivityEventPDSA_InsertPDSA object</returns>
    public ActivityEventPDSA_InsertPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ActivityEventPDSA_InsertPDSA
    /// </summary>
    /// <param name="entityToClone">The ActivityEventPDSA_InsertPDSA entity to clone</param>
    /// <returns>A cloned ActivityEventPDSA_InsertPDSA object</returns>
    public ActivityEventPDSA_InsertPDSA CloneEntity(ActivityEventPDSA_InsertPDSA entityToClone)
    {
      ActivityEventPDSA_InsertPDSA newEntity = new ActivityEventPDSA_InsertPDSA();


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
      
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityEventUid, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ActivityEventUid_Header", "Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeMessage, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EventTypeMessage_Header", "Event Type Message"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EventTypeMessage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ForeColor, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ForeColor_Header", "Fore Color"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ForeColor_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_DeviceName_Header", "Device Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_DeviceName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SiteName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_SiteName_Header", "Site Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_SiteName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceUid, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_DeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeUid, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EventTypeUid_Header", "Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceType, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_DeviceType_Header", "Device Type"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_DeviceType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.LastName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_LastName_Header", "Last Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_LastName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.FirstName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_FirstName_Header", "First Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_FirstName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.IsTraced, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_IsTraced_Header", "Is Traced"), false, typeof(bool), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_IsTraced_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialDescription, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CredentialDescription_Header", "Credential Description"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CredentialDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_InputOutputGroupName_Header", "Input Output Group Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_InputOutputGroupName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_InputOutputGroupNumber_Header", "Input Output Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_InputOutputGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_BoardNumber_Header", "Board Number"), false, typeof(short), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SectionNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_SectionNumber_Header", "Section Number"), false, typeof(short), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ModuleNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ModuleNumber_Header", "Module Number"), false, typeof(short), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ModuleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.NodeNumber, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_NodeNumber_Header", "Node Number"), false, typeof(short), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.AlarmPriority, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_AlarmPriority_Header", "Alarm Priority"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ResponseRequired, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ResponseRequired_Header", "Response Required"), false, typeof(bool), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_ResponseRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityName, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityType, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EntityType_Header", "Entity Type"), false, typeof(string), 8000, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_EntityType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialBytes, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CredentialBytes_Header", "Credential Bytes"), false, typeof(byte[]), 32, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_CredentialBytes_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_ActivityEventPDSA_InsertPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeMessage).Value = Entity.EventTypeMessage;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ForeColor).Value = Entity.ForeColor;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceName).Value = Entity.DeviceName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SiteName).Value = Entity.SiteName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceUid).Value = Entity.DeviceUid;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeUid).Value = Entity.EventTypeUid;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceType).Value = Entity.DeviceType;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.LastName).Value = Entity.LastName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.FirstName).Value = Entity.FirstName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.IsTraced).Value = Entity.IsTraced;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialDescription).Value = Entity.CredentialDescription;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterName).Value = Entity.ClusterName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupName).Value = Entity.InputOutputGroupName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupNumber).Value = Entity.InputOutputGroupNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ModuleNumber).Value = Entity.ModuleNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.AlarmPriority).Value = Entity.AlarmPriority;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ResponseRequired).Value = Entity.ResponseRequired;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityName).Value = Entity.EntityName;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityType).Value = Entity.EntityType;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialBytes).Value = Entity.CredentialBytes;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityEventUid).IsNull == false)
        Entity.ActivityEventUid = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityEventUid).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeMessage).IsNull == false)
        Entity.EventTypeMessage = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeMessage).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ForeColor).IsNull == false)
        Entity.ForeColor = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ForeColor).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceName).IsNull == false)
        Entity.DeviceName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SiteName).IsNull == false)
        Entity.SiteName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SiteName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceUid).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeUid).IsNull == false)
        Entity.EventTypeUid = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EventTypeUid).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceType).IsNull == false)
        Entity.DeviceType = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.DeviceType).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.LastName).IsNull == false)
        Entity.LastName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.LastName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.FirstName).IsNull == false)
        Entity.FirstName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.FirstName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.IsTraced).IsNull == false)
        Entity.IsTraced = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.IsTraced).GetAsBool();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialDescription).IsNull == false)
        Entity.CredentialDescription = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialDescription).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupName).IsNull == false)
        Entity.InputOutputGroupName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupNumber).IsNull == false)
        Entity.InputOutputGroupNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InputOutputGroupNumber).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BoardNumber).GetAsShort();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.SectionNumber).GetAsShort();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ModuleNumber).IsNull == false)
        Entity.ModuleNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ModuleNumber).GetAsShort();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.NodeNumber).GetAsShort();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ResponseRequired).IsNull == false)
        Entity.ResponseRequired = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.ResponseRequired).GetAsBool();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityName).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityType).IsNull == false)
        Entity.EntityType = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.EntityType).GetAsString();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialBytes).IsNull == false)
        Entity.CredentialBytes = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.CredentialBytes).GetAsByteArray();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(ActivityEventPDSA_InsertPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ActivityEventPDSA_InsertPDSA class.
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
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
