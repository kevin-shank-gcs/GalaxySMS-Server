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
  /// This class calls the stored procedure GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData class
    /// </summary>
    public GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData() : base()
    {
      Entity = new GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA();
      ValidatorObject = new  GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA</param>
    public GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA</param>
    public GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData(PDSADataProvider dataProvider,
      GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA</param>
    /// <param name="validator">An instance of a GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator</param>
    public GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData(PDSADataProvider dataProvider,
      GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA entity, GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator validator)
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
    public GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAData";
      StoredProcName = "GalaxyPanelAlarmSettings_PanelLoadDataByClusterUid";
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
      param.ParameterName = GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_EntityName_Header", "Entity Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_AccountCode_Header", "Account Code"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_Tag_Header", "Tag"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_IOGroupNumber_Header", "IO Group Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex, GetResourceMessage("GCS_GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA_OffsetIndex_Header", "Offset Index"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber).Value = 0;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName).Value = string.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId).Value = string.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber).Value = 0;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName).Value = string.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag).Value = string.Empty;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber).Value = Entity.IOGroupNumber;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber).Value = 0;
     
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex).SetAsNull == false)
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex).Value = Entity.OffsetIndex;
      else
        AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      else
        Entity.PanelNumber = 0;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      else
        Entity.GalaxyPanelUid = Guid.Empty;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName).GetAsString();
      else
        Entity.EntityName = string.Empty;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      else
        Entity.ClusterGroupId = 0;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      else
        Entity.ClusterNumber = 0;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName).GetAsString();
      else
        Entity.ClusterName = string.Empty;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag).GetAsString();
      else
        Entity.Tag = string.Empty;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber).IsNull == false)
        Entity.IOGroupNumber = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber).GetAsInteger();
      else
        Entity.IOGroupNumber = 0;

      if (AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex).IsNull == false)
        Entity.OffsetIndex = AllColumns.GetByName(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex).GetAsShort();
      else
        Entity.OffsetIndex = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA</returns>
    public GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA entity = new GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA();

      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber] != DBNull.Value)
          entity.PanelNumber = Convert.ToInt32(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.PanelNumber]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid] != DBNull.Value)
          entity.GalaxyPanelUid = PDSAProperty.ConvertToGuid(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.GalaxyPanelUid]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName] != DBNull.Value)
          entity.EntityName = PDSAString.ConvertToStringTrim(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityName]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId] != DBNull.Value)
          entity.EntityId = PDSAProperty.ConvertToGuid(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.EntityId]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterUid]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId] != DBNull.Value)
          entity.ClusterGroupId = Convert.ToInt32(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterGroupId]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber] != DBNull.Value)
          entity.ClusterNumber = Convert.ToInt32(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterNumber]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName] != DBNull.Value)
          entity.ClusterName = PDSAString.ConvertToStringTrim(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.ClusterName]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag] != DBNull.Value)
          entity.Tag = PDSAString.ConvertToStringTrim(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.Tag]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber] != DBNull.Value)
          entity.IOGroupNumber = Convert.ToInt32(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.IOGroupNumber]);
      }
      if (dr.Table.Columns.Contains(GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex))
      {
        if (dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex] != DBNull.Value)
          entity.OffsetIndex = Convert.ToInt16(dr[GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAValidator.ColumnNames.OffsetIndex]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSA class.
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
