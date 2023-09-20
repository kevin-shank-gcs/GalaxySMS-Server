using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsUser_UpdatePasswordPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsUser_UpdatePasswordPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsUser_UpdatePasswordPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsUser_UpdatePasswordPDSA Entity
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
    /// Clones the current gcsUser_UpdatePasswordPDSA
    /// </summary>
    /// <returns>A cloned gcsUser_UpdatePasswordPDSA object</returns>
    public gcsUser_UpdatePasswordPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsUser_UpdatePasswordPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsUser_UpdatePasswordPDSA entity to clone</param>
    /// <returns>A cloned gcsUser_UpdatePasswordPDSA object</returns>
    public gcsUser_UpdatePasswordPDSA CloneEntity(gcsUser_UpdatePasswordPDSA entityToClone)
    {
      gcsUser_UpdatePasswordPDSA newEntity = new gcsUser_UpdatePasswordPDSA();


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
      
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.Password, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_Password_Header", "Password"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_Password_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.PasswordHash, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_PasswordHash_Header", "Password Hash"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_PasswordHash_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserName, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_UserName_Header", "User Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_UserName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsUser_UpdatePasswordPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.Password).Value = Entity.Password;
      Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.PasswordHash).Value = Entity.PasswordHash;
      Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserName).Value = Entity.UserName;
      Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.Password).IsNull == false)
        Entity.Password = Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.Password).GetAsString();
      if(Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.PasswordHash).IsNull == false)
        Entity.PasswordHash = Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.PasswordHash).GetAsString();
      if(Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserName).IsNull == false)
        Entity.UserName = Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UserName).GetAsString();
      if(Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsUser_UpdatePasswordPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUser_UpdatePasswordPDSA class.
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
    /// Returns '@Password'
    /// </summary>
    public static string Password = "@Password";
    /// <summary>
    /// Returns '@PasswordHash'
    /// </summary>
    public static string PasswordHash = "@PasswordHash";
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
