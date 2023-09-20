using System;
using System.Collections.Generic;
using System.Data;

using PDSA;
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
    /// This class should be used when you need to select data for the InputOutputGroupAssignmentViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputOutputGroupAssignmentViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputOutputGroupAssignmentViewPDSAManager class
        /// </summary>
        public InputOutputGroupAssignmentViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the InputOutputGroupAssignmentViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputOutputGroupAssignmentViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the InputOutputGroupAssignmentViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputOutputGroupAssignmentViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputOutputGroupAssignmentViewPDSA _Entity = null;
        private InputOutputGroupAssignmentViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputOutputGroupAssignmentViewPDSA Entity
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
        public InputOutputGroupAssignmentViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputOutputGroupAssignmentViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputOutputGroupAssignmentViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputOutputGroupAssignmentViewPDSAData DataObject { get; set; }
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
                Entity = new InputOutputGroupAssignmentViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputOutputGroupAssignmentViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputOutputGroupAssignmentViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputOutputGroupAssignmentViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputOutputGroupAssignmentViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputOutputGroupAssignmentViewPDSA ret = new InputOutputGroupAssignmentViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid))
                ret.InputOutputGroupAssignmentUid = PDSAProperty.ConvertToGuid(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid))
                ret.InputOutputGroupUid = PDSAProperty.ConvertToGuid(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.InputOutputGroupUid]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex))
                ret.OffsetIndex = Convert.ToInt16(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.OffsetIndex]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName))
                ret.DeviceName = PDSAString.ConvertToStringTrim(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceName]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType))
                ret.EventType = PDSAString.ConvertToStringTrim(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.EventType]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType))
                ret.DeviceType = PDSAString.ConvertToStringTrim(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.DeviceType]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup))
                ret.LocalIOGroup = Convert.ToBoolean(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.LocalIOGroup]);

            if (values.ContainsKey(InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[InputOutputGroupAssignmentViewPDSAValidator.ColumnNames.GalaxyPanelUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputOutputGroupAssignmentViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputOutputGroupAssignmentViewPDSACollection</returns>
        public InputOutputGroupAssignmentViewPDSACollection BuildCollection()
        {
            InputOutputGroupAssignmentViewPDSACollection coll = new InputOutputGroupAssignmentViewPDSACollection();
            InputOutputGroupAssignmentViewPDSA entity = null;
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
        /// <returns>A collection of InputOutputGroupAssignmentViewPDSA objects</returns>
        public InputOutputGroupAssignmentViewPDSACollection BuildCollection(DataSet ds)
        {
            InputOutputGroupAssignmentViewPDSACollection coll = new InputOutputGroupAssignmentViewPDSACollection();

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
        /// <returns>A collection of InputOutputGroupAssignmentViewPDSA objects</returns>
        public InputOutputGroupAssignmentViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputOutputGroupAssignmentViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputOutputGroupAssignmentViewPDSACollection), BuildCollection());
        }
        #endregion

        #region GetDataSet Method
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
            DataObject.SelectFilter = InputOutputGroupAssignmentViewPDSAData.SelectFilters.Search;

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
        /// InputOutputGroupAssignmentViewPDSA.SearchEntity = mgr.InitSearchFilter(InputOutputGroupAssignmentViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputOutputGroupAssignmentViewPDSA object</param>
        /// <returns>An InputOutputGroupAssignmentViewPDSA object</returns>
        public InputOutputGroupAssignmentViewPDSA InitSearchFilter(InputOutputGroupAssignmentViewPDSA searchEntity)
        {
            searchEntity.DeviceName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputOutputGroupAssignmentViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current InputOutputGroupAssignmentViewPDSA
        /// </summary>
        /// <returns>A cloned InputOutputGroupAssignmentViewPDSA object</returns>
        public InputOutputGroupAssignmentViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in InputOutputGroupAssignmentViewPDSA
        /// </summary>
        /// <param name="entityToClone">The InputOutputGroupAssignmentViewPDSA entity to clone</param>
        /// <returns>A cloned InputOutputGroupAssignmentViewPDSA object</returns>
        public InputOutputGroupAssignmentViewPDSA CloneEntity(InputOutputGroupAssignmentViewPDSA entityToClone)
        {
            InputOutputGroupAssignmentViewPDSA newEntity = new InputOutputGroupAssignmentViewPDSA();

            newEntity.InputOutputGroupAssignmentUid = entityToClone.InputOutputGroupAssignmentUid;
            newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
            newEntity.OffsetIndex = entityToClone.OffsetIndex;
            newEntity.DeviceName = entityToClone.DeviceName;
            newEntity.EventType = entityToClone.EventType;
            newEntity.DeviceType = entityToClone.DeviceType;
            newEntity.Display = entityToClone.Display;
            newEntity.LocalIOGroup = entityToClone.LocalIOGroup;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;

            return newEntity;
        }
        #endregion
    }
}
