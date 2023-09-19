using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsUserPropertyUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsUserPropertyUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsUserPropertyUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsUserPropertyUniquePDSA Entity
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
    /// Clones the current gcs_IsUserPropertyUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsUserPropertyUniquePDSA object</returns>
    public gcs_IsUserPropertyUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsUserPropertyUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsUserPropertyUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsUserPropertyUniquePDSA object</returns>
    public gcs_IsUserPropertyUniquePDSA CloneEntity(gcs_IsUserPropertyUniquePDSA entityToClone)
    {
      gcs_IsUserPropertyUniquePDSA newEntity = new gcs_IsUserPropertyUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.LoginName, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_LoginName_Header", "Login Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_LoginName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.EmailAddress, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_EmailAddress_Header", "Email Address"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_EmailAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.PropName, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_PropName_Header", "Prop Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_PropName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsUserPropertyUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.LoginName).Value = Entity.LoginName;
      this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.EmailAddress).Value = Entity.EmailAddress;
      this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.PropName).Value = Entity.PropName;
      this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.LoginName).IsNull == false)
        Entity.LoginName = this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.LoginName).GetAsString();
      if(this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.EmailAddress).IsNull == false)
        Entity.EmailAddress = this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.EmailAddress).GetAsString();
      if(this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.PropName).IsNull == false)
        Entity.PropName = this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.PropName).GetAsString();
      if(this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsUserPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsUserPropertyUniquePDSA class.
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
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@LoginName'
    /// </summary>
    public static string LoginName = "@LoginName";
    /// <summary>
    /// Returns '@EmailAddress'
    /// </summary>
    public static string EmailAddress = "@EmailAddress";
    /// <summary>
    /// Returns '@PropName'
    /// </summary>
    public static string PropName = "@PropName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsUserPropertyUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@LoginName'
    /// </summary>
    public static string LoginName = "@LoginName";
    /// <summary>
    /// Returns '@EmailAddress'
    /// </summary>
    public static string EmailAddress = "@EmailAddress";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@PropName'
    /// </summary>
    public static string PropName = "@PropName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
