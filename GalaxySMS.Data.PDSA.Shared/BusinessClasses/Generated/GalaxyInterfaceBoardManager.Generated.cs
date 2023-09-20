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
    /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyInterfaceBoardPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyInterfaceBoardPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardPDSAManager class
        /// </summary>
        public GalaxyInterfaceBoardPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyInterfaceBoardPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyInterfaceBoardPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyInterfaceBoardPDSA _Entity = null;
        private GalaxyInterfaceBoardPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyInterfaceBoardPDSA Entity
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
        public GalaxyInterfaceBoardPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyInterfaceBoardPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyInterfaceBoardPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyInterfaceBoardPDSAData DataObject { get; set; }
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
                Entity = new GalaxyInterfaceBoardPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyInterfaceBoardPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyInterfaceBoardPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "GalaxyInterfaceBoardPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyInterfaceBoardPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyInterfaceBoardPDSA ret = new GalaxyInterfaceBoardPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.InterfaceBoardTypeUid))
                ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[GalaxyInterfaceBoardPDSAValidator.ColumnNames.ClusterGroupId]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyInterfaceBoardPDSACollection</returns>
        public GalaxyInterfaceBoardPDSACollection BuildCollection()
        {
            GalaxyInterfaceBoardPDSACollection coll = new GalaxyInterfaceBoardPDSACollection();
            GalaxyInterfaceBoardPDSA entity = null;
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
            }

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of GalaxyInterfaceBoardPDSA objects</returns>
        public GalaxyInterfaceBoardPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyInterfaceBoardPDSACollection coll = new GalaxyInterfaceBoardPDSACollection();

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
        /// <returns>A collection of GalaxyInterfaceBoardPDSA objects</returns>
        public GalaxyInterfaceBoardPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyInterfaceBoardPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.Search;

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
        /// GalaxyInterfaceBoardPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyInterfaceBoardPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyInterfaceBoardPDSA object</param>
        /// <returns>An GalaxyInterfaceBoardPDSA object</returns>
        public GalaxyInterfaceBoardPDSA InitSearchFilter(GalaxyInterfaceBoardPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.GalaxyInterfaceBoard table
        /// </summary>
        /// <param name="entity">An GalaxyInterfaceBoardPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(GalaxyInterfaceBoardPDSA entity)
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
        /// Updates an entity in the GCS.GalaxyInterfaceBoard table
        /// </summary>
        /// <param name="entity">An GalaxyInterfaceBoardPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(GalaxyInterfaceBoardPDSA entity)
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
        /// Deletes an entity from the GCS.GalaxyInterfaceBoard table
        /// </summary>
        /// <param name="entity">An GalaxyInterfaceBoardPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(GalaxyInterfaceBoardPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.GalaxyInterfaceBoardUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToGalaxyPanelEntity Method
        public GalaxyInterfaceBoardPDSACollection GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToGalaxyPanelEntity(GalaxyPanelPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByGalaxyPanelUid;
                    }
                    else
                    {
                    }

                    Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
                }
                catch (Exception ex)
                {
                    // This is here for design time exceptions
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
                return new GalaxyInterfaceBoardPDSACollection();
        }
        #endregion

        #region GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToGalaxyPanel Method
        public GalaxyInterfaceBoardPDSACollection GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToGalaxyPanel(Guid galaxyPanelUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByGalaxyPanelUid;
                }
                else
                {
                }

                Entity.GalaxyPanelUid = galaxyPanelUid;
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
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
        #endregion

        #region GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToInterfaceBoardTypeEntity Method
        public GalaxyInterfaceBoardPDSACollection GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToInterfaceBoardTypeEntity(InterfaceBoardTypePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByInterfaceBoardTypeUid;
                    }
                    else
                    {
                    }

                    Entity.InterfaceBoardTypeUid = entity.InterfaceBoardTypeUid;
                }
                catch (Exception ex)
                {
                    // This is here for design time exceptions
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
                return new GalaxyInterfaceBoardPDSACollection();
        }
        #endregion

        #region GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToInterfaceBoardType Method
        public GalaxyInterfaceBoardPDSACollection GetGalaxyInterfaceBoardPDSAsByFK_GalaxyInterfaceBoardToInterfaceBoardType(Guid interfaceBoardTypeUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = GalaxyInterfaceBoardPDSAData.SelectFilters.ByInterfaceBoardTypeUid;
                }
                else
                {
                }

                Entity.InterfaceBoardTypeUid = interfaceBoardTypeUid;
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
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
        #endregion

    }
}

