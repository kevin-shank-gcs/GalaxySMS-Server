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
  /// This class calls the stored procedure AreaUid_GetByAccessPortalUidAndAreaNumberPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData class
    /// </summary>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData() : base()
    {
      Entity = new AreaUid_GetByAccessPortalUidAndAreaNumberPDSA();
      ValidatorObject = new  AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a AreaUid_GetByAccessPortalUidAndAreaNumberPDSA</param>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData(AreaUid_GetByAccessPortalUidAndAreaNumberPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AreaUid_GetByAccessPortalUidAndAreaNumberPDSA</param>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData(PDSADataProvider dataProvider,
      AreaUid_GetByAccessPortalUidAndAreaNumberPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a AreaUid_GetByAccessPortalUidAndAreaNumberPDSA</param>
    /// <param name="validator">An instance of a AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator</param>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData(PDSADataProvider dataProvider,
      AreaUid_GetByAccessPortalUidAndAreaNumberPDSA entity, AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator validator)
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
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "AreaUid_GetByAccessPortalUidAndAreaNumberPDSAData";
      StoredProcName = "AreaUid_GetByAccessPortalUidAndAreaNumber";
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
      param.ParameterName = AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber;
      param.DBType = DbType.Int32;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_AreaUid_Header", "Area Uid"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid).SetAsNull == false)
        AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid).Value = Entity.accessPortalUid;
      else
        AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid).Value = System.Data.SqlTypes.SqlGuid.Null;
      if (AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber).SetAsNull == false)
        AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber).Value = Entity.areaNumber;
      else
        AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber).Value = System.Data.SqlTypes.SqlInt32.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid).SetAsNull == false)
        AllColumns.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid).Value = Entity.AreaUid;
      else
        AllColumns.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid).Value = Guid.NewGuid();
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid).IsNull == false)
        Entity.AreaUid = AllColumns.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid).GetAsGuid();
      else
        Entity.AreaUid = Guid.NewGuid();

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>AreaUid_GetByAccessPortalUidAndAreaNumberPDSA</returns>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSA CreateEntityFromDataRow(DataRow dr)
    {
      AreaUid_GetByAccessPortalUidAndAreaNumberPDSA entity = new AreaUid_GetByAccessPortalUidAndAreaNumberPDSA();

      if (dr.Table.Columns.Contains(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid))
      {
        if (dr[AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid] != DBNull.Value)
          entity.AreaUid = PDSAProperty.ConvertToGuid(dr[AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ColumnNames.AreaUid]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AreaUid_GetByAccessPortalUidAndAreaNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@accessPortalUid'
    /// </summary>
    public static string accessPortalUid = "@accessPortalUid";
    /// <summary>
    /// Returns '@areaNumber'
    /// </summary>
    public static string areaNumber = "@areaNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
