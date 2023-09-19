using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyPanelAlarmSettings_PanelLoadDataPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelAlarmSettings_PanelLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelAlarmSettings_PanelLoadDataPDSA Entity
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
    /// Clones the current GalaxyPanelAlarmSettings_PanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelAlarmSettings_PanelLoadDataPDSA object</returns>
    public GalaxyPanelAlarmSettings_PanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelAlarmSettings_PanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelAlarmSettings_PanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelAlarmSettings_PanelLoadDataPDSA object</returns>
    public GalaxyPanelAlarmSettings_PanelLoadDataPDSA CloneEntity(GalaxyPanelAlarmSettings_PanelLoadDataPDSA entityToClone)
    {
      GalaxyPanelAlarmSettings_PanelLoadDataPDSA newEntity = new GalaxyPanelAlarmSettings_PanelLoadDataPDSA();

      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.Tag = entityToClone.Tag;
      newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
      newEntity.OffsetIndex = entityToClone.OffsetIndex;

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
      
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_AccountCode_Header", "Account Code"), false, typeof(string), 16, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_AccountCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_Tag_Header", "Tag"), false, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_IOGroupNumber_Header", "IO Group Number"), false, typeof(int), 10, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_IOGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_OffsetIndex_Header", "Offset Index"), false, typeof(short), 5, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataPDSA_OffsetIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PanelNumber = 0;
      Entity.GalaxyPanelUid = Guid.Empty;
      Entity.EntityName = string.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.ClusterGroupId = 0;
      Entity.ClusterNumber = 0;
      Entity.ClusterName = string.Empty;
      Entity.Tag = string.Empty;
      Entity.IOGroupNumber = 0;
      Entity.OffsetIndex = 0;

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
      
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).Value = Entity.IOGroupNumber;
      if(!Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex).SetAsNull)
        Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex).Value = Entity.OffsetIndex;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).IsNull == false)
        Entity.IOGroupNumber = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex).IsNull == false)
        Entity.OffsetIndex = Properties.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelAlarmSettings_PanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
    /// <summary>
    /// Returns 'IOGroupNumber'
    /// </summary>
    public static string IOGroupNumber = "IOGroupNumber";
    /// <summary>
    /// Returns 'OffsetIndex'
    /// </summary>
    public static string OffsetIndex = "OffsetIndex";
    }
    #endregion
  }
}
