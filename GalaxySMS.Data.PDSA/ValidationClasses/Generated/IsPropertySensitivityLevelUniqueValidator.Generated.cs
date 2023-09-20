using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPropertySensitivityLevelUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPropertySensitivityLevelUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPropertySensitivityLevelUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPropertySensitivityLevelUniquePDSA Entity
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
    /// Clones the current IsPropertySensitivityLevelUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPropertySensitivityLevelUniquePDSA object</returns>
    public IsPropertySensitivityLevelUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPropertySensitivityLevelUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPropertySensitivityLevelUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPropertySensitivityLevelUniquePDSA object</returns>
    public IsPropertySensitivityLevelUniquePDSA CloneEntity(IsPropertySensitivityLevelUniquePDSA entityToClone)
    {
      IsPropertySensitivityLevelUniquePDSA newEntity = new IsPropertySensitivityLevelUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_PropertySensitivityLevelUid_Header", "Property Sensitivity Level Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_PropertySensitivityLevelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_SensitivityLevel_Header", "Sensitivity Level"), false, typeof(short), 0, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_SensitivityLevel_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid).Value = Entity.PropertySensitivityLevelUid;
      this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel).Value = Entity.SensitivityLevel;
      this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid).IsNull == false)
        Entity.PropertySensitivityLevelUid = this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid).GetAsGuid();
      if(this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel).IsNull == false)
        Entity.SensitivityLevel = this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel).GetAsShort();
      if(this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display).GetAsString();
      if(this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPropertySensitivityLevelUniquePDSA class.
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
    /// Returns '@PropertySensitivityLevelUid'
    /// </summary>
    public static string PropertySensitivityLevelUid = "@PropertySensitivityLevelUid";
    /// <summary>
    /// Returns '@SensitivityLevel'
    /// </summary>
    public static string SensitivityLevel = "@SensitivityLevel";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPropertySensitivityLevelUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PropertySensitivityLevelUid'
    /// </summary>
    public static string PropertySensitivityLevelUid = "@PropertySensitivityLevelUid";
    /// <summary>
    /// Returns '@SensitivityLevel'
    /// </summary>
    public static string SensitivityLevel = "@SensitivityLevel";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
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
