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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsApplicationPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsApplicationPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsApplicationPDSAManager class
        /// </summary>
        public gcsApplicationPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsApplicationPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsApplicationPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsApplicationPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsApplicationPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsApplicationPDSA _Entity = null;
        private gcsApplicationPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsApplicationPDSA Entity
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
        public gcsApplicationPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsApplicationPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsApplicationPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsApplicationPDSAData DataObject { get; set; }
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
                Entity = new gcsApplicationPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsApplicationPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsApplicationPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsApplicationPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsApplicationPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsApplicationPDSA ret = new gcsApplicationPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.ApplicationId))
                ret.ApplicationId = PDSAProperty.ConvertToGuid(values[gcsApplicationPDSAValidator.ColumnNames.ApplicationId]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.LanguageId))
                ret.LanguageId = PDSAProperty.ConvertToGuid(values[gcsApplicationPDSAValidator.ColumnNames.LanguageId]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.SystemRoleId))
                ret.SystemRoleId = PDSAProperty.ConvertToGuid(values[gcsApplicationPDSAValidator.ColumnNames.SystemRoleId]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.ApplicationName))
                ret.ApplicationName = PDSAString.ConvertToStringTrim(values[gcsApplicationPDSAValidator.ColumnNames.ApplicationName]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.ApplicationDescription))
                ret.ApplicationDescription = PDSAString.ConvertToStringTrim(values[gcsApplicationPDSAValidator.ColumnNames.ApplicationDescription]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsApplicationPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsApplicationPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsApplicationPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[gcsApplicationPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsApplicationPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[gcsApplicationPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(gcsApplicationPDSAValidator.ColumnNames.UserId))
                ret.UserId = PDSAProperty.ConvertToGuid(values[gcsApplicationPDSAValidator.ColumnNames.UserId]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsApplicationPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsApplicationPDSACollection</returns>
        public gcsApplicationPDSACollection BuildCollection()
        {
            gcsApplicationPDSACollection coll = new gcsApplicationPDSACollection();
            gcsApplicationPDSA entity = null;
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
        /// <returns>A collection of gcsApplicationPDSA objects</returns>
        public gcsApplicationPDSACollection BuildCollection(DataSet ds)
        {
            gcsApplicationPDSACollection coll = new gcsApplicationPDSACollection();

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
        /// <returns>A collection of gcsApplicationPDSA objects</returns>
        public gcsApplicationPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsApplicationPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsApplicationPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsApplicationPDSAData.SelectFilters.Search;

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
        /// gcsApplicationPDSA.SearchEntity = mgr.InitSearchFilter(gcsApplicationPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsApplicationPDSA object</param>
        /// <returns>An gcsApplicationPDSA object</returns>
        public gcsApplicationPDSA InitSearchFilter(gcsApplicationPDSA searchEntity)
        {
            searchEntity.ApplicationName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsApplicationPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsApplication table
        /// </summary>
        /// <param name="entity">An gcsApplicationPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsApplicationPDSA entity)
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
        /// Updates an entity in the GCS.gcsApplication table
        /// </summary>
        /// <param name="entity">An gcsApplicationPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsApplicationPDSA entity)
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
        /// Deletes an entity from the GCS.gcsApplication table
        /// </summary>
        /// <param name="entity">An gcsApplicationPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsApplicationPDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.ApplicationId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetgcsApplicationPDSAsByFK_ApplicationSystemRoleEntity Method
        public gcsApplicationPDSACollection GetgcsApplicationPDSAsByFK_ApplicationSystemRoleEntity(gcsRolePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsApplicationPDSAData.SelectFilters.BySystemRoleId;
                    }
                    else
                    {
                    }

                    Entity.SystemRoleId = entity.RoleId;
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
                return new gcsApplicationPDSACollection();
        }
        #endregion

        #region GetgcsApplicationPDSAsByFK_ApplicationSystemRole Method
        public gcsApplicationPDSACollection GetgcsApplicationPDSAsByFK_ApplicationSystemRole(Guid roleId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsApplicationPDSAData.SelectFilters.BySystemRoleId;
                }
                else
                {
                }

                Entity.SystemRoleId = roleId;
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
            return BuildCollection();
        }
        #endregion

    }
}

