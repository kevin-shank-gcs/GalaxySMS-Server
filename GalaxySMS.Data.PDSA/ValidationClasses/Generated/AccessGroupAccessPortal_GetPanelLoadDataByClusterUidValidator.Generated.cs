using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA Entity
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
    /// Clones the current AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA
    /// </summary>
    /// <returns>A cloned AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA object</returns>
    public AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA entity to clone</param>
    /// <returns>A cloned AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA object</returns>
    public AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA CloneEntity(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA entityToClone)
    {
      AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA newEntity = new AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA();

      newEntity.AccessGroupAccessPortalUid = entityToClone.AccessGroupAccessPortalUid;
      newEntity.AccessGroupName = entityToClone.AccessGroupName;
      newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
      newEntity.AccessPortalName = entityToClone.AccessPortalName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;
      newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
      newEntity.ActivationDate = entityToClone.ActivationDate;
      newEntity.ExpirationDate = entityToClone.ExpirationDate;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.AccessPortalBoardTypeTypeCode = entityToClone.AccessPortalBoardTypeTypeCode;
      newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.AccessGroupLoadToCpuUid = entityToClone.AccessGroupLoadToCpuUid;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.DefaultTimeScheduleName = entityToClone.DefaultTimeScheduleName;
      newEntity.DefaultTimeScheduleNumber = entityToClone.DefaultTimeScheduleNumber;
      newEntity.IsConnected = entityToClone.IsConnected;
      newEntity.IsNodeActive = entityToClone.IsNodeActive;

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
      
      props.Add(PDSAProperty.Create(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessGroupAccessPortalUid'
    /// </summary>
    public static string AccessGroupAccessPortalUid = "AccessGroupAccessPortalUid";
    /// <summary>
    /// Returns 'AccessGroupName'
    /// </summary>
    public static string AccessGroupName = "AccessGroupName";
    /// <summary>
    /// Returns 'TimeScheduleName'
    /// </summary>
    public static string TimeScheduleName = "TimeScheduleName";
    /// <summary>
    /// Returns 'AccessPortalName'
    /// </summary>
    public static string AccessPortalName = "AccessPortalName";
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
    /// Returns 'AccessGroupNumber'
    /// </summary>
    public static string AccessGroupNumber = "AccessGroupNumber";
    /// <summary>
    /// Returns 'PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "PanelScheduleNumber";
    /// <summary>
    /// Returns 'ActivationDate'
    /// </summary>
    public static string ActivationDate = "ActivationDate";
    /// <summary>
    /// Returns 'ExpirationDate'
    /// </summary>
    public static string ExpirationDate = "ExpirationDate";
    /// <summary>
    /// Returns 'IsEnabled'
    /// </summary>
    public static string IsEnabled = "IsEnabled";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "AccessGroupUid";
    /// <summary>
    /// Returns 'AccessPortalBoardTypeTypeCode'
    /// </summary>
    public static string AccessPortalBoardTypeTypeCode = "AccessPortalBoardTypeTypeCode";
    /// <summary>
    /// Returns 'CurrentTimeForCluster'
    /// </summary>
    public static string CurrentTimeForCluster = "CurrentTimeForCluster";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'AccessGroupLoadToCpuUid'
    /// </summary>
    public static string AccessGroupLoadToCpuUid = "AccessGroupLoadToCpuUid";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'DefaultTimeScheduleName'
    /// </summary>
    public static string DefaultTimeScheduleName = "DefaultTimeScheduleName";
    /// <summary>
    /// Returns 'DefaultTimeScheduleNumber'
    /// </summary>
    public static string DefaultTimeScheduleNumber = "DefaultTimeScheduleNumber";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    /// <summary>
    /// Returns 'IsNodeActive'
    /// </summary>
    public static string IsNodeActive = "IsNodeActive";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
