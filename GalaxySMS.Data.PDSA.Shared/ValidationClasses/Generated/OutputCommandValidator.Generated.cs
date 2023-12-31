using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the OutputCommandPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class OutputCommandPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private OutputCommandPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new OutputCommandPDSA Entity
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
    /// Clones the current OutputCommandPDSA
    /// </summary>
    /// <returns>A cloned OutputCommandPDSA object</returns>
    public OutputCommandPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in OutputCommandPDSA
    /// </summary>
    /// <param name="entityToClone">The OutputCommandPDSA entity to clone</param>
    /// <returns>A cloned OutputCommandPDSA object</returns>
    public OutputCommandPDSA CloneEntity(OutputCommandPDSA entityToClone)
    {
      OutputCommandPDSA newEntity = new OutputCommandPDSA();

      newEntity.OutputCommandUid = entityToClone.OutputCommandUid;
      newEntity.Display = entityToClone.Display;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.Description = entityToClone.Description;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.CommandCode = entityToClone.CommandCode;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.CultureName = entityToClone.CultureName;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.GalaxyOutputModeUid = entityToClone.GalaxyOutputModeUid;

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
      
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.OutputCommandUid, GetResourceMessage("GCS_OutputCommandPDSA_OutputCommandUid_Header", "Output Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_OutputCommandPDSA_OutputCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_OutputCommandPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_OutputCommandPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_OutputCommandPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_OutputCommandPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_OutputCommandPDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_OutputCommandPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_OutputCommandPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_OutputCommandPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.CommandCode, GetResourceMessage("GCS_OutputCommandPDSA_CommandCode_Header", "Command Code"), true, typeof(short), 5, GetResourceMessage("GCS_OutputCommandPDSA_CommandCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_OutputCommandPDSA_IsActive_Header", "Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_OutputCommandPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_OutputCommandPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_OutputCommandPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_OutputCommandPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_OutputCommandPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_OutputCommandPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_OutputCommandPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_OutputCommandPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_OutputCommandPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_OutputCommandPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_OutputCommandPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_OutputCommandPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_OutputCommandPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.GalaxyPanelModelUid, GetResourceMessage("GCS_OutputCommandPDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_OutputCommandPDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputCommandPDSAValidator.ColumnNames.GalaxyOutputModeUid, GetResourceMessage("GCS_OutputCommandPDSA_GalaxyOutputModeUid_Header", "Galaxy Output Mode Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_OutputCommandPDSA_GalaxyOutputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.OutputCommandUid = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.CommandCode = 0;
      Entity.IsActive = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.CultureName = string.Empty;
      Entity.GalaxyPanelModelUid = Guid.Empty;
      Entity.GalaxyOutputModeUid = Guid.Empty;

      Entity.ResetAllIsDirtyProperties();
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
      if (Properties == null)
        InitProperties();
      
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.OutputCommandUid).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.OutputCommandUid).Value = Entity.OutputCommandUid;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CommandCode).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CommandCode).Value = Entity.CommandCode;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      if(!Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyOutputModeUid).SetAsNull)
        Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyOutputModeUid).Value = Entity.GalaxyOutputModeUid;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.OutputCommandUid).IsNull == false)
        Entity.OutputCommandUid = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.OutputCommandUid).GetAsGuid();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CommandCode).IsNull == false)
        Entity.CommandCode = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CommandCode).GetAsShort();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.CultureName).GetAsString();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyPanelModelUid).GetAsGuid();
      if(Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyOutputModeUid).IsNull == false)
        Entity.GalaxyOutputModeUid = Properties.GetByName(OutputCommandPDSAValidator.ColumnNames.GalaxyOutputModeUid).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputCommandPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'OutputCommandUid'
    /// </summary>
    public static string OutputCommandUid = "OutputCommandUid";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'CommandCode'
    /// </summary>
    public static string CommandCode = "CommandCode";
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
    /// <summary>
    /// Returns 'GalaxyOutputModeUid'
    /// </summary>
    public static string GalaxyOutputModeUid = "GalaxyOutputModeUid";
    }
    #endregion
  }
}
