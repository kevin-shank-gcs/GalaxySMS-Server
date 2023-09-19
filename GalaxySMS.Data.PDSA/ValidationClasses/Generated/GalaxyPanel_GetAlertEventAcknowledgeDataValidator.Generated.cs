using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyPanel_GetAlertEventAcknowledgeDataPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanel_GetAlertEventAcknowledgeDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanel_GetAlertEventAcknowledgeDataPDSA Entity
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
    /// Clones the current GalaxyPanel_GetAlertEventAcknowledgeDataPDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanel_GetAlertEventAcknowledgeDataPDSA object</returns>
    public GalaxyPanel_GetAlertEventAcknowledgeDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanel_GetAlertEventAcknowledgeDataPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanel_GetAlertEventAcknowledgeDataPDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanel_GetAlertEventAcknowledgeDataPDSA object</returns>
    public GalaxyPanel_GetAlertEventAcknowledgeDataPDSA CloneEntity(GalaxyPanel_GetAlertEventAcknowledgeDataPDSA entityToClone)
    {
      GalaxyPanel_GetAlertEventAcknowledgeDataPDSA newEntity = new GalaxyPanel_GetAlertEventAcknowledgeDataPDSA();

      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.GalaxyPanelAlertEventTypeUid = entityToClone.GalaxyPanelAlertEventTypeUid;
      newEntity.Tag = entityToClone.Tag;
      newEntity.CanHaveAudio = entityToClone.CanHaveAudio;
      newEntity.CanHaveInstructions = entityToClone.CanHaveInstructions;
      newEntity.CanHaveSchedule = entityToClone.CanHaveSchedule;
      newEntity.AcknowledgeTimeScheduleUid = entityToClone.AcknowledgeTimeScheduleUid;
      newEntity.AcknowledgePriority = entityToClone.AcknowledgePriority;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.ResponseInstructions = entityToClone.ResponseInstructions;
      newEntity.UserInstructionsNoteUid = entityToClone.UserInstructionsNoteUid;
      newEntity.AudioBinaryResourceUid = entityToClone.AudioBinaryResourceUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ScheduleTypeCode = entityToClone.ScheduleTypeCode;

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
      
      props.Add(PDSAProperty.Create(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyPanel_GetAlertEventAcknowledgeDataPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyPanel_GetAlertEventAcknowledgeDataPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyPanel_GetAlertEventAcknowledgeDataPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyPanel_GetAlertEventAcknowledgeDataPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      this.Properties.GetByName(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = this.Properties.GetByName(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.GalaxyPanelUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyPanel_GetAlertEventAcknowledgeDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanel_GetAlertEventAcknowledgeDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'GalaxyPanelAlertEventTypeUid'
    /// </summary>
    public static string GalaxyPanelAlertEventTypeUid = "GalaxyPanelAlertEventTypeUid";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'CanHaveAudio'
    /// </summary>
    public static string CanHaveAudio = "CanHaveAudio";
    /// <summary>
    /// Returns 'CanHaveInstructions'
    /// </summary>
    public static string CanHaveInstructions = "CanHaveInstructions";
    /// <summary>
    /// Returns 'CanHaveSchedule'
    /// </summary>
    public static string CanHaveSchedule = "CanHaveSchedule";
    /// <summary>
    /// Returns 'AcknowledgeTimeScheduleUid'
    /// </summary>
    public static string AcknowledgeTimeScheduleUid = "AcknowledgeTimeScheduleUid";
    /// <summary>
    /// Returns 'AcknowledgePriority'
    /// </summary>
    public static string AcknowledgePriority = "AcknowledgePriority";
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns 'ResponseInstructions'
    /// </summary>
    public static string ResponseInstructions = "ResponseInstructions";
    /// <summary>
    /// Returns 'UserInstructionsNoteUid'
    /// </summary>
    public static string UserInstructionsNoteUid = "UserInstructionsNoteUid";
    /// <summary>
    /// Returns 'AudioBinaryResourceUid'
    /// </summary>
    public static string AudioBinaryResourceUid = "AudioBinaryResourceUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "ScheduleTypeCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanel_GetAlertEventAcknowledgeDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
