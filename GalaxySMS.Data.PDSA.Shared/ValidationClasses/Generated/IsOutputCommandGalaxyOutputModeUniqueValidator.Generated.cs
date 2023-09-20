using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsOutputCommandGalaxyOutputModeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsOutputCommandGalaxyOutputModeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsOutputCommandGalaxyOutputModeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsOutputCommandGalaxyOutputModeUniquePDSA Entity
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
    /// Clones the current IsOutputCommandGalaxyOutputModeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsOutputCommandGalaxyOutputModeUniquePDSA object</returns>
    public IsOutputCommandGalaxyOutputModeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsOutputCommandGalaxyOutputModeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsOutputCommandGalaxyOutputModeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsOutputCommandGalaxyOutputModeUniquePDSA object</returns>
    public IsOutputCommandGalaxyOutputModeUniquePDSA CloneEntity(IsOutputCommandGalaxyOutputModeUniquePDSA entityToClone)
    {
      IsOutputCommandGalaxyOutputModeUniquePDSA newEntity = new IsOutputCommandGalaxyOutputModeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandGalaxyOutputModeUid, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_OutputCommandGalaxyOutputModeUid_Header", "Output Command Galaxy Output Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_OutputCommandGalaxyOutputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.GalaxyOutputModeUid, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_GalaxyOutputModeUid_Header", "Galaxy Output Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_GalaxyOutputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandUid, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_OutputCommandUid_Header", "Output Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_OutputCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputCommandGalaxyOutputModeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandGalaxyOutputModeUid).Value = Entity.OutputCommandGalaxyOutputModeUid;
      this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.GalaxyOutputModeUid).Value = Entity.GalaxyOutputModeUid;
      this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandUid).Value = Entity.OutputCommandUid;
      this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandGalaxyOutputModeUid).IsNull == false)
        Entity.OutputCommandGalaxyOutputModeUid = this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandGalaxyOutputModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.GalaxyOutputModeUid).IsNull == false)
        Entity.GalaxyOutputModeUid = this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.GalaxyOutputModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandUid).IsNull == false)
        Entity.OutputCommandUid = this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.OutputCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsOutputCommandGalaxyOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputCommandGalaxyOutputModeUniquePDSA class.
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
    /// Returns '@OutputCommandGalaxyOutputModeUid'
    /// </summary>
    public static string OutputCommandGalaxyOutputModeUid = "@OutputCommandGalaxyOutputModeUid";
    /// <summary>
    /// Returns '@GalaxyOutputModeUid'
    /// </summary>
    public static string GalaxyOutputModeUid = "@GalaxyOutputModeUid";
    /// <summary>
    /// Returns '@OutputCommandUid'
    /// </summary>
    public static string OutputCommandUid = "@OutputCommandUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputCommandGalaxyOutputModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputCommandGalaxyOutputModeUid'
    /// </summary>
    public static string OutputCommandGalaxyOutputModeUid = "@OutputCommandGalaxyOutputModeUid";
    /// <summary>
    /// Returns '@GalaxyOutputModeUid'
    /// </summary>
    public static string GalaxyOutputModeUid = "@GalaxyOutputModeUid";
    /// <summary>
    /// Returns '@OutputCommandUid'
    /// </summary>
    public static string OutputCommandUid = "@OutputCommandUid";
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
