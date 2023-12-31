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
  /// This class calls the stored procedure AccessGroup_GetPanelLoadDataChangesForCpuPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class AccessGroup_GetPanelLoadDataChangesForCpuPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AccessGroup_GetPanelLoadDataChangesForCpuPDSAData class
    /// </summary>
    public AccessGroup_GetPanelLoadDataChangesForCpuPDSAData() : base()
    {
      Entity = new AccessGroup_GetPanelLoadDataChangesForCpuPDSA();
      ValidatorObject = new  AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AccessGroup_GetPanelLoadDataChangesForCpuPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AccessGroup_GetPanelLoadDataChangesForCpuPDSA</param>
    public AccessGroup_GetPanelLoadDataChangesForCpuPDSAData(AccessGroup_GetPanelLoadDataChangesForCpuPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessGroup_GetPanelLoadDataChangesForCpuPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessGroup_GetPanelLoadDataChangesForCpuPDSA</param>
    public AccessGroup_GetPanelLoadDataChangesForCpuPDSAData(PDSADataProvider dataProvider,
      AccessGroup_GetPanelLoadDataChangesForCpuPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AccessGroup_GetPanelLoadDataChangesForCpuPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AccessGroup_GetPanelLoadDataChangesForCpuPDSA</param>
    /// <param name="validator">An instance of a AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator</param>
    public AccessGroup_GetPanelLoadDataChangesForCpuPDSAData(PDSADataProvider dataProvider,
      AccessGroup_GetPanelLoadDataChangesForCpuPDSA entity, AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator validator)
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
    public AccessGroup_GetPanelLoadDataChangesForCpuPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "AccessGroup_GetPanelLoadDataChangesForCpuPDSAData";
      StoredProcName = "AccessGroup_GetPanelLoadDataChangesForCpu";
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
      param.ParameterName = AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.CpuUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.ServerAddress;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.IsConnected;
      param.DBType = DbType.Boolean;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_AccessGroupName_Header", "Access Group Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_AccessGroupNumber_Header", "Access Group Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_ActivationDate_Header", "Activation Date"), false, typeof(DateTime), DbType.DateTime);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_ExpirationDate_Header", "Expiration Date"), false, typeof(DateTime), DbType.DateTime);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_IsEnabled_Header", "Is Enabled"), false, typeof(bool), DbType.Boolean);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_CrisisModeAccessGroupUid_Header", "Crisis Mode Access Group Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_CrisisModeAccessGroupName_Header", "Crisis Mode Access Group Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_CrisisModeAccessGroupNumber_Header", "Crisis Mode Access Group Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_CurrentTimeForCluster_Header", "Current Time For Cluster"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_AccessGroupLoadToCpuUid_Header", "Access Group Load To Cpu Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_ServerAddress_Header", "Server Address"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesForCpuPDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), DbType.Boolean);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.CpuUid).SetAsNull == false)
        AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      else
        AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.CpuUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.ServerAddress).SetAsNull == false)
        AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.ServerAddress).Value = Entity.ServerAddress;
      else
        AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.ServerAddress).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.IsConnected).SetAsNull == false)
        AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.IsConnected).Value = Entity.IsConnected;
      else
        AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.IsConnected).Value = System.Data.SqlTypes.SqlBoolean.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName).Value = Entity.AccessGroupName;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName).Value = string.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber).Value = Entity.AccessGroupNumber;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber).Value = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate)
              .SetAsNull == false)
          AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate)
              .Value = Entity.ActivationDate;
      else
          AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate)
              .Value = null;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate)
              .SetAsNull == false)
          AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate)
              .Value = Entity.ExpirationDate;
      else
          AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate)
              .Value = null;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled).Value = Entity.IsEnabled;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled).Value = false;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid).Value = Entity.CrisisModeAccessGroupUid;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName).Value = Entity.CrisisModeAccessGroupName;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName).Value = string.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber).Value = Entity.CrisisModeAccessGroupNumber;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber).Value = 0;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster).Value = Entity.CurrentTimeForCluster;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster).Value = DateTimeOffset.Now;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId).Value = 0;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber).Value = 0;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber).Value = 0;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber).Value = Entity.CpuNumber;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber).Value = 0;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid).Value = Entity.AccessGroupLoadToCpuUid;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid).Value = Guid.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress).Value = Entity.ServerAddress;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress).Value = string.Empty;
     
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected).SetAsNull == false)
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected).Value = Entity.IsConnected;
      else
        AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected).Value = false;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid).GetAsGuid();
      else
        Entity.AccessGroupUid = Guid.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      else
        Entity.ClusterUid = Guid.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName).IsNull == false)
        Entity.AccessGroupName = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName).GetAsString();
      else
        Entity.AccessGroupName = string.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber).IsNull == false)
        Entity.AccessGroupNumber = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber).GetAsInteger();
      else
        Entity.AccessGroupNumber = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate).IsNull == false)
        Entity.ActivationDate = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate).GetAsDate();
      else
        Entity.ActivationDate = null;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate).IsNull == false)
        Entity.ExpirationDate = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate).GetAsDate();
      else
        Entity.ExpirationDate = null;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled).IsNull == false)
        Entity.IsEnabled = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled).GetAsBool();
      else
        Entity.IsEnabled = false;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid).IsNull == false)
        Entity.CrisisModeAccessGroupUid = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid).GetAsGuid();
      else
        Entity.CrisisModeAccessGroupUid = Guid.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName).IsNull == false)
        Entity.CrisisModeAccessGroupName = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName).GetAsString();
      else
        Entity.CrisisModeAccessGroupName = string.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber).IsNull == false)
        Entity.CrisisModeAccessGroupNumber = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber).GetAsInteger();
      else
        Entity.CrisisModeAccessGroupNumber = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster).IsNull == false)
        Entity.CurrentTimeForCluster = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster).GetAsDateTimeOffset();
      else
        Entity.CurrentTimeForCluster = DateTimeOffset.Now;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      else
        Entity.ClusterGroupId = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      else
        Entity.ClusterNumber = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      else
        Entity.PanelNumber = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      else
        Entity.GalaxyPanelUid = Guid.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber).GetAsShort();
      else
        Entity.CpuNumber = 0;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      else
        Entity.CpuUid = Guid.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid).IsNull == false)
        Entity.AccessGroupLoadToCpuUid = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid).GetAsGuid();
      else
        Entity.AccessGroupLoadToCpuUid = Guid.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress).IsNull == false)
        Entity.ServerAddress = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress).GetAsString();
      else
        Entity.ServerAddress = string.Empty;

      if (AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected).IsNull == false)
        Entity.IsConnected = AllColumns.GetByName(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected).GetAsBool();
      else
        Entity.IsConnected = false;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AccessGroup_GetPanelLoadDataChangesForCpuPDSA</returns>
    public AccessGroup_GetPanelLoadDataChangesForCpuPDSA CreateEntityFromDataRow(DataRow dr)
    {
      AccessGroup_GetPanelLoadDataChangesForCpuPDSA entity = new AccessGroup_GetPanelLoadDataChangesForCpuPDSA();

      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid] != DBNull.Value)
          entity.AccessGroupUid = PDSAProperty.ConvertToGuid(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid] != DBNull.Value)
          entity.ClusterUid = PDSAProperty.ConvertToGuid(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName] != DBNull.Value)
          entity.AccessGroupName = PDSAString.ConvertToStringTrim(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber] != DBNull.Value)
          entity.AccessGroupNumber = Convert.ToInt32(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate] != DBNull.Value)
          entity.ActivationDate = Convert.ToDateTime(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate] != DBNull.Value)
          entity.ExpirationDate = Convert.ToDateTime(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled] != DBNull.Value)
          entity.IsEnabled = Convert.ToBoolean(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid] != DBNull.Value)
          entity.CrisisModeAccessGroupUid = PDSAProperty.ConvertToGuid(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName] != DBNull.Value)
          entity.CrisisModeAccessGroupName = PDSAString.ConvertToStringTrim(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber] != DBNull.Value)
          entity.CrisisModeAccessGroupNumber = Convert.ToInt32(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster] != DBNull.Value)
          entity.CurrentTimeForCluster = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId] != DBNull.Value)
          entity.ClusterGroupId = Convert.ToInt32(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber] != DBNull.Value)
          entity.ClusterNumber = Convert.ToInt32(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber] != DBNull.Value)
          entity.PanelNumber = Convert.ToInt32(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid] != DBNull.Value)
          entity.GalaxyPanelUid = PDSAProperty.ConvertToGuid(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber] != DBNull.Value)
          entity.CpuNumber = Convert.ToInt16(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid] != DBNull.Value)
          entity.CpuUid = PDSAProperty.ConvertToGuid(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid] != DBNull.Value)
          entity.AccessGroupLoadToCpuUid = PDSAProperty.ConvertToGuid(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress] != DBNull.Value)
          entity.ServerAddress = PDSAString.ConvertToStringTrim(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress]);
      }
      if (dr.Table.Columns.Contains(AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected))
      {
        if (dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected] != DBNull.Value)
          entity.IsConnected = Convert.ToBoolean(dr[AccessGroup_GetPanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPanelLoadDataChangesForCpuPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@ServerAddress'
    /// </summary>
    public static string ServerAddress = "@ServerAddress";
    /// <summary>
    /// Returns '@IsConnected'
    /// </summary>
    public static string IsConnected = "@IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
