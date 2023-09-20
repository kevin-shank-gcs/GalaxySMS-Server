using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleMercScpGroupPermissionUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleMercScpGroupPermissionUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleMercScpGroupPermissionUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleMercScpGroupPermissionUniquePDSA Entity
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
    /// Clones the current IsRoleMercScpGroupPermissionUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleMercScpGroupPermissionUniquePDSA object</returns>
    public IsRoleMercScpGroupPermissionUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleMercScpGroupPermissionUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleMercScpGroupPermissionUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleMercScpGroupPermissionUniquePDSA object</returns>
    public IsRoleMercScpGroupPermissionUniquePDSA CloneEntity(IsRoleMercScpGroupPermissionUniquePDSA entityToClone)
    {
      IsRoleMercScpGroupPermissionUniquePDSA newEntity = new IsRoleMercScpGroupPermissionUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupPermissionUid, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_RoleMercScpGroupPermissionUid_Header", "Role Merc Scp Group Permission Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_RoleMercScpGroupPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_RoleMercScpGroupUid_Header", "Role Merc Scp Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_RoleMercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleMercScpGroupPermissionUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupPermissionUid).Value = Entity.RoleMercScpGroupPermissionUid;
      this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).Value = Entity.RoleMercScpGroupUid;
      this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupPermissionUid).IsNull == false)
        Entity.RoleMercScpGroupPermissionUid = this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupPermissionUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).IsNull == false)
        Entity.RoleMercScpGroupUid = this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleMercScpGroupPermissionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleMercScpGroupPermissionUniquePDSA class.
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
    /// Returns '@RoleMercScpGroupPermissionUid'
    /// </summary>
    public static string RoleMercScpGroupPermissionUid = "@RoleMercScpGroupPermissionUid";
    /// <summary>
    /// Returns '@RoleMercScpGroupUid'
    /// </summary>
    public static string RoleMercScpGroupUid = "@RoleMercScpGroupUid";
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
    /// Contains static string properties that represent the name of each property in the IsRoleMercScpGroupPermissionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleMercScpGroupPermissionUid'
    /// </summary>
    public static string RoleMercScpGroupPermissionUid = "@RoleMercScpGroupPermissionUid";
    /// <summary>
    /// Returns '@RoleMercScpGroupUid'
    /// </summary>
    public static string RoleMercScpGroupUid = "@RoleMercScpGroupUid";
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
