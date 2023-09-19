using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA Entity
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
    /// Clones the current IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA object</returns>
    public IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA object</returns>
    public IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA CloneEntity(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA entityToClone)
    {
      IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA newEntity = new IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.GalaxyPanelAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA_GalaxyPanelAlarmEventAcknowledgmentUid_Header", "Galaxy Panel Alarm Event Acknowledgment Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA_GalaxyPanelAlarmEventAcknowledgmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.GalaxyPanelAlarmEventAcknowledgmentUid).Value = Entity.GalaxyPanelAlarmEventAcknowledgmentUid;
      this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.GalaxyPanelAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.GalaxyPanelAlarmEventAcknowledgmentUid = this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.GalaxyPanelAlarmEventAcknowledgmentUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA class.
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
    /// Returns '@GalaxyPanelAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string GalaxyPanelAlarmEventAcknowledgmentUid = "@GalaxyPanelAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelAlarmEventAcknowledgmentUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string GalaxyPanelAlarmEventAcknowledgmentUid = "@GalaxyPanelAlarmEventAcknowledgmentUid";
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
