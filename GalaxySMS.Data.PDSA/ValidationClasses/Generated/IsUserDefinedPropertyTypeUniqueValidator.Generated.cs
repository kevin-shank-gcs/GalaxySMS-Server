using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsUserDefinedPropertyTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsUserDefinedPropertyTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsUserDefinedPropertyTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsUserDefinedPropertyTypeUniquePDSA Entity
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
    /// Clones the current IsUserDefinedPropertyTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsUserDefinedPropertyTypeUniquePDSA object</returns>
    public IsUserDefinedPropertyTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsUserDefinedPropertyTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsUserDefinedPropertyTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsUserDefinedPropertyTypeUniquePDSA object</returns>
    public IsUserDefinedPropertyTypeUniquePDSA CloneEntity(IsUserDefinedPropertyTypeUniquePDSA entityToClone)
    {
      IsUserDefinedPropertyTypeUniquePDSA newEntity = new IsUserDefinedPropertyTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyTypeUid, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_PropertyTypeUid_Header", "Property Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_PropertyTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyType, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_PropertyType_Header", "Property Type"), false, typeof(string), 8000, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_PropertyType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedPropertyTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyTypeUid).Value = Entity.PropertyTypeUid;
      this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyType).Value = Entity.PropertyType;
      this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyTypeUid).IsNull == false)
        Entity.PropertyTypeUid = this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyType).IsNull == false)
        Entity.PropertyType = this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.PropertyType).GetAsString();
      if(this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsUserDefinedPropertyTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyTypeUniquePDSA class.
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
    /// Returns '@PropertyTypeUid'
    /// </summary>
    public static string PropertyTypeUid = "@PropertyTypeUid";
    /// <summary>
    /// Returns '@PropertyType'
    /// </summary>
    public static string PropertyType = "@PropertyType";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PropertyTypeUid'
    /// </summary>
    public static string PropertyTypeUid = "@PropertyTypeUid";
    /// <summary>
    /// Returns '@PropertyType'
    /// </summary>
    public static string PropertyType = "@PropertyType";
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
