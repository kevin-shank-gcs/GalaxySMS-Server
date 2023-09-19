using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsEntityUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsEntityUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsEntityUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsEntityUniquePDSA Entity
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
    /// Clones the current gcs_IsEntityUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsEntityUniquePDSA object</returns>
    public gcs_IsEntityUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsEntityUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsEntityUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsEntityUniquePDSA object</returns>
    public gcs_IsEntityUniquePDSA CloneEntity(gcs_IsEntityUniquePDSA entityToClone)
    {
      gcs_IsEntityUniquePDSA newEntity = new gcs_IsEntityUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_ParentEntityId_Header", "Parent Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_ParentEntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_EntityName_Header", "Entity Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId).Value = Entity.ParentEntityId;
      this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName).Value = Entity.EntityName;
      this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId).IsNull == false)
        Entity.ParentEntityId = this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName).IsNull == false)
        Entity.EntityName = this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName).GetAsString();
      if(this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityUniquePDSA class.
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
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ParentEntityId'
    /// </summary>
    public static string ParentEntityId = "@ParentEntityId";
    /// <summary>
    /// Returns '@EntityName'
    /// </summary>
    public static string EntityName = "@EntityName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ParentEntityId'
    /// </summary>
    public static string ParentEntityId = "@ParentEntityId";
    /// <summary>
    /// Returns '@EntityName'
    /// </summary>
    public static string EntityName = "@EntityName";
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
