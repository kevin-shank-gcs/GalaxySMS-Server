using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleSitePermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleSitePermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleSitePermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleSitePermissionUniquePDSA Entity
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
    /// Clones the current IsRoleSitePermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleSitePermissionUniquePDSA object</returns>
    public IsRoleSitePermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleSitePermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleSitePermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleSitePermissionUniquePDSA object</returns>
    public IsRoleSitePermissionUniquePDSA CloneEntity(IsRoleSitePermissionUniquePDSA entityToClone)
    {
      IsRoleSitePermissionUniquePDSA newEntity = new IsRoleSitePermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSitePermissionUid, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_RoleSitePermissionUid_Header", "Role Site Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_RoleSitePermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSiteUid, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_RoleSiteUid_Header", "Role Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_RoleSiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleSitePermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSitePermissionUid).Value = Entity.RoleSitePermissionUid;
      this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSiteUid).Value = Entity.RoleSiteUid;
      this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSitePermissionUid).IsNull == false)
        Entity.RoleSitePermissionUid = this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSitePermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSiteUid).IsNull == false)
        Entity.RoleSiteUid = this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RoleSiteUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleSitePermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleSitePermissionUniquePDSA class.
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
    /// Returns '@RoleSitePermissionUid'
    /// </summary>
    public static string RoleSitePermissionUid = "@RoleSitePermissionUid";
    /// <summary>
    /// Returns '@RoleSiteUid'
    /// </summary>
    public static string RoleSiteUid = "@RoleSiteUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleSitePermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleSitePermissionUid'
    /// </summary>
    public static string RoleSitePermissionUid = "@RoleSitePermissionUid";
    /// <summary>
    /// Returns '@RoleSiteUid'
    /// </summary>
    public static string RoleSiteUid = "@RoleSiteUid";
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
