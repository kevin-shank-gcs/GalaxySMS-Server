using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialFormatDataFieldUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialFormatDataFieldUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialFormatDataFieldUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialFormatDataFieldUniquePDSA Entity
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
    /// Clones the current IsCredentialFormatDataFieldUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialFormatDataFieldUniquePDSA object</returns>
    public IsCredentialFormatDataFieldUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialFormatDataFieldUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialFormatDataFieldUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialFormatDataFieldUniquePDSA object</returns>
    public IsCredentialFormatDataFieldUniquePDSA CloneEntity(IsCredentialFormatDataFieldUniquePDSA entityToClone)
    {
      IsCredentialFormatDataFieldUniquePDSA newEntity = new IsCredentialFormatDataFieldUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatDataFieldUid, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_CredentialFormatDataFieldUid_Header", "Credential Format Data Field Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_CredentialFormatDataFieldUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatUid, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_CredentialFormatUid_Header", "Credential Format Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_CredentialFormatUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.FieldNumber, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_FieldNumber_Header", "Field Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_FieldNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialFormatDataFieldUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatDataFieldUid).Value = Entity.CredentialFormatDataFieldUid;
      this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatUid).Value = Entity.CredentialFormatUid;
      this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.FieldNumber).Value = Entity.FieldNumber;
      this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatDataFieldUid).IsNull == false)
        Entity.CredentialFormatDataFieldUid = this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatDataFieldUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatUid).IsNull == false)
        Entity.CredentialFormatUid = this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.CredentialFormatUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.FieldNumber).IsNull == false)
        Entity.FieldNumber = this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.FieldNumber).GetAsShort();
      if(this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialFormatDataFieldUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialFormatDataFieldUniquePDSA class.
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
    /// Returns '@CredentialFormatDataFieldUid'
    /// </summary>
    public static string CredentialFormatDataFieldUid = "@CredentialFormatDataFieldUid";
    /// <summary>
    /// Returns '@CredentialFormatUid'
    /// </summary>
    public static string CredentialFormatUid = "@CredentialFormatUid";
    /// <summary>
    /// Returns '@FieldNumber'
    /// </summary>
    public static string FieldNumber = "@FieldNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialFormatDataFieldUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialFormatDataFieldUid'
    /// </summary>
    public static string CredentialFormatDataFieldUid = "@CredentialFormatDataFieldUid";
    /// <summary>
    /// Returns '@CredentialFormatUid'
    /// </summary>
    public static string CredentialFormatUid = "@CredentialFormatUid";
    /// <summary>
    /// Returns '@FieldNumber'
    /// </summary>
    public static string FieldNumber = "@FieldNumber";
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
