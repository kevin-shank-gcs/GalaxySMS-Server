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
  /// Used to Add/Edit/Delete/Select data from the AreaEntityMapPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AreaEntityMapPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AreaEntityMapPDSAData class
    /// </summary>
    public AreaEntityMapPDSAData() : base()
    {
      Entity = new AreaEntityMapPDSA();
      ValidatorObject = new AreaEntityMapPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AreaEntityMapPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AreaEntityMapPDSA</param>
    public AreaEntityMapPDSAData(AreaEntityMapPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new AreaEntityMapPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AreaEntityMapPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AreaEntityMapPDSA</param>
    public AreaEntityMapPDSAData(PDSADataProvider dataProvider,
      AreaEntityMapPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new AreaEntityMapPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AreaEntityMapPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AreaEntityMapPDSA</param>
    /// <param name="validator">An instance of a AreaEntityMapPDSAValidator</param>
    public AreaEntityMapPDSAData(PDSADataProvider dataProvider,
      AreaEntityMapPDSA entity, AreaEntityMapPDSAValidator validator)
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
      /// 'ByEntityId' SelectFilter
      /// </summary>
      ByEntityId
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
      /// 'ByAreaUid' SelectFilter
      /// </summary>
      ByAreaUid
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
    private AreaEntityMapPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public AreaEntityMapPDSA Entity 
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
      ClassName = "AreaEntityMapPDSAData";
      DBObjectName = "GCS.AreaEntityMap";
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
      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

      prop = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

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
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).Value = Entity.AreaEntityMapUid;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).SetAsNull == true)
        Entity.AreaEntityMapUid = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).Value = Entity.AreaUid;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).SetAsNull == true)
        Entity.AreaUid = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).SetAsNull == true)
        Entity.EntityId = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName).SetAsNull == true)
        Entity.InsertName = string.Empty;
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
        Entity.InsertDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).SetAsNull == true)
        Entity.UpdateName = string.Empty;
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull == true)
        Entity.UpdateDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull == true)
        Entity.ConcurrencyValue = 0;
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
      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).IsNull == false)
        Entity.AreaEntityMapUid = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).GetAsGuid();
      else
        Entity.AreaEntityMapUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).IsNull == false)
        Entity.AreaUid = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).GetAsGuid();
      else
        Entity.AreaUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.AreaUid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.EntityId, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      else
        Entity.InsertName = string.Empty;
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.InsertName, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate).GetAsDate();
      else
        Entity.InsertDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      else
        Entity.UpdateName = string.Empty;
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.UpdateName, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).GetAsDate();
      else
        Entity.UpdateDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).Value);

      if (ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      else
        Entity.ConcurrencyValue = 0;
      Entity.SetOriginalValueForProperty(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AreaEntityMapPDSA</returns>
    public AreaEntityMapPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new AreaEntityMapPDSA();

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
            sb.Append("GCS.AreaEntityMapPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByEntityId:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AreaEntityMapPDSA_ByEntityId");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AreaEntityMapPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AreaEntityMapPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AreaEntityMapPDSA_SelectSearch");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByAreaUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AreaEntityMapPDSA_ByAreaUid");
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
            sb.Append("GCS.AreaEntityMapPDSA_Insert");
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
            sb.Append("GCS.AreaEntityMapPDSA_Update");
          }
          else
          {
            
          }
          
          break;
        case UpdateFilters.UpdateConcurrency:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AreaEntityMapPDSA_UpdateConcurrency");
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
    /// <param name="areaEntityMapUid">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid areaEntityMapUid)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.AreaEntityMapUid = areaEntityMapUid;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(areaEntityMapUid);

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
            sb.Append("GCS.AreaEntityMapPDSA_DeleteByPK");
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
            sb.Append("GCS.AreaEntityMapPDSA_RowCount");
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
    /// <param name="areaEntityMapUid">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid areaEntityMapUid)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.AreaEntityMapUid = areaEntityMapUid;      

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
        case SelectFilters.ByEntityId:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EntityId", DbType.Guid, Entity.EntityId));
         
          break;
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AreaEntityMapUid", DbType.Guid, Entity.AreaEntityMapUid));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@InsertName", DbType.String, Entity.InsertName));
         
          break;
        case SelectFilters.ByAreaUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AreaUid", DbType.Guid, Entity.AreaUid));
         
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
                  "@AreaEntityMapUid", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
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
                  "@AreaEntityMapUid", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AreaUid", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EntityId", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertName", DbType.String, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.InsertDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AreaEntityMapUid", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AreaUid", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EntityId", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.EntityId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
            case UpdateFilters.UpdateConcurrency:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AreaEntityMapUid", DbType.Guid, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.AreaEntityMapUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(AreaEntityMapPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
