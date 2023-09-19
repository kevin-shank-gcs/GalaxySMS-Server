using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetTimeScheduleAndClusterNamesPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetTimeScheduleAndClusterNamesPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetTimeScheduleAndClusterNamesPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetTimeScheduleAndClusterNamesPDSA Entity
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
    /// Clones the current GetTimeScheduleAndClusterNamesPDSA
    /// </summary>
    /// <returns>A cloned GetTimeScheduleAndClusterNamesPDSA object</returns>
    public GetTimeScheduleAndClusterNamesPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetTimeScheduleAndClusterNamesPDSA
    /// </summary>
    /// <param name="entityToClone">The GetTimeScheduleAndClusterNamesPDSA entity to clone</param>
    /// <returns>A cloned GetTimeScheduleAndClusterNamesPDSA object</returns>
    public GetTimeScheduleAndClusterNamesPDSA CloneEntity(GetTimeScheduleAndClusterNamesPDSA entityToClone)
    {
      GetTimeScheduleAndClusterNamesPDSA newEntity = new GetTimeScheduleAndClusterNamesPDSA();

      newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
      newEntity.ClusterName = entityToClone.ClusterName;

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
      
      props.Add(PDSAProperty.Create(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.timeScheduleUid, GetResourceMessage("GCS_GetTimeScheduleAndClusterNamesPDSA_timeScheduleUid_Header", "time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetTimeScheduleAndClusterNamesPDSA_timeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.clusterUid, GetResourceMessage("GCS_GetTimeScheduleAndClusterNamesPDSA_clusterUid_Header", "cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetTimeScheduleAndClusterNamesPDSA_clusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetTimeScheduleAndClusterNamesPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetTimeScheduleAndClusterNamesPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.timeScheduleUid).Value = Entity.timeScheduleUid;
      this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.clusterUid).Value = Entity.clusterUid;
      this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.timeScheduleUid).IsNull == false)
        Entity.timeScheduleUid = this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.timeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.clusterUid).IsNull == false)
        Entity.clusterUid = this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.clusterUid).GetAsGuid();
      if(this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetTimeScheduleAndClusterNamesPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetTimeScheduleAndClusterNamesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'TimeScheduleName'
    /// </summary>
    public static string TimeScheduleName = "TimeScheduleName";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
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
    /// Contains static string properties that represent the name of each property in the GetTimeScheduleAndClusterNamesPDSA class.
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
