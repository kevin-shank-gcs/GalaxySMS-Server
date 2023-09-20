using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyClusterTimeScheduleMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyClusterTimeScheduleMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyClusterTimeScheduleMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyClusterTimeScheduleMapUniquePDSA Entity
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
    /// Clones the current IsGalaxyClusterTimeScheduleMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyClusterTimeScheduleMapUniquePDSA object</returns>
    public IsGalaxyClusterTimeScheduleMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyClusterTimeScheduleMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyClusterTimeScheduleMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyClusterTimeScheduleMapUniquePDSA object</returns>
    public IsGalaxyClusterTimeScheduleMapUniquePDSA CloneEntity(IsGalaxyClusterTimeScheduleMapUniquePDSA entityToClone)
    {
      IsGalaxyClusterTimeScheduleMapUniquePDSA newEntity = new IsGalaxyClusterTimeScheduleMapUniquePDSA();

      newEntity.Result = entityToClone.Result;

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
      
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_GalaxyClusterTimeScheduleMapUid_Header", "Galaxy Cluster Time Schedule Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_GalaxyClusterTimeScheduleMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_PanelScheduleNumber_Header", "Panel Schedule Number"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_PanelScheduleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid).Value = Entity.GalaxyClusterTimeScheduleMapUid;
      this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber).Value = Entity.PanelScheduleNumber;
      this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid).IsNull == false)
        Entity.GalaxyClusterTimeScheduleMapUid = this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber).IsNull == false)
        Entity.PanelScheduleNumber = this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterTimeScheduleMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@GalaxyClusterTimeScheduleMapUid'
    /// </summary>
    public static string GalaxyClusterTimeScheduleMapUid = "@GalaxyClusterTimeScheduleMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "@PanelScheduleNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterTimeScheduleMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyClusterTimeScheduleMapUid'
    /// </summary>
    public static string GalaxyClusterTimeScheduleMapUid = "@GalaxyClusterTimeScheduleMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "@PanelScheduleNumber";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
