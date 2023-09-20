using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleAccessPortalPermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleAccessPortalPermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleAccessPortalPermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleAccessPortalPermissionUniquePDSA Entity
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
    /// Clones the current IsRoleAccessPortalPermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleAccessPortalPermissionUniquePDSA object</returns>
    public IsRoleAccessPortalPermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleAccessPortalPermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleAccessPortalPermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleAccessPortalPermissionUniquePDSA object</returns>
    public IsRoleAccessPortalPermissionUniquePDSA CloneEntity(IsRoleAccessPortalPermissionUniquePDSA entityToClone)
    {
      IsRoleAccessPortalPermissionUniquePDSA newEntity = new IsRoleAccessPortalPermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalPermissionUid, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_RoleAccessPortalPermissionUid_Header", "Role Access Portal Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_RoleAccessPortalPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalUid, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_RoleAccessPortalUid_Header", "Role Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_RoleAccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleAccessPortalPermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalPermissionUid).Value = Entity.RoleAccessPortalPermissionUid;
      this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalUid).Value = Entity.RoleAccessPortalUid;
      this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalPermissionUid).IsNull == false)
        Entity.RoleAccessPortalPermissionUid = this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalUid).IsNull == false)
        Entity.RoleAccessPortalUid = this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RoleAccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleAccessPortalPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleAccessPortalPermissionUniquePDSA class.
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
    /// Returns '@RoleAccessPortalPermissionUid'
    /// </summary>
    public static string RoleAccessPortalPermissionUid = "@RoleAccessPortalPermissionUid";
    /// <summary>
    /// Returns '@RoleAccessPortalUid'
    /// </summary>
    public static string RoleAccessPortalUid = "@RoleAccessPortalUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleAccessPortalPermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleAccessPortalPermissionUid'
    /// </summary>
    public static string RoleAccessPortalPermissionUid = "@RoleAccessPortalPermissionUid";
    /// <summary>
    /// Returns '@RoleAccessPortalUid'
    /// </summary>
    public static string RoleAccessPortalUid = "@RoleAccessPortalUid";
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
