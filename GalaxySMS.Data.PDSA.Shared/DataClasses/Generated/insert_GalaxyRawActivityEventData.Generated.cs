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
  /// This class calls the stored procedure insert_GalaxyRawActivityEventPDSAData
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class insert_GalaxyRawActivityEventPDSAData : PDSAStoredProcExecute
  {
    #region Constructors
    /// <summary>
    /// Constructor for the insert_GalaxyRawActivityEventPDSAData class
    /// </summary>
    public insert_GalaxyRawActivityEventPDSAData() : base()
    {
      Entity = new insert_GalaxyRawActivityEventPDSA();
      ValidatorObject = new  insert_GalaxyRawActivityEventPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the insert_GalaxyRawActivityEventPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a insert_GalaxyRawActivityEventPDSA</param>
    public insert_GalaxyRawActivityEventPDSAData(insert_GalaxyRawActivityEventPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new insert_GalaxyRawActivityEventPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the insert_GalaxyRawActivityEventPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a insert_GalaxyRawActivityEventPDSA</param>
    public insert_GalaxyRawActivityEventPDSAData(PDSADataProvider dataProvider,
      insert_GalaxyRawActivityEventPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  insert_GalaxyRawActivityEventPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the insert_GalaxyRawActivityEventPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a insert_GalaxyRawActivityEventPDSA</param>
    /// <param name="validator">An instance of a insert_GalaxyRawActivityEventPDSAValidator</param>
    public insert_GalaxyRawActivityEventPDSAData(PDSADataProvider dataProvider,
      insert_GalaxyRawActivityEventPDSA entity, insert_GalaxyRawActivityEventPDSAValidator validator)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = validator;

      Init();
    }
    #endregion

    #region Public Property
    /// <summary>
    /// Get/Set the Entity class that will be used to get and set parameters and columns for this data class.
    /// </summary>
    public insert_GalaxyRawActivityEventPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "insert_GalaxyRawActivityEventPDSAData";
      StoredProcName = "insert_GalaxyRawActivityEvent";
      SchemaName = "GCS";

      // Move validator Properties collection into the Parameters collection
      PropertiesToParameters(ValidatorObject.Properties);

      // Create Parameters
      InitParameters();
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
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.GalaxyRawActivityEventUid;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.CpuUid;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.InsertDate;
      param.DBType = DbType.DateTimeOffset;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.ClusterGroupId;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.ClusterNumber;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.PanelNumber;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.CpuNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.EventDateTime;
      param.DBType = DbType.DateTimeOffset;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.EventType;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.BufferIndex;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.CredentialBytes;
      param.DBType = DbType.Binary;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.Pin;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.BitCount;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.InputOutputGroupNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.BoardNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.SectionNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.ModuleNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.NodeNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.RawData;
      param.DBType = DbType.Binary;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = insert_GalaxyRawActivityEventPDSAData.ParameterNames.RETURNVALUE;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.ReturnValue;
      AllParameters.Add(param);


      AddReturnValueParameterToCollection();
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid).Value = Entity.GalaxyRawActivityEventUid;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate).Value = System.Data.SqlTypes.SqlDateTime.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime).Value = Entity.EventDateTime;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType).Value = Entity.EventType;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes).Value = Entity.CredentialBytes;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes).Value = System.Data.SqlTypes.SqlBinary.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin).Value = Entity.Pin;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount).Value = Entity.BitCount;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).Value = Entity.InputOutputGroupNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber).Value = Entity.ModuleNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData).SetAsNull == false)
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData).Value = Entity.RawData;
      else
        AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData).Value = System.Data.SqlTypes.SqlBinary.Null;
    }
    #endregion
    
    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAData.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(insert_GalaxyRawActivityEventPDSAData.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
    }
    #endregion
        
    #region SetDirtyFlag Methods
    /// <summary>
    /// This is called with a 'false' value after each successful Insert/Update method call.
    /// </summary>
    /// <param name="isDirty">Called with 'false' by default</param>
    protected override void SetDirtyFlag(bool isDirty)
    {
      Entity.IsDirty = isDirty;
    }
    #endregion
       
    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_GalaxyRawActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyRawActivityEventUid'
    /// </summary>
    public static string GalaxyRawActivityEventUid = "@GalaxyRawActivityEventUid";
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@PanelNumber'
    /// </summary>
    public static string PanelNumber = "@PanelNumber";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@EventDateTime'
    /// </summary>
    public static string EventDateTime = "@EventDateTime";
    /// <summary>
    /// Returns '@EventType'
    /// </summary>
    public static string EventType = "@EventType";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
    /// <summary>
    /// Returns '@CredentialBytes'
    /// </summary>
    public static string CredentialBytes = "@CredentialBytes";
    /// <summary>
    /// Returns '@Pin'
    /// </summary>
    public static string Pin = "@Pin";
    /// <summary>
    /// Returns '@BitCount'
    /// </summary>
    public static string BitCount = "@BitCount";
    /// <summary>
    /// Returns '@InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "@InputOutputGroupNumber";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@SectionNumber'
    /// </summary>
    public static string SectionNumber = "@SectionNumber";
    /// <summary>
    /// Returns '@ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "@ModuleNumber";
    /// <summary>
    /// Returns '@NodeNumber'
    /// </summary>
    public static string NodeNumber = "@NodeNumber";
    /// <summary>
    /// Returns '@RawData'
    /// </summary>
    public static string RawData = "@RawData";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
