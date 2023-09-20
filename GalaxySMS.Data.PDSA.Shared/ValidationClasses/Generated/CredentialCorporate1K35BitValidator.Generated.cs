using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CredentialCorporate1K35BitPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialCorporate1K35BitPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialCorporate1K35BitPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialCorporate1K35BitPDSA Entity
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
    /// Clones the current CredentialCorporate1K35BitPDSA
    /// </summary>
    /// <returns>A cloned CredentialCorporate1K35BitPDSA object</returns>
    public CredentialCorporate1K35BitPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialCorporate1K35BitPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialCorporate1K35BitPDSA entity to clone</param>
    /// <returns>A cloned CredentialCorporate1K35BitPDSA object</returns>
    public CredentialCorporate1K35BitPDSA CloneEntity(CredentialCorporate1K35BitPDSA entityToClone)
    {
      CredentialCorporate1K35BitPDSA newEntity = new CredentialCorporate1K35BitPDSA();

      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.CompanyCode = entityToClone.CompanyCode;
      newEntity.IdCode = entityToClone.IdCode;
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
      
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CredentialUid, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_CredentialUid_Header", "Credential Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CompanyCode, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_CompanyCode_Header", "Company Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_CompanyCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.IdCode, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_IdCode_Header", "Id Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_IdCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialCorporate1K35BitPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialCorporate1K35BitPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.CredentialUid = Guid.Empty;
      Entity.CompanyCode = 0;
      Entity.IdCode = 0;
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
      
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CredentialUid).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CompanyCode).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CompanyCode).Value = Entity.CompanyCode;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.IdCode).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.IdCode).Value = Entity.IdCode;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CompanyCode).IsNull == false)
        Entity.CompanyCode = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.CompanyCode).GetAsInteger();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.IdCode).IsNull == false)
        Entity.IdCode = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.IdCode).GetAsInteger();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CredentialCorporate1K35BitPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialCorporate1K35BitPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CredentialUid'
    /// </summary>
    public static string CredentialUid = "CredentialUid";
    /// <summary>
    /// Returns 'CompanyCode'
    /// </summary>
    public static string CompanyCode = "CompanyCode";
    /// <summary>
    /// Returns 'IdCode'
    /// </summary>
    public static string IdCode = "IdCode";
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
