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
  /// This class is used when you need to add, edit, delete, select and validate data for the AreaPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AreaPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the AreaPDSAManager class
    /// </summary>
    public AreaPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the AreaPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public AreaPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the AreaPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public AreaPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private AreaPDSA _Entity = null;
    private AreaPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public AreaPDSA Entity
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
    public AreaPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new AreaPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public AreaPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public AreaPDSAData DataObject { get; set; }
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
        Entity = new AreaPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new AreaPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new AreaPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "AreaPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public AreaPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      AreaPDSA ret = new AreaPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.AreaUid))
        ret.AreaUid = PDSAProperty.ConvertToGuid(values[AreaPDSAValidator.ColumnNames.AreaUid]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.ClusterUid))
        ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AreaPDSAValidator.ColumnNames.ClusterUid]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.DisplayResourceKey))
        ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[AreaPDSAValidator.ColumnNames.DisplayResourceKey]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.AreaNumber))
        ret.AreaNumber = Convert.ToInt32(values[AreaPDSAValidator.ColumnNames.AreaNumber]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.DescriptionResourceKey))
        ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[AreaPDSAValidator.ColumnNames.DescriptionResourceKey]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[AreaPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.Display))
        ret.Display = PDSAString.ConvertToStringTrim(values[AreaPDSAValidator.ColumnNames.Display]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AreaPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.Description))
        ret.Description = PDSAString.ConvertToStringTrim(values[AreaPDSAValidator.ColumnNames.Description]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[AreaPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AreaPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[AreaPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[AreaPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.PageNumber))
        ret.PageNumber = Convert.ToInt32(values[AreaPDSAValidator.ColumnNames.PageNumber]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.CultureName))
        ret.CultureName = PDSAString.ConvertToStringTrim(values[AreaPDSAValidator.ColumnNames.CultureName]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.PageSize))
        ret.PageSize = Convert.ToInt32(values[AreaPDSAValidator.ColumnNames.PageSize]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.TotalRowCount))
        ret.TotalRowCount = Convert.ToInt32(values[AreaPDSAValidator.ColumnNames.TotalRowCount]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.SortColumn))
        ret.SortColumn = PDSAString.ConvertToStringTrim(values[AreaPDSAValidator.ColumnNames.SortColumn]);

      if (values.ContainsKey(AreaPDSAValidator.ColumnNames.DescendingOrder))
        ret.DescendingOrder = Convert.ToBoolean(values[AreaPDSAValidator.ColumnNames.DescendingOrder]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of AreaPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>AreaPDSACollection</returns>
    public AreaPDSACollection BuildCollection()
    {
      AreaPDSACollection coll = new AreaPDSACollection();
      AreaPDSA entity = null;
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
    /// <returns>A collection of AreaPDSA objects</returns>
    public AreaPDSACollection BuildCollection(DataSet ds)
    {
      AreaPDSACollection coll = new AreaPDSACollection();

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
    /// <returns>A collection of AreaPDSA objects</returns>
    public AreaPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of AreaPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(AreaPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = AreaPDSAData.SelectFilters.Search;

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
    /// AreaPDSA.SearchEntity = mgr.InitSearchFilter(AreaPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A AreaPDSA object</param>
    /// <returns>An AreaPDSA object</returns>
    public AreaPDSA InitSearchFilter(AreaPDSA searchEntity)
    {
      searchEntity.Display  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = AreaPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.Area table
    /// </summary>
    /// <param name="entity">An AreaPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(AreaPDSA entity)
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
    /// Updates an entity in the GCS.Area table
    /// </summary>
    /// <param name="entity">An AreaPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(AreaPDSA entity)
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
    /// Deletes an entity from the GCS.Area table
    /// </summary>
    /// <param name="entity">An AreaPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(AreaPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.AreaUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetAreaPDSAsByFK_AreaClusterEntity Method
    public AreaPDSACollection GetAreaPDSAsByFK_AreaClusterEntity(ClusterPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = AreaPDSAData.SelectFilters.ByClusterUid;
           }
           else
           {
           }
           
           Entity.ClusterUid = entity.ClusterUid;
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
        return new AreaPDSACollection();
    }
    #endregion

    #region GetAreaPDSAsByFK_AreaCluster Method
    public AreaPDSACollection GetAreaPDSAsByFK_AreaCluster(Guid clusterUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = AreaPDSAData.SelectFilters.ByClusterUid;
        }
        else
        {
        }
        
        Entity.ClusterUid = clusterUid;
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
    
    #region GetAreaPDSAsByFK_AreaEntityEntity Method
    public AreaPDSACollection GetAreaPDSAsByFK_AreaEntityEntity(gcsEntityPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = AreaPDSAData.SelectFilters.ByEntityId;
           }
           else
           {
           }
           
           Entity.EntityId = entity.EntityId;
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
        return new AreaPDSACollection();
    }
    #endregion

    #region GetAreaPDSAsByFK_AreaEntity Method
    public AreaPDSACollection GetAreaPDSAsByFK_AreaEntity(Guid entityId)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = AreaPDSAData.SelectFilters.ByEntityId;
        }
        else
        {
        }
        
        Entity.EntityId = entityId;
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

