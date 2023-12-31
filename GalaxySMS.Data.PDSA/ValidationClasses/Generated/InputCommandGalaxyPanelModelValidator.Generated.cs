using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputCommandGalaxyPanelModelPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputCommandGalaxyPanelModelPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputCommandGalaxyPanelModelPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputCommandGalaxyPanelModelPDSA Entity
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
    /// Clones the current InputCommandGalaxyPanelModelPDSA
    /// </summary>
    /// <returns>A cloned InputCommandGalaxyPanelModelPDSA object</returns>
    public InputCommandGalaxyPanelModelPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputCommandGalaxyPanelModelPDSA
    /// </summary>
    /// <param name="entityToClone">The InputCommandGalaxyPanelModelPDSA entity to clone</param>
    /// <returns>A cloned InputCommandGalaxyPanelModelPDSA object</returns>
    public InputCommandGalaxyPanelModelPDSA CloneEntity(InputCommandGalaxyPanelModelPDSA entityToClone)
    {
      InputCommandGalaxyPanelModelPDSA newEntity = new InputCommandGalaxyPanelModelPDSA();

      newEntity.InputCommandGalaxyPanelModelUid = entityToClone.InputCommandGalaxyPanelModelUid;
      newEntity.InputCommandUid = entityToClone.InputCommandUid;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.CommandCode = entityToClone.CommandCode;
      newEntity.IsTextCommand = entityToClone.IsTextCommand;
      newEntity.TextCommand = entityToClone.TextCommand;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;

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
      
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandGalaxyPanelModelUid, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InputCommandGalaxyPanelModelUid_Header", "Input Command Galaxy Panel Model Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InputCommandGalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandUid, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InputCommandUid_Header", "Input Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InputCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.CommandCode, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_CommandCode_Header", "Command Code"), true, typeof(short), 5, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_CommandCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsTextCommand, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_IsTextCommand_Header", "Is Text Command"), true, typeof(bool), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_IsTextCommand_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.TextCommand, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_TextCommand_Header", "Text Command"), false, typeof(string), 20, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_TextCommand_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_IsActive_Header", "Is Active"), true, typeof(bool), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputCommandGalaxyPanelModelPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputCommandGalaxyPanelModelUid = Guid.Empty;
      Entity.InputCommandUid = Guid.Empty;
      Entity.GalaxyPanelModelUid = Guid.Empty;
      Entity.CommandCode = 0;
      Entity.IsTextCommand = false;
      Entity.TextCommand = string.Empty;
      Entity.IsActive = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;

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
      
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandGalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandGalaxyPanelModelUid).Value = Entity.InputCommandGalaxyPanelModelUid;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandUid).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandUid).Value = Entity.InputCommandUid;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.CommandCode).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.CommandCode).Value = Entity.CommandCode;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsTextCommand).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsTextCommand).Value = Entity.IsTextCommand;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.TextCommand).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.TextCommand).Value = Entity.TextCommand;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandGalaxyPanelModelUid).IsNull == false)
        Entity.InputCommandGalaxyPanelModelUid = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandGalaxyPanelModelUid).GetAsGuid();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandUid).IsNull == false)
        Entity.InputCommandUid = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InputCommandUid).GetAsGuid();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).GetAsGuid();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.CommandCode).IsNull == false)
        Entity.CommandCode = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.CommandCode).GetAsShort();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsTextCommand).IsNull == false)
        Entity.IsTextCommand = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsTextCommand).GetAsBool();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.TextCommand).IsNull == false)
        Entity.TextCommand = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.TextCommand).GetAsString();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputCommandGalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputCommandGalaxyPanelModelPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputCommandGalaxyPanelModelUid'
    /// </summary>
    public static string InputCommandGalaxyPanelModelUid = "InputCommandGalaxyPanelModelUid";
    /// <summary>
    /// Returns 'InputCommandUid'
    /// </summary>
    public static string InputCommandUid = "InputCommandUid";
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
    /// <summary>
    /// Returns 'CommandCode'
    /// </summary>
    public static string CommandCode = "CommandCode";
    /// <summary>
    /// Returns 'IsTextCommand'
    /// </summary>
    public static string IsTextCommand = "IsTextCommand";
    /// <summary>
    /// Returns 'TextCommand'
    /// </summary>
    public static string TextCommand = "TextCommand";
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
    }
    #endregion
  }
}
