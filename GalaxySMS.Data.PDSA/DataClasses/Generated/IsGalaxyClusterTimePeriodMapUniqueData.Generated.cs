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
  /// This class calls the stored procedure IsGalaxyClusterTimePeriodMapUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsGalaxyClusterTimePeriodMapUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsGalaxyClusterTimePeriodMapUniquePDSAData class
    /// </summary>
    public IsGalaxyClusterTimePeriodMapUniquePDSAData() : base()
    {
      Entity = new IsGalaxyClusterTimePeriodMapUniquePDSA();
      ValidatorObject = new  IsGalaxyClusterTimePeriodMapUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsGalaxyClusterTimePeriodMapUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsGalaxyClusterTimePeriodMapUniquePDSA</param>
    public IsGalaxyClusterTimePeriodMapUniquePDSAData(IsGalaxyClusterTimePeriodMapUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsGalaxyClusterTimePeriodMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyClusterTimePeriodMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyClusterTimePeriodMapUniquePDSA</param>
    public IsGalaxyClusterTimePeriodMapUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyClusterTimePeriodMapUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsGalaxyClusterTimePeriodMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyClusterTimePeriodMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyClusterTimePeriodMapUniquePDSA</param>
    /// <param name="validator">An instance of a IsGalaxyClusterTimePeriodMapUniquePDSAValidator</param>
    public IsGalaxyClusterTimePeriodMapUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyClusterTimePeriodMapUniquePDSA entity, IsGalaxyClusterTimePeriodMapUniquePDSAValidator validator)
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
    public IsGalaxyClusterTimePeriodMapUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsGalaxyClusterTimePeriodMapUniquePDSAData";
      StoredProcName = "IsGalaxyClusterTimePeriodMapUnique";
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
      param.ParameterName = IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsGalaxyClusterTimePeriodMapUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid).Value = Entity.GalaxyClusterTimePeriodMapUid;
      else
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.GalaxyClusterTimePeriodMapUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      else
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber).Value = Entity.PanelPeriodNumber;
      else
        AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.PanelPeriodNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsGalaxyClusterTimePeriodMapUniquePDSA</returns>
    public IsGalaxyClusterTimePeriodMapUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsGalaxyClusterTimePeriodMapUniquePDSA entity = new IsGalaxyClusterTimePeriodMapUniquePDSA();

      if (dr.Table.Columns.Contains(IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsGalaxyClusterTimePeriodMapUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyClusterTimePeriodMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyClusterTimePeriodMapUid'
    /// </summary>
    public static string GalaxyClusterTimePeriodMapUid = "@GalaxyClusterTimePeriodMapUid";
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PanelPeriodNumber'
    /// </summary>
    public static string PanelPeriodNumber = "@PanelPeriodNumber";
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
