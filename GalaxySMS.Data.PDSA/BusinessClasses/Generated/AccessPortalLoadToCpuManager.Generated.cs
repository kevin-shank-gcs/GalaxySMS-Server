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
    /// This class is used when you need to add, edit, delete, select and validate data for the AccessPortalLoadToCpuPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortalLoadToCpuPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortalLoadToCpuPDSAManager class
        /// </summary>
        public AccessPortalLoadToCpuPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalLoadToCpuPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortalLoadToCpuPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalLoadToCpuPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortalLoadToCpuPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortalLoadToCpuPDSA _Entity = null;
        private AccessPortalLoadToCpuPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortalLoadToCpuPDSA Entity
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
        public AccessPortalLoadToCpuPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortalLoadToCpuPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortalLoadToCpuPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortalLoadToCpuPDSAData DataObject { get; set; }
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
                Entity = new AccessPortalLoadToCpuPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortalLoadToCpuPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortalLoadToCpuPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessPortalLoadToCpuPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortalLoadToCpuPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortalLoadToCpuPDSA ret = new AccessPortalLoadToCpuPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid))
                ret.AccessPortalLoadToCpuUid = PDSAProperty.ConvertToGuid(values[AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalLoadToCpuUid]);

            if (values.ContainsKey(AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid))
                ret.AccessPortalGalaxyHardwareAddressUid = PDSAProperty.ConvertToGuid(values[AccessPortalLoadToCpuPDSAValidator.ColumnNames.AccessPortalGalaxyHardwareAddressUid]);

            if (values.ContainsKey(AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[AccessPortalLoadToCpuPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate))
                ret.LastForceLoadDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastForceLoadDate]);

            if (values.ContainsKey(AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate))
                ret.LastLoadedDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalLoadToCpuPDSAValidator.ColumnNames.LastLoadedDate]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortalLoadToCpuPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortalLoadToCpuPDSACollection</returns>
        public AccessPortalLoadToCpuPDSACollection BuildCollection()
        {
            AccessPortalLoadToCpuPDSACollection coll = new AccessPortalLoadToCpuPDSACollection();
            AccessPortalLoadToCpuPDSA entity = null;
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
        /// <returns>A collection of AccessPortalLoadToCpuPDSA objects</returns>
        public AccessPortalLoadToCpuPDSACollection BuildCollection(DataSet ds)
        {
            AccessPortalLoadToCpuPDSACollection coll = new AccessPortalLoadToCpuPDSACollection();

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
        /// <returns>A collection of AccessPortalLoadToCpuPDSA objects</returns>
        public AccessPortalLoadToCpuPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortalLoadToCpuPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortalLoadToCpuPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortalLoadToCpuPDSAData.SelectFilters.Search;

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
        /// AccessPortalLoadToCpuPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalLoadToCpuPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortalLoadToCpuPDSA object</param>
        /// <returns>An AccessPortalLoadToCpuPDSA object</returns>
        public AccessPortalLoadToCpuPDSA InitSearchFilter(AccessPortalLoadToCpuPDSA searchEntity)
        {
            searchEntity.AccessPortalLoadToCpuUid = Guid.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortalLoadToCpuPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AccessPortalLoadToCpu table
        /// </summary>
        /// <param name="entity">An AccessPortalLoadToCpuPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AccessPortalLoadToCpuPDSA entity)
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
        /// Updates an entity in the GCS.AccessPortalLoadToCpu table
        /// </summary>
        /// <param name="entity">An AccessPortalLoadToCpuPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AccessPortalLoadToCpuPDSA entity)
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
        /// Deletes an entity from the GCS.AccessPortalLoadToCpu table
        /// </summary>
        /// <param name="entity">An AccessPortalLoadToCpuPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AccessPortalLoadToCpuPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AccessPortalLoadToCpuUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetAccessPortalLoadToCpuPDSAsByFK_AccessPortalLoadToCpuGalaxyCpuEntity Method
        public AccessPortalLoadToCpuPDSACollection GetAccessPortalLoadToCpuPDSAsByFK_AccessPortalLoadToCpuGalaxyCpuEntity(GalaxyCpuPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AccessPortalLoadToCpuPDSAData.SelectFilters.ByCpuUid;
                    }
                    else
                    {
                    }

                    Entity.CpuUid = entity.CpuUid;
                }
                catch (Exception ex)
                {
                    // This is here for design time exceptions
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                return BuildCollection();
            }
            else
                return new AccessPortalLoadToCpuPDSACollection();
        }
        #endregion

        #region GetAccessPortalLoadToCpuPDSAsByFK_AccessPortalLoadToCpuGalaxyCpu Method
        public AccessPortalLoadToCpuPDSACollection GetAccessPortalLoadToCpuPDSAsByFK_AccessPortalLoadToCpuGalaxyCpu(Guid cpuUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AccessPortalLoadToCpuPDSAData.SelectFilters.ByCpuUid;
                }
                else
                {
                }

                Entity.CpuUid = cpuUid;
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
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

            return BuildCollection();
        }
        #endregion

    }
}

