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
    /// This class is used when you need to add, edit, delete, select and validate data for the AccessPortalAlertEventTypePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortalAlertEventTypePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortalAlertEventTypePDSAManager class
        /// </summary>
        public AccessPortalAlertEventTypePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalAlertEventTypePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortalAlertEventTypePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalAlertEventTypePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortalAlertEventTypePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortalAlertEventTypePDSA _Entity = null;
        private AccessPortalAlertEventTypePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortalAlertEventTypePDSA Entity
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
        public AccessPortalAlertEventTypePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortalAlertEventTypePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortalAlertEventTypePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortalAlertEventTypePDSAData DataObject { get; set; }
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
                Entity = new AccessPortalAlertEventTypePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortalAlertEventTypePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortalAlertEventTypePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessPortalAlertEventTypePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortalAlertEventTypePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortalAlertEventTypePDSA ret = new AccessPortalAlertEventTypePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.AccessPortalAlertEventTypeUid))
                ret.AccessPortalAlertEventTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.AccessPortalAlertEventTypeUid]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.Tag))
                ret.Tag = PDSAString.ConvertToStringTrim(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.Tag]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge))
                ret.CanAcknowledge = Convert.ToBoolean(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.CultureName]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset))
                ret.CanHaveInputOutputGroupOffset = Convert.ToBoolean(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule))
                ret.CanHaveSchedule = Convert.ToBoolean(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio))
                ret.CanHaveAudio = Convert.ToBoolean(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio]);

            if (values.ContainsKey(AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions))
                ret.CanHaveInstructions = Convert.ToBoolean(values[AccessPortalAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortalAlertEventTypePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortalAlertEventTypePDSACollection</returns>
        public AccessPortalAlertEventTypePDSACollection BuildCollection()
        {
            AccessPortalAlertEventTypePDSACollection coll = new AccessPortalAlertEventTypePDSACollection();
            AccessPortalAlertEventTypePDSA entity = null;
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
        /// <returns>A collection of AccessPortalAlertEventTypePDSA objects</returns>
        public AccessPortalAlertEventTypePDSACollection BuildCollection(DataSet ds)
        {
            AccessPortalAlertEventTypePDSACollection coll = new AccessPortalAlertEventTypePDSACollection();

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
        /// <returns>A collection of AccessPortalAlertEventTypePDSA objects</returns>
        public AccessPortalAlertEventTypePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortalAlertEventTypePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortalAlertEventTypePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortalAlertEventTypePDSAData.SelectFilters.Search;

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
        /// AccessPortalAlertEventTypePDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalAlertEventTypePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortalAlertEventTypePDSA object</param>
        /// <returns>An AccessPortalAlertEventTypePDSA object</returns>
        public AccessPortalAlertEventTypePDSA InitSearchFilter(AccessPortalAlertEventTypePDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortalAlertEventTypePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AccessPortalAlertEventType table
        /// </summary>
        /// <param name="entity">An AccessPortalAlertEventTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AccessPortalAlertEventTypePDSA entity)
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
        /// Updates an entity in the GCS.AccessPortalAlertEventType table
        /// </summary>
        /// <param name="entity">An AccessPortalAlertEventTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AccessPortalAlertEventTypePDSA entity)
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
        /// Deletes an entity from the GCS.AccessPortalAlertEventType table
        /// </summary>
        /// <param name="entity">An AccessPortalAlertEventTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AccessPortalAlertEventTypePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AccessPortalAlertEventTypeUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

