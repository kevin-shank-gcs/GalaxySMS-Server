using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsRoleInputOutputGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsRoleInputOutputGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsRoleInputOutputGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsRoleInputOutputGroupUniquePDSA Entity
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
    /// Clones the current IsRoleInputOutputGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsRoleInputOutputGroupUniquePDSA object</returns>
    public IsRoleInputOutputGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsRoleInputOutputGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsRoleInputOutputGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsRoleInputOutputGroupUniquePDSA object</returns>
    public IsRoleInputOutputGroupUniquePDSA CloneEntity(IsRoleInputOutputGroupUniquePDSA entityToClone)
    {
      IsRoleInputOutputGroupUniquePDSA newEntity = new IsRoleInputOutputGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_RoleInputOutputGroupUid_Header", "Role Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_RoleInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleId, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.InputOutputGroupUid, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsRoleInputOutputGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid).Value = Entity.RoleInputOutputGroupUid;
      this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid).IsNull == false)
        Entity.RoleInputOutputGroupUid = this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleInputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleId).IsNull == false)
        Entity.RoleId = this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RoleId).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.InputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsRoleInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleInputOutputGroupUniquePDSA class.
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
    /// Returns '@RoleInputOutputGroupUid'
    /// </summary>
    public static string RoleInputOutputGroupUid = "@RoleInputOutputGroupUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleInputOutputGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleInputOutputGroupUid'
    /// </summary>
    public static string RoleInputOutputGroupUid = "@RoleInputOutputGroupUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
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
