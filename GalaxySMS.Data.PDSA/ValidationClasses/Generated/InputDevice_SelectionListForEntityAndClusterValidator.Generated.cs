using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputDevice_SelectionListForEntityAndClusterPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputDevice_SelectionListForEntityAndClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputDevice_SelectionListForEntityAndClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputDevice_SelectionListForEntityAndClusterPDSA Entity
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
    /// Clones the current InputDevice_SelectionListForEntityAndClusterPDSA
    /// </summary>
    /// <returns>A cloned InputDevice_SelectionListForEntityAndClusterPDSA object</returns>
    public InputDevice_SelectionListForEntityAndClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputDevice_SelectionListForEntityAndClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The InputDevice_SelectionListForEntityAndClusterPDSA entity to clone</param>
    /// <returns>A cloned InputDevice_SelectionListForEntityAndClusterPDSA object</returns>
    public InputDevice_SelectionListForEntityAndClusterPDSA CloneEntity(InputDevice_SelectionListForEntityAndClusterPDSA entityToClone)
    {
      InputDevice_SelectionListForEntityAndClusterPDSA newEntity = new InputDevice_SelectionListForEntityAndClusterPDSA();

      newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.InputName = entityToClone.InputName;
      newEntity.Location = entityToClone.Location;
      newEntity.BinaryResource = entityToClone.BinaryResource;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.GalaxyPanelTypeCode = entityToClone.GalaxyPanelTypeCode;
      newEntity.InterfaceBoardTypeCode = entityToClone.InterfaceBoardTypeCode;
      newEntity.InterfaceBoardModel = entityToClone.InterfaceBoardModel;
      newEntity.InterfaceBoardSectionModeCode = entityToClone.InterfaceBoardSectionModeCode;
      newEntity.ModuleTypeCode = entityToClone.ModuleTypeCode;

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
      
      props.Add(PDSAProperty.Create(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_InputDevice_SelectionListForEntityAndClusterPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_SelectionListForEntityAndClusterPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_InputDevice_SelectionListForEntityAndClusterPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputDevice_SelectionListForEntityAndClusterPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputDevice_SelectionListForEntityAndClusterPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputDevice_SelectionListForEntityAndClusterPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_SelectionListForEntityAndClusterPDSA class.
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
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'InputName'
    /// </summary>
    public static string InputName = "InputName";
    /// <summary>
    /// Returns 'Location'
    /// </summary>
    public static string Location = "Location";
    /// <summary>
    /// Returns 'BinaryResource'
    /// </summary>
    public static string BinaryResource = "BinaryResource";
    /// <summary>
    /// Returns 'ClusterTypeCode'
    /// </summary>
    public static string ClusterTypeCode = "ClusterTypeCode";
    /// <summary>
    /// Returns 'GalaxyPanelTypeCode'
    /// </summary>
    public static string GalaxyPanelTypeCode = "GalaxyPanelTypeCode";
    /// <summary>
    /// Returns 'InterfaceBoardTypeCode'
    /// </summary>
    public static string InterfaceBoardTypeCode = "InterfaceBoardTypeCode";
    /// <summary>
    /// Returns 'InterfaceBoardModel'
    /// </summary>
    public static string InterfaceBoardModel = "InterfaceBoardModel";
    /// <summary>
    /// Returns 'InterfaceBoardSectionModeCode'
    /// </summary>
    public static string InterfaceBoardSectionModeCode = "InterfaceBoardSectionModeCode";
    /// <summary>
    /// Returns 'ModuleTypeCode'
    /// </summary>
    public static string ModuleTypeCode = "ModuleTypeCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_SelectionListForEntityAndClusterPDSA class.
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
