using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AssaDsrEntityMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AssaDsrEntityMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AssaDsrEntityMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AssaDsrEntityMapPDSA Entity
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
    /// Clones the current AssaDsrEntityMapPDSA
    /// </summary>
    /// <returns>A cloned AssaDsrEntityMapPDSA object</returns>
    public AssaDsrEntityMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AssaDsrEntityMapPDSA
    /// </summary>
    /// <param name="entityToClone">The AssaDsrEntityMapPDSA entity to clone</param>
    /// <returns>A cloned AssaDsrEntityMapPDSA object</returns>
    public AssaDsrEntityMapPDSA CloneEntity(AssaDsrEntityMapPDSA entityToClone)
    {
      AssaDsrEntityMapPDSA newEntity = new AssaDsrEntityMapPDSA();

      newEntity.AssaDsrEntityMapUid = entityToClone.AssaDsrEntityMapUid;
      newEntity.AssaDsrUid = entityToClone.AssaDsrUid;
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
      
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrEntityMapUid, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_AssaDsrEntityMapUid_Header", "Assa Dsr Entity Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_AssaDsrEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrUid, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_AssaDsrUid_Header", "Assa Dsr Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_AssaDsrUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaDsrEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AssaDsrEntityMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AssaDsrEntityMapUid = Guid.NewGuid();
      Entity.AssaDsrUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrEntityMapUid).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrEntityMapUid).Value = Entity.AssaDsrEntityMapUid;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrUid).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrEntityMapUid).IsNull == false)
        Entity.AssaDsrEntityMapUid = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrEntityMapUid).GetAsGuid();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrUid).IsNull == false)
        Entity.AssaDsrUid = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.AssaDsrUid).GetAsGuid();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AssaDsrEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AssaDsrEntityMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AssaDsrEntityMapUid'
    /// </summary>
    public static string AssaDsrEntityMapUid = "AssaDsrEntityMapUid";
    /// <summary>
    /// Returns 'AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "AssaDsrUid";
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
