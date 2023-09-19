using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsUser_GetPasswordResetInfoPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsUser_GetPasswordResetInfoPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsUser_GetPasswordResetInfoPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsUser_GetPasswordResetInfoPDSA Entity
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
    /// Clones the current gcsUser_GetPasswordResetInfoPDSA
    /// </summary>
    /// <returns>A cloned gcsUser_GetPasswordResetInfoPDSA object</returns>
    public gcsUser_GetPasswordResetInfoPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsUser_GetPasswordResetInfoPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsUser_GetPasswordResetInfoPDSA entity to clone</param>
    /// <returns>A cloned gcsUser_GetPasswordResetInfoPDSA object</returns>
    public gcsUser_GetPasswordResetInfoPDSA CloneEntity(gcsUser_GetPasswordResetInfoPDSA entityToClone)
    {
      gcsUser_GetPasswordResetInfoPDSA newEntity = new gcsUser_GetPasswordResetInfoPDSA();

      newEntity.UserId = entityToClone.UserId;
      newEntity.PrimaryEntityId = entityToClone.PrimaryEntityId;
      newEntity.UserName = entityToClone.UserName;
      newEntity.Email = entityToClone.Email;
      newEntity.ResetPasswordFlag = entityToClone.ResetPasswordFlag;
      newEntity.LastPasswordResetDate = entityToClone.LastPasswordResetDate;
      newEntity.PasswordResetToken = entityToClone.PasswordResetToken;
      newEntity.PasswordResetTokenExpiration = entityToClone.PasswordResetTokenExpiration;

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
      
      props.Add(PDSAProperty.Create(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserName, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_UserName_Header", "User Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_UserName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.Email, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_Email_Header", "Email"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_Email_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsUser_GetPasswordResetInfoPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserName).Value = Entity.UserName;
      this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.Email).Value = Entity.Email;
      this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserName).IsNull == false)
        Entity.UserName = this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.UserName).GetAsString();
      if(this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.Email).IsNull == false)
        Entity.Email = this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.Email).GetAsString();
      if(this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcsUser_GetPasswordResetInfoPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUser_GetPasswordResetInfoPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'PrimaryEntityId'
    /// </summary>
    public static string PrimaryEntityId = "PrimaryEntityId";
    /// <summary>
    /// Returns 'UserName'
    /// </summary>
    public static string UserName = "UserName";
    /// <summary>
    /// Returns 'Email'
    /// </summary>
    public static string Email = "Email";
    /// <summary>
    /// Returns 'ResetPasswordFlag'
    /// </summary>
    public static string ResetPasswordFlag = "ResetPasswordFlag";
    /// <summary>
    /// Returns 'LastPasswordResetDate'
    /// </summary>
    public static string LastPasswordResetDate = "LastPasswordResetDate";
    /// <summary>
    /// Returns 'PasswordResetToken'
    /// </summary>
    public static string PasswordResetToken = "PasswordResetToken";
    /// <summary>
    /// Returns 'PasswordResetTokenExpiration'
    /// </summary>
    public static string PasswordResetTokenExpiration = "PasswordResetTokenExpiration";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUser_GetPasswordResetInfoPDSA class.
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
    /// Returns '@UserName'
    /// </summary>
    public static string UserName = "@UserName";
    /// <summary>
    /// Returns '@Email'
    /// </summary>
    public static string Email = "@Email";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
