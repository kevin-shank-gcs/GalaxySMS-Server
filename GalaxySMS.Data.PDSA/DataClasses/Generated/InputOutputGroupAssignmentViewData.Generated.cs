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
  /// Used to Select data from the InputOutputGroupAssignmentViewPDSA view.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroupAssignmentViewPDSAData : PDSADataClassReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the InputOutputGroupAssignmentViewPDSAData class
    /// </summary>
    public InputOutputGroupAssignmentViewPDSAData() : base()
    {
      Entity = new InputOutputGroupAssignmentViewPDSA();
      ValidatorObject = new InputOutputGroupAssignmentViewPDSAValidator(Entity);

      Init();
    }
    
    /// <summary>
    /// Constructor for the InputOutputGroupAssignmentViewPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputOutputGroupAssignmentViewPDSA</param>
    public InputOutputGroupAssignmentViewPDSAData(PDSADataProvider dataProvider,
      InputOutputGroupAssignmentViewPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new InputOutputGroupAssignmentViewPDSAValidator(Entity);

      Init();
    }
     
    /// <summary>
    /// Constructor for the InputOutputGroupAssignmentViewPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputOutputGroupAssignmentViewPDSA</param>
    /// <param name="validator">An instance of a InputOutputGroupAssignmentViewPDSAValidator</param>
    public InputOutputGroupAssignmentViewPDSAData(PDSADataProvider dataProvider,
      InputOutputGroupAssignmentViewPDSA entity, InputOutputGroupAssignmentViewPDSAValidator validator)
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
      /// 'DeviceName' WhereFilter
      /// </summary>
      DeviceName
      ,
      /// <summary>
      /// 'InputOutputGroupUid' WhereFilter
      /// </summary>
      InputOutputGroupUid
      ,
      /// <summary>
      /// 'LikeDeviceName' WhereFilter
      /// </summary>
      LikeDeviceName
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
      /// 'DeviceName' OrderByFilter
      /// </summary>
      DeviceName
      ,
      /// <summary>
      /// 'Display' OrderByFilter
      /// </summary>
      Display
      ,
      /// <summary>
      /// 'OffsetIndex' OrderByFilter
      /// </summary>
      OffsetIndex
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
        private InputOutputGroupAssignmentViewPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public InputOutputGroupAssignmentViewPDSA Entity 
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
      ClassName = "InputOutputGroupAssignmentViewPDSAData";
      DBObjectName = "GCS.InputOutputGroupAssignmentView";
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
      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBoolean.Null;
      //prop.ValueForNull = false;

      prop = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid);
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
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid).Value = Entity.InputOutputGroupAssignmentUid;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid).SetAsNull == true)
        Entity.InputOutputGroupAssignmentUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull == true)
        Entity.InputOutputGroupUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex).Value = Entity.OffsetIndex;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex).SetAsNull == true)
        Entity.OffsetIndex = 0;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName).Value = Entity.DeviceName;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName).SetAsNull == true)
        Entity.DeviceName = string.Empty;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType).Value = Entity.EventType;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType).SetAsNull == true)
        Entity.EventType = string.Empty;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType).Value = Entity.DeviceType;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType).SetAsNull == true)
        Entity.DeviceType = string.Empty;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display).SetAsNull == true)
        Entity.Display = string.Empty;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup).Value = Entity.LocalIOGroup;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup).SetAsNull == true)
        Entity.LocalIOGroup = false;
      ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull == true)
        Entity.GalaxyPanelUid = Guid.Empty;
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
      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid).IsNull == false)
        Entity.InputOutputGroupAssignmentUid = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid).GetAsGuid();
      else
        Entity.InputOutputGroupAssignmentUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      else
        Entity.InputOutputGroupUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex).IsNull == false)
        Entity.OffsetIndex = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex).GetAsShort();
      else
        Entity.OffsetIndex = 0;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName).IsNull == false)
        Entity.DeviceName = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName).GetAsString();
      else
        Entity.DeviceName = string.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType).IsNull == false)
        Entity.EventType = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType).GetAsString();
      else
        Entity.EventType = string.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType).IsNull == false)
        Entity.DeviceType = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType).GetAsString();
      else
        Entity.DeviceType = string.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display).GetAsString();
      else
        Entity.Display = string.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup).IsNull == false)
        Entity.LocalIOGroup = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup).GetAsBool();
      else
        Entity.LocalIOGroup = false;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup).Value);

      if (ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      else
        Entity.GalaxyPanelUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid, ValidatorObject.Properties.GetByName(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>InputOutputGroupAssignmentViewPDSA</returns>
    public InputOutputGroupAssignmentViewPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new InputOutputGroupAssignmentViewPDSA();

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

        case WhereFilters.DeviceName:
          
          
          break;
        case WhereFilters.InputOutputGroupUid:
          
          
          break;
        case WhereFilters.LikeDeviceName:
          
          
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
        case WhereFilters.DeviceName:
         
          break;
        case WhereFilters.InputOutputGroupUid:
         
          break;
        case WhereFilters.LikeDeviceName:
         
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
          
        case OrderByFilters.DeviceName:
          
          
          break;
        case OrderByFilters.Display:
          
          
          break;
        case OrderByFilters.OffsetIndex:
          
          
          break;
      }

      return sb.ToString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupAssignmentViewPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputOutputGroupAssignmentUid'
    /// </summary>
    public static string InputOutputGroupAssignmentUid = "InputOutputGroupAssignmentUid";
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
    /// <summary>
    /// Returns 'OffsetIndex'
    /// </summary>
    public static string OffsetIndex = "OffsetIndex";
    /// <summary>
    /// Returns 'DeviceName'
    /// </summary>
    public static string DeviceName = "DeviceName";
    /// <summary>
    /// Returns 'EventType'
    /// </summary>
    public static string EventType = "EventType";
    /// <summary>
    /// Returns 'DeviceType'
    /// </summary>
    public static string DeviceType = "DeviceType";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'LocalIOGroup'
    /// </summary>
    public static string LocalIOGroup = "LocalIOGroup";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    }
    #endregion
  }
}
