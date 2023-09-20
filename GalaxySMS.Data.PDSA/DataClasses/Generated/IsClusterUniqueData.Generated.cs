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
  /// This class calls the stored procedure IsClusterUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsClusterUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsClusterUniquePDSAData class
    /// </summary>
    public IsClusterUniquePDSAData() : base()
    {
      Entity = new IsClusterUniquePDSA();
      ValidatorObject = new  IsClusterUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsClusterUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsClusterUniquePDSA</param>
    public IsClusterUniquePDSAData(IsClusterUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsClusterUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsClusterUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsClusterUniquePDSA</param>
    public IsClusterUniquePDSAData(PDSADataProvider dataProvider,
      IsClusterUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsClusterUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsClusterUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsClusterUniquePDSA</param>
    /// <param name="validator">An instance of a IsClusterUniquePDSAValidator</param>
    public IsClusterUniquePDSAData(PDSADataProvider dataProvider,
      IsClusterUniquePDSA entity, IsClusterUniquePDSAValidator validator)
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
    public IsClusterUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsClusterUniquePDSAData";
      StoredProcName = "IsClusterUnique";
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
      param.ParameterName = IsClusterUniquePDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterUniquePDSAValidator.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterUniquePDSAValidator.ParameterNames.ClusterName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsClusterUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsClusterUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterName).SetAsNull == false)
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterName).Value = Entity.ClusterName;
      else
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterName).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber).SetAsNull == false)
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      else
        AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.ClusterNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsClusterUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsClusterUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsClusterUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsClusterUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsClusterUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsClusterUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsClusterUniquePDSA</returns>
    public IsClusterUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsClusterUniquePDSA entity = new IsClusterUniquePDSA();

      if (dr.Table.Columns.Contains(IsClusterUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsClusterUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsClusterUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterUniquePDSA class.
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
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@ClusterName'
    /// </summary>
    public static string ClusterName = "@ClusterName";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
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
