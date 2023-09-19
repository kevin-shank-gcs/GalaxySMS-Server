using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialCorporate1K48BitUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialCorporate1K48BitUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialCorporate1K48BitUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialCorporate1K48BitUniquePDSA Entity
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
    /// Clones the current IsCredentialCorporate1K48BitUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialCorporate1K48BitUniquePDSA object</returns>
    public IsCredentialCorporate1K48BitUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialCorporate1K48BitUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialCorporate1K48BitUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialCorporate1K48BitUniquePDSA object</returns>
    public IsCredentialCorporate1K48BitUniquePDSA CloneEntity(IsCredentialCorporate1K48BitUniquePDSA entityToClone)
    {
      IsCredentialCorporate1K48BitUniquePDSA newEntity = new IsCredentialCorporate1K48BitUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CompanyCode, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_CompanyCode_Header", "Company Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_CompanyCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.IdCode, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_IdCode_Header", "Id Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_IdCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialCorporate1K48BitUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CompanyCode).Value = Entity.CompanyCode;
      this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.IdCode).Value = Entity.IdCode;
      this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CompanyCode).IsNull == false)
        Entity.CompanyCode = this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.CompanyCode).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.IdCode).IsNull == false)
        Entity.IdCode = this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.IdCode).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialCorporate1K48BitUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialCorporate1K48BitUniquePDSA class.
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
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@CompanyCode'
    /// </summary>
    public static string CompanyCode = "@CompanyCode";
    /// <summary>
    /// Returns '@IdCode'
    /// </summary>
    public static string IdCode = "@IdCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialCorporate1K48BitUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@CompanyCode'
    /// </summary>
    public static string CompanyCode = "@CompanyCode";
    /// <summary>
    /// Returns '@IdCode'
    /// </summary>
    public static string IdCode = "@IdCode";
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
