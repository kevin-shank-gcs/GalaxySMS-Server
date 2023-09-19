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
  /// Used to Add/Edit/Delete/Select data from the gcsPermissionCategoryPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsPermissionCategoryPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsPermissionCategoryPDSAData class
    /// </summary>
    public gcsPermissionCategoryPDSAData() : base()
    {
      Entity = new gcsPermissionCategoryPDSA();
      ValidatorObject = new gcsPermissionCategoryPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsPermissionCategoryPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsPermissionCategoryPDSA</param>
    public gcsPermissionCategoryPDSAData(gcsPermissionCategoryPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new gcsPermissionCategoryPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsPermissionCategoryPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsPermissionCategoryPDSA</param>
    public gcsPermissionCategoryPDSAData(PDSADataProvider dataProvider,
      gcsPermissionCategoryPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new gcsPermissionCategoryPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsPermissionCategoryPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsPermissionCategoryPDSA</param>
    /// <param name="validator">An instance of a gcsPermissionCategoryPDSAValidator</param>
    public gcsPermissionCategoryPDSAData(PDSADataProvider dataProvider,
      gcsPermissionCategoryPDSA entity, gcsPermissionCategoryPDSAValidator validator)
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
      /// 'ByApplicationId' SelectFilter
      /// </summary>
      ByApplicationId
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
    private gcsPermissionCategoryPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public gcsPermissionCategoryPDSA Entity 
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
      ClassName = "gcsPermissionCategoryPDSAData";
      DBObjectName = "GCS.gcsPermissionCategory";
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
      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBoolean.Null;
      //prop.ValueForNull = false;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBoolean.Null;
      //prop.ValueForNull = false;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = null;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlString.Null;
      //prop.ValueForNull = string.Empty;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = null;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.Code);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
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
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).Value = Entity.PermissionCategoryId;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).SetAsNull == true)
        Entity.PermissionCategoryId = Guid.Empty;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).Value = Entity.ApplicationId;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).SetAsNull == true)
        Entity.ApplicationId = Guid.Empty;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).Value = Entity.CategoryName;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).SetAsNull == true)
        Entity.CategoryName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).Value = Entity.PermissionCategoryDescription;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).SetAsNull == true)
        Entity.PermissionCategoryDescription = string.Empty;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).Value = Entity.IsSystemCategory;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).SetAsNull == true)
        Entity.IsSystemCategory = false;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).Value = Entity.IsEntityCategory;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).SetAsNull == true)
        Entity.IsEntityCategory = false;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName).SetAsNull == true)
        Entity.InsertName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
        Entity.InsertDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).SetAsNull == true)
        Entity.UpdateName = string.Empty;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).SetAsNull == true)
        Entity.UpdateDate = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull == true)
        Entity.ConcurrencyValue = 0;
      ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.Code).Value = Entity.Code;
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.Code).SetAsNull == true)
        Entity.Code = string.Empty;
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
      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).IsNull == false)
        Entity.PermissionCategoryId = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).GetAsGuid();
      else
        Entity.PermissionCategoryId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).IsNull == false)
        Entity.ApplicationId = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).GetAsGuid();
      else
        Entity.ApplicationId = Guid.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).IsNull == false)
        Entity.CategoryName = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).GetAsString();
      else
        Entity.CategoryName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).IsNull == false)
        Entity.PermissionCategoryDescription = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).GetAsString();
      else
        Entity.PermissionCategoryDescription = string.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).IsNull == false)
        Entity.IsSystemCategory = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).GetAsBool();
      else
        Entity.IsSystemCategory = false;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).IsNull == false)
        Entity.IsEntityCategory = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).GetAsBool();
      else
        Entity.IsEntityCategory = false;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName).GetAsString();
      else
        Entity.InsertName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      else
        Entity.InsertDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).GetAsString();
      else
        Entity.UpdateName = string.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      else
        Entity.UpdateDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      else
        Entity.ConcurrencyValue = 0;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).Value);

      if (ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.Code).IsNull == false)
        Entity.Code = ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.Code).GetAsString();
      else
        Entity.Code = string.Empty;
      Entity.SetOriginalValueForProperty(gcsPermissionCategoryPDSAValidator.ColumnNames.Code, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.Code).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcsPermissionCategoryPDSA</returns>
    public gcsPermissionCategoryPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new gcsPermissionCategoryPDSA();

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
            sb.Append("GCS.gcsPermissionCategoryPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsPermissionCategoryPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsPermissionCategoryPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsPermissionCategoryPDSA_SelectSearch");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByApplicationId:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsPermissionCategoryPDSA_ByApplicationId");
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
            sb.Append("GCS.gcsPermissionCategoryPDSA_Insert");
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
            sb.Append("GCS.gcsPermissionCategoryPDSA_Update");
          }
          else
          {
            
          }
          
          break;
        case UpdateFilters.UpdateConcurrency:
          if (UseStoredProcs)
          {
            sb.Append("GCS.gcsPermissionCategoryPDSA_UpdateConcurrency");
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
    /// <param name="permissionCategoryId">The value of the primary key of the row to delete</param>
    /// <returns>int</returns>
    public int DeleteByPK(Guid permissionCategoryId)
    {
      DeleteFilter = DeleteFilters.DeleteByPK;
      Entity.PermissionCategoryId = permissionCategoryId;      
      
      // If using Audit Tracking, need to load the record first
      if (UseAuditTracking)
        LoadByPK(permissionCategoryId);

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
            sb.Append("GCS.gcsPermissionCategoryPDSA_DeleteByPK");
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
            sb.Append("GCS.gcsPermissionCategoryPDSA_RowCount");
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
    /// <param name="permissionCategoryId">The value of the primary key of the row to load</param>
    /// <returns>Int32</returns>
    public int LoadByPK(Guid permissionCategoryId)
    {
      SelectFilter = SelectFilters.PrimaryKey;
      Entity.PermissionCategoryId = permissionCategoryId;      

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
        case SelectFilters.ListBox:
         
          break;
        case SelectFilters.PrimaryKey:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@PermissionCategoryId", DbType.Guid, Entity.PermissionCategoryId));
         
          break;
        case SelectFilters.Search:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CategoryName", DbType.String, Entity.CategoryName));
         
          break;
        case SelectFilters.ByApplicationId:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@ApplicationId", DbType.Guid, Entity.ApplicationId));
         
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
                  "@PermissionCategoryId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
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
                  "@PermissionCategoryId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ApplicationId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CategoryName", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PermissionCategoryDescription", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@IsSystemCategory", DbType.Boolean, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@IsEntityCategory", DbType.Boolean, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertName", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.InsertDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PermissionCategoryId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ApplicationId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ApplicationId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CategoryName", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.CategoryName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PermissionCategoryDescription", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryDescription).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@IsSystemCategory", DbType.Boolean, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsSystemCategory).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@IsEntityCategory", DbType.Boolean, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.IsEntityCategory).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateName", DbType.String, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateName).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@UpdateDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.UpdateDate).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
            case UpdateFilters.UpdateConcurrency:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PermissionCategoryId", DbType.Guid, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.PermissionCategoryId).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ConcurrencyValue", DbType.Int16, ValidatorObject.Properties.GetByName(gcsPermissionCategoryPDSAValidator.ColumnNames.ConcurrencyValue).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
