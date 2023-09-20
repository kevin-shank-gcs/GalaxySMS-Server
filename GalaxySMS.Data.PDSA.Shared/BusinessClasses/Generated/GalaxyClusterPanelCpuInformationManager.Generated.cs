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
    /// This class should be used when you need to select data for the GalaxyClusterPanelCpuInformationPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyClusterPanelCpuInformationPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyClusterPanelCpuInformationPDSAManager class
        /// </summary>
        public GalaxyClusterPanelCpuInformationPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyClusterPanelCpuInformationPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyClusterPanelCpuInformationPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyClusterPanelCpuInformationPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyClusterPanelCpuInformationPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyClusterPanelCpuInformationPDSA _Entity = null;
        private GalaxyClusterPanelCpuInformationPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyClusterPanelCpuInformationPDSA Entity
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
        public GalaxyClusterPanelCpuInformationPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyClusterPanelCpuInformationPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyClusterPanelCpuInformationPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyClusterPanelCpuInformationPDSAData DataObject { get; set; }
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
                Entity = new GalaxyClusterPanelCpuInformationPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyClusterPanelCpuInformationPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyClusterPanelCpuInformationPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyClusterPanelCpuInformationPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyClusterPanelCpuInformationPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyClusterPanelCpuInformationPDSA ret = new GalaxyClusterPanelCpuInformationPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber))
                ret.SerialNumber = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SerialNumber]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress))
                ret.IpAddress = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.IpAddress]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn))
                ret.DefaultEventLoggingOn = Convert.ToBoolean(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.DefaultEventLoggingOn]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading))
                ret.PreventDataLoading = Convert.ToBoolean(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventDataLoading]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading))
                ret.PreventFlashLoading = Convert.ToBoolean(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PreventFlashLoading]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex))
                ret.LastLogIndex = Convert.ToInt32(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.LastLogIndex]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterName]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName))
                ret.PanelName = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelName]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode))
                ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeCode]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive))
                ret.ClusterTypeIsActive = Convert.ToBoolean(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.ClusterTypeIsActive]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength))
                ret.CredentialDataLength = Convert.ToInt16(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CredentialDataLength]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation))
                ret.PanelLocation = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelLocation]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode))
                ret.PanelModelTypeCode = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelTypeCode]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive))
                ret.PanelModelIsActive = Convert.ToBoolean(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.PanelModelIsActive]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive))
                ret.CpuIsActive = Convert.ToBoolean(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.CpuIsActive]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid))
                ret.SiteUid = PDSAProperty.ConvertToGuid(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteUid]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName))
                ret.SiteName = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.SiteName]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName))
                ret.EntityName = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.EntityName]);

            if (values.ContainsKey(GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId))
                ret.TimeZoneId = PDSAString.ConvertToStringTrim(values[GalaxyClusterPanelCpuInformationPDSAValidator.ColumnNames.TimeZoneId]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyClusterPanelCpuInformationPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyClusterPanelCpuInformationPDSACollection</returns>
        public GalaxyClusterPanelCpuInformationPDSACollection BuildCollection()
        {
            GalaxyClusterPanelCpuInformationPDSACollection coll = new GalaxyClusterPanelCpuInformationPDSACollection();
            GalaxyClusterPanelCpuInformationPDSA entity = null;
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
            {                // This is here for design time exceptions
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
        /// <returns>A collection of GalaxyClusterPanelCpuInformationPDSA objects</returns>
        public GalaxyClusterPanelCpuInformationPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyClusterPanelCpuInformationPDSACollection coll = new GalaxyClusterPanelCpuInformationPDSACollection();

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
        /// <returns>A collection of GalaxyClusterPanelCpuInformationPDSA objects</returns>
        public GalaxyClusterPanelCpuInformationPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyClusterPanelCpuInformationPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyClusterPanelCpuInformationPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyClusterPanelCpuInformationPDSAData.SelectFilters.Search;

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
        /// GalaxyClusterPanelCpuInformationPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyClusterPanelCpuInformationPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyClusterPanelCpuInformationPDSA object</param>
        /// <returns>An GalaxyClusterPanelCpuInformationPDSA object</returns>
        public GalaxyClusterPanelCpuInformationPDSA InitSearchFilter(GalaxyClusterPanelCpuInformationPDSA searchEntity)
        {
            searchEntity.ClusterGroupId = 0;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyClusterPanelCpuInformationPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current GalaxyClusterPanelCpuInformationPDSA
        /// </summary>
        /// <returns>A cloned GalaxyClusterPanelCpuInformationPDSA object</returns>
        public GalaxyClusterPanelCpuInformationPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in GalaxyClusterPanelCpuInformationPDSA
        /// </summary>
        /// <param name="entityToClone">The GalaxyClusterPanelCpuInformationPDSA entity to clone</param>
        /// <returns>A cloned GalaxyClusterPanelCpuInformationPDSA object</returns>
        public GalaxyClusterPanelCpuInformationPDSA CloneEntity(GalaxyClusterPanelCpuInformationPDSA entityToClone)
        {
            GalaxyClusterPanelCpuInformationPDSA newEntity = new GalaxyClusterPanelCpuInformationPDSA();

            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.SerialNumber = entityToClone.SerialNumber;
            newEntity.IpAddress = entityToClone.IpAddress;
            newEntity.DefaultEventLoggingOn = entityToClone.DefaultEventLoggingOn;
            newEntity.PreventDataLoading = entityToClone.PreventDataLoading;
            newEntity.PreventFlashLoading = entityToClone.PreventFlashLoading;
            newEntity.LastLogIndex = entityToClone.LastLogIndex;
            newEntity.ClusterName = entityToClone.ClusterName;
            newEntity.PanelName = entityToClone.PanelName;
            newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
            newEntity.ClusterTypeIsActive = entityToClone.ClusterTypeIsActive;
            newEntity.CredentialDataLength = entityToClone.CredentialDataLength;
            newEntity.PanelLocation = entityToClone.PanelLocation;
            newEntity.PanelModelTypeCode = entityToClone.PanelModelTypeCode;
            newEntity.PanelModelIsActive = entityToClone.PanelModelIsActive;
            newEntity.CpuIsActive = entityToClone.CpuIsActive;
            newEntity.SiteUid = entityToClone.SiteUid;
            newEntity.SiteName = entityToClone.SiteName;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.TimeZoneId = entityToClone.TimeZoneId;

            return newEntity;
        }
        #endregion
    }
}
