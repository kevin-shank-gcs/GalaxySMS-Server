using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA Entity
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
    /// Clones the current GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA
    /// </summary>
    /// <returns>A cloned GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA object</returns>
    public GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA entity to clone</param>
    /// <returns>A cloned GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA object</returns>
    public GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA CloneEntity(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA entityToClone)
    {
      GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA newEntity = new GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA();

      newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;

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
      
      props.Add(PDSAProperty.Create(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "PanelScheduleNumber";
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

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyClusterTimeScheduleMap_SelectAvailableTimeScheduleNumberPDSA class.
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
