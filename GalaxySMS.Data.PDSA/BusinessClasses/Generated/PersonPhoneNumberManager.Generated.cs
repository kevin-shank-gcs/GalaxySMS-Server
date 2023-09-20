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
  /// This class is used when you need to add, edit, delete, select and validate data for the PersonPhoneNumberPDSA table.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// DO NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonPhoneNumberPDSAManager : PDSADataClassManagerBase
  {
    #region Constructors
    /// <summary>
    /// Constructor for the PersonPhoneNumberPDSAManager class
    /// </summary>
    public PersonPhoneNumberPDSAManager() : base()
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the PersonPhoneNumberPDSAManager class
    /// </summary>
    /// <param name="dataProvider">An instance of a PDSADataProvider</param>
    public PersonPhoneNumberPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
    {
      // The base constructor calls the Init() method
    }

    /// <summary>
    /// Constructor for the PersonPhoneNumberPDSAManager class
    /// </summary>
    /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
    public PersonPhoneNumberPDSAManager(string dataProviderName) : base(dataProviderName)
    {
      // The base constructor calls the Init() method
    }
    #endregion
    
    #region Private variables
    private PersonPhoneNumberPDSA _Entity = null;
    private PersonPhoneNumberPDSA _SearchEntity = null;
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the entity class. This is the class that contains one property for each column in the table.
    /// </summary>
    public PersonPhoneNumberPDSA Entity
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
    public PersonPhoneNumberPDSA SearchEntity
    {
      get
      {
        // Create Search Entity Class if not created
        if (_SearchEntity == null)
        {
          _SearchEntity = new PersonPhoneNumberPDSA();
          InitSearchFilter();
        }

        return _SearchEntity;
      }
      set { _SearchEntity = value; }
    }

    /// <summary>
    /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
    /// </summary>
    public PersonPhoneNumberPDSAValidator Validator { get; set; }
    /// <summary>
    /// Get/Set the data class that contains the CRUD logic for loading the Entity class
    /// </summary>
    public PersonPhoneNumberPDSAData DataObject { get; set; }
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
        Entity = new PersonPhoneNumberPDSA();

        // Set any default values on the Entity object
        InitEntityObject();
      }

      // Create Validator Class
      if(Validator == null)
        Validator = new PersonPhoneNumberPDSAValidator(Entity);

      // Create Data Class if not created
      if(DataObject == null)
        DataObject = new PersonPhoneNumberPDSAData(DataProvider, Entity, Validator);
      else
      {
        DataObject.DataProvider = DataProvider;
        DataObject.ValidatorObject = Validator;
        DataObject.Entity = Entity;
      }
        
      DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

      ClassName = "PersonPhoneNumberPDSAManager";
    }
    #endregion
    
    #region DictionaryToEntity Method
    /// <summary>
    /// Takes the filled Dictionary object and puts the values into the Entity object
    /// </summary>
    /// <param name="values">A Dictionary object</param>
    /// <returns>An EmployeeType object</returns>
    public PersonPhoneNumberPDSA DictionaryToEntity(Dictionary<string, string> values)
    {
      PersonPhoneNumberPDSA ret = new PersonPhoneNumberPDSA();

      // Initialize Entity Object
      InitEntityObject(ret);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.PersonPhoneNumberUid))
        ret.PersonPhoneNumberUid = PDSAProperty.ConvertToGuid(values[PersonPhoneNumberPDSAValidator.ColumnNames.PersonPhoneNumberUid]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.PersonUid))
        ret.PersonUid = PDSAProperty.ConvertToGuid(values[PersonPhoneNumberPDSAValidator.ColumnNames.PersonUid]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.CellCarrierUid))
        ret.CellCarrierUid = PDSAProperty.ConvertToGuid(values[PersonPhoneNumberPDSAValidator.ColumnNames.CellCarrierUid]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.Label))
        ret.Label = PDSAString.ConvertToStringTrim(values[PersonPhoneNumberPDSAValidator.ColumnNames.Label]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.PhoneNumber))
        ret.PhoneNumber = PDSAString.ConvertToStringTrim(values[PersonPhoneNumberPDSAValidator.ColumnNames.PhoneNumber]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.InsertName))
        ret.InsertName = PDSAString.ConvertToStringTrim(values[PersonPhoneNumberPDSAValidator.ColumnNames.InsertName]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.InsertDate))
        ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[PersonPhoneNumberPDSAValidator.ColumnNames.InsertDate]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.UpdateName))
        ret.UpdateName = PDSAString.ConvertToStringTrim(values[PersonPhoneNumberPDSAValidator.ColumnNames.UpdateName]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.UpdateDate))
        ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[PersonPhoneNumberPDSAValidator.ColumnNames.UpdateDate]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.ConcurrencyValue))
        ret.ConcurrencyValue = Convert.ToInt16(values[PersonPhoneNumberPDSAValidator.ColumnNames.ConcurrencyValue]);

      if (values.ContainsKey(PersonPhoneNumberPDSAValidator.ColumnNames.SmsPermitted))
        ret.SmsPermitted = Convert.ToBoolean(values[PersonPhoneNumberPDSAValidator.ColumnNames.SmsPermitted]);

      return ret;
    }
    #endregion
    
    #region BuildCollection Method
    /// <summary>
    /// Returns a collection of PersonPhoneNumberPDSA classes based on the filters set
    /// You can set the SearchEntity object with values to search on partial data
    /// prior to calling this method to filter the results
    /// </summary>
    /// <returns>PersonPhoneNumberPDSACollection</returns>
    public PersonPhoneNumberPDSACollection BuildCollection()
    {
      PersonPhoneNumberPDSACollection coll = new PersonPhoneNumberPDSACollection();
      PersonPhoneNumberPDSA entity = null;
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
          System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod()?.Name}:{ex}");
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
    /// <returns>A collection of PersonPhoneNumberPDSA objects</returns>
    public PersonPhoneNumberPDSACollection BuildCollection(DataSet ds)
    {
      PersonPhoneNumberPDSACollection coll = new PersonPhoneNumberPDSACollection();

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
    /// <returns>A collection of PersonPhoneNumberPDSA objects</returns>
    public PersonPhoneNumberPDSACollection BuildCollection(DataTable dt)
    {
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      return BuildCollection(ds);
    }
    #endregion

    #region GetCollectionAsJSON Method
    /// <summary>
    /// Returns a collection of PersonPhoneNumberPDSA objects as a JSON formatted string
    /// </summary>
    /// <returns>A JSON formatted string</returns>
    public string GetCollectionAsJSON()
    {
      return PDSAString.GetAsJSON(typeof(PersonPhoneNumberPDSACollection), BuildCollection());
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
      DataObject.SelectFilter = PersonPhoneNumberPDSAData.SelectFilters.Search;

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
    /// PersonPhoneNumberPDSA.SearchEntity = mgr.InitSearchFilter(PersonPhoneNumberPDSA.SearchEntity);
    /// </summary>
    /// <param name="searchEntity">A PersonPhoneNumberPDSA object</param>
    /// <returns>An PersonPhoneNumberPDSA object</returns>
    public PersonPhoneNumberPDSA InitSearchFilter(PersonPhoneNumberPDSA searchEntity)
    {
      searchEntity.Label  = string.Empty;

      searchEntity.IsDirty = false;

      DataObject.SelectFilter = PersonPhoneNumberPDSAData.SelectFilters.All;
     
      return searchEntity;
    }
    #endregion

    #region Insert Method
    /// <summary>
    /// Insert a new entity into the GCS.PersonPhoneNumber table
    /// </summary>
    /// <param name="entity">An PersonPhoneNumberPDSA entity object</param>
    /// <returns>Number of rows affected by the Insert</returns>
    public int Insert(PersonPhoneNumberPDSA entity)
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
    /// Updates an entity in the GCS.PersonPhoneNumber table
    /// </summary>
    /// <param name="entity">An PersonPhoneNumberPDSA entity object</param>
    /// <returns>Number of rows affected by the Update</returns>
    public int Update(PersonPhoneNumberPDSA entity)
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
    /// Deletes an entity from the GCS.PersonPhoneNumber table
    /// </summary>
    /// <param name="entity">An PersonPhoneNumberPDSA entity object</param>
    /// <returns>Number of rows affected by the Delete</returns>
    public int Delete(PersonPhoneNumberPDSA entity)
    {
      int ret = 0;

      Entity = entity;
      DataObject.Entity = entity;
      ret = DataObject.DeleteByPK(entity.PersonPhoneNumberUid);
      if(ret >= 1)
        TrackChanges("Delete");

      return ret;
    }
    #endregion
  
    
    
    #region GetPersonPhoneNumberPDSAsByFK_PersonPhoneNumberPersonEntity Method
    public PersonPhoneNumberPDSACollection GetPersonPhoneNumberPDSAsByFK_PersonPhoneNumberPersonEntity(PersonPDSA entity)
    {
      if (entity != null)
      {
         try
         {
           if(DataObject.UseStoredProcs)
           {
             DataObject.SelectFilter = PersonPhoneNumberPDSAData.SelectFilters.ByPersonUid;
           }
           else
           {
           }
           
           Entity.PersonUid = entity.PersonUid;
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
        return new PersonPhoneNumberPDSACollection();
    }
    #endregion

    #region GetPersonPhoneNumberPDSAsByFK_PersonPhoneNumberPerson Method
    public PersonPhoneNumberPDSACollection GetPersonPhoneNumberPDSAsByFK_PersonPhoneNumberPerson(Guid personUid)
    {
      try
      {
        if(DataObject.UseStoredProcs)
        {
          DataObject.SelectFilter = PersonPhoneNumberPDSAData.SelectFilters.ByPersonUid;
        }
        else
        {
        }
        
        Entity.PersonUid = personUid;
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

