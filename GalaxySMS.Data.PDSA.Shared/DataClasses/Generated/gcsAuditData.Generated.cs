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
  /// Used to Add/Edit/Delete/Select data from the gcsAuditPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsAuditPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsAuditPDSAData class
    /// </summary>
    public gcsAuditPDSAData() : base()
    {
      Entity = new gcsAuditPDSA();
      ValidatorObject = new gcsAuditPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsAuditPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsAuditPDSA</param>
    public gcsAuditPDSAData(gcsAuditPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new gcsAuditPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsAuditPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsAuditPDSA</param>
    public gcsAuditPDSAData(PDSADataProvider dataProvider,
      gcsAuditPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new gcsAuditPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsAuditPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsAuditPDSA</param>
    /// <param name="validator">An instance of a gcsAuditPDSAValidator</param>
    public gcsAuditPDSAData(PDSADataProvider dataProvider,
      gcsAuditPDSA entity, gcsAuditPDSAValidator validator)
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
    private gcsAuditPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public gcsAuditPDSA Entity 
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
      ClassName = "gcsAuditPDSAData";
      DBObjectName = "GCS.gcsAudit";
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
      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlXml.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBinary.Null;
      //prop.ValueForNull = new byte[0];

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBinary.Null;
      //prop.ValueForNull = new byte[0];

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);

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
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).Value = Entity.AuditId;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).SetAsNull == true)
        Entity.AuditId = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).Value = Entity.TransactionId;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).SetAsNull == true)
        Entity.TransactionId = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).Value = Entity.TableName;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).SetAsNull == true)
        Entity.TableName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).Value = Entity.OperationType;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).SetAsNull == true)
        Entity.OperationType = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).Value = Entity.PrimaryKeyColumn;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).SetAsNull == true)
        Entity.PrimaryKeyColumn = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).Value = Entity.PrimaryKeyValue;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).SetAsNull == true)
        Entity.PrimaryKeyValue = Guid.NewGuid();
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).Value = Entity.RecordTag;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).SetAsNull == true)
        Entity.RecordTag = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).Value = Entity.AuditXml;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).SetAsNull == true)
        Entity.AuditXml = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).Value = Entity.ColumnName;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).SetAsNull == true)
        Entity.ColumnName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).Value = Entity.OriginalValue;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).SetAsNull == true)
        Entity.OriginalValue = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).Value = Entity.NewValue;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).SetAsNull == true)
        Entity.NewValue = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue).Value = Entity.OriginalBinaryValue;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue).SetAsNull == true)
        Entity.OriginalBinaryValue = null;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue).Value = Entity.NewBinaryValue;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue).SetAsNull == true)
        Entity.NewBinaryValue = null;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName).SetAsNull == true)
        Entity.InsertName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
        Entity.InsertDate = DateTimeOffset.Now;
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
      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).IsNull == false)
        Entity.AuditId = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).GetAsGuid();
      else
        Entity.AuditId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.AuditId, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).IsNull == false)
        Entity.TransactionId = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).GetAsGuid();
      else
        Entity.TransactionId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.TransactionId, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).IsNull == false)
        Entity.TableName = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).GetAsString();
      else
        Entity.TableName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.TableName, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).IsNull == false)
        Entity.OperationType = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).GetAsString();
      else
        Entity.OperationType = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.OperationType, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).IsNull == false)
        Entity.PrimaryKeyColumn = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).GetAsString();
      else
        Entity.PrimaryKeyColumn = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).IsNull == false)
        Entity.PrimaryKeyValue = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).GetAsGuid();
      else
        Entity.PrimaryKeyValue = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).IsNull == false)
        Entity.RecordTag = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).GetAsString();
      else
        Entity.RecordTag = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.RecordTag, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).IsNull == false)
        Entity.AuditXml = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).GetAsString();
      else
        Entity.AuditXml = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.AuditXml, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).IsNull == false)
        Entity.ColumnName = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).GetAsString();
      else
        Entity.ColumnName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.ColumnName, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).IsNull == false)
        Entity.OriginalValue = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).GetAsString();
      else
        Entity.OriginalValue = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.OriginalValue, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).IsNull == false)
        Entity.NewValue = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).GetAsString();
      else
        Entity.NewValue = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.NewValue, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue).IsNull == false)
        Entity.OriginalBinaryValue = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue).GetAsByteArray();
      else
        Entity.OriginalBinaryValue = new byte[0];
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue).IsNull == false)
        Entity.NewBinaryValue = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue).GetAsByteArray();
      else
        Entity.NewBinaryValue = new byte[0];
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName).GetAsString();
      else
        Entity.InsertName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.InsertName, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName).Value);

      if (ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate).GetAsDate();
      else
        Entity.InsertDate = Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
      Entity.SetOriginalValueForProperty(gcsAuditPDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcsAuditPDSA</returns>
    public gcsAuditPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new gcsAuditPDSA();

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
            sb.Append("GCS.gcsAudit_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsAudit_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsAudit_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsAudit_SelectSearch");
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
            sb.Append("GCS.gcsAudit_Insert");
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
            sb.Append("GCS.gcsAudit_Update");
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
    /// <param name="auditId">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid auditId)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.AuditId = auditId;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(auditId);

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
            
          }
          
          break;
        case DeleteFilters.DeleteByPK:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsAudit_DeleteByPK");
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
            sb.Append("GCS.gcsAudit_RowCount");
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
    /// <param name="auditId">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid auditId)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.AuditId = auditId;      

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
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@AuditId", DbType.Guid, Entity.AuditId));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@TableName", DbType.String, Entity.TableName));
         
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
                  "@AuditId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).Value));
              
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
                  "@AuditId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@TransactionId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@TableName", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@OperationType", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PrimaryKeyColumn", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PrimaryKeyValue", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@RecordTag", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AuditXml", DbType.Xml, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ColumnName", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@OriginalValue", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NewValue", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@OriginalBinaryValue", DbType.Binary, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalBinaryValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NewBinaryValue", DbType.Binary, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewBinaryValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertName", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.InsertDate).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AuditId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@TransactionId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TransactionId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@TableName", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.TableName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@OperationType", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OperationType).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PrimaryKeyColumn", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyColumn).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PrimaryKeyValue", DbType.Guid, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.PrimaryKeyValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@RecordTag", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.RecordTag).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AuditXml", DbType.Xml, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.AuditXml).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ColumnName", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.ColumnName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@OriginalValue", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.OriginalValue).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@NewValue", DbType.String, ValidatorObject.Properties.GetByName(gcsAuditPDSAValidator.ColumnNames.NewValue).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
