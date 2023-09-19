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
  /// This class calls the stored procedure PanelDataPacketLog_InsertPDSAData
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class PanelDataPacketLog_InsertPDSAData : PDSAStoredProcExecute
  {
    #region Constructors
    /// <summary>
    /// Constructor for the PanelDataPacketLog_InsertPDSAData class
    /// </summary>
    public PanelDataPacketLog_InsertPDSAData() : base()
    {
      Entity = new PanelDataPacketLog_InsertPDSA();
      ValidatorObject = new  PanelDataPacketLog_InsertPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the PanelDataPacketLog_InsertPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a PanelDataPacketLog_InsertPDSA</param>
    public PanelDataPacketLog_InsertPDSAData(PanelDataPacketLog_InsertPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new PanelDataPacketLog_InsertPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the PanelDataPacketLog_InsertPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a PanelDataPacketLog_InsertPDSA</param>
    public PanelDataPacketLog_InsertPDSAData(PDSADataProvider dataProvider,
      PanelDataPacketLog_InsertPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  PanelDataPacketLog_InsertPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the PanelDataPacketLog_InsertPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a PanelDataPacketLog_InsertPDSA</param>
    /// <param name="validator">An instance of a PanelDataPacketLog_InsertPDSAValidator</param>
    public PanelDataPacketLog_InsertPDSAData(PDSADataProvider dataProvider,
      PanelDataPacketLog_InsertPDSA entity, PanelDataPacketLog_InsertPDSAValidator validator)
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
    public PanelDataPacketLog_InsertPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "PanelDataPacketLog_InsertPDSAData";
      StoredProcName = "PanelDataPacketLog_Insert";
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
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.Id;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.InsertDate;
      param.DBType = DbType.DateTimeOffset;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.UpdateDate;
      param.DBType = DbType.DateTimeOffset;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.Length;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.Distribute;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.ClusterId;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.PanelId;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.CpuId;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.BoardNumber;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.SectionNumber;
      param.DBType = DbType.Int16;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.SecondsFromWeekStart;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.Sequence;
      param.DBType = DbType.Int32;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.RawData;
      param.DBType = DbType.Binary;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.Direction;
      param.DBType = DbType.Boolean;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = PanelDataPacketLog_InsertPDSAData.ParameterNames.RETURNVALUE;
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
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id).Value = Entity.Id;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate).Value = System.Data.SqlTypes.SqlDateTime.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate).Value = System.Data.SqlTypes.SqlDateTime.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length).Value = Entity.Length;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute).Value = Entity.Distribute;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId).Value = Entity.ClusterId;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId).Value = Entity.PanelId;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId).Value = Entity.CpuId;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart).Value = Entity.SecondsFromWeekStart;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence).Value = Entity.Sequence;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence).Value = System.Data.SqlTypes.SqlInt32.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData).Value = Entity.RawData;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData).Value = System.Data.SqlTypes.SqlBinary.Null;
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction).SetAsNull == false)
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction).Value = Entity.Direction;
      else
        AllParameters.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction).Value = System.Data.SqlTypes.SqlBoolean.Null;
    }
    #endregion
    
    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(PanelDataPacketLog_InsertPDSAData.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(PanelDataPacketLog_InsertPDSAData.ParameterNames.RETURNVALUE).GetAsInteger();
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
    /// Contains static string properties that represent the name of each property in the PanelDataPacketLog_InsertPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@Id'
    /// </summary>
    public static string Id = "@Id";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@Length'
    /// </summary>
    public static string Length = "@Length";
    /// <summary>
    /// Returns '@Distribute'
    /// </summary>
    public static string Distribute = "@Distribute";
    /// <summary>
    /// Returns '@ClusterId'
    /// </summary>
    public static string ClusterId = "@ClusterId";
    /// <summary>
    /// Returns '@PanelId'
    /// </summary>
    public static string PanelId = "@PanelId";
    /// <summary>
    /// Returns '@CpuId'
    /// </summary>
    public static string CpuId = "@CpuId";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@SectionNumber'
    /// </summary>
    public static string SectionNumber = "@SectionNumber";
    /// <summary>
    /// Returns '@SecondsFromWeekStart'
    /// </summary>
    public static string SecondsFromWeekStart = "@SecondsFromWeekStart";
    /// <summary>
    /// Returns '@Sequence'
    /// </summary>
    public static string Sequence = "@Sequence";
    /// <summary>
    /// Returns '@RawData'
    /// </summary>
    public static string RawData = "@RawData";
    /// <summary>
    /// Returns '@Direction'
    /// </summary>
    public static string Direction = "@Direction";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
