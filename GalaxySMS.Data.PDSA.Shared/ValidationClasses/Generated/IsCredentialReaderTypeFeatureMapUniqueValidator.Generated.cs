using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialReaderTypeFeatureMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialReaderTypeFeatureMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialReaderTypeFeatureMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialReaderTypeFeatureMapUniquePDSA Entity
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
    /// Clones the current IsCredentialReaderTypeFeatureMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialReaderTypeFeatureMapUniquePDSA object</returns>
    public IsCredentialReaderTypeFeatureMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialReaderTypeFeatureMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialReaderTypeFeatureMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialReaderTypeFeatureMapUniquePDSA object</returns>
    public IsCredentialReaderTypeFeatureMapUniquePDSA CloneEntity(IsCredentialReaderTypeFeatureMapUniquePDSA entityToClone)
    {
      IsCredentialReaderTypeFeatureMapUniquePDSA newEntity = new IsCredentialReaderTypeFeatureMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeFeatureMapUid, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_CredentialReaderTypeFeatureMapUid_Header", "Credential Reader Type Feature Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_CredentialReaderTypeFeatureMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeUid, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_CredentialReaderTypeUid_Header", "Credential Reader Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_CredentialReaderTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_FeatureUid_Header", "Feature Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_FeatureUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialReaderTypeFeatureMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeFeatureMapUid).Value = Entity.CredentialReaderTypeFeatureMapUid;
      this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeUid).Value = Entity.CredentialReaderTypeUid;
      this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid).Value = Entity.FeatureUid;
      this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeFeatureMapUid).IsNull == false)
        Entity.CredentialReaderTypeFeatureMapUid = this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeFeatureMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeUid).IsNull == false)
        Entity.CredentialReaderTypeUid = this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.CredentialReaderTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid).IsNull == false)
        Entity.FeatureUid = this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialReaderTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialReaderTypeFeatureMapUniquePDSA class.
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
    /// Returns '@CredentialReaderTypeFeatureMapUid'
    /// </summary>
    public static string CredentialReaderTypeFeatureMapUid = "@CredentialReaderTypeFeatureMapUid";
    /// <summary>
    /// Returns '@CredentialReaderTypeUid'
    /// </summary>
    public static string CredentialReaderTypeUid = "@CredentialReaderTypeUid";
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialReaderTypeFeatureMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialReaderTypeFeatureMapUid'
    /// </summary>
    public static string CredentialReaderTypeFeatureMapUid = "@CredentialReaderTypeFeatureMapUid";
    /// <summary>
    /// Returns '@CredentialReaderTypeUid'
    /// </summary>
    public static string CredentialReaderTypeUid = "@CredentialReaderTypeUid";
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
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
