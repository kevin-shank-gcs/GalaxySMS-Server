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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsLanguagePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsLanguagePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsLanguagePDSAManager class
        /// </summary>
        public gcsLanguagePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsLanguagePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsLanguagePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsLanguagePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsLanguagePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsLanguagePDSA _Entity = null;
        private gcsLanguagePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsLanguagePDSA Entity
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
        public gcsLanguagePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsLanguagePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsLanguagePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsLanguagePDSAData DataObject { get; set; }
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
                Entity = new gcsLanguagePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsLanguagePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsLanguagePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsLanguagePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsLanguagePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsLanguagePDSA ret = new gcsLanguagePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.LanguageId))
                ret.LanguageId = PDSAProperty.ConvertToGuid(values[gcsLanguagePDSAValidator.ColumnNames.LanguageId]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[gcsLanguagePDSAValidator.ColumnNames.CultureName]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.LanguageName))
                ret.LanguageName = PDSAString.ConvertToStringTrim(values[gcsLanguagePDSAValidator.ColumnNames.LanguageName]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[gcsLanguagePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.Notes))
                ret.Notes = PDSAString.ConvertToStringTrim(values[gcsLanguagePDSAValidator.ColumnNames.Notes]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[gcsLanguagePDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.IsDisplay))
                ret.IsDisplay = Convert.ToBoolean(values[gcsLanguagePDSAValidator.ColumnNames.IsDisplay]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.IsDefault))
                ret.IsDefault = Convert.ToBoolean(values[gcsLanguagePDSAValidator.ColumnNames.IsDefault]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.FlagImage))
                ret.FlagImage = PDSAProperty.ConvertToByteArray(values[gcsLanguagePDSAValidator.ColumnNames.FlagImage]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.DisplayOrder))
                ret.DisplayOrder = Convert.ToInt32(values[gcsLanguagePDSAValidator.ColumnNames.DisplayOrder]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsLanguagePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsLanguagePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsLanguagePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[gcsLanguagePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsLanguagePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsLanguagePDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsLanguagePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsLanguagePDSACollection</returns>
        public gcsLanguagePDSACollection BuildCollection()
        {
            gcsLanguagePDSACollection coll = new gcsLanguagePDSACollection();
            gcsLanguagePDSA entity = null;
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
        /// <returns>A collection of gcsLanguagePDSA objects</returns>
        public gcsLanguagePDSACollection BuildCollection(DataSet ds)
        {
            gcsLanguagePDSACollection coll = new gcsLanguagePDSACollection();

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
        /// <returns>A collection of gcsLanguagePDSA objects</returns>
        public gcsLanguagePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsLanguagePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsLanguagePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsLanguagePDSAData.SelectFilters.Search;

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
        /// gcsLanguagePDSA.SearchEntity = mgr.InitSearchFilter(gcsLanguagePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsLanguagePDSA object</param>
        /// <returns>An gcsLanguagePDSA object</returns>
        public gcsLanguagePDSA InitSearchFilter(gcsLanguagePDSA searchEntity)
        {
            searchEntity.CultureName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsLanguagePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsLanguage table
        /// </summary>
        /// <param name="entity">An gcsLanguagePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsLanguagePDSA entity)
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
        /// Updates an entity in the GCS.gcsLanguage table
        /// </summary>
        /// <param name="entity">An gcsLanguagePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsLanguagePDSA entity)
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
        /// Deletes an entity from the GCS.gcsLanguage table
        /// </summary>
        /// <param name="entity">An gcsLanguagePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsLanguagePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.LanguageId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

