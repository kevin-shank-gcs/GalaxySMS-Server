using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonCredentialCommandScriptUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonCredentialCommandScriptUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonCredentialCommandScriptUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonCredentialCommandScriptUniquePDSA Entity
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
    /// Clones the current IsPersonCredentialCommandScriptUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonCredentialCommandScriptUniquePDSA object</returns>
    public IsPersonCredentialCommandScriptUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonCredentialCommandScriptUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonCredentialCommandScriptUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonCredentialCommandScriptUniquePDSA object</returns>
    public IsPersonCredentialCommandScriptUniquePDSA CloneEntity(IsPersonCredentialCommandScriptUniquePDSA entityToClone)
    {
      IsPersonCredentialCommandScriptUniquePDSA newEntity = new IsPersonCredentialCommandScriptUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialCommandScriptUid, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_PersonCredentialCommandScriptUid_Header", "Person Credential Command Script Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_PersonCredentialCommandScriptUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialUid, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_PersonCredentialUid_Header", "Person Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_PersonCredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_CommandScriptUid_Header", "Command Script Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_CommandScriptUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonCredentialCommandScriptUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialCommandScriptUid).Value = Entity.PersonCredentialCommandScriptUid;
      this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialUid).Value = Entity.PersonCredentialUid;
      this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid).Value = Entity.CommandScriptUid;
      this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialCommandScriptUid).IsNull == false)
        Entity.PersonCredentialCommandScriptUid = this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialCommandScriptUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialUid).IsNull == false)
        Entity.PersonCredentialUid = this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.PersonCredentialUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid).IsNull == false)
        Entity.CommandScriptUid = this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonCredentialCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonCredentialCommandScriptUniquePDSA class.
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
    /// Returns '@PersonCredentialCommandScriptUid'
    /// </summary>
    public static string PersonCredentialCommandScriptUid = "@PersonCredentialCommandScriptUid";
    /// <summary>
    /// Returns '@PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "@PersonCredentialUid";
    /// <summary>
    /// Returns '@CommandScriptUid'
    /// </summary>
    public static string CommandScriptUid = "@CommandScriptUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonCredentialCommandScriptUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonCredentialCommandScriptUid'
    /// </summary>
    public static string PersonCredentialCommandScriptUid = "@PersonCredentialCommandScriptUid";
    /// <summary>
    /// Returns '@PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "@PersonCredentialUid";
    /// <summary>
    /// Returns '@CommandScriptUid'
    /// </summary>
    public static string CommandScriptUid = "@CommandScriptUid";
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
