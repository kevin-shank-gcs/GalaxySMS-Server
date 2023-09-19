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
  /// This class calls the stored procedure InputDevice_GetAllUidsFromRoleIdPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class InputDevice_GetAllUidsFromRoleIdPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsFromRoleIdPDSAData class
    /// </summary>
    public InputDevice_GetAllUidsFromRoleIdPDSAData() : base()
    {
      Entity = new InputDevice_GetAllUidsFromRoleIdPDSA();
      ValidatorObject = new  InputDevice_GetAllUidsFromRoleIdPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsFromRoleIdPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a InputDevice_GetAllUidsFromRoleIdPDSA</param>
    public InputDevice_GetAllUidsFromRoleIdPDSAData(InputDevice_GetAllUidsFromRoleIdPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new InputDevice_GetAllUidsFromRoleIdPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsFromRoleIdPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputDevice_GetAllUidsFromRoleIdPDSA</param>
    public InputDevice_GetAllUidsFromRoleIdPDSAData(PDSADataProvider dataProvider,
      InputDevice_GetAllUidsFromRoleIdPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  InputDevice_GetAllUidsFromRoleIdPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsFromRoleIdPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputDevice_GetAllUidsFromRoleIdPDSA</param>
    /// <param name="validator">An instance of a InputDevice_GetAllUidsFromRoleIdPDSAValidator</param>
    public InputDevice_GetAllUidsFromRoleIdPDSAData(PDSADataProvider dataProvider,
      InputDevice_GetAllUidsFromRoleIdPDSA entity, InputDevice_GetAllUidsFromRoleIdPDSAValidator validator)
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
    public InputDevice_GetAllUidsFromRoleIdPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "InputDevice_GetAllUidsFromRoleIdPDSAData";
      StoredProcName = "InputDevice_GetAllUidsFromRoleId";
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
      param.ParameterName = InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RoleId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid, GetResourceMessage("GCS_InputDevice_GetAllUidsFromRoleIdPDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RoleId).SetAsNull == false)
        AllParameters.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      else
        AllParameters.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RoleId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid).SetAsNull == false)
        AllColumns.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      else
        AllColumns.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = AllColumns.GetByName(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid).GetAsGuid();
      else
        Entity.InputDeviceUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>InputDevice_GetAllUidsFromRoleIdPDSA</returns>
    public InputDevice_GetAllUidsFromRoleIdPDSA CreateEntityFromDataRow(DataRow dr)
    {
      InputDevice_GetAllUidsFromRoleIdPDSA entity = new InputDevice_GetAllUidsFromRoleIdPDSA();

      if (dr.Table.Columns.Contains(InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid))
      {
        if (dr[InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid] != DBNull.Value)
          entity.InputDeviceUid = PDSAProperty.ConvertToGuid(dr[InputDevice_GetAllUidsFromRoleIdPDSAValidator.ColumnNames.InputDeviceUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetAllUidsFromRoleIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
