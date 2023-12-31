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
  /// This class calls the stored procedure IsCredential26BitStandardUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsCredential26BitStandardUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsCredential26BitStandardUniquePDSAData class
    /// </summary>
    public IsCredential26BitStandardUniquePDSAData() : base()
    {
      Entity = new IsCredential26BitStandardUniquePDSA();
      ValidatorObject = new  IsCredential26BitStandardUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsCredential26BitStandardUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsCredential26BitStandardUniquePDSA</param>
    public IsCredential26BitStandardUniquePDSAData(IsCredential26BitStandardUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsCredential26BitStandardUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsCredential26BitStandardUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsCredential26BitStandardUniquePDSA</param>
    public IsCredential26BitStandardUniquePDSAData(PDSADataProvider dataProvider,
      IsCredential26BitStandardUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsCredential26BitStandardUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsCredential26BitStandardUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsCredential26BitStandardUniquePDSA</param>
    /// <param name="validator">An instance of a IsCredential26BitStandardUniquePDSAValidator</param>
    public IsCredential26BitStandardUniquePDSAData(PDSADataProvider dataProvider,
      IsCredential26BitStandardUniquePDSA entity, IsCredential26BitStandardUniquePDSAValidator validator)
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
    public IsCredential26BitStandardUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsCredential26BitStandardUniquePDSAData";
      StoredProcName = "IsCredential26BitStandardUnique";
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
      param.ParameterName = IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsCredential26BitStandardUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid).SetAsNull == false)
        AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      else
        AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.CredentialUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode).SetAsNull == false)
        AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode).Value = Entity.FacilityCode;
      else
        AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.FacilityCode).Value = System.Data.SqlTypes.SqlInt16.Null;
      if (AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode).SetAsNull == false)
        AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode).Value = Entity.IdCode;
      else
        AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.IdCode).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsCredential26BitStandardUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsCredential26BitStandardUniquePDSA</returns>
    public IsCredential26BitStandardUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsCredential26BitStandardUniquePDSA entity = new IsCredential26BitStandardUniquePDSA();

      if (dr.Table.Columns.Contains(IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsCredential26BitStandardUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCredential26BitStandardUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@FacilityCode'
    /// </summary>
    public static string FacilityCode = "@FacilityCode";
    /// <summary>
    /// Returns '@IdCode'
    /// </summary>
    public static string IdCode = "@IdCode";
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
