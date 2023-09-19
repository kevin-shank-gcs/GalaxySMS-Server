using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalAreaTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalAreaTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalAreaTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalAreaTypePDSA Entity
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
    /// Clones the current AccessPortalAreaTypePDSA
    /// </summary>
    /// <returns>A cloned AccessPortalAreaTypePDSA object</returns>
    public AccessPortalAreaTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalAreaTypePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalAreaTypePDSA entity to clone</param>
    /// <returns>A cloned AccessPortalAreaTypePDSA object</returns>
    public AccessPortalAreaTypePDSA CloneEntity(AccessPortalAreaTypePDSA entityToClone)
    {
      AccessPortalAreaTypePDSA newEntity = new AccessPortalAreaTypePDSA();

      newEntity.AccessPortalAreaTypeUid = entityToClone.AccessPortalAreaTypeUid;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Tag = entityToClone.Tag;
      newEntity.Display = entityToClone.Display;
      newEntity.Description = entityToClone.Description;
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
      
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.AccessPortalAreaTypeUid, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_AccessPortalAreaTypeUid_Header", "Access Portal Area Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_AccessPortalAreaTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_Tag_Header", "Tag"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalAreaTypePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AccessPortalAreaTypePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalAreaTypeUid = Guid.NewGuid();
      Entity.DisplayResourceKey = Guid.NewGuid();
      Entity.DescriptionResourceKey = Guid.NewGuid();
      Entity.Tag = string.Empty;
      Entity.Display = string.Empty;
      Entity.Description = string.Empty;
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
      
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.AccessPortalAreaTypeUid).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.AccessPortalAreaTypeUid).Value = Entity.AccessPortalAreaTypeUid;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.AccessPortalAreaTypeUid).IsNull == false)
        Entity.AccessPortalAreaTypeUid = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.AccessPortalAreaTypeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(AccessPortalAreaTypePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalAreaTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalAreaTypeUid'
    /// </summary>
    public static string AccessPortalAreaTypeUid = "AccessPortalAreaTypeUid";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
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
