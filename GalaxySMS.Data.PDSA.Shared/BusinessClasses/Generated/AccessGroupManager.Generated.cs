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
    /// This class is used when you need to add, edit, delete, select and validate data for the AccessGroupPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessGroupPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessGroupPDSAManager class
        /// </summary>
        public AccessGroupPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessGroupPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessGroupPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessGroupPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessGroupPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessGroupPDSA _Entity = null;
        private AccessGroupPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessGroupPDSA Entity
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
        public AccessGroupPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessGroupPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessGroupPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessGroupPDSAData DataObject { get; set; }
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
                Entity = new AccessGroupPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessGroupPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessGroupPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessGroupPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessGroupPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessGroupPDSA ret = new AccessGroupPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.AccessGroupUid))
                ret.AccessGroupUid = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.AccessGroupUid]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.AccessGroupNumber))
                ret.AccessGroupNumber = Convert.ToInt32(values[AccessGroupPDSAValidator.ColumnNames.AccessGroupNumber]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.ServiceComment))
                ret.ServiceComment = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.ServiceComment]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.Comment))
                ret.Comment = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.Comment]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.IsEnabled))
                ret.IsEnabled = Convert.ToBoolean(values[AccessGroupPDSAValidator.ColumnNames.IsEnabled]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.ActivationDate))
                ret.ActivationDate = Convert.ToDateTime(values[AccessGroupPDSAValidator.ColumnNames.ActivationDate]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.ExpirationDate))
                ret.ExpirationDate = Convert.ToDateTime(values[AccessGroupPDSAValidator.ColumnNames.ExpirationDate]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[AccessGroupPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[AccessGroupPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AccessGroupPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.CrisisModeAccessGroupUid))
                ret.CrisisModeAccessGroupUid = PDSAProperty.ConvertToGuid(values[AccessGroupPDSAValidator.ColumnNames.CrisisModeAccessGroupUid]);

            if (values.ContainsKey(AccessGroupPDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[AccessGroupPDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessGroupPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessGroupPDSACollection</returns>
        public AccessGroupPDSACollection BuildCollection()
        {
            AccessGroupPDSACollection coll = new AccessGroupPDSACollection();
            AccessGroupPDSA entity = null;
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
        /// <returns>A collection of AccessGroupPDSA objects</returns>
        public AccessGroupPDSACollection BuildCollection(DataSet ds)
        {
            AccessGroupPDSACollection coll = new AccessGroupPDSACollection();

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
        /// <returns>A collection of AccessGroupPDSA objects</returns>
        public AccessGroupPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessGroupPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessGroupPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.Search;

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
        /// AccessGroupPDSA.SearchEntity = mgr.InitSearchFilter(AccessGroupPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessGroupPDSA object</param>
        /// <returns>An AccessGroupPDSA object</returns>
        public AccessGroupPDSA InitSearchFilter(AccessGroupPDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AccessGroup table
        /// </summary>
        /// <param name="entity">An AccessGroupPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AccessGroupPDSA entity)
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
        /// Updates an entity in the GCS.AccessGroup table
        /// </summary>
        /// <param name="entity">An AccessGroupPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AccessGroupPDSA entity)
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
        /// Deletes an entity from the GCS.AccessGroup table
        /// </summary>
        /// <param name="entity">An AccessGroupPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AccessGroupPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AccessGroupUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetAccessGroupPDSAsByFK_AccessGroupClusterEntity Method
        public AccessGroupPDSACollection GetAccessGroupPDSAsByFK_AccessGroupClusterEntity(ClusterPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByClusterUid;
                    }
                    else
                    {
                    }

                    Entity.ClusterUid = entity.ClusterUid;
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
                return new AccessGroupPDSACollection();
        }
        #endregion

        #region GetAccessGroupPDSAsByFK_AccessGroupCluster Method
        public AccessGroupPDSACollection GetAccessGroupPDSAsByFK_AccessGroupCluster(Guid clusterUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByClusterUid;
                }
                else
                {
                }

                Entity.ClusterUid = clusterUid;
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
        #endregion

        #region GetAccessGroupPDSAsByFK_AccessGroupEntityEntity Method
        public AccessGroupPDSACollection GetAccessGroupPDSAsByFK_AccessGroupEntityEntity(gcsEntityPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByEntityId;
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
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new AccessGroupPDSACollection();
        }
        #endregion

        #region GetAccessGroupPDSAsByFK_AccessGroupEntity Method
        public AccessGroupPDSACollection GetAccessGroupPDSAsByFK_AccessGroupEntity(Guid entityId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByEntityId;
                }
                else
                {
                }

                Entity.EntityId = entityId;
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
        #endregion

    }
}

