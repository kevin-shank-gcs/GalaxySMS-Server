using System;
using System.Data;
using System.Text;

using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;

namespace GalaxySMS.DataLayer
{
  /// <summary>
  /// Used to Add/Edit/Delete/Select data from the gcsSettingPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsSettingPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsSettingPDSAData class
    /// </summary>
    public gcsSettingPDSAData() : base()
    {
      Entity = new gcsSettingPDSA();
      ValidatorObject = new gcsSettingPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsSettingPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsSettingPDSA</param>
    public gcsSettingPDSAData(gcsSettingPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new gcsSettingPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsSettingPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsSettingPDSA</param>
    public gcsSettingPDSAData(PDSADataProvider dataProvider,
      gcsSettingPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new gcsSettingPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsSettingPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsSettingPDSA</param>
    /// <param name="validator">An instance of a gcsSettingPDSAValidator</param>
    public gcsSettingPDSAData(PDSADataProvider dataProvider,
      gcsSettingPDSA entity, gcsSettingPDSAValidator validator)
      : base(dataProvider, entity, validator)
    {
      Entity = entity;
      ValidatorObject = validator;

      Init();
    }
    #endregion

    #region Filter Properties and Enumerations
    /// <summary>
    /// Enumeration for selecting a SELECT statement when calling the Load, GetDataSet or GetDataReader method.
    /// </summary>
    public enum SelectFilters
    {
      
      /// <summary>
      /// 'All' SelectFilter
      /// </summary>
      All
      ,
      /// <summary>
      /// 'AllByEntityId' SelectFilter
      /// </summary>
      AllByEntityId
      ,
      /// <summary>
      /// 'ByEntityGroupSubGroupKey' SelectFilter
      /// </summary>
      ByEntityGroupSubGroupKey
      ,
      /// <summary>
      /// 'ListBox' SelectFilter
      /// </summary>
      ListBox
      ,
      /// <summary>
      /// 'PrimaryKey' SelectFilter
      /// </summary>
      PrimaryKey
      ,
      /// <summary>
      /// 'Search' SelectFilter
      /// </summary>
      Search
      ,
      /// <summary>
      /// 'ByEntityId' SelectFilter
      /// </summary>
      ByEntityId
      ,
      /// <summary>
      /// 'ByEntityAndGroup' SelectFilter
      /// </summary>
      ByEntityAndGroup
      ,
      /// <summary>
      /// 'ByEntityGroupAndSubGroup' SelectFilter
      /// </summary>
      ByEntityGroupAndSubGroup
      ,
      /// <summary>
      /// A Custom Select Filter
      /// </summary>
      Custom
    }


    /// <summary>
    /// Enumeration for selecting an INSERT statement or INSERT stored procedure to execute when calling the Insert() method.
    /// </summary>
    public enum InsertFilters
    {
      
      /// <summary>
      /// 'All' InsertFilter
      /// </summary>
      All
      ,
      /// <summary>
      /// A Custom InsertFilter
      /// </summary>
      Custom
    }

    /// <summary>
    /// Enumeration for selecting an UPDATE statement or UPDATE stored procedure to execute when calling the Update() method.
    /// </summary>
    public enum UpdateFilters
    {
      
      /// <summary>
      /// 'PrimaryKey' UpdateFilter
      /// </summary>
      PrimaryKey
      ,
      /// <summary>
      /// 'UpdateConcurrency' UpdateFilter
      /// </summary>
      UpdateConcurrency
      ,
      /// <summary>
      /// A Custom UpdateFilter
      /// </summary>
      Custom
    }

    /// <summary>
    /// Enumeration for selecting a DELETE statement or DELETE stored procedure to execute when calling the Delete() method.
    /// </summary>
    public enum DeleteFilters
    {
      
      /// <summary>
      /// 'DeleteByPK' DeleteFilter
      /// </summary>
      DeleteByPK
      ,
      /// <summary>
      /// A Custom DeleteFilter
      /// </summary>
      Custom
    }

    /// <summary>
    /// Enumeration for selecting a Row Count statement or Row Count stored procedure to execute when calling the RowCount() method.
    /// </summary>
    public enum RowCountFilters
    {
      
      /// <summary>
      /// 'All' RowCountFilter
      /// </summary>
      All
      ,
      /// <summary>
      /// A Custom RowCountFilter
      /// </summary>
      Custom
    }

    /// <summary>
    /// Get/Set a Dynamic SQL or Stored Procedure to execute to return data.
    /// </summary>
    public SelectFilters SelectFilter { get; set; }

    
    /// <summary>
    /// Get/Set an INSERT statement or INSERT stored procedure to execute when calling the Insert() method.
    /// </summary>
    public InsertFilters InsertFilter { get; set; }

    private UpdateFilters mUpdateFilter;
    /// <summary>
    /// Get/Set an UPDATE statement or UPDATE stored procedure to execute when calling the Update() method.
    /// </summary>
    public UpdateFilters UpdateFilter
    {
      get { return mUpdateFilter; }
      set
      {
        mUpdateFilter = value;
        if (mUpdateFilter == UpdateFilters.Custom)
          PerformValidation = false;
      }
    }
    /// <summary>
    /// Get/Set a DELETE statement or DELETE stored procedure to execute when calling the Delete() method. You might need to set a WhereFilter as well.
    /// </summary>
    public DeleteFilters DeleteFilter { get; set; }
    /// <summary>
    /// Get/Set a Row Count statement or RowCount stored procedure to execute when calling the RowCount() method. You might need to set a WhereFilter as well.
    /// </summary>
    public RowCountFilters RowCountFilter { get; set; }
    #endregion

    #region Entity Property
    private gcsSettingPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public gcsSettingPDSA Entity 
    { 
      get { return _EntityObject; }
      set
      {
        _EntityObject = value;
        base.EntityObject = _EntityObject;
      } 
    }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcsSettingPDSAData";
      DBObjectName = "GCS.gcsSetting";
      SchemaName = "GCS";
      PrimaryKeyType = PDSAPrimaryKeyType.GUID;
      PrimaryKeyGenerate = false;
      UseAuditTracking = DataProvider.UseDBAuditTracking;
      UseStoredProcs = DataProvider.UseStoredProcedures;
      base.EntityObject = Entity;
      base.ValidatorObject = ValidatorObject;

      // Set Reference to ValidatorObject Properties Collection
      AllColumns = ValidatorObject.Properties;

      // Set any Initial Starting values for data columns
      InitDataColumns();
    }
    #endregion

    #region InitDataColumns Method
    /// <summary>
    /// Use this area to initialize any starting values for data in the Properties collection for each Entity property.
    /// </summary>
    protected override void InitDataColumns()
    {
      PDSAProperty prop;

      // Fill in Column Properties
      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// This is called prior to performing a Business Rule Check or an INSERT, UPDATE or DELETE
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      // Move all Entity Values into Properties Collection
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).Value = Entity.SettingId;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).SetAsNull == true)
        Entity.SettingId = Guid.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).Value = Entity.SettingGroup;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).SetAsNull == true)
        Entity.SettingGroup = string.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).Value = Entity.SettingSubGroup;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).SetAsNull == true)
        Entity.SettingSubGroup = string.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).Value = Entity.SettingKey;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).SetAsNull == true)
        Entity.SettingKey = string.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).Value = Entity.Value;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).SetAsNull == true)
        Entity.Value = string.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName).SetAsNull == true)
        Entity.InsertName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
        Entity.InsertDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).SetAsNull == true)
        Entity.UpdateName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).SetAsNull == true)
        Entity.UpdateDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull == true)
        Entity.ConcurrencyValue = 0;
      ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).SetAsNull == true)
        Entity.EntityId = Guid.Empty;
    }
    #endregion

    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// This is called whenever you are reading data in from a database.
    ///   For example, from BuildCollection, Load, LoadByPK, etc.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).IsNull == false)
        Entity.SettingId = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).GetAsGuid();
      else
        Entity.SettingId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.SettingId, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).IsNull == false)
        Entity.SettingGroup = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).GetAsString();
      else
        Entity.SettingGroup = string.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.SettingGroup, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).IsNull == false)
        Entity.SettingSubGroup = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).GetAsString();
      else
        Entity.SettingSubGroup = string.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).IsNull == false)
        Entity.SettingKey = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).GetAsString();
      else
        Entity.SettingKey = string.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.SettingKey, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).IsNull == false)
        Entity.Value = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).GetAsString();
      else
        Entity.Value = string.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.Value, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName).GetAsString();
      else
        Entity.InsertName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.InsertName, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      else
        Entity.InsertDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).GetAsString();
      else
        Entity.UpdateName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.UpdateName, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      else
        Entity.UpdateDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.UpdateDate, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      else
        Entity.ConcurrencyValue = 0;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsSettingPDSAValidator.ColumnNames.EntityId, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcsSettingPDSA</returns>
    public gcsSettingPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new gcsSettingPDSA();

      // Move all data into Properties collection
      // This method calls the ColumnCollectionToEntityData method
      DataRowToProperties(dr);
      Entity.IsDirty = false;

      return Entity;
    }
    #endregion

    #region SelectSQL Method
    /// <summary>
    /// Builds the SQL for the SELECT statement, or SELECT stored procedure based on the SelectFilter property.
    /// </summary>
    /// <returns>string</returns>
    public override string SelectSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (SelectFilter)
      {
        case SelectFilters.All:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.AllByEntityId:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectAllByEntityId");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByEntityGroupSubGroupKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectByEntityGroupSubGroupKey");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectSearch");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByEntityId:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_ByEntityId");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByEntityAndGroup:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectByEntityAndGroup");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByEntityGroupAndSubGroup:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_SelectByEntityGroupAndSubGroup");
          }
          else
          {
            
          }
          
          break;

        case SelectFilters.Custom:
          sb.Append(SelectCustom);

          break;          
      }

      SQL = sb.ToString();

      return SQL;
    }
    #endregion

    #region InsertSQL Method
    /// <summary>
    /// Builds the SQL for the INSERT statement, or INSERT stored procedure based on the InsertFilter property.
    /// </summary>
    /// <returns>string</returns>
    public override string InsertSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (InsertFilter)
      {
        case InsertFilters.All:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_Insert");
          }
          else
          {
            
          }
            
          break;
        
        case InsertFilters.Custom:
          sb.Append(InsertCustom);
          
          break;
      }

      SQL = sb.ToString();

      return SQL;
    }
    #endregion

    #region UpdateSQL Method
    /// <summary>
    /// Builds the SQL for the UPDATE statement, or UPDATE stored procedure based on the UpdateFilter property.
    /// </summary>
    /// <returns>string</returns>
    public override string UpdateSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (UpdateFilter)
      {
        case UpdateFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_Update");
          }
          else
          {
            
          }
          
          break;
        case UpdateFilters.UpdateConcurrency:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_UpdateConcurrency");
          }
          else
          {
            
          }
          
          break;
        
        case UpdateFilters.Custom:
          sb.Append(UpdateCustom);
          
          break;
      }

      SQL = sb.ToString();

      return SQL;
    }
    #endregion

    #region DeleteByPK Method
    /// <summary>
    /// Delete a record from the table based on the primary key value that is passed in.
    /// </summary>
    /// <param name="settingId">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid settingId)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.SettingId = settingId;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(settingId);

      RowsAffected = Delete();

      return RowsAffected;
    }
    #endregion

    #region DeleteSQL Method
    /// <summary>
    /// Builds the SQL for the DELETE statement, or DELETE stored procedure. You can set the WhereFilter property to selectively delete rows from the table.
    /// </summary>
    /// <returns>string</returns>
    public override string DeleteSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (DeleteFilter)
      {
        case DeleteFilters.DeleteByPK:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_DeleteByPK");
          }
          else
          {
            
          }
          
          break;

        case DeleteFilters.Custom:
          sb.Append(DeleteCustom);

          break;          
      }

      if(!UseStoredProcs)
      {
        sb.Append(WhereClauseSQL());
      }
     
      SQL = sb.ToString();

      return SQL;
    }
    #endregion

    #region RowCountSQL Method
    /// <summary>
    /// Builds the SELECT Count(*) SQL, or the name of the stored procedure, that will count the number of rows.
    /// </summary>
    /// <returns>string</returns>
    public override string RowCountSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (RowCountFilter)
      {
        case RowCountFilters.All:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsSettingPDSA_RowCount");
          }
          else
          {
            
          }
          
          break;

        case RowCountFilters.Custom:
          sb.Append(RowCountCustom);

          break;          
      }

      if(!UseStoredProcs)
      {
        sb.Append(WhereClauseSQL());
      }
     
      SQL = sb.ToString();

      return SQL;
    }
    #endregion

    #region LoadByPK Method
    /// <summary>
    /// Load a row of data in the Entity properties. Returns a value greater than 0 if it finds the record.
    /// </summary>
    /// <param name="settingId">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid settingId)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.SettingId = settingId;      

      // Load Data into Properties
      RowsAffected = Load();

      // Reset all Collection Properties
      ResetCollectionProperties();
      
      return RowsAffected;
    }
    #endregion
    
    
    #region Updated Method
    /// <summary>
    /// This method is called after a successful update
    /// </summary>
    protected override void Updated()
    {
      Entity.ConcurrencyValue += Convert.ToInt16(1);
    }
    #endregion

    #region SelectFillInParameters Method
    /// <summary>
    /// Builds the CommandObject.Parameters collection for any SELECT statement parameters.
    /// </summary>
    protected override void SelectFillInParameters()
    {
      switch (SelectFilter)
      {
        case SelectFilters.All:
         
          break;
        case SelectFilters.AllByEntityId:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EntityId", DbType.Guid, Entity.EntityId));
         
          break;
        case SelectFilters.ByEntityGroupSubGroupKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EntityId", DbType.Guid, Entity.EntityId));
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingGroup", DbType.String, Entity.SettingGroup));
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingSubGroup", DbType.String, Entity.SettingSubGroup));
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingKey", DbType.String, Entity.SettingKey));
         
          break;
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingId", DbType.Guid, Entity.SettingId));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingGroup", DbType.String, Entity.SettingGroup));
         
          break;
        case SelectFilters.ByEntityId:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EntityId", DbType.Guid, Entity.EntityId));
         
          break;
        case SelectFilters.ByEntityAndGroup:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EntityId", DbType.Guid, Entity.EntityId));
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingGroup", DbType.String, Entity.SettingGroup));
         
          break;
        case SelectFilters.ByEntityGroupAndSubGroup:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EntityId", DbType.Guid, Entity.EntityId));
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingGroup", DbType.String, Entity.SettingGroup));
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@SettingSubGroup", DbType.String, Entity.SettingSubGroup));
         
          break;
      }

      // Add on paging parameters
      if(UsePaging)
      {
        PagingFillInParameters(Entity.ResultSetRowNumberBegin, Entity.ResultSetRowNumberEnd);
      }
    }
    #endregion


    #region SetModificationCommandParameters Method
    /// <summary>
    /// Called to build any parameters prior to submitting an INSERT, UPDATE, or DELETE statement.
    /// </summary>
    protected override void SetModificationCommandParameters()
    {    
      switch (DataModificationAction)
      {
        case PDSADataModificationState.Delete:
          switch (DeleteFilter)
          {
            case DeleteFilters.DeleteByPK:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Insert:
          if (PrimaryKeyType == PDSAPrimaryKeyType.PDSA)
          {
            if (PrimaryKeyGenerate == true)
            {
              //  Get New Primary Key from pdsaTableIds
              PrimaryKeySet(PKGetFromPDSATableIds(PDSALoginName));
            }
          }

          switch (InsertFilter)
          {
            case InsertFilters.All:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingGroup", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingSubGroup", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingKey", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Value", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertName", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.InsertDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EntityId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingGroup", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingGroup).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingSubGroup", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingKey", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingKey).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Value", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.Value).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EntityId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.EntityId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
            case UpdateFilters.UpdateConcurrency:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@SettingId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.SettingId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
