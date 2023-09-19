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
  /// This class calls the stored procedure IsAssaAccessPointUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsAssaAccessPointUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsAssaAccessPointUniquePDSAData class
    /// </summary>
    public IsAssaAccessPointUniquePDSAData() : base()
    {
      Entity = new IsAssaAccessPointUniquePDSA();
      ValidatorObject = new  IsAssaAccessPointUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsAssaAccessPointUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsAssaAccessPointUniquePDSA</param>
    public IsAssaAccessPointUniquePDSAData(IsAssaAccessPointUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsAssaAccessPointUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAssaAccessPointUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAssaAccessPointUniquePDSA</param>
    public IsAssaAccessPointUniquePDSAData(PDSADataProvider dataProvider,
      IsAssaAccessPointUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsAssaAccessPointUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAssaAccessPointUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAssaAccessPointUniquePDSA</param>
    /// <param name="validator">An instance of a IsAssaAccessPointUniquePDSAValidator</param>
    public IsAssaAccessPointUniquePDSAData(PDSADataProvider dataProvider,
      IsAssaAccessPointUniquePDSA entity, IsAssaAccessPointUniquePDSAValidator validator)
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
    public IsAssaAccessPointUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsAssaAccessPointUniquePDSAData";
      StoredProcName = "IsAssaAccessPointUnique";
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
      param.ParameterName = IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid).SetAsNull == false)
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid).Value = Entity.AssaAccessPointUid;
      else
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid).SetAsNull == false)
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      else
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber).SetAsNull == false)
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber).Value = Entity.SerialNumber;
      else
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber).Value = System.Data.SqlTypes.SqlString.Null;
      if (AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId).SetAsNull == false)
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId).Value = Entity.AssaUniqueId;
      else
        AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsAssaAccessPointUniquePDSA</returns>
    public IsAssaAccessPointUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsAssaAccessPointUniquePDSA entity = new IsAssaAccessPointUniquePDSA();

      if (dr.Table.Columns.Contains(IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsAssaAccessPointUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaAccessPointUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaAccessPointUid'
    /// </summary>
    public static string AssaAccessPointUid = "@AssaAccessPointUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
    /// <summary>
    /// Returns '@AssaUniqueId'
    /// </summary>
    public static string AssaUniqueId = "@AssaUniqueId";
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
