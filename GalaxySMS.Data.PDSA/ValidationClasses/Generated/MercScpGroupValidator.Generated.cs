using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the MercScpGroupPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class MercScpGroupPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private MercScpGroupPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new MercScpGroupPDSA Entity
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
    /// Clones the current MercScpGroupPDSA
    /// </summary>
    /// <returns>A cloned MercScpGroupPDSA object</returns>
    public MercScpGroupPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in MercScpGroupPDSA
    /// </summary>
    /// <param name="entityToClone">The MercScpGroupPDSA entity to clone</param>
    /// <returns>A cloned MercScpGroupPDSA object</returns>
    public MercScpGroupPDSA CloneEntity(MercScpGroupPDSA entityToClone)
    {
      MercScpGroupPDSA newEntity = new MercScpGroupPDSA();

      newEntity.MercScpGroupUid = entityToClone.MercScpGroupUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.Name = entityToClone.Name;
      newEntity.NumberOfTransactions = entityToClone.NumberOfTransactions;
      newEntity.NumberOfOperatingModes = entityToClone.NumberOfOperatingModes;
      newEntity.OperatingModeType = entityToClone.OperatingModeType;
      newEntity.AllowConnection = entityToClone.AllowConnection;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.Description = entityToClone.Description;
      newEntity.PageNumber = entityToClone.PageNumber;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.PageSize = entityToClone.PageSize;
      newEntity.SortColumn = entityToClone.SortColumn;
      newEntity.DescendingOrder = entityToClone.DescendingOrder;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;

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
      
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.MercScpGroupUid, GetResourceMessage("GCS_MercScpGroupPDSA_MercScpGroupUid_Header", "Merc Scp Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_MercScpGroupPDSA_MercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_MercScpGroupPDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_MercScpGroupPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_MercScpGroupPDSA_SiteUid_Header", "Site Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_MercScpGroupPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.Name, GetResourceMessage("GCS_MercScpGroupPDSA_Name_Header", "Name"), true, typeof(string), 65, GetResourceMessage("GCS_MercScpGroupPDSA_Name_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.NumberOfTransactions, GetResourceMessage("GCS_MercScpGroupPDSA_NumberOfTransactions_Header", "Number Of Transactions"), true, typeof(int), 10, GetResourceMessage("GCS_MercScpGroupPDSA_NumberOfTransactions_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.NumberOfOperatingModes, GetResourceMessage("GCS_MercScpGroupPDSA_NumberOfOperatingModes_Header", "Number Of Operating Modes"), true, typeof(short), 5, GetResourceMessage("GCS_MercScpGroupPDSA_NumberOfOperatingModes_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.OperatingModeType, GetResourceMessage("GCS_MercScpGroupPDSA_OperatingModeType_Header", "Operating Mode Type"), true, typeof(short), 5, GetResourceMessage("GCS_MercScpGroupPDSA_OperatingModeType_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.AllowConnection, GetResourceMessage("GCS_MercScpGroupPDSA_AllowConnection_Header", "Allow Connection"), true, typeof(bool), -1, GetResourceMessage("GCS_MercScpGroupPDSA_AllowConnection_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_MercScpGroupPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_MercScpGroupPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_MercScpGroupPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_MercScpGroupPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_MercScpGroupPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_MercScpGroupPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_MercScpGroupPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_MercScpGroupPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_MercScpGroupPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_MercScpGroupPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_MercScpGroupPDSA_Description_Header", "Description"), false, typeof(string), 1000, GetResourceMessage("GCS_MercScpGroupPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.PageNumber, GetResourceMessage("GCS_MercScpGroupPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_MercScpGroupPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.IsActive, GetResourceMessage("GCS_MercScpGroupPDSA_IsActive_Header", "Is Active"), true, typeof(bool), -1, GetResourceMessage("GCS_MercScpGroupPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.PageSize, GetResourceMessage("GCS_MercScpGroupPDSA_PageSize_Header", "Page Size"), false, typeof(int), 2147483647, GetResourceMessage("GCS_MercScpGroupPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.SortColumn, GetResourceMessage("GCS_MercScpGroupPDSA_SortColumn_Header", "Sort Column"), false, typeof(string), 2147483647, GetResourceMessage("GCS_MercScpGroupPDSA_SortColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.DescendingOrder, GetResourceMessage("GCS_MercScpGroupPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 2147483647, GetResourceMessage("GCS_MercScpGroupPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroupPDSAValidator.ColumnNames.TotalRowCount, GetResourceMessage("GCS_MercScpGroupPDSA_TotalRowCount_Header", "Total Row Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_MercScpGroupPDSA_TotalRowCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.MercScpGroupUid = Guid.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.SiteUid = Guid.Empty;
      Entity.Name = string.Empty;
      Entity.NumberOfTransactions = 0;
      Entity.NumberOfOperatingModes = 0;
      Entity.OperatingModeType = 0;
      Entity.AllowConnection = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.Description = string.Empty;
      Entity.PageNumber = 0;
      Entity.IsActive = false;
      Entity.PageSize = 0;
      Entity.SortColumn = string.Empty;
      Entity.DescendingOrder = false;
      Entity.TotalRowCount = 0;

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
      
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.MercScpGroupUid).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Name).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Name).Value = Entity.Name;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfTransactions).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfTransactions).Value = Entity.NumberOfTransactions;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfOperatingModes).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfOperatingModes).Value = Entity.NumberOfOperatingModes;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.OperatingModeType).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.OperatingModeType).Value = Entity.OperatingModeType;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.AllowConnection).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.AllowConnection).Value = Entity.AllowConnection;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageNumber).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageNumber).Value = Entity.PageNumber;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.IsActive).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.IsActive).Value = Entity.IsActive;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageSize).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageSize).Value = Entity.PageSize;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SortColumn).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SortColumn).Value = Entity.SortColumn;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.DescendingOrder).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.DescendingOrder).Value = Entity.DescendingOrder;
      if(!Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.TotalRowCount).SetAsNull)
        Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.TotalRowCount).Value = Entity.TotalRowCount;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.MercScpGroupUid).IsNull == false)
        Entity.MercScpGroupUid = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.MercScpGroupUid).GetAsGuid();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Name).IsNull == false)
        Entity.Name = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Name).GetAsString();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfTransactions).IsNull == false)
        Entity.NumberOfTransactions = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfTransactions).GetAsInteger();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfOperatingModes).IsNull == false)
        Entity.NumberOfOperatingModes = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.NumberOfOperatingModes).GetAsShort();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.OperatingModeType).IsNull == false)
        Entity.OperatingModeType = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.OperatingModeType).GetAsShort();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.AllowConnection).IsNull == false)
        Entity.AllowConnection = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.AllowConnection).GetAsBool();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageNumber).IsNull == false)
        Entity.PageNumber = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageNumber).GetAsInteger();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.IsActive).IsNull == false)
        Entity.IsActive = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.IsActive).GetAsBool();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageSize).IsNull == false)
        Entity.PageSize = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.PageSize).GetAsInteger();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SortColumn).IsNull == false)
        Entity.SortColumn = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.SortColumn).GetAsString();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.DescendingOrder).GetAsBool();
      if(Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.TotalRowCount).IsNull == false)
        Entity.TotalRowCount = Properties.GetByName(MercScpGroupPDSAValidator.ColumnNames.TotalRowCount).GetAsInteger();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the MercScpGroupPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "MercScpGroupUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'Name'
    /// </summary>
    public static string Name = "Name";
    /// <summary>
    /// Returns 'NumberOfTransactions'
    /// </summary>
    public static string NumberOfTransactions = "NumberOfTransactions";
    /// <summary>
    /// Returns 'NumberOfOperatingModes'
    /// </summary>
    public static string NumberOfOperatingModes = "NumberOfOperatingModes";
    /// <summary>
    /// Returns 'OperatingModeType'
    /// </summary>
    public static string OperatingModeType = "OperatingModeType";
    /// <summary>
    /// Returns 'AllowConnection'
    /// </summary>
    public static string AllowConnection = "AllowConnection";
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
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'PageNumber'
    /// </summary>
    public static string PageNumber = "PageNumber";
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns 'PageSize'
    /// </summary>
    public static string PageSize = "PageSize";
    /// <summary>
    /// Returns 'SortColumn'
    /// </summary>
    public static string SortColumn = "SortColumn";
    /// <summary>
    /// Returns 'DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "DescendingOrder";
    /// <summary>
    /// Returns 'TotalRowCount'
    /// </summary>
    public static string TotalRowCount = "TotalRowCount";
    }
    #endregion
  }
}
