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
  /// This class calls the stored procedure gcs_GetRowCountFromTableByNVarCharColumnValuePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData class
    /// </summary>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData() : base()
    {
      Entity = new gcs_GetRowCountFromTableByNVarCharColumnValuePDSA();
      ValidatorObject = new  gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcs_GetRowCountFromTableByNVarCharColumnValuePDSA</param>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData(gcs_GetRowCountFromTableByNVarCharColumnValuePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_GetRowCountFromTableByNVarCharColumnValuePDSA</param>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData(PDSADataProvider dataProvider,
      gcs_GetRowCountFromTableByNVarCharColumnValuePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_GetRowCountFromTableByNVarCharColumnValuePDSA</param>
    /// <param name="validator">An instance of a gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator</param>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData(PDSADataProvider dataProvider,
      gcs_GetRowCountFromTableByNVarCharColumnValuePDSA entity, gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator validator)
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
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcs_GetRowCountFromTableByNVarCharColumnValuePDSAData";
      StoredProcName = "gcs_GetRowCountFromTableByNVarCharColumnValue";
      SchemaName = "dbo";

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
      param.ParameterName = gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result, GetResourceMessage("dbo_gcs_GetRowCountFromTableByNVarCharColumnValuePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.SchemaName).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.TableName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.ColumnName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value).Value = Entity.Value;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Value).Value = System.Data.SqlTypes.SqlString.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ParameterNames.Result).GetAsInteger();
      else
        Entity.Result = 0;
    }
    #endregion
    
    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcs_GetRowCountFromTableByNVarCharColumnValuePDSA</returns>
    public gcs_GetRowCountFromTableByNVarCharColumnValuePDSA CreateEntityFromDataRow(DataRow dr)
    {
      gcs_GetRowCountFromTableByNVarCharColumnValuePDSA entity = new gcs_GetRowCountFromTableByNVarCharColumnValuePDSA();

      if (dr.Table.Columns.Contains(gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result))
      {
        if (dr[gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[gcs_GetRowCountFromTableByNVarCharColumnValuePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_GetRowCountFromTableByNVarCharColumnValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@SchemaName'
    /// </summary>
    public static string SchemaName = "@SchemaName";
    /// <summary>
    /// Returns '@TableName'
    /// </summary>
    public static string TableName = "@TableName";
    /// <summary>
    /// Returns '@ColumnName'
    /// </summary>
    public static string ColumnName = "@ColumnName";
    /// <summary>
    /// Returns '@Value'
    /// </summary>
    public static string Value = "@Value";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
