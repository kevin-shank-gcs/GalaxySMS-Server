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
  /// This class calls the stored procedure IsAccessPortalTypeAccessPortalCommandUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsAccessPortalTypeAccessPortalCommandUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsAccessPortalTypeAccessPortalCommandUniquePDSAData class
    /// </summary>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSAData() : base()
    {
      Entity = new IsAccessPortalTypeAccessPortalCommandUniquePDSA();
      ValidatorObject = new  IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsAccessPortalTypeAccessPortalCommandUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsAccessPortalTypeAccessPortalCommandUniquePDSA</param>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSAData(IsAccessPortalTypeAccessPortalCommandUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessPortalTypeAccessPortalCommandUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessPortalTypeAccessPortalCommandUniquePDSA</param>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessPortalTypeAccessPortalCommandUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessPortalTypeAccessPortalCommandUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessPortalTypeAccessPortalCommandUniquePDSA</param>
    /// <param name="validator">An instance of a IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator</param>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessPortalTypeAccessPortalCommandUniquePDSA entity, IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator validator)
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
    public IsAccessPortalTypeAccessPortalCommandUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsAccessPortalTypeAccessPortalCommandUniquePDSAData";
      StoredProcName = "IsAccessPortalTypeAccessPortalCommandUnique";
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
      param.ParameterName = IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid).Value = Entity.AccessPortalTypeAccessPortalCommandUid;
      else
        AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).Value = Entity.AccessPortalTypeUid;
      else
        AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).Value = Entity.AccessPortalCommandUid;
      else
        AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsAccessPortalTypeAccessPortalCommandUniquePDSA</returns>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsAccessPortalTypeAccessPortalCommandUniquePDSA entity = new IsAccessPortalTypeAccessPortalCommandUniquePDSA();

      if (dr.Table.Columns.Contains(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTypeAccessPortalCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalTypeAccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalTypeAccessPortalCommandUid = "@AccessPortalTypeAccessPortalCommandUid";
    /// <summary>
    /// Returns '@AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "@AccessPortalTypeUid";
    /// <summary>
    /// Returns '@AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "@AccessPortalCommandUid";
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
