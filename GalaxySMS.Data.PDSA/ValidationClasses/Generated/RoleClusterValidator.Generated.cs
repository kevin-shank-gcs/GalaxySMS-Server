using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the RoleClusterPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class RoleClusterPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private RoleClusterPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new RoleClusterPDSA Entity
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
    /// Clones the current RoleClusterPDSA
    /// </summary>
    /// <returns>A cloned RoleClusterPDSA object</returns>
    public RoleClusterPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in RoleClusterPDSA
    /// </summary>
    /// <param name="entityToClone">The RoleClusterPDSA entity to clone</param>
    /// <returns>A cloned RoleClusterPDSA object</returns>
    public RoleClusterPDSA CloneEntity(RoleClusterPDSA entityToClone)
    {
      RoleClusterPDSA newEntity = new RoleClusterPDSA();

      newEntity.RoleClusterUid = entityToClone.RoleClusterUid;
      newEntity.RoleId = entityToClone.RoleId;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.IncludeAllAccessPortals = entityToClone.IncludeAllAccessPortals;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.IncludeAllInputOutputGroups = entityToClone.IncludeAllInputOutputGroups;
      newEntity.IncludeAllInputDevices = entityToClone.IncludeAllInputDevices;
      newEntity.IncludeAllOutputDevices = entityToClone.IncludeAllOutputDevices;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.SiteUid = entityToClone.SiteUid;

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
      
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.RoleClusterUid, GetResourceMessage("GCS_RoleClusterPDSA_RoleClusterUid_Header", "Role Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleClusterPDSA_RoleClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.RoleId, GetResourceMessage("GCS_RoleClusterPDSA_RoleId_Header", "Role Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleClusterPDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_RoleClusterPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_RoleClusterPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_RoleClusterPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_RoleClusterPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_RoleClusterPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleClusterPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_RoleClusterPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_RoleClusterPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_RoleClusterPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_RoleClusterPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_RoleClusterPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_RoleClusterPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.IncludeAllAccessPortals, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllAccessPortals_Header", "Include All Access Portals"), true, typeof(bool), -1, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllAccessPortals_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_RoleClusterPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_RoleClusterPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputOutputGroups, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllInputOutputGroups_Header", "Include All Input Output Groups"), true, typeof(bool), -1, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllInputOutputGroups_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputDevices, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllInputDevices_Header", "Include All Input Devices"), true, typeof(bool), -1, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllInputDevices_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.IncludeAllOutputDevices, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllOutputDevices_Header", "Include All Output Devices"), true, typeof(bool), -1, GetResourceMessage("GCS_RoleClusterPDSA_IncludeAllOutputDevices_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_RoleClusterPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 2147483647, GetResourceMessage("GCS_RoleClusterPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_RoleClusterPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_RoleClusterPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(RoleClusterPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_RoleClusterPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_RoleClusterPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.RoleClusterUid = Guid.Empty;
      Entity.RoleId = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.IncludeAllAccessPortals = false;
      Entity.ClusterName = string.Empty;
      Entity.IncludeAllInputOutputGroups = false;
      Entity.IncludeAllInputDevices = false;
      Entity.IncludeAllOutputDevices = false;
      Entity.ClusterGroupId = 0;
      Entity.ClusterNumber = 0;
      Entity.SiteUid = Guid.Empty;

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
      
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleClusterUid).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleClusterUid).Value = Entity.RoleClusterUid;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleId).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleId).Value = Entity.RoleId;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllAccessPortals).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllAccessPortals).Value = Entity.IncludeAllAccessPortals;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputOutputGroups).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputOutputGroups).Value = Entity.IncludeAllInputOutputGroups;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputDevices).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputDevices).Value = Entity.IncludeAllInputDevices;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllOutputDevices).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllOutputDevices).Value = Entity.IncludeAllOutputDevices;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleClusterUid).IsNull == false)
        Entity.RoleClusterUid = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleClusterUid).GetAsGuid();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleId).IsNull == false)
        Entity.RoleId = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.RoleId).GetAsGuid();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllAccessPortals).IsNull == false)
        Entity.IncludeAllAccessPortals = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllAccessPortals).GetAsBool();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterName).GetAsString();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputOutputGroups).IsNull == false)
        Entity.IncludeAllInputOutputGroups = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputOutputGroups).GetAsBool();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputDevices).IsNull == false)
        Entity.IncludeAllInputDevices = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllInputDevices).GetAsBool();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllOutputDevices).IsNull == false)
        Entity.IncludeAllOutputDevices = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.IncludeAllOutputDevices).GetAsBool();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(RoleClusterPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the RoleClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'RoleClusterUid'
    /// </summary>
    public static string RoleClusterUid = "RoleClusterUid";
    /// <summary>
    /// Returns 'RoleId'
    /// </summary>
    public static string RoleId = "RoleId";
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
    /// <summary>
    /// Returns 'IncludeAllAccessPortals'
    /// </summary>
    public static string IncludeAllAccessPortals = "IncludeAllAccessPortals";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'IncludeAllInputOutputGroups'
    /// </summary>
    public static string IncludeAllInputOutputGroups = "IncludeAllInputOutputGroups";
    /// <summary>
    /// Returns 'IncludeAllInputDevices'
    /// </summary>
    public static string IncludeAllInputDevices = "IncludeAllInputDevices";
    /// <summary>
    /// Returns 'IncludeAllOutputDevices'
    /// </summary>
    public static string IncludeAllOutputDevices = "IncludeAllOutputDevices";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    }
    #endregion
  }
}
