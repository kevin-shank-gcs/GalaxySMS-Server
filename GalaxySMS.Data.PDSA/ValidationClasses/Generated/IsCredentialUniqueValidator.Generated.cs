using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialUniquePDSA Entity
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
    /// Clones the current IsCredentialUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialUniquePDSA object</returns>
    public IsCredentialUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialUniquePDSA object</returns>
    public IsCredentialUniquePDSA CloneEntity(IsCredentialUniquePDSA entityToClone)
    {
      IsCredentialUniquePDSA newEntity = new IsCredentialUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialUniquePDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_IsCredentialUniquePDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialUniquePDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialUniquePDSAValidator.ParameterNames.CardNumber, GetResourceMessage("GCS_IsCredentialUniquePDSA_CardNumber_Header", "Card Number"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCredentialUniquePDSA_CardNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialUniquePDSAValidator.ParameterNames.CardBinaryData, GetResourceMessage("GCS_IsCredentialUniquePDSA_CardBinaryData_Header", "Card Binary Data"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCredentialUniquePDSA_CardBinaryData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CardNumber).Value = Entity.CardNumber;
      this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CardBinaryData).Value = Entity.CardBinaryData;
      this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CardNumber).IsNull == false)
        Entity.CardNumber = this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CardNumber).GetAsString();
      if(this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CardBinaryData).IsNull == false)
        Entity.CardBinaryData = this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.CardBinaryData).GetAsByteArray();
      if(this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialUniquePDSA class.
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
    /// Returns '@CardNumber'
    /// </summary>
    public static string CardNumber = "@CardNumber";
    /// <summary>
    /// Returns '@CardBinaryData'
    /// </summary>
    public static string CardBinaryData = "@CardBinaryData";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialUniquePDSA class.
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
    /// Returns '@CardNumber'
    /// </summary>
    public static string CardNumber = "@CardNumber";
    /// <summary>
    /// Returns '@CardBinaryData'
    /// </summary>
    public static string CardBinaryData = "@CardBinaryData";
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
