using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalCommandChoiceUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalCommandChoiceUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalCommandChoiceUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalCommandChoiceUniquePDSA Entity
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
    /// Clones the current IsAccessPortalCommandChoiceUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalCommandChoiceUniquePDSA object</returns>
    public IsAccessPortalCommandChoiceUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalCommandChoiceUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalCommandChoiceUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalCommandChoiceUniquePDSA object</returns>
    public IsAccessPortalCommandChoiceUniquePDSA CloneEntity(IsAccessPortalCommandChoiceUniquePDSA entityToClone)
    {
      IsAccessPortalCommandChoiceUniquePDSA newEntity = new IsAccessPortalCommandChoiceUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandChoiceUid, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_AccessPortalCommandChoiceUid_Header", "Access Portal Command Choice Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_AccessPortalCommandChoiceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandUid, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_AccessPortalCommandUid_Header", "Access Portal Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_AccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.ChoiceTypeCode, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_ChoiceTypeCode_Header", "Choice Type Code"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_ChoiceTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalCommandChoiceUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandChoiceUid).Value = Entity.AccessPortalCommandChoiceUid;
      this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).Value = Entity.AccessPortalCommandUid;
      this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.ChoiceTypeCode).Value = Entity.ChoiceTypeCode;
      this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandChoiceUid).IsNull == false)
        Entity.AccessPortalCommandChoiceUid = this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandChoiceUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalCommandUid = this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.ChoiceTypeCode).IsNull == false)
        Entity.ChoiceTypeCode = this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.ChoiceTypeCode).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalCommandChoiceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalCommandChoiceUniquePDSA class.
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
    /// Returns '@AccessPortalCommandChoiceUid'
    /// </summary>
    public static string AccessPortalCommandChoiceUid = "@AccessPortalCommandChoiceUid";
    /// <summary>
    /// Returns '@AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "@AccessPortalCommandUid";
    /// <summary>
    /// Returns '@ChoiceTypeCode'
    /// </summary>
    public static string ChoiceTypeCode = "@ChoiceTypeCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalCommandChoiceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalCommandChoiceUid'
    /// </summary>
    public static string AccessPortalCommandChoiceUid = "@AccessPortalCommandChoiceUid";
    /// <summary>
    /// Returns '@AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "@AccessPortalCommandUid";
    /// <summary>
    /// Returns '@ChoiceTypeCode'
    /// </summary>
    public static string ChoiceTypeCode = "@ChoiceTypeCode";
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
