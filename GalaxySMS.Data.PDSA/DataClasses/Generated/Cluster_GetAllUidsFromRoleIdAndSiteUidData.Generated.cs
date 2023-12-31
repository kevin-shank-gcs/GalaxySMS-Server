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
  /// This class calls the stored procedure Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData class
    /// </summary>
    public Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData() : base()
    {
      Entity = new Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA();
      ValidatorObject = new  Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA</param>
    public Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA</param>
    public Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData(PDSADataProvider dataProvider,
      Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA</param>
    /// <param name="validator">An instance of a Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator</param>
    public Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData(PDSADataProvider dataProvider,
      Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA entity, Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator validator)
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
    public Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAData";
      StoredProcName = "Cluster_GetAllUidsFromRoleIdAndSiteUid";
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
      param.ParameterName = Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId).SetAsNull == false)
        AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      else
        AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid).SetAsNull == false)
        AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      else
        AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA</returns>
    public Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA entity = new Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA();

      if (dr.Table.Columns.Contains(Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ColumnNames.ClusterUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Cluster_GetAllUidsFromRoleIdAndSiteUidPDSA class.
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
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
