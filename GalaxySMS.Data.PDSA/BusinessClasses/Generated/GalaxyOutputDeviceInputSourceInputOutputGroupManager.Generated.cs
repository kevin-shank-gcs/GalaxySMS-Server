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
  /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyOutputDeviceInputSourceInputOutputGroupPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager class
    /// </summary>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private GalaxyOutputDeviceInputSourceInputOutputGroupPDSA _Entity = null;
    private GalaxyOutputDeviceInputSourceInputOutputGroupPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSA Entity
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
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData DataObject { get; set; }
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
        Entity = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
	DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
        
      ClassName ="GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      GalaxyOutputDeviceInputSourceInputOutputGroupPDSA ret = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid))
        ret.GalaxyOutputDeviceInputSourceInputOutputGroupUid = PDSAProperty.ConvertToGuid(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid))
        ret.GalaxyOutputDeviceInputSourceUid = PDSAProperty.ConvertToGuid(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid))
        ret.InputOutputGroupUid = PDSAProperty.ConvertToGuid(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of GalaxyOutputDeviceInputSourceInputOutputGroupPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection BuildCollection()
    {
      GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection coll = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection();
      GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity = null;
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
        // This is here for design time exceptions
        System.Diagnostics.Debug.WriteLine(ex.Message);
        var innerEx = ex.InnerException;
        while( innerEx != null)
        {
            System.Diagnostics.Debug.WriteLine(innerEx.Message);
            innerEx = innerEx.InnerException;
        }
      }

      return coll;
    }

    /// <summary>
    /// Build collection from a DataSet returned from a stored procedure
    /// </summary>
    /// <param name="ds">A DataSet</param>
    /// <returns>A collection of GalaxyOutputDeviceInputSourceInputOutputGroupPDSA objects</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection BuildCollection(DataSet ds)
    {
      GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection coll = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection();

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
    /// <returns>A collection of GalaxyOutputDeviceInputSourceInputOutputGroupPDSA objects</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of GalaxyOutputDeviceInputSourceInputOutputGroupPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.Search;

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
    /// GalaxyOutputDeviceInputSourceInputOutputGroupPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyOutputDeviceInputSourceInputOutputGroupPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A GalaxyOutputDeviceInputSourceInputOutputGroupPDSA object</param>
    /// <returns>An GalaxyOutputDeviceInputSourceInputOutputGroupPDSA object</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSA InitSearchFilter(GalaxyOutputDeviceInputSourceInputOutputGroupPDSA searchEntity)
    {
      searchEntity.InsertName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.GalaxyOutputDeviceInputSourceInputOutputGroup table
    /// </summary>
    /// <param name="entity">An GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity)
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
    /// Updates an entity in the GCS.GalaxyOutputDeviceInputSourceInputOutputGroup table
    /// </summary>
    /// <param name="entity">An GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity)
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
    /// Deletes an entity from the GCS.GalaxyOutputDeviceInputSourceInputOutputGroup table
    /// </summary>
    /// <param name="entity">An GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetGalaxyOutputDeviceInputSourceInputOutputGroupPDSAsByFK_GalaxyOutputDeviceInputSourceInputOutputGroupSourceEntity Method
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection GetGalaxyOutputDeviceInputSourceInputOutputGroupPDSAsByFK_GalaxyOutputDeviceInputSourceInputOutputGroupSourceEntity(GalaxyOutputDeviceInputSourcePDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.ByGalaxyOutputDeviceInputSourceUid;
           }
           else
           {
           }
           
           Entity.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
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
        return new GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection();
    }
    #endregion

    #region GetGalaxyOutputDeviceInputSourceInputOutputGroupPDSAsByFK_GalaxyOutputDeviceInputSourceInputOutputGroupSource Method
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSACollection GetGalaxyOutputDeviceInputSourceInputOutputGroupPDSAsByFK_GalaxyOutputDeviceInputSourceInputOutputGroupSource(Guid galaxyOutputDeviceInputSourceUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.ByGalaxyOutputDeviceInputSourceUid;
        }
        else
        {
        }
        
        Entity.GalaxyOutputDeviceInputSourceUid = galaxyOutputDeviceInputSourceUid;
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

