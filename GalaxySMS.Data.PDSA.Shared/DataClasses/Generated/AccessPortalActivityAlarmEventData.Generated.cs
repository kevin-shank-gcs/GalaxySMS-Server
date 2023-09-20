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
  /// Used to Add/Edit/Delete/Select data from the AccessPortalActivityAlarmEventPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalActivityAlarmEventPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessPortalActivityAlarmEventPDSAData class
    /// </summary>
    public AccessPortalActivityAlarmEventPDSAData() : base()
    {
      Entity = new AccessPortalActivityAlarmEventPDSA();
      ValidatorObject = new AccessPortalActivityAlarmEventPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AccessPortalActivityAlarmEventPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AccessPortalActivityAlarmEventPDSA</param>
    public AccessPortalActivityAlarmEventPDSAData(AccessPortalActivityAlarmEventPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new AccessPortalActivityAlarmEventPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessPortalActivityAlarmEventPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessPortalActivityAlarmEventPDSA</param>
    public AccessPortalActivityAlarmEventPDSAData(PDSADataProvider dataProvider,
      AccessPortalActivityAlarmEventPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new AccessPortalActivityAlarmEventPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessPortalActivityAlarmEventPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessPortalActivityAlarmEventPDSA</param>
    /// <param name="validator">An instance of a AccessPortalActivityAlarmEventPDSAValidator</param>
    public AccessPortalActivityAlarmEventPDSAData(PDSADataProvider dataProvider,
      AccessPortalActivityAlarmEventPDSA entity, AccessPortalActivityAlarmEventPDSAValidator validator)
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
      /// 'ByAccessPortalUid' SelectFilter
      /// </summary>
      ByAccessPortalUid
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
    private AccessPortalActivityAlarmEventPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public AccessPortalActivityAlarmEventPDSA Entity 
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
      ClassName = "AccessPortalActivityAlarmEventPDSAData";
      DBObjectName = "GCS.AccessPortalActivityAlarmEvent";
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
      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
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
      ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value = Entity.AccessPortalActivityEventUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).SetAsNull == true)
        Entity.AccessPortalActivityEventUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).Value = Entity.NoteUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).SetAsNull == true)
        Entity.NoteUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).SetAsNull == true)
        Entity.BinaryResourceUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).Value = Entity.AlarmPriority;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).SetAsNull == true)
        Entity.AlarmPriority = 0;
      ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull == true)
        Entity.AccessPortalUid = Guid.Empty;
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
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).IsNull == false)
        Entity.AccessPortalActivityEventUid = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).GetAsGuid();
      else
        Entity.AccessPortalActivityEventUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).IsNull == false)
        Entity.NoteUid = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).GetAsGuid();
      else
        Entity.NoteUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).GetAsGuid();
      else
        Entity.BinaryResourceUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).GetAsInteger();
      else
        Entity.AlarmPriority = 0;
      Entity.SetOriginalValueForProperty(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      else
        Entity.AccessPortalUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AccessPortalActivityAlarmEventPDSA</returns>
    public AccessPortalActivityAlarmEventPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new AccessPortalActivityAlarmEventPDSA();

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
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByAccessPortalUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_ByAccessPortalUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_SelectSearch");
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
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_Insert");
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
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_Update");
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
    /// <param name="accessPortalActivityEventUid">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid accessPortalActivityEventUid)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.AccessPortalActivityEventUid = accessPortalActivityEventUid;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(accessPortalActivityEventUid);

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
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_DeleteByPK");
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
            sb.Append("GCS.AccessPortalActivityAlarmEventPDSA_RowCount");
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
    /// <param name="accessPortalActivityEventUid">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid accessPortalActivityEventUid)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.AccessPortalActivityEventUid = accessPortalActivityEventUid;      

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
        case SelectFilters.ByAccessPortalUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AccessPortalUid", DbType.Guid, Entity.AccessPortalUid));
         
          break;
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AccessPortalActivityEventUid", DbType.Guid, Entity.AccessPortalActivityEventUid));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AccessPortalActivityEventUid", DbType.Guid, Entity.AccessPortalActivityEventUid));
         
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
                  "@AccessPortalActivityEventUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value));
              
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
                  "@AccessPortalActivityEventUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NoteUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@BinaryResourceUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AlarmPriority", DbType.Int32, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalActivityEventUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NoteUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@BinaryResourceUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AlarmPriority", DbType.Int32, ValidatorObject.Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
