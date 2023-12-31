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
  /// This class calls the stored procedure DateTypeDefaultBehavior_GetPanelLoadDataPDSA
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public class DateTypeDefaultBehavior_GetPanelLoadDataPDSAData : PDSAStoredProcReadOnly
  {
    #region Constructors
    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_GetPanelLoadDataPDSAData class
    /// </summary>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSAData() : base()
    {
      Entity = new DateTypeDefaultBehavior_GetPanelLoadDataPDSA();
      ValidatorObject = new  DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator(Entity);

      Init();
    }

    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_GetPanelLoadDataPDSAData class
    /// </summary>
    /// <param name="entity">An instance of a DateTypeDefaultBehavior_GetPanelLoadDataPDSA</param>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSAData(DateTypeDefaultBehavior_GetPanelLoadDataPDSA entity) : base()
    {
      Entity = entity;
      ValidatorObject = new DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_GetPanelLoadDataPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a DateTypeDefaultBehavior_GetPanelLoadDataPDSA</param>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSAData(PDSADataProvider dataProvider,
      DateTypeDefaultBehavior_GetPanelLoadDataPDSA entity)
      : base(dataProvider)
    {
      Entity = entity;
      ValidatorObject = new  DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator(Entity);
            
      Init();
    }
    
    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_GetPanelLoadDataPDSAData class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    /// <param name="entity">An instance of a DateTypeDefaultBehavior_GetPanelLoadDataPDSA</param>
    /// <param name="validator">An instance of a DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator</param>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSAData(PDSADataProvider dataProvider,
      DateTypeDefaultBehavior_GetPanelLoadDataPDSA entity, DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator validator)
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
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSA Entity { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initializes this class to a valid start state.
    /// </summary>
    protected override void Init()
    {
      ClassName = "DateTypeDefaultBehavior_GetPanelLoadDataPDSAData";
      StoredProcName = "DateTypeDefaultBehavior_GetPanelLoadData";
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
      param.ParameterName = DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId;
      param.DBType = DbType.Guid;
      param.ParamDirection = ParameterDirection.Input;
      param.IsRefCursor = false;
      AllParameters.Add(param);

      param = new PDSADataParameter();
      param.ParameterName = DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE;
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
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), DbType.Guid);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_EntityName_Header", "Entity Name"), false, typeof(string), DbType.String);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_SundayDayCode_Header", "Sunday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_MondayDayCode_Header", "Monday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_TuesdayDayCode_Header", "Tuesday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_WednesdayDayCode_Header", "Wednesday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_ThursdayDayCode_Header", "Thursday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_FridayDayCode_Header", "Friday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
      dc = PDSADataColumn.CreateDataColumn(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode, GetResourceMessage("GCS_DateTypeDefaultBehavior_GetPanelLoadDataPDSA_SaturdayDayCode_Header", "Saturday Day Code"), false, typeof(short), DbType.Int16);
      AllColumns.Add(dc);
    }
    #endregion

    #region EntityDataToParameterCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Parameters collection
    /// </summary>
    protected override void EntityDataToParameterCollection()
    {
      if (AllParameters.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId).SetAsNull == false)
        AllParameters.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      else
        AllParameters.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.EntityId).Value = System.Data.SqlTypes.SqlGuid.Null;
    }
    #endregion

    #region EntityDataToColumnCollection Method
    /// <summary>
    /// Moves the data from the Entity class into the Columns collection
    /// </summary>
    protected override void EntityDataToColumnCollection()
    {
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId).Value = Guid.Empty;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName).Value = Entity.EntityName;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName).Value = string.Empty;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).Value = Entity.SundayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).Value = 0;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).Value = Entity.MondayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).Value = 0;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).Value = Entity.TuesdayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).Value = 0;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).Value = Entity.WednesdayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).Value = 0;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).Value = Entity.ThursdayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).Value = 0;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).Value = Entity.FridayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).Value = 0;
     
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).SetAsNull == false)
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).Value = Entity.SaturdayDayCode;
      else
        AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).Value = 0;
     
    }
    #endregion

    #region OutputParametersToEntityData Method
    /// <summary>
    /// Moves the output parameters from the Parameters collection into the Entity class.
    /// </summary>
    protected override void OutputParametersToEntityData()
    {
      if (AllParameters.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).IsValueNull == false)
        Entity.RETURNVALUE = AllParameters.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
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
      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      else
        Entity.EntityId = Guid.Empty;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName).IsNull == false)
        Entity.EntityName = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName).GetAsString();
      else
        Entity.EntityName = string.Empty;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).IsNull == false)
        Entity.SundayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode).GetAsShort();
      else
        Entity.SundayDayCode = 0;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).IsNull == false)
        Entity.MondayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode).GetAsShort();
      else
        Entity.MondayDayCode = 0;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).IsNull == false)
        Entity.TuesdayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode).GetAsShort();
      else
        Entity.TuesdayDayCode = 0;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).IsNull == false)
        Entity.WednesdayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode).GetAsShort();
      else
        Entity.WednesdayDayCode = 0;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).IsNull == false)
        Entity.ThursdayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode).GetAsShort();
      else
        Entity.ThursdayDayCode = 0;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).IsNull == false)
        Entity.FridayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode).GetAsShort();
      else
        Entity.FridayDayCode = 0;

      if (AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).IsNull == false)
        Entity.SaturdayDayCode = AllColumns.GetByName(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode).GetAsShort();
      else
        Entity.SaturdayDayCode = 0;

    }
    #endregion

    #region CreateEntityFromDataRow Method
    /// <summary>
    /// Creates an Entity object from a DataRow object.
    /// </summary>
    /// <param name="dr">DataRow object with all fields from the table in it.</param>
    /// <returns>DateTypeDefaultBehavior_GetPanelLoadDataPDSA</returns>
    public DateTypeDefaultBehavior_GetPanelLoadDataPDSA CreateEntityFromDataRow(DataRow dr)
    {
      DateTypeDefaultBehavior_GetPanelLoadDataPDSA entity = new DateTypeDefaultBehavior_GetPanelLoadDataPDSA();

      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId] != DBNull.Value)
          entity.EntityId = PDSAProperty.ConvertToGuid(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityId]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName] != DBNull.Value)
          entity.EntityName = PDSAString.ConvertToStringTrim(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.EntityName]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode] != DBNull.Value)
          entity.SundayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SundayDayCode]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode] != DBNull.Value)
          entity.MondayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.MondayDayCode]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode] != DBNull.Value)
          entity.TuesdayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode] != DBNull.Value)
          entity.WednesdayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode] != DBNull.Value)
          entity.ThursdayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode] != DBNull.Value)
          entity.FridayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.FridayDayCode]);
      }
      if (dr.Table.Columns.Contains(DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode))
      {
        if (dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode] != DBNull.Value)
          entity.SaturdayDayCode = Convert.ToInt16(dr[DateTypeDefaultBehavior_GetPanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode]);
      }
      entity.IsDirty = false;

      return entity;
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateTypeDefaultBehavior_GetPanelLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}
