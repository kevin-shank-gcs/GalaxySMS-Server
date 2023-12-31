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
  /// This class calls the stored procedure IsRoleMercScpGroupUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsRoleMercScpGroupUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsRoleMercScpGroupUniquePDSAData class
    /// </summary>
    public IsRoleMercScpGroupUniquePDSAData() : base()
    {
      Entity = new IsRoleMercScpGroupUniquePDSA();
      ValidatorObject = new  IsRoleMercScpGroupUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsRoleMercScpGroupUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsRoleMercScpGroupUniquePDSA</param>
    public IsRoleMercScpGroupUniquePDSAData(IsRoleMercScpGroupUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsRoleMercScpGroupUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleMercScpGroupUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleMercScpGroupUniquePDSA</param>
    public IsRoleMercScpGroupUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleMercScpGroupUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsRoleMercScpGroupUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleMercScpGroupUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleMercScpGroupUniquePDSA</param>
    /// <param name="validator">An instance of a IsRoleMercScpGroupUniquePDSAValidator</param>
    public IsRoleMercScpGroupUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleMercScpGroupUniquePDSA entity, IsRoleMercScpGroupUniquePDSAValidator validator)
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
    public IsRoleMercScpGroupUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsRoleMercScpGroupUniquePDSAData";
      StoredProcName = "IsRoleMercScpGroupUnique";
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
      param.ParameterName = IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsRoleMercScpGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).Value = Entity.RoleMercScpGroupUid;
      else
        AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleMercScpGroupUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId).SetAsNull == false)
        AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      else
        AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RoleId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      else
        AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.MercScpGroupUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsRoleMercScpGroupUniquePDSA</returns>
    public IsRoleMercScpGroupUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsRoleMercScpGroupUniquePDSA entity = new IsRoleMercScpGroupUniquePDSA();

      if (dr.Table.Columns.Contains(IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsRoleMercScpGroupUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleMercScpGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleMercScpGroupUid'
    /// </summary>
    public static string RoleMercScpGroupUid = "@RoleMercScpGroupUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
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
