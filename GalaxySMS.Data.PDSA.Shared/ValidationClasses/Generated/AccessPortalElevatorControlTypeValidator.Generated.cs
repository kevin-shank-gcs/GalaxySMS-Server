using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalElevatorControlTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalElevatorControlTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalElevatorControlTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalElevatorControlTypePDSA Entity
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
    /// Clones the current AccessPortalElevatorControlTypePDSA
    /// </summary>
    /// <returns>A cloned AccessPortalElevatorControlTypePDSA object</returns>
    public AccessPortalElevatorControlTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalElevatorControlTypePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalElevatorControlTypePDSA entity to clone</param>
    /// <returns>A cloned AccessPortalElevatorControlTypePDSA object</returns>
    public AccessPortalElevatorControlTypePDSA CloneEntity(AccessPortalElevatorControlTypePDSA entityToClone)
    {
      AccessPortalElevatorControlTypePDSA newEntity = new AccessPortalElevatorControlTypePDSA();

      newEntity.AccessPortalElevatorControlTypeUid = entityToClone.AccessPortalElevatorControlTypeUid;
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
      newEntity.BinaryResourceUid = entityToClone.BinaryResourceUid;
      newEntity.CultureName = entityToClone.CultureName;
      newEntity.AccessPointUid = entityToClone.AccessPointUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;

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
      
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalElevatorControlTypeUid, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_AccessPortalElevatorControlTypeUid_Header", "Access Portal Elevator Control Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_AccessPortalElevatorControlTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Code, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_Code_Header", "Code"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_Code_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayOrder, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_DisplayOrder_Header", "Display Order"), false, typeof(int), 10, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_DisplayOrder_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsDefault, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_IsDefault_Header", "Is Default"), false, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_IsDefault_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_IsActive_Header", "Is Active"), false, typeof(bool?), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.BinaryResourceUid, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPointUid, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_AccessPointUid_Header", "Access Point Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_AccessPointUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.GalaxyPanelModelUid, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AccessPortalElevatorControlTypePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalElevatorControlTypeUid = Guid.NewGuid();
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
      Entity.BinaryResourceUid = Guid.NewGuid();
      Entity.CultureName = string.Empty;
      Entity.AccessPointUid = Guid.NewGuid();
      Entity.AccessPortalUid = Guid.NewGuid();
      Entity.GalaxyPanelModelUid = Guid.NewGuid();

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
      
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalElevatorControlTypeUid).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalElevatorControlTypeUid).Value = Entity.AccessPortalElevatorControlTypeUid;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Code).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Code).Value = Entity.Code;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayOrder).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayOrder).Value = Entity.DisplayOrder;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsDefault).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsDefault).Value = Entity.IsDefault;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.BinaryResourceUid).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPointUid).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPointUid).Value = Entity.AccessPointUid;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if(!Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalElevatorControlTypeUid).IsNull == false)
        Entity.AccessPortalElevatorControlTypeUid = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalElevatorControlTypeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Code).IsNull == false)
        Entity.Code = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.Code).GetAsShort();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayOrder).IsNull == false)
        Entity.DisplayOrder = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.DisplayOrder).GetAsInteger();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsDefault).IsNull == false)
        Entity.IsDefault = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsDefault).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.IsActive).GetValueAsBoolean();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.BinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.CultureName).GetAsString();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPointUid).IsNull == false)
        Entity.AccessPointUid = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPointUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = Properties.GetByName(AccessPortalElevatorControlTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalElevatorControlTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalElevatorControlTypeUid'
    /// </summary>
    public static string AccessPortalElevatorControlTypeUid = "AccessPortalElevatorControlTypeUid";
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
    /// Returns 'BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "BinaryResourceUid";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    /// <summary>
    /// Returns 'AccessPointUid'
    /// </summary>
    public static string AccessPointUid = "AccessPointUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
    }
    #endregion
  }
}
