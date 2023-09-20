using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsResourceStringLanguageUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsResourceStringLanguageUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsResourceStringLanguageUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsResourceStringLanguageUniquePDSA Entity
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
    /// Clones the current gcs_IsResourceStringLanguageUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsResourceStringLanguageUniquePDSA object</returns>
    public gcs_IsResourceStringLanguageUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsResourceStringLanguageUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsResourceStringLanguageUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsResourceStringLanguageUniquePDSA object</returns>
    public gcs_IsResourceStringLanguageUniquePDSA CloneEntity(gcs_IsResourceStringLanguageUniquePDSA entityToClone)
    {
      gcs_IsResourceStringLanguageUniquePDSA newEntity = new gcs_IsResourceStringLanguageUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceStringLanguageId, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_ResourceStringLanguageId_Header", "Resource String Language Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_ResourceStringLanguageId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceId, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_ResourceId_Header", "Resource Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_ResourceId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.LanguageId, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_LanguageId_Header", "Language Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_LanguageId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsResourceStringLanguageUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceStringLanguageId).Value = Entity.ResourceStringLanguageId;
      this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceId).Value = Entity.ResourceId;
      this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.LanguageId).Value = Entity.LanguageId;
      this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceStringLanguageId).IsNull == false)
        Entity.ResourceStringLanguageId = this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceStringLanguageId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceId).IsNull == false)
        Entity.ResourceId = this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.ResourceId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.LanguageId).IsNull == false)
        Entity.LanguageId = this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.LanguageId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsResourceStringLanguageUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsResourceStringLanguageUniquePDSA class.
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
    /// Returns '@ResourceStringLanguageId'
    /// </summary>
    public static string ResourceStringLanguageId = "@ResourceStringLanguageId";
    /// <summary>
    /// Returns '@ResourceId'
    /// </summary>
    public static string ResourceId = "@ResourceId";
    /// <summary>
    /// Returns '@LanguageId'
    /// </summary>
    public static string LanguageId = "@LanguageId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsResourceStringLanguageUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ResourceStringLanguageId'
    /// </summary>
    public static string ResourceStringLanguageId = "@ResourceStringLanguageId";
    /// <summary>
    /// Returns '@ResourceId'
    /// </summary>
    public static string ResourceId = "@ResourceId";
    /// <summary>
    /// Returns '@LanguageId'
    /// </summary>
    public static string LanguageId = "@LanguageId";
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
