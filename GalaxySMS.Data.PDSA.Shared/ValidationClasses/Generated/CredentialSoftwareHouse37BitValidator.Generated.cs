using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CredentialSoftwareHouse37BitPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialSoftwareHouse37BitPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialSoftwareHouse37BitPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialSoftwareHouse37BitPDSA Entity
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
    /// Clones the current CredentialSoftwareHouse37BitPDSA
    /// </summary>
    /// <returns>A cloned CredentialSoftwareHouse37BitPDSA object</returns>
    public CredentialSoftwareHouse37BitPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialSoftwareHouse37BitPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialSoftwareHouse37BitPDSA entity to clone</param>
    /// <returns>A cloned CredentialSoftwareHouse37BitPDSA object</returns>
    public CredentialSoftwareHouse37BitPDSA CloneEntity(CredentialSoftwareHouse37BitPDSA entityToClone)
    {
      CredentialSoftwareHouse37BitPDSA newEntity = new CredentialSoftwareHouse37BitPDSA();

      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.FacilityCode = entityToClone.FacilityCode;
      newEntity.SiteCode = entityToClone.SiteCode;
      newEntity.IDCode = entityToClone.IDCode;
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
      
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.CredentialUid, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_CredentialUid_Header", "Credential Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.FacilityCode, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_FacilityCode_Header", "Facility Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_FacilityCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.SiteCode, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_SiteCode_Header", "Site Code"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_SiteCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.IDCode, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_IDCode_Header", "ID Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_IDCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialSoftwareHouse37BitPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
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
      Entity.FacilityCode = 0;
      Entity.SiteCode = 0;
      Entity.IDCode = 0;
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
      
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.CredentialUid).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.FacilityCode).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.FacilityCode).Value = Entity.FacilityCode;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.SiteCode).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.SiteCode).Value = Entity.SiteCode;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.IDCode).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.IDCode).Value = Entity.IDCode;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.FacilityCode).IsNull == false)
        Entity.FacilityCode = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.FacilityCode).GetAsInteger();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.SiteCode).IsNull == false)
        Entity.SiteCode = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.SiteCode).GetAsShort();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.IDCode).IsNull == false)
        Entity.IDCode = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.IDCode).GetAsInteger();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CredentialSoftwareHouse37BitPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialSoftwareHouse37BitPDSA class.
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
    /// Returns 'FacilityCode'
    /// </summary>
    public static string FacilityCode = "FacilityCode";
    /// <summary>
    /// Returns 'SiteCode'
    /// </summary>
    public static string SiteCode = "SiteCode";
    /// <summary>
    /// Returns 'IDCode'
    /// </summary>
    public static string IDCode = "IDCode";
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
