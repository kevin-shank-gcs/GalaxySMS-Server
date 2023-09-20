using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleClusterPermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleClusterPermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleClusterPermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleClusterPermissionUniquePDSA Entity
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
    /// Clones the current IsRoleClusterPermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleClusterPermissionUniquePDSA object</returns>
    public IsRoleClusterPermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleClusterPermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleClusterPermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleClusterPermissionUniquePDSA object</returns>
    public IsRoleClusterPermissionUniquePDSA CloneEntity(IsRoleClusterPermissionUniquePDSA entityToClone)
    {
      IsRoleClusterPermissionUniquePDSA newEntity = new IsRoleClusterPermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterPermissionUid, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_RoleClusterPermissionUid_Header", "Role Cluster Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_RoleClusterPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterUid, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_RoleClusterUid_Header", "Role Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_RoleClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleClusterPermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterPermissionUid).Value = Entity.RoleClusterPermissionUid;
      this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterUid).Value = Entity.RoleClusterUid;
      this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterPermissionUid).IsNull == false)
        Entity.RoleClusterPermissionUid = this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterUid).IsNull == false)
        Entity.RoleClusterUid = this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RoleClusterUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleClusterPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleClusterPermissionUniquePDSA class.
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
    /// Returns '@RoleClusterPermissionUid'
    /// </summary>
    public static string RoleClusterPermissionUid = "@RoleClusterPermissionUid";
    /// <summary>
    /// Returns '@RoleClusterUid'
    /// </summary>
    public static string RoleClusterUid = "@RoleClusterUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleClusterPermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleClusterPermissionUid'
    /// </summary>
    public static string RoleClusterPermissionUid = "@RoleClusterPermissionUid";
    /// <summary>
    /// Returns '@RoleClusterUid'
    /// </summary>
    public static string RoleClusterUid = "@RoleClusterUid";
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
