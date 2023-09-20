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
  /// This class is used when you need to add, edit, delete, select and validate data for the DepartmentPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DepartmentPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the DepartmentPDSAManager class
    /// </summary>
    public DepartmentPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the DepartmentPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public DepartmentPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the DepartmentPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public DepartmentPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private DepartmentPDSA _Entity = null;
    private DepartmentPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public DepartmentPDSA Entity
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
    public DepartmentPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new DepartmentPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public DepartmentPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public DepartmentPDSAData DataObject { get; set; }
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
        Entity = new DepartmentPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new DepartmentPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new DepartmentPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "DepartmentPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public DepartmentPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      DepartmentPDSA ret = new DepartmentPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.DepartmentUid))
        ret.DepartmentUid = PDSAProperty.ConvertToGuid(values[DepartmentPDSAValidator.ColumnNames.DepartmentUid]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.EntityId))
        ret.EntityId = PDSAProperty.ConvertToGuid(values[DepartmentPDSAValidator.ColumnNames.EntityId]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.DepartmentName))
        ret.DepartmentName = PDSAString.ConvertToStringTrim(values[DepartmentPDSAValidator.ColumnNames.DepartmentName]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.Description))
        ret.Description = PDSAString.ConvertToStringTrim(values[DepartmentPDSAValidator.ColumnNames.Description]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[DepartmentPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[DepartmentPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[DepartmentPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[DepartmentPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[DepartmentPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.PageNumber))
        ret.PageNumber = Convert.ToInt32(values[DepartmentPDSAValidator.ColumnNames.PageNumber]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.PageSize))
        ret.PageSize = Convert.ToInt32(values[DepartmentPDSAValidator.ColumnNames.PageSize]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.TotalRowCount))
        ret.TotalRowCount = Convert.ToInt32(values[DepartmentPDSAValidator.ColumnNames.TotalRowCount]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.SortColumn))
        ret.SortColumn = PDSAString.ConvertToStringTrim(values[DepartmentPDSAValidator.ColumnNames.SortColumn]);

      if (values.ContainsKey(DepartmentPDSAValidator.ColumnNames.DescendingOrder))
        ret.DescendingOrder = Convert.ToBoolean(values[DepartmentPDSAValidator.ColumnNames.DescendingOrder]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of DepartmentPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>DepartmentPDSACollection</returns>
    public DepartmentPDSACollection BuildCollection()
    {
      DepartmentPDSACollection coll = new DepartmentPDSACollection();
      DepartmentPDSA entity = null;
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
    /// <returns>A collection of DepartmentPDSA objects</returns>
    public DepartmentPDSACollection BuildCollection(DataSet ds)
    {
      DepartmentPDSACollection coll = new DepartmentPDSACollection();

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
    /// <returns>A collection of DepartmentPDSA objects</returns>
    public DepartmentPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of DepartmentPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(DepartmentPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = DepartmentPDSAData.SelectFilters.Search;

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
    /// DepartmentPDSA.SearchEntity = mgr.InitSearchFilter(DepartmentPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A DepartmentPDSA object</param>
    /// <returns>An DepartmentPDSA object</returns>
    public DepartmentPDSA InitSearchFilter(DepartmentPDSA searchEntity)
    {
      searchEntity.DepartmentName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = DepartmentPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.Department table
    /// </summary>
    /// <param name="entity">An DepartmentPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(DepartmentPDSA entity)
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
    /// Updates an entity in the GCS.Department table
    /// </summary>
    /// <param name="entity">An DepartmentPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(DepartmentPDSA entity)
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
    /// Deletes an entity from the GCS.Department table
    /// </summary>
    /// <param name="entity">An DepartmentPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(DepartmentPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.DepartmentUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetDepartmentPDSAsByFK_DepartmentEntityEntity Method
    public DepartmentPDSACollection GetDepartmentPDSAsByFK_DepartmentEntityEntity(gcsEntityPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = DepartmentPDSAData.SelectFilters.ByEntityId;
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
        return new DepartmentPDSACollection();
    }
    #endregion

    #region GetDepartmentPDSAsByFK_DepartmentEntity Method
    public DepartmentPDSACollection GetDepartmentPDSAsByFK_DepartmentEntity(Guid entityId)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = DepartmentPDSAData.SelectFilters.ByEntityId;
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

