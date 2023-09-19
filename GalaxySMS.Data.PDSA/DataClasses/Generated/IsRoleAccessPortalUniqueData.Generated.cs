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
  /// This class calls the stored procedure IsRoleAccessPortalUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsRoleAccessPortalUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsRoleAccessPortalUniquePDSAData class
    /// </summary>
    public IsRoleAccessPortalUniquePDSAData() : base()
    {
      Entity = new IsRoleAccessPortalUniquePDSA();
      ValidatorObject = new  IsRoleAccessPortalUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsRoleAccessPortalUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsRoleAccessPortalUniquePDSA</param>
    public IsRoleAccessPortalUniquePDSAData(IsRoleAccessPortalUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsRoleAccessPortalUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleAccessPortalUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleAccessPortalUniquePDSA</param>
    public IsRoleAccessPortalUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleAccessPortalUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsRoleAccessPortalUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleAccessPortalUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleAccessPortalUniquePDSA</param>
    /// <param name="validator">An instance of a IsRoleAccessPortalUniquePDSAValidator</param>
    public IsRoleAccessPortalUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleAccessPortalUniquePDSA entity, IsRoleAccessPortalUniquePDSAValidator validator)
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
    public IsRoleAccessPortalUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsRoleAccessPortalUniquePDSAData";
      StoredProcName = "IsRoleAccessPortalUnique";
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
      param.ParameterName = IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleAccessPortalUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleAccessPortalUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsRoleAccessPortalUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleAccessPortalUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleAccessPortalUid).Value = Entity.RoleAccessPortalUid;
      else
        AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleAccessPortalUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleId).SetAsNull == false)
        AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      else
        AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RoleId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      else
        AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsRoleAccessPortalUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsRoleAccessPortalUniquePDSA</returns>
    public IsRoleAccessPortalUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsRoleAccessPortalUniquePDSA entity = new IsRoleAccessPortalUniquePDSA();

      if (dr.Table.Columns.Contains(IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsRoleAccessPortalUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleAccessPortalUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleAccessPortalUid'
    /// </summary>
    public static string RoleAccessPortalUid = "@RoleAccessPortalUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
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
