using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the RoleInputOutputGroupPermissionPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class RoleInputOutputGroupPermissionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private RoleInputOutputGroupPermissionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new RoleInputOutputGroupPermissionPDSA Entity
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
    /// Clones the current RoleInputOutputGroupPermissionPDSA
    /// </summary>
    /// <returns>A cloned RoleInputOutputGroupPermissionPDSA object</returns>
    public RoleInputOutputGroupPermissionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in RoleInputOutputGroupPermissionPDSA
    /// </summary>
    /// <param name="entityToClone">The RoleInputOutputGroupPermissionPDSA entity to clone</param>
    /// <returns>A cloned RoleInputOutputGroupPermissionPDSA object</returns>
    public RoleInputOutputGroupPermissionPDSA CloneEntity(RoleInputOutputGroupPermissionPDSA entityToClone)
    {
      RoleInputOutputGroupPermissionPDSA newEntity = new RoleInputOutputGroupPermissionPDSA();

      newEntity.RoleInputOutputGroupPermissionUid = entityToClone.RoleInputOutputGroupPermissionUid;
      newEntity.RoleInputOutputGroupUid = entityToClone.RoleInputOutputGroupUid;
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
      
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_RoleInputOutputGroupPermissionUid_Header", "Role Input Output Group Permission Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_RoleInputOutputGroupPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_RoleInputOutputGroupUid_Header", "Role Input Output Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_RoleInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_PermissionId_Header", "Permission Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_PermissionId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_RoleInputOutputGroupPermissionPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.RoleInputOutputGroupPermissionUid = Guid.Empty;
      Entity.RoleInputOutputGroupUid = Guid.Empty;
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
      
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid).Value = Entity.RoleInputOutputGroupPermissionUid;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid).Value = Entity.RoleInputOutputGroupUid;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId).Value = Entity.PermissionId;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid).IsNull == false)
        Entity.RoleInputOutputGroupPermissionUid = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid).GetAsGuid();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid).IsNull == false)
        Entity.RoleInputOutputGroupUid = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId).IsNull == false)
        Entity.PermissionId = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId).GetAsGuid();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the RoleInputOutputGroupPermissionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'RoleInputOutputGroupPermissionUid'
    /// </summary>
    public static string RoleInputOutputGroupPermissionUid = "RoleInputOutputGroupPermissionUid";
    /// <summary>
    /// Returns 'RoleInputOutputGroupUid'
    /// </summary>
    public static string RoleInputOutputGroupUid = "RoleInputOutputGroupUid";
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
