using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AreaPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AreaPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AreaPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AreaPDSA Entity
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
    /// Clones the current AreaPDSA
    /// </summary>
    /// <returns>A cloned AreaPDSA object</returns>
    public AreaPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AreaPDSA
    /// </summary>
    /// <param name="entityToClone">The AreaPDSA entity to clone</param>
    /// <returns>A cloned AreaPDSA object</returns>
    public AreaPDSA CloneEntity(AreaPDSA entityToClone)
    {
      AreaPDSA newEntity = new AreaPDSA();

      newEntity.AreaUid = entityToClone.AreaUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.AreaNumber = entityToClone.AreaNumber;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.Display = entityToClone.Display;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.Description = entityToClone.Description;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.PageNumber = entityToClone.PageNumber;
      newEntity.CultureName = entityToClone.CultureName;
      newEntity.PageSize = entityToClone.PageSize;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;
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
      
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.AreaUid, GetResourceMessage("GCS_AreaPDSA_AreaUid_Header", "Area Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AreaPDSA_AreaUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_AreaPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AreaPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_AreaPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AreaPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.AreaNumber, GetResourceMessage("GCS_AreaPDSA_AreaNumber_Header", "Area Number"), true, typeof(int), 10, GetResourceMessage("GCS_AreaPDSA_AreaNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_AreaPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AreaPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AreaPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AreaPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_AreaPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_AreaPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AreaPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AreaPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AreaPDSA_Description_Header", "Description"), false, typeof(string), 1000, GetResourceMessage("GCS_AreaPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AreaPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AreaPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AreaPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AreaPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AreaPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AreaPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_AreaPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), -1, GetResourceMessage("GCS_AreaPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.PageNumber, GetResourceMessage("GCS_AreaPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_AreaPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_AreaPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AreaPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.PageSize, GetResourceMessage("GCS_AreaPDSA_PageSize_Header", "Page Size"), false, typeof(int), 2147483647, GetResourceMessage("GCS_AreaPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.TotalRowCount, GetResourceMessage("GCS_AreaPDSA_TotalRowCount_Header", "Total Row Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_AreaPDSA_TotalRowCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.SortColumn, GetResourceMessage("GCS_AreaPDSA_SortColumn_Header", "Sort Column"), false, typeof(string), 2147483647, GetResourceMessage("GCS_AreaPDSA_SortColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaPDSAValidator.ColumnNames.DescendingOrder, GetResourceMessage("GCS_AreaPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 2147483647, GetResourceMessage("GCS_AreaPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AreaUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.AreaNumber = 0;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.InsertName = string.Empty;
      Entity.Display = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.Description = string.Empty;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.EntityId = Guid.Empty;
      Entity.PageNumber = 0;
      Entity.CultureName = string.Empty;
      Entity.PageSize = 0;
      Entity.TotalRowCount = 0;
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
      
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaUid).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaUid).Value = Entity.AreaUid;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaNumber).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaNumber).Value = Entity.AreaNumber;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.PageNumber).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.PageNumber).Value = Entity.PageNumber;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.PageSize).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.PageSize).Value = Entity.PageSize;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.TotalRowCount).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.TotalRowCount).Value = Entity.TotalRowCount;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.SortColumn).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.SortColumn).Value = Entity.SortColumn;
      if(!Properties.GetByName(AreaPDSAValidator.ColumnNames.DescendingOrder).SetAsNull)
        Properties.GetByName(AreaPDSAValidator.ColumnNames.DescendingOrder).Value = Entity.DescendingOrder;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaUid).IsNull == false)
        Entity.AreaUid = Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaUid).GetAsGuid();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(AreaPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(AreaPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaNumber).IsNull == false)
        Entity.AreaNumber = Properties.GetByName(AreaPDSAValidator.ColumnNames.AreaNumber).GetAsInteger();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(AreaPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(AreaPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AreaPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AreaPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AreaPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AreaPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(AreaPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.PageNumber).IsNull == false)
        Entity.PageNumber = Properties.GetByName(AreaPDSAValidator.ColumnNames.PageNumber).GetAsInteger();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(AreaPDSAValidator.ColumnNames.CultureName).GetAsString();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.PageSize).IsNull == false)
        Entity.PageSize = Properties.GetByName(AreaPDSAValidator.ColumnNames.PageSize).GetAsInteger();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.TotalRowCount).IsNull == false)
        Entity.TotalRowCount = Properties.GetByName(AreaPDSAValidator.ColumnNames.TotalRowCount).GetAsInteger();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.SortColumn).IsNull == false)
        Entity.SortColumn = Properties.GetByName(AreaPDSAValidator.ColumnNames.SortColumn).GetAsString();
      if(Properties.GetByName(AreaPDSAValidator.ColumnNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = Properties.GetByName(AreaPDSAValidator.ColumnNames.DescendingOrder).GetAsBool();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AreaPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AreaUid'
    /// </summary>
    public static string AreaUid = "AreaUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'AreaNumber'
    /// </summary>
    public static string AreaNumber = "AreaNumber";
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
    /// Returns 'PageNumber'
    /// </summary>
    public static string PageNumber = "PageNumber";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    /// <summary>
    /// Returns 'PageSize'
    /// </summary>
    public static string PageSize = "PageSize";
    /// <summary>
    /// Returns 'TotalRowCount'
    /// </summary>
    public static string TotalRowCount = "TotalRowCount";
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
