using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsUserSettingUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsUserSettingUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsUserSettingUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsUserSettingUniquePDSA Entity
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
    /// Clones the current gcs_IsUserSettingUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsUserSettingUniquePDSA object</returns>
    public gcs_IsUserSettingUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsUserSettingUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsUserSettingUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsUserSettingUniquePDSA object</returns>
    public gcs_IsUserSettingUniquePDSA CloneEntity(gcs_IsUserSettingUniquePDSA entityToClone)
    {
      gcs_IsUserSettingUniquePDSA newEntity = new gcs_IsUserSettingUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_UserSettingId_Header", "User Setting Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_UserSettingId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_UserId_Header", "User Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_ApplicationId_Header", "Application Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_Category_Header", "Category"), true, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_Category_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_SettingKey_Header", "Setting Key"), true, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId).Value = Entity.UserSettingId;
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category).Value = Entity.Category;
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey).Value = Entity.SettingKey;
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId).IsNull == false)
        Entity.UserSettingId = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category).IsNull == false)
        Entity.Category = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category).GetAsString();
      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey).IsNull == false)
        Entity.SettingKey = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey).GetAsString();
      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsUserSettingUniquePDSA class.
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
    /// Returns '@UserSettingId'
    /// </summary>
    public static string UserSettingId = "@UserSettingId";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@Category'
    /// </summary>
    public static string Category = "@Category";
    /// <summary>
    /// Returns '@SettingKey'
    /// </summary>
    public static string SettingKey = "@SettingKey";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsUserSettingUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserSettingId'
    /// </summary>
    public static string UserSettingId = "@UserSettingId";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@Category'
    /// </summary>
    public static string Category = "@Category";
    /// <summary>
    /// Returns '@SettingKey'
    /// </summary>
    public static string SettingKey = "@SettingKey";
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
