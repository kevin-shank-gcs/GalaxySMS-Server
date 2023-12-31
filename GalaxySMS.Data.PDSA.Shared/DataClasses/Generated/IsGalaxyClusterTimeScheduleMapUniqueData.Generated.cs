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
  /// This class calls the stored procedure IsGalaxyClusterTimeScheduleMapUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsGalaxyClusterTimeScheduleMapUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsGalaxyClusterTimeScheduleMapUniquePDSAData class
    /// </summary>
    public IsGalaxyClusterTimeScheduleMapUniquePDSAData() : base()
    {
      Entity = new IsGalaxyClusterTimeScheduleMapUniquePDSA();
      ValidatorObject = new  IsGalaxyClusterTimeScheduleMapUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsGalaxyClusterTimeScheduleMapUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsGalaxyClusterTimeScheduleMapUniquePDSA</param>
    public IsGalaxyClusterTimeScheduleMapUniquePDSAData(IsGalaxyClusterTimeScheduleMapUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsGalaxyClusterTimeScheduleMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyClusterTimeScheduleMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyClusterTimeScheduleMapUniquePDSA</param>
    public IsGalaxyClusterTimeScheduleMapUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyClusterTimeScheduleMapUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsGalaxyClusterTimeScheduleMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyClusterTimeScheduleMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyClusterTimeScheduleMapUniquePDSA</param>
    /// <param name="validator">An instance of a IsGalaxyClusterTimeScheduleMapUniquePDSAValidator</param>
    public IsGalaxyClusterTimeScheduleMapUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyClusterTimeScheduleMapUniquePDSA entity, IsGalaxyClusterTimeScheduleMapUniquePDSAValidator validator)
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
    public IsGalaxyClusterTimeScheduleMapUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsGalaxyClusterTimeScheduleMapUniquePDSAData";
      StoredProcName = "IsGalaxyClusterTimeScheduleMapUnique";
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
      param.ParameterName = IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsGalaxyClusterTimeScheduleMapUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid).Value = Entity.GalaxyClusterTimeScheduleMapUid;
      else
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimeScheduleMapUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      else
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber).Value = Entity.PanelScheduleNumber;
      else
        AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.PanelScheduleNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsGalaxyClusterTimeScheduleMapUniquePDSA</returns>
    public IsGalaxyClusterTimeScheduleMapUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsGalaxyClusterTimeScheduleMapUniquePDSA entity = new IsGalaxyClusterTimeScheduleMapUniquePDSA();

      if (dr.Table.Columns.Contains(IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsGalaxyClusterTimeScheduleMapUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterTimeScheduleMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyClusterTimeScheduleMapUid'
    /// </summary>
    public static string GalaxyClusterTimeScheduleMapUid = "@GalaxyClusterTimeScheduleMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "@PanelScheduleNumber";
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
