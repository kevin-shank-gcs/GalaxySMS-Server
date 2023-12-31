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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsEnumNamespacePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsEnumNamespacePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsEnumNamespacePDSAManager class
        /// </summary>
        public gcsEnumNamespacePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsEnumNamespacePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsEnumNamespacePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsEnumNamespacePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsEnumNamespacePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsEnumNamespacePDSA _Entity = null;
        private gcsEnumNamespacePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsEnumNamespacePDSA Entity
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
        public gcsEnumNamespacePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsEnumNamespacePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsEnumNamespacePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsEnumNamespacePDSAData DataObject { get; set; }
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
                Entity = new gcsEnumNamespacePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsEnumNamespacePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsEnumNamespacePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsEnumNamespacePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsEnumNamespacePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsEnumNamespacePDSA ret = new gcsEnumNamespacePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.EnumNamespaceId))
                ret.EnumNamespaceId = PDSAProperty.ConvertToGuid(values[gcsEnumNamespacePDSAValidator.ColumnNames.EnumNamespaceId]);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.Name))
                ret.Name = PDSAString.ConvertToStringTrim(values[gcsEnumNamespacePDSAValidator.ColumnNames.Name]);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsEnumNamespacePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsEnumNamespacePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsEnumNamespacePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[gcsEnumNamespacePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsEnumNamespacePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsEnumNamespacePDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsEnumNamespacePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsEnumNamespacePDSACollection</returns>
        public gcsEnumNamespacePDSACollection BuildCollection()
        {
            gcsEnumNamespacePDSACollection coll = new gcsEnumNamespacePDSACollection();
            gcsEnumNamespacePDSA entity = null;
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
        /// <returns>A collection of gcsEnumNamespacePDSA objects</returns>
        public gcsEnumNamespacePDSACollection BuildCollection(DataSet ds)
        {
            gcsEnumNamespacePDSACollection coll = new gcsEnumNamespacePDSACollection();

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
        /// <returns>A collection of gcsEnumNamespacePDSA objects</returns>
        public gcsEnumNamespacePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsEnumNamespacePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsEnumNamespacePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsEnumNamespacePDSAData.SelectFilters.Search;

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
        /// gcsEnumNamespacePDSA.SearchEntity = mgr.InitSearchFilter(gcsEnumNamespacePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsEnumNamespacePDSA object</param>
        /// <returns>An gcsEnumNamespacePDSA object</returns>
        public gcsEnumNamespacePDSA InitSearchFilter(gcsEnumNamespacePDSA searchEntity)
        {
            searchEntity.Name = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsEnumNamespacePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsEnumNamespace table
        /// </summary>
        /// <param name="entity">An gcsEnumNamespacePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsEnumNamespacePDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.Insert();
            if (ret >= 1)
                TrackChanges("Insert");

            return ret;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Updates an entity in the GCS.gcsEnumNamespace table
        /// </summary>
        /// <param name="entity">An gcsEnumNamespacePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsEnumNamespacePDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.Update();
            if (ret >= 1)
                TrackChanges("Update");

            return ret;
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Deletes an entity from the GCS.gcsEnumNamespace table
        /// </summary>
        /// <param name="entity">An gcsEnumNamespacePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsEnumNamespacePDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.EnumNamespaceId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion

        #region GetgcsEnumNamespacePDSAsByPrimaryKey Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsEnumNamespacePDSACollection GetgcsEnumNamespacePDSAsByPrimaryKey()
        {
            DataObject.WhereFilter = gcsEnumNamespacePDSAData.WhereFilters.PrimaryKey;

            return BuildCollection();
        }
        #endregion

        #region GetgcsEnumNamespacePDSAsByName Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsEnumNamespacePDSACollection GetgcsEnumNamespacePDSAsByName()
        {
            DataObject.WhereFilter = gcsEnumNamespacePDSAData.WhereFilters.Name;

            return BuildCollection();
        }
        #endregion

        #region GetgcsEnumNamespacePDSAsByLikeName Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsEnumNamespacePDSACollection GetgcsEnumNamespacePDSAsByLikeName()
        {
            DataObject.WhereFilter = gcsEnumNamespacePDSAData.WhereFilters.LikeName;

            return BuildCollection();
        }
        #endregion

    }
}

