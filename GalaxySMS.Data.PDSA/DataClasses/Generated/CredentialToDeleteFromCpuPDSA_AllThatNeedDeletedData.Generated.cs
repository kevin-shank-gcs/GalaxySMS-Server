using System;
using System.Data;
using System.Text;

using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.DataLayer
{
  /// <summary>
  /// This class calls the stored procedure CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData class
    /// </summary>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData() : base()
    {
      Entity = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA();

      Init();
    }

    /// <summary>
    /// Constructor for the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA</param>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA entity) : base()
    {
      Entity = entity;
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA</param>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData(PDSADataProvider dataProvider,
      CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
            
      Init();
    }
    #endregion

    #region Public Property
    /// <summary>
    /// Get/Set the Entity class that will be used to get and set properties/fields for this data class.
    /// </summary>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData";
      StoredProcName = "CredentialToDeleteFromCpuPDSA_AllThatNeedDeleted";
      SchemaName = "GCS";


      // Create Data Columns
      InitDataColumns();
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
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_CredentialToDeleteFromCpuUid_Header", "Credential To Delete From Cpu Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_CardBinaryData_Header", "Card Binary Data"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_DeletedFromDatabaseDate_Header", "Deleted From Database Date"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_DeletedFromCpuDate_Header", "Deleted From Cpu Date"), false, typeof(DateTimeOffset), DbType.DateTimeOffset);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_ServerAddress_Header", "Server Address"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected, GetResourceMessage("GCS_CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), DbType.Boolean);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid).Value = Entity.CredentialToDeleteFromCpuUid;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid).Value = Guid.Empty;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid).Value = Entity.CpuUid;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid).Value = Guid.Empty;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData).Value = Entity.CardBinaryData;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData).Value = string.Empty;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate).Value = Entity.DeletedFromDatabaseDate;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate).Value = DateTimeOffset.Now;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate).Value = Entity.DeletedFromCpuDate;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate).Value = null;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber).Value = 0;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber).Value = 0;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber).Value = Entity.CpuNumber;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber).Value = 0;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId).Value = 0;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress).Value = Entity.ServerAddress;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress).Value = string.Empty;

      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected).SetAsNull == false)
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected).Value = Entity.IsConnected;
      else
        AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected).Value = false;

    }
    #endregion

    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid).IsNull == false)
        Entity.CredentialToDeleteFromCpuUid = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid).GetAsGuid();
      else
        Entity.CredentialToDeleteFromCpuUid = Guid.Empty;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid).GetAsGuid();
      else
        Entity.CpuUid = Guid.Empty;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData).IsNull == false)
        Entity.CardBinaryData = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData).GetAsByteArray();
      else
        Entity.CardBinaryData = null;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate).IsNull == false)
        Entity.DeletedFromDatabaseDate = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate).GetAsDateTimeOffset();
      else
        Entity.DeletedFromDatabaseDate = DateTimeOffset.Now;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate).IsNull == false)
        Entity.DeletedFromCpuDate = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate).GetAsDateTimeOffset();
      else
        Entity.DeletedFromCpuDate = null;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber).GetAsInteger();
      else
        Entity.ClusterNumber = 0;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber).GetAsInteger();
      else
        Entity.PanelNumber = 0;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber).GetAsShort();
      else
        Entity.CpuNumber = 0;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId).GetAsInteger();
      else
        Entity.ClusterGroupId = 0;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress).IsNull == false)
        Entity.ServerAddress = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress).GetAsString();
      else
        Entity.ServerAddress = string.Empty;
      if (AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected).IsNull == false)
        Entity.IsConnected = AllColumns.GetByName(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected).GetAsBool();
      else
        Entity.IsConnected = false;
    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA</returns>
    public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA CreateEntityFromDataRow(System.Data.DataRow dr)
    {
      CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA entity = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA();

      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid] != DBNull.Value)
          entity.CredentialToDeleteFromCpuUid = PDSAProperty.ConvertToGuid(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CredentialToDeleteFromCpuUid]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid] != DBNull.Value)
          entity.CpuUid = PDSAProperty.ConvertToGuid(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuUid]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData] != DBNull.Value)
          entity.CardBinaryData = (byte[])dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData];//PDSAString.ConvertToStringTrim(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CardBinaryData]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate] != DBNull.Value)
          entity.DeletedFromDatabaseDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromDatabaseDate]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate] != DBNull.Value)
          entity.DeletedFromCpuDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.DeletedFromCpuDate]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber] != DBNull.Value)
          entity.ClusterNumber = Convert.ToInt32(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterNumber]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber] != DBNull.Value)
          entity.PanelNumber = Convert.ToInt32(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.PanelNumber]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber] != DBNull.Value)
          entity.CpuNumber = Convert.ToInt16(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.CpuNumber]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId] != DBNull.Value)
          entity.ClusterGroupId = Convert.ToInt32(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ClusterGroupId]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress] != DBNull.Value)
          entity.ServerAddress = PDSAString.ConvertToStringTrim(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.ServerAddress]);
      }
      if (dr.Table.Columns.Contains(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected))
      {
        if (dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected] != DBNull.Value)
          entity.IsConnected = Convert.ToBoolean(dr[CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData.ColumnNames.IsConnected]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion
 
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CredentialToDeleteFromCpuUid'
    /// </summary>
    public static string CredentialToDeleteFromCpuUid = "CredentialToDeleteFromCpuUid";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'CardBinaryData'
    /// </summary>
    public static string CardBinaryData = "CardBinaryData";
    /// <summary>
    /// Returns 'DeletedFromDatabaseDate'
    /// </summary>
    public static string DeletedFromDatabaseDate = "DeletedFromDatabaseDate";
    /// <summary>
    /// Returns 'DeletedFromCpuDate'
    /// </summary>
    public static string DeletedFromCpuDate = "DeletedFromCpuDate";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    }
    #endregion

 }
}
