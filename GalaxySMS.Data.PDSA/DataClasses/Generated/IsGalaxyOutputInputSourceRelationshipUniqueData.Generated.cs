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
  /// This class calls the stored procedure IsGalaxyOutputInputSourceRelationshipUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsGalaxyOutputInputSourceRelationshipUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceRelationshipUniquePDSAData class
    /// </summary>
    public IsGalaxyOutputInputSourceRelationshipUniquePDSAData() : base()
    {
      Entity = new IsGalaxyOutputInputSourceRelationshipUniquePDSA();
      ValidatorObject = new  IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceRelationshipUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsGalaxyOutputInputSourceRelationshipUniquePDSA</param>
    public IsGalaxyOutputInputSourceRelationshipUniquePDSAData(IsGalaxyOutputInputSourceRelationshipUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceRelationshipUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyOutputInputSourceRelationshipUniquePDSA</param>
    public IsGalaxyOutputInputSourceRelationshipUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyOutputInputSourceRelationshipUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyOutputInputSourceRelationshipUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyOutputInputSourceRelationshipUniquePDSA</param>
    /// <param name="validator">An instance of a IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator</param>
    public IsGalaxyOutputInputSourceRelationshipUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyOutputInputSourceRelationshipUniquePDSA entity, IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator validator)
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
    public IsGalaxyOutputInputSourceRelationshipUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsGalaxyOutputInputSourceRelationshipUniquePDSAData";
      StoredProcName = "IsGalaxyOutputInputSourceRelationshipUnique";
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
      param.ParameterName = IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceRelationshipUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Code;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsGalaxyOutputInputSourceRelationshipUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceRelationshipUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceRelationshipUid).Value = Entity.GalaxyOutputInputSourceRelationshipUid;
      else
        AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.GalaxyOutputInputSourceRelationshipUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Code).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Code).Value = Entity.Code;
      else
        AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Code).Value = System.Data.SqlTypes.SqlInt16.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsGalaxyOutputInputSourceRelationshipUniquePDSA</returns>
    public IsGalaxyOutputInputSourceRelationshipUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsGalaxyOutputInputSourceRelationshipUniquePDSA entity = new IsGalaxyOutputInputSourceRelationshipUniquePDSA();

      if (dr.Table.Columns.Contains(IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsGalaxyOutputInputSourceRelationshipUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyOutputInputSourceRelationshipUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyOutputInputSourceRelationshipUid'
    /// </summary>
    public static string GalaxyOutputInputSourceRelationshipUid = "@GalaxyOutputInputSourceRelationshipUid";
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
