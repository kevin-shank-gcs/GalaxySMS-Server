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
  /// Used to Add/Edit/Delete/Select data from the gcsEnumValuePDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsEnumValuePDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsEnumValuePDSAData class
    /// </summary>
    public gcsEnumValuePDSAData() : base()
    {
      Entity = new gcsEnumValuePDSA();
      ValidatorObject = new gcsEnumValuePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsEnumValuePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsEnumValuePDSA</param>
    public gcsEnumValuePDSAData(gcsEnumValuePDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new gcsEnumValuePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsEnumValuePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsEnumValuePDSA</param>
    public gcsEnumValuePDSAData(PDSADataProvider dataProvider,
      gcsEnumValuePDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new gcsEnumValuePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsEnumValuePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsEnumValuePDSA</param>
    /// <param name="validator">An instance of a gcsEnumValuePDSAValidator</param>
    public gcsEnumValuePDSAData(PDSADataProvider dataProvider,
      gcsEnumValuePDSA entity, gcsEnumValuePDSAValidator validator)
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
      /// 'ByEnumNamespaceId' SelectFilter
      /// </summary>
      ByEnumNamespaceId
      ,
      /// <summary>
      /// A Custom Select Filter
      /// </summary>
      Custom
    }

    /// <summary>
    /// Enumeration for selecting a WHERE statement when calling the Load, GetDataSet or GetDataReader method.
    /// </summary>
    public enum WhereFilters
    {
      /// <summary>
      /// No WhereFilter Selected
      /// </summary>
      None,
      /// <summary>
      /// A Custom WhereFilter
      /// </summary>
      Custom
      ,
      /// <summary>
      /// 'PrimaryKey' WhereFilter
      /// </summary>
      PrimaryKey
      ,
      /// <summary>
      /// 'Description' WhereFilter
      /// </summary>
      Description
      ,
      /// <summary>
      /// 'LikeDescription' WhereFilter
      /// </summary>
      LikeDescription
      ,
      /// <summary>
      /// 'EnumNamespaceId' WhereFilter
      /// </summary>
      EnumNamespaceId
    }

    /// <summary>
    /// Enumeration for selecting an ORDER BY statement when calling the Load, GetDataSet or GetDataReader method.
    /// </summary>
    public enum OrderByFilters
    {
      /// <summary>
      /// No OrderByFilter Selected
      /// </summary>
      None,
      /// <summary>
      /// A Custom OrderByFilter
      /// </summary>
      Custom
      ,
      /// <summary>
      /// 'Description' OrderByFilter
      /// </summary>
      Description
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
      /// 'All' DeleteFilter
      /// </summary>
      All
      ,
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
    /// Get/Set a WHERE clause to be used with a SELECT statement when using Dynamic SQL.
    /// </summary>
    public WhereFilters WhereFilter { get; set; }
    /// <summary>
    /// Get/Set a ORDER BY clause to be used with a SELECT statement when using Dynamic SQL.
    /// </summary>
    public OrderByFilters OrderByFilter { get; set; }
    
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
    private gcsEnumValuePDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public gcsEnumValuePDSA Entity 
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
      ClassName = "gcsEnumValuePDSAData";
      DBObjectName = "GCS.gcsEnumValue";
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
      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

      prop = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue);
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
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value = Entity.EnumValueId;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).SetAsNull == true)
        Entity.EnumValueId = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).Value = Entity.EnumNamespaceId;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).SetAsNull == true)
        Entity.EnumNamespaceId = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).Value = Entity.Value;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).SetAsNull == true)
        Entity.Value = 0;
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).SetAsNull == true)
        Entity.Description = string.Empty;
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).SetAsNull == true)
        Entity.InsertName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
        Entity.InsertDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).SetAsNull == true)
        Entity.UpdateName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).SetAsNull == true)
        Entity.UpdateDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull == true)
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
      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).IsNull == false)
        Entity.EnumValueId = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).GetAsGuid();
      else
        Entity.EnumValueId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).IsNull == false)
        Entity.EnumNamespaceId = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).GetAsGuid();
      else
        Entity.EnumNamespaceId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).IsNull == false)
        Entity.Value = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).GetAsInteger();
      else
        Entity.Value = 0;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.Value, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).GetAsString();
      else
        Entity.Description = string.Empty;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.Description, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).GetAsString();
      else
        Entity.InsertName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.InsertName, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).GetAsDate();
      else
        Entity.InsertDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).GetAsString();
      else
        Entity.UpdateName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.UpdateName, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).GetAsDate();
      else
        Entity.UpdateDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).Value);

      if (ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      else
        Entity.ConcurrencyValue = 0;
      Entity.SetOriginalValueForProperty(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcsEnumValuePDSA</returns>
    public gcsEnumValuePDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new gcsEnumValuePDSA();

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
            sb.Append("GCS.gcsEnumValue_SelectAll");
          }
          else
          {
            sb.Append(" SELECT EnumValueId, EnumNamespaceId, [Value], Description, InsertName, InsertDate, UpdateName, UpdateDate, ConcurrencyValue FROM GCS.gcsEnumValue");

          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsEnumValue_SelectListBox");
          }
          else
          {
            sb.Append(" SELECT EnumValueId, Description FROM GCS.gcsEnumValue");

          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsEnumValue_SelectByPK");
          }
          else
          {
            sb.Append(" SELECT EnumValueId, EnumNamespaceId, [Value], Description, InsertName, InsertDate, UpdateName, UpdateDate, ConcurrencyValue FROM GCS.gcsEnumValue WHERE EnumValueId = @EnumValueId");

          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsEnumValue_SelectSearch");
          }
          else
          {
            sb.Append(" SELECT EnumValueId, EnumNamespaceId, [Value], Description, InsertName, InsertDate, UpdateName, UpdateDate, ConcurrencyValue FROM GCS.gcsEnumValue WHERE (@Description IS NULL OR Description LIKE @Description + '%')");

          }
          
          break;
        case SelectFilters.ByEnumNamespaceId:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsEnumValue_ByDescriptionResourceId");
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
            sb.Append("GCS.gcsEnumValue_Insert");
          }
          else
          {
            sb.Append(" INSERT INTO GCS.gcsEnumValue ( EnumValueId, EnumNamespaceId, [Value], Description, InsertName, InsertDate, UpdateName, UpdateDate, ConcurrencyValue ) VALUES ( @EnumValueId, @EnumNamespaceId, @Value, @Description, @InsertName, @InsertDate, @UpdateName, @UpdateDate, @ConcurrencyValue )");

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
            sb.Append("GCS.gcsEnumValue_Update");
          }
          else
          {
            sb.Append(" UPDATE GCS.gcsEnumValue SET EnumValueId = @EnumValueId, EnumNamespaceId = @EnumNamespaceId, [Value] = @Value, Description = @Description, UpdateName = @UpdateName, UpdateDate = @UpdateDate, ConcurrencyValue = ConcurrencyValue + 1 WHERE EnumValueId = @EnumValueId And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)");

          }
          
          break;
        case UpdateFilters.UpdateConcurrency:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsEnumValue_UpdateConcurrency");
          }
          else
          {
            sb.Append(" UPDATE GCS.gcsEnumValue SET ConcurrencyValue = @ConcurrencyValue WHERE EnumValueId = @EnumValueId");

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
    /// <param name="enumValueId">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid enumValueId)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.EnumValueId = enumValueId;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(enumValueId);

      // Set WhereFilter to None here, because it got set in LoadByPK
      WhereFilter = WhereFilters.None;
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
        case DeleteFilters.All:
          if (UseStoredProcs)
          {
            sb.Append("");
          }
          else
          {
            sb.Append(" DELETE FROM GCS.gcsEnumValue");

          }
          
          break;
        case DeleteFilters.DeleteByPK:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsEnumValue_DeleteByPK");
          }
          else
          {
            sb.Append(" DELETE FROM GCS.gcsEnumValue WHERE EnumValueId = @EnumValueId And (ConcurrencyValue = @ConcurrencyValue OR ConcurrencyValue is null)");

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
            sb.Append("GCS.gcsEnumValue_RowCount");
          }
          else
          {
            sb.Append(" SELECT Count(*) As NumRecs FROM GCS.gcsEnumValue");

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
    /// <param name="enumValueId">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid enumValueId)
    {
      WhereFilter = WhereFilters.None;
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.EnumValueId = enumValueId;      

      // Load Data into Properties
      RowsAffected = Load();

      // Reset all Collection Properties
      ResetCollectionProperties();
      
      return RowsAffected;
    }
    #endregion
    
    #region WhereClauseSQL Method
    /// <summary>
    /// Builds the WHERE clause to be used in combination with a SELECT statement.
    /// </summary>
    /// <returns>string</returns>
    public override string WhereClauseSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (WhereFilter)
      {
        case WhereFilters.Custom:
          sb.Append(" " + WhereCustom);

          break;

        case WhereFilters.None:
          //  Do nothing

          break;

        case WhereFilters.PrimaryKey:
          sb.Append(" WHERE EnumValueId = @EnumValueId");

          
          break;
        case WhereFilters.Description:
          sb.Append(" WHERE Description = @Description");

          
          break;
        case WhereFilters.LikeDescription:
          sb.Append(" WHERE Description LIKE @Description + '%'");

          
          break;
        case WhereFilters.EnumNamespaceId:
          sb.Append(" WHERE EnumNamespaceId = @EnumNamespaceId");

          
          break;
      }
      
      return sb.ToString();
    }
    #endregion

    #region WhereClauseFillInParameters Method
    /// <summary>
    /// Builds the CommandObject.Parameters collection for any WHERE clause parameters.
    /// </summary>
    protected override void WhereClauseFillInParameters()
    {
      switch (WhereFilter)
      {

        case WhereFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EnumValueId", DbType.Guid, Entity.EnumValueId));
         
          break;
        case WhereFilters.Description:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@Description", DbType.String, Entity.Description));
         
          break;
        case WhereFilters.LikeDescription:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@Description", DbType.String, Entity.Description));
         
          break;
        case WhereFilters.EnumNamespaceId:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EnumNamespaceId", DbType.Guid, Entity.EnumNamespaceId));
         
          break;
      }
    }
    #endregion

    #region OrderByClauseSQL Method
    /// <summary>
    /// Builds the ORDER BY clause to be used in combination with a SELECT statement.
    /// </summary>
    /// <returns>string</returns>
    public override string OrderByClauseSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (OrderByFilter)
      {
        case OrderByFilters.None:
          //  Do Nothing

          break;

        case OrderByFilters.Custom:
          sb.Append(" " + OrderByCustom);

          break;
          
        case OrderByFilters.Description:
          sb.Append(" ORDER BY Description");

          
          break;
      }
      
      return sb.ToString();
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
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EnumValueId", DbType.Guid, Entity.EnumValueId));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@Description", DbType.String, Entity.Description));
         
          break;
        case SelectFilters.ByEnumNamespaceId:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@EnumNamespaceId", DbType.Guid, Entity.EnumNamespaceId));
         
          break;
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
            case DeleteFilters.All:
             CommandObject.Parameters.Clear();
              
              break;
            case DeleteFilters.DeleteByPK:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EnumValueId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }
          if (this.WhereFilter != WhereFilters.None)
            WhereClauseFillInParameters();

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
          // Clear any Where Filter when doing an INSERT
          this.WhereFilter = WhereFilters.None;

          switch (InsertFilter)
          {
            case InsertFilters.All:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EnumValueId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EnumNamespaceId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Value", DbType.Int32, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Description", DbType.String, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertName", DbType.String, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EnumValueId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EnumNamespaceId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Value", DbType.Int32, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@Description", DbType.String, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
            case UpdateFilters.UpdateConcurrency:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@EnumValueId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
