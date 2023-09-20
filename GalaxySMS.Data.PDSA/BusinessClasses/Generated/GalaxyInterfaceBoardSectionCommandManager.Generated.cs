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
    /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyInterfaceBoardSectionCommandPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyInterfaceBoardSectionCommandPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSectionCommandPDSAManager class
        /// </summary>
        public GalaxyInterfaceBoardSectionCommandPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSectionCommandPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyInterfaceBoardSectionCommandPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSectionCommandPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyInterfaceBoardSectionCommandPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyInterfaceBoardSectionCommandPDSA _Entity = null;
        private GalaxyInterfaceBoardSectionCommandPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyInterfaceBoardSectionCommandPDSA Entity
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
        public GalaxyInterfaceBoardSectionCommandPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyInterfaceBoardSectionCommandPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyInterfaceBoardSectionCommandPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyInterfaceBoardSectionCommandPDSAData DataObject { get; set; }
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
                Entity = new GalaxyInterfaceBoardSectionCommandPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyInterfaceBoardSectionCommandPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyInterfaceBoardSectionCommandPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyInterfaceBoardSectionCommandPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyInterfaceBoardSectionCommandPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyInterfaceBoardSectionCommandPDSA ret = new GalaxyInterfaceBoardSectionCommandPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionCommandUid))
                ret.GalaxyInterfaceBoardSectionCommandUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionCommandUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.CommandCode))
                ret.CommandCode = Convert.ToInt16(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.CommandCode]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.CultureName]);

            if (values.ContainsKey(GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
                ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSectionCommandPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardSectionCommandPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyInterfaceBoardSectionCommandPDSACollection</returns>
        public GalaxyInterfaceBoardSectionCommandPDSACollection BuildCollection()
        {
            GalaxyInterfaceBoardSectionCommandPDSACollection coll = new GalaxyInterfaceBoardSectionCommandPDSACollection();
            GalaxyInterfaceBoardSectionCommandPDSA entity = null;
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
        /// <returns>A collection of GalaxyInterfaceBoardSectionCommandPDSA objects</returns>
        public GalaxyInterfaceBoardSectionCommandPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyInterfaceBoardSectionCommandPDSACollection coll = new GalaxyInterfaceBoardSectionCommandPDSACollection();

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
        /// <returns>A collection of GalaxyInterfaceBoardSectionCommandPDSA objects</returns>
        public GalaxyInterfaceBoardSectionCommandPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardSectionCommandPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyInterfaceBoardSectionCommandPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandPDSAData.SelectFilters.Search;

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
        /// GalaxyInterfaceBoardSectionCommandPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyInterfaceBoardSectionCommandPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyInterfaceBoardSectionCommandPDSA object</param>
        /// <returns>An GalaxyInterfaceBoardSectionCommandPDSA object</returns>
        public GalaxyInterfaceBoardSectionCommandPDSA InitSearchFilter(GalaxyInterfaceBoardSectionCommandPDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.GalaxyInterfaceBoardSectionCommand table
        /// </summary>
        /// <param name="entity">An GalaxyInterfaceBoardSectionCommandPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(GalaxyInterfaceBoardSectionCommandPDSA entity)
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
        /// Updates an entity in the GCS.GalaxyInterfaceBoardSectionCommand table
        /// </summary>
        /// <param name="entity">An GalaxyInterfaceBoardSectionCommandPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(GalaxyInterfaceBoardSectionCommandPDSA entity)
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
        /// Deletes an entity from the GCS.GalaxyInterfaceBoardSectionCommand table
        /// </summary>
        /// <param name="entity">An GalaxyInterfaceBoardSectionCommandPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(GalaxyInterfaceBoardSectionCommandPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.GalaxyInterfaceBoardSectionCommandUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

