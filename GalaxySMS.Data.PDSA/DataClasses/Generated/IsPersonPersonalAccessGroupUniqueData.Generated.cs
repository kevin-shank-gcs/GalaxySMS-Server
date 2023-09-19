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
  /// This class calls the stored procedure IsPersonPersonalAccessGroupUniquePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class IsPersonPersonalAccessGroupUniquePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the IsPersonPersonalAccessGroupUniquePDSAData class
    /// </summary>
    public IsPersonPersonalAccessGroupUniquePDSAData() : base()
    {
      Entity = new IsPersonPersonalAccessGroupUniquePDSA();
      ValidatorObject = new  IsPersonPersonalAccessGroupUniquePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the IsPersonPersonalAccessGroupUniquePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a IsPersonPersonalAccessGroupUniquePDSA</param>
    public IsPersonPersonalAccessGroupUniquePDSAData(IsPersonPersonalAccessGroupUniquePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new IsPersonPersonalAccessGroupUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsPersonPersonalAccessGroupUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsPersonPersonalAccessGroupUniquePDSA</param>
    public IsPersonPersonalAccessGroupUniquePDSAData(PDSADataProvider dataProvider,
      IsPersonPersonalAccessGroupUniquePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  IsPersonPersonalAccessGroupUniquePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the IsPersonPersonalAccessGroupUniquePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a IsPersonPersonalAccessGroupUniquePDSA</param>
    /// <param name="validator">An instance of a IsPersonPersonalAccessGroupUniquePDSAValidator</param>
    public IsPersonPersonalAccessGroupUniquePDSAData(PDSADataProvider dataProvider,
      IsPersonPersonalAccessGroupUniquePDSA entity, IsPersonPersonalAccessGroupUniquePDSAValidator validator)
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
    public IsPersonPersonalAccessGroupUniquePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "IsPersonPersonalAccessGroupUniquePDSAData";
      StoredProcName = "IsPersonPersonalAccessGroupUnique";
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
      param.ParameterName = IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber;
      param.DBType = DbType.Int16;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Output;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result, GetResourceMessage("GCS_IsPersonPersonalAccessGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).SetAsNull == false)
        AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).Value = Entity.PersonClusterPermissionUid;
      else
        AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonClusterPermissionUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid).SetAsNull == false)
        AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      else
        AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.ClusterUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber).SetAsNull == false)
        AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber).Value = Entity.PersonalAccessGroupNumber;
      else
        AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.PersonalAccessGroupNumber).Value = System.Data.SqlTypes.SqlInt16.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result).SetAsNull == false)
        AllColumns.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result).Value = Entity.Result;
      else
        AllColumns.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
      else
        Entity.RETURNVALUE = 0;
      if (AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result).IsValueNull == false)
        Entity.Result = AllParameters.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
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
      if (AllColumns.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result).IsNull == false)
        Entity.Result = AllColumns.GetByName(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result).GetAsInteger();
      else
        Entity.Result = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>IsPersonPersonalAccessGroupUniquePDSA</returns>
    public IsPersonPersonalAccessGroupUniquePDSA CreateEntityFromDataRow(DataRow dr)
    {
      IsPersonPersonalAccessGroupUniquePDSA entity = new IsPersonPersonalAccessGroupUniquePDSA();

      if (dr.Table.Columns.Contains(IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result))
      {
        if (dr[IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result] != DBNull.Value)
          entity.Result = Convert.ToInt32(dr[IsPersonPersonalAccessGroupUniquePDSAValidator.ColumnNames.Result]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonPersonalAccessGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonClusterPermissionUid'
    /// </summary>
    public static string PersonClusterPermissionUid = "@PersonClusterPermissionUid";
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@PersonalAccessGroupNumber'
    /// </summary>
    public static string PersonalAccessGroupNumber = "@PersonalAccessGroupNumber";
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
