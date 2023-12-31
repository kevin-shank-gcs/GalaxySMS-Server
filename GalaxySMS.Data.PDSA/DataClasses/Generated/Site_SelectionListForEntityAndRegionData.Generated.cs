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
  /// This class calls the stored procedure Site_SelectionListForEntityAndRegionPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class Site_SelectionListForEntityAndRegionPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the Site_SelectionListForEntityAndRegionPDSAData class
    /// </summary>
    public Site_SelectionListForEntityAndRegionPDSAData() : base()
    {
      Entity = new Site_SelectionListForEntityAndRegionPDSA();
      ValidatorObject = new  Site_SelectionListForEntityAndRegionPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the Site_SelectionListForEntityAndRegionPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a Site_SelectionListForEntityAndRegionPDSA</param>
    public Site_SelectionListForEntityAndRegionPDSAData(Site_SelectionListForEntityAndRegionPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new Site_SelectionListForEntityAndRegionPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the Site_SelectionListForEntityAndRegionPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a Site_SelectionListForEntityAndRegionPDSA</param>
    public Site_SelectionListForEntityAndRegionPDSAData(PDSADataProvider dataProvider,
      Site_SelectionListForEntityAndRegionPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  Site_SelectionListForEntityAndRegionPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the Site_SelectionListForEntityAndRegionPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a Site_SelectionListForEntityAndRegionPDSA</param>
    /// <param name="validator">An instance of a Site_SelectionListForEntityAndRegionPDSAValidator</param>
    public Site_SelectionListForEntityAndRegionPDSAData(PDSADataProvider dataProvider,
      Site_SelectionListForEntityAndRegionPDSA entity, Site_SelectionListForEntityAndRegionPDSAValidator validator)
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
    public Site_SelectionListForEntityAndRegionPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "Site_SelectionListForEntityAndRegionPDSAData";
      StoredProcName = "Site_SelectionListForEntityAndRegion";
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
      param.ParameterName = Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_RegionUid_Header", "Region Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_SiteName_Header", "Site Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_SiteId_Header", "Site Id"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_BinaryResource_Header", "Binary Resource"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid).SetAsNull == false)
        AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid).Value = Entity.RegionUid;
      else
        AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid).SetAsNull == false)
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      else
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid).SetAsNull == false)
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid).Value = Entity.RegionUid;
      else
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName).SetAsNull == false)
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName).Value = Entity.SiteName;
      else
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName).Value = string.Empty;
     
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId).SetAsNull == false)
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId).Value = Entity.SiteId;
      else
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId).Value = string.Empty;
     
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId).SetAsNull == false)
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      else
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource).SetAsNull == false)
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource).Value = Entity.BinaryResource;
      else
        AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource).Value = string.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      else
        Entity.SiteUid = Guid.Empty;

      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid).IsNull == false)
        Entity.RegionUid = AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid).GetAsGuid();
      else
        Entity.RegionUid = Guid.Empty;

      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName).IsNull == false)
        Entity.SiteName = AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName).GetAsString();
      else
        Entity.SiteName = string.Empty;

      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId).IsNull == false)
        Entity.SiteId = AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId).GetAsString();
      else
        Entity.SiteId = string.Empty;

      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;

      if (AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource).IsNull == false)
        Entity.BinaryResource = AllColumns.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource).GetAsByteArray();
      else
        Entity.BinaryResource = null;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>Site_SelectionListForEntityAndRegionPDSA</returns>
    public Site_SelectionListForEntityAndRegionPDSA CreateEntityFromDataRow(DataRow dr)
    {
      Site_SelectionListForEntityAndRegionPDSA entity = new Site_SelectionListForEntityAndRegionPDSA();

      if (dr.Table.Columns.Contains(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid))
      {
        if (dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid] != DBNull.Value)
          entity.SiteUid = PDSAProperty.ConvertToGuid(dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteUid]);
      }
      if (dr.Table.Columns.Contains(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid))
      {
        if (dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid] != DBNull.Value)
          entity.RegionUid = PDSAProperty.ConvertToGuid(dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.RegionUid]);
      }
      if (dr.Table.Columns.Contains(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName))
      {
        if (dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName] != DBNull.Value)
          entity.SiteName = PDSAString.ConvertToStringTrim(dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteName]);
      }
      if (dr.Table.Columns.Contains(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId))
      {
        if (dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId] != DBNull.Value)
          entity.SiteId = PDSAString.ConvertToStringTrim(dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.SiteId]);
      }
      if (dr.Table.Columns.Contains(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId))
      {
        if (dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId] != DBNull.Value)
          entity.EntityId = PDSAProperty.ConvertToGuid(dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.EntityId]);
      }
      if (dr.Table.Columns.Contains(Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource))
      {
        if (dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource] != DBNull.Value)
          entity.BinaryResource = (byte[])dr[Site_SelectionListForEntityAndRegionPDSAValidator.ColumnNames.BinaryResource];
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Site_SelectionListForEntityAndRegionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
