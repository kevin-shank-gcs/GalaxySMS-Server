using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalCommandAuditPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalCommandAuditPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalCommandAuditPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalCommandAuditPDSA Entity
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
    /// Clones the current AccessPortalCommandAuditPDSA
    /// </summary>
    /// <returns>A cloned AccessPortalCommandAuditPDSA object</returns>
    public AccessPortalCommandAuditPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalCommandAuditPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalCommandAuditPDSA entity to clone</param>
    /// <returns>A cloned AccessPortalCommandAuditPDSA object</returns>
    public AccessPortalCommandAuditPDSA CloneEntity(AccessPortalCommandAuditPDSA entityToClone)
    {
      AccessPortalCommandAuditPDSA newEntity = new AccessPortalCommandAuditPDSA();

      newEntity.AccessPortalCommandAuditUid = entityToClone.AccessPortalCommandAuditUid;
      newEntity.UserId = entityToClone.UserId;
      newEntity.AccessPortalCommandUid = entityToClone.AccessPortalCommandUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
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
      
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandAuditUid, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_AccessPortalCommandAuditUid_Header", "Access Portal Command Audit Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_AccessPortalCommandAuditUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.UserId, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_UserId_Header", "User Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandUid, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_AccessPortalCommandUid_Header", "Access Portal Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_AccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_AccessPortalUid_Header", "Access Portal Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalCommandAuditPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalCommandAuditUid = Guid.Empty;
      Entity.UserId = Guid.Empty;
      Entity.AccessPortalCommandUid = Guid.Empty;
      Entity.AccessPortalUid = Guid.Empty;
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
      
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandAuditUid).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandAuditUid).Value = Entity.AccessPortalCommandAuditUid;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UserId).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UserId).Value = Entity.UserId;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandUid).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandUid).Value = Entity.AccessPortalCommandUid;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandAuditUid).IsNull == false)
        Entity.AccessPortalCommandAuditUid = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandAuditUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UserId).IsNull == false)
        Entity.UserId = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UserId).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalCommandUid = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalCommandUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalCommandAuditPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalCommandAuditUid'
    /// </summary>
    public static string AccessPortalCommandAuditUid = "AccessPortalCommandAuditUid";
    /// <summary>
    /// Returns 'UserId'
    /// </summary>
    public static string UserId = "UserId";
    /// <summary>
    /// Returns 'AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "AccessPortalCommandUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
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
