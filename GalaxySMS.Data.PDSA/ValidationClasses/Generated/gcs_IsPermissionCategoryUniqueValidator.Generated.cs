using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsPermissionCategoryUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsPermissionCategoryUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsPermissionCategoryUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsPermissionCategoryUniquePDSA Entity
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
    /// Clones the current gcs_IsPermissionCategoryUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsPermissionCategoryUniquePDSA object</returns>
    public gcs_IsPermissionCategoryUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsPermissionCategoryUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsPermissionCategoryUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsPermissionCategoryUniquePDSA object</returns>
    public gcs_IsPermissionCategoryUniquePDSA CloneEntity(gcs_IsPermissionCategoryUniquePDSA entityToClone)
    {
      gcs_IsPermissionCategoryUniquePDSA newEntity = new gcs_IsPermissionCategoryUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.PermissionCategoryId, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_PermissionCategoryId_Header", "Permission Category Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_PermissionCategoryId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.ApplicationId, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_ApplicationId_Header", "Application Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.CategoryName, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_CategoryName_Header", "Category Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_CategoryName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsPermissionCategoryUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.PermissionCategoryId).Value = Entity.PermissionCategoryId;
      this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.CategoryName).Value = Entity.CategoryName;
      this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.PermissionCategoryId).IsNull == false)
        Entity.PermissionCategoryId = this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.PermissionCategoryId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.ApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.CategoryName).IsNull == false)
        Entity.CategoryName = this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.CategoryName).GetAsString();
      if(this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsPermissionCategoryUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsPermissionCategoryUniquePDSA class.
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
    /// Returns '@PermissionCategoryId'
    /// </summary>
    public static string PermissionCategoryId = "@PermissionCategoryId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@CategoryName'
    /// </summary>
    public static string CategoryName = "@CategoryName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsPermissionCategoryUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PermissionCategoryId'
    /// </summary>
    public static string PermissionCategoryId = "@PermissionCategoryId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@CategoryName'
    /// </summary>
    public static string CategoryName = "@CategoryName";
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
