using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyPanelActivityAlarmEventUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyPanelActivityAlarmEventUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyPanelActivityAlarmEventUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyPanelActivityAlarmEventUniquePDSA Entity
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
    /// Clones the current IsGalaxyPanelActivityAlarmEventUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyPanelActivityAlarmEventUniquePDSA object</returns>
    public IsGalaxyPanelActivityAlarmEventUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyPanelActivityAlarmEventUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyPanelActivityAlarmEventUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyPanelActivityAlarmEventUniquePDSA object</returns>
    public IsGalaxyPanelActivityAlarmEventUniquePDSA CloneEntity(IsGalaxyPanelActivityAlarmEventUniquePDSA entityToClone)
    {
      IsGalaxyPanelActivityAlarmEventUniquePDSA newEntity = new IsGalaxyPanelActivityAlarmEventUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.GalaxyPanelActivityEventUid, GetResourceMessage("GCS_IsGalaxyPanelActivityAlarmEventUniquePDSA_GalaxyPanelActivityEventUid_Header", "Galaxy Panel Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelActivityAlarmEventUniquePDSA_GalaxyPanelActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyPanelActivityAlarmEventUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelActivityAlarmEventUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyPanelActivityAlarmEventUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelActivityAlarmEventUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.GalaxyPanelActivityEventUid).Value = Entity.GalaxyPanelActivityEventUid;
      this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.GalaxyPanelActivityEventUid).IsNull == false)
        Entity.GalaxyPanelActivityEventUid = this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.GalaxyPanelActivityEventUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyPanelActivityAlarmEventUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelActivityAlarmEventUniquePDSA class.
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
    /// Returns '@GalaxyPanelActivityEventUid'
    /// </summary>
    public static string GalaxyPanelActivityEventUid = "@GalaxyPanelActivityEventUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelActivityAlarmEventUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelActivityEventUid'
    /// </summary>
    public static string GalaxyPanelActivityEventUid = "@GalaxyPanelActivityEventUid";
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
