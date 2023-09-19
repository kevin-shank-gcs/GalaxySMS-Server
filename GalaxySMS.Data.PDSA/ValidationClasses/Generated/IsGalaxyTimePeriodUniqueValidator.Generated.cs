using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyTimePeriodUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyTimePeriodUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyTimePeriodUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyTimePeriodUniquePDSA Entity
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
    /// Clones the current IsGalaxyTimePeriodUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyTimePeriodUniquePDSA object</returns>
    public IsGalaxyTimePeriodUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyTimePeriodUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyTimePeriodUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyTimePeriodUniquePDSA object</returns>
    public IsGalaxyTimePeriodUniquePDSA CloneEntity(IsGalaxyTimePeriodUniquePDSA entityToClone)
    {
      IsGalaxyTimePeriodUniquePDSA newEntity = new IsGalaxyTimePeriodUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_GalaxyTimePeriodUid_Header", "Galaxy Time Period Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_GalaxyTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.PanelTimePeriodNumber, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_PanelTimePeriodNumber_Header", "Panel Time Period Number"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_PanelTimePeriodNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyTimePeriodUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid).Value = Entity.GalaxyTimePeriodUid;
      this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.PanelTimePeriodNumber).Value = Entity.PanelTimePeriodNumber;
      this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid).IsNull == false)
        Entity.GalaxyTimePeriodUid = this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.GalaxyTimePeriodUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Display).GetAsString();
      if(this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.PanelTimePeriodNumber).IsNull == false)
        Entity.PanelTimePeriodNumber = this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.PanelTimePeriodNumber).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyTimePeriodUniquePDSA class.
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
    /// Returns '@GalaxyTimePeriodUid'
    /// </summary>
    public static string GalaxyTimePeriodUid = "@GalaxyTimePeriodUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@PanelTimePeriodNumber'
    /// </summary>
    public static string PanelTimePeriodNumber = "@PanelTimePeriodNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyTimePeriodUniquePDSA class.
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
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@PanelTimePeriodNumber'
    /// </summary>
    public static string PanelTimePeriodNumber = "@PanelTimePeriodNumber";
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
