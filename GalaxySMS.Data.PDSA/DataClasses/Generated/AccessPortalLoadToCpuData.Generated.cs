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
  /// Used to Add/Edit/Delete/Select data from the AccessPortalLoadToCpuPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalLoadToCpuPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessPortalLoadToCpuPDSAData class
    /// </summary>
    public AccessPortalLoadToCpuPDSAData() : base()
    {
      Entity = new AccessPortalLoadToCpuPDSA();
      ValidatorObject = new AccessPortalLoadToCpuPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AccessPortalLoadToCpuPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AccessPortalLoadToCpuPDSA</param>
    public AccessPortalLoadToCpuPDSAData(AccessPortalLoadToCpuPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new AccessPortalLoadToCpuPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessPortalLoadToCpuPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessPortalLoadToCpuPDSA</param>
    public AccessPortalLoadToCpuPDSAData(PDSADataProvider dataProvider,
      AccessPortalLoadToCpuPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new AccessPortalLoadToCpuPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessPortalLoadToCpuPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessPortalLoadToCpuPDSA</param>
    /// <param name="validator">An instance of a AccessPortalLoadToCpuPDSAValidator</param>
    public AccessPortalLoadToCpuPDSAData(PDSADataProvider dataProvider,
      AccessPortalLoadToCpuPDSA entity, AccessPortalLoadToCpuPDSAValidator validator)
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
      /// 'ByCpuUid' SelectFilter
      /// </summary>
      ByCpuUid
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
    private AccessPortalLoadToCpuPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public AccessPortalLoadToCpuPDSA Entity 
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
      ClassName = "AccessPortalLoadToCpuPDSAData";
      DBObjectName = "GCS.AccessPortalLoadToCpu";
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
      prop = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate);
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
      ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).Value = Entity.AccessPortalLoadToCpuUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).SetAsNull == true)
        Entity.AccessPortalLoadToCpuUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).Value = Entity.AccessPortalGalaxyHardwareAddressUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).SetAsNull == true)
        Entity.AccessPortalGalaxyHardwareAddressUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).SetAsNull == true)
        Entity.CpuUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value = Entity.LastForceLoadDate;
      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).SetAsNull == true)
        Entity.LastForceLoadDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).Value = Entity.LastLoadedDate;
      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).SetAsNull == true)
        Entity.LastLoadedDate = DateTimeOffset.Now;
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
      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).IsNull == false)
        Entity.AccessPortalLoadToCpuUid = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).GetAsGuid();
      else
        Entity.AccessPortalLoadToCpuUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).IsNull == false)
        Entity.AccessPortalGalaxyHardwareAddressUid = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).GetAsGuid();
      else
        Entity.AccessPortalGalaxyHardwareAddressUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      else
        Entity.CpuUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).IsNull == false)
        Entity.LastForceLoadDate = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).GetAsDateTimeOffset();
      else
        Entity.LastForceLoadDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).IsNull == false)
        Entity.LastLoadedDate = ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).GetAsDateTimeOffset();
      else
        Entity.LastLoadedDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AccessPortalLoadToCpuPDSA</returns>
    public AccessPortalLoadToCpuPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new AccessPortalLoadToCpuPDSA();

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
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_SelectSearch");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByCpuUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_ByCpuUid");
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
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_Insert");
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
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_Update");
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
    /// <param name="accessPortalLoadToCpuUid">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid accessPortalLoadToCpuUid)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.AccessPortalLoadToCpuUid = accessPortalLoadToCpuUid;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(accessPortalLoadToCpuUid);

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
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_DeleteByPK");
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
            sb.Append("GCS.AccessPortalLoadToCpuPDSA_RowCount");
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
    /// <param name="accessPortalLoadToCpuUid">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid accessPortalLoadToCpuUid)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.AccessPortalLoadToCpuUid = accessPortalLoadToCpuUid;      

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
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AccessPortalLoadToCpuUid", DbType.Guid, Entity.AccessPortalLoadToCpuUid));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AccessPortalLoadToCpuUid", DbType.Guid, Entity.AccessPortalLoadToCpuUid));
         
          break;
        case SelectFilters.ByCpuUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CpuUid", DbType.Guid, Entity.CpuUid));
         
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
                  "@AccessPortalLoadToCpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).Value));
              
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
                  "@AccessPortalLoadToCpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalGalaxyHardwareAddressUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastForceLoadDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastLoadedDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalLoadToCpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalGalaxyHardwareAddressUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastForceLoadDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@LastLoadedDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
