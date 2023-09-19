using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsApplicationSettingPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsApplicationSettingPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsApplicationSettingPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsApplicationSettingPDSA Entity
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
    /// Clones the current gcsApplicationSettingPDSA
    /// </summary>
    /// <returns>A cloned gcsApplicationSettingPDSA object</returns>
    public gcsApplicationSettingPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsApplicationSettingPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsApplicationSettingPDSA entity to clone</param>
    /// <returns>A cloned gcsApplicationSettingPDSA object</returns>
    public gcsApplicationSettingPDSA CloneEntity(gcsApplicationSettingPDSA entityToClone)
    {
      gcsApplicationSettingPDSA newEntity = new gcsApplicationSettingPDSA();

      newEntity.ApplicationSettingId = entityToClone.ApplicationSettingId;
      newEntity.ApplicationId = entityToClone.ApplicationId;
      newEntity.Category = entityToClone.Category;
      newEntity.SettingKey = entityToClone.SettingKey;
      newEntity.SettingValue = entityToClone.SettingValue;
      newEntity.SettingDescription = entityToClone.SettingDescription;
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
      
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationSettingId, GetResourceMessage("GCS_gcsApplicationSettingPDSA_ApplicationSettingId_Header", "Application Setting Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsApplicationSettingPDSA_ApplicationSettingId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationId, GetResourceMessage("GCS_gcsApplicationSettingPDSA_ApplicationId_Header", "Application Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsApplicationSettingPDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.Category, GetResourceMessage("GCS_gcsApplicationSettingPDSA_Category_Header", "Category"), true, typeof(string), 100, GetResourceMessage("GCS_gcsApplicationSettingPDSA_Category_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.SettingKey, GetResourceMessage("GCS_gcsApplicationSettingPDSA_SettingKey_Header", "Setting Key"), true, typeof(string), 255, GetResourceMessage("GCS_gcsApplicationSettingPDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.SettingValue, GetResourceMessage("GCS_gcsApplicationSettingPDSA_SettingValue_Header", "Setting Value"), true, typeof(string), 255, GetResourceMessage("GCS_gcsApplicationSettingPDSA_SettingValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.SettingDescription, GetResourceMessage("GCS_gcsApplicationSettingPDSA_SettingDescription_Header", "Setting Description"), true, typeof(string), 255, GetResourceMessage("GCS_gcsApplicationSettingPDSA_SettingDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_gcsApplicationSettingPDSA_IsActive_Header", "Is Active"), true, typeof(bool?), -1, GetResourceMessage("GCS_gcsApplicationSettingPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsApplicationSettingPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsApplicationSettingPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsApplicationSettingPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsApplicationSettingPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsApplicationSettingPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsApplicationSettingPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsApplicationSettingPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsApplicationSettingPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationSettingPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsApplicationSettingPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsApplicationSettingPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ApplicationSettingId = Guid.NewGuid();
      Entity.ApplicationId = Guid.NewGuid();
      Entity.Category = string.Empty;
      Entity.SettingKey = string.Empty;
      Entity.SettingValue = string.Empty;
      Entity.SettingDescription = string.Empty;
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
      
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationSettingId).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationSettingId).Value = Entity.ApplicationSettingId;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationId).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationId).Value = Entity.ApplicationId;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.Category).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.Category).Value = Entity.Category;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingKey).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingKey).Value = Entity.SettingKey;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingValue).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingValue).Value = Entity.SettingValue;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingDescription).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingDescription).Value = Entity.SettingDescription;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationSettingId).IsNull == false)
        Entity.ApplicationSettingId = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationSettingId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ApplicationId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.Category).IsNull == false)
        Entity.Category = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.Category).GetAsString();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingKey).IsNull == false)
        Entity.SettingKey = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingKey).GetAsString();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingValue).IsNull == false)
        Entity.SettingValue = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingValue).GetAsString();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingDescription).IsNull == false)
        Entity.SettingDescription = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.SettingDescription).GetAsString();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.IsActive).GetValueAsBoolean();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsApplicationSettingPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsApplicationSettingPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ApplicationSettingId'
    /// </summary>
    public static string ApplicationSettingId = "ApplicationSettingId";
    /// <summary>
    /// Returns 'ApplicationId'
    /// </summary>
    public static string ApplicationId = "ApplicationId";
    /// <summary>
    /// Returns 'Category'
    /// </summary>
    public static string Category = "Category";
    /// <summary>
    /// Returns 'SettingKey'
    /// </summary>
    public static string SettingKey = "SettingKey";
    /// <summary>
    /// Returns 'SettingValue'
    /// </summary>
    public static string SettingValue = "SettingValue";
    /// <summary>
    /// Returns 'SettingDescription'
    /// </summary>
    public static string SettingDescription = "SettingDescription";
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
