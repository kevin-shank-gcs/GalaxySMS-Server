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
    /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyPanelModelInterfaceBoardSectionModePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyPanelModelInterfaceBoardSectionModePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyPanelModelInterfaceBoardSectionModePDSAManager class
        /// </summary>
        public GalaxyPanelModelInterfaceBoardSectionModePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyPanelModelInterfaceBoardSectionModePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyPanelModelInterfaceBoardSectionModePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyPanelModelInterfaceBoardSectionModePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyPanelModelInterfaceBoardSectionModePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyPanelModelInterfaceBoardSectionModePDSA _Entity = null;
        private GalaxyPanelModelInterfaceBoardSectionModePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyPanelModelInterfaceBoardSectionModePDSA Entity
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
        public GalaxyPanelModelInterfaceBoardSectionModePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyPanelModelInterfaceBoardSectionModePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyPanelModelInterfaceBoardSectionModePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyPanelModelInterfaceBoardSectionModePDSAData DataObject { get; set; }
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
                Entity = new GalaxyPanelModelInterfaceBoardSectionModePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyPanelModelInterfaceBoardSectionModePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyPanelModelInterfaceBoardSectionModePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyPanelModelInterfaceBoardSectionModePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyPanelModelInterfaceBoardSectionModePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyPanelModelInterfaceBoardSectionModePDSA ret = new GalaxyPanelModelInterfaceBoardSectionModePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardSectionModeUid))
                ret.GalaxyPanelModelInterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardSectionModeUid]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.GalaxyPanelModelUid))
                ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.GalaxyPanelModelUid]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
                ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyPanelModelInterfaceBoardSectionModePDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyPanelModelInterfaceBoardSectionModePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyPanelModelInterfaceBoardSectionModePDSACollection</returns>
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection BuildCollection()
        {
            GalaxyPanelModelInterfaceBoardSectionModePDSACollection coll = new GalaxyPanelModelInterfaceBoardSectionModePDSACollection();
            GalaxyPanelModelInterfaceBoardSectionModePDSA entity = null;
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
        /// <returns>A collection of GalaxyPanelModelInterfaceBoardSectionModePDSA objects</returns>
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection BuildCollection(DataSet ds)
        {
            GalaxyPanelModelInterfaceBoardSectionModePDSACollection coll = new GalaxyPanelModelInterfaceBoardSectionModePDSACollection();

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
        /// <returns>A collection of GalaxyPanelModelInterfaceBoardSectionModePDSA objects</returns>
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyPanelModelInterfaceBoardSectionModePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyPanelModelInterfaceBoardSectionModePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyPanelModelInterfaceBoardSectionModePDSAData.SelectFilters.Search;

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
        /// GalaxyPanelModelInterfaceBoardSectionModePDSA.SearchEntity = mgr.InitSearchFilter(GalaxyPanelModelInterfaceBoardSectionModePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyPanelModelInterfaceBoardSectionModePDSA object</param>
        /// <returns>An GalaxyPanelModelInterfaceBoardSectionModePDSA object</returns>
        public GalaxyPanelModelInterfaceBoardSectionModePDSA InitSearchFilter(GalaxyPanelModelInterfaceBoardSectionModePDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyPanelModelInterfaceBoardSectionModePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.GalaxyPanelModelInterfaceBoardSectionMode table
        /// </summary>
        /// <param name="entity">An GalaxyPanelModelInterfaceBoardSectionModePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(GalaxyPanelModelInterfaceBoardSectionModePDSA entity)
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
        /// Updates an entity in the GCS.GalaxyPanelModelInterfaceBoardSectionMode table
        /// </summary>
        /// <param name="entity">An GalaxyPanelModelInterfaceBoardSectionModePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(GalaxyPanelModelInterfaceBoardSectionModePDSA entity)
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
        /// Deletes an entity from the GCS.GalaxyPanelModelInterfaceBoardSectionMode table
        /// </summary>
        /// <param name="entity">An GalaxyPanelModelInterfaceBoardSectionModePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(GalaxyPanelModelInterfaceBoardSectionModePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.GalaxyPanelModelInterfaceBoardSectionModeUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModePanelModelEntity Method
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModePanelModelEntity(GalaxyPanelModelPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyPanelModelInterfaceBoardSectionModePDSAData.SelectFilters.ByGalaxyPanelModelUid;
                    }
                    else
                    {
                    }

                    Entity.GalaxyPanelModelUid = entity.GalaxyPanelModelUid;
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
                return new GalaxyPanelModelInterfaceBoardSectionModePDSACollection();
        }
        #endregion

        #region GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModePanelModel Method
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModePanelModel(Guid galaxyPanelModelUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyPanelModelInterfaceBoardSectionModePDSAData.SelectFilters.ByGalaxyPanelModelUid;
                }
                else
                {
                }

                Entity.GalaxyPanelModelUid = galaxyPanelModelUid;
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

        #region GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModeSectionModeEntity Method
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModeSectionModeEntity(InterfaceBoardSectionModePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyPanelModelInterfaceBoardSectionModePDSAData.SelectFilters.ByInterfaceBoardSectionModeUid;
                    }
                    else
                    {
                    }

                    Entity.InterfaceBoardSectionModeUid = entity.InterfaceBoardSectionModeUid;
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
                return new GalaxyPanelModelInterfaceBoardSectionModePDSACollection();
        }
        #endregion

        #region GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModeSectionMode Method
        public GalaxyPanelModelInterfaceBoardSectionModePDSACollection GetGalaxyPanelModelInterfaceBoardSectionModePDSAsByFK_GalaxyPanelModelInterfaceBoardSectionModeSectionMode(Guid interfaceBoardSectionModeUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyPanelModelInterfaceBoardSectionModePDSAData.SelectFilters.ByInterfaceBoardSectionModeUid;
                }
                else
                {
                }

                Entity.InterfaceBoardSectionModeUid = interfaceBoardSectionModeUid;
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

