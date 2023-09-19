using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleRegionPermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleRegionPermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleRegionPermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleRegionPermissionUniquePDSA Entity
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
    /// Clones the current IsRoleRegionPermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleRegionPermissionUniquePDSA object</returns>
    public IsRoleRegionPermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleRegionPermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleRegionPermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleRegionPermissionUniquePDSA object</returns>
    public IsRoleRegionPermissionUniquePDSA CloneEntity(IsRoleRegionPermissionUniquePDSA entityToClone)
    {
      IsRoleRegionPermissionUniquePDSA newEntity = new IsRoleRegionPermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionPermissionUid, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_RoleRegionPermissionUid_Header", "Role Region Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_RoleRegionPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionUid, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_RoleRegionUid_Header", "Role Region Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_RoleRegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleRegionPermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionPermissionUid).Value = Entity.RoleRegionPermissionUid;
      this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionUid).Value = Entity.RoleRegionUid;
      this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionPermissionUid).IsNull == false)
        Entity.RoleRegionPermissionUid = this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionUid).IsNull == false)
        Entity.RoleRegionUid = this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RoleRegionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleRegionPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleRegionPermissionUniquePDSA class.
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
    /// Returns '@RoleRegionPermissionUid'
    /// </summary>
    public static string RoleRegionPermissionUid = "@RoleRegionPermissionUid";
    /// <summary>
    /// Returns '@RoleRegionUid'
    /// </summary>
    public static string RoleRegionUid = "@RoleRegionUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleRegionPermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleRegionPermissionUid'
    /// </summary>
    public static string RoleRegionPermissionUid = "@RoleRegionPermissionUid";
    /// <summary>
    /// Returns '@RoleRegionUid'
    /// </summary>
    public static string RoleRegionUid = "@RoleRegionUid";
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
