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
  /// This class calls the stored procedure Cluster_GetAccessPortalDefaultsPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class Cluster_GetAccessPortalDefaultsPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the Cluster_GetAccessPortalDefaultsPDSAData class
    /// </summary>
    public Cluster_GetAccessPortalDefaultsPDSAData() : base()
    {
      Entity = new Cluster_GetAccessPortalDefaultsPDSA();
      ValidatorObject = new  Cluster_GetAccessPortalDefaultsPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the Cluster_GetAccessPortalDefaultsPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a Cluster_GetAccessPortalDefaultsPDSA</param>
    public Cluster_GetAccessPortalDefaultsPDSAData(Cluster_GetAccessPortalDefaultsPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new Cluster_GetAccessPortalDefaultsPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the Cluster_GetAccessPortalDefaultsPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a Cluster_GetAccessPortalDefaultsPDSA</param>
    public Cluster_GetAccessPortalDefaultsPDSAData(PDSADataProvider dataProvider,
      Cluster_GetAccessPortalDefaultsPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  Cluster_GetAccessPortalDefaultsPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the Cluster_GetAccessPortalDefaultsPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a Cluster_GetAccessPortalDefaultsPDSA</param>
    /// <param name="validator">An instance of a Cluster_GetAccessPortalDefaultsPDSAValidator</param>
    public Cluster_GetAccessPortalDefaultsPDSAData(PDSADataProvider dataProvider,
      Cluster_GetAccessPortalDefaultsPDSA entity, Cluster_GetAccessPortalDefaultsPDSAValidator validator)
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
    public Cluster_GetAccessPortalDefaultsPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "Cluster_GetAccessPortalDefaultsPDSAData";
      StoredProcName = "Cluster_GetAccessPortalDefaults";
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
      param.ParameterName = Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid, GetResourceMessage("GCS_Cluster_GetAccessPortalDefaultsPDSA_AccessPortalTypeUid_Header", "Access Portal Type Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid, GetResourceMessage("GCS_Cluster_GetAccessPortalDefaultsPDSA_TemplateAccessPortalUid_Header", "Template Access Portal Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_Cluster_GetAccessPortalDefaultsPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_Cluster_GetAccessPortalDefaultsPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid).SetAsNull == false)
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid).Value = Entity.AccessPortalTypeUid;
      else
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid).SetAsNull == false)
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid).Value = Entity.TemplateAccessPortalUid;
      else
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId).SetAsNull == false)
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      else
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid).SetAsNull == false)
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      else
        AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid).IsNull == false)
        Entity.AccessPortalTypeUid = AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid).GetAsGuid();
      else
        Entity.AccessPortalTypeUid = Guid.Empty;

      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid).IsNull == false)
        Entity.TemplateAccessPortalUid = AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid).GetAsGuid();
      else
        Entity.TemplateAccessPortalUid = Guid.Empty;

      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;

      if (AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = AllColumns.GetByName(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      else
        Entity.SiteUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>Cluster_GetAccessPortalDefaultsPDSA</returns>
    public Cluster_GetAccessPortalDefaultsPDSA CreateEntityFromDataRow(DataRow dr)
    {
      Cluster_GetAccessPortalDefaultsPDSA entity = new Cluster_GetAccessPortalDefaultsPDSA();

      if (dr.Table.Columns.Contains(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid))
      {
        if (dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid] != DBNull.Value)
          entity.AccessPortalTypeUid = PDSAProperty.ConvertToGuid(dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.AccessPortalTypeUid]);
      }
      if (dr.Table.Columns.Contains(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid))
      {
        if (dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid] != DBNull.Value)
          entity.TemplateAccessPortalUid = PDSAProperty.ConvertToGuid(dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.TemplateAccessPortalUid]);
      }
      if (dr.Table.Columns.Contains(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId))
      {
        if (dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId] != DBNull.Value)
          entity.EntityId = PDSAProperty.ConvertToGuid(dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.EntityId]);
      }
      if (dr.Table.Columns.Contains(Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid))
      {
        if (dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid] != DBNull.Value)
          entity.SiteUid = PDSAProperty.ConvertToGuid(dr[Cluster_GetAccessPortalDefaultsPDSAValidator.ColumnNames.SiteUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Cluster_GetAccessPortalDefaultsPDSA class.
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
