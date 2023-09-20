using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleInputOutputGroupPermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleInputOutputGroupPermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleInputOutputGroupPermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleInputOutputGroupPermissionUniquePDSA Entity
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
    /// Clones the current IsRoleInputOutputGroupPermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleInputOutputGroupPermissionUniquePDSA object</returns>
    public IsRoleInputOutputGroupPermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleInputOutputGroupPermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleInputOutputGroupPermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleInputOutputGroupPermissionUniquePDSA object</returns>
    public IsRoleInputOutputGroupPermissionUniquePDSA CloneEntity(IsRoleInputOutputGroupPermissionUniquePDSA entityToClone)
    {
      IsRoleInputOutputGroupPermissionUniquePDSA newEntity = new IsRoleInputOutputGroupPermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupPermissionUid, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_RoleInputOutputGroupPermissionUid_Header", "Role Input Output Group Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_RoleInputOutputGroupPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_RoleInputOutputGroupUid_Header", "Role Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_RoleInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupPermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupPermissionUid).Value = Entity.RoleInputOutputGroupPermissionUid;
      this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid).Value = Entity.RoleInputOutputGroupUid;
      this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupPermissionUid).IsNull == false)
        Entity.RoleInputOutputGroupPermissionUid = this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid).IsNull == false)
        Entity.RoleInputOutputGroupUid = this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleInputOutputGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleInputOutputGroupPermissionUniquePDSA class.
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
    /// Returns '@RoleInputOutputGroupPermissionUid'
    /// </summary>
    public static string RoleInputOutputGroupPermissionUid = "@RoleInputOutputGroupPermissionUid";
    /// <summary>
    /// Returns '@RoleInputOutputGroupUid'
    /// </summary>
    public static string RoleInputOutputGroupUid = "@RoleInputOutputGroupUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleInputOutputGroupPermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleInputOutputGroupPermissionUid'
    /// </summary>
    public static string RoleInputOutputGroupPermissionUid = "@RoleInputOutputGroupPermissionUid";
    /// <summary>
    /// Returns '@RoleInputOutputGroupUid'
    /// </summary>
    public static string RoleInputOutputGroupUid = "@RoleInputOutputGroupUid";
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
