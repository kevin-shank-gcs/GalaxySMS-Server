using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleInputDevicePermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleInputDevicePermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleInputDevicePermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleInputDevicePermissionUniquePDSA Entity
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
    /// Clones the current IsRoleInputDevicePermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleInputDevicePermissionUniquePDSA object</returns>
    public IsRoleInputDevicePermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleInputDevicePermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleInputDevicePermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleInputDevicePermissionUniquePDSA object</returns>
    public IsRoleInputDevicePermissionUniquePDSA CloneEntity(IsRoleInputDevicePermissionUniquePDSA entityToClone)
    {
      IsRoleInputDevicePermissionUniquePDSA newEntity = new IsRoleInputDevicePermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDevicePermissionUid, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_RoleInputDevicePermissionUid_Header", "Role Input Device Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_RoleInputDevicePermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDeviceUid, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_RoleInputDeviceUid_Header", "Role Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_RoleInputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleInputDevicePermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDevicePermissionUid).Value = Entity.RoleInputDevicePermissionUid;
      this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDeviceUid).Value = Entity.RoleInputDeviceUid;
      this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDevicePermissionUid).IsNull == false)
        Entity.RoleInputDevicePermissionUid = this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDevicePermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDeviceUid).IsNull == false)
        Entity.RoleInputDeviceUid = this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RoleInputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleInputDevicePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleInputDevicePermissionUniquePDSA class.
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
    /// Returns '@RoleInputDevicePermissionUid'
    /// </summary>
    public static string RoleInputDevicePermissionUid = "@RoleInputDevicePermissionUid";
    /// <summary>
    /// Returns '@RoleInputDeviceUid'
    /// </summary>
    public static string RoleInputDeviceUid = "@RoleInputDeviceUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleInputDevicePermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleInputDevicePermissionUid'
    /// </summary>
    public static string RoleInputDevicePermissionUid = "@RoleInputDevicePermissionUid";
    /// <summary>
    /// Returns '@RoleInputDeviceUid'
    /// </summary>
    public static string RoleInputDeviceUid = "@RoleInputDeviceUid";
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
