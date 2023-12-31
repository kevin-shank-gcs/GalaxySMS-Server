using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CredentialPIV75BitPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialPIV75BitPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialPIV75BitPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialPIV75BitPDSA Entity
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
    /// Clones the current CredentialPIV75BitPDSA
    /// </summary>
    /// <returns>A cloned CredentialPIV75BitPDSA object</returns>
    public CredentialPIV75BitPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialPIV75BitPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialPIV75BitPDSA entity to clone</param>
    /// <returns>A cloned CredentialPIV75BitPDSA object</returns>
    public CredentialPIV75BitPDSA CloneEntity(CredentialPIV75BitPDSA entityToClone)
    {
      CredentialPIV75BitPDSA newEntity = new CredentialPIV75BitPDSA();

      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.AgencyCode = entityToClone.AgencyCode;
      newEntity.SiteCode = entityToClone.SiteCode;
      newEntity.CredentialCode = entityToClone.CredentialCode;
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
      
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid, GetResourceMessage("GCS_CredentialPIV75BitPDSA_CredentialUid_Header", "Credential Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CredentialPIV75BitPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode, GetResourceMessage("GCS_CredentialPIV75BitPDSA_AgencyCode_Header", "Agency Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialPIV75BitPDSA_AgencyCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode, GetResourceMessage("GCS_CredentialPIV75BitPDSA_SiteCode_Header", "Site Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialPIV75BitPDSA_SiteCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode, GetResourceMessage("GCS_CredentialPIV75BitPDSA_CredentialCode_Header", "Credential Code"), true, typeof(int), 10, GetResourceMessage("GCS_CredentialPIV75BitPDSA_CredentialCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CredentialPIV75BitPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_CredentialPIV75BitPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CredentialPIV75BitPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialPIV75BitPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CredentialPIV75BitPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_CredentialPIV75BitPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CredentialPIV75BitPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialPIV75BitPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CredentialPIV75BitPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialPIV75BitPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
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
      Entity.AgencyCode = 0;
      Entity.SiteCode = 0;
      Entity.CredentialCode = 0;
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
      
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode).Value = Entity.AgencyCode;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode).Value = Entity.SiteCode;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode).Value = Entity.CredentialCode;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode).IsNull == false)
        Entity.AgencyCode = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode).GetAsInteger();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode).IsNull == false)
        Entity.SiteCode = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode).GetAsInteger();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode).IsNull == false)
        Entity.CredentialCode = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode).GetAsInteger();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialPIV75BitPDSA class.
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
    /// Returns 'AgencyCode'
    /// </summary>
    public static string AgencyCode = "AgencyCode";
    /// <summary>
    /// Returns 'SiteCode'
    /// </summary>
    public static string SiteCode = "SiteCode";
    /// <summary>
    /// Returns 'CredentialCode'
    /// </summary>
    public static string CredentialCode = "CredentialCode";
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
