using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonActivationModePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonActivationModePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonActivationModePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonActivationModePDSA Entity
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
    /// Clones the current PersonActivationModePDSA
    /// </summary>
    /// <returns>A cloned PersonActivationModePDSA object</returns>
    public PersonActivationModePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonActivationModePDSA
    /// </summary>
    /// <param name="entityToClone">The PersonActivationModePDSA entity to clone</param>
    /// <returns>A cloned PersonActivationModePDSA object</returns>
    public PersonActivationModePDSA CloneEntity(PersonActivationModePDSA entityToClone)
    {
      PersonActivationModePDSA newEntity = new PersonActivationModePDSA();

      newEntity.PersonActivationModeUid = entityToClone.PersonActivationModeUid;
      newEntity.Display = entityToClone.Display;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.Description = entityToClone.Description;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Code = entityToClone.Code;
      newEntity.DisplayOrder = entityToClone.DisplayOrder;
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
      
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.PersonActivationModeUid, GetResourceMessage("GCS_PersonActivationModePDSA_PersonActivationModeUid_Header", "Person Activation Mode Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonActivationModePDSA_PersonActivationModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_PersonActivationModePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_PersonActivationModePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_PersonActivationModePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_PersonActivationModePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_PersonActivationModePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_PersonActivationModePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_PersonActivationModePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_PersonActivationModePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.Code, GetResourceMessage("GCS_PersonActivationModePDSA_Code_Header", "Code"), true, typeof(short), 5, GetResourceMessage("GCS_PersonActivationModePDSA_Code_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.DisplayOrder, GetResourceMessage("GCS_PersonActivationModePDSA_DisplayOrder_Header", "Display Order"), false, typeof(int), 10, GetResourceMessage("GCS_PersonActivationModePDSA_DisplayOrder_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.IsDefault, GetResourceMessage("GCS_PersonActivationModePDSA_IsDefault_Header", "Is Default"), false, typeof(bool), -1, GetResourceMessage("GCS_PersonActivationModePDSA_IsDefault_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_PersonActivationModePDSA_IsActive_Header", "Is Active"), false, typeof(bool), -1, GetResourceMessage("GCS_PersonActivationModePDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonActivationModePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonActivationModePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonActivationModePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonActivationModePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonActivationModePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonActivationModePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonActivationModePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonActivationModePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonActivationModePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonActivationModePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonActivationModePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_PersonActivationModePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_PersonActivationModePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonActivationModeUid = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.Code = 0;
      Entity.DisplayOrder = 0;
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
      
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.PersonActivationModeUid).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.PersonActivationModeUid).Value = Entity.PersonActivationModeUid;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Code).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Code).Value = Entity.Code;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayOrder).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayOrder).Value = Entity.DisplayOrder;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsDefault).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsDefault).Value = Entity.IsDefault;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.PersonActivationModeUid).IsNull == false)
        Entity.PersonActivationModeUid = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.PersonActivationModeUid).GetAsGuid();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Code).IsNull == false)
        Entity.Code = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.Code).GetAsShort();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayOrder).IsNull == false)
        Entity.DisplayOrder = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.DisplayOrder).GetAsInteger();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsDefault).IsNull == false)
        Entity.IsDefault = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsDefault).GetAsBool();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(PersonActivationModePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonActivationModePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonActivationModeUid'
    /// </summary>
    public static string PersonActivationModeUid = "PersonActivationModeUid";
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
    /// Returns 'Code'
    /// </summary>
    public static string Code = "Code";
    /// <summary>
    /// Returns 'DisplayOrder'
    /// </summary>
    public static string DisplayOrder = "DisplayOrder";
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
