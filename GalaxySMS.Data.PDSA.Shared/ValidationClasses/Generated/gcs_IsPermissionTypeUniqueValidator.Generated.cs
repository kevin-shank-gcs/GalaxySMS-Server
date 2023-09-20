using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsPermissionTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsPermissionTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsPermissionTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsPermissionTypeUniquePDSA Entity
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
    /// Clones the current gcs_IsPermissionTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsPermissionTypeUniquePDSA object</returns>
    public gcs_IsPermissionTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsPermissionTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsPermissionTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsPermissionTypeUniquePDSA object</returns>
    public gcs_IsPermissionTypeUniquePDSA CloneEntity(gcs_IsPermissionTypeUniquePDSA entityToClone)
    {
      gcs_IsPermissionTypeUniquePDSA newEntity = new gcs_IsPermissionTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeId, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_PermissionTypeId_Header", "Permission Type Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_PermissionTypeId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeCode, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_PermissionTypeCode_Header", "Permission Type Code"), false, typeof(short), 0, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_PermissionTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsPermissionTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeId).Value = Entity.PermissionTypeId;
      this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeCode).Value = Entity.PermissionTypeCode;
      this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeId).IsNull == false)
        Entity.PermissionTypeId = this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeCode).IsNull == false)
        Entity.PermissionTypeCode = this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.PermissionTypeCode).GetAsShort();
      if(this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Display).GetAsString();
      if(this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsPermissionTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsPermissionTypeUniquePDSA class.
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
    /// Returns '@PermissionTypeId'
    /// </summary>
    public static string PermissionTypeId = "@PermissionTypeId";
    /// <summary>
    /// Returns '@PermissionTypeCode'
    /// </summary>
    public static string PermissionTypeCode = "@PermissionTypeCode";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsPermissionTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PermissionTypeId'
    /// </summary>
    public static string PermissionTypeId = "@PermissionTypeId";
    /// <summary>
    /// Returns '@PermissionTypeCode'
    /// </summary>
    public static string PermissionTypeCode = "@PermissionTypeCode";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
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
