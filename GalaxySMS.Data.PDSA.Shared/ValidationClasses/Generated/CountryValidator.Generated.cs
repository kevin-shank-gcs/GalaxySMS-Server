using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the CountryPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CountryPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CountryPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CountryPDSA Entity
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
    /// Clones the current CountryPDSA
    /// </summary>
    /// <returns>A cloned CountryPDSA object</returns>
    public CountryPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CountryPDSA
    /// </summary>
    /// <param name="entityToClone">The CountryPDSA entity to clone</param>
    /// <returns>A cloned CountryPDSA object</returns>
    public CountryPDSA CloneEntity(CountryPDSA entityToClone)
    {
      CountryPDSA newEntity = new CountryPDSA();

      newEntity.CountryUid = entityToClone.CountryUid;
      newEntity.CountryIso = entityToClone.CountryIso;
      newEntity.CountryName = entityToClone.CountryName;
      newEntity.LongCountryName = entityToClone.LongCountryName;
      newEntity.Iso3 = entityToClone.Iso3;
      newEntity.NumberCode = entityToClone.NumberCode;
      newEntity.UnitedNationsMemberState = entityToClone.UnitedNationsMemberState;
      newEntity.CallingCode = entityToClone.CallingCode;
      newEntity.CCTLD = entityToClone.CCTLD;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.FlagImage = entityToClone.FlagImage;

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
      
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.CountryUid, GetResourceMessage("GCS_CountryPDSA_CountryUid_Header", "Country Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_CountryPDSA_CountryUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.CountryIso, GetResourceMessage("GCS_CountryPDSA_CountryIso_Header", "Country Iso"), true, typeof(string), 2, GetResourceMessage("GCS_CountryPDSA_CountryIso_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.CountryName, GetResourceMessage("GCS_CountryPDSA_CountryName_Header", "Country Name"), true, typeof(string), 100, GetResourceMessage("GCS_CountryPDSA_CountryName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.LongCountryName, GetResourceMessage("GCS_CountryPDSA_LongCountryName_Header", "Long Country Name"), true, typeof(string), 100, GetResourceMessage("GCS_CountryPDSA_LongCountryName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.Iso3, GetResourceMessage("GCS_CountryPDSA_Iso3_Header", "Iso 3"), true, typeof(string), 3, GetResourceMessage("GCS_CountryPDSA_Iso3_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.NumberCode, GetResourceMessage("GCS_CountryPDSA_NumberCode_Header", "Number Code"), true, typeof(string), 6, GetResourceMessage("GCS_CountryPDSA_NumberCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.UnitedNationsMemberState, GetResourceMessage("GCS_CountryPDSA_UnitedNationsMemberState_Header", "United Nations Member State"), true, typeof(bool), -1, GetResourceMessage("GCS_CountryPDSA_UnitedNationsMemberState_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.CallingCode, GetResourceMessage("GCS_CountryPDSA_CallingCode_Header", "Calling Code"), false, typeof(string), 10, GetResourceMessage("GCS_CountryPDSA_CallingCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.CCTLD, GetResourceMessage("GCS_CountryPDSA_CCTLD_Header", "CCTLD"), false, typeof(string), 5, GetResourceMessage("GCS_CountryPDSA_CCTLD_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_CountryPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_CountryPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_CountryPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CountryPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_CountryPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_CountryPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_CountryPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_CountryPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_CountryPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_CountryPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(CountryPDSAValidator.ColumnNames.FlagImage, GetResourceMessage("GCS_CountryPDSA_FlagImage_Header", "Flag Image"), false, typeof(byte[]), 2147483647, GetResourceMessage("GCS_CountryPDSA_FlagImage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.CountryUid = Guid.Empty;
      Entity.CountryIso = string.Empty;
      Entity.CountryName = string.Empty;
      Entity.LongCountryName = string.Empty;
      Entity.Iso3 = string.Empty;
      Entity.NumberCode = string.Empty;
      Entity.UnitedNationsMemberState = false;
      Entity.CallingCode = string.Empty;
      Entity.CCTLD = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.FlagImage = null;

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
      
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryUid).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryUid).Value = Entity.CountryUid;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryIso).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryIso).Value = Entity.CountryIso;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryName).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryName).Value = Entity.CountryName;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.LongCountryName).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.LongCountryName).Value = Entity.LongCountryName;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.Iso3).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.Iso3).Value = Entity.Iso3;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.NumberCode).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.NumberCode).Value = Entity.NumberCode;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.UnitedNationsMemberState).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.UnitedNationsMemberState).Value = Entity.UnitedNationsMemberState;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.CallingCode).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.CallingCode).Value = Entity.CallingCode;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.CCTLD).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.CCTLD).Value = Entity.CCTLD;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(CountryPDSAValidator.ColumnNames.FlagImage).SetAsNull)
        Properties.GetByName(CountryPDSAValidator.ColumnNames.FlagImage).Value = Entity.FlagImage;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryUid).IsNull == false)
        Entity.CountryUid = Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryUid).GetAsGuid();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryIso).IsNull == false)
        Entity.CountryIso = Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryIso).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryName).IsNull == false)
        Entity.CountryName = Properties.GetByName(CountryPDSAValidator.ColumnNames.CountryName).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.LongCountryName).IsNull == false)
        Entity.LongCountryName = Properties.GetByName(CountryPDSAValidator.ColumnNames.LongCountryName).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.Iso3).IsNull == false)
        Entity.Iso3 = Properties.GetByName(CountryPDSAValidator.ColumnNames.Iso3).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.NumberCode).IsNull == false)
        Entity.NumberCode = Properties.GetByName(CountryPDSAValidator.ColumnNames.NumberCode).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.UnitedNationsMemberState).IsNull == false)
        Entity.UnitedNationsMemberState = Properties.GetByName(CountryPDSAValidator.ColumnNames.UnitedNationsMemberState).GetAsBool();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.CallingCode).IsNull == false)
        Entity.CallingCode = Properties.GetByName(CountryPDSAValidator.ColumnNames.CallingCode).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.CCTLD).IsNull == false)
        Entity.CCTLD = Properties.GetByName(CountryPDSAValidator.ColumnNames.CCTLD).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(CountryPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(CountryPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(CountryPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(CountryPDSAValidator.ColumnNames.FlagImage).IsNull == false)
        Entity.FlagImage = Properties.GetByName(CountryPDSAValidator.ColumnNames.FlagImage).GetAsByteArray();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CountryPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CountryUid'
    /// </summary>
    public static string CountryUid = "CountryUid";
    /// <summary>
    /// Returns 'CountryIso'
    /// </summary>
    public static string CountryIso = "CountryIso";
    /// <summary>
    /// Returns 'CountryName'
    /// </summary>
    public static string CountryName = "CountryName";
    /// <summary>
    /// Returns 'LongCountryName'
    /// </summary>
    public static string LongCountryName = "LongCountryName";
    /// <summary>
    /// Returns 'Iso3'
    /// </summary>
    public static string Iso3 = "Iso3";
    /// <summary>
    /// Returns 'NumberCode'
    /// </summary>
    public static string NumberCode = "NumberCode";
    /// <summary>
    /// Returns 'UnitedNationsMemberState'
    /// </summary>
    public static string UnitedNationsMemberState = "UnitedNationsMemberState";
    /// <summary>
    /// Returns 'CallingCode'
    /// </summary>
    public static string CallingCode = "CallingCode";
    /// <summary>
    /// Returns 'CCTLD'
    /// </summary>
    public static string CCTLD = "CCTLD";
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
    /// Returns 'FlagImage'
    /// </summary>
    public static string FlagImage = "FlagImage";
    }
    #endregion
  }
}
