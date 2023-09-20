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
  /// This class calls the stored procedure IsAccessPortalNoServerReplyBehaviorUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsAccessPortalNoServerReplyBehaviorUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsAccessPortalNoServerReplyBehaviorUniquePDSAData class
    /// </summary>
    public IsAccessPortalNoServerReplyBehaviorUniquePDSAData() : base()
    {
      Entity = new IsAccessPortalNoServerReplyBehaviorUniquePDSA();
      ValidatorObject = new  IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsAccessPortalNoServerReplyBehaviorUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsAccessPortalNoServerReplyBehaviorUniquePDSA</param>
    public IsAccessPortalNoServerReplyBehaviorUniquePDSAData(IsAccessPortalNoServerReplyBehaviorUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessPortalNoServerReplyBehaviorUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessPortalNoServerReplyBehaviorUniquePDSA</param>
    public IsAccessPortalNoServerReplyBehaviorUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessPortalNoServerReplyBehaviorUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessPortalNoServerReplyBehaviorUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessPortalNoServerReplyBehaviorUniquePDSA</param>
    /// <param name="validator">An instance of a IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator</param>
    public IsAccessPortalNoServerReplyBehaviorUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessPortalNoServerReplyBehaviorUniquePDSA entity, IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator validator)
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
    public IsAccessPortalNoServerReplyBehaviorUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsAccessPortalNoServerReplyBehaviorUniquePDSAData";
      StoredProcName = "IsAccessPortalNoServerReplyBehaviorUnique";
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
      param.ParameterName = IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.AccessPortalNoServerReplyBehaviorUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Display;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Code;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsAccessPortalNoServerReplyBehaviorUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.AccessPortalNoServerReplyBehaviorUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.AccessPortalNoServerReplyBehaviorUid).Value = Entity.AccessPortalNoServerReplyBehaviorUid;
      else
        AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.AccessPortalNoServerReplyBehaviorUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Display).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      else
        AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Display).Value = System.Data.SqlTypes.SqlChars.Null;
      if (AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Code).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Code).Value = Entity.Code;
      else
        AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Code).Value = System.Data.SqlTypes.SqlInt16.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsAccessPortalNoServerReplyBehaviorUniquePDSA</returns>
    public IsAccessPortalNoServerReplyBehaviorUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsAccessPortalNoServerReplyBehaviorUniquePDSA entity = new IsAccessPortalNoServerReplyBehaviorUniquePDSA();

      if (dr.Table.Columns.Contains(IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsAccessPortalNoServerReplyBehaviorUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalNoServerReplyBehaviorUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalNoServerReplyBehaviorUid'
    /// </summary>
    public static string AccessPortalNoServerReplyBehaviorUid = "@AccessPortalNoServerReplyBehaviorUid";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
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
