using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaDsrEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaDsrEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaDsrEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaDsrEntityMapUniquePDSA Entity
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
    /// Clones the current IsAssaDsrEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaDsrEntityMapUniquePDSA object</returns>
    public IsAssaDsrEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaDsrEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaDsrEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaDsrEntityMapUniquePDSA object</returns>
    public IsAssaDsrEntityMapUniquePDSA CloneEntity(IsAssaDsrEntityMapUniquePDSA entityToClone)
    {
      IsAssaDsrEntityMapUniquePDSA newEntity = new IsAssaDsrEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrEntityMapUid, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_AssaDsrEntityMapUid_Header", "Assa Dsr Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_AssaDsrEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrUid, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_AssaDsrUid_Header", "Assa Dsr Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_AssaDsrUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDsrEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrEntityMapUid).Value = Entity.AssaDsrEntityMapUid;
      this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrEntityMapUid).IsNull == false)
        Entity.AssaDsrEntityMapUid = this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrUid).IsNull == false)
        Entity.AssaDsrUid = this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.AssaDsrUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaDsrEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDsrEntityMapUniquePDSA class.
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
    /// Returns '@AssaDsrEntityMapUid'
    /// </summary>
    public static string AssaDsrEntityMapUid = "@AssaDsrEntityMapUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
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
    /// Contains static string properties that represent the name of each property in the IsAssaDsrEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaDsrEntityMapUid'
    /// </summary>
    public static string AssaDsrEntityMapUid = "@AssaDsrEntityMapUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
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
