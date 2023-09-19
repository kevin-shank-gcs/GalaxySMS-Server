using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the RoleRegionPermissionPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class RoleRegionPermissionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private RoleRegionPermissionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new RoleRegionPermissionPDSA Entity
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
    /// Clones the current RoleRegionPermissionPDSA
    /// </summary>
    /// <returns>A cloned RoleRegionPermissionPDSA object</returns>
    public RoleRegionPermissionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in RoleRegionPermissionPDSA
    /// </summary>
    /// <param name="entityToClone">The RoleRegionPermissionPDSA entity to clone</param>
    /// <returns>A cloned RoleRegionPermissionPDSA object</returns>
    public RoleRegionPermissionPDSA CloneEntity(RoleRegionPermissionPDSA entityToClone)
    {
      RoleRegionPermissionPDSA newEntity = new RoleRegionPermissionPDSA();

      newEntity.RoleRegionPermissionUid = entityToClone.RoleRegionPermissionUid;
      newEntity.RoleRegionUid = entityToClone.RoleRegionUid;
      newEntity.PermissionId = entityToClone.PermissionId;
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
      
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionPermissionUid, GetResourceMessage("GCS_RoleRegionPermissionPDSA_RoleRegionPermissionUid_Header", "Role Region Permission Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleRegionPermissionPDSA_RoleRegionPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionUid, GetResourceMessage("GCS_RoleRegionPermissionPDSA_RoleRegionUid_Header", "Role Region Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleRegionPermissionPDSA_RoleRegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.PermissionId, GetResourceMessage("GCS_RoleRegionPermissionPDSA_PermissionId_Header", "Permission Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleRegionPermissionPDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_RoleRegionPermissionPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_RoleRegionPermissionPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_RoleRegionPermissionPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleRegionPermissionPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_RoleRegionPermissionPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_RoleRegionPermissionPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_RoleRegionPermissionPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleRegionPermissionPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleRegionPermissionPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_RoleRegionPermissionPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_RoleRegionPermissionPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.RoleRegionPermissionUid = Guid.Empty;
      Entity.RoleRegionUid = Guid.Empty;
      Entity.PermissionId = Guid.Empty;
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
      
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionPermissionUid).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionPermissionUid).Value = Entity.RoleRegionPermissionUid;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionUid).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionUid).Value = Entity.RoleRegionUid;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.PermissionId).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.PermissionId).Value = Entity.PermissionId;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionPermissionUid).IsNull == false)
        Entity.RoleRegionPermissionUid = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionPermissionUid).GetAsGuid();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionUid).IsNull == false)
        Entity.RoleRegionUid = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.RoleRegionUid).GetAsGuid();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.PermissionId).IsNull == false)
        Entity.PermissionId = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.PermissionId).GetAsGuid();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(RoleRegionPermissionPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the RoleRegionPermissionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'RoleRegionPermissionUid'
    /// </summary>
    public static string RoleRegionPermissionUid = "RoleRegionPermissionUid";
    /// <summary>
    /// Returns 'RoleRegionUid'
    /// </summary>
    public static string RoleRegionUid = "RoleRegionUid";
    /// <summary>
    /// Returns 'PermissionId'
    /// </summary>
    public static string PermissionId = "PermissionId";
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
