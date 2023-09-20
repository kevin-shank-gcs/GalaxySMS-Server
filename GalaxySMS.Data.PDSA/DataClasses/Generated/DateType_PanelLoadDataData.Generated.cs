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
  /// Used to Select data from the DateType_PanelLoadDataPDSA view.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateType_PanelLoadDataPDSAData : PDSADataClassReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the DateType_PanelLoadDataPDSAData class
    /// </summary>
    public DateType_PanelLoadDataPDSAData() : base()
    {
      Entity = new DateType_PanelLoadDataPDSA();
      ValidatorObject = new DateType_PanelLoadDataPDSAValidator(Entity);

      Init();
    }
    
    /// <summary>
    /// Constructor for the DateType_PanelLoadDataPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a DateType_PanelLoadDataPDSA</param>
    public DateType_PanelLoadDataPDSAData(PDSADataProvider dataProvider,
      DateType_PanelLoadDataPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new DateType_PanelLoadDataPDSAValidator(Entity);

      Init();
    }
     
    /// <summary>
    /// Constructor for the DateType_PanelLoadDataPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a DateType_PanelLoadDataPDSA</param>
    /// <param name="validator">An instance of a DateType_PanelLoadDataPDSAValidator</param>
    public DateType_PanelLoadDataPDSAData(PDSADataProvider dataProvider,
      DateType_PanelLoadDataPDSA entity, DateType_PanelLoadDataPDSAValidator validator)
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
      /// 'Search' SelectFilter
      /// </summary>
      Search
      ,
      /// <summary>
      /// A Custom SelectFilter
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
      /// 'DayTypeName' WhereFilter
      /// </summary>
      DayTypeName
      ,
      /// <summary>
      /// 'LikeDayTypeName' WhereFilter
      /// </summary>
      LikeDayTypeName
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
      /// 'DayTypeName' OrderByFilter
      /// </summary>
      DayTypeName
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
      /// A Custom OrderByFilter
      /// </summary>
      Custom
    }

    /// <summary>
    /// Get/Set a Dynamic SQL to execute to return data.
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
    /// Get/Set a Row Count statement or RowCount stored procedure to execute when calling the RowCount() method. You might need to set a WhereFilter as well.
    /// </summary>
    public RowCountFilters RowCountFilter { get; set; }
    #endregion

    #region Public Property Entity Class
        private DateType_PanelLoadDataPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public DateType_PanelLoadDataPDSA Entity 
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
      ClassName = "DateType_PanelLoadDataPDSAData";
      DBObjectName = "GCS.DateType_PanelLoadData";
      SchemaName = "GCS";
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
    /// Initializes all of the Data Columns with valid data for each field in the table.
    /// </summary>
    protected override void InitDataColumns()
    {
      PDSAProperty prop;

      // Fill in Column Properties
      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

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
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid).Value = Entity.DateTypeUid;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid).SetAsNull == true)
        Entity.DateTypeUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x).Value = Entity.Date_x;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x).SetAsNull == true)
        Entity.Date_x = DateTime.MinValue;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName).Value = Entity.DayTypeName;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName).SetAsNull == true)
        Entity.DayTypeName = string.Empty;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber).Value = Entity.PanelDayTypeNumber;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber).SetAsNull == true)
        Entity.PanelDayTypeNumber = 0;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName).SetAsNull == true)
        Entity.EntityName = string.Empty;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId).SetAsNull == true)
        Entity.EntityId = Guid.Empty;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).SetAsNull == true)
        Entity.ClusterUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull == true)
        Entity.ClusterGroupId = 0;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).SetAsNull == true)
        Entity.ClusterNumber = 0;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).SetAsNull == true)
        Entity.ClusterName = string.Empty;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode).Value = Entity.ScheduleTypeCode;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode).SetAsNull == true)
        Entity.ScheduleTypeCode = 0;
      ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay).Value = Entity.ScheduleTypeDisplay;
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay).SetAsNull == true)
        Entity.ScheduleTypeDisplay = string.Empty;
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
      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid).IsNull == false)
        Entity.DateTypeUid = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid).GetAsGuid();
      else
        Entity.DateTypeUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x).IsNull == false)
        Entity.Date_x = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x).GetAsDate();
      else
        Entity.Date_x = DateTime.MinValue;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName).IsNull == false)
        Entity.DayTypeName = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName).GetAsString();
      else
        Entity.DayTypeName = string.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber).IsNull == false)
        Entity.PanelDayTypeNumber = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber).GetAsShort();
      else
        Entity.PanelDayTypeNumber = 0;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName).GetAsString();
      else
        Entity.EntityName = string.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      else
        Entity.ClusterGroupId = 0;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      else
        Entity.ClusterNumber = 0;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).GetAsString();
      else
        Entity.ClusterName = string.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode).IsNull == false)
        Entity.ScheduleTypeCode = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode).GetAsShort();
      else
        Entity.ScheduleTypeCode = 0;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode).Value);

      if (ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay).IsNull == false)
        Entity.ScheduleTypeDisplay = ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay).GetAsString();
      else
        Entity.ScheduleTypeDisplay = string.Empty;
      Entity.SetOriginalValueForProperty(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay, ValidatorObject.Properties.GetByName(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>DateType_PanelLoadDataPDSA</returns>
    public DateType_PanelLoadDataPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new DateType_PanelLoadDataPDSA();

      // Move all data into Properties collection
      // This method calls the ColumnCollectionToEntityData method
      DataRowToProperties(dr);
      Entity.IsDirty = false;

      return Entity;
    }
    #endregion

    #region SelectSQL Method
    /// <summary>
    /// Builds the SQL for the SELECT statement based on the SelectFilter property.
    /// </summary>
    /// <returns>string</returns>
    public override string SelectSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (SelectFilter)
      {
        case SelectFilters.All:
          
          
          break;
        case SelectFilters.Search:
          
          
          break;

        case SelectFilters.Custom:
          sb.Append(SelectCustom);

          break;          
      }

      SQL = sb.ToString();

      return SQL;
    }
    #endregion

    #region RowCountSQL Method
    /// <summary>
    /// Builds the SELECT Count(*) SQL that will count the number of rows returned from this view.
    /// </summary>
    /// <returns>string</returns>
    public override string RowCountSQL()
    {
      StringBuilder sb = new StringBuilder(SB_INIT_LENGTH);

      switch (RowCountFilter)
      {
        case RowCountFilters.All:
          
          
          break;

        case RowCountFilters.Custom:
          sb.Append(RowCountCustom);

          break;          
      }

      sb.Append(WhereClauseSQL());
     
      SQL = sb.ToString();

      return SQL;
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

        case WhereFilters.DayTypeName:
          
          
          break;
        case WhereFilters.LikeDayTypeName:
          
          
          break;
      }
      
      return sb.ToString();
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
        case SelectFilters.Search:
         
          break;
      }

      // Add on paging parameters
      if(UsePaging)
      {
        PagingFillInParameters(Entity.ResultSetRowNumberBegin, Entity.ResultSetRowNumberEnd);
      }
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
        case WhereFilters.DayTypeName:
         
          break;
        case WhereFilters.LikeDayTypeName:
         
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
          
        case OrderByFilters.DayTypeName:
          
          
          break;
      }

      return sb.ToString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateType_PanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DateTypeUid'
    /// </summary>
    public static string DateTypeUid = "DateTypeUid";
    /// <summary>
    /// Returns 'Date'
    /// </summary>
    public static string Date_x = "Date";
    /// <summary>
    /// Returns 'DayTypeName'
    /// </summary>
    public static string DayTypeName = "DayTypeName";
    /// <summary>
    /// Returns 'PanelDayTypeNumber'
    /// </summary>
    public static string PanelDayTypeNumber = "PanelDayTypeNumber";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "ScheduleTypeCode";
    /// <summary>
    /// Returns 'ScheduleTypeDisplay'
    /// </summary>
    public static string ScheduleTypeDisplay = "ScheduleTypeDisplay";
    }
    #endregion
  }
}
