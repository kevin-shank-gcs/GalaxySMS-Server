using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalMultiFactorModePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalMultiFactorModePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalMultiFactorModePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalMultiFactorModePDSA Entity
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
    /// Clones the current AccessPortalMultiFactorModePDSA
    /// </summary>
    /// <returns>A cloned AccessPortalMultiFactorModePDSA object</returns>
    public AccessPortalMultiFactorModePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalMultiFactorModePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalMultiFactorModePDSA entity to clone</param>
    /// <returns>A cloned AccessPortalMultiFactorModePDSA object</returns>
    public AccessPortalMultiFactorModePDSA CloneEntity(AccessPortalMultiFactorModePDSA entityToClone)
    {
      AccessPortalMultiFactorModePDSA newEntity = new AccessPortalMultiFactorModePDSA();

      newEntity.AccessPortalMultiFactorModeUid = entityToClone.AccessPortalMultiFactorModeUid;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Display = entityToClone.Display;
      newEntity.Description = entityToClone.Description;
      newEntity.Code = entityToClone.Code;
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
      
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.AccessPortalMultiFactorModeUid, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_AccessPortalMultiFactorModeUid_Header", "Access Portal Multi Factor Mode Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_AccessPortalMultiFactorModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Code, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_Code_Header", "Code"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_Code_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalMultiFactorModePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AccessPortalMultiFactorModePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalMultiFactorModeUid = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.Description = string.Empty;
      Entity.Code = 0;
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
      
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.AccessPortalMultiFactorModeUid).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.AccessPortalMultiFactorModeUid).Value = Entity.AccessPortalMultiFactorModeUid;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Code).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Code).Value = Entity.Code;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.AccessPortalMultiFactorModeUid).IsNull == false)
        Entity.AccessPortalMultiFactorModeUid = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.AccessPortalMultiFactorModeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Code).IsNull == false)
        Entity.Code = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.Code).GetAsShort();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(AccessPortalMultiFactorModePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalMultiFactorModePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalMultiFactorModeUid'
    /// </summary>
    public static string AccessPortalMultiFactorModeUid = "AccessPortalMultiFactorModeUid";
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
    /// Returns 'Code'
    /// </summary>
    public static string Code = "Code";
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
