using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA Entity
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
    /// Clones the current GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA object</returns>
    public GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA object</returns>
    public GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA CloneEntity(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA entityToClone)
    {
      GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA newEntity = new GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA();

      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.Tag = entityToClone.Tag;
      newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
      newEntity.OffsetIndex = entityToClone.OffsetIndex;

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
      
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      this.Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = this.Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'IOGroupNumber'
    /// </summary>
    public static string IOGroupNumber = "IOGroupNumber";
    /// <summary>
    /// Returns 'OffsetIndex'
    /// </summary>
    public static string OffsetIndex = "OffsetIndex";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
