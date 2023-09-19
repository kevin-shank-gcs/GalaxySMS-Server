using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsApplicationAuditTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsApplicationAuditTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsApplicationAuditTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsApplicationAuditTypePDSA Entity
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
    /// Clones the current gcsApplicationAuditTypePDSA
    /// </summary>
    /// <returns>A cloned gcsApplicationAuditTypePDSA object</returns>
    public gcsApplicationAuditTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsApplicationAuditTypePDSA
    /// </summary>
    /// <param name="entityToClone">The gcsApplicationAuditTypePDSA entity to clone</param>
    /// <returns>A cloned gcsApplicationAuditTypePDSA object</returns>
    public gcsApplicationAuditTypePDSA CloneEntity(gcsApplicationAuditTypePDSA entityToClone)
    {
      gcsApplicationAuditTypePDSA newEntity = new gcsApplicationAuditTypePDSA();

      newEntity.ApplicationAuditTypeId = entityToClone.ApplicationAuditTypeId;
      newEntity.Display = entityToClone.Display;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.Description = entityToClone.Description;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.TypeCode = entityToClone.TypeCode;
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
      
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.ApplicationAuditTypeId, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_ApplicationAuditTypeId_Header", "Application Audit Type Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_ApplicationAuditTypeId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_Display_Header", "Display"), true, typeof(string), 255, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.TypeCode, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_TypeCode_Header", "Type Code"), true, typeof(string), 100, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_TypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsApplicationAuditTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsApplicationAuditTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ApplicationAuditTypeId = Guid.NewGuid();
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.NewGuid();
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.NewGuid();
      Entity.TypeCode = string.Empty;
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
      
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ApplicationAuditTypeId).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ApplicationAuditTypeId).Value = Entity.ApplicationAuditTypeId;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.TypeCode).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.TypeCode).Value = Entity.TypeCode;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ApplicationAuditTypeId).IsNull == false)
        Entity.ApplicationAuditTypeId = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ApplicationAuditTypeId).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.TypeCode).IsNull == false)
        Entity.TypeCode = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.TypeCode).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsApplicationAuditTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsApplicationAuditTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ApplicationAuditTypeId'
    /// </summary>
    public static string ApplicationAuditTypeId = "ApplicationAuditTypeId";
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
