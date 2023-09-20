using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyPanelModelPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelModelPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelModelPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelModelPDSA Entity
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
    /// Clones the current GalaxyPanelModelPDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelModelPDSA object</returns>
    public GalaxyPanelModelPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelModelPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelModelPDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelModelPDSA object</returns>
    public GalaxyPanelModelPDSA CloneEntity(GalaxyPanelModelPDSA entityToClone)
    {
      GalaxyPanelModelPDSA newEntity = new GalaxyPanelModelPDSA();

      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.Display = entityToClone.Display;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.Description = entityToClone.Description;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.TypeCode = entityToClone.TypeCode;
      newEntity.IsDefault = entityToClone.IsDefault;
      newEntity.IsActive = entityToClone.IsActive;
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
      
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid, GetResourceMessage("GCS_GalaxyPanelModelPDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_GalaxyPanelModelPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelModelPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_GalaxyPanelModelPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_GalaxyPanelModelPDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_GalaxyPanelModelPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_GalaxyPanelModelPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.TypeCode, GetResourceMessage("GCS_GalaxyPanelModelPDSA_TypeCode_Header", "Type Code"), true, typeof(string), 16, GetResourceMessage("GCS_GalaxyPanelModelPDSA_TypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.IsDefault, GetResourceMessage("GCS_GalaxyPanelModelPDSA_IsDefault_Header", "Is Default"), false, typeof(bool?), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_IsDefault_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_GalaxyPanelModelPDSA_IsActive_Header", "Is Active"), false, typeof(bool?), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyPanelModelPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyPanelModelPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyPanelModelPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyPanelModelPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyPanelModelPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyPanelModelPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelModelPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyPanelModelPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyPanelModelPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_GalaxyPanelModelPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_GalaxyPanelModelPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyPanelModelUid = Guid.NewGuid();
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.NewGuid();
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.NewGuid();
      Entity.TypeCode = string.Empty;
      Entity.IsDefault = false;
      Entity.IsActive = false;
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
      
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.TypeCode).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.TypeCode).Value = Entity.TypeCode;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsDefault).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsDefault).Value = Entity.IsDefault;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.GalaxyPanelModelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.TypeCode).IsNull == false)
        Entity.TypeCode = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.TypeCode).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsDefault).IsNull == false)
        Entity.IsDefault = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsDefault).GetValueAsBoolean();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.IsActive).GetValueAsBoolean();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(GalaxyPanelModelPDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelModelPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
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
    /// Returns 'TypeCode'
    /// </summary>
    public static string TypeCode = "TypeCode";
    /// <summary>
    /// Returns 'IsDefault'
    /// </summary>
    public static string IsDefault = "IsDefault";
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
    }
    #endregion
  }
}
