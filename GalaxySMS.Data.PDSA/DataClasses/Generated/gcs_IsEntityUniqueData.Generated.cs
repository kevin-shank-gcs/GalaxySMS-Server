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
  /// This class calls the stored procedure gcs_IsEntityUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcs_IsEntityUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcs_IsEntityUniquePDSAData class
    /// </summary>
    public gcs_IsEntityUniquePDSAData() : base()
    {
      Entity = new gcs_IsEntityUniquePDSA();
      ValidatorObject = new  gcs_IsEntityUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcs_IsEntityUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcs_IsEntityUniquePDSA</param>
    public gcs_IsEntityUniquePDSAData(gcs_IsEntityUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcs_IsEntityUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsEntityUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsEntityUniquePDSA</param>
    public gcs_IsEntityUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsEntityUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcs_IsEntityUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsEntityUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsEntityUniquePDSA</param>
    /// <param name="validator">An instance of a gcs_IsEntityUniquePDSAValidator</param>
    public gcs_IsEntityUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsEntityUniquePDSA entity, gcs_IsEntityUniquePDSAValidator validator)
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
    public gcs_IsEntityUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcs_IsEntityUniquePDSAData";
      StoredProcName = "gcs_IsEntityUnique";
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
      param.ParameterName = gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsEntityUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_gcs_IsEntityUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId).SetAsNull == false)
        AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId).Value = Entity.ParentEntityId;
      else
        AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.ParentEntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName).SetAsNull == false)
        AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName).Value = Entity.EntityName;
      else
        AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.EntityName).Value = System.Data.SqlTypes.SqlString.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(gcs_IsEntityUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcs_IsEntityUniquePDSA</returns>
    public gcs_IsEntityUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      gcs_IsEntityUniquePDSA entity = new gcs_IsEntityUniquePDSA();

      if (dr.Table.Columns.Contains(gcs_IsEntityUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[gcs_IsEntityUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[gcs_IsEntityUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsEntityUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ParentEntityId'
    /// </summary>
    public static string ParentEntityId = "@ParentEntityId";
    /// <summary>
    /// Returns '@EntityName'
    /// </summary>
    public static string EntityName = "@EntityName";
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
