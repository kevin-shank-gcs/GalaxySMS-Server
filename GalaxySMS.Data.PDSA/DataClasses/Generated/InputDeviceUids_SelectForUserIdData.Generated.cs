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
  /// This class calls the stored procedure InputDeviceUids_SelectForUserIdPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class InputDeviceUids_SelectForUserIdPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the InputDeviceUids_SelectForUserIdPDSAData class
    /// </summary>
    public InputDeviceUids_SelectForUserIdPDSAData() : base()
    {
      Entity = new InputDeviceUids_SelectForUserIdPDSA();
      ValidatorObject = new  InputDeviceUids_SelectForUserIdPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the InputDeviceUids_SelectForUserIdPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a InputDeviceUids_SelectForUserIdPDSA</param>
    public InputDeviceUids_SelectForUserIdPDSAData(InputDeviceUids_SelectForUserIdPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new InputDeviceUids_SelectForUserIdPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputDeviceUids_SelectForUserIdPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputDeviceUids_SelectForUserIdPDSA</param>
    public InputDeviceUids_SelectForUserIdPDSAData(PDSADataProvider dataProvider,
      InputDeviceUids_SelectForUserIdPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  InputDeviceUids_SelectForUserIdPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputDeviceUids_SelectForUserIdPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputDeviceUids_SelectForUserIdPDSA</param>
    /// <param name="validator">An instance of a InputDeviceUids_SelectForUserIdPDSAValidator</param>
    public InputDeviceUids_SelectForUserIdPDSAData(PDSADataProvider dataProvider,
      InputDeviceUids_SelectForUserIdPDSA entity, InputDeviceUids_SelectForUserIdPDSAValidator validator)
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
    public InputDeviceUids_SelectForUserIdPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "InputDeviceUids_SelectForUserIdPDSAData";
      StoredProcName = "InputDeviceUids_SelectForUserId";
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
      param.ParameterName = InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid, GetResourceMessage("GCS_InputDeviceUids_SelectForUserIdPDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId).SetAsNull == false)
        AllParameters.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      else
        AllParameters.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid).SetAsNull == false)
        AllColumns.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      else
        AllColumns.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = AllColumns.GetByName(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid).GetAsGuid();
      else
        Entity.InputDeviceUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>InputDeviceUids_SelectForUserIdPDSA</returns>
    public InputDeviceUids_SelectForUserIdPDSA CreateEntityFromDataRow(DataRow dr)
    {
      InputDeviceUids_SelectForUserIdPDSA entity = new InputDeviceUids_SelectForUserIdPDSA();

      if (dr.Table.Columns.Contains(InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid))
      {
        if (dr[InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid] != DBNull.Value)
          entity.InputDeviceUid = PDSAProperty.ConvertToGuid(dr[InputDeviceUids_SelectForUserIdPDSAValidator.ColumnNames.InputDeviceUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDeviceUids_SelectForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
