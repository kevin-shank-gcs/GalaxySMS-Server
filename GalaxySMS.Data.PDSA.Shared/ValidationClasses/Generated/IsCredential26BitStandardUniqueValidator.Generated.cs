using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredential26BitStandardUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredential26BitStandardUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredential26BitStandardUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredential26BitStandardUniquePDSA Entity
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
    /// Clones the current IsCredential26BitStandardUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredential26BitStandardUniquePDSA object</returns>
    public IsCredential26BitStandardUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredential26BitStandardUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredential26BitStandardUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredential26BitStandardUniquePDSA object</returns>
    public IsCredential26BitStandardUniquePDSA CloneEntity(IsCredential26BitStandardUniquePDSA entityToClone)
    {
      IsCredential26BitStandardUniquePDSA newEntity = new IsCredential26BitStandardUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_FacilityCode_Header", "Facility Code"), false, typeof(short), 0, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_FacilityCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("0"), Convert.ToInt16("255"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_IdCode_Header", "Id Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_IdCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode).Value = Entity.FacilityCode;
      this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode).Value = Entity.IdCode;
      this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode).IsNull == false)
        Entity.FacilityCode = this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode).GetAsShort();
      if(this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode).IsNull == false)
        Entity.IdCode = this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode).GetAsInteger();
      if(this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredential26BitStandardUniquePDSA class.
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
    /// Returns '@FacilityCode'
    /// </summary>
    public static string FacilityCode = "@FacilityCode";
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
    /// Contains static string properties that represent the name of each property in the IsCredential26BitStandardUniquePDSA class.
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
    /// Returns '@FacilityCode'
    /// </summary>
    public static string FacilityCode = "@FacilityCode";
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
