using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PropertySensitivityLevelPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PropertySensitivityLevelPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PropertySensitivityLevelPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PropertySensitivityLevelPDSA Entity
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
    /// Clones the current PropertySensitivityLevelPDSA
    /// </summary>
    /// <returns>A cloned PropertySensitivityLevelPDSA object</returns>
    public PropertySensitivityLevelPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PropertySensitivityLevelPDSA
    /// </summary>
    /// <param name="entityToClone">The PropertySensitivityLevelPDSA entity to clone</param>
    /// <returns>A cloned PropertySensitivityLevelPDSA object</returns>
    public PropertySensitivityLevelPDSA CloneEntity(PropertySensitivityLevelPDSA entityToClone)
    {
      PropertySensitivityLevelPDSA newEntity = new PropertySensitivityLevelPDSA();

      newEntity.PropertySensitivityLevelUid = entityToClone.PropertySensitivityLevelUid;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Display = entityToClone.Display;
      newEntity.Description = entityToClone.Description;
      newEntity.SensitivityLevel = entityToClone.SensitivityLevel;
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
      
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.PropertySensitivityLevelUid, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_PropertySensitivityLevelUid_Header", "Property Sensitivity Level Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_PropertySensitivityLevelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.SensitivityLevel, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_SensitivityLevel_Header", "Sensitivity Level"), true, typeof(short), 5, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_SensitivityLevel_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PropertySensitivityLevelPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_PropertySensitivityLevelPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PropertySensitivityLevelUid = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.Description = string.Empty;
      Entity.SensitivityLevel = 0;
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
      
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.PropertySensitivityLevelUid).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.PropertySensitivityLevelUid).Value = Entity.PropertySensitivityLevelUid;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.SensitivityLevel).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.SensitivityLevel).Value = Entity.SensitivityLevel;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.PropertySensitivityLevelUid).IsNull == false)
        Entity.PropertySensitivityLevelUid = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.PropertySensitivityLevelUid).GetAsGuid();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.SensitivityLevel).IsNull == false)
        Entity.SensitivityLevel = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.SensitivityLevel).GetAsShort();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(PropertySensitivityLevelPDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PropertySensitivityLevelPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PropertySensitivityLevelUid'
    /// </summary>
    public static string PropertySensitivityLevelUid = "PropertySensitivityLevelUid";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'SensitivityLevel'
    /// </summary>
    public static string SensitivityLevel = "SensitivityLevel";
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
