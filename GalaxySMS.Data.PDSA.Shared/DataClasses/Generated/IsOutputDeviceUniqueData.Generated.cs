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
  /// This class calls the stored procedure IsOutputDeviceUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsOutputDeviceUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsOutputDeviceUniquePDSAData class
    /// </summary>
    public IsOutputDeviceUniquePDSAData() : base()
    {
      Entity = new IsOutputDeviceUniquePDSA();
      ValidatorObject = new  IsOutputDeviceUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsOutputDeviceUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsOutputDeviceUniquePDSA</param>
    public IsOutputDeviceUniquePDSAData(IsOutputDeviceUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsOutputDeviceUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsOutputDeviceUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsOutputDeviceUniquePDSA</param>
    public IsOutputDeviceUniquePDSAData(PDSADataProvider dataProvider,
      IsOutputDeviceUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsOutputDeviceUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsOutputDeviceUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsOutputDeviceUniquePDSA</param>
    /// <param name="validator">An instance of a IsOutputDeviceUniquePDSAValidator</param>
    public IsOutputDeviceUniquePDSAData(PDSADataProvider dataProvider,
      IsOutputDeviceUniquePDSA entity, IsOutputDeviceUniquePDSAValidator validator)
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
    public IsOutputDeviceUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsOutputDeviceUniquePDSAData";
      StoredProcName = "IsOutputDeviceUnique";
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
      param.ParameterName = IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).SetAsNull == false)
        AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      else
        AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid).SetAsNull == false)
        AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      else
        AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName).SetAsNull == false)
        AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName).Value = Entity.OutputName;
      else
        AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName).Value = System.Data.SqlTypes.SqlChars.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsOutputDeviceUniquePDSA</returns>
    public IsOutputDeviceUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsOutputDeviceUniquePDSA entity = new IsOutputDeviceUniquePDSA();

      if (dr.Table.Columns.Contains(IsOutputDeviceUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsOutputDeviceUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsOutputDeviceUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@OutputName'
    /// </summary>
    public static string OutputName = "@OutputName";
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
