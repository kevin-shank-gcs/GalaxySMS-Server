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
  /// This class calls the stored procedure GetClusterUidForAccessPortalPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class GetClusterUidForAccessPortalPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GetClusterUidForAccessPortalPDSAData class
    /// </summary>
    public GetClusterUidForAccessPortalPDSAData() : base()
    {
      Entity = new GetClusterUidForAccessPortalPDSA();
      ValidatorObject = new  GetClusterUidForAccessPortalPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the GetClusterUidForAccessPortalPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a GetClusterUidForAccessPortalPDSA</param>
    public GetClusterUidForAccessPortalPDSAData(GetClusterUidForAccessPortalPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new GetClusterUidForAccessPortalPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GetClusterUidForAccessPortalPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GetClusterUidForAccessPortalPDSA</param>
    public GetClusterUidForAccessPortalPDSAData(PDSADataProvider dataProvider,
      GetClusterUidForAccessPortalPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  GetClusterUidForAccessPortalPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GetClusterUidForAccessPortalPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GetClusterUidForAccessPortalPDSA</param>
    /// <param name="validator">An instance of a GetClusterUidForAccessPortalPDSAValidator</param>
    public GetClusterUidForAccessPortalPDSAData(PDSADataProvider dataProvider,
      GetClusterUidForAccessPortalPDSA entity, GetClusterUidForAccessPortalPDSAValidator validator)
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
    public GetClusterUidForAccessPortalPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "GetClusterUidForAccessPortalPDSAData";
      StoredProcName = "GetClusterUidForAccessPortal";
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
      param.ParameterName = GetClusterUidForAccessPortalPDSAValidator.ParameterNames.uid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = GetClusterUidForAccessPortalPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GetClusterUidForAccessPortalPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(GetClusterUidForAccessPortalPDSAValidator.ParameterNames.uid).SetAsNull == false)
        AllParameters.GetByName(GetClusterUidForAccessPortalPDSAValidator.ParameterNames.uid).Value = Entity.uid;
      else
        AllParameters.GetByName(GetClusterUidForAccessPortalPDSAValidator.ParameterNames.uid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(GetClusterUidForAccessPortalPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(GetClusterUidForAccessPortalPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>GetClusterUidForAccessPortalPDSA</returns>
    public GetClusterUidForAccessPortalPDSA CreateEntityFromDataRow(DataRow dr)
    {
      GetClusterUidForAccessPortalPDSA entity = new GetClusterUidForAccessPortalPDSA();

      if (dr.Table.Columns.Contains(GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[GetClusterUidForAccessPortalPDSAValidator.ColumnNames.ClusterUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetClusterUidForAccessPortalPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
