using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessProfileEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessProfileEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessProfileEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessProfileEntityMapUniquePDSA Entity
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
    /// Clones the current IsAccessProfileEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessProfileEntityMapUniquePDSA object</returns>
    public IsAccessProfileEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessProfileEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessProfileEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessProfileEntityMapUniquePDSA object</returns>
    public IsAccessProfileEntityMapUniquePDSA CloneEntity(IsAccessProfileEntityMapUniquePDSA entityToClone)
    {
      IsAccessProfileEntityMapUniquePDSA newEntity = new IsAccessProfileEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileEntityMapUid, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_AccessProfileEntityMapUid_Header", "Access Profile Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_AccessProfileEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileUid, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_AccessProfileUid_Header", "Access Profile Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_AccessProfileUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessProfileEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileEntityMapUid).Value = Entity.AccessProfileEntityMapUid;
      this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileUid).Value = Entity.AccessProfileUid;
      this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileEntityMapUid).IsNull == false)
        Entity.AccessProfileEntityMapUid = this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileUid).IsNull == false)
        Entity.AccessProfileUid = this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.AccessProfileUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessProfileEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessProfileEntityMapUniquePDSA class.
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
    /// Returns '@AccessProfileEntityMapUid'
    /// </summary>
    public static string AccessProfileEntityMapUid = "@AccessProfileEntityMapUid";
    /// <summary>
    /// Returns '@AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "@AccessProfileUid";
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
    /// Contains static string properties that represent the name of each property in the IsAccessProfileEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessProfileEntityMapUid'
    /// </summary>
    public static string AccessProfileEntityMapUid = "@AccessProfileEntityMapUid";
    /// <summary>
    /// Returns '@AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "@AccessProfileUid";
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
