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
  /// This class calls the stored procedure AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData class
    /// </summary>
    public AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData() : base()
    {
      Entity = new AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA();
      ValidatorObject = new  AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA</param>
    public AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA</param>
    public AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData(PDSADataProvider dataProvider,
      AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA</param>
    /// <param name="validator">An instance of a AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator</param>
    public AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData(PDSADataProvider dataProvider,
      AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA entity, AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator validator)
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
    public AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAData";
      StoredProcName = "AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUid";
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
      param.ParameterName = AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.AccessPortalAlarmEventAcknowledgmentUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_ActivityEventUid_Header", "Activity Event Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_DeviceEntityId_Header", "Device Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_DeviceUid_Header", "Device Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_AccessPortalAlarmEventAcknowledgmentUid_Header", "Access Portal Alarm Event Acknowledgment Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_GalaxyPanelAlarmEventAcknowledgmentUid_Header", "Galaxy Panel Alarm Event Acknowledgment Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_InputDeviceAlarmEventAcknowledgmentUid_Header", "Input Device Alarm Event Acknowledgment Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_Response_Header", "Response"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_AckedByUserId_Header", "Acked By User Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_AckedByUserDisplayName_Header", "Acked By User Display Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_AckedDateTime_Header", "Acked Date Time"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime, GetResourceMessage("GCS_AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA_AckedUpdatedDateTime_Header", "Acked Updated Date Time"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.AccessPortalAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllParameters.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.AccessPortalAlarmEventAcknowledgmentUid).Value = Entity.AccessPortalAlarmEventAcknowledgmentUid;
      else
        AllParameters.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.AccessPortalAlarmEventAcknowledgmentUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid).Value = Entity.ActivityEventUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId).Value = Entity.DeviceEntityId;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid).Value = Entity.DeviceUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).Value = Entity.AccessPortalAlarmEventAcknowledgmentUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).Value = Entity.GalaxyPanelAlarmEventAcknowledgmentUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).Value = Entity.InputDeviceAlarmEventAcknowledgmentUid;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response).Value = Entity.Response;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response).Value = string.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId).Value = Entity.AckedByUserId;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName).Value = Entity.AckedByUserDisplayName;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName).Value = string.Empty;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime).Value = Entity.AckedDateTime;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime).Value = DateTimeOffset.Now;
     
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).SetAsNull == false)
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).Value = Entity.AckedUpdatedDateTime;
      else
        AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).Value = DateTimeOffset.Now;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid).IsNull == false)
        Entity.ActivityEventUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid).GetAsGuid();
      else
        Entity.ActivityEventUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId).IsNull == false)
        Entity.DeviceEntityId = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId).GetAsGuid();
      else
        Entity.DeviceEntityId = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid).IsNull == false)
        Entity.DeviceUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid).GetAsGuid();
      else
        Entity.DeviceUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.AccessPortalAlarmEventAcknowledgmentUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid).GetAsGuid();
      else
        Entity.AccessPortalAlarmEventAcknowledgmentUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.GalaxyPanelAlarmEventAcknowledgmentUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid).GetAsGuid();
      else
        Entity.GalaxyPanelAlarmEventAcknowledgmentUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.InputDeviceAlarmEventAcknowledgmentUid = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid).GetAsGuid();
      else
        Entity.InputDeviceAlarmEventAcknowledgmentUid = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response).IsNull == false)
        Entity.Response = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response).GetAsString();
      else
        Entity.Response = string.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId).IsNull == false)
        Entity.AckedByUserId = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId).GetAsGuid();
      else
        Entity.AckedByUserId = Guid.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName).IsNull == false)
        Entity.AckedByUserDisplayName = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName).GetAsString();
      else
        Entity.AckedByUserDisplayName = string.Empty;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime).IsNull == false)
        Entity.AckedDateTime = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime).GetAsDateTimeOffset();
      else
        Entity.AckedDateTime = DateTimeOffset.Now;

      if (AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).IsNull == false)
        Entity.AckedUpdatedDateTime = AllColumns.GetByName(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime).GetAsDateTimeOffset();
      else
        Entity.AckedUpdatedDateTime = DateTimeOffset.Now;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA</returns>
    public AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA CreateEntityFromDataRow(DataRow dr)
    {
      AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA entity = new AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA();

      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid] != DBNull.Value)
          entity.ActivityEventUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.ActivityEventUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId] != DBNull.Value)
          entity.DeviceEntityId = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceEntityId]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid] != DBNull.Value)
          entity.DeviceUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.DeviceUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid] != DBNull.Value)
          entity.AccessPortalAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid] != DBNull.Value)
          entity.GalaxyPanelAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid] != DBNull.Value)
          entity.InputDeviceAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response] != DBNull.Value)
          entity.Response = PDSAString.ConvertToStringTrim(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.Response]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId] != DBNull.Value)
          entity.AckedByUserId = PDSAProperty.ConvertToGuid(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserId]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName] != DBNull.Value)
          entity.AckedByUserDisplayName = PDSAString.ConvertToStringTrim(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedByUserDisplayName]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime] != DBNull.Value)
          entity.AckedDateTime = PDSAProperty.ConvertToDateTimeOffset(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedDateTime]);
      }
      if (dr.Table.Columns.Contains(AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime))
      {
        if (dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime] != DBNull.Value)
          entity.AckedUpdatedDateTime = PDSAProperty.ConvertToDateTimeOffset(dr[AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSAValidator.ColumnNames.AckedUpdatedDateTime]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string AccessPortalAlarmEventAcknowledgmentUid = "@AccessPortalAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
