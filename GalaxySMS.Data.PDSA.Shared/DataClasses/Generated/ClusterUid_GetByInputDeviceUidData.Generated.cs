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
  /// This class calls the stored procedure ClusterUid_GetByInputDeviceUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class ClusterUid_GetByInputDeviceUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the ClusterUid_GetByInputDeviceUidPDSAData class
    /// </summary>
    public ClusterUid_GetByInputDeviceUidPDSAData() : base()
    {
      Entity = new ClusterUid_GetByInputDeviceUidPDSA();
      ValidatorObject = new  ClusterUid_GetByInputDeviceUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the ClusterUid_GetByInputDeviceUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a ClusterUid_GetByInputDeviceUidPDSA</param>
    public ClusterUid_GetByInputDeviceUidPDSAData(ClusterUid_GetByInputDeviceUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new ClusterUid_GetByInputDeviceUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the ClusterUid_GetByInputDeviceUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a ClusterUid_GetByInputDeviceUidPDSA</param>
    public ClusterUid_GetByInputDeviceUidPDSAData(PDSADataProvider dataProvider,
      ClusterUid_GetByInputDeviceUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  ClusterUid_GetByInputDeviceUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the ClusterUid_GetByInputDeviceUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a ClusterUid_GetByInputDeviceUidPDSA</param>
    /// <param name="validator">An instance of a ClusterUid_GetByInputDeviceUidPDSAValidator</param>
    public ClusterUid_GetByInputDeviceUidPDSAData(PDSADataProvider dataProvider,
      ClusterUid_GetByInputDeviceUidPDSA entity, ClusterUid_GetByInputDeviceUidPDSAValidator validator)
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
    public ClusterUid_GetByInputDeviceUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "ClusterUid_GetByInputDeviceUidPDSAData";
      StoredProcName = "ClusterUid_GetByInputDeviceUid";
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
      param.ParameterName = ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_ClusterUid_GetByInputDeviceUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid).SetAsNull == false)
        AllParameters.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid).Value = Entity.inputDeviceUid;
      else
        AllParameters.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.inputDeviceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>ClusterUid_GetByInputDeviceUidPDSA</returns>
    public ClusterUid_GetByInputDeviceUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      ClusterUid_GetByInputDeviceUidPDSA entity = new ClusterUid_GetByInputDeviceUidPDSA();

      if (dr.Table.Columns.Contains(ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[ClusterUid_GetByInputDeviceUidPDSAValidator.ColumnNames.ClusterUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterUid_GetByInputDeviceUidPDSA class.
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
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
