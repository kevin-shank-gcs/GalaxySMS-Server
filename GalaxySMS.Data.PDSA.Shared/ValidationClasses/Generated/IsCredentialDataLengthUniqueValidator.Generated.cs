using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialDataLengthUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialDataLengthUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialDataLengthUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialDataLengthUniquePDSA Entity
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
    /// Clones the current IsCredentialDataLengthUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialDataLengthUniquePDSA object</returns>
    public IsCredentialDataLengthUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialDataLengthUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialDataLengthUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialDataLengthUniquePDSA object</returns>
    public IsCredentialDataLengthUniquePDSA CloneEntity(IsCredentialDataLengthUniquePDSA entityToClone)
    {
      IsCredentialDataLengthUniquePDSA newEntity = new IsCredentialDataLengthUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.CredentialDataLengthUid, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_CredentialDataLengthUid_Header", "Credential Data Length Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_CredentialDataLengthUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.DataLength, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_DataLength_Header", "Data Length"), false, typeof(short), 0, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_DataLength_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialDataLengthUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.CredentialDataLengthUid).Value = Entity.CredentialDataLengthUid;
      this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.DataLength).Value = Entity.DataLength;
      this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.CredentialDataLengthUid).IsNull == false)
        Entity.CredentialDataLengthUid = this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.CredentialDataLengthUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.DataLength).IsNull == false)
        Entity.DataLength = this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.DataLength).GetAsShort();
      if(this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialDataLengthUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialDataLengthUniquePDSA class.
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
    /// Returns '@CredentialDataLengthUid'
    /// </summary>
    public static string CredentialDataLengthUid = "@CredentialDataLengthUid";
    /// <summary>
    /// Returns '@DataLength'
    /// </summary>
    public static string DataLength = "@DataLength";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialDataLengthUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialDataLengthUid'
    /// </summary>
    public static string CredentialDataLengthUid = "@CredentialDataLengthUid";
    /// <summary>
    /// Returns '@DataLength'
    /// </summary>
    public static string DataLength = "@DataLength";
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
