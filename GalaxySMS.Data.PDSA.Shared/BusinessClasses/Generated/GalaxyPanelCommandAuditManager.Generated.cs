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
    /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyPanelCommandAuditPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyPanelCommandAuditPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyPanelCommandAuditPDSAManager class
        /// </summary>
        public GalaxyPanelCommandAuditPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyPanelCommandAuditPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyPanelCommandAuditPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyPanelCommandAuditPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyPanelCommandAuditPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyPanelCommandAuditPDSA _Entity = null;
        private GalaxyPanelCommandAuditPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyPanelCommandAuditPDSA Entity
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
        public GalaxyPanelCommandAuditPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyPanelCommandAuditPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyPanelCommandAuditPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyPanelCommandAuditPDSAData DataObject { get; set; }
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
                Entity = new GalaxyPanelCommandAuditPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyPanelCommandAuditPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyPanelCommandAuditPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyPanelCommandAuditPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyPanelCommandAuditPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyPanelCommandAuditPDSA ret = new GalaxyPanelCommandAuditPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.GalaxyPanelCommandAuditUid))
                ret.GalaxyPanelCommandAuditUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.GalaxyPanelCommandAuditUid]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.GalaxyPanelCommandUid))
                ret.GalaxyPanelCommandUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.GalaxyPanelCommandUid]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.UserId))
                ret.UserId = PDSAProperty.ConvertToGuid(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.UserId]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(GalaxyPanelCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyPanelCommandAuditPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyPanelCommandAuditPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyPanelCommandAuditPDSACollection</returns>
        public GalaxyPanelCommandAuditPDSACollection BuildCollection()
        {
            GalaxyPanelCommandAuditPDSACollection coll = new GalaxyPanelCommandAuditPDSACollection();
            GalaxyPanelCommandAuditPDSA entity = null;
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
        /// <returns>A collection of GalaxyPanelCommandAuditPDSA objects</returns>
        public GalaxyPanelCommandAuditPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyPanelCommandAuditPDSACollection coll = new GalaxyPanelCommandAuditPDSACollection();

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
        /// <returns>A collection of GalaxyPanelCommandAuditPDSA objects</returns>
        public GalaxyPanelCommandAuditPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyPanelCommandAuditPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyPanelCommandAuditPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.Search;

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
        /// GalaxyPanelCommandAuditPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyPanelCommandAuditPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyPanelCommandAuditPDSA object</param>
        /// <returns>An GalaxyPanelCommandAuditPDSA object</returns>
        public GalaxyPanelCommandAuditPDSA InitSearchFilter(GalaxyPanelCommandAuditPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.GalaxyPanelCommandAudit table
        /// </summary>
        /// <param name="entity">An GalaxyPanelCommandAuditPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(GalaxyPanelCommandAuditPDSA entity)
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
        /// Updates an entity in the GCS.GalaxyPanelCommandAudit table
        /// </summary>
        /// <param name="entity">An GalaxyPanelCommandAuditPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(GalaxyPanelCommandAuditPDSA entity)
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
        /// Deletes an entity from the GCS.GalaxyPanelCommandAudit table
        /// </summary>
        /// <param name="entity">An GalaxyPanelCommandAuditPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(GalaxyPanelCommandAuditPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.GalaxyPanelCommandAuditUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanelEntity Method
        public GalaxyPanelCommandAuditPDSACollection GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanelEntity(GalaxyPanelPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.ByGalaxyPanelUid;
                    }
                    else
                    {
                    }

                    Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
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
                return new GalaxyPanelCommandAuditPDSACollection();
        }
        #endregion

        #region GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanel Method
        public GalaxyPanelCommandAuditPDSACollection GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanel(Guid galaxyPanelUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.ByGalaxyPanelUid;
                }
                else
                {
                }

                Entity.GalaxyPanelUid = galaxyPanelUid;
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

        #region GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanelCommandEntity Method
        public GalaxyPanelCommandAuditPDSACollection GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanelCommandEntity(GalaxyPanelCommandPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.ByGalaxyPanelCommandUid;
                    }
                    else
                    {
                    }

                    Entity.GalaxyPanelCommandUid = entity.GalaxyPanelCommandUid;
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
                return new GalaxyPanelCommandAuditPDSACollection();
        }
        #endregion

        #region GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanelCommand Method
        public GalaxyPanelCommandAuditPDSACollection GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGalaxyPanelCommand(Guid galaxyPanelCommandUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.ByGalaxyPanelCommandUid;
                }
                else
                {
                }

                Entity.GalaxyPanelCommandUid = galaxyPanelCommandUid;
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

        #region GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGcsUserEntity Method
        public GalaxyPanelCommandAuditPDSACollection GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGcsUserEntity(gcsUserPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.ByUserId;
                    }
                    else
                    {
                    }

                    Entity.UserId = entity.UserId;
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
                return new GalaxyPanelCommandAuditPDSACollection();
        }
        #endregion

        #region GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGcsUser Method
        public GalaxyPanelCommandAuditPDSACollection GetGalaxyPanelCommandAuditPDSAsByFK_GalaxyPanelCommandAuditGcsUser(Guid userId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.ByUserId;
                }
                else
                {
                }

                Entity.UserId = userId;
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

