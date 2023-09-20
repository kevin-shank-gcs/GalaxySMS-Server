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
  /// This class calls the stored procedure IsRoleOutputDeviceUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsRoleOutputDeviceUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsRoleOutputDeviceUniquePDSAData class
    /// </summary>
    public IsRoleOutputDeviceUniquePDSAData() : base()
    {
      Entity = new IsRoleOutputDeviceUniquePDSA();
      ValidatorObject = new  IsRoleOutputDeviceUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsRoleOutputDeviceUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsRoleOutputDeviceUniquePDSA</param>
    public IsRoleOutputDeviceUniquePDSAData(IsRoleOutputDeviceUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsRoleOutputDeviceUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleOutputDeviceUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleOutputDeviceUniquePDSA</param>
    public IsRoleOutputDeviceUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleOutputDeviceUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsRoleOutputDeviceUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsRoleOutputDeviceUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsRoleOutputDeviceUniquePDSA</param>
    /// <param name="validator">An instance of a IsRoleOutputDeviceUniquePDSAValidator</param>
    public IsRoleOutputDeviceUniquePDSAData(PDSADataProvider dataProvider,
      IsRoleOutputDeviceUniquePDSA entity, IsRoleOutputDeviceUniquePDSAValidator validator)
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
    public IsRoleOutputDeviceUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsRoleOutputDeviceUniquePDSAData";
      StoredProcName = "IsRoleOutputDeviceUnique";
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
      param.ParameterName = IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleOutputDeviceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsRoleOutputDeviceUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleOutputDeviceUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleOutputDeviceUid).Value = Entity.RoleOutputDeviceUid;
      else
        AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleOutputDeviceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleId).SetAsNull == false)
        AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      else
        AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RoleId).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).SetAsNull == false)
        AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      else
        AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsRoleOutputDeviceUniquePDSA</returns>
    public IsRoleOutputDeviceUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsRoleOutputDeviceUniquePDSA entity = new IsRoleOutputDeviceUniquePDSA();

      if (dr.Table.Columns.Contains(IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsRoleOutputDeviceUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsRoleOutputDeviceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleOutputDeviceUid'
    /// </summary>
    public static string RoleOutputDeviceUid = "@RoleOutputDeviceUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
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
