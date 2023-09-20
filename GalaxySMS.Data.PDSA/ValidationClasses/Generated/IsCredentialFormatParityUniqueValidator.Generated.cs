using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCredentialFormatParityUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCredentialFormatParityUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCredentialFormatParityUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCredentialFormatParityUniquePDSA Entity
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
    /// Clones the current IsCredentialFormatParityUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCredentialFormatParityUniquePDSA object</returns>
    public IsCredentialFormatParityUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCredentialFormatParityUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCredentialFormatParityUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCredentialFormatParityUniquePDSA object</returns>
    public IsCredentialFormatParityUniquePDSA CloneEntity(IsCredentialFormatParityUniquePDSA entityToClone)
    {
      IsCredentialFormatParityUniquePDSA newEntity = new IsCredentialFormatParityUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatParityUid, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_CredentialFormatParityUid_Header", "Credential Format Parity Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_CredentialFormatParityUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatUid, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_CredentialFormatUid_Header", "Credential Format Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_CredentialFormatUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.ComputeSequence, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_ComputeSequence_Header", "Compute Sequence"), false, typeof(short), 0, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_ComputeSequence_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.BitPosition, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_BitPosition_Header", "Bit Position"), false, typeof(short), 0, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_BitPosition_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCredentialFormatParityUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatParityUid).Value = Entity.CredentialFormatParityUid;
      this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatUid).Value = Entity.CredentialFormatUid;
      this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.ComputeSequence).Value = Entity.ComputeSequence;
      this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.BitPosition).Value = Entity.BitPosition;
      this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatParityUid).IsNull == false)
        Entity.CredentialFormatParityUid = this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatParityUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatUid).IsNull == false)
        Entity.CredentialFormatUid = this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.CredentialFormatUid).GetAsGuid();
      if(this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.ComputeSequence).IsNull == false)
        Entity.ComputeSequence = this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.ComputeSequence).GetAsShort();
      if(this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.BitPosition).IsNull == false)
        Entity.BitPosition = this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.BitPosition).GetAsShort();
      if(this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCredentialFormatParityUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialFormatParityUniquePDSA class.
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
    /// Returns '@CredentialFormatParityUid'
    /// </summary>
    public static string CredentialFormatParityUid = "@CredentialFormatParityUid";
    /// <summary>
    /// Returns '@CredentialFormatUid'
    /// </summary>
    public static string CredentialFormatUid = "@CredentialFormatUid";
    /// <summary>
    /// Returns '@ComputeSequence'
    /// </summary>
    public static string ComputeSequence = "@ComputeSequence";
    /// <summary>
    /// Returns '@BitPosition'
    /// </summary>
    public static string BitPosition = "@BitPosition";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredentialFormatParityUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialFormatParityUid'
    /// </summary>
    public static string CredentialFormatParityUid = "@CredentialFormatParityUid";
    /// <summary>
    /// Returns '@CredentialFormatUid'
    /// </summary>
    public static string CredentialFormatUid = "@CredentialFormatUid";
    /// <summary>
    /// Returns '@ComputeSequence'
    /// </summary>
    public static string ComputeSequence = "@ComputeSequence";
    /// <summary>
    /// Returns '@BitPosition'
    /// </summary>
    public static string BitPosition = "@BitPosition";
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
