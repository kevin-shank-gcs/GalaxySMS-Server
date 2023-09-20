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
  /// This class calls the stored procedure MercScp_GetAllUidsForMercScpGroupUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class MercScp_GetAllUidsForMercScpGroupUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the MercScp_GetAllUidsForMercScpGroupUidPDSAData class
    /// </summary>
    public MercScp_GetAllUidsForMercScpGroupUidPDSAData() : base()
    {
      Entity = new MercScp_GetAllUidsForMercScpGroupUidPDSA();
      ValidatorObject = new  MercScp_GetAllUidsForMercScpGroupUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the MercScp_GetAllUidsForMercScpGroupUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a MercScp_GetAllUidsForMercScpGroupUidPDSA</param>
    public MercScp_GetAllUidsForMercScpGroupUidPDSAData(MercScp_GetAllUidsForMercScpGroupUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new MercScp_GetAllUidsForMercScpGroupUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the MercScp_GetAllUidsForMercScpGroupUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a MercScp_GetAllUidsForMercScpGroupUidPDSA</param>
    public MercScp_GetAllUidsForMercScpGroupUidPDSAData(PDSADataProvider dataProvider,
      MercScp_GetAllUidsForMercScpGroupUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  MercScp_GetAllUidsForMercScpGroupUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the MercScp_GetAllUidsForMercScpGroupUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a MercScp_GetAllUidsForMercScpGroupUidPDSA</param>
    /// <param name="validator">An instance of a MercScp_GetAllUidsForMercScpGroupUidPDSAValidator</param>
    public MercScp_GetAllUidsForMercScpGroupUidPDSAData(PDSADataProvider dataProvider,
      MercScp_GetAllUidsForMercScpGroupUidPDSA entity, MercScp_GetAllUidsForMercScpGroupUidPDSAValidator validator)
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
    public MercScp_GetAllUidsForMercScpGroupUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "MercScp_GetAllUidsForMercScpGroupUidPDSAData";
      StoredProcName = "MercScp_GetAllUidsForMercScpGroupUid";
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
      param.ParameterName = MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.MercScpGroupUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid, GetResourceMessage("GCS_MercScp_GetAllUidsForMercScpGroupUidPDSA_Uid_Header", "Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.MercScpGroupUid).SetAsNull == false)
        AllParameters.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      else
        AllParameters.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.MercScpGroupUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid).SetAsNull == false)
        AllColumns.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid).Value = Entity.Uid;
      else
        AllColumns.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid).IsNull == false)
        Entity.Uid = AllColumns.GetByName(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid).GetAsGuid();
      else
        Entity.Uid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>MercScp_GetAllUidsForMercScpGroupUidPDSA</returns>
    public MercScp_GetAllUidsForMercScpGroupUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      MercScp_GetAllUidsForMercScpGroupUidPDSA entity = new MercScp_GetAllUidsForMercScpGroupUidPDSA();

      if (dr.Table.Columns.Contains(MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid))
      {
        if (dr[MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid] != DBNull.Value)
          entity.Uid = PDSAProperty.ConvertToGuid(dr[MercScp_GetAllUidsForMercScpGroupUidPDSAValidator.ColumnNames.Uid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the MercScp_GetAllUidsForMercScpGroupUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
