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
  /// This class calls the stored procedure IsGalaxyInputDelayTypeUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsGalaxyInputDelayTypeUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsGalaxyInputDelayTypeUniquePDSAData class
    /// </summary>
    public IsGalaxyInputDelayTypeUniquePDSAData() : base()
    {
      Entity = new IsGalaxyInputDelayTypeUniquePDSA();
      ValidatorObject = new  IsGalaxyInputDelayTypeUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsGalaxyInputDelayTypeUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsGalaxyInputDelayTypeUniquePDSA</param>
    public IsGalaxyInputDelayTypeUniquePDSAData(IsGalaxyInputDelayTypeUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsGalaxyInputDelayTypeUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyInputDelayTypeUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyInputDelayTypeUniquePDSA</param>
    public IsGalaxyInputDelayTypeUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyInputDelayTypeUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsGalaxyInputDelayTypeUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyInputDelayTypeUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyInputDelayTypeUniquePDSA</param>
    /// <param name="validator">An instance of a IsGalaxyInputDelayTypeUniquePDSAValidator</param>
    public IsGalaxyInputDelayTypeUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyInputDelayTypeUniquePDSA entity, IsGalaxyInputDelayTypeUniquePDSAValidator validator)
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
    public IsGalaxyInputDelayTypeUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsGalaxyInputDelayTypeUniquePDSAData";
      StoredProcName = "IsGalaxyInputDelayTypeUnique";
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
      param.ParameterName = IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.GalaxyInputDelayTypeUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Code;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsGalaxyInputDelayTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.GalaxyInputDelayTypeUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.GalaxyInputDelayTypeUid).Value = Entity.GalaxyInputDelayTypeUid;
      else
        AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.GalaxyInputDelayTypeUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Code).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Code).Value = Entity.Code;
      else
        AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Code).Value = System.Data.SqlTypes.SqlInt16.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsGalaxyInputDelayTypeUniquePDSA</returns>
    public IsGalaxyInputDelayTypeUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsGalaxyInputDelayTypeUniquePDSA entity = new IsGalaxyInputDelayTypeUniquePDSA();

      if (dr.Table.Columns.Contains(IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsGalaxyInputDelayTypeUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInputDelayTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInputDelayTypeUid'
    /// </summary>
    public static string GalaxyInputDelayTypeUid = "@GalaxyInputDelayTypeUid";
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
