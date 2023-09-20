using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputCommandGalaxyPanelModelUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputCommandGalaxyPanelModelUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputCommandGalaxyPanelModelUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputCommandGalaxyPanelModelUniquePDSA Entity
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
    /// Clones the current IsInputCommandGalaxyPanelModelUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputCommandGalaxyPanelModelUniquePDSA object</returns>
    public IsInputCommandGalaxyPanelModelUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputCommandGalaxyPanelModelUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputCommandGalaxyPanelModelUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputCommandGalaxyPanelModelUniquePDSA object</returns>
    public IsInputCommandGalaxyPanelModelUniquePDSA CloneEntity(IsInputCommandGalaxyPanelModelUniquePDSA entityToClone)
    {
      IsInputCommandGalaxyPanelModelUniquePDSA newEntity = new IsInputCommandGalaxyPanelModelUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandGalaxyPanelModelUid, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_InputCommandGalaxyPanelModelUid_Header", "Input Command Galaxy Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_InputCommandGalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandUid, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_InputCommandUid_Header", "Input Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_InputCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputCommandGalaxyPanelModelUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandGalaxyPanelModelUid).Value = Entity.InputCommandGalaxyPanelModelUid;
      this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandUid).Value = Entity.InputCommandUid;
      this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandGalaxyPanelModelUid).IsNull == false)
        Entity.InputCommandGalaxyPanelModelUid = this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandGalaxyPanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandUid).IsNull == false)
        Entity.InputCommandUid = this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.InputCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputCommandGalaxyPanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputCommandGalaxyPanelModelUniquePDSA class.
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
    /// Returns '@InputCommandGalaxyPanelModelUid'
    /// </summary>
    public static string InputCommandGalaxyPanelModelUid = "@InputCommandGalaxyPanelModelUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@InputCommandUid'
    /// </summary>
    public static string InputCommandUid = "@InputCommandUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputCommandGalaxyPanelModelUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputCommandGalaxyPanelModelUid'
    /// </summary>
    public static string InputCommandGalaxyPanelModelUid = "@InputCommandGalaxyPanelModelUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@InputCommandUid'
    /// </summary>
    public static string InputCommandUid = "@InputCommandUid";
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
