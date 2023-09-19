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
  /// This class calls the stored procedure OutputDevice_GetUserPermissionPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class OutputDevice_GetUserPermissionPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the OutputDevice_GetUserPermissionPDSAData class
    /// </summary>
    public OutputDevice_GetUserPermissionPDSAData() : base()
    {
      Entity = new OutputDevice_GetUserPermissionPDSA();
      ValidatorObject = new  OutputDevice_GetUserPermissionPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the OutputDevice_GetUserPermissionPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a OutputDevice_GetUserPermissionPDSA</param>
    public OutputDevice_GetUserPermissionPDSAData(OutputDevice_GetUserPermissionPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new OutputDevice_GetUserPermissionPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the OutputDevice_GetUserPermissionPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a OutputDevice_GetUserPermissionPDSA</param>
    public OutputDevice_GetUserPermissionPDSAData(PDSADataProvider dataProvider,
      OutputDevice_GetUserPermissionPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  OutputDevice_GetUserPermissionPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the OutputDevice_GetUserPermissionPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a OutputDevice_GetUserPermissionPDSA</param>
    /// <param name="validator">An instance of a OutputDevice_GetUserPermissionPDSAValidator</param>
    public OutputDevice_GetUserPermissionPDSAData(PDSADataProvider dataProvider,
      OutputDevice_GetUserPermissionPDSA entity, OutputDevice_GetUserPermissionPDSAValidator validator)
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
    public OutputDevice_GetUserPermissionPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "OutputDevice_GetUserPermissionPDSAData";
      StoredProcName = "OutputDevice_GetUserPermission";
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
      param.ParameterName = OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.OutputDeviceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_DisplayName_Header", "Display Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_EntityName_Header", "Entity Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_ApplicationName_Header", "Application Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_RoleName_Header", "Role Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_PermissionName_Header", "Permission Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_OutputName_Header", "Output Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId, GetResourceMessage("GCS_OutputDevice_GetUserPermissionPDSA_PermissionId_Header", "Permission Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId).SetAsNull == false)
        AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      else
        AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.UserId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.OutputDeviceUid).SetAsNull == false)
        AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      else
        AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.OutputDeviceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId).SetAsNull == false)
        AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId).Value = Entity.PermissionId;
      else
        AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.PermissionId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName).Value = Entity.DisplayName;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName).Value = Entity.ApplicationName;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName).Value = Entity.RoleName;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName).Value = Entity.PermissionName;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName).Value = Entity.OutputName;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId).Value = Entity.PermissionId;
      else
        AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName).IsNull == false)
        Entity.DisplayName = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName).GetAsString();
      else
        Entity.DisplayName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName).GetAsString();
      else
        Entity.EntityName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName).IsNull == false)
        Entity.ApplicationName = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName).GetAsString();
      else
        Entity.ApplicationName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName).IsNull == false)
        Entity.RoleName = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName).GetAsString();
      else
        Entity.RoleName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName).IsNull == false)
        Entity.PermissionName = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName).GetAsString();
      else
        Entity.PermissionName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid).GetAsGuid();
      else
        Entity.OutputDeviceUid = Guid.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName).IsNull == false)
        Entity.OutputName = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName).GetAsString();
      else
        Entity.OutputName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId).IsNull == false)
        Entity.PermissionId = AllColumns.GetByName(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId).GetAsGuid();
      else
        Entity.PermissionId = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>OutputDevice_GetUserPermissionPDSA</returns>
    public OutputDevice_GetUserPermissionPDSA CreateEntityFromDataRow(DataRow dr)
    {
      OutputDevice_GetUserPermissionPDSA entity = new OutputDevice_GetUserPermissionPDSA();

      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName] != DBNull.Value)
          entity.DisplayName = PDSAString.ConvertToStringTrim(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.DisplayName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName] != DBNull.Value)
          entity.EntityName = PDSAString.ConvertToStringTrim(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.EntityName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName] != DBNull.Value)
          entity.ApplicationName = PDSAString.ConvertToStringTrim(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.ApplicationName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName] != DBNull.Value)
          entity.RoleName = PDSAString.ConvertToStringTrim(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.RoleName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName] != DBNull.Value)
          entity.PermissionName = PDSAString.ConvertToStringTrim(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid] != DBNull.Value)
          entity.OutputDeviceUid = PDSAProperty.ConvertToGuid(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputDeviceUid]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName] != DBNull.Value)
          entity.OutputName = PDSAString.ConvertToStringTrim(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.OutputName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId))
      {
        if (dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId] != DBNull.Value)
          entity.PermissionId = PDSAProperty.ConvertToGuid(dr[OutputDevice_GetUserPermissionPDSAValidator.ColumnNames.PermissionId]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDevice_GetUserPermissionPDSA class.
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
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
    /// <summary>
    /// Returns '@PermissionId'
    /// </summary>
    public static string PermissionId = "@PermissionId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
