using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessProfileEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessProfileEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessProfileEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessProfileEntityMapPDSA Entity
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
    /// Clones the current AccessProfileEntityMapPDSA
    /// </summary>
    /// <returns>A cloned AccessProfileEntityMapPDSA object</returns>
    public AccessProfileEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessProfileEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessProfileEntityMapPDSA entity to clone</param>
    /// <returns>A cloned AccessProfileEntityMapPDSA object</returns>
    public AccessProfileEntityMapPDSA CloneEntity(AccessProfileEntityMapPDSA entityToClone)
    {
      AccessProfileEntityMapPDSA newEntity = new AccessProfileEntityMapPDSA();

      newEntity.AccessProfileEntityMapUid = entityToClone.AccessProfileEntityMapUid;
      newEntity.AccessProfileUid = entityToClone.AccessProfileUid;
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
      
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileEntityMapUid, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_AccessProfileEntityMapUid_Header", "Access Profile Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_AccessProfileEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileUid, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_AccessProfileUid_Header", "Access Profile Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_AccessProfileUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessProfileEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessProfileEntityMapUid = Guid.Empty;
      Entity.AccessProfileUid = Guid.Empty;
      Entity.EntityId = Guid.Empty;
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
      
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileEntityMapUid).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileEntityMapUid).Value = Entity.AccessProfileEntityMapUid;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileUid).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileUid).Value = Entity.AccessProfileUid;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileEntityMapUid).IsNull == false)
        Entity.AccessProfileEntityMapUid = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileEntityMapUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileUid).IsNull == false)
        Entity.AccessProfileUid = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.AccessProfileUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessProfileEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessProfileEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessProfileEntityMapUid'
    /// </summary>
    public static string AccessProfileEntityMapUid = "AccessProfileEntityMapUid";
    /// <summary>
    /// Returns 'AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "AccessProfileUid";
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
