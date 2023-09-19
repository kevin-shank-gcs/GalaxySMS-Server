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
  /// This class calls the stored procedure gcs_IsBinaryResourceUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class gcs_IsBinaryResourceUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the gcs_IsBinaryResourceUniquePDSAData class
    /// </summary>
    public gcs_IsBinaryResourceUniquePDSAData() : base()
    {
      Entity = new gcs_IsBinaryResourceUniquePDSA();
      ValidatorObject = new  gcs_IsBinaryResourceUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the gcs_IsBinaryResourceUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a gcs_IsBinaryResourceUniquePDSA</param>
    public gcs_IsBinaryResourceUniquePDSAData(gcs_IsBinaryResourceUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new gcs_IsBinaryResourceUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsBinaryResourceUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsBinaryResourceUniquePDSA</param>
    public gcs_IsBinaryResourceUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsBinaryResourceUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  gcs_IsBinaryResourceUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the gcs_IsBinaryResourceUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a gcs_IsBinaryResourceUniquePDSA</param>
    /// <param name="validator">An instance of a gcs_IsBinaryResourceUniquePDSAValidator</param>
    public gcs_IsBinaryResourceUniquePDSAData(PDSADataProvider dataProvider,
      gcs_IsBinaryResourceUniquePDSA entity, gcs_IsBinaryResourceUniquePDSAValidator validator)
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
    public gcs_IsBinaryResourceUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "gcs_IsBinaryResourceUniquePDSAData";
      StoredProcName = "gcs_IsBinaryResourceUnique";
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
      param.ParameterName = gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_gcs_IsBinaryResourceUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid).SetAsNull == false)
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      else
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.BinaryResourceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType).SetAsNull == false)
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType).Value = Entity.DataType;
      else
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.DataType).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category).SetAsNull == false)
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category).Value = Entity.Category;
      else
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Category).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag).SetAsNull == false)
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      else
        AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Tag).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>gcs_IsBinaryResourceUniquePDSA</returns>
    public gcs_IsBinaryResourceUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      gcs_IsBinaryResourceUniquePDSA entity = new gcs_IsBinaryResourceUniquePDSA();

      if (dr.Table.Columns.Contains(gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[gcs_IsBinaryResourceUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsBinaryResourceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "@BinaryResourceUid";
    /// <summary>
    /// Returns '@DataType'
    /// </summary>
    public static string DataType = "@DataType";
    /// <summary>
    /// Returns '@Category'
    /// </summary>
    public static string Category = "@Category";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
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
