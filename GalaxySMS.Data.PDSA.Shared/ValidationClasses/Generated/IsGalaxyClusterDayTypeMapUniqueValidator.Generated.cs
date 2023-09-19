using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyClusterDayTypeMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyClusterDayTypeMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyClusterDayTypeMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyClusterDayTypeMapUniquePDSA Entity
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
    /// Clones the current IsGalaxyClusterDayTypeMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyClusterDayTypeMapUniquePDSA object</returns>
    public IsGalaxyClusterDayTypeMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyClusterDayTypeMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyClusterDayTypeMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyClusterDayTypeMapUniquePDSA object</returns>
    public IsGalaxyClusterDayTypeMapUniquePDSA CloneEntity(IsGalaxyClusterDayTypeMapUniquePDSA entityToClone)
    {
      IsGalaxyClusterDayTypeMapUniquePDSA newEntity = new IsGalaxyClusterDayTypeMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.GalaxyClusterDayTypeMapUid, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_GalaxyClusterDayTypeMapUid_Header", "Galaxy Cluster Day Type Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_GalaxyClusterDayTypeMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.DayTypeUid, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_DayTypeUid_Header", "Day Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_DayTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.PanelDayTypeNumber, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_PanelDayTypeNumber_Header", "Panel Day Type Number"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_PanelDayTypeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterDayTypeMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.GalaxyClusterDayTypeMapUid).Value = Entity.GalaxyClusterDayTypeMapUid;
      this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.DayTypeUid).Value = Entity.DayTypeUid;
      this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.PanelDayTypeNumber).Value = Entity.PanelDayTypeNumber;
      this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.GalaxyClusterDayTypeMapUid).IsNull == false)
        Entity.GalaxyClusterDayTypeMapUid = this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.GalaxyClusterDayTypeMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.DayTypeUid).IsNull == false)
        Entity.DayTypeUid = this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.DayTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.PanelDayTypeNumber).IsNull == false)
        Entity.PanelDayTypeNumber = this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.PanelDayTypeNumber).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyClusterDayTypeMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterDayTypeMapUniquePDSA class.
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
    /// Returns '@GalaxyClusterDayTypeMapUid'
    /// </summary>
    public static string GalaxyClusterDayTypeMapUid = "@GalaxyClusterDayTypeMapUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelDayTypeNumber'
    /// </summary>
    public static string PanelDayTypeNumber = "@PanelDayTypeNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterDayTypeMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyClusterDayTypeMapUid'
    /// </summary>
    public static string GalaxyClusterDayTypeMapUid = "@GalaxyClusterDayTypeMapUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelDayTypeNumber'
    /// </summary>
    public static string PanelDayTypeNumber = "@PanelDayTypeNumber";
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
