using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CredentialH1030237BitPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialH1030237BitPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialH1030237BitPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialH1030237BitPDSA Entity
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
    /// Clones the current CredentialH1030237BitPDSA
    /// </summary>
    /// <returns>A cloned CredentialH1030237BitPDSA object</returns>
    public CredentialH1030237BitPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialH1030237BitPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialH1030237BitPDSA entity to clone</param>
    /// <returns>A cloned CredentialH1030237BitPDSA object</returns>
    public CredentialH1030237BitPDSA CloneEntity(CredentialH1030237BitPDSA entityToClone)
    {
      CredentialH1030237BitPDSA newEntity = new CredentialH1030237BitPDSA();

      newEntity.CredentialUid = entityToClone.CredentialUid;
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
      
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid, GetResourceMessage("GCS_CredentialH1030237BitPDSA_CredentialUid_Header", "Credential Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CredentialH1030237BitPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.IdCode, GetResourceMessage("GCS_CredentialH1030237BitPDSA_IdCode_Header", "ID Code"), true, typeof(long), 19, GetResourceMessage("GCS_CredentialH1030237BitPDSA_IdCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CredentialH1030237BitPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_CredentialH1030237BitPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CredentialH1030237BitPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialH1030237BitPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CredentialH1030237BitPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_CredentialH1030237BitPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CredentialH1030237BitPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CredentialH1030237BitPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CredentialH1030237BitPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CredentialH1030237BitPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
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
      
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.IdCode).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.IdCode).Value = Entity.IdCode;
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.IdCode).IsNull == false)
        Entity.IdCode = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.IdCode).GetAsLong();
      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialH1030237BitPDSA class.
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
