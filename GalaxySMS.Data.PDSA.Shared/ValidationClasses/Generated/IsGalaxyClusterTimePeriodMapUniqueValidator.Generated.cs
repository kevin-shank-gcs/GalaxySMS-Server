using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyClusterTimePeriodMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyClusterTimePeriodMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyClusterTimePeriodMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyClusterTimePeriodMapUniquePDSA Entity
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
    /// Clones the current IsGalaxyClusterTimePeriodMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyClusterTimePeriodMapUniquePDSA object</returns>
    public IsGalaxyClusterTimePeriodMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyClusterTimePeriodMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyClusterTimePeriodMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyClusterTimePeriodMapUniquePDSA object</returns>
    public IsGalaxyClusterTimePeriodMapUniquePDSA CloneEntity(IsGalaxyClusterTimePeriodMapUniquePDSA entityToClone)
    {
      IsGalaxyClusterTimePeriodMapUniquePDSA newEntity = new IsGalaxyClusterTimePeriodMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_GalaxyClusterTimePeriodMapUid_Header", "Galaxy Cluster Time Period Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_GalaxyClusterTimePeriodMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_TimePeriodUid_Header", "Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_PanelPeriodNumber_Header", "Panel Period Number"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_PanelPeriodNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid).Value = Entity.GalaxyClusterTimePeriodMapUid;
      this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber).Value = Entity.PanelPeriodNumber;
      this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid).IsNull == false)
        Entity.GalaxyClusterTimePeriodMapUid = this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber).IsNull == false)
        Entity.PanelPeriodNumber = this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterTimePeriodMapUniquePDSA class.
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
    /// Returns '@GalaxyClusterTimePeriodMapUid'
    /// </summary>
    public static string GalaxyClusterTimePeriodMapUid = "@GalaxyClusterTimePeriodMapUid";
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelPeriodNumber'
    /// </summary>
    public static string PanelPeriodNumber = "@PanelPeriodNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterTimePeriodMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyClusterTimePeriodMapUid'
    /// </summary>
    public static string GalaxyClusterTimePeriodMapUid = "@GalaxyClusterTimePeriodMapUid";
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelPeriodNumber'
    /// </summary>
    public static string PanelPeriodNumber = "@PanelPeriodNumber";
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
