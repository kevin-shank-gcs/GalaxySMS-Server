using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyTimePeriod_GetPanelLoadDataPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyTimePeriod_GetPanelLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyTimePeriod_GetPanelLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyTimePeriod_GetPanelLoadDataPDSA Entity
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
    /// Clones the current GalaxyTimePeriod_GetPanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned GalaxyTimePeriod_GetPanelLoadDataPDSA object</returns>
    public GalaxyTimePeriod_GetPanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyTimePeriod_GetPanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyTimePeriod_GetPanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned GalaxyTimePeriod_GetPanelLoadDataPDSA object</returns>
    public GalaxyTimePeriod_GetPanelLoadDataPDSA CloneEntity(GalaxyTimePeriod_GetPanelLoadDataPDSA entityToClone)
    {
      GalaxyTimePeriod_GetPanelLoadDataPDSA newEntity = new GalaxyTimePeriod_GetPanelLoadDataPDSA();

      newEntity.GalaxyTimePeriodUid = entityToClone.GalaxyTimePeriodUid;
      newEntity.TimePeriodName = entityToClone.TimePeriodName;
      newEntity.PanelTimePeriodNumber = entityToClone.PanelTimePeriodNumber;
      newEntity.StartTime = entityToClone.StartTime;
      newEntity.EndTime = entityToClone.EndTime;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ScheduleTypeCode = entityToClone.ScheduleTypeCode;
      newEntity.ScheduleTypeDisplay = entityToClone.ScheduleTypeDisplay;

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
      
      props.Add(PDSAProperty.Create(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.GalaxyTimePeriodUid, GetResourceMessage("GCS_GalaxyTimePeriod_GetPanelLoadDataPDSA_GalaxyTimePeriodUid_Header", "Galaxy Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyTimePeriod_GetPanelLoadDataPDSA_GalaxyTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_GalaxyTimePeriod_GetPanelLoadDataPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyTimePeriod_GetPanelLoadDataPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyTimePeriod_GetPanelLoadDataPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyTimePeriod_GetPanelLoadDataPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.GalaxyTimePeriodUid).Value = Entity.GalaxyTimePeriodUid;
      this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.GalaxyTimePeriodUid).IsNull == false)
        Entity.GalaxyTimePeriodUid = this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.GalaxyTimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyTimePeriod_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyTimePeriod_GetPanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyTimePeriodUid'
    /// </summary>
    public static string GalaxyTimePeriodUid = "GalaxyTimePeriodUid";
    /// <summary>
    /// Returns 'TimePeriodName'
    /// </summary>
    public static string TimePeriodName = "TimePeriodName";
    /// <summary>
    /// Returns 'PanelTimePeriodNumber'
    /// </summary>
    public static string PanelTimePeriodNumber = "PanelTimePeriodNumber";
    /// <summary>
    /// Returns 'StartTime'
    /// </summary>
    public static string StartTime = "StartTime";
    /// <summary>
    /// Returns 'EndTime'
    /// </summary>
    public static string EndTime = "EndTime";
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
    /// Returns 'ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "ScheduleTypeCode";
    /// <summary>
    /// Returns 'ScheduleTypeDisplay'
    /// </summary>
    public static string ScheduleTypeDisplay = "ScheduleTypeDisplay";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyTimePeriod_GetPanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyTimePeriodUid'
    /// </summary>
    public static string GalaxyTimePeriodUid = "@GalaxyTimePeriodUid";
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
