using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetLoadDataCountsForGalaxyPanelUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetLoadDataCountsForGalaxyPanelUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetLoadDataCountsForGalaxyPanelUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetLoadDataCountsForGalaxyPanelUidPDSA Entity
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
    /// Clones the current GetLoadDataCountsForGalaxyPanelUidPDSA
    /// </summary>
    /// <returns>A cloned GetLoadDataCountsForGalaxyPanelUidPDSA object</returns>
    public GetLoadDataCountsForGalaxyPanelUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetLoadDataCountsForGalaxyPanelUidPDSA
    /// </summary>
    /// <param name="entityToClone">The GetLoadDataCountsForGalaxyPanelUidPDSA entity to clone</param>
    /// <returns>A cloned GetLoadDataCountsForGalaxyPanelUidPDSA object</returns>
    public GetLoadDataCountsForGalaxyPanelUidPDSA CloneEntity(GetLoadDataCountsForGalaxyPanelUidPDSA entityToClone)
    {
      GetLoadDataCountsForGalaxyPanelUidPDSA newEntity = new GetLoadDataCountsForGalaxyPanelUidPDSA();

      newEntity.AccessPortalsInputsOutputsCount = entityToClone.AccessPortalsInputsOutputsCount;
      newEntity.AllCardDataCount = entityToClone.AllCardDataCount;
      newEntity.InterfaceBoardSectionCount = entityToClone.InterfaceBoardSectionCount;
      newEntity.AccessPortalCount = entityToClone.AccessPortalCount;
      newEntity.InputDeviceCount = entityToClone.InputDeviceCount;
      newEntity.OutputDeviceCount = entityToClone.OutputDeviceCount;
      newEntity.InputOutputGroupCount = entityToClone.InputOutputGroupCount;
      newEntity.CredentialCount = entityToClone.CredentialCount;
      newEntity.PersonalAccessGroupCount = entityToClone.PersonalAccessGroupCount;
      newEntity.AccessRulesCount = entityToClone.AccessRulesCount;
      newEntity.AccessPortalAccessRulesCount = entityToClone.AccessPortalAccessRulesCount;
      newEntity.DayTypeCount = entityToClone.DayTypeCount;
      newEntity.TimePeriodCount = entityToClone.TimePeriodCount;
      newEntity.TimePeriodDayTypeMapCount = entityToClone.TimePeriodDayTypeMapCount;
      newEntity.TimeSchedulesCount = entityToClone.TimeSchedulesCount;

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
      
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.galaxyPanelUid, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_galaxyPanelUid_Header", "galaxy Panel Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_galaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeBoardSectionCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeBoardSectionCount_Header", "include Board Section Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeBoardSectionCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessPortalCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeAccessPortalCount_Header", "include Access Portal Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeAccessPortalCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeInputDeviceCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeInputDeviceCount_Header", "include Input Device Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeInputDeviceCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeOutputDeviceCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeOutputDeviceCount_Header", "include Output Device Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeOutputDeviceCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeIoGroupCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeIoGroupCount_Header", "include Io Group Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeIoGroupCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeCredentialCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeCredentialCount_Header", "include Credential Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeCredentialCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includePersonalAccessGroupCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includePersonalAccessGroupCount_Header", "include Personal Access Group Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includePersonalAccessGroupCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessRuleCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeAccessRuleCount_Header", "include Access Rule Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeAccessRuleCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeTimeScheduleCount, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeTimeScheduleCount_Header", "include Time Schedule Count"), false, typeof(bool), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_includeTimeScheduleCount_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetLoadDataCountsForGalaxyPanelUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.galaxyPanelUid).Value = Entity.galaxyPanelUid;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeBoardSectionCount).Value = Entity.includeBoardSectionCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessPortalCount).Value = Entity.includeAccessPortalCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeInputDeviceCount).Value = Entity.includeInputDeviceCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeOutputDeviceCount).Value = Entity.includeOutputDeviceCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeIoGroupCount).Value = Entity.includeIoGroupCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeCredentialCount).Value = Entity.includeCredentialCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includePersonalAccessGroupCount).Value = Entity.includePersonalAccessGroupCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessRuleCount).Value = Entity.includeAccessRuleCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeTimeScheduleCount).Value = Entity.includeTimeScheduleCount;
      this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.galaxyPanelUid).IsNull == false)
        Entity.galaxyPanelUid = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.galaxyPanelUid).GetAsGuid();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeBoardSectionCount).IsNull == false)
        Entity.includeBoardSectionCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeBoardSectionCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessPortalCount).IsNull == false)
        Entity.includeAccessPortalCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessPortalCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeInputDeviceCount).IsNull == false)
        Entity.includeInputDeviceCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeInputDeviceCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeOutputDeviceCount).IsNull == false)
        Entity.includeOutputDeviceCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeOutputDeviceCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeIoGroupCount).IsNull == false)
        Entity.includeIoGroupCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeIoGroupCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeCredentialCount).IsNull == false)
        Entity.includeCredentialCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeCredentialCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includePersonalAccessGroupCount).IsNull == false)
        Entity.includePersonalAccessGroupCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includePersonalAccessGroupCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessRuleCount).IsNull == false)
        Entity.includeAccessRuleCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeAccessRuleCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeTimeScheduleCount).IsNull == false)
        Entity.includeTimeScheduleCount = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.includeTimeScheduleCount).GetAsBool();
      if(this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetLoadDataCountsForGalaxyPanelUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetLoadDataCountsForGalaxyPanelUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalsInputsOutputsCount'
    /// </summary>
    public static string AccessPortalsInputsOutputsCount = "AccessPortalsInputsOutputsCount";
    /// <summary>
    /// Returns 'AllCardDataCount'
    /// </summary>
    public static string AllCardDataCount = "AllCardDataCount";
    /// <summary>
    /// Returns 'InterfaceBoardSectionCount'
    /// </summary>
    public static string InterfaceBoardSectionCount = "InterfaceBoardSectionCount";
    /// <summary>
    /// Returns 'AccessPortalCount'
    /// </summary>
    public static string AccessPortalCount = "AccessPortalCount";
    /// <summary>
    /// Returns 'InputDeviceCount'
    /// </summary>
    public static string InputDeviceCount = "InputDeviceCount";
    /// <summary>
    /// Returns 'OutputDeviceCount'
    /// </summary>
    public static string OutputDeviceCount = "OutputDeviceCount";
    /// <summary>
    /// Returns 'InputOutputGroupCount'
    /// </summary>
    public static string InputOutputGroupCount = "InputOutputGroupCount";
    /// <summary>
    /// Returns 'CredentialCount'
    /// </summary>
    public static string CredentialCount = "CredentialCount";
    /// <summary>
    /// Returns 'PersonalAccessGroupCount'
    /// </summary>
    public static string PersonalAccessGroupCount = "PersonalAccessGroupCount";
    /// <summary>
    /// Returns 'AccessRulesCount'
    /// </summary>
    public static string AccessRulesCount = "AccessRulesCount";
    /// <summary>
    /// Returns 'AccessPortalAccessRulesCount'
    /// </summary>
    public static string AccessPortalAccessRulesCount = "AccessPortalAccessRulesCount";
    /// <summary>
    /// Returns 'DayTypeCount'
    /// </summary>
    public static string DayTypeCount = "DayTypeCount";
    /// <summary>
    /// Returns 'TimePeriodCount'
    /// </summary>
    public static string TimePeriodCount = "TimePeriodCount";
    /// <summary>
    /// Returns 'TimePeriodDayTypeMapCount'
    /// </summary>
    public static string TimePeriodDayTypeMapCount = "TimePeriodDayTypeMapCount";
    /// <summary>
    /// Returns 'TimeSchedulesCount'
    /// </summary>
    public static string TimeSchedulesCount = "TimeSchedulesCount";
    /// <summary>
    /// Returns '@galaxyPanelUid'
    /// </summary>
    public static string galaxyPanelUid = "@galaxyPanelUid";
    /// <summary>
    /// Returns '@includeBoardSectionCount'
    /// </summary>
    public static string includeBoardSectionCount = "@includeBoardSectionCount";
    /// <summary>
    /// Returns '@includeAccessPortalCount'
    /// </summary>
    public static string includeAccessPortalCount = "@includeAccessPortalCount";
    /// <summary>
    /// Returns '@includeInputDeviceCount'
    /// </summary>
    public static string includeInputDeviceCount = "@includeInputDeviceCount";
    /// <summary>
    /// Returns '@includeOutputDeviceCount'
    /// </summary>
    public static string includeOutputDeviceCount = "@includeOutputDeviceCount";
    /// <summary>
    /// Returns '@includeIoGroupCount'
    /// </summary>
    public static string includeIoGroupCount = "@includeIoGroupCount";
    /// <summary>
    /// Returns '@includeCredentialCount'
    /// </summary>
    public static string includeCredentialCount = "@includeCredentialCount";
    /// <summary>
    /// Returns '@includePersonalAccessGroupCount'
    /// </summary>
    public static string includePersonalAccessGroupCount = "@includePersonalAccessGroupCount";
    /// <summary>
    /// Returns '@includeAccessRuleCount'
    /// </summary>
    public static string includeAccessRuleCount = "@includeAccessRuleCount";
    /// <summary>
    /// Returns '@includeTimeScheduleCount'
    /// </summary>
    public static string includeTimeScheduleCount = "@includeTimeScheduleCount";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetLoadDataCountsForGalaxyPanelUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@galaxyPanelUid'
    /// </summary>
    public static string galaxyPanelUid = "@galaxyPanelUid";
    /// <summary>
    /// Returns '@includeBoardSectionCount'
    /// </summary>
    public static string includeBoardSectionCount = "@includeBoardSectionCount";
    /// <summary>
    /// Returns '@includeAccessPortalCount'
    /// </summary>
    public static string includeAccessPortalCount = "@includeAccessPortalCount";
    /// <summary>
    /// Returns '@includeInputDeviceCount'
    /// </summary>
    public static string includeInputDeviceCount = "@includeInputDeviceCount";
    /// <summary>
    /// Returns '@includeOutputDeviceCount'
    /// </summary>
    public static string includeOutputDeviceCount = "@includeOutputDeviceCount";
    /// <summary>
    /// Returns '@includeIoGroupCount'
    /// </summary>
    public static string includeIoGroupCount = "@includeIoGroupCount";
    /// <summary>
    /// Returns '@includeCredentialCount'
    /// </summary>
    public static string includeCredentialCount = "@includeCredentialCount";
    /// <summary>
    /// Returns '@includePersonalAccessGroupCount'
    /// </summary>
    public static string includePersonalAccessGroupCount = "@includePersonalAccessGroupCount";
    /// <summary>
    /// Returns '@includeAccessRuleCount'
    /// </summary>
    public static string includeAccessRuleCount = "@includeAccessRuleCount";
    /// <summary>
    /// Returns '@includeTimeScheduleCount'
    /// </summary>
    public static string includeTimeScheduleCount = "@includeTimeScheduleCount";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
