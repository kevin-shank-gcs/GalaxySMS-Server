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
  /// This class calls the stored procedure gcsAudit_InsertPDSAData
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcsAudit_InsertPDSAData : PDSAStoredProcExecute
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcsAudit_InsertPDSAData class
    /// </summary>
    public gcsAudit_InsertPDSAData() : base()
    {
      Entity = new gcsAudit_InsertPDSA();
      ValidatorObject = new  gcsAudit_InsertPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcsAudit_InsertPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcsAudit_InsertPDSA</param>
    public gcsAudit_InsertPDSAData(gcsAudit_InsertPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcsAudit_InsertPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsAudit_InsertPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsAudit_InsertPDSA</param>
    public gcsAudit_InsertPDSAData(PDSADataProvider dataProvider,
      gcsAudit_InsertPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcsAudit_InsertPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcsAudit_InsertPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcsAudit_InsertPDSA</param>
    /// <param name="validator">An instance of a gcsAudit_InsertPDSAValidator</param>
    public gcsAudit_InsertPDSAData(PDSADataProvider dataProvider,
      gcsAudit_InsertPDSA entity, gcsAudit_InsertPDSAValidator validator)
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
    public gcsAudit_InsertPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcsAudit_InsertPDSAData";
      StoredProcName = "gcsAudit_Insert";
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
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.AuditId;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.TransactionId;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.TableName;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.OperationType;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.PrimaryKeyColumn;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.PrimaryKeyValue;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.RecordTag;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.AuditXml;
      param.DBType = DbType.Xml;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.ColumnName;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.OriginalValue;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.NewValue;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.OriginalBinaryValue;
      param.DBType = DbType.Binary;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.NewBinaryValue;
      param.DBType = DbType.Binary;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.InsertName;
      param.DBType = DbType.String;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.InsertDate;
      param.DBType = DbType.DateTimeOffset;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.UserId;
      param.DBType = DbType.Guid;
      param.IsRefCursor = false;
      param.ParamDirection = ParameterDirection.Input;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcsAudit_InsertPDSAData.ParameterNames.RETURNVALUE;
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
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId).Value = Entity.AuditId;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId).Value = Entity.TransactionId;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TransactionId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TableName).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TableName).Value = Entity.TableName;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.TableName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType).Value = Entity.OperationType;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OperationType).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn).Value = Entity.PrimaryKeyColumn;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyColumn).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue).Value = Entity.PrimaryKeyValue;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.PrimaryKeyValue).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag).Value = Entity.RecordTag;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.RecordTag).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml).Value = Entity.AuditXml;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.AuditXml).Value = System.Data.SqlTypes.SqlXml.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName).Value = Entity.ColumnName;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.ColumnName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue).Value = Entity.OriginalValue;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalValue).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue).Value = Entity.NewValue;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewValue).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue).Value = Entity.OriginalBinaryValue;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.OriginalBinaryValue).Value = System.Data.SqlTypes.SqlBinary.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue).Value = Entity.NewBinaryValue;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.NewBinaryValue).Value = System.Data.SqlTypes.SqlBinary.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName).Value = Entity.InsertName;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertName).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.InsertDate).Value = System.Data.SqlTypes.SqlDateTime.Null;
      if (AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.UserId).SetAsNull == false)
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      else
        AllParameters.GetByName(gcsAudit_InsertPDSAValidator.ParameterNames.UserId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion
    
    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcsAudit_InsertPDSAData.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcsAudit_InsertPDSAData.ParameterNames.RETURNVALUE).GetAsInteger();
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
    /// Contains static string properties that represent the name of each property in the gcsAudit_InsertPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AuditId'
    /// </summary>
    public static string AuditId = "@AuditId";
    /// <summary>
    /// Returns '@TransactionId'
    /// </summary>
    public static string TransactionId = "@TransactionId";
    /// <summary>
    /// Returns '@TableName'
    /// </summary>
    public static string TableName = "@TableName";
    /// <summary>
    /// Returns '@OperationType'
    /// </summary>
    public static string OperationType = "@OperationType";
    /// <summary>
    /// Returns '@PrimaryKeyColumn'
    /// </summary>
    public static string PrimaryKeyColumn = "@PrimaryKeyColumn";
    /// <summary>
    /// Returns '@PrimaryKeyValue'
    /// </summary>
    public static string PrimaryKeyValue = "@PrimaryKeyValue";
    /// <summary>
    /// Returns '@RecordTag'
    /// </summary>
    public static string RecordTag = "@RecordTag";
    /// <summary>
    /// Returns '@AuditXml'
    /// </summary>
    public static string AuditXml = "@AuditXml";
    /// <summary>
    /// Returns '@ColumnName'
    /// </summary>
    public static string ColumnName = "@ColumnName";
    /// <summary>
    /// Returns '@OriginalValue'
    /// </summary>
    public static string OriginalValue = "@OriginalValue";
    /// <summary>
    /// Returns '@NewValue'
    /// </summary>
    public static string NewValue = "@NewValue";
    /// <summary>
    /// Returns '@OriginalBinaryValue'
    /// </summary>
    public static string OriginalBinaryValue = "@OriginalBinaryValue";
    /// <summary>
    /// Returns '@NewBinaryValue'
    /// </summary>
    public static string NewBinaryValue = "@NewBinaryValue";
    /// <summary>
    /// Returns '@InsertName'
    /// </summary>
    public static string InsertName = "@InsertName";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
