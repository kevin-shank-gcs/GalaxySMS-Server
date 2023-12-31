using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsSystemPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsSystemPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsSystemPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsSystemPDSA Entity
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
    /// Clones the current gcsSystemPDSA
    /// </summary>
    /// <returns>A cloned gcsSystemPDSA object</returns>
    public gcsSystemPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsSystemPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsSystemPDSA entity to clone</param>
    /// <returns>A cloned gcsSystemPDSA object</returns>
    public gcsSystemPDSA CloneEntity(gcsSystemPDSA entityToClone)
    {
      gcsSystemPDSA newEntity = new gcsSystemPDSA();

      newEntity.SystemId = entityToClone.SystemId;
      newEntity.SystemName = entityToClone.SystemName;
      newEntity.CompanyName = entityToClone.CompanyName;
      newEntity.SupportCompany = entityToClone.SupportCompany;
      newEntity.SupportContact = entityToClone.SupportContact;
      newEntity.SupportPhone = entityToClone.SupportPhone;
      newEntity.SupportEmail = entityToClone.SupportEmail;
      newEntity.SupportUrl = entityToClone.SupportUrl;
      newEntity.SupportImage = entityToClone.SupportImage;
      newEntity.SystemImage = entityToClone.SystemImage;
      newEntity.License = entityToClone.License;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.PublicKey = entityToClone.PublicKey;

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
      
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SystemId, GetResourceMessage("GCS_gcsSystemPDSA_SystemId_Header", "System Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsSystemPDSA_SystemId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SystemName, GetResourceMessage("GCS_gcsSystemPDSA_SystemName_Header", "System Name"), true, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_SystemName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.CompanyName, GetResourceMessage("GCS_gcsSystemPDSA_CompanyName_Header", "Company Name"), false, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_CompanyName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SupportCompany, GetResourceMessage("GCS_gcsSystemPDSA_SupportCompany_Header", "Support Company"), false, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_SupportCompany_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SupportContact, GetResourceMessage("GCS_gcsSystemPDSA_SupportContact_Header", "Support Contact"), false, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_SupportContact_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SupportPhone, GetResourceMessage("GCS_gcsSystemPDSA_SupportPhone_Header", "Support Phone"), false, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_SupportPhone_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SupportEmail, GetResourceMessage("GCS_gcsSystemPDSA_SupportEmail_Header", "Support Email"), false, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_SupportEmail_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SupportUrl, GetResourceMessage("GCS_gcsSystemPDSA_SupportUrl_Header", "Support Url"), false, typeof(string), 65, GetResourceMessage("GCS_gcsSystemPDSA_SupportUrl_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SupportImage, GetResourceMessage("GCS_gcsSystemPDSA_SupportImage_Header", "Support Image"), false, typeof(byte[]), 2147483647, GetResourceMessage("GCS_gcsSystemPDSA_SupportImage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.SystemImage, GetResourceMessage("GCS_gcsSystemPDSA_SystemImage_Header", "System Image"), false, typeof(byte[]), 2147483647, GetResourceMessage("GCS_gcsSystemPDSA_SystemImage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.License, GetResourceMessage("GCS_gcsSystemPDSA_License_Header", "License"), false, typeof(string), 1073741823, GetResourceMessage("GCS_gcsSystemPDSA_License_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsSystemPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsSystemPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsSystemPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsSystemPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsSystemPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsSystemPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsSystemPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsSystemPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsSystemPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsSystemPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcsSystemPDSAValidator.ColumnNames.PublicKey, GetResourceMessage("GCS_gcsSystemPDSA_PublicKey_Header", "Public Key"), false, typeof(string), 1073741823, GetResourceMessage("GCS_gcsSystemPDSA_PublicKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.SystemId = Guid.Empty;
      Entity.SystemName = string.Empty;
      Entity.CompanyName = string.Empty;
      Entity.SupportCompany = string.Empty;
      Entity.SupportContact = string.Empty;
      Entity.SupportPhone = string.Empty;
      Entity.SupportEmail = string.Empty;
      Entity.SupportUrl = string.Empty;
      Entity.SupportImage = null;
      Entity.SystemImage = null;
      Entity.License = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.PublicKey = string.Empty;

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
      
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemId).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemId).Value = Entity.SystemId;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemName).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemName).Value = Entity.SystemName;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.CompanyName).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.CompanyName).Value = Entity.CompanyName;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportCompany).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportCompany).Value = Entity.SupportCompany;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportContact).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportContact).Value = Entity.SupportContact;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportPhone).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportPhone).Value = Entity.SupportPhone;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportEmail).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportEmail).Value = Entity.SupportEmail;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportUrl).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportUrl).Value = Entity.SupportUrl;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportImage).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportImage).Value = Entity.SupportImage;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemImage).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemImage).Value = Entity.SystemImage;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.License).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.License).Value = Entity.License;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.PublicKey).SetAsNull)
        Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.PublicKey).Value = Entity.PublicKey;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemId).IsNull == false)
        Entity.SystemId = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemId).GetAsGuid();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemName).IsNull == false)
        Entity.SystemName = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemName).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.CompanyName).IsNull == false)
        Entity.CompanyName = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.CompanyName).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportCompany).IsNull == false)
        Entity.SupportCompany = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportCompany).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportContact).IsNull == false)
        Entity.SupportContact = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportContact).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportPhone).IsNull == false)
        Entity.SupportPhone = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportPhone).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportEmail).IsNull == false)
        Entity.SupportEmail = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportEmail).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportUrl).IsNull == false)
        Entity.SupportUrl = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportUrl).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportImage).IsNull == false)
        Entity.SupportImage = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SupportImage).GetAsByteArray();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemImage).IsNull == false)
        Entity.SystemImage = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.SystemImage).GetAsByteArray();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.License).IsNull == false)
        Entity.License = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.License).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.PublicKey).IsNull == false)
        Entity.PublicKey = Properties.GetByName(gcsSystemPDSAValidator.ColumnNames.PublicKey).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsSystemPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'SystemId'
    /// </summary>
    public static string SystemId = "SystemId";
    /// <summary>
    /// Returns 'SystemName'
    /// </summary>
    public static string SystemName = "SystemName";
    /// <summary>
    /// Returns 'CompanyName'
    /// </summary>
    public static string CompanyName = "CompanyName";
    /// <summary>
    /// Returns 'SupportCompany'
    /// </summary>
    public static string SupportCompany = "SupportCompany";
    /// <summary>
    /// Returns 'SupportContact'
    /// </summary>
    public static string SupportContact = "SupportContact";
    /// <summary>
    /// Returns 'SupportPhone'
    /// </summary>
    public static string SupportPhone = "SupportPhone";
    /// <summary>
    /// Returns 'SupportEmail'
    /// </summary>
    public static string SupportEmail = "SupportEmail";
    /// <summary>
    /// Returns 'SupportUrl'
    /// </summary>
    public static string SupportUrl = "SupportUrl";
    /// <summary>
    /// Returns 'SupportImage'
    /// </summary>
    public static string SupportImage = "SupportImage";
    /// <summary>
    /// Returns 'SystemImage'
    /// </summary>
    public static string SystemImage = "SystemImage";
    /// <summary>
    /// Returns 'License'
    /// </summary>
    public static string License = "License";
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
    /// Returns 'PublicKey'
    /// </summary>
    public static string PublicKey = "PublicKey";
    }
    #endregion
  }
}
