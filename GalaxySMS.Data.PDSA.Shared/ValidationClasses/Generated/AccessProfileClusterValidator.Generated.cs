using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessProfileClusterPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessProfileClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessProfileClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessProfileClusterPDSA Entity
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
    /// Clones the current AccessProfileClusterPDSA
    /// </summary>
    /// <returns>A cloned AccessProfileClusterPDSA object</returns>
    public AccessProfileClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessProfileClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessProfileClusterPDSA entity to clone</param>
    /// <returns>A cloned AccessProfileClusterPDSA object</returns>
    public AccessProfileClusterPDSA CloneEntity(AccessProfileClusterPDSA entityToClone)
    {
      AccessProfileClusterPDSA newEntity = new AccessProfileClusterPDSA();

      newEntity.AccessProfileClusterUid = entityToClone.AccessProfileClusterUid;
      newEntity.AccessProfileUid = entityToClone.AccessProfileUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
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
      
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileClusterUid, GetResourceMessage("GCS_AccessProfileClusterPDSA_AccessProfileClusterUid_Header", "Access Profile Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileClusterPDSA_AccessProfileClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileUid, GetResourceMessage("GCS_AccessProfileClusterPDSA_AccessProfileUid_Header", "Access Profile Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileClusterPDSA_AccessProfileUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_AccessProfileClusterPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileClusterPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessProfileClusterPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessProfileClusterPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessProfileClusterPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessProfileClusterPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessProfileClusterPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessProfileClusterPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessProfileClusterPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessProfileClusterPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileClusterPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessProfileClusterPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessProfileClusterPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessProfileClusterUid = Guid.Empty;
      Entity.AccessProfileUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
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
      
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileClusterUid).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileClusterUid).Value = Entity.AccessProfileClusterUid;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileUid).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileUid).Value = Entity.AccessProfileUid;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileClusterUid).IsNull == false)
        Entity.AccessProfileClusterUid = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileClusterUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileUid).IsNull == false)
        Entity.AccessProfileUid = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.AccessProfileUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessProfileClusterPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessProfileClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessProfileClusterUid'
    /// </summary>
    public static string AccessProfileClusterUid = "AccessProfileClusterUid";
    /// <summary>
    /// Returns 'AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "AccessProfileUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
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
