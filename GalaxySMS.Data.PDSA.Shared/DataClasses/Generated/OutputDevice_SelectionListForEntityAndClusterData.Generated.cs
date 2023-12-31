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
  /// This class calls the stored procedure OutputDevice_SelectionListForEntityAndClusterPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class OutputDevice_SelectionListForEntityAndClusterPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the OutputDevice_SelectionListForEntityAndClusterPDSAData class
    /// </summary>
    public OutputDevice_SelectionListForEntityAndClusterPDSAData() : base()
    {
      Entity = new OutputDevice_SelectionListForEntityAndClusterPDSA();
      ValidatorObject = new  OutputDevice_SelectionListForEntityAndClusterPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the OutputDevice_SelectionListForEntityAndClusterPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a OutputDevice_SelectionListForEntityAndClusterPDSA</param>
    public OutputDevice_SelectionListForEntityAndClusterPDSAData(OutputDevice_SelectionListForEntityAndClusterPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new OutputDevice_SelectionListForEntityAndClusterPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the OutputDevice_SelectionListForEntityAndClusterPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a OutputDevice_SelectionListForEntityAndClusterPDSA</param>
    public OutputDevice_SelectionListForEntityAndClusterPDSAData(PDSADataProvider dataProvider,
      OutputDevice_SelectionListForEntityAndClusterPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  OutputDevice_SelectionListForEntityAndClusterPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the OutputDevice_SelectionListForEntityAndClusterPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a OutputDevice_SelectionListForEntityAndClusterPDSA</param>
    /// <param name="validator">An instance of a OutputDevice_SelectionListForEntityAndClusterPDSAValidator</param>
    public OutputDevice_SelectionListForEntityAndClusterPDSAData(PDSADataProvider dataProvider,
      OutputDevice_SelectionListForEntityAndClusterPDSA entity, OutputDevice_SelectionListForEntityAndClusterPDSAValidator validator)
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
    public OutputDevice_SelectionListForEntityAndClusterPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "OutputDevice_SelectionListForEntityAndClusterPDSAData";
      StoredProcName = "OutputDevice_SelectionListForEntityAndCluster";
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
      param.ParameterName = OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_OutputName_Header", "Output Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_Location_Header", "Location"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_BinaryResource_Header", "Binary Resource"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_ClusterTypeCode_Header", "Cluster Type Code"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_GalaxyPanelTypeCode_Header", "Galaxy Panel Type Code"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_InterfaceBoardTypeCode_Header", "Interface Board Type Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_InterfaceBoardModel_Header", "Interface Board Model"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_InterfaceBoardSectionModeCode_Header", "Interface Board Section Mode Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode, GetResourceMessage("GCS_OutputDevice_SelectionListForEntityAndClusterPDSA_ModuleTypeCode_Header", "Module Type Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName).Value = Entity.OutputName;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location).Value = Entity.Location;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource).Value = Entity.BinaryResource;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode).Value = Entity.ClusterTypeCode;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode).Value = Entity.GalaxyPanelTypeCode;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode).Value = Entity.InterfaceBoardTypeCode;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode).Value = 0;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel).Value = Entity.InterfaceBoardModel;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel).Value = string.Empty;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode).Value = Entity.InterfaceBoardSectionModeCode;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode).Value = 0;
     
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode).SetAsNull == false)
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode).Value = Entity.ModuleTypeCode;
      else
        AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid).GetAsGuid();
      else
        Entity.OutputDeviceUid = Guid.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName).IsNull == false)
        Entity.OutputName = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName).GetAsString();
      else
        Entity.OutputName = string.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location).IsNull == false)
        Entity.Location = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location).GetAsString();
      else
        Entity.Location = string.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource).IsNull == false)
        Entity.BinaryResource = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource).GetAsByteArray();
      else
        Entity.BinaryResource = null;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode).IsNull == false)
        Entity.ClusterTypeCode = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode).GetAsString();
      else
        Entity.ClusterTypeCode = string.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode).IsNull == false)
        Entity.GalaxyPanelTypeCode = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode).GetAsString();
      else
        Entity.GalaxyPanelTypeCode = string.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode).IsNull == false)
        Entity.InterfaceBoardTypeCode = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode).GetAsShort();
      else
        Entity.InterfaceBoardTypeCode = 0;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel).IsNull == false)
        Entity.InterfaceBoardModel = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel).GetAsString();
      else
        Entity.InterfaceBoardModel = string.Empty;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode).IsNull == false)
        Entity.InterfaceBoardSectionModeCode = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode).GetAsShort();
      else
        Entity.InterfaceBoardSectionModeCode = 0;

      if (AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode).IsNull == false)
        Entity.ModuleTypeCode = AllColumns.GetByName(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode).GetAsShort();
      else
        Entity.ModuleTypeCode = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>OutputDevice_SelectionListForEntityAndClusterPDSA</returns>
    public OutputDevice_SelectionListForEntityAndClusterPDSA CreateEntityFromDataRow(DataRow dr)
    {
      OutputDevice_SelectionListForEntityAndClusterPDSA entity = new OutputDevice_SelectionListForEntityAndClusterPDSA();

      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid] != DBNull.Value)
          entity.OutputDeviceUid = PDSAProperty.ConvertToGuid(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputDeviceUid]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterUid]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId] != DBNull.Value)
          entity.EntityId = PDSAProperty.ConvertToGuid(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.EntityId]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName] != DBNull.Value)
          entity.OutputName = PDSAString.ConvertToStringTrim(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.OutputName]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location] != DBNull.Value)
          entity.Location = PDSAString.ConvertToStringTrim(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.Location]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource] != DBNull.Value)
          entity.BinaryResource = (byte[])dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.BinaryResource];
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode] != DBNull.Value)
          entity.ClusterTypeCode = PDSAString.ConvertToStringTrim(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ClusterTypeCode]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode] != DBNull.Value)
          entity.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.GalaxyPanelTypeCode]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode] != DBNull.Value)
          entity.InterfaceBoardTypeCode = Convert.ToInt16(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardTypeCode]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel] != DBNull.Value)
          entity.InterfaceBoardModel = PDSAString.ConvertToStringTrim(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardModel]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode] != DBNull.Value)
          entity.InterfaceBoardSectionModeCode = Convert.ToInt16(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);
      }
      if (dr.Table.Columns.Contains(OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode))
      {
        if (dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode] != DBNull.Value)
          entity.ModuleTypeCode = Convert.ToInt16(dr[OutputDevice_SelectionListForEntityAndClusterPDSAValidator.ColumnNames.ModuleTypeCode]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDevice_SelectionListForEntityAndClusterPDSA class.
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
