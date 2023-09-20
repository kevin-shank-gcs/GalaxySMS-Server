using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputOutputGroupCommandPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroupCommandPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputOutputGroupCommandPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputOutputGroupCommandPDSA Entity
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
    /// Clones the current InputOutputGroupCommandPDSA
    /// </summary>
    /// <returns>A cloned InputOutputGroupCommandPDSA object</returns>
    public InputOutputGroupCommandPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputOutputGroupCommandPDSA
    /// </summary>
    /// <param name="entityToClone">The InputOutputGroupCommandPDSA entity to clone</param>
    /// <returns>A cloned InputOutputGroupCommandPDSA object</returns>
    public InputOutputGroupCommandPDSA CloneEntity(InputOutputGroupCommandPDSA entityToClone)
    {
      InputOutputGroupCommandPDSA newEntity = new InputOutputGroupCommandPDSA();

      newEntity.InputOutputGroupCommandUid = entityToClone.InputOutputGroupCommandUid;
      newEntity.Display = entityToClone.Display;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.Description = entityToClone.Description;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.CommandCode = entityToClone.CommandCode;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.IsAccessPortalGroupCommand = entityToClone.IsAccessPortalGroupCommand;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.CultureName = entityToClone.CultureName;

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
      
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_InputOutputGroupCommandUid_Header", "Input Output Group Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_InputOutputGroupCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_CommandCode_Header", "Command Code"), true, typeof(short), 5, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_CommandCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_IsActive_Header", "Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_IsAccessPortalGroupCommand_Header", "Is Access Portal Group Command"), true, typeof(bool), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_IsAccessPortalGroupCommand_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_InputOutputGroupCommandPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputOutputGroupCommandUid = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.CommandCode = 0;
      Entity.IsActive = false;
      Entity.IsAccessPortalGroupCommand = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.CultureName = string.Empty;

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
      
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid).Value = Entity.InputOutputGroupCommandUid;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode).Value = Entity.CommandCode;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand).Value = Entity.IsAccessPortalGroupCommand;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid).IsNull == false)
        Entity.InputOutputGroupCommandUid = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode).IsNull == false)
        Entity.CommandCode = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode).GetAsShort();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand).IsNull == false)
        Entity.IsAccessPortalGroupCommand = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand).GetAsBool();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupCommandPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputOutputGroupCommandUid'
    /// </summary>
    public static string InputOutputGroupCommandUid = "InputOutputGroupCommandUid";
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
    /// Returns 'IsAccessPortalGroupCommand'
    /// </summary>
    public static string IsAccessPortalGroupCommand = "IsAccessPortalGroupCommand";
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
    }
    #endregion
  }
}
