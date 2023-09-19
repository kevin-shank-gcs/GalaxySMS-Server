using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputDevice_GetUserPermissionPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDevice_GetUserPermissionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDevice_GetUserPermissionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDevice_GetUserPermissionPDSA Entity
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
    /// Clones the current InputDevice_GetUserPermissionPDSA
    /// </summary>
    /// <returns>A cloned InputDevice_GetUserPermissionPDSA object</returns>
    public InputDevice_GetUserPermissionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDevice_GetUserPermissionPDSA
    /// </summary>
    /// <param name="entityToClone">The InputDevice_GetUserPermissionPDSA entity to clone</param>
    /// <returns>A cloned InputDevice_GetUserPermissionPDSA object</returns>
    public InputDevice_GetUserPermissionPDSA CloneEntity(InputDevice_GetUserPermissionPDSA entityToClone)
    {
      InputDevice_GetUserPermissionPDSA newEntity = new InputDevice_GetUserPermissionPDSA();

      newEntity.DisplayName = entityToClone.DisplayName;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.ApplicationName = entityToClone.ApplicationName;
      newEntity.RoleName = entityToClone.RoleName;
      newEntity.PermissionName = entityToClone.PermissionName;
      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
      newEntity.InputName = entityToClone.InputName;
      newEntity.PermissionId = entityToClone.PermissionId;

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
      
      props.Add(PDSAProperty.Create(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.InputDeviceUid, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputDevice_GetUserPermissionPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.InputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId).IsNull == false)
        Entity.PermissionId = this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetUserPermissionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DisplayName'
    /// </summary>
    public static string DisplayName = "DisplayName";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'ApplicationName'
    /// </summary>
    public static string ApplicationName = "ApplicationName";
    /// <summary>
    /// Returns 'RoleName'
    /// </summary>
    public static string RoleName = "RoleName";
    /// <summary>
    /// Returns 'PermissionName'
    /// </summary>
    public static string PermissionName = "PermissionName";
    /// <summary>
    /// Returns 'InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "InputDeviceUid";
    /// <summary>
    /// Returns 'InputName'
    /// </summary>
    public static string InputName = "InputName";
    /// <summary>
    /// Returns 'PermissionId'
    /// </summary>
    public static string PermissionId = "PermissionId";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetUserPermissionPDSA class.
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
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
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
  }
}
