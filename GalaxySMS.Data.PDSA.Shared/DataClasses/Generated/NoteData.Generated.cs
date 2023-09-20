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
  /// Used to Add/Edit/Delete/Select data from the NotePDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class NotePDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the NotePDSAData class
    /// </summary>
    public NotePDSAData() : base()
    {
      Entity = new NotePDSA();
      ValidatorObject = new NotePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the NotePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a NotePDSA</param>
    public NotePDSAData(NotePDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new NotePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the NotePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a NotePDSA</param>
    public NotePDSAData(PDSADataProvider dataProvider,
      NotePDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new NotePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the NotePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a NotePDSA</param>
    /// <param name="validator">An instance of a NotePDSAValidator</param>
    public NotePDSAData(PDSADataProvider dataProvider,
      NotePDSA entity, NotePDSAValidator validator)
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
      /// 'AllForAccessPortal' SelectFilter
      /// </summary>
      AllForAccessPortal
      ,
      /// <summary>
      /// 'AllForPersonUid' SelectFilter
      /// </summary>
      AllForPersonUid
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
    private NotePDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public NotePDSA Entity 
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
      ClassName = "NotePDSAData";
      DBObjectName = "GCS.Note";
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
      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBinary.Null;
      //prop.ValueForNull = new byte[0];

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBinary.Null;
      //prop.ValueForNull = new byte[0];

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.AccessPortalUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.PersonUid);
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
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).Value = Entity.NoteUid;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).SetAsNull == true)
        Entity.NoteUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).Value = Entity.Category;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).SetAsNull == true)
        Entity.Category = string.Empty;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).Value = Entity.NoteText;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).SetAsNull == true)
        Entity.NoteText = string.Empty;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).Value = Entity.Photo;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).SetAsNull == true)
        Entity.Photo = null;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).Value = Entity.Document;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).SetAsNull == true)
        Entity.Document = null;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName).SetAsNull == true)
        Entity.InsertName = string.Empty;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
        Entity.InsertDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).SetAsNull == true)
        Entity.UpdateName = string.Empty;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).SetAsNull == true)
        Entity.UpdateDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull == true)
        Entity.ConcurrencyValue = 0;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.AccessPortalUid).SetAsNull == true)
        Entity.AccessPortalUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.PersonUid).SetAsNull == true)
        Entity.PersonUid = Guid.Empty;
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
      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).IsNull == false)
        Entity.NoteUid = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).GetAsGuid();
      else
        Entity.NoteUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.NoteUid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).IsNull == false)
        Entity.Category = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).GetAsString();
      else
        Entity.Category = string.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.Category, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).IsNull == false)
        Entity.NoteText = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).GetAsString();
      else
        Entity.NoteText = string.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.NoteText, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).IsNull == false)
        Entity.Photo = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).GetAsByteArray();
      else
        Entity.Photo = new byte[0];
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.Photo, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).IsNull == false)
        Entity.Document = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).GetAsByteArray();
      else
        Entity.Document = new byte[0];
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.Document, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName).GetAsString();
      else
        Entity.InsertName = string.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.InsertName, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate).GetAsDate();
      else
        Entity.InsertDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).GetAsString();
      else
        Entity.UpdateName = string.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.UpdateName, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).GetAsDate();
      else
        Entity.UpdateDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.UpdateDate, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      else
        Entity.ConcurrencyValue = 0;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.ConcurrencyValue, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      else
        Entity.AccessPortalUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.AccessPortalUid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.AccessPortalUid).Value);

      if (ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      else
        Entity.PersonUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(NotePDSAValidator.ColumnNames.PersonUid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.PersonUid).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>NotePDSA</returns>
    public NotePDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new NotePDSA();

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
            sb.Append("GCS.NotePDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.AllForAccessPortal:
          if (UseStoredProcs)
          {
            sb.Append("GCS.NotePDSA_SelectAllForAccessPortal");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.AllForPersonUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.NotePDSA_SelectAllForPersonUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.NotePDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.NotePDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.NotePDSA_SelectSearch");
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
            sb.Append("GCS.NotePDSA_Insert");
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
            sb.Append("GCS.NotePDSA_Update");
          }
          else
          {
            
          }
          
          break;
        case UpdateFilters.UpdateConcurrency:
          if (UseStoredProcs)
          {
            sb.Append("GCS.NotePDSA_UpdateConcurrency");
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
    /// <param name="noteUid">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid noteUid)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.NoteUid = noteUid;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(noteUid);

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
            sb.Append("GCS.NotePDSA_DeleteByPK");
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
            sb.Append("GCS.NotePDSA_RowCount");
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
    /// <param name="noteUid">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid noteUid)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.NoteUid = noteUid;      

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
        case SelectFilters.AllForAccessPortal:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AccessPortalUid", DbType.Guid, Entity.AccessPortalUid));
         
          break;
        case SelectFilters.AllForPersonUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@PersonUid", DbType.Guid, Entity.PersonUid));
         
          break;
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@NoteUid", DbType.Guid, Entity.NoteUid));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@Category", DbType.String, Entity.Category));
         
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
                  "@NoteUid", DbType.Guid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
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
                  "@NoteUid", DbType.Guid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Category", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NoteText", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertName", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.InsertDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Document", DbType.Binary, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Photo", DbType.Binary, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NoteUid", DbType.Guid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Category", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Category).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NoteText", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteText).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Document", DbType.Binary, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Document).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Photo", DbType.Binary, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.Photo).Value));
              
              break;
            case UpdateFilters.UpdateConcurrency:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NoteUid", DbType.Guid, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.NoteUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(NotePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
