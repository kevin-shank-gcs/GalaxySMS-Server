using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialPIV75BitUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialPIV75BitUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialPIV75BitUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialPIV75BitUniquePDSA Entity
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
    /// Clones the current IsCredentialPIV75BitUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialPIV75BitUniquePDSA object</returns>
    public IsCredentialPIV75BitUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialPIV75BitUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialPIV75BitUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialPIV75BitUniquePDSA object</returns>
    public IsCredentialPIV75BitUniquePDSA CloneEntity(IsCredentialPIV75BitUniquePDSA entityToClone)
    {
      IsCredentialPIV75BitUniquePDSA newEntity = new IsCredentialPIV75BitUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.AgencyCode, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_AgencyCode_Header", "Agency Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_AgencyCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.SiteCode, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_SiteCode_Header", "Site Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_SiteCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialCode, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_CredentialCode_Header", "Credential Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_CredentialCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialPIV75BitUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.AgencyCode).Value = Entity.AgencyCode;
      this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.SiteCode).Value = Entity.SiteCode;
      this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialCode).Value = Entity.CredentialCode;
      this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.AgencyCode).IsNull == false)
        Entity.AgencyCode = this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.AgencyCode).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.SiteCode).IsNull == false)
        Entity.SiteCode = this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.SiteCode).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialCode).IsNull == false)
        Entity.CredentialCode = this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.CredentialCode).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialPIV75BitUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialPIV75BitUniquePDSA class.
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
    /// Returns '@AgencyCode'
    /// </summary>
    public static string AgencyCode = "@AgencyCode";
    /// <summary>
    /// Returns '@SiteCode'
    /// </summary>
    public static string SiteCode = "@SiteCode";
    /// <summary>
    /// Returns '@CredentialCode'
    /// </summary>
    public static string CredentialCode = "@CredentialCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialPIV75BitUniquePDSA class.
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
    /// Returns '@AgencyCode'
    /// </summary>
    public static string AgencyCode = "@AgencyCode";
    /// <summary>
    /// Returns '@SiteCode'
    /// </summary>
    public static string SiteCode = "@SiteCode";
    /// <summary>
    /// Returns '@CredentialCode'
    /// </summary>
    public static string CredentialCode = "@CredentialCode";
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
