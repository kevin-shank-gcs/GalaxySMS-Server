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
  /// This class calls the stored procedure IsRoleRegionUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsRoleRegionUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsRoleRegionUniquePDSAData class
    /// </summary>
    public IsRoleRegionUniquePDSAData() : base()
    {
      Entity = new IsRoleRegionUniquePDSA();
      ValidatorObject = new  IsRoleRegionUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsRoleRegionUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsRoleRegionUniquePDSA</param>
    public IsRoleRegionUniquePDSAData(IsRoleRegionUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsRoleRegionUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleRegionUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleRegionUniquePDSA</param>
    public IsRoleRegionUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleRegionUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsRoleRegionUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleRegionUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleRegionUniquePDSA</param>
    /// <param name="validator">An instance of a IsRoleRegionUniquePDSAValidator</param>
    public IsRoleRegionUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleRegionUniquePDSA entity, IsRoleRegionUniquePDSAValidator validator)
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
    public IsRoleRegionUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsRoleRegionUniquePDSAData";
      StoredProcName = "IsRoleRegionUnique";
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
      param.ParameterName = IsRoleRegionUniquePDSAValidator.ParameterNames.RoleRegionUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleRegionUniquePDSAValidator.ParameterNames.RoleId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleRegionUniquePDSAValidator.ParameterNames.RegionUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleRegionUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleRegionUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsRoleRegionUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsRoleRegionUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RoleRegionUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RoleRegionUid).Value = Entity.RoleRegionUid;
      else
        AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RoleRegionUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RoleId).SetAsNull == false)
        AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      else
        AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RoleId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RegionUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RegionUid).Value = Entity.RegionUid;
      else
        AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RegionUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsRoleRegionUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsRoleRegionUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsRoleRegionUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsRoleRegionUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsRoleRegionUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsRoleRegionUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsRoleRegionUniquePDSA</returns>
    public IsRoleRegionUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsRoleRegionUniquePDSA entity = new IsRoleRegionUniquePDSA();

      if (dr.Table.Columns.Contains(IsRoleRegionUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsRoleRegionUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsRoleRegionUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleRegionUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleRegionUid'
    /// </summary>
    public static string RoleRegionUid = "@RoleRegionUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
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
