using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the select_ActivityEventsPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class select_ActivityEventsPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private select_ActivityEventsPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new select_ActivityEventsPDSA Entity
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
    /// Clones the current select_ActivityEventsPDSA
    /// </summary>
    /// <returns>A cloned select_ActivityEventsPDSA object</returns>
    public select_ActivityEventsPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in select_ActivityEventsPDSA
    /// </summary>
    /// <param name="entityToClone">The select_ActivityEventsPDSA entity to clone</param>
    /// <returns>A cloned select_ActivityEventsPDSA object</returns>
    public select_ActivityEventsPDSA CloneEntity(select_ActivityEventsPDSA entityToClone)
    {
      select_ActivityEventsPDSA newEntity = new select_ActivityEventsPDSA();

      newEntity.TotalItemCount = entityToClone.TotalItemCount;
      newEntity.PK = entityToClone.PK;
      newEntity.ActivityDateTime = entityToClone.ActivityDateTime;
      newEntity.ActivityDateTimeUTC = entityToClone.ActivityDateTimeUTC;
      newEntity.AcknowledgeComment = entityToClone.AcknowledgeComment;
      newEntity.AcknowledgedTime = entityToClone.AcknowledgedTime;
      newEntity.EventTypeUid = entityToClone.EventTypeUid;
      newEntity.EventTypeMessage = entityToClone.EventTypeMessage;
      newEntity.ForeColorHex = entityToClone.ForeColorHex;
      newEntity.AlarmPriority = entityToClone.AlarmPriority;
      newEntity.DeviceType = entityToClone.DeviceType;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.DeviceName = entityToClone.DeviceName;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.LastName = entityToClone.LastName;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.IsTraced = entityToClone.IsTraced;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.InputOutputGroupName = entityToClone.InputOutputGroupName;
      newEntity.IsAcknowledgeable = entityToClone.IsAcknowledgeable;
      newEntity.AckCount = entityToClone.AckCount;
      newEntity.IsAcknowledged = entityToClone.IsAcknowledged;
      newEntity.AcknowledgedByUser = entityToClone.AcknowledgedByUser;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityType = entityToClone.EntityType;

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
      
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_select_ActivityEventsPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_select_ActivityEventsPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.StartDateTime, GetResourceMessage("GCS_select_ActivityEventsPDSA_StartDateTime_Header", "Start Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_StartDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.EndDateTime, GetResourceMessage("GCS_select_ActivityEventsPDSA_EndDateTime_Header", "End Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_EndDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.DeviceUid, GetResourceMessage("GCS_select_ActivityEventsPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_DeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_select_ActivityEventsPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_select_ActivityEventsPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_select_ActivityEventsPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.EventTypeUids, GetResourceMessage("GCS_select_ActivityEventsPDSA_EventTypeUids_Header", "Event Type Uids"), false, typeof(string), 8000, GetResourceMessage("GCS_select_ActivityEventsPDSA_EventTypeUids_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.IsAcknowledgeable, GetResourceMessage("GCS_select_ActivityEventsPDSA_IsAcknowledgeable_Header", "Is Acknowledgeable"), false, typeof(bool), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_IsAcknowledgeable_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.IsActionRequired, GetResourceMessage("GCS_select_ActivityEventsPDSA_IsActionRequired_Header", "Is Action Required"), false, typeof(bool), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_IsActionRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.IsTraced, GetResourceMessage("GCS_select_ActivityEventsPDSA_IsTraced_Header", "Is Traced"), false, typeof(bool), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_IsTraced_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.StartPriority, GetResourceMessage("GCS_select_ActivityEventsPDSA_StartPriority_Header", "Start Priority"), false, typeof(int), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_StartPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.EndPriority, GetResourceMessage("GCS_select_ActivityEventsPDSA_EndPriority_Header", "End Priority"), false, typeof(int), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_EndPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.Priorities, GetResourceMessage("GCS_select_ActivityEventsPDSA_Priorities_Header", "Priorities"), false, typeof(string), 8000, GetResourceMessage("GCS_select_ActivityEventsPDSA_Priorities_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.JustNumber, GetResourceMessage("GCS_select_ActivityEventsPDSA_JustNumber_Header", "Just Number"), false, typeof(bool), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_JustNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_select_ActivityEventsPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_select_ActivityEventsPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.SortColumn, GetResourceMessage("GCS_select_ActivityEventsPDSA_SortColumn_Header", "Sort Column"), false, typeof(string), 8000, GetResourceMessage("GCS_select_ActivityEventsPDSA_SortColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.DescendingOrder, GetResourceMessage("GCS_select_ActivityEventsPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.CultureName, GetResourceMessage("GCS_select_ActivityEventsPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 8000, GetResourceMessage("GCS_select_ActivityEventsPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents, GetResourceMessage("GCS_select_ActivityEventsPDSA_IncludeLoggingOnOffEvents_Header", "Include Logging On Off Events"), false, typeof(bool), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_IncludeLoggingOnOffEvents_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_ActivityEventsPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_select_ActivityEventsPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_select_ActivityEventsPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.StartDateTime).Value = Entity.StartDateTime;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EndDateTime).Value = Entity.EndDateTime;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.DeviceUid).Value = Entity.DeviceUid;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EventTypeUids).Value = Entity.EventTypeUids;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsAcknowledgeable).Value = Entity.IsAcknowledgeable;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsActionRequired).Value = Entity.IsActionRequired;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsTraced).Value = Entity.IsTraced;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.StartPriority).Value = Entity.StartPriority;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EndPriority).Value = Entity.EndPriority;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.Priorities).Value = Entity.Priorities;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.JustNumber).Value = Entity.JustNumber;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.SortColumn).Value = Entity.SortColumn;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.DescendingOrder).Value = Entity.DescendingOrder;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.CultureName).Value = Entity.CultureName;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents).Value = Entity.IncludeLoggingOnOffEvents;
      this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.StartDateTime).IsNull == false)
        Entity.StartDateTime = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.StartDateTime).GetAsDateTimeOffset();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EndDateTime).IsNull == false)
        Entity.EndDateTime = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EndDateTime).GetAsDateTimeOffset();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.DeviceUid).GetAsGuid();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EventTypeUids).IsNull == false)
        Entity.EventTypeUids = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EventTypeUids).GetAsString();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsAcknowledgeable).IsNull == false)
        Entity.IsAcknowledgeable = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsAcknowledgeable).GetAsBool();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsActionRequired).IsNull == false)
        Entity.IsActionRequired = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsActionRequired).GetAsBool();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsTraced).IsNull == false)
        Entity.IsTraced = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IsTraced).GetAsBool();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.StartPriority).IsNull == false)
        Entity.StartPriority = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.StartPriority).GetAsInteger();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EndPriority).IsNull == false)
        Entity.EndPriority = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.EndPriority).GetAsInteger();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.Priorities).IsNull == false)
        Entity.Priorities = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.Priorities).GetAsString();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.JustNumber).IsNull == false)
        Entity.JustNumber = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.JustNumber).GetAsBool();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PageNumber).IsNull == false)
        Entity.PageNumber = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PageSize).IsNull == false)
        Entity.PageSize = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.PageSize).GetAsInteger();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.SortColumn).IsNull == false)
        Entity.SortColumn = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.SortColumn).GetAsString();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.DescendingOrder).GetAsBool();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.CultureName).IsNull == false)
        Entity.CultureName = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.CultureName).GetAsString();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents).IsNull == false)
        Entity.IncludeLoggingOnOffEvents = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents).GetAsBool();
      if(this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(select_ActivityEventsPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the select_ActivityEventsPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'TotalItemCount'
    /// </summary>
    public static string TotalItemCount = "TotalItemCount";
    /// <summary>
    /// Returns 'PK'
    /// </summary>
    public static string PK = "PK";
    /// <summary>
    /// Returns 'ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "ActivityDateTime";
    /// <summary>
    /// Returns 'ActivityDateTimeUTC'
    /// </summary>
    public static string ActivityDateTimeUTC = "ActivityDateTimeUTC";
    /// <summary>
    /// Returns 'AcknowledgeComment'
    /// </summary>
    public static string AcknowledgeComment = "AcknowledgeComment";
    /// <summary>
    /// Returns 'AcknowledgedTime'
    /// </summary>
    public static string AcknowledgedTime = "AcknowledgedTime";
    /// <summary>
    /// Returns 'EventTypeUid'
    /// </summary>
    public static string EventTypeUid = "EventTypeUid";
    /// <summary>
    /// Returns 'EventTypeMessage'
    /// </summary>
    public static string EventTypeMessage = "EventTypeMessage";
    /// <summary>
    /// Returns 'ForeColorHex'
    /// </summary>
    public static string ForeColorHex = "ForeColorHex";
    /// <summary>
    /// Returns 'AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "AlarmPriority";
    /// <summary>
    /// Returns 'DeviceType'
    /// </summary>
    public static string DeviceType = "DeviceType";
    /// <summary>
    /// Returns 'DeviceUid'
    /// </summary>
    public static string DeviceUid = "DeviceUid";
    /// <summary>
    /// Returns 'DeviceName'
    /// </summary>
    public static string DeviceName = "DeviceName";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'LastName'
    /// </summary>
    public static string LastName = "LastName";
    /// <summary>
    /// Returns 'FirstName'
    /// </summary>
    public static string FirstName = "FirstName";
    /// <summary>
    /// Returns 'IsTraced'
    /// </summary>
    public static string IsTraced = "IsTraced";
    /// <summary>
    /// Returns 'CredentialDescription'
    /// </summary>
    public static string CredentialDescription = "CredentialDescription";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'InputOutputGroupName'
    /// </summary>
    public static string InputOutputGroupName = "InputOutputGroupName";
    /// <summary>
    /// Returns 'IsAcknowledgeable'
    /// </summary>
    public static string IsAcknowledgeable = "IsAcknowledgeable";
    /// <summary>
    /// Returns 'AckCount'
    /// </summary>
    public static string AckCount = "AckCount";
    /// <summary>
    /// Returns 'IsAcknowledged'
    /// </summary>
    public static string IsAcknowledged = "IsAcknowledged";
    /// <summary>
    /// Returns 'AcknowledgedByUser'
    /// </summary>
    public static string AcknowledgedByUser = "AcknowledgedByUser";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'EntityType'
    /// </summary>
    public static string EntityType = "EntityType";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@StartDateTime'
    /// </summary>
    public static string StartDateTime = "@StartDateTime";
    /// <summary>
    /// Returns '@EndDateTime'
    /// </summary>
    public static string EndDateTime = "@EndDateTime";
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@EventTypeUids'
    /// </summary>
    public static string EventTypeUids = "@EventTypeUids";
    /// <summary>
    /// Returns '@IsActionRequired'
    /// </summary>
    public static string IsActionRequired = "@IsActionRequired";
    /// <summary>
    /// Returns '@StartPriority'
    /// </summary>
    public static string StartPriority = "@StartPriority";
    /// <summary>
    /// Returns '@EndPriority'
    /// </summary>
    public static string EndPriority = "@EndPriority";
    /// <summary>
    /// Returns '@Priorities'
    /// </summary>
    public static string Priorities = "@Priorities";
    /// <summary>
    /// Returns '@JustNumber'
    /// </summary>
    public static string JustNumber = "@JustNumber";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@SortColumn'
    /// </summary>
    public static string SortColumn = "@SortColumn";
    /// <summary>
    /// Returns '@DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "@DescendingOrder";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@IncludeLoggingOnOffEvents'
    /// </summary>
    public static string IncludeLoggingOnOffEvents = "@IncludeLoggingOnOffEvents";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the select_ActivityEventsPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@StartDateTime'
    /// </summary>
    public static string StartDateTime = "@StartDateTime";
    /// <summary>
    /// Returns '@EndDateTime'
    /// </summary>
    public static string EndDateTime = "@EndDateTime";
    /// <summary>
    /// Returns '@DeviceUid'
    /// </summary>
    public static string DeviceUid = "@DeviceUid";
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
    /// Returns '@EventTypeUids'
    /// </summary>
    public static string EventTypeUids = "@EventTypeUids";
    /// <summary>
    /// Returns '@IsAcknowledgeable'
    /// </summary>
    public static string IsAcknowledgeable = "@IsAcknowledgeable";
    /// <summary>
    /// Returns '@IsActionRequired'
    /// </summary>
    public static string IsActionRequired = "@IsActionRequired";
    /// <summary>
    /// Returns '@IsTraced'
    /// </summary>
    public static string IsTraced = "@IsTraced";
    /// <summary>
    /// Returns '@StartPriority'
    /// </summary>
    public static string StartPriority = "@StartPriority";
    /// <summary>
    /// Returns '@EndPriority'
    /// </summary>
    public static string EndPriority = "@EndPriority";
    /// <summary>
    /// Returns '@Priorities'
    /// </summary>
    public static string Priorities = "@Priorities";
    /// <summary>
    /// Returns '@JustNumber'
    /// </summary>
    public static string JustNumber = "@JustNumber";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@SortColumn'
    /// </summary>
    public static string SortColumn = "@SortColumn";
    /// <summary>
    /// Returns '@DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "@DescendingOrder";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@IncludeLoggingOnOffEvents'
    /// </summary>
    public static string IncludeLoggingOnOffEvents = "@IncludeLoggingOnOffEvents";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
