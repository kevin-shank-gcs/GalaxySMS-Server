using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsRolePermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsRolePermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsRolePermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsRolePermissionUniquePDSA Entity
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
    /// Clones the current gcs_IsRolePermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsRolePermissionUniquePDSA object</returns>
    public gcs_IsRolePermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsRolePermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsRolePermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsRolePermissionUniquePDSA object</returns>
    public gcs_IsRolePermissionUniquePDSA CloneEntity(gcs_IsRolePermissionUniquePDSA entityToClone)
    {
      gcs_IsRolePermissionUniquePDSA newEntity = new gcs_IsRolePermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RolePermissionId, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_RolePermissionId_Header", "Role Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_RolePermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RoleId, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsRolePermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RolePermissionId).Value = Entity.RolePermissionId;
      this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RolePermissionId).IsNull == false)
        Entity.RolePermissionId = this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RolePermissionId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RoleId).IsNull == false)
        Entity.RoleId = this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RoleId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsRolePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsRolePermissionUniquePDSA class.
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
    /// Returns '@RolePermissionId'
    /// </summary>
    public static string RolePermissionId = "@RolePermissionId";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@PermissionId'
    /// </summary>
    public static string PermissionId = "@PermissionId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsRolePermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RolePermissionId'
    /// </summary>
    public static string RolePermissionId = "@RolePermissionId";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@PermissionId'
    /// </summary>
    public static string PermissionId = "@PermissionId";
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
