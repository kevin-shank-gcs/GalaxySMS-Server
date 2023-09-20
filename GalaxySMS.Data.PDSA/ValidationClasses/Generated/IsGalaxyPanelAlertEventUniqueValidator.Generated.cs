using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyPanelAlertEventUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyPanelAlertEventUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyPanelAlertEventUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyPanelAlertEventUniquePDSA Entity
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
    /// Clones the current IsGalaxyPanelAlertEventUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyPanelAlertEventUniquePDSA object</returns>
    public IsGalaxyPanelAlertEventUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyPanelAlertEventUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyPanelAlertEventUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyPanelAlertEventUniquePDSA object</returns>
    public IsGalaxyPanelAlertEventUniquePDSA CloneEntity(IsGalaxyPanelAlertEventUniquePDSA entityToClone)
    {
      IsGalaxyPanelAlertEventUniquePDSA newEntity = new IsGalaxyPanelAlertEventUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventUid, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_GalaxyPanelAlertEventUid_Header", "Galaxy Panel Alert Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_GalaxyPanelAlertEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventTypeUid, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_GalaxyPanelAlertEventTypeUid_Header", "Galaxy Panel Alert Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_GalaxyPanelAlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelAlertEventUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventUid).Value = Entity.GalaxyPanelAlertEventUid;
      this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventTypeUid).Value = Entity.GalaxyPanelAlertEventTypeUid;
      this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventUid).IsNull == false)
        Entity.GalaxyPanelAlertEventUid = this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventTypeUid).IsNull == false)
        Entity.GalaxyPanelAlertEventTypeUid = this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.GalaxyPanelAlertEventTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyPanelAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelAlertEventUniquePDSA class.
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
    /// Returns '@GalaxyPanelAlertEventUid'
    /// </summary>
    public static string GalaxyPanelAlertEventUid = "@GalaxyPanelAlertEventUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@GalaxyPanelAlertEventTypeUid'
    /// </summary>
    public static string GalaxyPanelAlertEventTypeUid = "@GalaxyPanelAlertEventTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelAlertEventUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelAlertEventUid'
    /// </summary>
    public static string GalaxyPanelAlertEventUid = "@GalaxyPanelAlertEventUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@GalaxyPanelAlertEventTypeUid'
    /// </summary>
    public static string GalaxyPanelAlertEventTypeUid = "@GalaxyPanelAlertEventTypeUid";
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
