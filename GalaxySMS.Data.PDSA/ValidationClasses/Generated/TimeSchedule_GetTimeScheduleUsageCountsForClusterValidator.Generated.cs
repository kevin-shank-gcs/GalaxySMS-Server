using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA Entity
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
    /// Clones the current TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA
    /// </summary>
    /// <returns>A cloned TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA object</returns>
    public TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA entity to clone</param>
    /// <returns>A cloned TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA object</returns>
    public TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA CloneEntity(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA entityToClone)
    {
      TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA newEntity = new TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
      newEntity.AccessGroupDefaultTimeScheduleCount = entityToClone.AccessGroupDefaultTimeScheduleCount;
      newEntity.AccessGroupAccessPortalCount = entityToClone.AccessGroupAccessPortalCount;
      newEntity.AccessPortalAlertEventCount = entityToClone.AccessPortalAlertEventCount;
      newEntity.AccessPortalAuxOutputCount = entityToClone.AccessPortalAuxOutputCount;
      newEntity.AccessPortalTimeScheduleCount = entityToClone.AccessPortalTimeScheduleCount;
      newEntity.InputDeviceTimeScheduleCount = entityToClone.InputDeviceTimeScheduleCount;
      newEntity.OutputDeviceTimeScheduleCount = entityToClone.OutputDeviceTimeScheduleCount;
      newEntity.GalaxyPanelAlertEventTimeScheduleCount = entityToClone.GalaxyPanelAlertEventTimeScheduleCount;
      newEntity.InputDeviceEventPropertiesTimeScheduleCount = entityToClone.InputDeviceEventPropertiesTimeScheduleCount;
      newEntity.InputOutputGroupTimeScheduleCount = entityToClone.InputOutputGroupTimeScheduleCount;
      newEntity.PersonPersonalAccessGroupTimeScheduleCount = entityToClone.PersonPersonalAccessGroupTimeScheduleCount;
      newEntity.AssaDsrTimeScheduleCount = entityToClone.AssaDsrTimeScheduleCount;
      newEntity.OtisFloorGroupTimeScheduleCount = entityToClone.OtisFloorGroupTimeScheduleCount;
      newEntity.TotalCount = entityToClone.TotalCount;

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
      
      props.Add(PDSAProperty.Create(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.timeScheduleUid, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA_timeScheduleUid_Header", "time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA_timeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.clusterUid, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA_clusterUid_Header", "cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA_clusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.timeScheduleUid).Value = Entity.timeScheduleUid;
      this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.clusterUid).Value = Entity.clusterUid;
      this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.timeScheduleUid).IsNull == false)
        Entity.timeScheduleUid = this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.timeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.clusterUid).IsNull == false)
        Entity.clusterUid = this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.clusterUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA class.
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
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'TimeScheduleName'
    /// </summary>
    public static string TimeScheduleName = "TimeScheduleName";
    /// <summary>
    /// Returns 'AccessGroupDefaultTimeScheduleCount'
    /// </summary>
    public static string AccessGroupDefaultTimeScheduleCount = "AccessGroupDefaultTimeScheduleCount";
    /// <summary>
    /// Returns 'AccessGroupAccessPortalCount'
    /// </summary>
    public static string AccessGroupAccessPortalCount = "AccessGroupAccessPortalCount";
    /// <summary>
    /// Returns 'AccessPortalAlertEventCount'
    /// </summary>
    public static string AccessPortalAlertEventCount = "AccessPortalAlertEventCount";
    /// <summary>
    /// Returns 'AccessPortalAuxOutputCount'
    /// </summary>
    public static string AccessPortalAuxOutputCount = "AccessPortalAuxOutputCount";
    /// <summary>
    /// Returns 'AccessPortalTimeScheduleCount'
    /// </summary>
    public static string AccessPortalTimeScheduleCount = "AccessPortalTimeScheduleCount";
    /// <summary>
    /// Returns 'InputDeviceTimeScheduleCount'
    /// </summary>
    public static string InputDeviceTimeScheduleCount = "InputDeviceTimeScheduleCount";
    /// <summary>
    /// Returns 'OutputDeviceTimeScheduleCount'
    /// </summary>
    public static string OutputDeviceTimeScheduleCount = "OutputDeviceTimeScheduleCount";
    /// <summary>
    /// Returns 'GalaxyPanelAlertEventTimeScheduleCount'
    /// </summary>
    public static string GalaxyPanelAlertEventTimeScheduleCount = "GalaxyPanelAlertEventTimeScheduleCount";
    /// <summary>
    /// Returns 'InputDeviceEventPropertiesTimeScheduleCount'
    /// </summary>
    public static string InputDeviceEventPropertiesTimeScheduleCount = "InputDeviceEventPropertiesTimeScheduleCount";
    /// <summary>
    /// Returns 'InputOutputGroupTimeScheduleCount'
    /// </summary>
    public static string InputOutputGroupTimeScheduleCount = "InputOutputGroupTimeScheduleCount";
    /// <summary>
    /// Returns 'PersonPersonalAccessGroupTimeScheduleCount'
    /// </summary>
    public static string PersonPersonalAccessGroupTimeScheduleCount = "PersonPersonalAccessGroupTimeScheduleCount";
    /// <summary>
    /// Returns 'AssaDsrTimeScheduleCount'
    /// </summary>
    public static string AssaDsrTimeScheduleCount = "AssaDsrTimeScheduleCount";
    /// <summary>
    /// Returns 'OtisFloorGroupTimeScheduleCount'
    /// </summary>
    public static string OtisFloorGroupTimeScheduleCount = "OtisFloorGroupTimeScheduleCount";
    /// <summary>
    /// Returns 'TotalCount'
    /// </summary>
    public static string TotalCount = "TotalCount";
    /// <summary>
    /// Returns '@timeScheduleUid'
    /// </summary>
    public static string timeScheduleUid = "@timeScheduleUid";
    /// <summary>
    /// Returns '@clusterUid'
    /// </summary>
    public static string clusterUid = "@clusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@timeScheduleUid'
    /// </summary>
    public static string timeScheduleUid = "@timeScheduleUid";
    /// <summary>
    /// Returns '@clusterUid'
    /// </summary>
    public static string clusterUid = "@clusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
