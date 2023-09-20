using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA Entity
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
    /// Clones the current InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA
    /// </summary>
    /// <returns>A cloned InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA object</returns>
    public InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA
    /// </summary>
    /// <param name="entityToClone">The InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA entity to clone</param>
    /// <returns>A cloned InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA object</returns>
    public InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA CloneEntity(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA entityToClone)
    {
      InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA newEntity = new InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA();

      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;

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
      
      props.Add(PDSAProperty.Create(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RoleId, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RoleId).IsNull == false)
        Entity.RoleId = this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RoleId).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "InputDeviceUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
