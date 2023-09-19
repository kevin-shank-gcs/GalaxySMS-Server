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
  /// This class calls the stored procedure IsTimeScheduleDayTypeTimePeriodUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsTimeScheduleDayTypeTimePeriodUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsTimeScheduleDayTypeTimePeriodUniquePDSAData class
    /// </summary>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSAData() : base()
    {
      Entity = new IsTimeScheduleDayTypeTimePeriodUniquePDSA();
      ValidatorObject = new  IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsTimeScheduleDayTypeTimePeriodUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsTimeScheduleDayTypeTimePeriodUniquePDSA</param>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSAData(IsTimeScheduleDayTypeTimePeriodUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsTimeScheduleDayTypeTimePeriodUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsTimeScheduleDayTypeTimePeriodUniquePDSA</param>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSAData(PDSADataProvider dataProvider,
      IsTimeScheduleDayTypeTimePeriodUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsTimeScheduleDayTypeTimePeriodUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsTimeScheduleDayTypeTimePeriodUniquePDSA</param>
    /// <param name="validator">An instance of a IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator</param>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSAData(PDSADataProvider dataProvider,
      IsTimeScheduleDayTypeTimePeriodUniquePDSA entity, IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator validator)
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
    public IsTimeScheduleDayTypeTimePeriodUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsTimeScheduleDayTypeTimePeriodUniquePDSAData";
      StoredProcName = "IsTimeScheduleDayTypeTimePeriodUnique";
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
      param.ParameterName = IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsTimeScheduleDayTypeTimePeriodUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid).SetAsNull == false)
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid).Value = Entity.TimeScheduleDayTypeTimePeriodUid;
      else
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleDayTypeTimePeriodUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).SetAsNull == false)
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      else
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).SetAsNull == false)
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).Value = Entity.DayTypeUid;
      else
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.DayTypeUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).SetAsNull == false)
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      else
        AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.TimePeriodUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsTimeScheduleDayTypeTimePeriodUniquePDSA</returns>
    public IsTimeScheduleDayTypeTimePeriodUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsTimeScheduleDayTypeTimePeriodUniquePDSA entity = new IsTimeScheduleDayTypeTimePeriodUniquePDSA();

      if (dr.Table.Columns.Contains(IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsTimeScheduleDayTypeTimePeriodUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleDayTypeTimePeriodUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeScheduleDayTypeTimePeriodUid'
    /// </summary>
    public static string TimeScheduleDayTypeTimePeriodUid = "@TimeScheduleDayTypeTimePeriodUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "@DayTypeUid";
    /// <summary>
    /// Returns '@TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "@TimePeriodUid";
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
