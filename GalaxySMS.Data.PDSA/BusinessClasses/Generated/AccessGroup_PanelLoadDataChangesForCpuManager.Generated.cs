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
using GCS.Core.Common.Logger;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class should be used when you need to select data for the AccessGroup_PanelLoadDataChangesForCpuPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessGroup_PanelLoadDataChangesForCpuPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessGroup_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        public AccessGroup_PanelLoadDataChangesForCpuPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the AccessGroup_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessGroup_PanelLoadDataChangesForCpuPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the AccessGroup_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessGroup_PanelLoadDataChangesForCpuPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessGroup_PanelLoadDataChangesForCpuPDSA _Entity = null;
        private AccessGroup_PanelLoadDataChangesForCpuPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessGroup_PanelLoadDataChangesForCpuPDSA Entity
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
        public AccessGroup_PanelLoadDataChangesForCpuPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessGroup_PanelLoadDataChangesForCpuPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessGroup_PanelLoadDataChangesForCpuPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessGroup_PanelLoadDataChangesForCpuPDSAData DataObject { get; set; }
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
                Entity = new AccessGroup_PanelLoadDataChangesForCpuPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessGroup_PanelLoadDataChangesForCpuPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessGroup_PanelLoadDataChangesForCpuPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessGroup_PanelLoadDataChangesForCpuPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessGroup_PanelLoadDataChangesForCpuPDSA ret = new AccessGroup_PanelLoadDataChangesForCpuPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid))
                ret.AccessGroupUid = PDSAProperty.ConvertToGuid(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupUid]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName))
                ret.AccessGroupName = PDSAString.ConvertToStringTrim(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupName]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber))
                ret.AccessGroupNumber = Convert.ToInt32(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupNumber]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate))
                ret.ActivationDate = Convert.ToDateTime(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ActivationDate]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate))
                ret.ExpirationDate = Convert.ToDateTime(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ExpirationDate]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled))
                ret.IsEnabled = Convert.ToBoolean(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsEnabled]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid))
                ret.CrisisModeAccessGroupUid = PDSAProperty.ConvertToGuid(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupUid]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName))
                ret.CrisisModeAccessGroupName = PDSAString.ConvertToStringTrim(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupName]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber))
                ret.CrisisModeAccessGroupNumber = Convert.ToInt32(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisModeAccessGroupNumber]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster))
                ret.CurrentTimeForCluster = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CurrentTimeForCluster]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid))
                ret.AccessGroupLoadToCpuUid = PDSAProperty.ConvertToGuid(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGroupLoadToCpuUid]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToBoolean(values[AccessGroup_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessGroup_PanelLoadDataChangesForCpuPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessGroup_PanelLoadDataChangesForCpuPDSACollection</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSACollection BuildCollection()
        {
            AccessGroup_PanelLoadDataChangesForCpuPDSACollection coll = new AccessGroup_PanelLoadDataChangesForCpuPDSACollection();
            AccessGroup_PanelLoadDataChangesForCpuPDSA entity = null;
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
        /// <returns>A collection of AccessGroup_PanelLoadDataChangesForCpuPDSA objects</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataSet ds)
        {
            AccessGroup_PanelLoadDataChangesForCpuPDSACollection coll = new AccessGroup_PanelLoadDataChangesForCpuPDSACollection();

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
        /// <returns>A collection of AccessGroup_PanelLoadDataChangesForCpuPDSA objects</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessGroup_PanelLoadDataChangesForCpuPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessGroup_PanelLoadDataChangesForCpuPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessGroup_PanelLoadDataChangesForCpuPDSAData.SelectFilters.Search;

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
        /// AccessGroup_PanelLoadDataChangesForCpuPDSA.SearchEntity = mgr.InitSearchFilter(AccessGroup_PanelLoadDataChangesForCpuPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessGroup_PanelLoadDataChangesForCpuPDSA object</param>
        /// <returns>An AccessGroup_PanelLoadDataChangesForCpuPDSA object</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSA InitSearchFilter(AccessGroup_PanelLoadDataChangesForCpuPDSA searchEntity)
        {
            searchEntity.AccessGroupName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessGroup_PanelLoadDataChangesForCpuPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current AccessGroup_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <returns>A cloned AccessGroup_PanelLoadDataChangesForCpuPDSA object</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in AccessGroup_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <param name="entityToClone">The AccessGroup_PanelLoadDataChangesForCpuPDSA entity to clone</param>
        /// <returns>A cloned AccessGroup_PanelLoadDataChangesForCpuPDSA object</returns>
        public AccessGroup_PanelLoadDataChangesForCpuPDSA CloneEntity(AccessGroup_PanelLoadDataChangesForCpuPDSA entityToClone)
        {
            AccessGroup_PanelLoadDataChangesForCpuPDSA newEntity = new AccessGroup_PanelLoadDataChangesForCpuPDSA();

            newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.AccessGroupName = entityToClone.AccessGroupName;
            newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;
            newEntity.ActivationDate = entityToClone.ActivationDate;
            newEntity.ExpirationDate = entityToClone.ExpirationDate;
            newEntity.IsEnabled = entityToClone.IsEnabled;
            newEntity.CrisisModeAccessGroupUid = entityToClone.CrisisModeAccessGroupUid;
            newEntity.CrisisModeAccessGroupName = entityToClone.CrisisModeAccessGroupName;
            newEntity.CrisisModeAccessGroupNumber = entityToClone.CrisisModeAccessGroupNumber;
            newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.AccessGroupLoadToCpuUid = entityToClone.AccessGroupLoadToCpuUid;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
