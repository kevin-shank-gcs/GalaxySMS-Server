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
  /// This class calls the stored procedure IsAccessGroupAccessPortalUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsAccessGroupAccessPortalUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsAccessGroupAccessPortalUniquePDSAData class
    /// </summary>
    public IsAccessGroupAccessPortalUniquePDSAData() : base()
    {
      Entity = new IsAccessGroupAccessPortalUniquePDSA();
      ValidatorObject = new  IsAccessGroupAccessPortalUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsAccessGroupAccessPortalUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsAccessGroupAccessPortalUniquePDSA</param>
    public IsAccessGroupAccessPortalUniquePDSAData(IsAccessGroupAccessPortalUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsAccessGroupAccessPortalUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessGroupAccessPortalUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessGroupAccessPortalUniquePDSA</param>
    public IsAccessGroupAccessPortalUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessGroupAccessPortalUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsAccessGroupAccessPortalUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessGroupAccessPortalUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessGroupAccessPortalUniquePDSA</param>
    /// <param name="validator">An instance of a IsAccessGroupAccessPortalUniquePDSAValidator</param>
    public IsAccessGroupAccessPortalUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessGroupAccessPortalUniquePDSA entity, IsAccessGroupAccessPortalUniquePDSAValidator validator)
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
    public IsAccessGroupAccessPortalUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsAccessGroupAccessPortalUniquePDSAData";
      StoredProcName = "IsAccessGroupAccessPortalUnique";
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
      param.ParameterName = IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupAccessPortalUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsAccessGroupAccessPortalUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupAccessPortalUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupAccessPortalUid).Value = Entity.AccessGroupAccessPortalUid;
      else
        AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupAccessPortalUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      else
        AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessGroupUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      else
        AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsAccessGroupAccessPortalUniquePDSA</returns>
    public IsAccessGroupAccessPortalUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsAccessGroupAccessPortalUniquePDSA entity = new IsAccessGroupAccessPortalUniquePDSA();

      if (dr.Table.Columns.Contains(IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsAccessGroupAccessPortalUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessGroupAccessPortalUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessGroupAccessPortalUid'
    /// </summary>
    public static string AccessGroupAccessPortalUid = "@AccessGroupAccessPortalUid";
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
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
