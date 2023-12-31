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
  /// This class calls the stored procedure IsOutputDeviceActivityEventUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsOutputDeviceActivityEventUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsOutputDeviceActivityEventUniquePDSAData class
    /// </summary>
    public IsOutputDeviceActivityEventUniquePDSAData() : base()
    {
      Entity = new IsOutputDeviceActivityEventUniquePDSA();
      ValidatorObject = new  IsOutputDeviceActivityEventUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsOutputDeviceActivityEventUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsOutputDeviceActivityEventUniquePDSA</param>
    public IsOutputDeviceActivityEventUniquePDSAData(IsOutputDeviceActivityEventUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsOutputDeviceActivityEventUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsOutputDeviceActivityEventUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsOutputDeviceActivityEventUniquePDSA</param>
    public IsOutputDeviceActivityEventUniquePDSAData(PDSADataProvider dataProvider,
      IsOutputDeviceActivityEventUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsOutputDeviceActivityEventUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsOutputDeviceActivityEventUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsOutputDeviceActivityEventUniquePDSA</param>
    /// <param name="validator">An instance of a IsOutputDeviceActivityEventUniquePDSAValidator</param>
    public IsOutputDeviceActivityEventUniquePDSAData(PDSADataProvider dataProvider,
      IsOutputDeviceActivityEventUniquePDSA entity, IsOutputDeviceActivityEventUniquePDSAValidator validator)
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
    public IsOutputDeviceActivityEventUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsOutputDeviceActivityEventUniquePDSAData";
      StoredProcName = "IsOutputDeviceActivityEventUnique";
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
      param.ParameterName = IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime;
      param.DBType = DbType.DateTimeOffset;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber).SetAsNull == false)
        AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      else
        AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime).SetAsNull == false)
        AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      else
        AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
      if (AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex).SetAsNull == false)
        AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      else
        AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsOutputDeviceActivityEventUniquePDSA</returns>
    public IsOutputDeviceActivityEventUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsOutputDeviceActivityEventUniquePDSA entity = new IsOutputDeviceActivityEventUniquePDSA();

      if (dr.Table.Columns.Contains(IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsOutputDeviceActivityEventUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceActivityEventUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "@ActivityDateTime";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
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
