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
  /// This class calls the stored procedure InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData class
    /// </summary>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData() : base()
    {
      Entity = new InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA();
      ValidatorObject = new  InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA</param>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA</param>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData(PDSADataProvider dataProvider,
      InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA</param>
    /// <param name="validator">An instance of a InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator</param>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData(PDSADataProvider dataProvider,
      InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA entity, InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator validator)
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
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAData";
      StoredProcName = "InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumber";
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
      param.ParameterName = InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid).SetAsNull == false)
        AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid).Value = Entity.inputDeviceUid;
      else
        AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).SetAsNull == false)
        AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).Value = Entity.ioGroupNumber;
      else
        AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull == false)
        AllColumns.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      else
        AllColumns.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
    }
    #endregion
    
    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = AllColumns.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      else
        Entity.InputOutputGroupUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA</returns>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA CreateEntityFromDataRow(DataRow dr)
    {
      InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA entity = new InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA();

      if (dr.Table.Columns.Contains(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid))
      {
        if (dr[InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid] != DBNull.Value)
          entity.InputOutputGroupUid = PDSAProperty.ConvertToGuid(dr[InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ColumnNames.InputOutputGroupUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@inputDeviceUid'
    /// </summary>
    public static string inputDeviceUid = "@inputDeviceUid";
    /// <summary>
    /// Returns '@ioGroupNumber'
    /// </summary>
    public static string ioGroupNumber = "@ioGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
