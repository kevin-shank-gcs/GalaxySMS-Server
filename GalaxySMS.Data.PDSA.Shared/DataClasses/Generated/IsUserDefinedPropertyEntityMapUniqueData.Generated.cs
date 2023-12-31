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
  /// This class calls the stored procedure IsUserDefinedPropertyEntityMapUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsUserDefinedPropertyEntityMapUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsUserDefinedPropertyEntityMapUniquePDSAData class
    /// </summary>
    public IsUserDefinedPropertyEntityMapUniquePDSAData() : base()
    {
      Entity = new IsUserDefinedPropertyEntityMapUniquePDSA();
      ValidatorObject = new  IsUserDefinedPropertyEntityMapUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsUserDefinedPropertyEntityMapUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsUserDefinedPropertyEntityMapUniquePDSA</param>
    public IsUserDefinedPropertyEntityMapUniquePDSAData(IsUserDefinedPropertyEntityMapUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsUserDefinedPropertyEntityMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsUserDefinedPropertyEntityMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsUserDefinedPropertyEntityMapUniquePDSA</param>
    public IsUserDefinedPropertyEntityMapUniquePDSAData(PDSADataProvider dataProvider,
      IsUserDefinedPropertyEntityMapUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsUserDefinedPropertyEntityMapUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsUserDefinedPropertyEntityMapUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsUserDefinedPropertyEntityMapUniquePDSA</param>
    /// <param name="validator">An instance of a IsUserDefinedPropertyEntityMapUniquePDSAValidator</param>
    public IsUserDefinedPropertyEntityMapUniquePDSAData(PDSADataProvider dataProvider,
      IsUserDefinedPropertyEntityMapUniquePDSA entity, IsUserDefinedPropertyEntityMapUniquePDSAValidator validator)
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
    public IsUserDefinedPropertyEntityMapUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsUserDefinedPropertyEntityMapUniquePDSAData";
      StoredProcName = "IsUserDefinedPropertyEntityMapUnique";
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
      param.ParameterName = IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid).SetAsNull == false)
        AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid).Value = Entity.UserDefinedPropertyEntityMapUid;
      else
        AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).SetAsNull == false)
        AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      else
        AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsUserDefinedPropertyEntityMapUniquePDSA</returns>
    public IsUserDefinedPropertyEntityMapUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsUserDefinedPropertyEntityMapUniquePDSA entity = new IsUserDefinedPropertyEntityMapUniquePDSA();

      if (dr.Table.Columns.Contains(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsUserDefinedPropertyEntityMapUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserDefinedPropertyEntityMapUid'
    /// </summary>
    public static string UserDefinedPropertyEntityMapUid = "@UserDefinedPropertyEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
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
