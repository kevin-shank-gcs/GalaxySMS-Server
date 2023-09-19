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
  /// This class calls the stored procedure IsGalaxyInterfaceBoardUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsGalaxyInterfaceBoardUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsGalaxyInterfaceBoardUniquePDSAData class
    /// </summary>
    public IsGalaxyInterfaceBoardUniquePDSAData() : base()
    {
      Entity = new IsGalaxyInterfaceBoardUniquePDSA();
      ValidatorObject = new  IsGalaxyInterfaceBoardUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsGalaxyInterfaceBoardUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsGalaxyInterfaceBoardUniquePDSA</param>
    public IsGalaxyInterfaceBoardUniquePDSAData(IsGalaxyInterfaceBoardUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsGalaxyInterfaceBoardUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyInterfaceBoardUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyInterfaceBoardUniquePDSA</param>
    public IsGalaxyInterfaceBoardUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyInterfaceBoardUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsGalaxyInterfaceBoardUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsGalaxyInterfaceBoardUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsGalaxyInterfaceBoardUniquePDSA</param>
    /// <param name="validator">An instance of a IsGalaxyInterfaceBoardUniquePDSAValidator</param>
    public IsGalaxyInterfaceBoardUniquePDSAData(PDSADataProvider dataProvider,
      IsGalaxyInterfaceBoardUniquePDSA entity, IsGalaxyInterfaceBoardUniquePDSAValidator validator)
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
    public IsGalaxyInterfaceBoardUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsGalaxyInterfaceBoardUniquePDSAData";
      StoredProcName = "IsGalaxyInterfaceBoardUnique";
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
      param.ParameterName = IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsGalaxyInterfaceBoardUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).Value = Entity.GalaxyInterfaceBoardUid;
      else
        AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      else
        AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.GalaxyPanelUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber).SetAsNull == false)
        AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      else
        AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.BoardNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsGalaxyInterfaceBoardUniquePDSA</returns>
    public IsGalaxyInterfaceBoardUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsGalaxyInterfaceBoardUniquePDSA entity = new IsGalaxyInterfaceBoardUniquePDSA();

      if (dr.Table.Columns.Contains(IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsGalaxyInterfaceBoardUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "@GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns '@GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "@GalaxyPanelUid";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
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
