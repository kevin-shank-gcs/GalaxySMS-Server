using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialDataUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialDataUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialDataUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialDataUniquePDSA Entity
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
    /// Clones the current IsCredentialDataUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialDataUniquePDSA object</returns>
    public IsCredentialDataUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialDataUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialDataUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialDataUniquePDSA object</returns>
    public IsCredentialDataUniquePDSA CloneEntity(IsCredentialDataUniquePDSA entityToClone)
    {
      IsCredentialDataUniquePDSA newEntity = new IsCredentialDataUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.Number1, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number1_Header", "Number 1"), false, typeof(long), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number1_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.Number2, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number2_Header", "Number 2"), false, typeof(long), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number2_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.Number3, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number3_Header", "Number 3"), false, typeof(long), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number3_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.Number4, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number4_Header", "Number 4"), false, typeof(long), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number4_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.Number5, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number5_Header", "Number 5"), false, typeof(long), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Number5_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialDataUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number1).Value = Entity.Number1;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number2).Value = Entity.Number2;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number3).Value = Entity.Number3;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number4).Value = Entity.Number4;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number5).Value = Entity.Number5;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number1).IsNull == false)
        Entity.Number1 = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number1).GetAsLong();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number2).IsNull == false)
        Entity.Number2 = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number2).GetAsLong();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number3).IsNull == false)
        Entity.Number3 = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number3).GetAsLong();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number4).IsNull == false)
        Entity.Number4 = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number4).GetAsLong();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number5).IsNull == false)
        Entity.Number5 = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Number5).GetAsLong();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialDataUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialDataUniquePDSA class.
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
    /// Returns '@Number1'
    /// </summary>
    public static string Number1 = "@Number1";
    /// <summary>
    /// Returns '@Number2'
    /// </summary>
    public static string Number2 = "@Number2";
    /// <summary>
    /// Returns '@Number3'
    /// </summary>
    public static string Number3 = "@Number3";
    /// <summary>
    /// Returns '@Number4'
    /// </summary>
    public static string Number4 = "@Number4";
    /// <summary>
    /// Returns '@Number5'
    /// </summary>
    public static string Number5 = "@Number5";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialDataUniquePDSA class.
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
    /// Returns '@Number1'
    /// </summary>
    public static string Number1 = "@Number1";
    /// <summary>
    /// Returns '@Number2'
    /// </summary>
    public static string Number2 = "@Number2";
    /// <summary>
    /// Returns '@Number3'
    /// </summary>
    public static string Number3 = "@Number3";
    /// <summary>
    /// Returns '@Number4'
    /// </summary>
    public static string Number4 = "@Number4";
    /// <summary>
    /// Returns '@Number5'
    /// </summary>
    public static string Number5 = "@Number5";
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
