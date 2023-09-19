using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputOutputGroup_PanelLoadDataPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroup_PanelLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputOutputGroup_PanelLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputOutputGroup_PanelLoadDataPDSA Entity
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
    /// Clones the current InputOutputGroup_PanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned InputOutputGroup_PanelLoadDataPDSA object</returns>
    public InputOutputGroup_PanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputOutputGroup_PanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The InputOutputGroup_PanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned InputOutputGroup_PanelLoadDataPDSA object</returns>
    public InputOutputGroup_PanelLoadDataPDSA CloneEntity(InputOutputGroup_PanelLoadDataPDSA entityToClone)
    {
      InputOutputGroup_PanelLoadDataPDSA newEntity = new InputOutputGroup_PanelLoadDataPDSA();

      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
      newEntity.InputOutputGroupName = entityToClone.InputOutputGroupName;
      newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
      newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
      newEntity.LocalIOGroup = entityToClone.LocalIOGroup;
      newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;

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
      
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_InputOutputGroupName_Header", "Input Output Group Name"), false, typeof(string), 65, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_InputOutputGroupName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_IOGroupNumber_Header", "IO Group Number"), false, typeof(int), 10, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_IOGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_PanelScheduleNumber_Header", "Panel Schedule Number"), false, typeof(int), 10, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_PanelScheduleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_LocalIOGroup_Header", "Local IO Group"), false, typeof(bool), -1, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_LocalIOGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_TimeScheduleName_Header", "Time Schedule Name"), false, typeof(string), 65, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_TimeScheduleName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_EntityName_Header", "Entity Name"), false, typeof(string), 65, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_EntityName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_AccountCode_Header", "Account Code"), false, typeof(string), 16, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_AccountCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 10, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 65, GetResourceMessage("GCS_InputOutputGroup_PanelLoadDataPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.InputOutputGroupUid = Guid.Empty;
      Entity.InputOutputGroupName = string.Empty;
      Entity.IOGroupNumber = 0;
      Entity.PanelScheduleNumber = 0;
      Entity.LocalIOGroup = false;
      Entity.TimeScheduleName = string.Empty;
      Entity.EntityName = string.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.ClusterGroupId = 0;
      Entity.ClusterNumber = 0;
      Entity.ClusterName = string.Empty;

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
      
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName).Value = Entity.InputOutputGroupName;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).Value = Entity.IOGroupNumber;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).Value = Entity.PanelScheduleNumber;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup).Value = Entity.LocalIOGroup;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName).Value = Entity.TimeScheduleName;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName).IsNull == false)
        Entity.InputOutputGroupName = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName).GetAsString();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).IsNull == false)
        Entity.IOGroupNumber = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber).GetAsInteger();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).IsNull == false)
        Entity.PanelScheduleNumber = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).GetAsInteger();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup).IsNull == false)
        Entity.LocalIOGroup = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup).GetAsBool();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName).IsNull == false)
        Entity.TimeScheduleName = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName).GetAsString();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName).GetAsString();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroup_PanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
    /// <summary>
    /// Returns 'InputOutputGroupName'
    /// </summary>
    public static string InputOutputGroupName = "InputOutputGroupName";
    /// <summary>
    /// Returns 'IOGroupNumber'
    /// </summary>
    public static string IOGroupNumber = "IOGroupNumber";
    /// <summary>
    /// Returns 'PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "PanelScheduleNumber";
    /// <summary>
    /// Returns 'LocalIOGroup'
    /// </summary>
    public static string LocalIOGroup = "LocalIOGroup";
    /// <summary>
    /// Returns 'TimeScheduleName'
    /// </summary>
    public static string TimeScheduleName = "TimeScheduleName";
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
    }
    #endregion
  }
}
