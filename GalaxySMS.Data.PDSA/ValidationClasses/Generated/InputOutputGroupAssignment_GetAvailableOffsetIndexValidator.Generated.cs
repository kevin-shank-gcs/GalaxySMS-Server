using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA Entity
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
    /// Clones the current InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA
    /// </summary>
    /// <returns>A cloned InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA object</returns>
    public InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA
    /// </summary>
    /// <param name="entityToClone">The InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA entity to clone</param>
    /// <returns>A cloned InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA object</returns>
    public InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA CloneEntity(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA entityToClone)
    {
      InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA newEntity = new InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA();

      newEntity.InputOutputGroupAssignmentUid = entityToClone.InputOutputGroupAssignmentUid;
      newEntity.OffsetIndex = entityToClone.OffsetIndex;

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
      
      props.Add(PDSAProperty.Create(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputOutputGroupUid, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.AccessPortalAlertEventUid, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_AccessPortalAlertEventUid_Header", "Access Portal Alert Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_AccessPortalAlertEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputDeviceAlertEventUid, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_InputDeviceAlertEventUid_Header", "Input Device Alert Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_InputDeviceAlertEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.GalaxyPanelAlertEventUid, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_GalaxyPanelAlertEventUid_Header", "Galaxy Panel Alert Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_GalaxyPanelAlertEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.AccessPortalAlertEventUid).Value = Entity.AccessPortalAlertEventUid;
      this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputDeviceAlertEventUid).Value = Entity.InputDeviceAlertEventUid;
      this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.GalaxyPanelAlertEventUid).Value = Entity.GalaxyPanelAlertEventUid;
      this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.AccessPortalAlertEventUid).IsNull == false)
        Entity.AccessPortalAlertEventUid = this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.AccessPortalAlertEventUid).GetAsGuid();
      if(this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputDeviceAlertEventUid).IsNull == false)
        Entity.InputDeviceAlertEventUid = this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.InputDeviceAlertEventUid).GetAsGuid();
      if(this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.GalaxyPanelAlertEventUid).IsNull == false)
        Entity.GalaxyPanelAlertEventUid = this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.GalaxyPanelAlertEventUid).GetAsGuid();
      if(this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputOutputGroupAssignmentUid'
    /// </summary>
    public static string InputOutputGroupAssignmentUid = "InputOutputGroupAssignmentUid";
    /// <summary>
    /// Returns 'OffsetIndex'
    /// </summary>
    public static string OffsetIndex = "OffsetIndex";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@AccessPortalAlertEventUid'
    /// </summary>
    public static string AccessPortalAlertEventUid = "@AccessPortalAlertEventUid";
    /// <summary>
    /// Returns '@InputDeviceAlertEventUid'
    /// </summary>
    public static string InputDeviceAlertEventUid = "@InputDeviceAlertEventUid";
    /// <summary>
    /// Returns '@GalaxyPanelAlertEventUid'
    /// </summary>
    public static string GalaxyPanelAlertEventUid = "@GalaxyPanelAlertEventUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupAssignment_GetAvailableOffsetIndexPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@AccessPortalAlertEventUid'
    /// </summary>
    public static string AccessPortalAlertEventUid = "@AccessPortalAlertEventUid";
    /// <summary>
    /// Returns '@InputDeviceAlertEventUid'
    /// </summary>
    public static string InputDeviceAlertEventUid = "@InputDeviceAlertEventUid";
    /// <summary>
    /// Returns '@GalaxyPanelAlertEventUid'
    /// </summary>
    public static string GalaxyPanelAlertEventUid = "@GalaxyPanelAlertEventUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
