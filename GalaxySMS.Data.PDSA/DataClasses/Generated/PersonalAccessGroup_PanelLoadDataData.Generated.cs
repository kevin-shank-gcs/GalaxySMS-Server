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
  /// Used to Select data from the PersonalAccessGroup_PanelLoadDataPDSA view.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonalAccessGroup_PanelLoadDataPDSAData : PDSADataClassReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the PersonalAccessGroup_PanelLoadDataPDSAData class
    /// </summary>
    public PersonalAccessGroup_PanelLoadDataPDSAData() : base()
    {
      Entity = new PersonalAccessGroup_PanelLoadDataPDSA();
      ValidatorObject = new PersonalAccessGroup_PanelLoadDataPDSAValidator(Entity);

      Init();
    }
    
    /// <summary>
    /// Constructor for the PersonalAccessGroup_PanelLoadDataPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a PersonalAccessGroup_PanelLoadDataPDSA</param>
    public PersonalAccessGroup_PanelLoadDataPDSAData(PDSADataProvider dataProvider,
      PersonalAccessGroup_PanelLoadDataPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new PersonalAccessGroup_PanelLoadDataPDSAValidator(Entity);

      Init();
    }
     
    /// <summary>
    /// Constructor for the PersonalAccessGroup_PanelLoadDataPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a PersonalAccessGroup_PanelLoadDataPDSA</param>
    /// <param name="validator">An instance of a PersonalAccessGroup_PanelLoadDataPDSAValidator</param>
    public PersonalAccessGroup_PanelLoadDataPDSAData(PDSADataProvider dataProvider,
      PersonalAccessGroup_PanelLoadDataPDSA entity, PersonalAccessGroup_PanelLoadDataPDSAValidator validator)
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
      /// 'AccountCode' WhereFilter
      /// </summary>
      AccountCode
      ,
      /// <summary>
      /// 'LikeAccountCode' WhereFilter
      /// </summary>
      LikeAccountCode
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
      /// 'AccountCode' OrderByFilter
      /// </summary>
      AccountCode
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
        private PersonalAccessGroup_PanelLoadDataPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public PersonalAccessGroup_PanelLoadDataPDSA Entity 
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
      ClassName = "PersonalAccessGroup_PanelLoadDataPDSAData";
      DBObjectName = "GCS.PersonalAccessGroup_PanelLoadData";
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
      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
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
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid).SetAsNull == true)
        Entity.PersonUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).SetAsNull == true)
        Entity.ClusterUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull == true)
        Entity.GalaxyPanelUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber).Value = Entity.PersonalAccessGroupNumber;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber).SetAsNull == true)
        Entity.PersonalAccessGroupNumber = 0;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).SetAsNull == true)
        Entity.ClusterNumber = 0;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull == true)
        Entity.ClusterGroupId = 0;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).Value = Entity.PanelScheduleNumber;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).SetAsNull == true)
        Entity.PanelScheduleNumber = 0;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber).Value = Entity.DoorNumber;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber).SetAsNull == true)
        Entity.DoorNumber = 0;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).SetAsNull == true)
        Entity.PanelNumber = 0;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay).Value = Entity.AccessGroupDisplay;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay).SetAsNull == true)
        Entity.AccessGroupDisplay = string.Empty;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid).SetAsNull == true)
        Entity.TimeScheduleUid = null;
      ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid).Value = Entity.DefaultTimeScheduleUid;
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid).SetAsNull == true)
        Entity.DefaultTimeScheduleUid = Guid.Empty;
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
      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      else
        Entity.PersonUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      else
        Entity.GalaxyPanelUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber).IsNull == false)
        Entity.PersonalAccessGroupNumber = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber).GetAsInteger();
      else
        Entity.PersonalAccessGroupNumber = 0;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      else
        Entity.ClusterNumber = 0;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      else
        Entity.ClusterGroupId = 0;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).IsNull == false)
        Entity.PanelScheduleNumber = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).GetAsInteger();
      else
        Entity.PanelScheduleNumber = 0;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber).IsNull == false)
        Entity.DoorNumber = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber).GetAsShort();
      else
        Entity.DoorNumber = 0;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      else
        Entity.PanelNumber = 0;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay).IsNull == false)
        Entity.AccessGroupDisplay = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay).GetAsString();
      else
        Entity.AccessGroupDisplay = string.Empty;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid).GetAsGuid();
      else
        Entity.TimeScheduleUid = null;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleUid).Value);

      if (ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid).IsNull == false)
        Entity.DefaultTimeScheduleUid = ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid).GetAsGuid();
      else
        Entity.DefaultTimeScheduleUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid, ValidatorObject.Properties.GetByName(PersonalAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DefaultTimeScheduleUid).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>PersonalAccessGroup_PanelLoadDataPDSA</returns>
    public PersonalAccessGroup_PanelLoadDataPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new PersonalAccessGroup_PanelLoadDataPDSA();

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

        case WhereFilters.AccountCode:
          
          
          break;
        case WhereFilters.LikeAccountCode:
          
          
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
        case WhereFilters.AccountCode:
         
          break;
        case WhereFilters.LikeAccountCode:
         
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
          
        case OrderByFilters.AccountCode:
          
          
          break;
      }

      return sb.ToString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonalAccessGroup_PanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'PersonalAccessGroupNumber'
    /// </summary>
    public static string PersonalAccessGroupNumber = "PersonalAccessGroupNumber";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "PanelScheduleNumber";
    /// <summary>
    /// Returns 'DoorNumber'
    /// </summary>
    public static string DoorNumber = "DoorNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'AccessGroupDisplay'
    /// </summary>
    public static string AccessGroupDisplay = "AccessGroupDisplay";
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'DefaultTimeScheduleUid'
    /// </summary>
    public static string DefaultTimeScheduleUid = "DefaultTimeScheduleUid";
    }
    #endregion
  }
}
