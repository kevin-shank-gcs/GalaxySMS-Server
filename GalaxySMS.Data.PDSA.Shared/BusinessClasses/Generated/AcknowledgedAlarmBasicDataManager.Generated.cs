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
    /// This class should be used when you need to select data for the AcknowledgedAlarmBasicDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AcknowledgedAlarmBasicDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AcknowledgedAlarmBasicDataPDSAManager class
        /// </summary>
        public AcknowledgedAlarmBasicDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the AcknowledgedAlarmBasicDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AcknowledgedAlarmBasicDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the AcknowledgedAlarmBasicDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AcknowledgedAlarmBasicDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AcknowledgedAlarmBasicDataPDSA _Entity = null;
        private AcknowledgedAlarmBasicDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AcknowledgedAlarmBasicDataPDSA Entity
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
        public AcknowledgedAlarmBasicDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AcknowledgedAlarmBasicDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AcknowledgedAlarmBasicDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AcknowledgedAlarmBasicDataPDSAData DataObject { get; set; }
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
                Entity = new AcknowledgedAlarmBasicDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AcknowledgedAlarmBasicDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AcknowledgedAlarmBasicDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AcknowledgedAlarmBasicDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AcknowledgedAlarmBasicDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AcknowledgedAlarmBasicDataPDSA ret = new AcknowledgedAlarmBasicDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.ActivityEventUid))
                ret.ActivityEventUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.ActivityEventUid]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.DeviceEntityId))
                ret.DeviceEntityId = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.DeviceEntityId]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.DeviceUid))
                ret.DeviceUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.DeviceUid]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid))
                ret.AccessPortalAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid))
                ret.GalaxyPanelAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.GalaxyPanelAlarmEventAcknowledgmentUid]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.Response))
                ret.Response = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.Response]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid))
                ret.InputDeviceAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.InputDeviceAlarmEventAcknowledgmentUid]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedByUserId))
                ret.AckedByUserId = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedByUserId]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedByUserDisplayName))
                ret.AckedByUserDisplayName = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedByUserDisplayName]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedDateTime))
                ret.AckedDateTime = Convert.ToDateTime(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedDateTime]);

            if (values.ContainsKey(AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedUpdatedDateTime))
                ret.AckedUpdatedDateTime = Convert.ToDateTime(values[AcknowledgedAlarmBasicDataPDSAValidator.ColumnNames.AckedUpdatedDateTime]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AcknowledgedAlarmBasicDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AcknowledgedAlarmBasicDataPDSACollection</returns>
        public AcknowledgedAlarmBasicDataPDSACollection BuildCollection()
        {
            AcknowledgedAlarmBasicDataPDSACollection coll = new AcknowledgedAlarmBasicDataPDSACollection();
            AcknowledgedAlarmBasicDataPDSA entity = null;
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
        /// <returns>A collection of AcknowledgedAlarmBasicDataPDSA objects</returns>
        public AcknowledgedAlarmBasicDataPDSACollection BuildCollection(DataSet ds)
        {
            AcknowledgedAlarmBasicDataPDSACollection coll = new AcknowledgedAlarmBasicDataPDSACollection();

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
        /// <returns>A collection of AcknowledgedAlarmBasicDataPDSA objects</returns>
        public AcknowledgedAlarmBasicDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AcknowledgedAlarmBasicDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AcknowledgedAlarmBasicDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AcknowledgedAlarmBasicDataPDSAData.SelectFilters.Search;

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
        /// AcknowledgedAlarmBasicDataPDSA.SearchEntity = mgr.InitSearchFilter(AcknowledgedAlarmBasicDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AcknowledgedAlarmBasicDataPDSA object</param>
        /// <returns>An AcknowledgedAlarmBasicDataPDSA object</returns>
        public AcknowledgedAlarmBasicDataPDSA InitSearchFilter(AcknowledgedAlarmBasicDataPDSA searchEntity)
        {
            searchEntity.Response = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AcknowledgedAlarmBasicDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current AcknowledgedAlarmBasicDataPDSA
        /// </summary>
        /// <returns>A cloned AcknowledgedAlarmBasicDataPDSA object</returns>
        public AcknowledgedAlarmBasicDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in AcknowledgedAlarmBasicDataPDSA
        /// </summary>
        /// <param name="entityToClone">The AcknowledgedAlarmBasicDataPDSA entity to clone</param>
        /// <returns>A cloned AcknowledgedAlarmBasicDataPDSA object</returns>
        public AcknowledgedAlarmBasicDataPDSA CloneEntity(AcknowledgedAlarmBasicDataPDSA entityToClone)
        {
            AcknowledgedAlarmBasicDataPDSA newEntity = new AcknowledgedAlarmBasicDataPDSA();

            newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
            newEntity.DeviceEntityId = entityToClone.DeviceEntityId;
            newEntity.DeviceUid = entityToClone.DeviceUid;
            newEntity.AccessPortalAlarmEventAcknowledgmentUid = entityToClone.AccessPortalAlarmEventAcknowledgmentUid;
            newEntity.GalaxyPanelAlarmEventAcknowledgmentUid = entityToClone.GalaxyPanelAlarmEventAcknowledgmentUid;
            newEntity.Response = entityToClone.Response;
            newEntity.InputDeviceAlarmEventAcknowledgmentUid = entityToClone.InputDeviceAlarmEventAcknowledgmentUid;
            newEntity.AckedByUserId = entityToClone.AckedByUserId;
            newEntity.AckedByUserDisplayName = entityToClone.AckedByUserDisplayName;
            newEntity.AckedDateTime = entityToClone.AckedDateTime;
            newEntity.AckedUpdatedDateTime = entityToClone.AckedUpdatedDateTime;

            return newEntity;
        }
        #endregion
    }
}
