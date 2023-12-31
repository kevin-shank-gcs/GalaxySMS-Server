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
  /// This class calls the stored procedure IsAssaDsrTimeScheduleMapUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsAssaDsrTimeScheduleMapUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsAssaDsrTimeScheduleMapUniquePDSAData class
    /// </summary>
    public IsAssaDsrTimeScheduleMapUniquePDSAData() : base()
    {
      Entity = new IsAssaDsrTimeScheduleMapUniquePDSA();
      ValidatorObject = new  IsAssaDsrTimeScheduleMapUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsAssaDsrTimeScheduleMapUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsAssaDsrTimeScheduleMapUniquePDSA</param>
    public IsAssaDsrTimeScheduleMapUniquePDSAData(IsAssaDsrTimeScheduleMapUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsAssaDsrTimeScheduleMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAssaDsrTimeScheduleMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAssaDsrTimeScheduleMapUniquePDSA</param>
    public IsAssaDsrTimeScheduleMapUniquePDSAData(PDSADataProvider dataProvider,
      IsAssaDsrTimeScheduleMapUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsAssaDsrTimeScheduleMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAssaDsrTimeScheduleMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAssaDsrTimeScheduleMapUniquePDSA</param>
    /// <param name="validator">An instance of a IsAssaDsrTimeScheduleMapUniquePDSAValidator</param>
    public IsAssaDsrTimeScheduleMapUniquePDSAData(PDSADataProvider dataProvider,
      IsAssaDsrTimeScheduleMapUniquePDSA entity, IsAssaDsrTimeScheduleMapUniquePDSAValidator validator)
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
    public IsAssaDsrTimeScheduleMapUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsAssaDsrTimeScheduleMapUniquePDSAData";
      StoredProcName = "IsAssaDsrTimeScheduleMapUnique";
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
      param.ParameterName = IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid).SetAsNull == false)
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid).Value = Entity.AssaDsrTimeScheduleMapUid;
      else
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).SetAsNull == false)
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      else
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid).SetAsNull == false)
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      else
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId).SetAsNull == false)
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId).Value = Entity.AssaDsrScheduleId;
      else
        AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsAssaDsrTimeScheduleMapUniquePDSA</returns>
    public IsAssaDsrTimeScheduleMapUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsAssaDsrTimeScheduleMapUniquePDSA entity = new IsAssaDsrTimeScheduleMapUniquePDSA();

      if (dr.Table.Columns.Contains(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsAssaDsrTimeScheduleMapUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDsrTimeScheduleMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaDsrTimeScheduleMapUid'
    /// </summary>
    public static string AssaDsrTimeScheduleMapUid = "@AssaDsrTimeScheduleMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
    /// <summary>
    /// Returns '@AssaDsrScheduleId'
    /// </summary>
    public static string AssaDsrScheduleId = "@AssaDsrScheduleId";
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
