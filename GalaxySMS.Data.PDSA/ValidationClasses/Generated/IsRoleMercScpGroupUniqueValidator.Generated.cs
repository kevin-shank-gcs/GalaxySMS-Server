using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleMercScpGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleMercScpGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleMercScpGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleMercScpGroupUniquePDSA Entity
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
    /// Clones the current IsRoleMercScpGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleMercScpGroupUniquePDSA object</returns>
    public IsRoleMercScpGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleMercScpGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleMercScpGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleMercScpGroupUniquePDSA object</returns>
    public IsRoleMercScpGroupUniquePDSA CloneEntity(IsRoleMercScpGroupUniquePDSA entityToClone)
    {
      IsRoleMercScpGroupUniquePDSA newEntity = new IsRoleMercScpGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_RoleMercScpGroupUid_Header", "Role Merc Scp Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_RoleMercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_MercScpGroupUid_Header", "Merc Scp Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_MercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).Value = Entity.RoleMercScpGroupUid;
      this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).IsNull == false)
        Entity.RoleMercScpGroupUid = this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId).IsNull == false)
        Entity.RoleId = this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).IsNull == false)
        Entity.MercScpGroupUid = this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleMercScpGroupUniquePDSA class.
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
    /// Returns '@RoleMercScpGroupUid'
    /// </summary>
    public static string RoleMercScpGroupUid = "@RoleMercScpGroupUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleMercScpGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleMercScpGroupUid'
    /// </summary>
    public static string RoleMercScpGroupUid = "@RoleMercScpGroupUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
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
