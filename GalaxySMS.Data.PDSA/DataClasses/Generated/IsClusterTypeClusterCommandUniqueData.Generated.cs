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
  /// This class calls the stored procedure IsClusterTypeClusterCommandUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsClusterTypeClusterCommandUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsClusterTypeClusterCommandUniquePDSAData class
    /// </summary>
    public IsClusterTypeClusterCommandUniquePDSAData() : base()
    {
      Entity = new IsClusterTypeClusterCommandUniquePDSA();
      ValidatorObject = new  IsClusterTypeClusterCommandUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsClusterTypeClusterCommandUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsClusterTypeClusterCommandUniquePDSA</param>
    public IsClusterTypeClusterCommandUniquePDSAData(IsClusterTypeClusterCommandUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsClusterTypeClusterCommandUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsClusterTypeClusterCommandUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsClusterTypeClusterCommandUniquePDSA</param>
    public IsClusterTypeClusterCommandUniquePDSAData(PDSADataProvider dataProvider,
      IsClusterTypeClusterCommandUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsClusterTypeClusterCommandUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsClusterTypeClusterCommandUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsClusterTypeClusterCommandUniquePDSA</param>
    /// <param name="validator">An instance of a IsClusterTypeClusterCommandUniquePDSAValidator</param>
    public IsClusterTypeClusterCommandUniquePDSAData(PDSADataProvider dataProvider,
      IsClusterTypeClusterCommandUniquePDSA entity, IsClusterTypeClusterCommandUniquePDSAValidator validator)
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
    public IsClusterTypeClusterCommandUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsClusterTypeClusterCommandUniquePDSAData";
      StoredProcName = "IsClusterTypeClusterCommandUnique";
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
      param.ParameterName = IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsClusterTypeClusterCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid).SetAsNull == false)
        AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid).Value = Entity.ClusterTypeClusterCommandUid;
      else
        AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeClusterCommandUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid).SetAsNull == false)
        AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid).Value = Entity.ClusterCommandUid;
      else
        AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterCommandUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid).SetAsNull == false)
        AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid).Value = Entity.ClusterTypeUid;
      else
        AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.ClusterTypeUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsClusterTypeClusterCommandUniquePDSA</returns>
    public IsClusterTypeClusterCommandUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsClusterTypeClusterCommandUniquePDSA entity = new IsClusterTypeClusterCommandUniquePDSA();

      if (dr.Table.Columns.Contains(IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsClusterTypeClusterCommandUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsClusterTypeClusterCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterTypeClusterCommandUid'
    /// </summary>
    public static string ClusterTypeClusterCommandUid = "@ClusterTypeClusterCommandUid";
    /// <summary>
    /// Returns '@ClusterCommandUid'
    /// </summary>
    public static string ClusterCommandUid = "@ClusterCommandUid";
    /// <summary>
    /// Returns '@ClusterTypeUid'
    /// </summary>
    public static string ClusterTypeUid = "@ClusterTypeUid";
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
