using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCountryUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCountryUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCountryUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCountryUniquePDSA Entity
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
    /// Clones the current IsCountryUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCountryUniquePDSA object</returns>
    public IsCountryUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCountryUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCountryUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCountryUniquePDSA object</returns>
    public IsCountryUniquePDSA CloneEntity(IsCountryUniquePDSA entityToClone)
    {
      IsCountryUniquePDSA newEntity = new IsCountryUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCountryUniquePDSAValidator.ParameterNames.CountryUid, GetResourceMessage("GCS_IsCountryUniquePDSA_CountryUid_Header", "Country Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCountryUniquePDSA_CountryUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCountryUniquePDSAValidator.ParameterNames.CountryIso, GetResourceMessage("GCS_IsCountryUniquePDSA_CountryIso_Header", "Country Iso"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCountryUniquePDSA_CountryIso_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCountryUniquePDSAValidator.ParameterNames.CountryName, GetResourceMessage("GCS_IsCountryUniquePDSA_CountryName_Header", "Country Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCountryUniquePDSA_CountryName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCountryUniquePDSAValidator.ParameterNames.Iso3, GetResourceMessage("GCS_IsCountryUniquePDSA_Iso3_Header", "Iso 3"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCountryUniquePDSA_Iso3_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCountryUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCountryUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCountryUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCountryUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCountryUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCountryUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryUid).Value = Entity.CountryUid;
      this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryIso).Value = Entity.CountryIso;
      this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryName).Value = Entity.CountryName;
      this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.Iso3).Value = Entity.Iso3;
      this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryUid).IsNull == false)
        Entity.CountryUid = this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryUid).GetAsGuid();
      if(this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryIso).IsNull == false)
        Entity.CountryIso = this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryIso).GetAsString();
      if(this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryName).IsNull == false)
        Entity.CountryName = this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.CountryName).GetAsString();
      if(this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.Iso3).IsNull == false)
        Entity.Iso3 = this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.Iso3).GetAsString();
      if(this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCountryUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCountryUniquePDSA class.
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
    /// Returns '@CountryUid'
    /// </summary>
    public static string CountryUid = "@CountryUid";
    /// <summary>
    /// Returns '@CountryIso'
    /// </summary>
    public static string CountryIso = "@CountryIso";
    /// <summary>
    /// Returns '@CountryName'
    /// </summary>
    public static string CountryName = "@CountryName";
    /// <summary>
    /// Returns '@Iso3'
    /// </summary>
    public static string Iso3 = "@Iso3";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCountryUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CountryUid'
    /// </summary>
    public static string CountryUid = "@CountryUid";
    /// <summary>
    /// Returns '@CountryIso'
    /// </summary>
    public static string CountryIso = "@CountryIso";
    /// <summary>
    /// Returns '@CountryName'
    /// </summary>
    public static string CountryName = "@CountryName";
    /// <summary>
    /// Returns '@Iso3'
    /// </summary>
    public static string Iso3 = "@Iso3";
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
