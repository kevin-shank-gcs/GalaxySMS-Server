using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AddressPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AddressPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AddressPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AddressPDSA Entity
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
    /// Clones the current AddressPDSA
    /// </summary>
    /// <returns>A cloned AddressPDSA object</returns>
    public AddressPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AddressPDSA
    /// </summary>
    /// <param name="entityToClone">The AddressPDSA entity to clone</param>
    /// <returns>A cloned AddressPDSA object</returns>
    public AddressPDSA CloneEntity(AddressPDSA entityToClone)
    {
      AddressPDSA newEntity = new AddressPDSA();

      newEntity.AddressUid = entityToClone.AddressUid;
      newEntity.StreetAddress = entityToClone.StreetAddress;
      newEntity.PostalCode = entityToClone.PostalCode;
      newEntity.City = entityToClone.City;
      newEntity.StateProvinceUid = entityToClone.StateProvinceUid;
      newEntity.Longitude = entityToClone.Longitude;
      newEntity.Latitude = entityToClone.Latitude;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.StateProvinceName = entityToClone.StateProvinceName;
      newEntity.CountryName = entityToClone.CountryName;
      newEntity.CountryIso = entityToClone.CountryIso;
      newEntity.Iso3 = entityToClone.Iso3;
      newEntity.CountryUid = entityToClone.CountryUid;

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
      
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.AddressUid, GetResourceMessage("GCS_AddressPDSA_AddressUid_Header", "Address Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AddressPDSA_AddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.StreetAddress, GetResourceMessage("GCS_AddressPDSA_StreetAddress_Header", "Street Address"), true, typeof(string), 256, GetResourceMessage("GCS_AddressPDSA_StreetAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.PostalCode, GetResourceMessage("GCS_AddressPDSA_PostalCode_Header", "Postal Code"), true, typeof(string), 20, GetResourceMessage("GCS_AddressPDSA_PostalCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.City, GetResourceMessage("GCS_AddressPDSA_City_Header", "City"), true, typeof(string), 65, GetResourceMessage("GCS_AddressPDSA_City_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.StateProvinceUid, GetResourceMessage("GCS_AddressPDSA_StateProvinceUid_Header", "State Province Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AddressPDSA_StateProvinceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.Longitude, GetResourceMessage("GCS_AddressPDSA_Longitude_Header", "Longitude"), false, typeof(double), 53, GetResourceMessage("GCS_AddressPDSA_Longitude_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDouble("-79228162514264337593543950335"), Convert.ToDouble("79228162514264337593543950335"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.Latitude, GetResourceMessage("GCS_AddressPDSA_Latitude_Header", "Latitude"), false, typeof(double), 53, GetResourceMessage("GCS_AddressPDSA_Latitude_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDouble("-79228162514264337593543950335"), Convert.ToDouble("79228162514264337593543950335"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AddressPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AddressPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AddressPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AddressPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AddressPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AddressPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AddressPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AddressPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AddressPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AddressPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.StateProvinceName, GetResourceMessage("GCS_AddressPDSA_StateProvinceName_Header", "State Province Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AddressPDSA_StateProvinceName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.CountryName, GetResourceMessage("GCS_AddressPDSA_CountryName_Header", "Country Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AddressPDSA_CountryName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.CountryIso, GetResourceMessage("GCS_AddressPDSA_CountryIso_Header", "Country Iso"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AddressPDSA_CountryIso_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.Iso3, GetResourceMessage("GCS_AddressPDSA_Iso3_Header", "Iso 3"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AddressPDSA_Iso3_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AddressPDSAValidator.ColumnNames.CountryUid, GetResourceMessage("GCS_AddressPDSA_CountryUid_Header", "Country Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AddressPDSA_CountryUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AddressUid = Guid.NewGuid();
      Entity.StreetAddress = string.Empty;
      Entity.PostalCode = string.Empty;
      Entity.City = string.Empty;
      Entity.StateProvinceUid = Guid.NewGuid();
      Entity.Longitude = 0;
      Entity.Latitude = 0;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.StateProvinceName = string.Empty;
      Entity.CountryName = string.Empty;
      Entity.CountryIso = string.Empty;
      Entity.Iso3 = string.Empty;
      Entity.CountryUid = Guid.NewGuid();

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
      
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.AddressUid).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.AddressUid).Value = Entity.AddressUid;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.StreetAddress).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.StreetAddress).Value = Entity.StreetAddress;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.PostalCode).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.PostalCode).Value = Entity.PostalCode;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.City).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.City).Value = Entity.City;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceUid).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceUid).Value = Entity.StateProvinceUid;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.Longitude).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.Longitude).Value = Entity.Longitude;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.Latitude).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.Latitude).Value = Entity.Latitude;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceName).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceName).Value = Entity.StateProvinceName;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryName).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryName).Value = Entity.CountryName;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryIso).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryIso).Value = Entity.CountryIso;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.Iso3).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.Iso3).Value = Entity.Iso3;
      if(!Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryUid).SetAsNull)
        Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryUid).Value = Entity.CountryUid;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.AddressUid).IsNull == false)
        Entity.AddressUid = Properties.GetByName(AddressPDSAValidator.ColumnNames.AddressUid).GetAsGuid();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.StreetAddress).IsNull == false)
        Entity.StreetAddress = Properties.GetByName(AddressPDSAValidator.ColumnNames.StreetAddress).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.PostalCode).IsNull == false)
        Entity.PostalCode = Properties.GetByName(AddressPDSAValidator.ColumnNames.PostalCode).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.City).IsNull == false)
        Entity.City = Properties.GetByName(AddressPDSAValidator.ColumnNames.City).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceUid).IsNull == false)
        Entity.StateProvinceUid = Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceUid).GetAsGuid();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.Longitude).IsNull == false)
        Entity.Longitude = Properties.GetByName(AddressPDSAValidator.ColumnNames.Longitude).GetAsDouble();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.Latitude).IsNull == false)
        Entity.Latitude = Properties.GetByName(AddressPDSAValidator.ColumnNames.Latitude).GetAsDouble();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AddressPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AddressPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AddressPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceName).IsNull == false)
        Entity.StateProvinceName = Properties.GetByName(AddressPDSAValidator.ColumnNames.StateProvinceName).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryName).IsNull == false)
        Entity.CountryName = Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryName).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryIso).IsNull == false)
        Entity.CountryIso = Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryIso).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.Iso3).IsNull == false)
        Entity.Iso3 = Properties.GetByName(AddressPDSAValidator.ColumnNames.Iso3).GetAsString();
      if(Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryUid).IsNull == false)
        Entity.CountryUid = Properties.GetByName(AddressPDSAValidator.ColumnNames.CountryUid).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AddressPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AddressUid'
    /// </summary>
    public static string AddressUid = "AddressUid";
    /// <summary>
    /// Returns 'StreetAddress'
    /// </summary>
    public static string StreetAddress = "StreetAddress";
    /// <summary>
    /// Returns 'PostalCode'
    /// </summary>
    public static string PostalCode = "PostalCode";
    /// <summary>
    /// Returns 'City'
    /// </summary>
    public static string City = "City";
    /// <summary>
    /// Returns 'StateProvinceUid'
    /// </summary>
    public static string StateProvinceUid = "StateProvinceUid";
    /// <summary>
    /// Returns 'Longitude'
    /// </summary>
    public static string Longitude = "Longitude";
    /// <summary>
    /// Returns 'Latitude'
    /// </summary>
    public static string Latitude = "Latitude";
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
    /// Returns 'StateProvinceName'
    /// </summary>
    public static string StateProvinceName = "StateProvinceName";
    /// <summary>
    /// Returns 'CountryName'
    /// </summary>
    public static string CountryName = "CountryName";
    /// <summary>
    /// Returns 'CountryIso'
    /// </summary>
    public static string CountryIso = "CountryIso";
    /// <summary>
    /// Returns 'Iso3'
    /// </summary>
    public static string Iso3 = "Iso3";
    /// <summary>
    /// Returns 'CountryUid'
    /// </summary>
    public static string CountryUid = "CountryUid";
    }
    #endregion
  }
}
