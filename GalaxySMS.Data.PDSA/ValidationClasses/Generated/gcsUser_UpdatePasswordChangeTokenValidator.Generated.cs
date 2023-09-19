using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsUser_UpdatePasswordChangeTokenPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsUser_UpdatePasswordChangeTokenPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsUser_UpdatePasswordChangeTokenPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsUser_UpdatePasswordChangeTokenPDSA Entity
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
    /// Clones the current gcsUser_UpdatePasswordChangeTokenPDSA
    /// </summary>
    /// <returns>A cloned gcsUser_UpdatePasswordChangeTokenPDSA object</returns>
    public gcsUser_UpdatePasswordChangeTokenPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsUser_UpdatePasswordChangeTokenPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsUser_UpdatePasswordChangeTokenPDSA entity to clone</param>
    /// <returns>A cloned gcsUser_UpdatePasswordChangeTokenPDSA object</returns>
    public gcsUser_UpdatePasswordChangeTokenPDSA CloneEntity(gcsUser_UpdatePasswordChangeTokenPDSA entityToClone)
    {
      gcsUser_UpdatePasswordChangeTokenPDSA newEntity = new gcsUser_UpdatePasswordChangeTokenPDSA();


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
      
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetToken, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_PasswordResetToken_Header", "Password Reset Token"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_PasswordResetToken_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetTokenExpiration, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_PasswordResetTokenExpiration_Header", "Password Reset Token Expiration"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_PasswordResetTokenExpiration_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.TempPassword, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_TempPassword_Header", "Temp Password"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_TempPassword_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserName, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_UserName_Header", "User Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_UserName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordChangeTokenPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetToken).Value = Entity.PasswordResetToken;
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetTokenExpiration).Value = Entity.PasswordResetTokenExpiration;
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.TempPassword).Value = Entity.TempPassword;
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserName).Value = Entity.UserName;
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetToken).IsNull == false)
        Entity.PasswordResetToken = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetToken).GetAsString();
      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetTokenExpiration).IsNull == false)
        Entity.PasswordResetTokenExpiration = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.PasswordResetTokenExpiration).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.TempPassword).IsNull == false)
        Entity.TempPassword = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.TempPassword).GetAsString();
      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserName).IsNull == false)
        Entity.UserName = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UserName).GetAsString();
      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsUser_UpdatePasswordChangeTokenPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUser_UpdatePasswordChangeTokenPDSA class.
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
    /// Returns '@PasswordResetToken'
    /// </summary>
    public static string PasswordResetToken = "@PasswordResetToken";
    /// <summary>
    /// Returns '@PasswordResetTokenExpiration'
    /// </summary>
    public static string PasswordResetTokenExpiration = "@PasswordResetTokenExpiration";
    /// <summary>
    /// Returns '@TempPassword'
    /// </summary>
    public static string TempPassword = "@TempPassword";
    /// <summary>
    /// Returns '@UserName'
    /// </summary>
    public static string UserName = "@UserName";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
