using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the SitePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class SitePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private SitePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new SitePDSA Entity
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
    /// Clones the current SitePDSA
    /// </summary>
    /// <returns>A cloned SitePDSA object</returns>
    public SitePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in SitePDSA
    /// </summary>
    /// <param name="entityToClone">The SitePDSA entity to clone</param>
    /// <returns>A cloned SitePDSA object</returns>
    public SitePDSA CloneEntity(SitePDSA entityToClone)
    {
      SitePDSA newEntity = new SitePDSA();

      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.RegionUid = entityToClone.RegionUid;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.SiteId = entityToClone.SiteId;
      newEntity.BinaryResourceUid = entityToClone.BinaryResourceUid;
      //newEntity.Longitude = entityToClone.Longitude;
      //newEntity.Latitude = entityToClone.Latitude;
      newEntity.AddressUid = entityToClone.AddressUid;
      newEntity.EntityId = entityToClone.EntityId;

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
      
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_SitePDSA_SiteUid_Header", "Site Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_SitePDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.RegionUid, GetResourceMessage("GCS_SitePDSA_RegionUid_Header", "Region Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_SitePDSA_RegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.SiteName, GetResourceMessage("GCS_SitePDSA_SiteName_Header", "Site Name"), true, typeof(string), 100, GetResourceMessage("GCS_SitePDSA_SiteName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_SitePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_SitePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_SitePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_SitePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_SitePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_SitePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_SitePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_SitePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_SitePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_SitePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.SiteId, GetResourceMessage("GCS_SitePDSA_SiteId_Header", "Site Id"), true, typeof(string), 30, GetResourceMessage("GCS_SitePDSA_SiteId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.BinaryResourceUid, GetResourceMessage("GCS_SitePDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_SitePDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.Longitude, GetResourceMessage("GCS_SitePDSA_Longitude_Header", "Longitude"), false, typeof(double), 53, GetResourceMessage("GCS_SitePDSA_Longitude_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDouble("-79228162514264337593543950335"), Convert.ToDouble("79228162514264337593543950335"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.Latitude, GetResourceMessage("GCS_SitePDSA_Latitude_Header", "Latitude"), false, typeof(double), 53, GetResourceMessage("GCS_SitePDSA_Latitude_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDouble("-79228162514264337593543950335"), Convert.ToDouble("79228162514264337593543950335"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.AddressUid, GetResourceMessage("GCS_SitePDSA_AddressUid_Header", "Address Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_SitePDSA_AddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SitePDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_SitePDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_SitePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.SiteUid = Guid.NewGuid();
      Entity.RegionUid = Guid.NewGuid();
      Entity.SiteName = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.SiteId = string.Empty;
      Entity.BinaryResourceUid = Guid.NewGuid();
      //Entity.Longitude = 0;
      //Entity.Latitude = 0;
      Entity.AddressUid = Guid.NewGuid();
      Entity.EntityId = Guid.NewGuid();

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
      
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.RegionUid).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.RegionUid).Value = Entity.RegionUid;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.SiteName).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.SiteName).Value = Entity.SiteName;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.SiteId).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.SiteId).Value = Entity.SiteId;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.BinaryResourceUid).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      //if(!Properties.GetByName(SitePDSAValidator.ColumnNames.Longitude).SetAsNull)
      //  Properties.GetByName(SitePDSAValidator.ColumnNames.Longitude).Value = Entity.Longitude;
      //if(!Properties.GetByName(SitePDSAValidator.ColumnNames.Latitude).SetAsNull)
      //  Properties.GetByName(SitePDSAValidator.ColumnNames.Latitude).Value = Entity.Latitude;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.AddressUid).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.AddressUid).Value = Entity.AddressUid;
      if(!Properties.GetByName(SitePDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(SitePDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(SitePDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(SitePDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.RegionUid).IsNull == false)
        Entity.RegionUid = Properties.GetByName(SitePDSAValidator.ColumnNames.RegionUid).GetAsGuid();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.SiteName).IsNull == false)
        Entity.SiteName = Properties.GetByName(SitePDSAValidator.ColumnNames.SiteName).GetAsString();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(SitePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(SitePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(SitePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(SitePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.SiteId).IsNull == false)
        Entity.SiteId = Properties.GetByName(SitePDSAValidator.ColumnNames.SiteId).GetAsString();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = Properties.GetByName(SitePDSAValidator.ColumnNames.BinaryResourceUid).GetAsGuid();
      //if(Properties.GetByName(SitePDSAValidator.ColumnNames.Longitude).IsNull == false)
      //  Entity.Longitude = Properties.GetByName(SitePDSAValidator.ColumnNames.Longitude).GetAsDouble();
      //if(Properties.GetByName(SitePDSAValidator.ColumnNames.Latitude).IsNull == false)
      //  Entity.Latitude = Properties.GetByName(SitePDSAValidator.ColumnNames.Latitude).GetAsDouble();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.AddressUid).IsNull == false)
        Entity.AddressUid = Properties.GetByName(SitePDSAValidator.ColumnNames.AddressUid).GetAsGuid();
      if(Properties.GetByName(SitePDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(SitePDSAValidator.ColumnNames.EntityId).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the SitePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'RegionUid'
    /// </summary>
    public static string RegionUid = "RegionUid";
    /// <summary>
    /// Returns 'SiteName'
    /// </summary>
    public static string SiteName = "SiteName";
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
    /// Returns 'SiteId'
    /// </summary>
    public static string SiteId = "SiteId";
    /// <summary>
    /// Returns 'BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "BinaryResourceUid";
    /// <summary>
    /// Returns 'Longitude'
    /// </summary>
    public static string Longitude = "Longitude";
    /// <summary>
    /// Returns 'Latitude'
    /// </summary>
    public static string Latitude = "Latitude";
    /// <summary>
    /// Returns 'AddressUid'
    /// </summary>
    public static string AddressUid = "AddressUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    }
    #endregion
  }
}
