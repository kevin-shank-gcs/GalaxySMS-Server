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
  /// Used to Add/Edit/Delete/Select data from the CredentialToLoadToCpuPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialToLoadToCpuPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the CredentialToLoadToCpuPDSAData class
    /// </summary>
    public CredentialToLoadToCpuPDSAData() : base()
    {
      Entity = new CredentialToLoadToCpuPDSA();
      ValidatorObject = new CredentialToLoadToCpuPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the CredentialToLoadToCpuPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a CredentialToLoadToCpuPDSA</param>
    public CredentialToLoadToCpuPDSAData(CredentialToLoadToCpuPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new CredentialToLoadToCpuPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the CredentialToLoadToCpuPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a CredentialToLoadToCpuPDSA</param>
    public CredentialToLoadToCpuPDSAData(PDSADataProvider dataProvider,
      CredentialToLoadToCpuPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new CredentialToLoadToCpuPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the CredentialToLoadToCpuPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a CredentialToLoadToCpuPDSA</param>
    /// <param name="validator">An instance of a CredentialToLoadToCpuPDSAValidator</param>
    public CredentialToLoadToCpuPDSAData(PDSADataProvider dataProvider,
      CredentialToLoadToCpuPDSA entity, CredentialToLoadToCpuPDSAValidator validator)
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
      /// 'ByCpuUid' SelectFilter
      /// </summary>
      ByCpuUid
      ,
      /// <summary>
      /// 'ByCredentialUid' SelectFilter
      /// </summary>
      ByCredentialUid
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
    private CredentialToLoadToCpuPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public CredentialToLoadToCpuPDSA Entity 
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
      ClassName = "CredentialToLoadToCpuPDSAData";
      DBObjectName = "GCS.CredentialToLoadToCpu";
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
      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

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
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).Value = Entity.CredentialToLoadToCpuUid;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).SetAsNull == true)
        Entity.CredentialToLoadToCpuUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).SetAsNull == true)
        Entity.CpuUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).SetAsNull == true)
        Entity.CredentialUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).Value = Entity.LastCredentialChangeDate;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).SetAsNull == true)
        Entity.LastCredentialChangeDate = DateTimeOffset.MinValue;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).Value = Entity.LastPersonalAccessGroupChangeDate;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).SetAsNull == true)
        Entity.LastPersonalAccessGroupChangeDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).Value = Entity.LastCredentialLoadedDate;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).SetAsNull == true)
        Entity.LastCredentialLoadedDate = DateTimeOffset.MinValue;//DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).Value = Entity.LastPersonalAccessGroupLoadedDate;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).SetAsNull == true)
        Entity.LastPersonalAccessGroupLoadedDate = DateTimeOffset.MinValue;//DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value = Entity.LastForceLoadDate;
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).SetAsNull == true)
        Entity.LastForceLoadDate = DateTimeOffset.Now;
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
      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).IsNull == false)
        Entity.CredentialToLoadToCpuUid = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).GetAsGuid();
      else
        Entity.CredentialToLoadToCpuUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      else
        Entity.CpuUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      else
        Entity.CredentialUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).IsNull == false)
        Entity.LastCredentialChangeDate = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).GetAsDateTimeOffset();
      else
        Entity.LastCredentialChangeDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).IsNull == false)
        Entity.LastPersonalAccessGroupChangeDate = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).GetAsDateTimeOffset();
      else
        Entity.LastPersonalAccessGroupChangeDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).IsNull == false)
        Entity.LastCredentialLoadedDate = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).GetAsDateTimeOffset();
      else
        Entity.LastCredentialLoadedDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).IsNull == false)
        Entity.LastPersonalAccessGroupLoadedDate = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).GetAsDateTimeOffset();
      else
        Entity.LastPersonalAccessGroupLoadedDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).Value);

      if (ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).IsNull == false)
        Entity.LastForceLoadDate = ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).GetAsDateTimeOffset();
      else
        Entity.LastForceLoadDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>CredentialToLoadToCpuPDSA</returns>
    public CredentialToLoadToCpuPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new CredentialToLoadToCpuPDSA();

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
            sb.Append("GCS.CredentialToLoadToCpuPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByCpuUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.CredentialToLoadToCpuPDSA_ByCpuUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByCredentialUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.CredentialToLoadToCpuPDSA_ByCredentialUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.CredentialToLoadToCpuPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.CredentialToLoadToCpuPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.CredentialToLoadToCpuPDSA_SelectSearch");
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
            sb.Append("GCS.CredentialToLoadToCpuPDSA_Insert");
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
            sb.Append("GCS.CredentialToLoadToCpuPDSA_Update");
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
    /// <param name="credentialToLoadToCpuUid">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid credentialToLoadToCpuUid)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.CredentialToLoadToCpuUid = credentialToLoadToCpuUid;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(credentialToLoadToCpuUid);

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
            sb.Append("GCS.CredentialToLoadToCpuPDSA_DeleteByPK");
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
            sb.Append("GCS.CredentialToLoadToCpuPDSA_RowCount");
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
    /// <param name="credentialToLoadToCpuUid">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid credentialToLoadToCpuUid)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.CredentialToLoadToCpuUid = credentialToLoadToCpuUid;      

      // Load Data into Properties
      RowsAffected = Load();

      // Reset all Collection Properties
      ResetCollectionProperties();
      
      return RowsAffected;
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
        case SelectFilters.ByCpuUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CpuUid", DbType.Guid, Entity.CpuUid));
         
          break;
        case SelectFilters.ByCredentialUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CredentialUid", DbType.Guid, Entity.CredentialUid));
         
          break;
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CredentialToLoadToCpuUid", DbType.Guid, Entity.CredentialToLoadToCpuUid));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CredentialToLoadToCpuUid", DbType.Guid, Entity.CredentialToLoadToCpuUid));
         
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
                  "@CredentialToLoadToCpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).Value));
              
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
                  "@CredentialToLoadToCpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastCredentialChangeDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastPersonalAccessGroupChangeDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastCredentialLoadedDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastPersonalAccessGroupLoadedDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastForceLoadDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialToLoadToCpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialToLoadToCpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialUid", DbType.Guid, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.CredentialUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastCredentialChangeDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialChangeDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastPersonalAccessGroupChangeDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupChangeDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastCredentialLoadedDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastCredentialLoadedDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastPersonalAccessGroupLoadedDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastPersonalAccessGroupLoadedDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastForceLoadDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(CredentialToLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
