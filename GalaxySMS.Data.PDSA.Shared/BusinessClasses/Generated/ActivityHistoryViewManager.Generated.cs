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
    /// This class should be used when you need to select data for the ActivityHistoryViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class ActivityHistoryViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the ActivityHistoryViewPDSAManager class
        /// </summary>
        public ActivityHistoryViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the ActivityHistoryViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public ActivityHistoryViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the ActivityHistoryViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public ActivityHistoryViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private ActivityHistoryViewPDSA _Entity = null;
        private ActivityHistoryViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public ActivityHistoryViewPDSA Entity
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
        public ActivityHistoryViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new ActivityHistoryViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public ActivityHistoryViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public ActivityHistoryViewPDSAData DataObject { get; set; }
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
                Entity = new ActivityHistoryViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new ActivityHistoryViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new ActivityHistoryViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "ActivityHistoryViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public ActivityHistoryViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            ActivityHistoryViewPDSA ret = new ActivityHistoryViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.ActivityDateTime))
                ret.ActivityDateTime = Convert.ToDateTime(values[ActivityHistoryViewPDSAValidator.ColumnNames.ActivityDateTime]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.EventTypeMessage))
                ret.EventTypeMessage = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.EventTypeMessage]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.ForeColor))
                ret.ForeColor = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.ForeColor]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.DeviceName))
                ret.DeviceName = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.DeviceName]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.SiteName))
                ret.SiteName = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.SiteName]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[ActivityHistoryViewPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.DeviceUid))
                ret.DeviceUid = PDSAProperty.ConvertToGuid(values[ActivityHistoryViewPDSAValidator.ColumnNames.DeviceUid]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.EventTypeUid))
                ret.EventTypeUid = PDSAProperty.ConvertToGuid(values[ActivityHistoryViewPDSAValidator.ColumnNames.EventTypeUid]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.DeviceType))
                ret.DeviceType = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.DeviceType]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.LastName))
                ret.LastName = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.LastName]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.FirstName))
                ret.FirstName = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.FirstName]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.CredentialDescription))
                ret.CredentialDescription = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.CredentialDescription]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[ActivityHistoryViewPDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.CredentialUid))
                ret.CredentialUid = PDSAProperty.ConvertToGuid(values[ActivityHistoryViewPDSAValidator.ColumnNames.CredentialUid]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.PK))
                ret.PK = PDSAProperty.ConvertToGuid(values[ActivityHistoryViewPDSAValidator.ColumnNames.PK]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.TotalRecordCount))
                ret.TotalRecordCount = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.TotalRecordCount]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.ClusterName]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.PageNumber))
                ret.PageNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.PageNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.PageSize))
                ret.PageSize = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.PageSize]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.InputOutputGroupName))
                ret.InputOutputGroupName = PDSAString.ConvertToStringTrim(values[ActivityHistoryViewPDSAValidator.ColumnNames.InputOutputGroupName]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.InputOutputGroupNumber))
                ret.InputOutputGroupNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.InputOutputGroupNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[ActivityHistoryViewPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(ActivityHistoryViewPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt32(values[ActivityHistoryViewPDSAValidator.ColumnNames.NodeNumber]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of ActivityHistoryViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>ActivityHistoryViewPDSACollection</returns>
        public ActivityHistoryViewPDSACollection BuildCollection()
        {
            ActivityHistoryViewPDSACollection coll = new ActivityHistoryViewPDSACollection();
            ActivityHistoryViewPDSA entity = null;
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
        /// <returns>A collection of ActivityHistoryViewPDSA objects</returns>
        public ActivityHistoryViewPDSACollection BuildCollection(DataSet ds)
        {
            ActivityHistoryViewPDSACollection coll = new ActivityHistoryViewPDSACollection();

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
        /// <returns>A collection of ActivityHistoryViewPDSA objects</returns>
        public ActivityHistoryViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of ActivityHistoryViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(ActivityHistoryViewPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = ActivityHistoryViewPDSAData.SelectFilters.Search;

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
        /// ActivityHistoryViewPDSA.SearchEntity = mgr.InitSearchFilter(ActivityHistoryViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A ActivityHistoryViewPDSA object</param>
        /// <returns>An ActivityHistoryViewPDSA object</returns>
        public ActivityHistoryViewPDSA InitSearchFilter(ActivityHistoryViewPDSA searchEntity)
        {
            searchEntity.EventTypeMessage = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = ActivityHistoryViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current ActivityHistoryViewPDSA
        /// </summary>
        /// <returns>A cloned ActivityHistoryViewPDSA object</returns>
        public ActivityHistoryViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in ActivityHistoryViewPDSA
        /// </summary>
        /// <param name="entityToClone">The ActivityHistoryViewPDSA entity to clone</param>
        /// <returns>A cloned ActivityHistoryViewPDSA object</returns>
        public ActivityHistoryViewPDSA CloneEntity(ActivityHistoryViewPDSA entityToClone)
        {
            ActivityHistoryViewPDSA newEntity = new ActivityHistoryViewPDSA();

            newEntity.ActivityDateTime = entityToClone.ActivityDateTime;
            newEntity.EventTypeMessage = entityToClone.EventTypeMessage;
            newEntity.ForeColor = entityToClone.ForeColor;
            newEntity.DeviceName = entityToClone.DeviceName;
            newEntity.SiteName = entityToClone.SiteName;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.DeviceUid = entityToClone.DeviceUid;
            newEntity.EventTypeUid = entityToClone.EventTypeUid;
            newEntity.DeviceType = entityToClone.DeviceType;
            newEntity.LastName = entityToClone.LastName;
            newEntity.FirstName = entityToClone.FirstName;
            newEntity.CredentialDescription = entityToClone.CredentialDescription;
            newEntity.PersonUid = entityToClone.PersonUid;
            newEntity.CredentialUid = entityToClone.CredentialUid;
            newEntity.PK = entityToClone.PK;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.TotalRecordCount = entityToClone.TotalRecordCount;
            newEntity.ClusterName = entityToClone.ClusterName;
            newEntity.PageNumber = entityToClone.PageNumber;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.PageSize = entityToClone.PageSize;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.InputOutputGroupName = entityToClone.InputOutputGroupName;
            newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.ModuleNumber = entityToClone.ModuleNumber;
            newEntity.NodeNumber = entityToClone.NodeNumber;

            return newEntity;
        }
        #endregion
    }
}
