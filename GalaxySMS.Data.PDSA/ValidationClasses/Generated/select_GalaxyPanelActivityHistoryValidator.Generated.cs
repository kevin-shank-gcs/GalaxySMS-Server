using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the select_GalaxyPanelActivityHistoryPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class select_GalaxyPanelActivityHistoryPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private select_GalaxyPanelActivityHistoryPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new select_GalaxyPanelActivityHistoryPDSA Entity
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
    /// Clones the current select_GalaxyPanelActivityHistoryPDSA
    /// </summary>
    /// <returns>A cloned select_GalaxyPanelActivityHistoryPDSA object</returns>
    public select_GalaxyPanelActivityHistoryPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in select_GalaxyPanelActivityHistoryPDSA
    /// </summary>
    /// <param name="entityToClone">The select_GalaxyPanelActivityHistoryPDSA entity to clone</param>
    /// <returns>A cloned select_GalaxyPanelActivityHistoryPDSA object</returns>
    public select_GalaxyPanelActivityHistoryPDSA CloneEntity(select_GalaxyPanelActivityHistoryPDSA entityToClone)
    {
      select_GalaxyPanelActivityHistoryPDSA newEntity = new select_GalaxyPanelActivityHistoryPDSA();

      newEntity.ActivityDateTime = entityToClone.ActivityDateTime;
      newEntity.ActivityDateTimeUTC = entityToClone.ActivityDateTimeUTC;
      newEntity.EventTypeMessage = entityToClone.EventTypeMessage;
      newEntity.ForeColor = entityToClone.ForeColor;
      newEntity.DeviceName = entityToClone.DeviceName;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.EventTypeUid = entityToClone.EventTypeUid;
      newEntity.DeviceType = entityToClone.DeviceType;
      newEntity.LastName = entityToClone.LastName;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.InputOutputGroupName = entityToClone.InputOutputGroupName;
      newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.PK = entityToClone.PK;
      newEntity.TotalRecordCount = entityToClone.TotalRecordCount;
      newEntity.PageNumber = entityToClone.PageNumber;
      newEntity.PageSize = entityToClone.PageSize;

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
      
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DeviceUid, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_DeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.StartDateTime, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_StartDateTime_Header", "Start Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_StartDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EndDateTime, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_EndDateTime_Header", "End Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_EndDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_IncludeLoggingOnOffEvents_Header", "Include Logging On Off Events"), false, typeof(bool), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_IncludeLoggingOnOffEvents_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.CultureName, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 8000, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.MaxResults, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_MaxResults_Header", "Max Results"), false, typeof(int), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_MaxResults_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DescendingOrder, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_select_GalaxyPanelActivityHistoryPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DeviceUid).Value = Entity.DeviceUid;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.StartDateTime).Value = Entity.StartDateTime;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EndDateTime).Value = Entity.EndDateTime;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents).Value = Entity.IncludeLoggingOnOffEvents;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.CultureName).Value = Entity.CultureName;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.MaxResults).Value = Entity.MaxResults;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DescendingOrder).Value = Entity.DescendingOrder;
      this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DeviceUid).GetAsGuid();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.StartDateTime).IsNull == false)
        Entity.StartDateTime = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.StartDateTime).GetAsDateTimeOffset();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EndDateTime).IsNull == false)
        Entity.EndDateTime = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.EndDateTime).GetAsDateTimeOffset();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents).IsNull == false)
        Entity.IncludeLoggingOnOffEvents = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.IncludeLoggingOnOffEvents).GetAsBool();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.CultureName).IsNull == false)
        Entity.CultureName = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.CultureName).GetAsString();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageNumber).IsNull == false)
        Entity.PageNumber = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageSize).IsNull == false)
        Entity.PageSize = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.PageSize).GetAsInteger();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.MaxResults).IsNull == false)
        Entity.MaxResults = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.MaxResults).GetAsInteger();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.DescendingOrder).GetAsBool();
      if(this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(select_GalaxyPanelActivityHistoryPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the select_GalaxyPanelActivityHistoryPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "ActivityDateTime";
    /// <summary>
    /// Returns 'ActivityDateTimeUTC'
    /// </summary>
    public static string ActivityDateTimeUTC = "ActivityDateTimeUTC";
    /// <summary>
    /// Returns 'EventTypeMessage'
    /// </summary>
    public static string EventTypeMessage = "EventTypeMessage";
    /// <summary>
    /// Returns 'ForeColor'
    /// </summary>
    public static string ForeColor = "ForeColor";
    /// <summary>
    /// Returns 'DeviceName'
    /// </summary>
    public static string DeviceName = "DeviceName";
    /// <summary>
    /// Returns 'SiteName'
    /// </summary>
    public static string SiteName = "SiteName";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'DeviceUid'
    /// </summary>
    public static string DeviceUid = "DeviceUid";
    /// <summary>
    /// Returns 'EventTypeUid'
    /// </summary>
    public static string EventTypeUid = "EventTypeUid";
    /// <summary>
    /// Returns 'DeviceType'
    /// </summary>
    public static string DeviceType = "DeviceType";
    /// <summary>
    /// Returns 'LastName'
    /// </summary>
    public static string LastName = "LastName";
    /// <summary>
    /// Returns 'FirstName'
    /// </summary>
    public static string FirstName = "FirstName";
    /// <summary>
    /// Returns 'CredentialDescription'
    /// </summary>
    public static string CredentialDescription = "CredentialDescription";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'CredentialUid'
    /// </summary>
    public static string CredentialUid = "CredentialUid";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'InputOutputGroupName'
    /// </summary>
    public static string InputOutputGroupName = "InputOutputGroupName";
    /// <summary>
    /// Returns 'InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "InputOutputGroupNumber";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
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
    /// Returns 'PK'
    /// </summary>
    public static string PK = "PK";
    /// <summary>
    /// Returns 'TotalRecordCount'
    /// </summary>
    public static string TotalRecordCount = "TotalRecordCount";
    /// <summary>
    /// Returns 'PageNumber'
    /// </summary>
    public static string PageNumber = "PageNumber";
    /// <summary>
    /// Returns 'PageSize'
    /// </summary>
    public static string PageSize = "PageSize";
    /// <summary>
    /// Returns '@StartDateTime'
    /// </summary>
    public static string StartDateTime = "@StartDateTime";
    /// <summary>
    /// Returns '@EndDateTime'
    /// </summary>
    public static string EndDateTime = "@EndDateTime";
    /// <summary>
    /// Returns '@IncludeLoggingOnOffEvents'
    /// </summary>
    public static string IncludeLoggingOnOffEvents = "@IncludeLoggingOnOffEvents";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@MaxResults'
    /// </summary>
    public static string MaxResults = "@MaxResults";
    /// <summary>
    /// Returns '@DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "@DescendingOrder";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the select_GalaxyPanelActivityHistoryPDSA class.
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
    /// Returns '@DeviceUid'
    /// </summary>
    public static string DeviceUid = "@DeviceUid";
    /// <summary>
    /// Returns '@StartDateTime'
    /// </summary>
    public static string StartDateTime = "@StartDateTime";
    /// <summary>
    /// Returns '@EndDateTime'
    /// </summary>
    public static string EndDateTime = "@EndDateTime";
    /// <summary>
    /// Returns '@IncludeLoggingOnOffEvents'
    /// </summary>
    public static string IncludeLoggingOnOffEvents = "@IncludeLoggingOnOffEvents";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@MaxResults'
    /// </summary>
    public static string MaxResults = "@MaxResults";
    /// <summary>
    /// Returns '@DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "@DescendingOrder";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
