using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyClusterPanelCpuInformationPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyClusterPanelCpuInformationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyClusterPanelCpuInformationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyClusterPanelCpuInformationPDSA Entity
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
    /// Clones the current GalaxyClusterPanelCpuInformationPDSA
    /// </summary>
    /// <returns>A cloned GalaxyClusterPanelCpuInformationPDSA object</returns>
    public GalaxyClusterPanelCpuInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyClusterPanelCpuInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyClusterPanelCpuInformationPDSA entity to clone</param>
    /// <returns>A cloned GalaxyClusterPanelCpuInformationPDSA object</returns>
    public GalaxyClusterPanelCpuInformationPDSA CloneEntity(GalaxyClusterPanelCpuInformationPDSA entityToClone)
    {
      GalaxyClusterPanelCpuInformationPDSA newEntity = new GalaxyClusterPanelCpuInformationPDSA();

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
      newEntity.EntityType = entityToClone.EntityType;
      newEntity.TimeZoneId = entityToClone.TimeZoneId;
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
      
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65565"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65565"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 30, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_IpAddress_Header", "Ip Address"), false, typeof(string), 30, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_IpAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_DefaultEventLoggingOn_Header", "Default Event Logging On"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_DefaultEventLoggingOn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PreventDataLoading_Header", "Prevent Data Loading"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PreventDataLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PreventFlashLoading_Header", "Prevent Flash Loading"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PreventFlashLoading_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_LastLogIndex_Header", "Last Log Index"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_LastLogIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelName_Header", "Panel Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterTypeCode_Header", "Cluster Type Code"), false, typeof(string), 16, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterTypeIsActive_Header", "Cluster Type Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_ClusterTypeIsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CredentialDataLength_Header", "Credential Data Length"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CredentialDataLength_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelLocation_Header", "Panel Location"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelLocation_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelModelTypeCode_Header", "Panel Model Type Code"), false, typeof(string), 16, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelModelTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelModelIsActive_Header", "Panel Model Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_PanelModelIsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CpuIsActive_Header", "Cpu Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_CpuIsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_SiteName_Header", "Site Name"), false, typeof(string), 100, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_SiteName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityType, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_EntityType_Header", "Entity Type"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_EntityType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_TimeZoneId_Header", "Time Zone Id"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_TimeZoneId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IsConnected, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), -1, GetResourceMessage("GCS_GalaxyClusterPanelCpuInformationPDSA_IsConnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      
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
      Entity.EntityType = string.Empty;
      Entity.TimeZoneId = string.Empty;
      Entity.IsConnected = false;

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
      
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber).Value = Entity.CpuNumber;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber).Value = Entity.SerialNumber;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress).Value = Entity.IpAddress;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).Value = Entity.DefaultEventLoggingOn;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).Value = Entity.PreventDataLoading;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).Value = Entity.PreventFlashLoading;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex).Value = Entity.LastLogIndex;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName).Value = Entity.PanelName;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).Value = Entity.ClusterTypeCode;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).Value = Entity.ClusterTypeIsActive;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).Value = Entity.CredentialDataLength;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation).Value = Entity.PanelLocation;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).Value = Entity.PanelModelTypeCode;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).Value = Entity.PanelModelIsActive;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive).Value = Entity.CpuIsActive;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName).Value = Entity.SiteName;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityType).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityType).Value = Entity.EntityType;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId).Value = Entity.TimeZoneId;
      if(!Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IsConnected).SetAsNull)
        Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IsConnected).Value = Entity.IsConnected;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress).IsNull == false)
        Entity.IpAddress = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).IsNull == false)
        Entity.DefaultEventLoggingOn = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn).GetAsBool();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).IsNull == false)
        Entity.PreventDataLoading = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading).GetAsBool();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).IsNull == false)
        Entity.PreventFlashLoading = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading).GetAsBool();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex).IsNull == false)
        Entity.LastLogIndex = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex).GetAsInteger();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName).IsNull == false)
        Entity.PanelName = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).IsNull == false)
        Entity.ClusterTypeCode = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).IsNull == false)
        Entity.ClusterTypeIsActive = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive).GetAsBool();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).IsNull == false)
        Entity.CredentialDataLength = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength).GetAsShort();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation).IsNull == false)
        Entity.PanelLocation = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).IsNull == false)
        Entity.PanelModelTypeCode = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).IsNull == false)
        Entity.PanelModelIsActive = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive).GetAsBool();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive).IsNull == false)
        Entity.CpuIsActive = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive).GetAsBool();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName).IsNull == false)
        Entity.SiteName = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityType).IsNull == false)
        Entity.EntityType = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityType).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId).IsNull == false)
        Entity.TimeZoneId = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId).GetAsString();
      if(Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IsConnected).IsNull == false)
        Entity.IsConnected = Properties.GetByName(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IsConnected).GetAsBool();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyClusterPanelCpuInformationPDSA class.
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
    /// Returns 'EntityType'
    /// </summary>
    public static string EntityType = "EntityType";
    /// <summary>
    /// Returns 'TimeZoneId'
    /// </summary>
    public static string TimeZoneId = "TimeZoneId";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    }
    #endregion
  }
}
