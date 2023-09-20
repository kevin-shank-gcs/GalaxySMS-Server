using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the SiteEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class SiteEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private SiteEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new SiteEntityMapPDSA Entity
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
    /// Clones the current SiteEntityMapPDSA
    /// </summary>
    /// <returns>A cloned SiteEntityMapPDSA object</returns>
    public SiteEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in SiteEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The SiteEntityMapPDSA entity to clone</param>
    /// <returns>A cloned SiteEntityMapPDSA object</returns>
    public SiteEntityMapPDSA CloneEntity(SiteEntityMapPDSA entityToClone)
    {
      SiteEntityMapPDSA newEntity = new SiteEntityMapPDSA();

      newEntity.SiteEntityMapUid = entityToClone.SiteEntityMapUid;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.EntityId = entityToClone.EntityId;
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
      
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.SiteEntityMapUid, GetResourceMessage("GCS_SiteEntityMapPDSA_SiteEntityMapUid_Header", "Site Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_SiteEntityMapPDSA_SiteEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_SiteEntityMapPDSA_SiteUid_Header", "Site Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_SiteEntityMapPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_SiteEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_SiteEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_SiteEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_SiteEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_SiteEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_SiteEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_SiteEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_SiteEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_SiteEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_SiteEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(SiteEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_SiteEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_SiteEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.SiteEntityMapUid = Guid.NewGuid();
      Entity.SiteUid = Guid.NewGuid();
      Entity.EntityId = Guid.NewGuid();
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
      
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteEntityMapUid).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteEntityMapUid).Value = Entity.SiteEntityMapUid;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteEntityMapUid).IsNull == false)
        Entity.SiteEntityMapUid = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteEntityMapUid).GetAsGuid();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(SiteEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the SiteEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'SiteEntityMapUid'
    /// </summary>
    public static string SiteEntityMapUid = "SiteEntityMapUid";
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
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
