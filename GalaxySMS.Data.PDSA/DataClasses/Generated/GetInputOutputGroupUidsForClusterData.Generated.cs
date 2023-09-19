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
  /// This class calls the stored procedure GetInputOutputGroupUidsForClusterPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class GetInputOutputGroupUidsForClusterPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GetInputOutputGroupUidsForClusterPDSAData class
    /// </summary>
    public GetInputOutputGroupUidsForClusterPDSAData() : base()
    {
      Entity = new GetInputOutputGroupUidsForClusterPDSA();
      ValidatorObject = new  GetInputOutputGroupUidsForClusterPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the GetInputOutputGroupUidsForClusterPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a GetInputOutputGroupUidsForClusterPDSA</param>
    public GetInputOutputGroupUidsForClusterPDSAData(GetInputOutputGroupUidsForClusterPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new GetInputOutputGroupUidsForClusterPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GetInputOutputGroupUidsForClusterPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GetInputOutputGroupUidsForClusterPDSA</param>
    public GetInputOutputGroupUidsForClusterPDSAData(PDSADataProvider dataProvider,
      GetInputOutputGroupUidsForClusterPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  GetInputOutputGroupUidsForClusterPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GetInputOutputGroupUidsForClusterPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GetInputOutputGroupUidsForClusterPDSA</param>
    /// <param name="validator">An instance of a GetInputOutputGroupUidsForClusterPDSAValidator</param>
    public GetInputOutputGroupUidsForClusterPDSAData(PDSADataProvider dataProvider,
      GetInputOutputGroupUidsForClusterPDSA entity, GetInputOutputGroupUidsForClusterPDSAValidator validator)
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
    public GetInputOutputGroupUidsForClusterPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "GetInputOutputGroupUidsForClusterPDSAData";
      StoredProcName = "GetInputOutputGroupUidsForCluster";
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
      param.ParameterName = GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_GetInputOutputGroupUidsForClusterPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid).SetAsNull == false)
        AllParameters.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid).Value = Entity.uid;
      else
        AllParameters.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.uid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull == false)
        AllColumns.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      else
        AllColumns.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
    }
    #endregion
    
    #region ColumnCollectionToEntityData Method
    /// <summary>
    /// Moves the data from the Columns collection into the Entity class.
    /// </summary>
    protected override void ColumnCollectionToEntityData()
    {
      if (AllColumns.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = AllColumns.GetByName(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      else
        Entity.InputOutputGroupUid = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>GetInputOutputGroupUidsForClusterPDSA</returns>
    public GetInputOutputGroupUidsForClusterPDSA CreateEntityFromDataRow(DataRow dr)
    {
      GetInputOutputGroupUidsForClusterPDSA entity = new GetInputOutputGroupUidsForClusterPDSA();

      if (dr.Table.Columns.Contains(GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid))
      {
        if (dr[GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid] != DBNull.Value)
          entity.InputOutputGroupUid = PDSAProperty.ConvertToGuid(dr[GetInputOutputGroupUidsForClusterPDSAValidator.ColumnNames.InputOutputGroupUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetInputOutputGroupUidsForClusterPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
