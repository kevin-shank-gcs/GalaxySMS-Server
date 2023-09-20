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
    /// This class should be used when you need to select data for the GalaxyPanelAlarmSettings_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager class
        /// </summary>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyPanelAlarmSettings_PanelLoadDataPDSA _Entity = null;
        private GalaxyPanelAlarmSettings_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSA Entity
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
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyPanelAlarmSettings_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new GalaxyPanelAlarmSettings_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyPanelAlarmSettings_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyPanelAlarmSettings_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyPanelAlarmSettings_PanelLoadDataPDSA ret = new GalaxyPanelAlarmSettings_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName))
                ret.EntityName = PDSAString.ConvertToStringTrim(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityName]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.ClusterName]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag))
                ret.Tag = PDSAString.ConvertToStringTrim(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.Tag]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber))
                ret.IOGroupNumber = Convert.ToInt32(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber]);

            if (values.ContainsKey(GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex))
                ret.OffsetIndex = Convert.ToInt16(values[GalaxyPanelAlarmSettings_PanelLoadDataPDSAValidator.ColumnNames.OffsetIndex]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyPanelAlarmSettings_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection BuildCollection()
        {
            GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection coll = new GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection();
            GalaxyPanelAlarmSettings_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of GalaxyPanelAlarmSettings_PanelLoadDataPDSA objects</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection coll = new GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of GalaxyPanelAlarmSettings_PanelLoadDataPDSA objects</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyPanelAlarmSettings_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyPanelAlarmSettings_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyPanelAlarmSettings_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// GalaxyPanelAlarmSettings_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyPanelAlarmSettings_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyPanelAlarmSettings_PanelLoadDataPDSA object</param>
        /// <returns>An GalaxyPanelAlarmSettings_PanelLoadDataPDSA object</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSA InitSearchFilter(GalaxyPanelAlarmSettings_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.EntityName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyPanelAlarmSettings_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current GalaxyPanelAlarmSettings_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned GalaxyPanelAlarmSettings_PanelLoadDataPDSA object</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in GalaxyPanelAlarmSettings_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The GalaxyPanelAlarmSettings_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned GalaxyPanelAlarmSettings_PanelLoadDataPDSA object</returns>
        public GalaxyPanelAlarmSettings_PanelLoadDataPDSA CloneEntity(GalaxyPanelAlarmSettings_PanelLoadDataPDSA entityToClone)
        {
            GalaxyPanelAlarmSettings_PanelLoadDataPDSA newEntity = new GalaxyPanelAlarmSettings_PanelLoadDataPDSA();

            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.ClusterName = entityToClone.ClusterName;
            newEntity.Tag = entityToClone.Tag;
            newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
            newEntity.OffsetIndex = entityToClone.OffsetIndex;

            return newEntity;
        }
        #endregion
    }
}
