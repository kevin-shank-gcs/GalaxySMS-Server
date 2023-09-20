using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialReaderDataFormatUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialReaderDataFormatUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialReaderDataFormatUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialReaderDataFormatUniquePDSA Entity
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
    /// Clones the current IsCredentialReaderDataFormatUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialReaderDataFormatUniquePDSA object</returns>
    public IsCredentialReaderDataFormatUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialReaderDataFormatUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialReaderDataFormatUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialReaderDataFormatUniquePDSA object</returns>
    public IsCredentialReaderDataFormatUniquePDSA CloneEntity(IsCredentialReaderDataFormatUniquePDSA entityToClone)
    {
      IsCredentialReaderDataFormatUniquePDSA newEntity = new IsCredentialReaderDataFormatUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.CredentialReaderDataFormatUid, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_CredentialReaderDataFormatUid_Header", "Credential Reader Data Format Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_CredentialReaderDataFormatUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.DataFormatName, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_DataFormatName_Header", "Data Format Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_DataFormatName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialReaderDataFormatUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.CredentialReaderDataFormatUid).Value = Entity.CredentialReaderDataFormatUid;
      this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.DataFormatName).Value = Entity.DataFormatName;
      this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.CredentialReaderDataFormatUid).IsNull == false)
        Entity.CredentialReaderDataFormatUid = this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.CredentialReaderDataFormatUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.DataFormatName).IsNull == false)
        Entity.DataFormatName = this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.DataFormatName).GetAsString();
      if(this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialReaderDataFormatUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialReaderDataFormatUniquePDSA class.
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
    /// Returns '@CredentialReaderDataFormatUid'
    /// </summary>
    public static string CredentialReaderDataFormatUid = "@CredentialReaderDataFormatUid";
    /// <summary>
    /// Returns '@DataFormatName'
    /// </summary>
    public static string DataFormatName = "@DataFormatName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialReaderDataFormatUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialReaderDataFormatUid'
    /// </summary>
    public static string CredentialReaderDataFormatUid = "@CredentialReaderDataFormatUid";
    /// <summary>
    /// Returns '@DataFormatName'
    /// </summary>
    public static string DataFormatName = "@DataFormatName";
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
