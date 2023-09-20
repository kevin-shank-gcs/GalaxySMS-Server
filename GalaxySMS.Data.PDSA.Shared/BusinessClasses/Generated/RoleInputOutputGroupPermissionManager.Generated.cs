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
    /// This class is used when you need to add, edit, delete, select and validate data for the RoleInputOutputGroupPermissionPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class RoleInputOutputGroupPermissionPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the RoleInputOutputGroupPermissionPDSAManager class
        /// </summary>
        public RoleInputOutputGroupPermissionPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the RoleInputOutputGroupPermissionPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public RoleInputOutputGroupPermissionPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the RoleInputOutputGroupPermissionPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public RoleInputOutputGroupPermissionPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private RoleInputOutputGroupPermissionPDSA _Entity = null;
        private RoleInputOutputGroupPermissionPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public RoleInputOutputGroupPermissionPDSA Entity
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
        public RoleInputOutputGroupPermissionPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new RoleInputOutputGroupPermissionPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public RoleInputOutputGroupPermissionPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public RoleInputOutputGroupPermissionPDSAData DataObject { get; set; }
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
                Entity = new RoleInputOutputGroupPermissionPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new RoleInputOutputGroupPermissionPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new RoleInputOutputGroupPermissionPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "RoleInputOutputGroupPermissionPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public RoleInputOutputGroupPermissionPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            RoleInputOutputGroupPermissionPDSA ret = new RoleInputOutputGroupPermissionPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid))
                ret.RoleInputOutputGroupPermissionUid = PDSAProperty.ConvertToGuid(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupPermissionUid]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid))
                ret.RoleInputOutputGroupUid = PDSAProperty.ConvertToGuid(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.RoleInputOutputGroupUid]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId))
                ret.PermissionId = PDSAProperty.ConvertToGuid(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.PermissionId]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[RoleInputOutputGroupPermissionPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of RoleInputOutputGroupPermissionPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>RoleInputOutputGroupPermissionPDSACollection</returns>
        public RoleInputOutputGroupPermissionPDSACollection BuildCollection()
        {
            RoleInputOutputGroupPermissionPDSACollection coll = new RoleInputOutputGroupPermissionPDSACollection();
            RoleInputOutputGroupPermissionPDSA entity = null;
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
        /// <returns>A collection of RoleInputOutputGroupPermissionPDSA objects</returns>
        public RoleInputOutputGroupPermissionPDSACollection BuildCollection(DataSet ds)
        {
            RoleInputOutputGroupPermissionPDSACollection coll = new RoleInputOutputGroupPermissionPDSACollection();

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
        /// <returns>A collection of RoleInputOutputGroupPermissionPDSA objects</returns>
        public RoleInputOutputGroupPermissionPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of RoleInputOutputGroupPermissionPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(RoleInputOutputGroupPermissionPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = RoleInputOutputGroupPermissionPDSAData.SelectFilters.Search;

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
        /// RoleInputOutputGroupPermissionPDSA.SearchEntity = mgr.InitSearchFilter(RoleInputOutputGroupPermissionPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A RoleInputOutputGroupPermissionPDSA object</param>
        /// <returns>An RoleInputOutputGroupPermissionPDSA object</returns>
        public RoleInputOutputGroupPermissionPDSA InitSearchFilter(RoleInputOutputGroupPermissionPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = RoleInputOutputGroupPermissionPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.RoleInputOutputGroupPermission table
        /// </summary>
        /// <param name="entity">An RoleInputOutputGroupPermissionPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(RoleInputOutputGroupPermissionPDSA entity)
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
        /// Updates an entity in the GCS.RoleInputOutputGroupPermission table
        /// </summary>
        /// <param name="entity">An RoleInputOutputGroupPermissionPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(RoleInputOutputGroupPermissionPDSA entity)
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
        /// Deletes an entity from the GCS.RoleInputOutputGroupPermission table
        /// </summary>
        /// <param name="entity">An RoleInputOutputGroupPermissionPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(RoleInputOutputGroupPermissionPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.RoleInputOutputGroupPermissionUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionPermissionEntity Method
        public RoleInputOutputGroupPermissionPDSACollection GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionPermissionEntity(gcsPermissionPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = RoleInputOutputGroupPermissionPDSAData.SelectFilters.ByPermissionId;
                    }
                    else
                    {
                    }

                    Entity.PermissionId = entity.PermissionId;
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
                return new RoleInputOutputGroupPermissionPDSACollection();
        }
        #endregion

        #region GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionPermission Method
        public RoleInputOutputGroupPermissionPDSACollection GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionPermission(Guid permissionId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = RoleInputOutputGroupPermissionPDSAData.SelectFilters.ByPermissionId;
                }
                else
                {
                }

                Entity.PermissionId = permissionId;
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

        #region GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionRoleInputOutputGroupEntity Method
        public RoleInputOutputGroupPermissionPDSACollection GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionRoleInputOutputGroupEntity(RoleInputOutputGroupPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = RoleInputOutputGroupPermissionPDSAData.SelectFilters.ByRoleInputOutputGroupUid;
                    }
                    else
                    {
                    }

                    Entity.RoleInputOutputGroupUid = entity.RoleInputOutputGroupUid;
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
                return new RoleInputOutputGroupPermissionPDSACollection();
        }
        #endregion

        #region GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionRoleInputOutputGroup Method
        public RoleInputOutputGroupPermissionPDSACollection GetRoleInputOutputGroupPermissionPDSAsByFK_RoleInputOutputGroupPermissionRoleInputOutputGroup(Guid roleInputOutputGroupUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = RoleInputOutputGroupPermissionPDSAData.SelectFilters.ByRoleInputOutputGroupUid;
                }
                else
                {
                }

                Entity.RoleInputOutputGroupUid = roleInputOutputGroupUid;
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

