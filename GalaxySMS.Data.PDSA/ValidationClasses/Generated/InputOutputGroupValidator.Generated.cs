using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the InputOutputGroupPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroupPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputOutputGroupPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputOutputGroupPDSA Entity
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
    /// Clones the current InputOutputGroupPDSA
    /// </summary>
    /// <returns>A cloned InputOutputGroupPDSA object</returns>
    public InputOutputGroupPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputOutputGroupPDSA
    /// </summary>
    /// <param name="entityToClone">The InputOutputGroupPDSA entity to clone</param>
    /// <returns>A cloned InputOutputGroupPDSA object</returns>
    public InputOutputGroupPDSA CloneEntity(InputOutputGroupPDSA entityToClone)
    {
      InputOutputGroupPDSA newEntity = new InputOutputGroupPDSA();

      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.Display = entityToClone.Display;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.Description = entityToClone.Description;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.LocalIOGroup = entityToClone.LocalIOGroup;
      newEntity.CultureName = entityToClone.CultureName;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PageNumber = entityToClone.PageNumber;
      newEntity.PageSize = entityToClone.PageSize;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.SortColumn = entityToClone.SortColumn;
      newEntity.DescendingOrder = entityToClone.DescendingOrder;

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
      
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_InputOutputGroupPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_InputOutputGroupPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_InputOutputGroupPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.IOGroupNumber, GetResourceMessage("GCS_InputOutputGroupPDSA_IOGroupNumber_Header", "IO Group Number"), true, typeof(int), 10, GetResourceMessage("GCS_InputOutputGroupPDSA_IOGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_InputOutputGroupPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_InputOutputGroupPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputOutputGroupPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_InputOutputGroupPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_InputOutputGroupPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_InputOutputGroupPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_InputOutputGroupPDSA_Description_Header", "Description"), false, typeof(string), 1000, GetResourceMessage("GCS_InputOutputGroupPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_InputOutputGroupPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_InputOutputGroupPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_InputOutputGroupPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_InputOutputGroupPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_InputOutputGroupPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_InputOutputGroupPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.TimeScheduleUid, GetResourceMessage("GCS_InputOutputGroupPDSA_TimeScheduleUid_Header", "Time Schedule Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.LocalIOGroup, GetResourceMessage("GCS_InputOutputGroupPDSA_LocalIOGroup_Header", "Local IO Group"), true, typeof(bool), -1, GetResourceMessage("GCS_InputOutputGroupPDSA_LocalIOGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_InputOutputGroupPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_InputOutputGroupPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65565"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.PageNumber, GetResourceMessage("GCS_InputOutputGroupPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.PageSize, GetResourceMessage("GCS_InputOutputGroupPDSA_PageSize_Header", "Page Size"), false, typeof(int), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.TotalRowCount, GetResourceMessage("GCS_InputOutputGroupPDSA_TotalRowCount_Header", "Total Row Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_TotalRowCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_InputOutputGroupPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.SortColumn, GetResourceMessage("GCS_InputOutputGroupPDSA_SortColumn_Header", "Sort Column"), false, typeof(string), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_SortColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupPDSAValidator.ColumnNames.DescendingOrder, GetResourceMessage("GCS_InputOutputGroupPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 2147483647, GetResourceMessage("GCS_InputOutputGroupPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      
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
      Entity.ClusterUid = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.IOGroupNumber = 0;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.InsertName = string.Empty;
      Entity.Display = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.Description = string.Empty;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.EntityId = Guid.Empty;
      Entity.TimeScheduleUid = Guid.Empty;
      Entity.LocalIOGroup = false;
      Entity.CultureName = string.Empty;
      Entity.ClusterNumber = 0;
      Entity.PageNumber = 0;
      Entity.PageSize = 0;
      Entity.TotalRowCount = 0;
      Entity.ClusterGroupId = 0;
      Entity.SortColumn = string.Empty;
      Entity.DescendingOrder = false;

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
      
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.IOGroupNumber).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.IOGroupNumber).Value = Entity.IOGroupNumber;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TimeScheduleUid).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.LocalIOGroup).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.LocalIOGroup).Value = Entity.LocalIOGroup;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageNumber).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageNumber).Value = Entity.PageNumber;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageSize).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageSize).Value = Entity.PageSize;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TotalRowCount).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TotalRowCount).Value = Entity.TotalRowCount;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.SortColumn).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.SortColumn).Value = Entity.SortColumn;
      if(!Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescendingOrder).SetAsNull)
        Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescendingOrder).Value = Entity.DescendingOrder;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.IOGroupNumber).IsNull == false)
        Entity.IOGroupNumber = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.IOGroupNumber).GetAsInteger();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.LocalIOGroup).IsNull == false)
        Entity.LocalIOGroup = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.LocalIOGroup).GetAsBool();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.CultureName).GetAsString();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageNumber).IsNull == false)
        Entity.PageNumber = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageNumber).GetAsInteger();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageSize).IsNull == false)
        Entity.PageSize = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.PageSize).GetAsInteger();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TotalRowCount).IsNull == false)
        Entity.TotalRowCount = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.TotalRowCount).GetAsInteger();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.SortColumn).IsNull == false)
        Entity.SortColumn = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.SortColumn).GetAsString();
      if(Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = Properties.GetByName(InputOutputGroupPDSAValidator.ColumnNames.DescendingOrder).GetAsBool();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupPDSA class.
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
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'IOGroupNumber'
    /// </summary>
    public static string IOGroupNumber = "IOGroupNumber";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
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
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'LocalIOGroup'
    /// </summary>
    public static string LocalIOGroup = "LocalIOGroup";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'PageNumber'
    /// </summary>
    public static string PageNumber = "PageNumber";
    /// <summary>
    /// Returns 'PageSize'
    /// </summary>
    public static string PageSize = "PageSize";
    /// <summary>
    /// Returns 'TotalRowCount'
    /// </summary>
    public static string TotalRowCount = "TotalRowCount";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'SortColumn'
    /// </summary>
    public static string SortColumn = "SortColumn";
    /// <summary>
    /// Returns 'DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "DescendingOrder";
    }
    #endregion
  }
}
