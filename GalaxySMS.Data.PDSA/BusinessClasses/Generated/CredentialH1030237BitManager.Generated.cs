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
  /// This class is used when you need to add, edit, delete, select and validate data for the CredentialH1030237BitPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialH1030237BitPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the CredentialH1030237BitPDSAManager class
    /// </summary>
    public CredentialH1030237BitPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the CredentialH1030237BitPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public CredentialH1030237BitPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the CredentialH1030237BitPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public CredentialH1030237BitPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private CredentialH1030237BitPDSA _Entity = null;
    private CredentialH1030237BitPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public CredentialH1030237BitPDSA Entity
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
    public CredentialH1030237BitPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new CredentialH1030237BitPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public CredentialH1030237BitPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public CredentialH1030237BitPDSAData DataObject { get; set; }
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
        Entity = new CredentialH1030237BitPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new CredentialH1030237BitPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new CredentialH1030237BitPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "CredentialH1030237BitPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public CredentialH1030237BitPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      CredentialH1030237BitPDSA ret = new CredentialH1030237BitPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid))
        ret.CredentialUid = PDSAProperty.ConvertToGuid(values[CredentialH1030237BitPDSAValidator.ColumnNames.CredentialUid]);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.IdCode))
        ret.IdCode = Convert.ToInt64(values[CredentialH1030237BitPDSAValidator.ColumnNames.IdCode]);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[CredentialH1030237BitPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialH1030237BitPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[CredentialH1030237BitPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialH1030237BitPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[CredentialH1030237BitPDSAValidator.ColumnNames.ConcurrencyValue]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of CredentialH1030237BitPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>CredentialH1030237BitPDSACollection</returns>
    public CredentialH1030237BitPDSACollection BuildCollection()
    {
      CredentialH1030237BitPDSACollection coll = new CredentialH1030237BitPDSACollection();
      CredentialH1030237BitPDSA entity = null;
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
    /// <returns>A collection of CredentialH1030237BitPDSA objects</returns>
    public CredentialH1030237BitPDSACollection BuildCollection(DataSet ds)
    {
      CredentialH1030237BitPDSACollection coll = new CredentialH1030237BitPDSACollection();

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
    /// <returns>A collection of CredentialH1030237BitPDSA objects</returns>
    public CredentialH1030237BitPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of CredentialH1030237BitPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(CredentialH1030237BitPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = CredentialH1030237BitPDSAData.SelectFilters.Search;

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
    /// CredentialH1030237BitPDSA.SearchEntity = mgr.InitSearchFilter(CredentialH1030237BitPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A CredentialH1030237BitPDSA object</param>
    /// <returns>An CredentialH1030237BitPDSA object</returns>
    public CredentialH1030237BitPDSA InitSearchFilter(CredentialH1030237BitPDSA searchEntity)
    {
      searchEntity.InsertName  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = CredentialH1030237BitPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.CredentialH1030237Bit table
    /// </summary>
    /// <param name="entity">An CredentialH1030237BitPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(CredentialH1030237BitPDSA entity)
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
    /// Updates an entity in the GCS.CredentialH1030237Bit table
    /// </summary>
    /// <param name="entity">An CredentialH1030237BitPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(CredentialH1030237BitPDSA entity)
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
    /// Deletes an entity from the GCS.CredentialH1030237Bit table
    /// </summary>
    /// <param name="entity">An CredentialH1030237BitPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(CredentialH1030237BitPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.CredentialUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetCredentialH1030237BitPDSAsByFK_CredentialH1030237BitCredentialEntity Method
    public CredentialH1030237BitPDSACollection GetCredentialH1030237BitPDSAsByFK_CredentialH1030237BitCredentialEntity(CredentialPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = CredentialH1030237BitPDSAData.SelectFilters.ByCredentialUid;
           }
           else
           {
           }
           
           Entity.CredentialUid = entity.CredentialUid;
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
        return new CredentialH1030237BitPDSACollection();
    }
    #endregion

    #region GetCredentialH1030237BitPDSAsByFK_CredentialH1030237BitCredential Method
    public CredentialH1030237BitPDSACollection GetCredentialH1030237BitPDSAsByFK_CredentialH1030237BitCredential(Guid credentialUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = CredentialH1030237BitPDSAData.SelectFilters.ByCredentialUid;
        }
        else
        {
        }
        
        Entity.CredentialUid = credentialUid;
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

