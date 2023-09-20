using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsFeatureUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsFeatureUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsFeatureUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsFeatureUniquePDSA Entity
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
    /// Clones the current IsFeatureUniquePDSA
    /// </summary>
    /// <returns>A cloned IsFeatureUniquePDSA object</returns>
    public IsFeatureUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsFeatureUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsFeatureUniquePDSA entity to clone</param>
    /// <returns>A cloned IsFeatureUniquePDSA object</returns>
    public IsFeatureUniquePDSA CloneEntity(IsFeatureUniquePDSA entityToClone)
    {
      IsFeatureUniquePDSA newEntity = new IsFeatureUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsFeatureUniquePDSAValidator.ParameterNames.FeatureUid, GetResourceMessage("GCS_IsFeatureUniquePDSA_FeatureUid_Header", "Feature Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsFeatureUniquePDSA_FeatureUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureUniquePDSAValidator.ParameterNames.CategoryCode, GetResourceMessage("GCS_IsFeatureUniquePDSA_CategoryCode_Header", "Category Code"), false, typeof(string), 8000, GetResourceMessage("GCS_IsFeatureUniquePDSA_CategoryCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureUniquePDSAValidator.ParameterNames.FeatureCode, GetResourceMessage("GCS_IsFeatureUniquePDSA_FeatureCode_Header", "Feature Code"), false, typeof(string), 8000, GetResourceMessage("GCS_IsFeatureUniquePDSA_FeatureCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureUniquePDSAValidator.ParameterNames.Description, GetResourceMessage("GCS_IsFeatureUniquePDSA_Description_Header", "Description"), false, typeof(string), 1000, GetResourceMessage("GCS_IsFeatureUniquePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsFeatureUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsFeatureUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsFeatureUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsFeatureUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.FeatureUid).Value = Entity.FeatureUid;
      this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.CategoryCode).Value = Entity.CategoryCode;
      this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.FeatureCode).Value = Entity.FeatureCode;
      this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.Description).Value = Entity.Description;
      this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.FeatureUid).IsNull == false)
        Entity.FeatureUid = this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.FeatureUid).GetAsGuid();
      if(this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.CategoryCode).IsNull == false)
        Entity.CategoryCode = this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.CategoryCode).GetAsString();
      if(this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.FeatureCode).IsNull == false)
        Entity.FeatureCode = this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.FeatureCode).GetAsString();
      if(this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.Description).IsNull == false)
        Entity.Description = this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.Description).GetAsString();
      if(this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsFeatureUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsFeatureUniquePDSA class.
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
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
    /// <summary>
    /// Returns '@CategoryCode'
    /// </summary>
    public static string CategoryCode = "@CategoryCode";
    /// <summary>
    /// Returns '@FeatureCode'
    /// </summary>
    public static string FeatureCode = "@FeatureCode";
    /// <summary>
    /// Returns '@Description'
    /// </summary>
    public static string Description = "@Description";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsFeatureUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
    /// <summary>
    /// Returns '@CategoryCode'
    /// </summary>
    public static string CategoryCode = "@CategoryCode";
    /// <summary>
    /// Returns '@FeatureCode'
    /// </summary>
    public static string FeatureCode = "@FeatureCode";
    /// <summary>
    /// Returns '@Description'
    /// </summary>
    public static string Description = "@Description";
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
