using System;
using System.Collections.Generic;
using System.Data;

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
  /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyPanelAlarmEventAcknowledgmentPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelAlarmEventAcknowledgmentPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GalaxyPanelAlarmEventAcknowledgmentPDSAManager class
    /// </summary>
    public GalaxyPanelAlarmEventAcknowledgmentPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the GalaxyPanelAlarmEventAcknowledgmentPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public GalaxyPanelAlarmEventAcknowledgmentPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the GalaxyPanelAlarmEventAcknowledgmentPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public GalaxyPanelAlarmEventAcknowledgmentPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private GalaxyPanelAlarmEventAcknowledgmentPDSA _Entity = null;
    private GalaxyPanelAlarmEventAcknowledgmentPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public GalaxyPanelAlarmEventAcknowledgmentPDSA Entity
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
    public GalaxyPanelAlarmEventAcknowledgmentPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new GalaxyPanelAlarmEventAcknowledgmentPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public GalaxyPanelAlarmEventAcknowledgmentPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public GalaxyPanelAlarmEventAcknowledgmentPDSAData DataObject { get; set; }
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
        Entity = new GalaxyPanelAlarmEventAcknowledgmentPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new GalaxyPanelAlarmEventAcknowledgmentPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new GalaxyPanelAlarmEventAcknowledgmentPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "GalaxyPanelAlarmEventAcknowledgmentPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public GalaxyPanelAlarmEventAcknowledgmentPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      GalaxyPanelAlarmEventAcknowledgmentPDSA ret = new GalaxyPanelAlarmEventAcknowledgmentPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid))
        ret.GalaxyPanelAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.GalaxyPanelActivityEventUid))
        ret.GalaxyPanelActivityEventUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.GalaxyPanelActivityEventUid]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId))
        ret.UserId = PDSAProperty.ConvertToGuid(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UserId]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response))
        ret.Response = PDSAString.ConvertToStringTrim(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.Response]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = PDSAProperty.ConvertToDateTimeOffset(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = PDSAProperty.ConvertToDateTimeOffset(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyPanelAlarmEventAcknowledgmentPDSAValidator.ColumnNames.ConcurrencyValue]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of GalaxyPanelAlarmEventAcknowledgmentPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>GalaxyPanelAlarmEventAcknowledgmentPDSACollection</returns>
    public GalaxyPanelAlarmEventAcknowledgmentPDSACollection BuildCollection()
    {
      GalaxyPanelAlarmEventAcknowledgmentPDSACollection coll = new GalaxyPanelAlarmEventAcknowledgmentPDSACollection();
      GalaxyPanelAlarmEventAcknowledgmentPDSA entity = null;
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
    /// <returns>A collection of GalaxyPanelAlarmEventAcknowledgmentPDSA objects</returns>
    public GalaxyPanelAlarmEventAcknowledgmentPDSACollection BuildCollection(DataSet ds)
    {
      GalaxyPanelAlarmEventAcknowledgmentPDSACollection coll = new GalaxyPanelAlarmEventAcknowledgmentPDSACollection();

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
    /// <returns>A collection of GalaxyPanelAlarmEventAcknowledgmentPDSA objects</returns>
    public GalaxyPanelAlarmEventAcknowledgmentPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of GalaxyPanelAlarmEventAcknowledgmentPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(GalaxyPanelAlarmEventAcknowledgmentPDSACollection), BuildCollection());
    }
    #endregion

    #region GetDataSet Methods
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
      DataObject.SelectFilter = GalaxyPanelAlarmEventAcknowledgmentPDSAData.SelectFilters.Search;

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
    /// GalaxyPanelAlarmEventAcknowledgmentPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyPanelAlarmEventAcknowledgmentPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A GalaxyPanelAlarmEventAcknowledgmentPDSA object</param>
    /// <returns>An GalaxyPanelAlarmEventAcknowledgmentPDSA object</returns>
    public GalaxyPanelAlarmEventAcknowledgmentPDSA InitSearchFilter(GalaxyPanelAlarmEventAcknowledgmentPDSA searchEntity)
    {
      searchEntity.Response  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = GalaxyPanelAlarmEventAcknowledgmentPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.GalaxyPanelAlarmEventAcknowledgment table
    /// </summary>
    /// <param name="entity">An GalaxyPanelAlarmEventAcknowledgmentPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(GalaxyPanelAlarmEventAcknowledgmentPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.Insert();
      if(ret >= 1)
        TrackChanges("Insert");

      return ret;
    }
    #endregion

    #region Update Method
    /// <summary>
    /// Updates an entity in the GCS.GalaxyPanelAlarmEventAcknowledgment table
    /// </summary>
    /// <param name="entity">An GalaxyPanelAlarmEventAcknowledgmentPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(GalaxyPanelAlarmEventAcknowledgmentPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.Update();
      if(ret >= 1)
        TrackChanges("Update");

      return ret;
    }
    #endregion

    #region Delete Method
    /// <summary>
    /// Deletes an entity from the GCS.GalaxyPanelAlarmEventAcknowledgment table
    /// </summary>
    /// <param name="entity">An GalaxyPanelAlarmEventAcknowledgmentPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(GalaxyPanelAlarmEventAcknowledgmentPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.GalaxyPanelAlarmEventAcknowledgmentUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetGalaxyPanelAlarmEventAcknowledgmentPDSAsByFK_GalaxyPanelActivityAlarmEventAcknowledgmentEntity Method
    public GalaxyPanelAlarmEventAcknowledgmentPDSACollection GetGalaxyPanelAlarmEventAcknowledgmentPDSAsByFK_GalaxyPanelActivityAlarmEventAcknowledgmentEntity(GalaxyPanelActivityAlarmEventPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = GalaxyPanelAlarmEventAcknowledgmentPDSAData.SelectFilters.ByGalaxyPanelActivityEventUid;
           }
           else
           {
           }
           
           Entity.GalaxyPanelActivityEventUid = entity.GalaxyPanelActivityEventUid;
         }
         catch (Exception ex)
         {
            // This is here for design time exceptions
            System.Diagnostics.Debug.WriteLine(ex.Message);
            var innerEx = ex.InnerException;
            while( innerEx != null)
            {
                System.Diagnostics.Debug.WriteLine(innerEx.Message);
                innerEx = innerEx.InnerException;
            }
         }
            
         return BuildCollection();
      }
      else
        return new GalaxyPanelAlarmEventAcknowledgmentPDSACollection();
    }
    #endregion

    #region GetGalaxyPanelAlarmEventAcknowledgmentPDSAsByFK_GalaxyPanelActivityAlarmEventAcknowledgment Method
    public GalaxyPanelAlarmEventAcknowledgmentPDSACollection GetGalaxyPanelAlarmEventAcknowledgmentPDSAsByFK_GalaxyPanelActivityAlarmEventAcknowledgment(Guid galaxyPanelActivityEventUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = GalaxyPanelAlarmEventAcknowledgmentPDSAData.SelectFilters.ByGalaxyPanelActivityEventUid;
        }
        else
        {
        }
        
        Entity.GalaxyPanelActivityEventUid = galaxyPanelActivityEventUid;
      }
      catch (Exception ex)
      {
        // This is here for design time exceptions
        System.Diagnostics.Debug.WriteLine(ex.Message);
        var innerEx = ex.InnerException;
        while( innerEx != null)
        {
            System.Diagnostics.Debug.WriteLine(innerEx.Message);
            innerEx = innerEx.InnerException;
        }
      }
            
      return BuildCollection();
    }
    #endregion
    
  }
}

