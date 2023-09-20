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
    /// This class is used when you need to add, edit, delete, select and validate data for the InputDeviceAlertEventTypePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputDeviceAlertEventTypePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputDeviceAlertEventTypePDSAManager class
        /// </summary>
        public InputDeviceAlertEventTypePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputDeviceAlertEventTypePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputDeviceAlertEventTypePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputDeviceAlertEventTypePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputDeviceAlertEventTypePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputDeviceAlertEventTypePDSA _Entity = null;
        private InputDeviceAlertEventTypePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputDeviceAlertEventTypePDSA Entity
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
        public InputDeviceAlertEventTypePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputDeviceAlertEventTypePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputDeviceAlertEventTypePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputDeviceAlertEventTypePDSAData DataObject { get; set; }
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
                Entity = new InputDeviceAlertEventTypePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputDeviceAlertEventTypePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputDeviceAlertEventTypePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputDeviceAlertEventTypePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputDeviceAlertEventTypePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputDeviceAlertEventTypePDSA ret = new InputDeviceAlertEventTypePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid))
                ret.InputDeviceAlertEventTypeUid = PDSAProperty.ConvertToGuid(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.InputDeviceAlertEventTypeUid]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.Tag))
                ret.Tag = PDSAString.ConvertToStringTrim(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.Tag]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge))
                ret.CanAcknowledge = Convert.ToBoolean(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanAcknowledge]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset))
                ret.CanHaveInputOutputGroupOffset = Convert.ToBoolean(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveInputOutputGroupOffset]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule))
                ret.CanHaveSchedule = Convert.ToBoolean(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveSchedule]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio))
                ret.CanHaveAudio = Convert.ToBoolean(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveAudio]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions))
                ret.CanHaveInstructions = Convert.ToBoolean(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.CanHaveInstructions]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(InputDeviceAlertEventTypePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[InputDeviceAlertEventTypePDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputDeviceAlertEventTypePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputDeviceAlertEventTypePDSACollection</returns>
        public InputDeviceAlertEventTypePDSACollection BuildCollection()
        {
            InputDeviceAlertEventTypePDSACollection coll = new InputDeviceAlertEventTypePDSACollection();
            InputDeviceAlertEventTypePDSA entity = null;
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
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}", ex);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    this.Log().Error($"InnerException in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{innerEx}", innerEx);
                    //System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
}

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of InputDeviceAlertEventTypePDSA objects</returns>
        public InputDeviceAlertEventTypePDSACollection BuildCollection(DataSet ds)
        {
            InputDeviceAlertEventTypePDSACollection coll = new InputDeviceAlertEventTypePDSACollection();

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
        /// <returns>A collection of InputDeviceAlertEventTypePDSA objects</returns>
        public InputDeviceAlertEventTypePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputDeviceAlertEventTypePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputDeviceAlertEventTypePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputDeviceAlertEventTypePDSAData.SelectFilters.Search;

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
        /// InputDeviceAlertEventTypePDSA.SearchEntity = mgr.InitSearchFilter(InputDeviceAlertEventTypePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputDeviceAlertEventTypePDSA object</param>
        /// <returns>An InputDeviceAlertEventTypePDSA object</returns>
        public InputDeviceAlertEventTypePDSA InitSearchFilter(InputDeviceAlertEventTypePDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputDeviceAlertEventTypePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.InputDeviceAlertEventType table
        /// </summary>
        /// <param name="entity">An InputDeviceAlertEventTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(InputDeviceAlertEventTypePDSA entity)
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
        /// Updates an entity in the GCS.InputDeviceAlertEventType table
        /// </summary>
        /// <param name="entity">An InputDeviceAlertEventTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(InputDeviceAlertEventTypePDSA entity)
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
        /// Deletes an entity from the GCS.InputDeviceAlertEventType table
        /// </summary>
        /// <param name="entity">An InputDeviceAlertEventTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(InputDeviceAlertEventTypePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.InputDeviceAlertEventTypeUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

