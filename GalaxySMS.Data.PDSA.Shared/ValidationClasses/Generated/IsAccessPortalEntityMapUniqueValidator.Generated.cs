using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalEntityMapUniquePDSA Entity
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
    /// Clones the current IsAccessPortalEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalEntityMapUniquePDSA object</returns>
    public IsAccessPortalEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalEntityMapUniquePDSA object</returns>
    public IsAccessPortalEntityMapUniquePDSA CloneEntity(IsAccessPortalEntityMapUniquePDSA entityToClone)
    {
      IsAccessPortalEntityMapUniquePDSA newEntity = new IsAccessPortalEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalEntityMapUid, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_AccessPortalEntityMapUid_Header", "Access Portal Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_AccessPortalEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalEntityMapUid).Value = Entity.AccessPortalEntityMapUid;
      this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalEntityMapUid).IsNull == false)
        Entity.AccessPortalEntityMapUid = this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalEntityMapUniquePDSA class.
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
    /// Returns '@AccessPortalEntityMapUid'
    /// </summary>
    public static string AccessPortalEntityMapUid = "@AccessPortalEntityMapUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalEntityMapUid'
    /// </summary>
    public static string AccessPortalEntityMapUid = "@AccessPortalEntityMapUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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
