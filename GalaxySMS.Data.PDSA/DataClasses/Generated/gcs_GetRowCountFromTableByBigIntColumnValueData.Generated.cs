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
  /// This class calls the stored procedure gcs_GetRowCountFromTableByBigIntColumnValuePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcs_GetRowCountFromTableByBigIntColumnValuePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByBigIntColumnValuePDSAData class
    /// </summary>
    public gcs_GetRowCountFromTableByBigIntColumnValuePDSAData() : base()
    {
      Entity = new gcs_GetRowCountFromTableByBigIntColumnValuePDSA();
      ValidatorObject = new  gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByBigIntColumnValuePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcs_GetRowCountFromTableByBigIntColumnValuePDSA</param>
    public gcs_GetRowCountFromTableByBigIntColumnValuePDSAData(gcs_GetRowCountFromTableByBigIntColumnValuePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByBigIntColumnValuePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_GetRowCountFromTableByBigIntColumnValuePDSA</param>
    public gcs_GetRowCountFromTableByBigIntColumnValuePDSAData(PDSADataProvider dataProvider,
      gcs_GetRowCountFromTableByBigIntColumnValuePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_GetRowCountFromTableByBigIntColumnValuePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_GetRowCountFromTableByBigIntColumnValuePDSA</param>
    /// <param name="validator">An instance of a gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator</param>
    public gcs_GetRowCountFromTableByBigIntColumnValuePDSAData(PDSADataProvider dataProvider,
      gcs_GetRowCountFromTableByBigIntColumnValuePDSA entity, gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator validator)
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
    public gcs_GetRowCountFromTableByBigIntColumnValuePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcs_GetRowCountFromTableByBigIntColumnValuePDSAData";
      StoredProcName = "gcs_GetRowCountFromTableByBigIntColumnValue";
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
      param.ParameterName = gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.SchemaName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.TableName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.ColumnName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.BigIntValue;
      param.DBType = DbType.Int64;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result, GetResourceMessage("dbo_gcs_GetRowCountFromTableByBigIntColumnValuePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.SchemaName).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.SchemaName).Value = Entity.SchemaName;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.SchemaName).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.TableName).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.TableName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.ColumnName).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.ColumnName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.BigIntValue).SetAsNull == false)
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.BigIntValue).Value = Entity.BigIntValue;
      else
        AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.BigIntValue).Value = System.Data.SqlTypes.SqlInt64.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcs_GetRowCountFromTableByBigIntColumnValuePDSA</returns>
    public gcs_GetRowCountFromTableByBigIntColumnValuePDSA CreateEntityFromDataRow(DataRow dr)
    {
      gcs_GetRowCountFromTableByBigIntColumnValuePDSA entity = new gcs_GetRowCountFromTableByBigIntColumnValuePDSA();

      if (dr.Table.Columns.Contains(gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result))
      {
        if (dr[gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[gcs_GetRowCountFromTableByBigIntColumnValuePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_GetRowCountFromTableByBigIntColumnValuePDSA class.
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
    /// Returns '@BigIntValue'
    /// </summary>
    public static string BigIntValue = "@BigIntValue";
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
