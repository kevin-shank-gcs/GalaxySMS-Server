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
  /// This class calls the stored procedure IsAccessPortalTypeUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsAccessPortalTypeUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsAccessPortalTypeUniquePDSAData class
    /// </summary>
    public IsAccessPortalTypeUniquePDSAData() : base()
    {
      Entity = new IsAccessPortalTypeUniquePDSA();
      ValidatorObject = new  IsAccessPortalTypeUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsAccessPortalTypeUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsAccessPortalTypeUniquePDSA</param>
    public IsAccessPortalTypeUniquePDSAData(IsAccessPortalTypeUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsAccessPortalTypeUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessPortalTypeUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessPortalTypeUniquePDSA</param>
    public IsAccessPortalTypeUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessPortalTypeUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsAccessPortalTypeUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsAccessPortalTypeUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsAccessPortalTypeUniquePDSA</param>
    /// <param name="validator">An instance of a IsAccessPortalTypeUniquePDSAValidator</param>
    public IsAccessPortalTypeUniquePDSAData(PDSADataProvider dataProvider,
      IsAccessPortalTypeUniquePDSA entity, IsAccessPortalTypeUniquePDSAValidator validator)
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
    public IsAccessPortalTypeUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsAccessPortalTypeUniquePDSAData";
      StoredProcName = "IsAccessPortalTypeUnique";
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
      param.ParameterName = IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeDescription;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsAccessPortalTypeUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsAccessPortalTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).Value = Entity.AccessPortalTypeUid;
      else
        AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeDescription).SetAsNull == false)
        AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeDescription).Value = Entity.AccessPortalTypeDescription;
      else
        AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.AccessPortalTypeDescription).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsAccessPortalTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsAccessPortalTypeUniquePDSA</returns>
    public IsAccessPortalTypeUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsAccessPortalTypeUniquePDSA entity = new IsAccessPortalTypeUniquePDSA();

      if (dr.Table.Columns.Contains(IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsAccessPortalTypeUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "@AccessPortalTypeUid";
    /// <summary>
    /// Returns '@AccessPortalTypeDescription'
    /// </summary>
    public static string AccessPortalTypeDescription = "@AccessPortalTypeDescription";
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
