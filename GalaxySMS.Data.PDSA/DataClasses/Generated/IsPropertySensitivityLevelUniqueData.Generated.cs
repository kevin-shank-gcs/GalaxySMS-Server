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
  /// This class calls the stored procedure IsPropertySensitivityLevelUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsPropertySensitivityLevelUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsPropertySensitivityLevelUniquePDSAData class
    /// </summary>
    public IsPropertySensitivityLevelUniquePDSAData() : base()
    {
      Entity = new IsPropertySensitivityLevelUniquePDSA();
      ValidatorObject = new  IsPropertySensitivityLevelUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsPropertySensitivityLevelUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsPropertySensitivityLevelUniquePDSA</param>
    public IsPropertySensitivityLevelUniquePDSAData(IsPropertySensitivityLevelUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsPropertySensitivityLevelUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsPropertySensitivityLevelUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsPropertySensitivityLevelUniquePDSA</param>
    public IsPropertySensitivityLevelUniquePDSAData(PDSADataProvider dataProvider,
      IsPropertySensitivityLevelUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsPropertySensitivityLevelUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsPropertySensitivityLevelUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsPropertySensitivityLevelUniquePDSA</param>
    /// <param name="validator">An instance of a IsPropertySensitivityLevelUniquePDSAValidator</param>
    public IsPropertySensitivityLevelUniquePDSAData(PDSADataProvider dataProvider,
      IsPropertySensitivityLevelUniquePDSA entity, IsPropertySensitivityLevelUniquePDSAValidator validator)
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
    public IsPropertySensitivityLevelUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsPropertySensitivityLevelUniquePDSAData";
      StoredProcName = "IsPropertySensitivityLevelUnique";
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
      param.ParameterName = IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsPropertySensitivityLevelUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid).SetAsNull == false)
        AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid).Value = Entity.PropertySensitivityLevelUid;
      else
        AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.PropertySensitivityLevelUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel).SetAsNull == false)
        AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel).Value = Entity.SensitivityLevel;
      else
        AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.SensitivityLevel).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display).SetAsNull == false)
        AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      else
        AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Display).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsPropertySensitivityLevelUniquePDSA</returns>
    public IsPropertySensitivityLevelUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsPropertySensitivityLevelUniquePDSA entity = new IsPropertySensitivityLevelUniquePDSA();

      if (dr.Table.Columns.Contains(IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsPropertySensitivityLevelUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPropertySensitivityLevelUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PropertySensitivityLevelUid'
    /// </summary>
    public static string PropertySensitivityLevelUid = "@PropertySensitivityLevelUid";
    /// <summary>
    /// Returns '@SensitivityLevel'
    /// </summary>
    public static string SensitivityLevel = "@SensitivityLevel";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
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
