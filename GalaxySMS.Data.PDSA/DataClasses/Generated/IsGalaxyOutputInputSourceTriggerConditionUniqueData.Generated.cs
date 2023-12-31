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
  /// This class calls the stored procedure IsGalaxyOutputInputSourceTriggerConditionUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData class
    /// </summary>
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData() : base()
    {
      Entity = new IsGalaxyOutputInputSourceTriggerConditionUniquePDSA();
      ValidatorObject = new  IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsGalaxyOutputInputSourceTriggerConditionUniquePDSA</param>
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData(IsGalaxyOutputInputSourceTriggerConditionUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyOutputInputSourceTriggerConditionUniquePDSA</param>
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyOutputInputSourceTriggerConditionUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyOutputInputSourceTriggerConditionUniquePDSA</param>
    /// <param name="validator">An instance of a IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator</param>
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyOutputInputSourceTriggerConditionUniquePDSA entity, IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator validator)
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
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsGalaxyOutputInputSourceTriggerConditionUniquePDSAData";
      StoredProcName = "IsGalaxyOutputInputSourceTriggerConditionUnique";
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
      param.ParameterName = IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceTriggerConditionUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Code;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsGalaxyOutputInputSourceTriggerConditionUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceTriggerConditionUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceTriggerConditionUid).Value = Entity.GalaxyOutputInputSourceTriggerConditionUid;
      else
        AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceTriggerConditionUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Code).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Code).Value = Entity.Code;
      else
        AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Code).Value = System.Data.SqlTypes.SqlInt16.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsGalaxyOutputInputSourceTriggerConditionUniquePDSA</returns>
    public IsGalaxyOutputInputSourceTriggerConditionUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsGalaxyOutputInputSourceTriggerConditionUniquePDSA entity = new IsGalaxyOutputInputSourceTriggerConditionUniquePDSA();

      if (dr.Table.Columns.Contains(IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsGalaxyOutputInputSourceTriggerConditionUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyOutputInputSourceTriggerConditionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyOutputInputSourceTriggerConditionUid'
    /// </summary>
    public static string GalaxyOutputInputSourceTriggerConditionUid = "@GalaxyOutputInputSourceTriggerConditionUid";
    /// <summary>
    /// Returns '@Code'
    /// </summary>
    public static string Code = "@Code";
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
