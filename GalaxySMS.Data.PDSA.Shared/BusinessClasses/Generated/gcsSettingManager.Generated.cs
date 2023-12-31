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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsSettingPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsSettingPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsSettingPDSAManager class
        /// </summary>
        public gcsSettingPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsSettingPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsSettingPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsSettingPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsSettingPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsSettingPDSA _Entity = null;
        private gcsSettingPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsSettingPDSA Entity
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
        public gcsSettingPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsSettingPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsSettingPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsSettingPDSAData DataObject { get; set; }
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
                Entity = new gcsSettingPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsSettingPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsSettingPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsSettingPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsSettingPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsSettingPDSA ret = new gcsSettingPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.SettingId))
                ret.SettingId = PDSAProperty.ConvertToGuid(values[gcsSettingPDSAValidator.ColumnNames.SettingId]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.SettingGroup))
                ret.SettingGroup = PDSAString.ConvertToStringTrim(values[gcsSettingPDSAValidator.ColumnNames.SettingGroup]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.SettingSubGroup))
                ret.SettingSubGroup = PDSAString.ConvertToStringTrim(values[gcsSettingPDSAValidator.ColumnNames.SettingSubGroup]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.SettingKey))
                ret.SettingKey = PDSAString.ConvertToStringTrim(values[gcsSettingPDSAValidator.ColumnNames.SettingKey]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.Value))
                ret.Value = PDSAString.ConvertToStringTrim(values[gcsSettingPDSAValidator.ColumnNames.Value]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsSettingPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsSettingPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsSettingPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[gcsSettingPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsSettingPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(gcsSettingPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[gcsSettingPDSAValidator.ColumnNames.EntityId]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsSettingPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsSettingPDSACollection</returns>
        public gcsSettingPDSACollection BuildCollection()
        {
            gcsSettingPDSACollection coll = new gcsSettingPDSACollection();
            gcsSettingPDSA entity = null;
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
        /// <returns>A collection of gcsSettingPDSA objects</returns>
        public gcsSettingPDSACollection BuildCollection(DataSet ds)
        {
            gcsSettingPDSACollection coll = new gcsSettingPDSACollection();

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
        /// <returns>A collection of gcsSettingPDSA objects</returns>
        public gcsSettingPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsSettingPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsSettingPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.Search;

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
        /// gcsSettingPDSA.SearchEntity = mgr.InitSearchFilter(gcsSettingPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsSettingPDSA object</param>
        /// <returns>An gcsSettingPDSA object</returns>
        public gcsSettingPDSA InitSearchFilter(gcsSettingPDSA searchEntity)
        {
            searchEntity.SettingGroup = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsSetting table
        /// </summary>
        /// <param name="entity">An gcsSettingPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsSettingPDSA entity)
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
        /// Updates an entity in the GCS.gcsSetting table
        /// </summary>
        /// <param name="entity">An gcsSettingPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsSettingPDSA entity)
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
        /// Deletes an entity from the GCS.gcsSetting table
        /// </summary>
        /// <param name="entity">An gcsSettingPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsSettingPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.SettingId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetgcsSettingPDSAsByFK_gcsSettingEntityEntity Method
        public gcsSettingPDSACollection GetgcsSettingPDSAsByFK_gcsSettingEntityEntity(gcsEntityPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.ByEntityId;
                    }
                    else
                    {
                    }

                    Entity.EntityId = entity.EntityId;
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
                }

                return BuildCollection();
            }
            else
                return new gcsSettingPDSACollection();
        }
        #endregion

        #region GetgcsSettingPDSAsByFK_gcsSettingEntity Method
        public gcsSettingPDSACollection GetgcsSettingPDSAsByFK_gcsSettingEntity(Guid entityId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.ByEntityId;
                }
                else
                {
                }

                Entity.EntityId = entityId;
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

