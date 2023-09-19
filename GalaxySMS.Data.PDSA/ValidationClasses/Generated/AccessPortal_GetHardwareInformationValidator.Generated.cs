using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessPortal_GetHardwareInformationPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortal_GetHardwareInformationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortal_GetHardwareInformationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortal_GetHardwareInformationPDSA Entity
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
    /// Clones the current AccessPortal_GetHardwareInformationPDSA
    /// </summary>
    /// <returns>A cloned AccessPortal_GetHardwareInformationPDSA object</returns>
    public AccessPortal_GetHardwareInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortal_GetHardwareInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortal_GetHardwareInformationPDSA entity to clone</param>
    /// <returns>A cloned AccessPortal_GetHardwareInformationPDSA object</returns>
    public AccessPortal_GetHardwareInformationPDSA CloneEntity(AccessPortal_GetHardwareInformationPDSA entityToClone)
    {
      AccessPortal_GetHardwareInformationPDSA newEntity = new AccessPortal_GetHardwareInformationPDSA();

      newEntity.AccessPortalTypeUid = entityToClone.AccessPortalTypeUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.ClusterTypeUid = entityToClone.ClusterTypeUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.DoorNumber = entityToClone.DoorNumber;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.GalaxyHardwareModuleTypeUid = entityToClone.GalaxyHardwareModuleTypeUid;
      newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
      newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.GalaxyPanelTypeCode = entityToClone.GalaxyPanelTypeCode;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.InterfaceBoardModel = entityToClone.InterfaceBoardModel;
      newEntity.InterfaceBoardSectionModeCode = entityToClone.InterfaceBoardSectionModeCode;
      newEntity.InterfaceBoardSectionModeUid = entityToClone.InterfaceBoardSectionModeUid;
      newEntity.InterfaceBoardTypeCode = entityToClone.InterfaceBoardTypeCode;
      newEntity.InterfaceBoardTypeUid = entityToClone.InterfaceBoardTypeUid;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.IsNodeActive = entityToClone.IsNodeActive;
      newEntity.ModuleNumber = entityToClone.ModuleNumber;
      newEntity.ModuleTypeCode = entityToClone.ModuleTypeCode;
      newEntity.NodeNumber = entityToClone.NodeNumber;
      newEntity.PanelConnectedCount = entityToClone.PanelConnectedCount;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.PortalName = entityToClone.PortalName;
      newEntity.RegionUid = entityToClone.RegionUid;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.SiteName = entityToClone.SiteName;

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
      
      props.Add(PDSAProperty.Create(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortal_GetHardwareInformationPDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessPortal_GetHardwareInformationPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessPortal_GetHardwareInformationPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessPortal_GetHardwareInformationPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessPortal_GetHardwareInformationPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortal_GetHardwareInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "AccessPortalTypeUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'BoardNumber'
    /// </summary>
    public static string BoardNumber = "BoardNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterTypeCode'
    /// </summary>
    public static string ClusterTypeCode = "ClusterTypeCode";
    /// <summary>
    /// Returns 'ClusterTypeUid'
    /// </summary>
    public static string ClusterTypeUid = "ClusterTypeUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'DoorNumber'
    /// </summary>
    public static string DoorNumber = "DoorNumber";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'GalaxyHardwareModuleTypeUid'
    /// </summary>
    public static string GalaxyHardwareModuleTypeUid = "GalaxyHardwareModuleTypeUid";
    /// <summary>
    /// Returns 'GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
    /// <summary>
    /// Returns 'GalaxyPanelTypeCode'
    /// </summary>
    public static string GalaxyPanelTypeCode = "GalaxyPanelTypeCode";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'InterfaceBoardModel'
    /// </summary>
    public static string InterfaceBoardModel = "InterfaceBoardModel";
    /// <summary>
    /// Returns 'InterfaceBoardSectionModeCode'
    /// </summary>
    public static string InterfaceBoardSectionModeCode = "InterfaceBoardSectionModeCode";
    /// <summary>
    /// Returns 'InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns 'InterfaceBoardTypeCode'
    /// </summary>
    public static string InterfaceBoardTypeCode = "InterfaceBoardTypeCode";
    /// <summary>
    /// Returns 'InterfaceBoardTypeUid'
    /// </summary>
    public static string InterfaceBoardTypeUid = "InterfaceBoardTypeUid";
    /// <summary>
    /// Returns 'IsEnabled'
    /// </summary>
    public static string IsEnabled = "IsEnabled";
    /// <summary>
    /// Returns 'IsNodeActive'
    /// </summary>
    public static string IsNodeActive = "IsNodeActive";
    /// <summary>
    /// Returns 'ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "ModuleNumber";
    /// <summary>
    /// Returns 'ModuleTypeCode'
    /// </summary>
    public static string ModuleTypeCode = "ModuleTypeCode";
    /// <summary>
    /// Returns 'NodeNumber'
    /// </summary>
    public static string NodeNumber = "NodeNumber";
    /// <summary>
    /// Returns 'PanelConnectedCount'
    /// </summary>
    public static string PanelConnectedCount = "PanelConnectedCount";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'PortalName'
    /// </summary>
    public static string PortalName = "PortalName";
    /// <summary>
    /// Returns 'RegionUid'
    /// </summary>
    public static string RegionUid = "RegionUid";
    /// <summary>
    /// Returns 'SectionNumber'
    /// </summary>
    public static string SectionNumber = "SectionNumber";
    /// <summary>
    /// Returns 'SiteName'
    /// </summary>
    public static string SiteName = "SiteName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortal_GetHardwareInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
