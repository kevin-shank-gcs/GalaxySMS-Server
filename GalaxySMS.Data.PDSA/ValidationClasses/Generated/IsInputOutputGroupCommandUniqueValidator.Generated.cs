using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputOutputGroupCommandUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputOutputGroupCommandUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputOutputGroupCommandUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputOutputGroupCommandUniquePDSA Entity
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
    /// Clones the current IsInputOutputGroupCommandUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputOutputGroupCommandUniquePDSA object</returns>
    public IsInputOutputGroupCommandUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputOutputGroupCommandUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputOutputGroupCommandUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputOutputGroupCommandUniquePDSA object</returns>
    public IsInputOutputGroupCommandUniquePDSA CloneEntity(IsInputOutputGroupCommandUniquePDSA entityToClone)
    {
      IsInputOutputGroupCommandUniquePDSA newEntity = new IsInputOutputGroupCommandUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.InputOutputGroupCommandUid, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_InputOutputGroupCommandUid_Header", "Input Output Group Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_InputOutputGroupCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputOutputGroupCommandUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.InputOutputGroupCommandUid).Value = Entity.InputOutputGroupCommandUid;
      this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.InputOutputGroupCommandUid).IsNull == false)
        Entity.InputOutputGroupCommandUid = this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.InputOutputGroupCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Display).GetAsString();
      if(this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputOutputGroupCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputOutputGroupCommandUniquePDSA class.
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
    /// Returns '@InputOutputGroupCommandUid'
    /// </summary>
    public static string InputOutputGroupCommandUid = "@InputOutputGroupCommandUid";
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
    /// Contains static string properties that represent the name of each property in the IsInputOutputGroupCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputOutputGroupCommandUid'
    /// </summary>
    public static string InputOutputGroupCommandUid = "@InputOutputGroupCommandUid";
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
