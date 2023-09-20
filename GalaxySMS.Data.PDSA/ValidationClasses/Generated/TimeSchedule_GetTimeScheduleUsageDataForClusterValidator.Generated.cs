using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA Entity
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
    /// Clones the current TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA
    /// </summary>
    /// <returns>A cloned TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA object</returns>
    public TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA entity to clone</param>
    /// <returns>A cloned TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA object</returns>
    public TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA CloneEntity(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA entityToClone)
    {
      TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA newEntity = new TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA();

      newEntity.DataType = entityToClone.DataType;
      newEntity.Id = entityToClone.Id;
      newEntity.Name = entityToClone.Name;
      newEntity.DeviceUid = entityToClone.DeviceUid;
      newEntity.DeviceName = entityToClone.DeviceName;
      newEntity.Type_x = entityToClone.Type_x;

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
      
      props.Add(PDSAProperty.Create(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.timeScheduleUid, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA_timeScheduleUid_Header", "time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA_timeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.clusterUid, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA_clusterUid_Header", "cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA_clusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.timeScheduleUid).Value = Entity.timeScheduleUid;
      this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.clusterUid).Value = Entity.clusterUid;
      this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.timeScheduleUid).IsNull == false)
        Entity.timeScheduleUid = this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.timeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.clusterUid).IsNull == false)
        Entity.clusterUid = this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.clusterUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DataType'
    /// </summary>
    public static string DataType = "DataType";
    /// <summary>
    /// Returns 'Id'
    /// </summary>
    public static string Id = "Id";
    /// <summary>
    /// Returns 'Name'
    /// </summary>
    public static string Name = "Name";
    /// <summary>
    /// Returns 'DeviceUid'
    /// </summary>
    public static string DeviceUid = "DeviceUid";
    /// <summary>
    /// Returns 'DeviceName'
    /// </summary>
    public static string DeviceName = "DeviceName";
    /// <summary>
    /// Returns 'Type'
    /// </summary>
    public static string Type_x = "Type";
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
    /// Contains static string properties that represent the name of each property in the TimeSchedule_GetTimeScheduleUsageDataForClusterPDSA class.
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
