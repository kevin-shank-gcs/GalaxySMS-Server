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
    /// This class should be used when you need to select data for the GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager class
        /// </summary>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA _Entity = null;
        private GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA Entity
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
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA ret = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceAssignmentUid))
                ret.GalaxyOutputDeviceInputSourceAssignmentUid = PDSAProperty.ConvertToGuid(values[GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceAssignmentUid]);

            if (values.ContainsKey(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid))
                ret.GalaxyOutputDeviceInputSourceUid = PDSAProperty.ConvertToGuid(values[GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid]);

            if (values.ContainsKey(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid))
                ret.InputOutputGroupAssignmentUid = PDSAProperty.ConvertToGuid(values[GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupAssignmentUid]);

            if (values.ContainsKey(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex))
                ret.OffsetIndex = Convert.ToInt16(values[GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex]);

            if (values.ContainsKey(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.DeviceName))
                ret.DeviceName = PDSAString.ConvertToStringTrim(values[GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.DeviceName]);

            if (values.ContainsKey(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.EventType))
                ret.EventType = PDSAString.ConvertToStringTrim(values[GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAValidator.ColumnNames.EventType]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection BuildCollection()
        {
            GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection coll = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection();
            GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA objects</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection coll = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA objects</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA object</param>
        /// <returns>An GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA object</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA InitSearchFilter(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.DeviceName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA object</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA object</returns>
        public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA CloneEntity(GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA entityToClone)
        {
            GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA newEntity = new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataPDSA();

            newEntity.GalaxyOutputDeviceInputSourceAssignmentUid = entityToClone.GalaxyOutputDeviceInputSourceAssignmentUid;
            newEntity.GalaxyOutputDeviceInputSourceUid = entityToClone.GalaxyOutputDeviceInputSourceUid;
            newEntity.InputOutputGroupAssignmentUid = entityToClone.InputOutputGroupAssignmentUid;
            newEntity.OffsetIndex = entityToClone.OffsetIndex;
            newEntity.DeviceName = entityToClone.DeviceName;
            newEntity.EventType = entityToClone.EventType;

            return newEntity;
        }
        #endregion
    }
}
