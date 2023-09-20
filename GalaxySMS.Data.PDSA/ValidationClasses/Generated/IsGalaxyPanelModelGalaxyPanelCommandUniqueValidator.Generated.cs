using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA Entity
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
    /// Clones the current IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA object</returns>
    public IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA object</returns>
    public IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA CloneEntity(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA entityToClone)
    {
      IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA newEntity = new IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelGalaxyPanelCommandUid, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_GalaxyPanelModelGalaxyPanelCommandUid_Header", "Galaxy Panel Model Galaxy Panel Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_GalaxyPanelModelGalaxyPanelCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelCommandUid, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_GalaxyPanelCommandUid_Header", "Galaxy Panel Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_GalaxyPanelCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelGalaxyPanelCommandUid).Value = Entity.GalaxyPanelModelGalaxyPanelCommandUid;
      this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelCommandUid).Value = Entity.GalaxyPanelCommandUid;
      this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelGalaxyPanelCommandUid).IsNull == false)
        Entity.GalaxyPanelModelGalaxyPanelCommandUid = this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelGalaxyPanelCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelCommandUid).IsNull == false)
        Entity.GalaxyPanelCommandUid = this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyPanelModelGalaxyPanelCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA class.
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
    /// Returns '@GalaxyPanelModelGalaxyPanelCommandUid'
    /// </summary>
    public static string GalaxyPanelModelGalaxyPanelCommandUid = "@GalaxyPanelModelGalaxyPanelCommandUid";
    /// <summary>
    /// Returns '@GalaxyPanelCommandUid'
    /// </summary>
    public static string GalaxyPanelCommandUid = "@GalaxyPanelCommandUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelModelGalaxyPanelCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelModelGalaxyPanelCommandUid'
    /// </summary>
    public static string GalaxyPanelModelGalaxyPanelCommandUid = "@GalaxyPanelModelGalaxyPanelCommandUid";
    /// <summary>
    /// Returns '@GalaxyPanelCommandUid'
    /// </summary>
    public static string GalaxyPanelCommandUid = "@GalaxyPanelCommandUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
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
