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
  /// This class calls the stored procedure gcs_IsUserSettingUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcs_IsUserSettingUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcs_IsUserSettingUniquePDSAData class
    /// </summary>
    public gcs_IsUserSettingUniquePDSAData() : base()
    {
      Entity = new gcs_IsUserSettingUniquePDSA();
      ValidatorObject = new  gcs_IsUserSettingUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcs_IsUserSettingUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcs_IsUserSettingUniquePDSA</param>
    public gcs_IsUserSettingUniquePDSAData(gcs_IsUserSettingUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcs_IsUserSettingUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsUserSettingUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsUserSettingUniquePDSA</param>
    public gcs_IsUserSettingUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsUserSettingUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcs_IsUserSettingUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsUserSettingUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsUserSettingUniquePDSA</param>
    /// <param name="validator">An instance of a gcs_IsUserSettingUniquePDSAValidator</param>
    public gcs_IsUserSettingUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsUserSettingUniquePDSA entity, gcs_IsUserSettingUniquePDSAValidator validator)
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
    public gcs_IsUserSettingUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcs_IsUserSettingUniquePDSAData";
      StoredProcName = "gcs_IsUserSettingUnique";
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
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_gcs_IsUserSettingUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId).SetAsNull == false)
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId).Value = Entity.UserSettingId;
      else
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserSettingId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId).SetAsNull == false)
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      else
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.UserId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId).SetAsNull == false)
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      else
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.ApplicationId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category).SetAsNull == false)
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category).Value = Entity.Category;
      else
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Category).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey).SetAsNull == false)
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey).Value = Entity.SettingKey;
      else
        AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.SettingKey).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(gcs_IsUserSettingUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      else
        Entity.Result = 0;
    }
    #endregion
    
    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcs_IsUserSettingUniquePDSA</returns>
    public gcs_IsUserSettingUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      gcs_IsUserSettingUniquePDSA entity = new gcs_IsUserSettingUniquePDSA();

      if (dr.Table.Columns.Contains(gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[gcs_IsUserSettingUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsUserSettingUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserSettingId'
    /// </summary>
    public static string UserSettingId = "@UserSettingId";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@Category'
    /// </summary>
    public static string Category = "@Category";
    /// <summary>
    /// Returns '@SettingKey'
    /// </summary>
    public static string SettingKey = "@SettingKey";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
