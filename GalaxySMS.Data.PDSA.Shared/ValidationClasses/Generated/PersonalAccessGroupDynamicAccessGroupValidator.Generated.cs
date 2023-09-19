using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonalAccessGroupDynamicAccessGroupPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonalAccessGroupDynamicAccessGroupPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonalAccessGroupDynamicAccessGroupPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonalAccessGroupDynamicAccessGroupPDSA Entity
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
    /// Clones the current PersonalAccessGroupDynamicAccessGroupPDSA
    /// </summary>
    /// <returns>A cloned PersonalAccessGroupDynamicAccessGroupPDSA object</returns>
    public PersonalAccessGroupDynamicAccessGroupPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonalAccessGroupDynamicAccessGroupPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonalAccessGroupDynamicAccessGroupPDSA entity to clone</param>
    /// <returns>A cloned PersonalAccessGroupDynamicAccessGroupPDSA object</returns>
    public PersonalAccessGroupDynamicAccessGroupPDSA CloneEntity(PersonalAccessGroupDynamicAccessGroupPDSA entityToClone)
    {
      PersonalAccessGroupDynamicAccessGroupPDSA newEntity = new PersonalAccessGroupDynamicAccessGroupPDSA();

      newEntity.PersonalAccessGroupDynamicAccessGroupUid = entityToClone.PersonalAccessGroupDynamicAccessGroupUid;
      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.PersonClusterPermissionUid = entityToClone.PersonClusterPermissionUid;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.PersonCredentialUid = entityToClone.PersonCredentialUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;

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
      
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonalAccessGroupDynamicAccessGroupUid, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonalAccessGroupDynamicAccessGroupUid_Header", "Personal Access Group Dynamic Access Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonalAccessGroupDynamicAccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.AccessGroupUid, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_AccessGroupUid_Header", "Access Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonClusterPermissionUid, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonClusterPermissionUid_Header", "Person Cluster Permission Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonClusterPermissionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonUid, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonCredentialUid, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonCredentialUid_Header", "Person Credential Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_PersonCredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_PersonalAccessGroupDynamicAccessGroupPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonalAccessGroupDynamicAccessGroupUid = Guid.Empty;
      Entity.AccessGroupUid = Guid.Empty;
      Entity.PersonClusterPermissionUid = Guid.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.PersonUid = Guid.Empty;
      Entity.PersonCredentialUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;

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
      
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonalAccessGroupDynamicAccessGroupUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonalAccessGroupDynamicAccessGroupUid).Value = Entity.PersonalAccessGroupDynamicAccessGroupUid;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonClusterPermissionUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonClusterPermissionUid).Value = Entity.PersonClusterPermissionUid;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonCredentialUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonCredentialUid).Value = Entity.PersonCredentialUid;
      if(!Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonalAccessGroupDynamicAccessGroupUid).IsNull == false)
        Entity.PersonalAccessGroupDynamicAccessGroupUid = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonalAccessGroupDynamicAccessGroupUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonClusterPermissionUid).IsNull == false)
        Entity.PersonClusterPermissionUid = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonClusterPermissionUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonCredentialUid).IsNull == false)
        Entity.PersonCredentialUid = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.PersonCredentialUid).GetAsGuid();
      if(Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(PersonalAccessGroupDynamicAccessGroupPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonalAccessGroupDynamicAccessGroupPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonalAccessGroupDynamicAccessGroupUid'
    /// </summary>
    public static string PersonalAccessGroupDynamicAccessGroupUid = "PersonalAccessGroupDynamicAccessGroupUid";
    /// <summary>
    /// Returns 'AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "AccessGroupUid";
    /// <summary>
    /// Returns 'PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "PersonClusterPermissionUid";
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
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "PersonCredentialUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    }
    #endregion
  }
}
