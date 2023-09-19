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
    /// This class is used when you need to add, edit, delete, select and validate data for the InputOutputGroupCommandPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputOutputGroupCommandPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputOutputGroupCommandPDSAManager class
        /// </summary>
        public InputOutputGroupCommandPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputOutputGroupCommandPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputOutputGroupCommandPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputOutputGroupCommandPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputOutputGroupCommandPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputOutputGroupCommandPDSA _Entity = null;
        private InputOutputGroupCommandPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputOutputGroupCommandPDSA Entity
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
        public InputOutputGroupCommandPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputOutputGroupCommandPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputOutputGroupCommandPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputOutputGroupCommandPDSAData DataObject { get; set; }
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
                Entity = new InputOutputGroupCommandPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputOutputGroupCommandPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputOutputGroupCommandPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "InputOutputGroupCommandPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputOutputGroupCommandPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputOutputGroupCommandPDSA ret = new InputOutputGroupCommandPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid))
                ret.InputOutputGroupCommandUid = PDSAProperty.ConvertToGuid(values[InputOutputGroupCommandPDSAValidator.ColumnNames.InputOutputGroupCommandUid]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[InputOutputGroupCommandPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[InputOutputGroupCommandPDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[InputOutputGroupCommandPDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[InputOutputGroupCommandPDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode))
                ret.CommandCode = Convert.ToInt16(values[InputOutputGroupCommandPDSAValidator.ColumnNames.CommandCode]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[InputOutputGroupCommandPDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand))
                ret.IsAccessPortalGroupCommand = Convert.ToBoolean(values[InputOutputGroupCommandPDSAValidator.ColumnNames.IsAccessPortalGroupCommand]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[InputOutputGroupCommandPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[InputOutputGroupCommandPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[InputOutputGroupCommandPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[InputOutputGroupCommandPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[InputOutputGroupCommandPDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputOutputGroupCommandPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputOutputGroupCommandPDSACollection</returns>
        public InputOutputGroupCommandPDSACollection BuildCollection()
        {
            InputOutputGroupCommandPDSACollection coll = new InputOutputGroupCommandPDSACollection();
            InputOutputGroupCommandPDSA entity = null;
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
        /// <returns>A collection of InputOutputGroupCommandPDSA objects</returns>
        public InputOutputGroupCommandPDSACollection BuildCollection(DataSet ds)
        {
            InputOutputGroupCommandPDSACollection coll = new InputOutputGroupCommandPDSACollection();

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
        /// <returns>A collection of InputOutputGroupCommandPDSA objects</returns>
        public InputOutputGroupCommandPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputOutputGroupCommandPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputOutputGroupCommandPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputOutputGroupCommandPDSAData.SelectFilters.Search;

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
        /// InputOutputGroupCommandPDSA.SearchEntity = mgr.InitSearchFilter(InputOutputGroupCommandPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputOutputGroupCommandPDSA object</param>
        /// <returns>An InputOutputGroupCommandPDSA object</returns>
        public InputOutputGroupCommandPDSA InitSearchFilter(InputOutputGroupCommandPDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputOutputGroupCommandPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.InputOutputGroupCommand table
        /// </summary>
        /// <param name="entity">An InputOutputGroupCommandPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(InputOutputGroupCommandPDSA entity)
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
        /// Updates an entity in the GCS.InputOutputGroupCommand table
        /// </summary>
        /// <param name="entity">An InputOutputGroupCommandPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(InputOutputGroupCommandPDSA entity)
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
        /// Deletes an entity from the GCS.InputOutputGroupCommand table
        /// </summary>
        /// <param name="entity">An InputOutputGroupCommandPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(InputOutputGroupCommandPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.InputOutputGroupCommandUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

