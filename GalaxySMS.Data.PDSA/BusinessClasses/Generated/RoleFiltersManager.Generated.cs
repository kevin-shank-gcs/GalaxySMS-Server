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
  /// This class is used when you need to add, edit, delete, select and validate data for the RoleFiltersPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class RoleFiltersPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the RoleFiltersPDSAManager class
    /// </summary>
    public RoleFiltersPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the RoleFiltersPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public RoleFiltersPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the RoleFiltersPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public RoleFiltersPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private RoleFiltersPDSA _Entity = null;
    private RoleFiltersPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public RoleFiltersPDSA Entity
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
    public RoleFiltersPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new RoleFiltersPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public RoleFiltersPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public RoleFiltersPDSAData DataObject { get; set; }
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
        Entity = new RoleFiltersPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new RoleFiltersPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new RoleFiltersPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "RoleFiltersPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public RoleFiltersPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      RoleFiltersPDSA ret = new RoleFiltersPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.RoleId))
        ret.RoleId = PDSAProperty.ConvertToGuid(values[RoleFiltersPDSAValidator.ColumnNames.RoleId]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllRegions))
        ret.IncludeAllRegions = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllRegions]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllSites))
        ret.IncludeAllSites = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllSites]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllClusters))
        ret.IncludeAllClusters = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllClusters]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[RoleFiltersPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[RoleFiltersPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[RoleFiltersPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[RoleFiltersPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[RoleFiltersPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllAccessPortals))
        ret.IncludeAllAccessPortals = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllAccessPortals]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllInputOutputGroups))
        ret.IncludeAllInputOutputGroups = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllInputOutputGroups]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllInputDevices))
        ret.IncludeAllInputDevices = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllInputDevices]);

      if (values.ContainsKey(RoleFiltersPDSAValidator.ColumnNames.IncludeAllOutputDevices))
        ret.IncludeAllOutputDevices = Convert.ToBoolean(values[RoleFiltersPDSAValidator.ColumnNames.IncludeAllOutputDevices]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of RoleFiltersPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>RoleFiltersPDSACollection</returns>
    public RoleFiltersPDSACollection BuildCollection()
    {
      RoleFiltersPDSACollection coll = new RoleFiltersPDSACollection();
      RoleFiltersPDSA entity = null;
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
    /// <returns>A collection of RoleFiltersPDSA objects</returns>
    public RoleFiltersPDSACollection BuildCollection(DataSet ds)
    {
      RoleFiltersPDSACollection coll = new RoleFiltersPDSACollection();

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
    /// <returns>A collection of RoleFiltersPDSA objects</returns>
    public RoleFiltersPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of RoleFiltersPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(RoleFiltersPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = RoleFiltersPDSAData.SelectFilters.Search;

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
    /// RoleFiltersPDSA.SearchEntity = mgr.InitSearchFilter(RoleFiltersPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A RoleFiltersPDSA object</param>
    /// <returns>An RoleFiltersPDSA object</returns>
    public RoleFiltersPDSA InitSearchFilter(RoleFiltersPDSA searchEntity)
    {
      searchEntity.InsertName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = RoleFiltersPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.RoleFilters table
    /// </summary>
    /// <param name="entity">An RoleFiltersPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(RoleFiltersPDSA entity)
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
    /// Updates an entity in the GCS.RoleFilters table
    /// </summary>
    /// <param name="entity">An RoleFiltersPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(RoleFiltersPDSA entity)
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
    /// Deletes an entity from the GCS.RoleFilters table
    /// </summary>
    /// <param name="entity">An RoleFiltersPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(RoleFiltersPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.RoleId);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetRoleFiltersPDSAsByFK_RoleFiltersRoleEntity Method
    public RoleFiltersPDSACollection GetRoleFiltersPDSAsByFK_RoleFiltersRoleEntity(gcsRolePDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = RoleFiltersPDSAData.SelectFilters.ByRoleId;
           }
           else
           {
           }
           
           Entity.RoleId = entity.RoleId;
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
        return new RoleFiltersPDSACollection();
    }
    #endregion

    #region GetRoleFiltersPDSAsByFK_RoleFiltersRole Method
    public RoleFiltersPDSACollection GetRoleFiltersPDSAsByFK_RoleFiltersRole(Guid roleId)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = RoleFiltersPDSAData.SelectFilters.ByRoleId;
        }
        else
        {
        }
        
        Entity.RoleId = roleId;
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

