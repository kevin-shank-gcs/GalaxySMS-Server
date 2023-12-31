using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsUserSettingPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsUserSettingPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsUserSettingPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsUserSettingPDSA Entity
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
    /// Clones the current gcsUserSettingPDSA
    /// </summary>
    /// <returns>A cloned gcsUserSettingPDSA object</returns>
    public gcsUserSettingPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsUserSettingPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsUserSettingPDSA entity to clone</param>
    /// <returns>A cloned gcsUserSettingPDSA object</returns>
    public gcsUserSettingPDSA CloneEntity(gcsUserSettingPDSA entityToClone)
    {
      gcsUserSettingPDSA newEntity = new gcsUserSettingPDSA();

      newEntity.UserSettingId = entityToClone.UserSettingId;
      newEntity.UserId = entityToClone.UserId;
      newEntity.ApplicationId = entityToClone.ApplicationId;
      newEntity.Category = entityToClone.Category;
      newEntity.SettingKey = entityToClone.SettingKey;
      newEntity.SettingValue = entityToClone.SettingValue;
      newEntity.SettingDescription = entityToClone.SettingDescription;
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
      
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.UserSettingId, GetResourceMessage("GCS_gcsUserSettingPDSA_UserSettingId_Header", "User Setting Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsUserSettingPDSA_UserSettingId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.UserId, GetResourceMessage("GCS_gcsUserSettingPDSA_UserId_Header", "User Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsUserSettingPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.ApplicationId, GetResourceMessage("GCS_gcsUserSettingPDSA_ApplicationId_Header", "Application Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_gcsUserSettingPDSA_ApplicationId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.Category, GetResourceMessage("GCS_gcsUserSettingPDSA_Category_Header", "Category"), true, typeof(string), 100, GetResourceMessage("GCS_gcsUserSettingPDSA_Category_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.SettingKey, GetResourceMessage("GCS_gcsUserSettingPDSA_SettingKey_Header", "Setting Key"), true, typeof(string), 255, GetResourceMessage("GCS_gcsUserSettingPDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.SettingValue, GetResourceMessage("GCS_gcsUserSettingPDSA_SettingValue_Header", "Setting Value"), true, typeof(string), 255, GetResourceMessage("GCS_gcsUserSettingPDSA_SettingValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.SettingDescription, GetResourceMessage("GCS_gcsUserSettingPDSA_SettingDescription_Header", "Setting Description"), true, typeof(string), 255, GetResourceMessage("GCS_gcsUserSettingPDSA_SettingDescription_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsUserSettingPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsUserSettingPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsUserSettingPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsUserSettingPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsUserSettingPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsUserSettingPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsUserSettingPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsUserSettingPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsUserSettingPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsUserSettingPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsUserSettingPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.UserSettingId = Guid.NewGuid();
      Entity.UserId = Guid.NewGuid();
      Entity.ApplicationId = Guid.NewGuid();
      Entity.Category = string.Empty;
      Entity.SettingKey = string.Empty;
      Entity.SettingValue = string.Empty;
      Entity.SettingDescription = string.Empty;
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
      
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserSettingId).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserSettingId).Value = Entity.UserSettingId;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserId).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserId).Value = Entity.UserId;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ApplicationId).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ApplicationId).Value = Entity.ApplicationId;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.Category).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.Category).Value = Entity.Category;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingKey).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingKey).Value = Entity.SettingKey;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingValue).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingValue).Value = Entity.SettingValue;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingDescription).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingDescription).Value = Entity.SettingDescription;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserSettingId).IsNull == false)
        Entity.UserSettingId = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserSettingId).GetAsGuid();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UserId).GetAsGuid();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ApplicationId).GetAsGuid();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.Category).IsNull == false)
        Entity.Category = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.Category).GetAsString();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingKey).IsNull == false)
        Entity.SettingKey = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingKey).GetAsString();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingValue).IsNull == false)
        Entity.SettingValue = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingValue).GetAsString();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingDescription).IsNull == false)
        Entity.SettingDescription = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.SettingDescription).GetAsString();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsUserSettingPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsUserSettingPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'UserSettingId'
    /// </summary>
    public static string UserSettingId = "UserSettingId";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
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
