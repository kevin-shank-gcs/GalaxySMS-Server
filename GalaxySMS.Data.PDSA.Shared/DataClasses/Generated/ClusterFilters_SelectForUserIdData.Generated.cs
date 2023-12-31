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
  /// This class calls the stored procedure ClusterFilters_SelectForUserIdPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class ClusterFilters_SelectForUserIdPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the ClusterFilters_SelectForUserIdPDSAData class
    /// </summary>
    public ClusterFilters_SelectForUserIdPDSAData() : base()
    {
      Entity = new ClusterFilters_SelectForUserIdPDSA();
      ValidatorObject = new  ClusterFilters_SelectForUserIdPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the ClusterFilters_SelectForUserIdPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a ClusterFilters_SelectForUserIdPDSA</param>
    public ClusterFilters_SelectForUserIdPDSAData(ClusterFilters_SelectForUserIdPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new ClusterFilters_SelectForUserIdPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the ClusterFilters_SelectForUserIdPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a ClusterFilters_SelectForUserIdPDSA</param>
    public ClusterFilters_SelectForUserIdPDSAData(PDSADataProvider dataProvider,
      ClusterFilters_SelectForUserIdPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  ClusterFilters_SelectForUserIdPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the ClusterFilters_SelectForUserIdPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a ClusterFilters_SelectForUserIdPDSA</param>
    /// <param name="validator">An instance of a ClusterFilters_SelectForUserIdPDSAValidator</param>
    public ClusterFilters_SelectForUserIdPDSAData(PDSADataProvider dataProvider,
      ClusterFilters_SelectForUserIdPDSA entity, ClusterFilters_SelectForUserIdPDSAValidator validator)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = validator;

      Init();
    }
    #endregion

    #region Public Property
    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public ClusterFilters_SelectForUserIdPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "ClusterFilters_SelectForUserIdPDSAData";
      StoredProcName = "ClusterFilters_SelectForUserId";
      SchemaName = "GCS";

      // Create Parameters
      InitParameters();

      // Create Data Columns
      InitDataColumns();
    }
    #endregion

   #region InitParameters Method
    /// <summary>
    /// Creates all the parameters for the stored procedure.
    /// </summary>
    protected override void InitParameters()
    {
      PDSADataParameter param;

      // Clear all parameters each time
      AllParameters.Clear();

      // Create each parameter object and add to Parameters Collection
      param = new PDSADataParameter();
      param.ParameterName = ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.UserId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.ReturnValue;
      param.IsRefCursor = false;
      AllParameters.Add(param);

  
      AddReturnValueParameterToCollection();
    }
    #endregion

    #region InitDataColumns Method
    /// <summary>
    /// Initializes the Data Columns Collection for each field returned from the stored procedure.
    /// </summary>
    protected override void InitDataColumns()
    {
      PDSADataColumn dc;

      // Create each data column
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_DisplayName_Header", "Display Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_EntityName_Header", "Entity Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_ApplicationName_Header", "Application Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_RoleName_Header", "Role Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_PermissionName_Header", "Permission Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId, GetResourceMessage("GCS_ClusterFilters_SelectForUserIdPDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.UserId).SetAsNull == false)
        AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      else
        AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.UserId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName).Value = Entity.DisplayName;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName).Value = string.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName).Value = string.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName).Value = Entity.ApplicationName;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName).Value = string.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName).Value = Entity.RoleName;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName).Value = string.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName).Value = Entity.PermissionName;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName).Value = string.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName).Value = string.Empty;
     
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId).SetAsNull == false)
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId).Value = Entity.PermissionId;
      else
        AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
    }
    #endregion
    
    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName).IsNull == false)
        Entity.DisplayName = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName).GetAsString();
      else
        Entity.DisplayName = string.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName).GetAsString();
      else
        Entity.EntityName = string.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName).IsNull == false)
        Entity.ApplicationName = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName).GetAsString();
      else
        Entity.ApplicationName = string.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName).IsNull == false)
        Entity.RoleName = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName).GetAsString();
      else
        Entity.RoleName = string.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName).IsNull == false)
        Entity.PermissionName = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName).GetAsString();
      else
        Entity.PermissionName = string.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName).GetAsString();
      else
        Entity.ClusterName = string.Empty;

      if (AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId).IsNull == false)
        Entity.PermissionId = AllColumns.GetByName(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId).GetAsGuid();
      else
        Entity.PermissionId = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>ClusterFilters_SelectForUserIdPDSA</returns>
    public ClusterFilters_SelectForUserIdPDSA CreateEntityFromDataRow(DataRow dr)
    {
      ClusterFilters_SelectForUserIdPDSA entity = new ClusterFilters_SelectForUserIdPDSA();

      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName] != DBNull.Value)
          entity.DisplayName = PDSAString.ConvertToStringTrim(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.DisplayName]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName] != DBNull.Value)
          entity.EntityName = PDSAString.ConvertToStringTrim(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.EntityName]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName] != DBNull.Value)
          entity.ApplicationName = PDSAString.ConvertToStringTrim(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ApplicationName]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName] != DBNull.Value)
          entity.RoleName = PDSAString.ConvertToStringTrim(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.RoleName]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName] != DBNull.Value)
          entity.PermissionName = PDSAString.ConvertToStringTrim(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionName]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterUid]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName] != DBNull.Value)
          entity.ClusterName = PDSAString.ConvertToStringTrim(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.ClusterName]);
      }
      if (dr.Table.Columns.Contains(ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId))
      {
        if (dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId] != DBNull.Value)
          entity.PermissionId = PDSAProperty.ConvertToGuid(dr[ClusterFilters_SelectForUserIdPDSAValidator.ColumnNames.PermissionId]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterFilters_SelectForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
