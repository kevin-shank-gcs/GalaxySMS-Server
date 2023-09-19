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
  /// This class calls the stored procedure InputDevice_GetAllUidsForClusterUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class InputDevice_GetAllUidsForClusterUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsForClusterUidPDSAData class
    /// </summary>
    public InputDevice_GetAllUidsForClusterUidPDSAData() : base()
    {
      Entity = new InputDevice_GetAllUidsForClusterUidPDSA();
      ValidatorObject = new  InputDevice_GetAllUidsForClusterUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsForClusterUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a InputDevice_GetAllUidsForClusterUidPDSA</param>
    public InputDevice_GetAllUidsForClusterUidPDSAData(InputDevice_GetAllUidsForClusterUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new InputDevice_GetAllUidsForClusterUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsForClusterUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputDevice_GetAllUidsForClusterUidPDSA</param>
    public InputDevice_GetAllUidsForClusterUidPDSAData(PDSADataProvider dataProvider,
      InputDevice_GetAllUidsForClusterUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  InputDevice_GetAllUidsForClusterUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the InputDevice_GetAllUidsForClusterUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a InputDevice_GetAllUidsForClusterUidPDSA</param>
    /// <param name="validator">An instance of a InputDevice_GetAllUidsForClusterUidPDSAValidator</param>
    public InputDevice_GetAllUidsForClusterUidPDSAData(PDSADataProvider dataProvider,
      InputDevice_GetAllUidsForClusterUidPDSA entity, InputDevice_GetAllUidsForClusterUidPDSAValidator validator)
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
    public InputDevice_GetAllUidsForClusterUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "InputDevice_GetAllUidsForClusterUidPDSAData";
      StoredProcName = "InputDevice_GetAllUidsForClusterUid";
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
      param.ParameterName = InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid, GetResourceMessage("GCS_InputDevice_GetAllUidsForClusterUidPDSA_Uid_Header", "Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid).SetAsNull == false)
        AllColumns.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid).Value = Entity.Uid;
      else
        AllColumns.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid).IsNull == false)
        Entity.Uid = AllColumns.GetByName(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid).GetAsGuid();
      else
        Entity.Uid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>InputDevice_GetAllUidsForClusterUidPDSA</returns>
    public InputDevice_GetAllUidsForClusterUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      InputDevice_GetAllUidsForClusterUidPDSA entity = new InputDevice_GetAllUidsForClusterUidPDSA();

      if (dr.Table.Columns.Contains(InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid))
      {
        if (dr[InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid] != DBNull.Value)
          entity.Uid = PDSAProperty.ConvertToGuid(dr[InputDevice_GetAllUidsForClusterUidPDSAValidator.ColumnNames.Uid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputDevice_GetAllUidsForClusterUidPDSA class.
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
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
