using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsResourceStringLanguagePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsResourceStringLanguagePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsResourceStringLanguagePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsResourceStringLanguagePDSA Entity
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
    /// Clones the current gcsResourceStringLanguagePDSA
    /// </summary>
    /// <returns>A cloned gcsResourceStringLanguagePDSA object</returns>
    public gcsResourceStringLanguagePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsResourceStringLanguagePDSA
    /// </summary>
    /// <param name="entityToClone">The gcsResourceStringLanguagePDSA entity to clone</param>
    /// <returns>A cloned gcsResourceStringLanguagePDSA object</returns>
    public gcsResourceStringLanguagePDSA CloneEntity(gcsResourceStringLanguagePDSA entityToClone)
    {
      gcsResourceStringLanguagePDSA newEntity = new gcsResourceStringLanguagePDSA();

      newEntity.ResourceStringLanguageId = entityToClone.ResourceStringLanguageId;
      newEntity.ResourceId = entityToClone.ResourceId;
      newEntity.LanguageId = entityToClone.LanguageId;
      newEntity.StringValue = entityToClone.StringValue;
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
      
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_ResourceStringLanguageId_Header", "Resource String Language Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_ResourceStringLanguageId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_ResourceId_Header", "Resource Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_ResourceId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_LanguageId_Header", "Language Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_LanguageId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_StringValue_Header", "String Value"), true, typeof(string), 1000, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_StringValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_gcsResourceStringLanguagePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ResourceStringLanguageId = Guid.NewGuid();
      Entity.ResourceId = Guid.NewGuid();
      Entity.LanguageId = Guid.NewGuid();
      Entity.StringValue = string.Empty;
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
      
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId).Value = Entity.ResourceStringLanguageId;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId).Value = Entity.ResourceId;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId).Value = Entity.LanguageId;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue).Value = Entity.StringValue;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId).IsNull == false)
        Entity.ResourceStringLanguageId = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId).GetAsGuid();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId).IsNull == false)
        Entity.ResourceId = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId).GetAsGuid();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId).IsNull == false)
        Entity.LanguageId = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId).GetAsGuid();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue).IsNull == false)
        Entity.StringValue = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue).GetAsString();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsResourceStringLanguagePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ResourceStringLanguageId'
    /// </summary>
    public static string ResourceStringLanguageId = "ResourceStringLanguageId";
    /// <summary>
    /// Returns 'ResourceId'
    /// </summary>
    public static string ResourceId = "ResourceId";
    /// <summary>
    /// Returns 'LanguageId'
    /// </summary>
    public static string LanguageId = "LanguageId";
    /// <summary>
    /// Returns 'StringValue'
    /// </summary>
    public static string StringValue = "StringValue";
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
