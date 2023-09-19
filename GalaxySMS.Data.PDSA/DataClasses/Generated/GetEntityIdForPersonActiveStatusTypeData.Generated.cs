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
  /// This class calls the stored procedure GetEntityIdForPersonActiveStatusTypePDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class GetEntityIdForPersonActiveStatusTypePDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GetEntityIdForPersonActiveStatusTypePDSAData class
    /// </summary>
    public GetEntityIdForPersonActiveStatusTypePDSAData() : base()
    {
      Entity = new GetEntityIdForPersonActiveStatusTypePDSA();
      ValidatorObject = new  GetEntityIdForPersonActiveStatusTypePDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the GetEntityIdForPersonActiveStatusTypePDSAData class
    /// </summary>
    /// <param name="entity">An instance of a GetEntityIdForPersonActiveStatusTypePDSA</param>
    public GetEntityIdForPersonActiveStatusTypePDSAData(GetEntityIdForPersonActiveStatusTypePDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new GetEntityIdForPersonActiveStatusTypePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GetEntityIdForPersonActiveStatusTypePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GetEntityIdForPersonActiveStatusTypePDSA</param>
    public GetEntityIdForPersonActiveStatusTypePDSAData(PDSADataProvider dataProvider,
      GetEntityIdForPersonActiveStatusTypePDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  GetEntityIdForPersonActiveStatusTypePDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the GetEntityIdForPersonActiveStatusTypePDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a GetEntityIdForPersonActiveStatusTypePDSA</param>
    /// <param name="validator">An instance of a GetEntityIdForPersonActiveStatusTypePDSAValidator</param>
    public GetEntityIdForPersonActiveStatusTypePDSAData(PDSADataProvider dataProvider,
      GetEntityIdForPersonActiveStatusTypePDSA entity, GetEntityIdForPersonActiveStatusTypePDSAValidator validator)
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
    public GetEntityIdForPersonActiveStatusTypePDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "GetEntityIdForPersonActiveStatusTypePDSAData";
      StoredProcName = "GetEntityIdForPersonActiveStatusType";
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
      param.ParameterName = GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.uid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_GetEntityIdForPersonActiveStatusTypePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.uid).SetAsNull == false)
        AllParameters.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.uid).Value = Entity.uid;
      else
        AllParameters.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.uid).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).SetAsNull == false)
        AllColumns.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      else
        AllColumns.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).Value = Guid.Empty;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = AllColumns.GetByName(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>GetEntityIdForPersonActiveStatusTypePDSA</returns>
    public GetEntityIdForPersonActiveStatusTypePDSA CreateEntityFromDataRow(DataRow dr)
    {
      GetEntityIdForPersonActiveStatusTypePDSA entity = new GetEntityIdForPersonActiveStatusTypePDSA();

      if (dr.Table.Columns.Contains(GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId))
      {
        if (dr[GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId] != DBNull.Value)
          entity.EntityId = PDSAProperty.ConvertToGuid(dr[GetEntityIdForPersonActiveStatusTypePDSAValidator.ColumnNames.EntityId]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetEntityIdForPersonActiveStatusTypePDSA class.
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
