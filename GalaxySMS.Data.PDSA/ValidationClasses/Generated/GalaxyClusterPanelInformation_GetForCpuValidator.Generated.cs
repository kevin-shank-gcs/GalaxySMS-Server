using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyClusterPanelInformation_GetForCpuPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyClusterPanelInformation_GetForCpuPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyClusterPanelInformation_GetForCpuPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyClusterPanelInformation_GetForCpuPDSA Entity
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
    /// Clones the current GalaxyClusterPanelInformation_GetForCpuPDSA
    /// </summary>
    /// <returns>A cloned GalaxyClusterPanelInformation_GetForCpuPDSA object</returns>
    public GalaxyClusterPanelInformation_GetForCpuPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyClusterPanelInformation_GetForCpuPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyClusterPanelInformation_GetForCpuPDSA entity to clone</param>
    /// <returns>A cloned GalaxyClusterPanelInformation_GetForCpuPDSA object</returns>
    public GalaxyClusterPanelInformation_GetForCpuPDSA CloneEntity(GalaxyClusterPanelInformation_GetForCpuPDSA entityToClone)
    {
      GalaxyClusterPanelInformation_GetForCpuPDSA newEntity = new GalaxyClusterPanelInformation_GetForCpuPDSA();

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
      
      props.Add(PDSAProperty.Create(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyClusterPanelInformation_GetForCpuPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyClusterPanelInformation_GetForCpuPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyClusterPanelInformation_GetForCpuPDSA class.
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
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyClusterPanelInformation_GetForCpuPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@PanelNumber'
    /// </summary>
    public static string PanelNumber = "@PanelNumber";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
