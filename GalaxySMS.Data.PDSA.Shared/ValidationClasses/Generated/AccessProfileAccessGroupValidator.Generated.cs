using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessProfileAccessGroupPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessProfileAccessGroupPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessProfileAccessGroupPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessProfileAccessGroupPDSA Entity
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
    /// Clones the current AccessProfileAccessGroupPDSA
    /// </summary>
    /// <returns>A cloned AccessProfileAccessGroupPDSA object</returns>
    public AccessProfileAccessGroupPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessProfileAccessGroupPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessProfileAccessGroupPDSA entity to clone</param>
    /// <returns>A cloned AccessProfileAccessGroupPDSA object</returns>
    public AccessProfileAccessGroupPDSA CloneEntity(AccessProfileAccessGroupPDSA entityToClone)
    {
      AccessProfileAccessGroupPDSA newEntity = new AccessProfileAccessGroupPDSA();

      newEntity.AccessProfileAccessGroupUid = entityToClone.AccessProfileAccessGroupUid;
      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.AccessProfileClusterUid = entityToClone.AccessProfileClusterUid;
      newEntity.OrderNumber = entityToClone.OrderNumber;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.AccessProfileUid = entityToClone.AccessProfileUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;
      newEntity.AccessGroupName = entityToClone.AccessGroupName;

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
      
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileAccessGroupUid, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessProfileAccessGroupUid_Header", "Access Profile Access Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessProfileAccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupUid, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessGroupUid_Header", "Access Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileClusterUid, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessProfileClusterUid_Header", "Access Profile Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessProfileClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.OrderNumber, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_OrderNumber_Header", "Order Number"), true, typeof(short), 5, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_OrderNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileUid, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessProfileUid_Header", "Access Profile Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessProfileUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupNumber, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessGroupNumber_Header", "Access Group Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2001"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupName, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessGroupName_Header", "Access Group Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AccessProfileAccessGroupPDSA_AccessGroupName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessProfileAccessGroupUid = Guid.Empty;
      Entity.AccessGroupUid = Guid.Empty;
      Entity.AccessProfileClusterUid = Guid.Empty;
      Entity.OrderNumber = 0;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.AccessProfileUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.AccessGroupNumber = 0;
      Entity.AccessGroupName = string.Empty;

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
      
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileAccessGroupUid).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileAccessGroupUid).Value = Entity.AccessProfileAccessGroupUid;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileClusterUid).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileClusterUid).Value = Entity.AccessProfileClusterUid;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.OrderNumber).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.OrderNumber).Value = Entity.OrderNumber;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileUid).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileUid).Value = Entity.AccessProfileUid;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupNumber).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupNumber).Value = Entity.AccessGroupNumber;
      if(!Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupName).SetAsNull)
        Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupName).Value = Entity.AccessGroupName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileAccessGroupUid).IsNull == false)
        Entity.AccessProfileAccessGroupUid = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileAccessGroupUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileClusterUid).IsNull == false)
        Entity.AccessProfileClusterUid = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileClusterUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.OrderNumber).IsNull == false)
        Entity.OrderNumber = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.OrderNumber).GetAsShort();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileUid).IsNull == false)
        Entity.AccessProfileUid = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessProfileUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupNumber).IsNull == false)
        Entity.AccessGroupNumber = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupNumber).GetAsInteger();
      if(Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupName).IsNull == false)
        Entity.AccessGroupName = Properties.GetByName(AccessProfileAccessGroupPDSAValidator.ColumnNames.AccessGroupName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessProfileAccessGroupPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessProfileAccessGroupUid'
    /// </summary>
    public static string AccessProfileAccessGroupUid = "AccessProfileAccessGroupUid";
    /// <summary>
    /// Returns 'AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "AccessGroupUid";
    /// <summary>
    /// Returns 'AccessProfileClusterUid'
    /// </summary>
    public static string AccessProfileClusterUid = "AccessProfileClusterUid";
    /// <summary>
    /// Returns 'OrderNumber'
    /// </summary>
    public static string OrderNumber = "OrderNumber";
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
    /// Returns 'AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "AccessProfileUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'AccessGroupNumber'
    /// </summary>
    public static string AccessGroupNumber = "AccessGroupNumber";
    /// <summary>
    /// Returns 'AccessGroupName'
    /// </summary>
    public static string AccessGroupName = "AccessGroupName";
    }
    #endregion
  }
}
