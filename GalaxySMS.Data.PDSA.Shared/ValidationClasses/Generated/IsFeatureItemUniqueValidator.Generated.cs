using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsFeatureItemUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsFeatureItemUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsFeatureItemUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsFeatureItemUniquePDSA Entity
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
    /// Clones the current IsFeatureItemUniquePDSA
    /// </summary>
    /// <returns>A cloned IsFeatureItemUniquePDSA object</returns>
    public IsFeatureItemUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsFeatureItemUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsFeatureItemUniquePDSA entity to clone</param>
    /// <returns>A cloned IsFeatureItemUniquePDSA object</returns>
    public IsFeatureItemUniquePDSA CloneEntity(IsFeatureItemUniquePDSA entityToClone)
    {
      IsFeatureItemUniquePDSA newEntity = new IsFeatureItemUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureItemUid, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_FeatureItemUid_Header", "Feature Item Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_FeatureItemUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureUid, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_FeatureUid_Header", "Feature Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_FeatureUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureItemUniquePDSAValidator.ParameterNames.Value, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_Value_Header", "Value"), false, typeof(string), 8000, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureItemUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsFeatureItemUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsFeatureItemUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureItemUid).Value = Entity.FeatureItemUid;
      this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureUid).Value = Entity.FeatureUid;
      this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.Value).Value = Entity.Value;
      this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureItemUid).IsNull == false)
        Entity.FeatureItemUid = this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureItemUid).GetAsGuid();
      if(this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureUid).IsNull == false)
        Entity.FeatureUid = this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.FeatureUid).GetAsGuid();
      if(this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.Value).IsNull == false)
        Entity.Value = this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.Value).GetAsString();
      if(this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsFeatureItemUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsFeatureItemUniquePDSA class.
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
    /// Returns '@FeatureItemUid'
    /// </summary>
    public static string FeatureItemUid = "@FeatureItemUid";
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
    /// <summary>
    /// Returns '@Value'
    /// </summary>
    public static string Value = "@Value";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsFeatureItemUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@FeatureItemUid'
    /// </summary>
    public static string FeatureItemUid = "@FeatureItemUid";
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
    /// <summary>
    /// Returns '@Value'
    /// </summary>
    public static string Value = "@Value";
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
