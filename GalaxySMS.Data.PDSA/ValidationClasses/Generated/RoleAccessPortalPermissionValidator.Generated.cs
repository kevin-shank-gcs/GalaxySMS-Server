using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the RoleAccessPortalPermissionPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class RoleAccessPortalPermissionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private RoleAccessPortalPermissionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new RoleAccessPortalPermissionPDSA Entity
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
    /// Clones the current RoleAccessPortalPermissionPDSA
    /// </summary>
    /// <returns>A cloned RoleAccessPortalPermissionPDSA object</returns>
    public RoleAccessPortalPermissionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in RoleAccessPortalPermissionPDSA
    /// </summary>
    /// <param name="entityToClone">The RoleAccessPortalPermissionPDSA entity to clone</param>
    /// <returns>A cloned RoleAccessPortalPermissionPDSA object</returns>
    public RoleAccessPortalPermissionPDSA CloneEntity(RoleAccessPortalPermissionPDSA entityToClone)
    {
      RoleAccessPortalPermissionPDSA newEntity = new RoleAccessPortalPermissionPDSA();

      newEntity.RoleAccessPortalPermissionUid = entityToClone.RoleAccessPortalPermissionUid;
      newEntity.RoleAccessPortalUid = entityToClone.RoleAccessPortalUid;
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
      
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalPermissionUid, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_RoleAccessPortalPermissionUid_Header", "Role Access Portal Permission Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_RoleAccessPortalPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalUid, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_RoleAccessPortalUid_Header", "Role Access Portal Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_RoleAccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.PermissionId, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_PermissionId_Header", "Permission Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleAccessPortalPermissionPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_RoleAccessPortalPermissionPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.RoleAccessPortalPermissionUid = Guid.Empty;
      Entity.RoleAccessPortalUid = Guid.Empty;
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
      
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalPermissionUid).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalPermissionUid).Value = Entity.RoleAccessPortalPermissionUid;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalUid).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalUid).Value = Entity.RoleAccessPortalUid;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.PermissionId).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.PermissionId).Value = Entity.PermissionId;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalPermissionUid).IsNull == false)
        Entity.RoleAccessPortalPermissionUid = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalPermissionUid).GetAsGuid();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalUid).IsNull == false)
        Entity.RoleAccessPortalUid = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.RoleAccessPortalUid).GetAsGuid();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.PermissionId).IsNull == false)
        Entity.PermissionId = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.PermissionId).GetAsGuid();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(RoleAccessPortalPermissionPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the RoleAccessPortalPermissionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'RoleAccessPortalPermissionUid'
    /// </summary>
    public static string RoleAccessPortalPermissionUid = "RoleAccessPortalPermissionUid";
    /// <summary>
    /// Returns 'RoleAccessPortalUid'
    /// </summary>
    public static string RoleAccessPortalUid = "RoleAccessPortalUid";
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
