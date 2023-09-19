using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the ClusterTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ClusterTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ClusterTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ClusterTypePDSA Entity
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
    /// Clones the current ClusterTypePDSA
    /// </summary>
    /// <returns>A cloned ClusterTypePDSA object</returns>
    public ClusterTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ClusterTypePDSA
    /// </summary>
    /// <param name="entityToClone">The ClusterTypePDSA entity to clone</param>
    /// <returns>A cloned ClusterTypePDSA object</returns>
    public ClusterTypePDSA CloneEntity(ClusterTypePDSA entityToClone)
    {
      ClusterTypePDSA newEntity = new ClusterTypePDSA();

      newEntity.ClusterTypeUid = entityToClone.ClusterTypeUid;
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
      
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.ClusterTypeUid, GetResourceMessage("GCS_ClusterTypePDSA_ClusterTypeUid_Header", "Cluster Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_ClusterTypePDSA_ClusterTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_ClusterTypePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_ClusterTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_ClusterTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_ClusterTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_ClusterTypePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_ClusterTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_ClusterTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_ClusterTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.TypeCode, GetResourceMessage("GCS_ClusterTypePDSA_TypeCode_Header", "Type Code"), true, typeof(string), 16, GetResourceMessage("GCS_ClusterTypePDSA_TypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.IsDefault, GetResourceMessage("GCS_ClusterTypePDSA_IsDefault_Header", "Is Default"), false, typeof(bool?), -1, GetResourceMessage("GCS_ClusterTypePDSA_IsDefault_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_ClusterTypePDSA_IsActive_Header", "Is Active"), false, typeof(bool?), -1, GetResourceMessage("GCS_ClusterTypePDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_ClusterTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_ClusterTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_ClusterTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_ClusterTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_ClusterTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_ClusterTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_ClusterTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_ClusterTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_ClusterTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_ClusterTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ClusterTypePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_ClusterTypePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_ClusterTypePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ClusterTypeUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ClusterTypeUid).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ClusterTypeUid).Value = Entity.ClusterTypeUid;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.TypeCode).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.TypeCode).Value = Entity.TypeCode;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsDefault).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsDefault).Value = Entity.IsDefault;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ClusterTypeUid).IsNull == false)
        Entity.ClusterTypeUid = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ClusterTypeUid).GetAsGuid();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.TypeCode).IsNull == false)
        Entity.TypeCode = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.TypeCode).GetAsString();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsDefault).IsNull == false)
        Entity.IsDefault = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsDefault).GetValueAsBoolean();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.IsActive).GetValueAsBoolean();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(ClusterTypePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterTypeUid'
    /// </summary>
    public static string ClusterTypeUid = "ClusterTypeUid";
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
