using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the TimeSchedule_SelectionListForEntityAndClusterPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class TimeSchedule_SelectionListForEntityAndClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private TimeSchedule_SelectionListForEntityAndClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new TimeSchedule_SelectionListForEntityAndClusterPDSA Entity
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
    /// Clones the current TimeSchedule_SelectionListForEntityAndClusterPDSA
    /// </summary>
    /// <returns>A cloned TimeSchedule_SelectionListForEntityAndClusterPDSA object</returns>
    public TimeSchedule_SelectionListForEntityAndClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in TimeSchedule_SelectionListForEntityAndClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The TimeSchedule_SelectionListForEntityAndClusterPDSA entity to clone</param>
    /// <returns>A cloned TimeSchedule_SelectionListForEntityAndClusterPDSA object</returns>
    public TimeSchedule_SelectionListForEntityAndClusterPDSA CloneEntity(TimeSchedule_SelectionListForEntityAndClusterPDSA entityToClone)
    {
      TimeSchedule_SelectionListForEntityAndClusterPDSA newEntity = new TimeSchedule_SelectionListForEntityAndClusterPDSA();

      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
      newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
      newEntity.Description = entityToClone.Description;

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
      
      props.Add(PDSAProperty.Create(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.GalaxyClusterUid, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_GalaxyClusterUid_Header", "Galaxy Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_GalaxyClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.CultureName, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 8000, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_TimeSchedule_SelectionListForEntityAndClusterPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.GalaxyClusterUid).Value = Entity.GalaxyClusterUid;
      this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.CultureName).Value = Entity.CultureName;
      this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.GalaxyClusterUid).IsNull == false)
        Entity.GalaxyClusterUid = this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.GalaxyClusterUid).GetAsGuid();
      if(this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.CultureName).IsNull == false)
        Entity.CultureName = this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.CultureName).GetAsString();
      if(this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(TimeSchedule_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_SelectionListForEntityAndClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "PanelScheduleNumber";
    /// <summary>
    /// Returns 'TimeScheduleName'
    /// </summary>
    public static string TimeScheduleName = "TimeScheduleName";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns '@GalaxyClusterUid'
    /// </summary>
    public static string GalaxyClusterUid = "@GalaxyClusterUid";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the TimeSchedule_SelectionListForEntityAndClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@GalaxyClusterUid'
    /// </summary>
    public static string GalaxyClusterUid = "@GalaxyClusterUid";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
