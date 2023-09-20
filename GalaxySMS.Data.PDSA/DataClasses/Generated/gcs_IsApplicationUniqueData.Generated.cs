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
  /// This class calls the stored procedure gcs_IsApplicationUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcs_IsApplicationUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcs_IsApplicationUniquePDSAData class
    /// </summary>
    public gcs_IsApplicationUniquePDSAData() : base()
    {
      Entity = new gcs_IsApplicationUniquePDSA();
      ValidatorObject = new  gcs_IsApplicationUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcs_IsApplicationUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcs_IsApplicationUniquePDSA</param>
    public gcs_IsApplicationUniquePDSAData(gcs_IsApplicationUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcs_IsApplicationUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsApplicationUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsApplicationUniquePDSA</param>
    public gcs_IsApplicationUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsApplicationUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcs_IsApplicationUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsApplicationUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsApplicationUniquePDSA</param>
    /// <param name="validator">An instance of a gcs_IsApplicationUniquePDSAValidator</param>
    public gcs_IsApplicationUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsApplicationUniquePDSA entity, gcs_IsApplicationUniquePDSAValidator validator)
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
    public gcs_IsApplicationUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcs_IsApplicationUniquePDSAData";
      StoredProcName = "gcs_IsApplicationUnique";
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
      param.ParameterName = gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsApplicationUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_gcs_IsApplicationUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationId).SetAsNull == false)
        AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationId).Value = Entity.ApplicationId;
      else
        AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationName).SetAsNull == false)
        AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationName).Value = Entity.ApplicationName;
      else
        AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.ApplicationName).Value = System.Data.SqlTypes.SqlString.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(gcs_IsApplicationUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcs_IsApplicationUniquePDSA</returns>
    public gcs_IsApplicationUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      gcs_IsApplicationUniquePDSA entity = new gcs_IsApplicationUniquePDSA();

      if (dr.Table.Columns.Contains(gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[gcs_IsApplicationUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsApplicationUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ApplicationId'
    /// </summary>
    public static string ApplicationId = "@ApplicationId";
    /// <summary>
    /// Returns '@ApplicationName'
    /// </summary>
    public static string ApplicationName = "@ApplicationName";
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
