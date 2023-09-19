using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyCpuInformationPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpuInformationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyCpuInformationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyCpuInformationPDSA Entity
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
    /// Clones the current GalaxyCpuInformationPDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpuInformationPDSA object</returns>
    public GalaxyCpuInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpuInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpuInformationPDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpuInformationPDSA object</returns>
    public GalaxyCpuInformationPDSA CloneEntity(GalaxyCpuInformationPDSA entityToClone)
    {
      GalaxyCpuInformationPDSA newEntity = new GalaxyCpuInformationPDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.SerialNumber = entityToClone.SerialNumber;
      newEntity.IpAddress = entityToClone.IpAddress;
      newEntity.DefaultEventLoggingOn = entityToClone.DefaultEventLoggingOn;
      newEntity.PreventDataLoading = entityToClone.PreventDataLoading;
      newEntity.PreventFlashLoading = entityToClone.PreventFlashLoading;
      newEntity.LastLogIndex = entityToClone.LastLogIndex;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.PanelName = entityToClone.PanelName;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.ClusterTypeIsActive = entityToClone.ClusterTypeIsActive;
      newEntity.CredentialDataLength = entityToClone.CredentialDataLength;
      newEntity.PanelLocation = entityToClone.PanelLocation;
      newEntity.PanelModelTypeCode = entityToClone.PanelModelTypeCode;
      newEntity.PanelModelIsActive = entityToClone.PanelModelIsActive;
      newEntity.CpuIsActive = entityToClone.CpuIsActive;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.TimeZoneId = entityToClone.TimeZoneId;

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
      
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_AccountCode_Header", "Account Code"), false, typeof(string), 16, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_AccountCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(short), 10, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelNumber_Header", "Panel Number"), false, typeof(short), 10, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 30, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_IpAddress_Header", "Ip Address"), false, typeof(string), 30, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_IpAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_DefaultEventLoggingOn_Header", "Default Event Logging On"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_DefaultEventLoggingOn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PreventDataLoading_Header", "Prevent Data Loading"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PreventDataLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PreventFlashLoading_Header", "Prevent Flash Loading"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PreventFlashLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_LastLogIndex_Header", "Last Log Index"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_LastLogIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelName_Header", "Panel Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterTypeCode_Header", "Cluster Type Code"), false, typeof(string), 16, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterTypeIsActive_Header", "Cluster Type Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_ClusterTypeIsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CredentialDataLength_Header", "Credential Data Length"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CredentialDataLength_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelLocation_Header", "Panel Location"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelLocation_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelModelTypeCode_Header", "Panel Model Type Code"), false, typeof(string), 16, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelModelTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelModelIsActive_Header", "Panel Model Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_PanelModelIsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CpuIsActive_Header", "Cpu Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_CpuIsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_SiteName_Header", "Site Name"), false, typeof(string), 100, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_SiteName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_TimeZoneId_Header", "Time Zone Id"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyCpuInformationPDSA_TimeZoneId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ClusterUid = Guid.Empty;
      Entity.GalaxyPanelUid = Guid.Empty;
      Entity.CpuUid = Guid.Empty;
      Entity.ClusterGroupId = 0;
      Entity.ClusterNumber = 0;
      Entity.PanelNumber = 0;
      Entity.CpuNumber = 0;
      Entity.SerialNumber = string.Empty;
      Entity.IpAddress = string.Empty;
      Entity.DefaultEventLoggingOn = false;
      Entity.PreventDataLoading = false;
      Entity.PreventFlashLoading = false;
      Entity.LastLogIndex = 0;
      Entity.ClusterName = string.Empty;
      Entity.PanelName = string.Empty;
      Entity.ClusterTypeCode = string.Empty;
      Entity.ClusterTypeIsActive = false;
      Entity.CredentialDataLength = 0;
      Entity.PanelLocation = string.Empty;
      Entity.PanelModelTypeCode = string.Empty;
      Entity.PanelModelIsActive = false;
      Entity.CpuIsActive = false;
      Entity.SiteUid = Guid.Empty;
      Entity.SiteName = string.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.EntityName = string.Empty;
      Entity.TimeZoneId = string.Empty;

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
      
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber).Value = Entity.CpuNumber;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber).Value = Entity.SerialNumber;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress).Value = Entity.IpAddress;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).Value = Entity.DefaultEventLoggingOn;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).Value = Entity.PreventDataLoading;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).Value = Entity.PreventFlashLoading;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex).Value = Entity.LastLogIndex;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName).Value = Entity.PanelName;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).Value = Entity.ClusterTypeCode;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).Value = Entity.ClusterTypeIsActive;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).Value = Entity.CredentialDataLength;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation).Value = Entity.PanelLocation;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).Value = Entity.PanelModelTypeCode;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).Value = Entity.PanelModelIsActive;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive).Value = Entity.CpuIsActive;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName).Value = Entity.SiteName;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if(!Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId).SetAsNull)
        Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId).Value = Entity.TimeZoneId;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterNumber).GetAsShort();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelNumber).GetAsShort();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SerialNumber).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress).IsNull == false)
        Entity.IpAddress = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.IpAddress).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).IsNull == false)
        Entity.DefaultEventLoggingOn = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).GetAsBool();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).IsNull == false)
        Entity.PreventDataLoading = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).GetAsBool();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).IsNull == false)
        Entity.PreventFlashLoading = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).GetAsBool();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex).IsNull == false)
        Entity.LastLogIndex = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.LastLogIndex).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterName).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName).IsNull == false)
        Entity.PanelName = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelName).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).IsNull == false)
        Entity.ClusterTypeCode = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).IsNull == false)
        Entity.ClusterTypeIsActive = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).GetAsBool();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).IsNull == false)
        Entity.CredentialDataLength = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).GetAsShort();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation).IsNull == false)
        Entity.PanelLocation = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelLocation).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).IsNull == false)
        Entity.PanelModelTypeCode = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).IsNull == false)
        Entity.PanelModelIsActive = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).GetAsBool();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive).IsNull == false)
        Entity.CpuIsActive = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.CpuIsActive).GetAsBool();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName).IsNull == false)
        Entity.SiteName = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.SiteName).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.EntityName).GetAsString();
      if(Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId).IsNull == false)
        Entity.TimeZoneId = Properties.GetByName(GalaxyCpuInformationPDSAValidator.ColumnNames.TimeZoneId).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyCpuInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
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
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'SerialNumber'
    /// </summary>
    public static string SerialNumber = "SerialNumber";
    /// <summary>
    /// Returns 'IpAddress'
    /// </summary>
    public static string IpAddress = "IpAddress";
    /// <summary>
    /// Returns 'DefaultEventLoggingOn'
    /// </summary>
    public static string DefaultEventLoggingOn = "DefaultEventLoggingOn";
    /// <summary>
    /// Returns 'PreventDataLoading'
    /// </summary>
    public static string PreventDataLoading = "PreventDataLoading";
    /// <summary>
    /// Returns 'PreventFlashLoading'
    /// </summary>
    public static string PreventFlashLoading = "PreventFlashLoading";
    /// <summary>
    /// Returns 'LastLogIndex'
    /// </summary>
    public static string LastLogIndex = "LastLogIndex";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'PanelName'
    /// </summary>
    public static string PanelName = "PanelName";
    /// <summary>
    /// Returns 'ClusterTypeCode'
    /// </summary>
    public static string ClusterTypeCode = "ClusterTypeCode";
    /// <summary>
    /// Returns 'ClusterTypeIsActive'
    /// </summary>
    public static string ClusterTypeIsActive = "ClusterTypeIsActive";
    /// <summary>
    /// Returns 'CredentialDataLength'
    /// </summary>
    public static string CredentialDataLength = "CredentialDataLength";
    /// <summary>
    /// Returns 'PanelLocation'
    /// </summary>
    public static string PanelLocation = "PanelLocation";
    /// <summary>
    /// Returns 'PanelModelTypeCode'
    /// </summary>
    public static string PanelModelTypeCode = "PanelModelTypeCode";
    /// <summary>
    /// Returns 'PanelModelIsActive'
    /// </summary>
    public static string PanelModelIsActive = "PanelModelIsActive";
    /// <summary>
    /// Returns 'CpuIsActive'
    /// </summary>
    public static string CpuIsActive = "CpuIsActive";
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'SiteName'
    /// </summary>
    public static string SiteName = "SiteName";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'TimeZoneId'
    /// </summary>
    public static string TimeZoneId = "TimeZoneId";
    }
    #endregion
  }
}
