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
  /// This class calls the stored procedure ChooseAvailableClusterNumberPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class ChooseAvailableClusterNumberPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the ChooseAvailableClusterNumberPDSAData class
    /// </summary>
    public ChooseAvailableClusterNumberPDSAData() : base()
    {
      Entity = new ChooseAvailableClusterNumberPDSA();
      ValidatorObject = new  ChooseAvailableClusterNumberPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the ChooseAvailableClusterNumberPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a ChooseAvailableClusterNumberPDSA</param>
    public ChooseAvailableClusterNumberPDSAData(ChooseAvailableClusterNumberPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new ChooseAvailableClusterNumberPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the ChooseAvailableClusterNumberPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a ChooseAvailableClusterNumberPDSA</param>
    public ChooseAvailableClusterNumberPDSAData(PDSADataProvider dataProvider,
      ChooseAvailableClusterNumberPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  ChooseAvailableClusterNumberPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the ChooseAvailableClusterNumberPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a ChooseAvailableClusterNumberPDSA</param>
    /// <param name="validator">An instance of a ChooseAvailableClusterNumberPDSAValidator</param>
    public ChooseAvailableClusterNumberPDSAData(PDSADataProvider dataProvider,
      ChooseAvailableClusterNumberPDSA entity, ChooseAvailableClusterNumberPDSAValidator validator)
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
    public ChooseAvailableClusterNumberPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "ChooseAvailableClusterNumberPDSAData";
      StoredProcName = "ChooseAvailableClusterNumber";
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
      param.ParameterName = ChooseAvailableClusterNumberPDSAValidator.ParameterNames.ClusterGroupId;
      param.DBType = DbType.String;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = ChooseAvailableClusterNumberPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_ChooseAvailableClusterNumberPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), DbType.Int32);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(ChooseAvailableClusterNumberPDSAValidator.ParameterNames.ClusterGroupId).SetAsNull == false)
        AllParameters.GetByName(ChooseAvailableClusterNumberPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      else
        AllParameters.GetByName(ChooseAvailableClusterNumberPDSAValidator.ParameterNames.ClusterGroupId).Value = System.Data.SqlTypes.SqlString.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber).SetAsNull == false)
        AllColumns.GetByName(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      else
        AllColumns.GetByName(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(ChooseAvailableClusterNumberPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(ChooseAvailableClusterNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = AllColumns.GetByName(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      else
        Entity.ClusterNumber = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>ChooseAvailableClusterNumberPDSA</returns>
    public ChooseAvailableClusterNumberPDSA CreateEntityFromDataRow(DataRow dr)
    {
      ChooseAvailableClusterNumberPDSA entity = new ChooseAvailableClusterNumberPDSA();

      if (dr.Table.Columns.Contains(ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber))
      {
        if (dr[ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber] != DBNull.Value)
          entity.ClusterNumber = Convert.ToInt32(dr[ChooseAvailableClusterNumberPDSAValidator.ColumnNames.ClusterNumber]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ChooseAvailableClusterNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
