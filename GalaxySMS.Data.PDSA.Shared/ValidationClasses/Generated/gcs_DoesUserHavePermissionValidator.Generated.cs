using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_DoesUserHavePermissionPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_DoesUserHavePermissionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_DoesUserHavePermissionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_DoesUserHavePermissionPDSA Entity
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
    /// Clones the current gcs_DoesUserHavePermissionPDSA
    /// </summary>
    /// <returns>A cloned gcs_DoesUserHavePermissionPDSA object</returns>
    public gcs_DoesUserHavePermissionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_DoesUserHavePermissionPDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_DoesUserHavePermissionPDSA entity to clone</param>
    /// <returns>A cloned gcs_DoesUserHavePermissionPDSA object</returns>
    public gcs_DoesUserHavePermissionPDSA CloneEntity(gcs_DoesUserHavePermissionPDSA entityToClone)
    {
      gcs_DoesUserHavePermissionPDSA newEntity = new gcs_DoesUserHavePermissionPDSA();

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
      
      props.Add(PDSAProperty.Create(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.ApplicationId, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_ApplicationId_Header", "Application Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_DoesUserHavePermissionPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.ApplicationId).GetAsGuid();
      if(this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_DoesUserHavePermissionPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_DoesUserHavePermissionPDSA class.
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
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
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
    /// Contains static string properties that represent the name of each property in the gcs_DoesUserHavePermissionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
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
