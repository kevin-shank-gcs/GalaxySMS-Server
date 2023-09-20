using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA Entity
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
    /// Clones the current GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA
    /// </summary>
    /// <returns>A cloned GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA object</returns>
    public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA entity to clone</param>
    /// <returns>A cloned GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA object</returns>
    public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA CloneEntity(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA entityToClone)
    {
      GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA newEntity = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA();

      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.InterfaceBoardSectionModeUid = entityToClone.InterfaceBoardSectionModeUid;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.IsSectionActive = entityToClone.IsSectionActive;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.BoardSectionMode = entityToClone.BoardSectionMode;
      newEntity.BoardSectionModeDisplay = entityToClone.BoardSectionModeDisplay;
      newEntity.PanelModelTypeCode = entityToClone.PanelModelTypeCode;
      newEntity.CpuTypeCode = entityToClone.CpuTypeCode;
      newEntity.BoardTypeModel = entityToClone.BoardTypeModel;
      newEntity.BoardTypeTypeCode = entityToClone.BoardTypeTypeCode;
      newEntity.BoardTypeDisplay = entityToClone.BoardTypeDisplay;
      newEntity.EntityId = entityToClone.EntityId;

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
      
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA_GalaxyInterfaceBoardUid_Header", "Galaxy Interface Board Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA_GalaxyInterfaceBoardUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).Value = Entity.GalaxyInterfaceBoardUid;
      this.Properties.GetByName(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).IsNull == false)
        Entity.GalaxyInterfaceBoardUid = this.Properties.GetByName(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns 'InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns 'SectionNumber'
    /// </summary>
    public static string SectionNumber = "SectionNumber";
    /// <summary>
    /// Returns 'IsSectionActive'
    /// </summary>
    public static string IsSectionActive = "IsSectionActive";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
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
    /// Returns 'BoardSectionMode'
    /// </summary>
    public static string BoardSectionMode = "BoardSectionMode";
    /// <summary>
    /// Returns 'BoardSectionModeDisplay'
    /// </summary>
    public static string BoardSectionModeDisplay = "BoardSectionModeDisplay";
    /// <summary>
    /// Returns 'PanelModelTypeCode'
    /// </summary>
    public static string PanelModelTypeCode = "PanelModelTypeCode";
    /// <summary>
    /// Returns 'CpuTypeCode'
    /// </summary>
    public static string CpuTypeCode = "CpuTypeCode";
    /// <summary>
    /// Returns 'BoardTypeModel'
    /// </summary>
    public static string BoardTypeModel = "BoardTypeModel";
    /// <summary>
    /// Returns 'BoardTypeTypeCode'
    /// </summary>
    public static string BoardTypeTypeCode = "BoardTypeTypeCode";
    /// <summary>
    /// Returns 'BoardTypeDisplay'
    /// </summary>
    public static string BoardTypeDisplay = "BoardTypeDisplay";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "@GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
