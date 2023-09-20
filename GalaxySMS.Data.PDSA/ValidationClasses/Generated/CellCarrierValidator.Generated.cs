using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CellCarrierPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CellCarrierPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CellCarrierPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CellCarrierPDSA Entity
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
    /// Clones the current CellCarrierPDSA
    /// </summary>
    /// <returns>A cloned CellCarrierPDSA object</returns>
    public CellCarrierPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CellCarrierPDSA
    /// </summary>
    /// <param name="entityToClone">The CellCarrierPDSA entity to clone</param>
    /// <returns>A cloned CellCarrierPDSA object</returns>
    public CellCarrierPDSA CloneEntity(CellCarrierPDSA entityToClone)
    {
      CellCarrierPDSA newEntity = new CellCarrierPDSA();

      newEntity.CellCarrierUid = entityToClone.CellCarrierUid;
      newEntity.CarrierName = entityToClone.CarrierName;
      newEntity.MMSSuffix = entityToClone.MMSSuffix;
      newEntity.SMSSuffix = entityToClone.SMSSuffix;
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
      
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.CellCarrierUid, GetResourceMessage("GCS_CellCarrierPDSA_CellCarrierUid_Header", "Cell Carrier Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CellCarrierPDSA_CellCarrierUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.CarrierName, GetResourceMessage("GCS_CellCarrierPDSA_CarrierName_Header", "Carrier Name"), true, typeof(string), 65, GetResourceMessage("GCS_CellCarrierPDSA_CarrierName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.MMSSuffix, GetResourceMessage("GCS_CellCarrierPDSA_MMSSuffix_Header", "MMS Suffix"), false, typeof(string), 65, GetResourceMessage("GCS_CellCarrierPDSA_MMSSuffix_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.SMSSuffix, GetResourceMessage("GCS_CellCarrierPDSA_SMSSuffix_Header", "SMS Suffix"), false, typeof(string), 65, GetResourceMessage("GCS_CellCarrierPDSA_SMSSuffix_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CellCarrierPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_CellCarrierPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CellCarrierPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CellCarrierPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CellCarrierPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_CellCarrierPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CellCarrierPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CellCarrierPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CellCarrierPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CellCarrierPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CellCarrierPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.CellCarrierUid = Guid.Empty;
      Entity.CarrierName = string.Empty;
      Entity.MMSSuffix = string.Empty;
      Entity.SMSSuffix = string.Empty;
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
      
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CellCarrierUid).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CellCarrierUid).Value = Entity.CellCarrierUid;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CarrierName).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CarrierName).Value = Entity.CarrierName;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.MMSSuffix).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.MMSSuffix).Value = Entity.MMSSuffix;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.SMSSuffix).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.SMSSuffix).Value = Entity.SMSSuffix;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CellCarrierUid).IsNull == false)
        Entity.CellCarrierUid = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CellCarrierUid).GetAsGuid();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CarrierName).IsNull == false)
        Entity.CarrierName = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.CarrierName).GetAsString();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.MMSSuffix).IsNull == false)
        Entity.MMSSuffix = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.MMSSuffix).GetAsString();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.SMSSuffix).IsNull == false)
        Entity.SMSSuffix = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.SMSSuffix).GetAsString();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CellCarrierPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CellCarrierPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CellCarrierUid'
    /// </summary>
    public static string CellCarrierUid = "CellCarrierUid";
    /// <summary>
    /// Returns 'CarrierName'
    /// </summary>
    public static string CarrierName = "CarrierName";
    /// <summary>
    /// Returns 'MMSSuffix'
    /// </summary>
    public static string MMSSuffix = "MMSSuffix";
    /// <summary>
    /// Returns 'SMSSuffix'
    /// </summary>
    public static string SMSSuffix = "SMSSuffix";
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
