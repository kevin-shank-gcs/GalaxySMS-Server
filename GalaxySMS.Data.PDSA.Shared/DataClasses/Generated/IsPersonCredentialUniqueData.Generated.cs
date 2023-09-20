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
  /// This class calls the stored procedure IsPersonCredentialUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsPersonCredentialUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsPersonCredentialUniquePDSAData class
    /// </summary>
    public IsPersonCredentialUniquePDSAData() : base()
    {
      Entity = new IsPersonCredentialUniquePDSA();
      ValidatorObject = new  IsPersonCredentialUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsPersonCredentialUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsPersonCredentialUniquePDSA</param>
    public IsPersonCredentialUniquePDSAData(IsPersonCredentialUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsPersonCredentialUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsPersonCredentialUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsPersonCredentialUniquePDSA</param>
    public IsPersonCredentialUniquePDSAData(PDSADataProvider dataProvider,
      IsPersonCredentialUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsPersonCredentialUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsPersonCredentialUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsPersonCredentialUniquePDSA</param>
    /// <param name="validator">An instance of a IsPersonCredentialUniquePDSAValidator</param>
    public IsPersonCredentialUniquePDSAData(PDSADataProvider dataProvider,
      IsPersonCredentialUniquePDSA entity, IsPersonCredentialUniquePDSAValidator validator)
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
    public IsPersonCredentialUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsPersonCredentialUniquePDSAData";
      StoredProcName = "IsPersonCredentialUnique";
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
      param.ParameterName = IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonCredentialUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonCredentialUniquePDSAValidator.ParameterNames.CredentialUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonCredentialUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsPersonCredentialUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonCredentialUid).SetAsNull == false)
        AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonCredentialUid).Value = Entity.PersonCredentialUid;
      else
        AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonCredentialUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.CredentialUid).SetAsNull == false)
        AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      else
        AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.CredentialUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonUid).SetAsNull == false)
        AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      else
        AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.PersonUid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsPersonCredentialUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsPersonCredentialUniquePDSA</returns>
    public IsPersonCredentialUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsPersonCredentialUniquePDSA entity = new IsPersonCredentialUniquePDSA();

      if (dr.Table.Columns.Contains(IsPersonCredentialUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsPersonCredentialUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsPersonCredentialUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonCredentialUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "@PersonCredentialUid";
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
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
