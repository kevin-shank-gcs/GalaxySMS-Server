using System;
using System.Collections.Generic;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Logger;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class should be used when you need to select data for the DateTypeDefaultBehavior_PanelLoadDataPDSA view.
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateTypeDefaultBehavior_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_PanelLoadDataPDSAManager class
    /// </summary>
    public DateTypeDefaultBehavior_PanelLoadDataPDSAManager()
    {
      Init();
    }

    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_PanelLoadDataPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public DateTypeDefaultBehavior_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
    {
      DataProvider = dataProvider;
      
      Init();
    }

    /// <summary>
    /// Constructor for the DateTypeDefaultBehavior_PanelLoadDataPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public DateTypeDefaultBehavior_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion

    #region Private variables
    private DateTypeDefaultBehavior_PanelLoadDataPDSA _Entity = null;
    private DateTypeDefaultBehavior_PanelLoadDataPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        if (Validator != null)
          Validator.Entity = value;
        if (DataObject != null)
          DataObject.Entity = value;
      }
    }
    
    /// <summary>
    /// Get/Set the Entity class used for searching
    /// </summary>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new DateTypeDefaultBehavior_PanelLoadDataPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public DateTypeDefaultBehavior_PanelLoadDataPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public DateTypeDefaultBehavior_PanelLoadDataPDSAData DataObject { get; set; }
    #endregion

    #region Init Method
    /// <summary>
    /// Initialize this class to a valid start state
    /// </summary>
    protected override void Init()
    {
      // Create Entity Class if not created
      if(Entity == null)
      {
        Entity = new DateTypeDefaultBehavior_PanelLoadDataPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new DateTypeDefaultBehavior_PanelLoadDataPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new DateTypeDefaultBehavior_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "DateTypeDefaultBehavior_PanelLoadDataPDSAManager";
    }
    #endregion

    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      DateTypeDefaultBehavior_PanelLoadDataPDSA ret = new DateTypeDefaultBehavior_PanelLoadDataPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName))
        ret.EntityName = PDSAString.ConvertToStringTrim(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.EntityName]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode))
        ret.SundayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SundayDayCode]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode))
        ret.MondayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.MondayDayCode]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode))
        ret.TuesdayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.TuesdayDayCode]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode))
        ret.WednesdayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.WednesdayDayCode]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode))
        ret.ThursdayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.ThursdayDayCode]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode))
        ret.FridayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.FridayDayCode]);

      if (values.ContainsKey(DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode))
        ret.SaturdayDayCode = Convert.ToInt16(values[DateTypeDefaultBehavior_PanelLoadDataPDSAValidator.ColumnNames.SaturdayDayCode]);

      return ret;
    }
    #endregion

    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of DateTypeDefaultBehavior_PanelLoadDataPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>DateTypeDefaultBehavior_PanelLoadDataPDSACollection</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSACollection BuildCollection()
    {
      DateTypeDefaultBehavior_PanelLoadDataPDSACollection coll = new DateTypeDefaultBehavior_PanelLoadDataPDSACollection();
      DateTypeDefaultBehavior_PanelLoadDataPDSA entity = null;
      DataSet ds;

      try
      {
        DataObject.Entity = Entity;
        ds = DataObject.GetDataSet();

        if (ds.Tables.Count > 0)
        {
          foreach (DataRow dr in ds.Tables[ds.Tables.Count - 1].Rows)
          {
            entity = DataObject.CreateEntityFromDataRow(dr);
          
            // You can set any additional properties here
          
            coll.Add(entity);
          }
        }
      }
      catch (Exception ex)
      {
#if BuildCollection_LogFullException
          System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}");
#else
          //System.Diagnostics.Debug.WriteLine(ex.Message);
          this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}", ex);
          var innerEx = ex.InnerException;
          while (innerEx != null)
          {
            this.Log().Error($"InnerException in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{innerEx}", innerEx);
           //System.Diagnostics.Debug.WriteLine(innerEx.Message);
            innerEx = innerEx.InnerException;
          }
#endif
	}
      return coll;
    }

    /// <summary>
    /// Build collection from a DataSet returned from a stored procedure
    /// </summary>
    /// <param name="ds">A DataSet</param>
    /// <returns>A collection of DateTypeDefaultBehavior_PanelLoadDataPDSA objects</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
    {
      DateTypeDefaultBehavior_PanelLoadDataPDSACollection coll = new DateTypeDefaultBehavior_PanelLoadDataPDSACollection();

      if (ds != null)
      {
        if (ds.Tables.Count > 0)
        {
          foreach (DataRow item in ds.Tables[0].Rows)
          {
            coll.Add(DataObject.CreateEntityFromDataRow(item));
          }
        }
      }

      return coll;
    }
    
    /// <summary>
    /// Build collection from a DataTable returned from a stored procedure
    /// </summary>
    /// <param name="dt">A DataTable</param>
    /// <returns>A collection of DateTypeDefaultBehavior_PanelLoadDataPDSA objects</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of DateTypeDefaultBehavior_PanelLoadDataPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(DateTypeDefaultBehavior_PanelLoadDataPDSACollection), BuildCollection());
    }
    #endregion

    #region GetDataSet Method
    /// <summary>
    /// Get DataSet with all rows or with any filters you have set
    /// </summary>
    /// <returns>A DatSet object</returns>
    public DataSet GetDataSet()
    {
      return DataObject.GetDataSet();
    }

    /// <summary>
    /// Get DataSet using the SearchEntity object
    /// </summary>
    /// <returns>A DatSet object</returns>
    public DataSet GetDataSetUsingSearchFilters()
    {
      DataObject.SelectFilter = DateTypeDefaultBehavior_PanelLoadDataPDSAData.SelectFilters.Search;

      // Create connection
      DataObject.CommandObject.Connection = DataProvider.CreateConnection(DataProvider.ConnectString);

      return DataProvider.GetDataSet(DataObject.CommandObject);
    }
    #endregion

    #region InitSearchFilter Method
    /// <summary>
    /// Re-Initialize a 'SearchEntity' property
    /// </summary>
    public void InitSearchFilter()
    {
      // Initialize Search Entity
      SearchEntity = InitSearchFilter(SearchEntity);
    }

    /// <summary>
    /// Re-Initialize a Search Entity object
    /// Usually you will use this to set the SearchEntity object
    /// 
    /// DateTypeDefaultBehavior_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(DateTypeDefaultBehavior_PanelLoadDataPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A DateTypeDefaultBehavior_PanelLoadDataPDSA object</param>
    /// <returns>An DateTypeDefaultBehavior_PanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA InitSearchFilter(DateTypeDefaultBehavior_PanelLoadDataPDSA searchEntity)
    {
      searchEntity.EntityName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = DateTypeDefaultBehavior_PanelLoadDataPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion
    
    

    #region Clone Entity Class
    /// <summary>
    /// Clones the current DateTypeDefaultBehavior_PanelLoadDataPDSA
    /// </summary>
    /// <returns>A cloned DateTypeDefaultBehavior_PanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateTypeDefaultBehavior_PanelLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The DateTypeDefaultBehavior_PanelLoadDataPDSA entity to clone</param>
    /// <returns>A cloned DateTypeDefaultBehavior_PanelLoadDataPDSA object</returns>
    public DateTypeDefaultBehavior_PanelLoadDataPDSA CloneEntity(DateTypeDefaultBehavior_PanelLoadDataPDSA entityToClone)
    {
      DateTypeDefaultBehavior_PanelLoadDataPDSA newEntity = new DateTypeDefaultBehavior_PanelLoadDataPDSA();

      newEntity.EntityId = entityToClone.EntityId;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.SundayDayCode = entityToClone.SundayDayCode;
      newEntity.MondayDayCode = entityToClone.MondayDayCode;
      newEntity.TuesdayDayCode = entityToClone.TuesdayDayCode;
      newEntity.WednesdayDayCode = entityToClone.WednesdayDayCode;
      newEntity.ThursdayDayCode = entityToClone.ThursdayDayCode;
      newEntity.FridayDayCode = entityToClone.FridayDayCode;
      newEntity.SaturdayDayCode = entityToClone.SaturdayDayCode;

      return newEntity;
    }
    #endregion
  }
}
