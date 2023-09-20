using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalAuxiliaryOutputModePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalAuxiliaryOutputModePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalAuxiliaryOutputModePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalAuxiliaryOutputModePDSA Entity
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
    /// Clones the current AccessPortalAuxiliaryOutputModePDSA
    /// </summary>
    /// <returns>A cloned AccessPortalAuxiliaryOutputModePDSA object</returns>
    public AccessPortalAuxiliaryOutputModePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalAuxiliaryOutputModePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalAuxiliaryOutputModePDSA entity to clone</param>
    /// <returns>A cloned AccessPortalAuxiliaryOutputModePDSA object</returns>
    public AccessPortalAuxiliaryOutputModePDSA CloneEntity(AccessPortalAuxiliaryOutputModePDSA entityToClone)
    {
      AccessPortalAuxiliaryOutputModePDSA newEntity = new AccessPortalAuxiliaryOutputModePDSA();

      newEntity.AccessPortalAuxiliaryOutputModeUid = entityToClone.AccessPortalAuxiliaryOutputModeUid;
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
      
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_AccessPortalAuxiliaryOutputModeUid_Header", "Access Portal Auxiliary Output Mode Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_AccessPortalAuxiliaryOutputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_Code_Header", "Code"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_Code_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_DisplayOrder_Header", "Display Order"), false, typeof(int), 10, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_DisplayOrder_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_IsDefault_Header", "Is Default"), false, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_IsDefault_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_IsActive_Header", "Is Active"), false, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AccessPortalAuxiliaryOutputModePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalAuxiliaryOutputModeUid = Guid.NewGuid();
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.NewGuid();
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.NewGuid();
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
      
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).Value = Entity.AccessPortalAuxiliaryOutputModeUid;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code).Value = Entity.Code;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder).Value = Entity.DisplayOrder;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault).Value = Entity.IsDefault;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).IsNull == false)
        Entity.AccessPortalAuxiliaryOutputModeUid = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code).IsNull == false)
        Entity.Code = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code).GetAsShort();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder).IsNull == false)
        Entity.DisplayOrder = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder).GetAsInteger();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault).IsNull == false)
        Entity.IsDefault = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalAuxiliaryOutputModePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalAuxiliaryOutputModeUid'
    /// </summary>
    public static string AccessPortalAuxiliaryOutputModeUid = "AccessPortalAuxiliaryOutputModeUid";
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
