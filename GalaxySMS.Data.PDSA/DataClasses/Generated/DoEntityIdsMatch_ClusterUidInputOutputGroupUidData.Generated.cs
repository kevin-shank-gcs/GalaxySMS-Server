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
  /// This class calls the stored procedure DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData class
    /// </summary>
    public DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData() : base()
    {
      Entity = new DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA();
      ValidatorObject = new  DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA</param>
    public DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA</param>
    public DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData(PDSADataProvider dataProvider,
      DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA</param>
    /// <param name="validator">An instance of a DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator</param>
    public DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData(PDSADataProvider dataProvider,
      DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA entity, DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator validator)
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
    public DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAData";
      StoredProcName = "DoEntityIdsMatch_ClusterUidInputOutputGroupUid";
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
      param.ParameterName = DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.InputOutputGroupUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.PreventSystemEntityMatches;
      param.DBType = DbType.Boolean;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Boolean;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA_Result_Header", "Result"), false, typeof(bool), DbType.Boolean);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.InputOutputGroupUid).SetAsNull == false)
        AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      else
        AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.InputOutputGroupUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.PreventSystemEntityMatches).SetAsNull == false)
        AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.PreventSystemEntityMatches).Value = Entity.PreventSystemEntityMatches;
      else
        AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.PreventSystemEntityMatches).Value = System.Data.SqlTypes.SqlBoolean.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result).Value = false;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ParameterNames.Result).GetAsBool();
      else
        Entity.Result = false;
    }
    #endregion
    
    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result).GetAsBool();
      else
        Entity.Result = false;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA</returns>
    public DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA entity = new DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA();

      if (dr.Table.Columns.Contains(DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result))
      {
        if (dr[DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToBoolean(dr[DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DoEntityIdsMatch_ClusterUidInputOutputGroupUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "@InputOutputGroupUid";
    /// <summary>
    /// Returns '@PreventSystemEntityMatches'
    /// </summary>
    public static string PreventSystemEntityMatches = "@PreventSystemEntityMatches";
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
