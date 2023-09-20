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

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsResourceStringLanguagePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsResourceStringLanguagePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsResourceStringLanguagePDSAManager class
        /// </summary>
        public gcsResourceStringLanguagePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsResourceStringLanguagePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsResourceStringLanguagePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsResourceStringLanguagePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsResourceStringLanguagePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsResourceStringLanguagePDSA _Entity = null;
        private gcsResourceStringLanguagePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsResourceStringLanguagePDSA Entity
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
        public gcsResourceStringLanguagePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsResourceStringLanguagePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsResourceStringLanguagePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsResourceStringLanguagePDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class if not created
            if (Entity == null)
            {
                Entity = new gcsResourceStringLanguagePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsResourceStringLanguagePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsResourceStringLanguagePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsResourceStringLanguagePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsResourceStringLanguagePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsResourceStringLanguagePDSA ret = new gcsResourceStringLanguagePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId))
                ret.ResourceStringLanguageId = PDSAProperty.ConvertToGuid(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceStringLanguageId]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId))
                ret.ResourceId = PDSAProperty.ConvertToGuid(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.ResourceId]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId))
                ret.LanguageId = PDSAProperty.ConvertToGuid(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.LanguageId]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue))
                ret.StringValue = PDSAString.ConvertToStringTrim(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.StringValue]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[gcsResourceStringLanguagePDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsResourceStringLanguagePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsResourceStringLanguagePDSACollection</returns>
        public gcsResourceStringLanguagePDSACollection BuildCollection()
        {
            gcsResourceStringLanguagePDSACollection coll = new gcsResourceStringLanguagePDSACollection();
            gcsResourceStringLanguagePDSA entity = null;
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
#if BuildCollection_LogFullException
                System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod()?.Name}:{ex}");
#else
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
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
        /// <returns>A collection of gcsResourceStringLanguagePDSA objects</returns>
        public gcsResourceStringLanguagePDSACollection BuildCollection(DataSet ds)
        {
            gcsResourceStringLanguagePDSACollection coll = new gcsResourceStringLanguagePDSACollection();

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
        /// <returns>A collection of gcsResourceStringLanguagePDSA objects</returns>
        public gcsResourceStringLanguagePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsResourceStringLanguagePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsResourceStringLanguagePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.Search;

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
        /// gcsResourceStringLanguagePDSA.SearchEntity = mgr.InitSearchFilter(gcsResourceStringLanguagePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsResourceStringLanguagePDSA object</param>
        /// <returns>An gcsResourceStringLanguagePDSA object</returns>
        public gcsResourceStringLanguagePDSA InitSearchFilter(gcsResourceStringLanguagePDSA searchEntity)
        {
            searchEntity.StringValue = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsResourceStringLanguage table
        /// </summary>
        /// <param name="entity">An gcsResourceStringLanguagePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsResourceStringLanguagePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.Insert();
            if (ret >= 1)
                TrackChanges("Insert");

            return ret;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Updates an entity in the GCS.gcsResourceStringLanguage table
        /// </summary>
        /// <param name="entity">An gcsResourceStringLanguagePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsResourceStringLanguagePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.Update();
            if (ret >= 1)
                TrackChanges("Update");

            return ret;
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Deletes an entity from the GCS.gcsResourceStringLanguage table
        /// </summary>
        /// <param name="entity">An gcsResourceStringLanguagePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsResourceStringLanguagePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.ResourceStringLanguageId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageLanguageEntity Method
        public gcsResourceStringLanguagePDSACollection GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageLanguageEntity(gcsLanguagePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByLanguageId;
                    }
                    else
                    {
                    }

                    Entity.LanguageId = entity.LanguageId;
                }
                catch (Exception ex)
                {                // This is here for design time exceptions
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    var innerEx = ex.InnerException;
                    while (innerEx != null)
                    {
                        System.Diagnostics.Debug.WriteLine(innerEx.Message);
                        innerEx = innerEx.InnerException;
                    }
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new gcsResourceStringLanguagePDSACollection();
        }
        #endregion

        #region GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageLanguage Method
        public gcsResourceStringLanguagePDSACollection GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageLanguage(Guid languageId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByLanguageId;
                }
                else
                {
                }

                Entity.LanguageId = languageId;
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
#if BuildCollection_LogFullException
                System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod()?.Name}:{ex}");
#else
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
#endif
            }


            return BuildCollection();
        }
        #endregion

        #region GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageResourceStringEntity Method
        public gcsResourceStringLanguagePDSACollection GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageResourceStringEntity(gcsResourceStringPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByResourceId;
                    }
                    else
                    {
                    }

                    Entity.ResourceId = entity.ResourceId;
                }
                catch (Exception ex)
                {                // This is here for design time exceptions
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    var innerEx = ex.InnerException;
                    while (innerEx != null)
                    {
                        System.Diagnostics.Debug.WriteLine(innerEx.Message);
                        innerEx = innerEx.InnerException;
                    }
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new gcsResourceStringLanguagePDSACollection();
        }
        #endregion

        #region GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageResourceString Method
        public gcsResourceStringLanguagePDSACollection GetgcsResourceStringLanguagePDSAsByFK_ResourceStringLanguageResourceString(Guid resourceId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByResourceId;
                }
                else
                {
                }

                Entity.ResourceId = resourceId;
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
#if BuildCollection_LogFullException
                System.Diagnostics.Debug.WriteLine($"Exception in {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod()?.Name}:{ex}");
#else
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
#endif
            }


            return BuildCollection();
        }
        #endregion

    }
}

