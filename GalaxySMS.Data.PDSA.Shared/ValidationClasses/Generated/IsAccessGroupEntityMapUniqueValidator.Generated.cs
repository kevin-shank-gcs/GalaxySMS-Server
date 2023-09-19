using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessGroupEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessGroupEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessGroupEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessGroupEntityMapUniquePDSA Entity
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
    /// Clones the current IsAccessGroupEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessGroupEntityMapUniquePDSA object</returns>
    public IsAccessGroupEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessGroupEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessGroupEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessGroupEntityMapUniquePDSA object</returns>
    public IsAccessGroupEntityMapUniquePDSA CloneEntity(IsAccessGroupEntityMapUniquePDSA entityToClone)
    {
      IsAccessGroupEntityMapUniquePDSA newEntity = new IsAccessGroupEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupEntityMapUid, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_AccessGroupEntityMapUid_Header", "Access Group Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_AccessGroupEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupUid, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessGroupEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupEntityMapUid).Value = Entity.AccessGroupEntityMapUid;
      this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupEntityMapUid).IsNull == false)
        Entity.AccessGroupEntityMapUid = this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.AccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessGroupEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessGroupEntityMapUniquePDSA class.
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
    /// Returns '@AccessGroupEntityMapUid'
    /// </summary>
    public static string AccessGroupEntityMapUid = "@AccessGroupEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessGroupEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessGroupEntityMapUid'
    /// </summary>
    public static string AccessGroupEntityMapUid = "@AccessGroupEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
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
