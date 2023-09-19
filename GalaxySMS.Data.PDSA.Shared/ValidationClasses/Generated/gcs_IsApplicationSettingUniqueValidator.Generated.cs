using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsApplicationSettingUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsApplicationSettingUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsApplicationSettingUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsApplicationSettingUniquePDSA Entity
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
    /// Clones the current gcs_IsApplicationSettingUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsApplicationSettingUniquePDSA object</returns>
    public gcs_IsApplicationSettingUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsApplicationSettingUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsApplicationSettingUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsApplicationSettingUniquePDSA object</returns>
    public gcs_IsApplicationSettingUniquePDSA CloneEntity(gcs_IsApplicationSettingUniquePDSA entityToClone)
    {
      gcs_IsApplicationSettingUniquePDSA newEntity = new gcs_IsApplicationSettingUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationSettingId, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_ApplicationSettingId_Header", "Application Setting Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_ApplicationSettingId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationId, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_ApplicationId_Header", "Application Id"), true, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Category, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_Category_Header", "Category"), true, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_Category_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.SettingKey, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_SettingKey_Header", "Setting Key"), true, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsApplicationSettingUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationSettingId).Value = Entity.ApplicationSettingId;
      this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Category).Value = Entity.Category;
      this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.SettingKey).Value = Entity.SettingKey;
      this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationSettingId).IsNull == false)
        Entity.ApplicationSettingId = this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationSettingId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.ApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Category).IsNull == false)
        Entity.Category = this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Category).GetAsString();
      if(this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.SettingKey).IsNull == false)
        Entity.SettingKey = this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.SettingKey).GetAsString();
      if(this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsApplicationSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsApplicationSettingUniquePDSA class.
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
    /// Returns '@ApplicationSettingId'
    /// </summary>
    public static string ApplicationSettingId = "@ApplicationSettingId";
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
    /// Contains static string properties that represent the name of each property in the gcs_IsApplicationSettingUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ApplicationSettingId'
    /// </summary>
    public static string ApplicationSettingId = "@ApplicationSettingId";
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
