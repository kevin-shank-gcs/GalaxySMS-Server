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
  /// Used to Add/Edit/Delete/Select data from the AccessPortalActivityEventPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalActivityEventPDSAData : PDSADataClassTable
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessPortalActivityEventPDSAData class
    /// </summary>
    public AccessPortalActivityEventPDSAData() : base()
    {
      Entity = new AccessPortalActivityEventPDSA();
      ValidatorObject = new AccessPortalActivityEventPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AccessPortalActivityEventPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AccessPortalActivityEventPDSA</param>
    public AccessPortalActivityEventPDSAData(AccessPortalActivityEventPDSA entity) : base(entity)
    {
      Entity = entity;
      ValidatorObject = new AccessPortalActivityEventPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessPortalActivityEventPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessPortalActivityEventPDSA</param>
    public AccessPortalActivityEventPDSAData(PDSADataProvider dataProvider,
      AccessPortalActivityEventPDSA entity)
      : base(dataProvider, entity)
    {
      Entity = entity;
      ValidatorObject = new AccessPortalActivityEventPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessPortalActivityEventPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessPortalActivityEventPDSA</param>
    /// <param name="validator">An instance of a AccessPortalActivityEventPDSAValidator</param>
    public AccessPortalActivityEventPDSAData(PDSADataProvider dataProvider,
      AccessPortalActivityEventPDSA entity, AccessPortalActivityEventPDSAValidator validator)
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
      /// 'ByCpuUid' SelectFilter
      /// </summary>
      ByCpuUid
      ,
      /// <summary>
      /// 'ByCredentialUid' SelectFilter
      /// </summary>
      ByCredentialUid
      ,
      /// <summary>
      /// 'ByGalaxyActivityEventTypeUid' SelectFilter
      /// </summary>
      ByGalaxyActivityEventTypeUid
      ,
      /// <summary>
      /// 'ByPersonUid' SelectFilter
      /// </summary>
      ByPersonUid
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
    private AccessPortalActivityEventPDSA _EntityObject = null;

    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public AccessPortalActivityEventPDSA Entity 
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
      ClassName = "AccessPortalActivityEventPDSAData";
      DBObjectName = "GCS.AccessPortalActivityEvent";
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
      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = true;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlGuid.Null;
      //prop.ValueForNull = Guid.Empty;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt16.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlDateTime.Null;
      //prop.ValueForNull = DateTimeOffset.MinValue;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex);
      prop.IsInsertable = true;
      prop.IsUpdatable = true;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = true;
      prop.DBValueForNull = System.Data.SqlTypes.SqlInt32.Null;
      //prop.ValueForNull = 0;

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes);
      prop.IsInsertable = false;
      prop.IsUpdatable = false;
      prop.IsPrimaryKey = false;
      prop.IncludeInAuditTracking = false;
      prop.DBValueForNull = System.Data.SqlTypes.SqlBinary.Null;
      //prop.ValueForNull = new byte[0];

      prop = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate);
      prop.IsInsertable = true;
      prop.IsUpdatable = false;
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
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value = Entity.AccessPortalActivityEventUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).SetAsNull == true)
        Entity.AccessPortalActivityEventUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).SetAsNull == true)
        Entity.GalaxyActivityEventTypeUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull == true)
        Entity.AccessPortalUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).SetAsNull == true)
        Entity.CredentialUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).SetAsNull == true)
        Entity.PersonUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).SetAsNull == true)
        Entity.CpuUid = Guid.Empty;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).Value = Entity.CpuNumber;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).SetAsNull == true)
        Entity.CpuNumber = 0;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).SetAsNull == true)
        Entity.ActivityDateTime = DateTimeOffset.Now;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).Value = Entity.BufferIndex;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).SetAsNull == true)
        Entity.BufferIndex = 0;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).Value = Entity.CredentialBytes;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).SetAsNull == true)
        Entity.CredentialBytes = null;
      ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).SetAsNull == true)
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
      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).IsNull == false)
        Entity.AccessPortalActivityEventUid = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).GetAsGuid();
      else
        Entity.AccessPortalActivityEventUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).GetAsGuid();
      else
        Entity.GalaxyActivityEventTypeUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      else
        Entity.AccessPortalUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      else
        Entity.CredentialUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      else
        Entity.PersonUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      else
        Entity.CpuUid = Guid.Empty;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).GetAsShort();
      else
        Entity.CpuNumber = 0;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).GetAsDateTimeOffset();
      else
        Entity.ActivityDateTime = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).GetAsInteger();
      else
        Entity.BufferIndex = 0;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).IsNull == false)
        Entity.CredentialBytes = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).GetAsByteArray();
      else
        Entity.CredentialBytes = new byte[0];
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).Value);

      if (ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      else
        Entity.InsertDate = DateTimeOffset.MinValue;
      Entity.SetOriginalValueForProperty(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).Value);

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AccessPortalActivityEventPDSA</returns>
    public AccessPortalActivityEventPDSA CreateEntityFromDataRow(DataRow dr)
    {
      // Create new Entity Object
      Entity = new AccessPortalActivityEventPDSA();

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
            sb.Append("GCS.AccessPortalActivityEventPDSA_SelectAll");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByAccessPortalUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_ByAccessPortalUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByCpuUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_ByCpuUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByCredentialUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_ByCredentialUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByGalaxyActivityEventTypeUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_ByGalaxyActivityEventTypeUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ByPersonUid:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_ByPersonUid");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.ListBox:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_SelectListBox");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.PrimaryKey:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_SelectByPK");
          }
          else
          {
            
          }
          
          break;
        case SelectFilters.Search:
          if (UseStoredProcs)
          {
            sb.Append("GCS.AccessPortalActivityEventPDSA_SelectSearch");
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
            sb.Append("GCS.AccessPortalActivityEventPDSA_Insert");
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
            sb.Append("GCS.AccessPortalActivityEventPDSA_Update");
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
            sb.Append("GCS.AccessPortalActivityEventPDSA_DeleteByPK");
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
            sb.Append("GCS.AccessPortalActivityEventPDSA_RowCount");
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
        case SelectFilters.ByCpuUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CpuUid", DbType.Guid, Entity.CpuUid));
         
          break;
        case SelectFilters.ByCredentialUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@CredentialUid", DbType.Guid, Entity.CredentialUid));
         
          break;
        case SelectFilters.ByGalaxyActivityEventTypeUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@GalaxyActivityEventTypeUid", DbType.Guid, Entity.GalaxyActivityEventTypeUid));
         
          break;
        case SelectFilters.ByPersonUid:
          CommandObject.Parameters.Add(DataProvider.CreateParameter("@PersonUid", DbType.Guid, Entity.PersonUid));
         
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
                  "@AccessPortalActivityEventUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value));
              
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
                  "@AccessPortalActivityEventUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@GalaxyActivityEventTypeUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PersonUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuNumber", DbType.Int16, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ActivityDateTime", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@BufferIndex", DbType.Int32, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialBytes", DbType.Binary, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@InsertDate", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).Value));
              
              break;
          }

          break;

        case PDSADataModificationState.Update:
          switch (UpdateFilter)
          {
            case UpdateFilters.PrimaryKey:
             CommandObject.Parameters.Clear();
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalActivityEventUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@GalaxyActivityEventTypeUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@AccessPortalUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@PersonUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuUid", DbType.Guid, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CpuNumber", DbType.Int16, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@ActivityDateTime", DbType.DateTimeOffset, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@BufferIndex", DbType.Int32, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).Value));
              CommandObject.Parameters.Add(DataProvider.CreateParameter( 
                  "@CredentialBytes", DbType.Binary, ValidatorObject.Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).Value));
              
              break;
          }
          break;
      }
    }
    #endregion
  }
}
