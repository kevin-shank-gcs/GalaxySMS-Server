using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsStateProvinceUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsStateProvinceUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsStateProvinceUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsStateProvinceUniquePDSA Entity
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
    /// Clones the current IsStateProvinceUniquePDSA
    /// </summary>
    /// <returns>A cloned IsStateProvinceUniquePDSA object</returns>
    public IsStateProvinceUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsStateProvinceUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsStateProvinceUniquePDSA entity to clone</param>
    /// <returns>A cloned IsStateProvinceUniquePDSA object</returns>
    public IsStateProvinceUniquePDSA CloneEntity(IsStateProvinceUniquePDSA entityToClone)
    {
      IsStateProvinceUniquePDSA newEntity = new IsStateProvinceUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceUid, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_StateProvinceUid_Header", "State Province Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_StateProvinceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsStateProvinceUniquePDSAValidator.ParameterNames.CountryUid, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_CountryUid_Header", "Country Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_CountryUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceName, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_StateProvinceName_Header", "State Province Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_StateProvinceName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsStateProvinceUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsStateProvinceUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsStateProvinceUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceUid).Value = Entity.StateProvinceUid;
      this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.CountryUid).Value = Entity.CountryUid;
      this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceName).Value = Entity.StateProvinceName;
      this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceUid).IsNull == false)
        Entity.StateProvinceUid = this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceUid).GetAsGuid();
      if(this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.CountryUid).IsNull == false)
        Entity.CountryUid = this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.CountryUid).GetAsGuid();
      if(this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceName).IsNull == false)
        Entity.StateProvinceName = this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.StateProvinceName).GetAsString();
      if(this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsStateProvinceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsStateProvinceUniquePDSA class.
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
    /// Returns '@StateProvinceUid'
    /// </summary>
    public static string StateProvinceUid = "@StateProvinceUid";
    /// <summary>
    /// Returns '@CountryUid'
    /// </summary>
    public static string CountryUid = "@CountryUid";
    /// <summary>
    /// Returns '@StateProvinceName'
    /// </summary>
    public static string StateProvinceName = "@StateProvinceName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsStateProvinceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@StateProvinceUid'
    /// </summary>
    public static string StateProvinceUid = "@StateProvinceUid";
    /// <summary>
    /// Returns '@CountryUid'
    /// </summary>
    public static string CountryUid = "@CountryUid";
    /// <summary>
    /// Returns '@StateProvinceName'
    /// </summary>
    public static string StateProvinceName = "@StateProvinceName";
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
