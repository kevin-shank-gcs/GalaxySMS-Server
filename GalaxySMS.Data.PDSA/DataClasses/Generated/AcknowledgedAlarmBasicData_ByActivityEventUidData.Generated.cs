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
  /// This class calls the stored procedure AcknowledgedAlarmBasicData_ByActivityEventUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData class
    /// </summary>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData() : base()
    {
      Entity = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSA();
      ValidatorObject = new  AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AcknowledgedAlarmBasicData_ByActivityEventUidPDSA</param>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData(AcknowledgedAlarmBasicData_ByActivityEventUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AcknowledgedAlarmBasicData_ByActivityEventUidPDSA</param>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData(PDSADataProvider dataProvider,
      AcknowledgedAlarmBasicData_ByActivityEventUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AcknowledgedAlarmBasicData_ByActivityEventUidPDSA</param>
    /// <param name="validator">An instance of a AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator</param>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData(PDSADataProvider dataProvider,
      AcknowledgedAlarmBasicData_ByActivityEventUidPDSA entity, AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator validator)
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
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "AcknowledgedAlarmBasicData_ByActivityEventUidPDSAData";
      StoredProcName = "AcknowledgedAlarmBasicData_ByActivityEventUid";
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
      param.ParameterName = AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_ActivityEventUid_Header", "Activity Event Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_DeviceEntityId_Header", "Device Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_AccessPortalAlarmEventAcknowledgmentUid_Header", "Access Portal Alarm Event Acknowledgment Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_GalaxyPanelAlarmEventAcknowledgmentUid_Header", "Galaxy Panel Alarm Event Acknowledgment Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_InputDeviceAlarmEventAcknowledgmentUid_Header", "Input Device Alarm Event Acknowledgment Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_Response_Header", "Response"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_AckedByUserId_Header", "Acked By User Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_AckedByUserDisplayName_Header", "Acked By User Display Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_AckedDateTime_Header", "Acked Date Time"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByActivityEventUidPDSA_AckedUpdatedDateTime_Header", "Acked Updated Date Time"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid).SetAsNull == false)
        AllParameters.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      else
        AllParameters.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.ActivityEventUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId).Value = Entity.DeviceEntityId;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid).Value = Entity.DeviceUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).Value = Entity.AccessPortalAlarmEventAcknowledgmentUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).Value = Entity.GalaxyPanelAlarmEventAcknowledgmentUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).Value = Entity.InputDeviceAlarmEventAcknowledgmentUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response).Value = Entity.Response;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response).Value = string.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId).Value = Entity.AckedByUserId;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName).Value = Entity.AckedByUserDisplayName;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName).Value = string.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime).Value = Entity.AckedDateTime;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime).Value = DateTimeOffset.Now;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).Value = Entity.AckedUpdatedDateTime;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).Value = DateTimeOffset.Now;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid).IsNull == false)
        Entity.ActivityEventUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid).GetAsGuid();
      else
        Entity.ActivityEventUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId).IsNull == false)
        Entity.DeviceEntityId = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId).GetAsGuid();
      else
        Entity.DeviceEntityId = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid).GetAsGuid();
      else
        Entity.DeviceUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.AccessPortalAlarmEventAcknowledgmentUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).GetAsGuid();
      else
        Entity.AccessPortalAlarmEventAcknowledgmentUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.GalaxyPanelAlarmEventAcknowledgmentUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).GetAsGuid();
      else
        Entity.GalaxyPanelAlarmEventAcknowledgmentUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.InputDeviceAlarmEventAcknowledgmentUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).GetAsGuid();
      else
        Entity.InputDeviceAlarmEventAcknowledgmentUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response).IsNull == false)
        Entity.Response = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response).GetAsString();
      else
        Entity.Response = string.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId).IsNull == false)
        Entity.AckedByUserId = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId).GetAsGuid();
      else
        Entity.AckedByUserId = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName).IsNull == false)
        Entity.AckedByUserDisplayName = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName).GetAsString();
      else
        Entity.AckedByUserDisplayName = string.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime).IsNull == false)
        Entity.AckedDateTime = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime).GetAsDateTimeOffset();
      else
        Entity.AckedDateTime = DateTimeOffset.Now;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).IsNull == false)
        Entity.AckedUpdatedDateTime = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).GetAsDateTimeOffset();
      else
        Entity.AckedUpdatedDateTime = DateTimeOffset.Now;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AcknowledgedAlarmBasicData_ByActivityEventUidPDSA</returns>
    public AcknowledgedAlarmBasicData_ByActivityEventUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      AcknowledgedAlarmBasicData_ByActivityEventUidPDSA entity = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSA();

      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid] != DBNull.Value)
          entity.ActivityEventUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.ActivityEventUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId] != DBNull.Value)
          entity.DeviceEntityId = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceEntityId]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid] != DBNull.Value)
          entity.DeviceUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.DeviceUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid] != DBNull.Value)
          entity.AccessPortalAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid] != DBNull.Value)
          entity.GalaxyPanelAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid] != DBNull.Value)
          entity.InputDeviceAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response] != DBNull.Value)
          entity.Response = PDSAString.ConvertToStringTrim(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.Response]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId] != DBNull.Value)
          entity.AckedByUserId = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserId]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName] != DBNull.Value)
          entity.AckedByUserDisplayName = PDSAString.ConvertToStringTrim(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedByUserDisplayName]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime] != DBNull.Value)
          entity.AckedDateTime = PDSAProperty.ConvertToDateTimeOffset(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedDateTime]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime))
      {
        if (dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime] != DBNull.Value)
          entity.AckedUpdatedDateTime = PDSAProperty.ConvertToDateTimeOffset(dr[AcknowledgedAlarmBasicData_ByActivityEventUidPDSAValidator.ColumnNames.AckedUpdatedDateTime]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AcknowledgedAlarmBasicData_ByActivityEventUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ActivityEventUid'
    /// </summary>
    public static string ActivityEventUid = "@ActivityEventUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    //public void ResetParameters()
    //{
    //    InitParameters();
    //}
  }
}
