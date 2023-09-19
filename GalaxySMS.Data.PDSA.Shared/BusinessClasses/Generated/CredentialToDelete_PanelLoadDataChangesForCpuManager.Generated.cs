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
    /// This class should be used when you need to select data for the CredentialToDelete_PanelLoadDataChangesForCpuPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private CredentialToDelete_PanelLoadDataChangesForCpuPDSA _Entity = null;
        private CredentialToDelete_PanelLoadDataChangesForCpuPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSA Entity
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
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new CredentialToDelete_PanelLoadDataChangesForCpuPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSAData DataObject { get; set; }
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
                Entity = new CredentialToDelete_PanelLoadDataChangesForCpuPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new CredentialToDelete_PanelLoadDataChangesForCpuPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "CredentialToDelete_PanelLoadDataChangesForCpuPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            CredentialToDelete_PanelLoadDataChangesForCpuPDSA ret = new CredentialToDelete_PanelLoadDataChangesForCpuPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CredentialToDeleteFromCpuUid))
                ret.CredentialToDeleteFromCpuUid = PDSAProperty.ConvertToGuid(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CredentialToDeleteFromCpuUid]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CardBinaryData))
                ret.CardBinaryData = PDSAProperty.ConvertToByteArray(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CardBinaryData]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeletedFromDatabaseDate))
                ret.DeletedFromDatabaseDate = Convert.ToDateTime(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeletedFromDatabaseDate]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeletedFromCpuDate))
                ret.DeletedFromCpuDate = Convert.ToDateTime(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeletedFromCpuDate]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToBoolean(values[CredentialToDelete_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of CredentialToDelete_PanelLoadDataChangesForCpuPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection BuildCollection()
        {
            CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection coll = new CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection();
            CredentialToDelete_PanelLoadDataChangesForCpuPDSA entity = null;
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
        /// <returns>A collection of CredentialToDelete_PanelLoadDataChangesForCpuPDSA objects</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataSet ds)
        {
            CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection coll = new CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection();

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
        /// <returns>A collection of CredentialToDelete_PanelLoadDataChangesForCpuPDSA objects</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of CredentialToDelete_PanelLoadDataChangesForCpuPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(CredentialToDelete_PanelLoadDataChangesForCpuPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = CredentialToDelete_PanelLoadDataChangesForCpuPDSAData.SelectFilters.Search;

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
        /// CredentialToDelete_PanelLoadDataChangesForCpuPDSA.SearchEntity = mgr.InitSearchFilter(CredentialToDelete_PanelLoadDataChangesForCpuPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A CredentialToDelete_PanelLoadDataChangesForCpuPDSA object</param>
        /// <returns>An CredentialToDelete_PanelLoadDataChangesForCpuPDSA object</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSA InitSearchFilter(CredentialToDelete_PanelLoadDataChangesForCpuPDSA searchEntity)
        {
            searchEntity.ServerAddress = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = CredentialToDelete_PanelLoadDataChangesForCpuPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current CredentialToDelete_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <returns>A cloned CredentialToDelete_PanelLoadDataChangesForCpuPDSA object</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in CredentialToDelete_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <param name="entityToClone">The CredentialToDelete_PanelLoadDataChangesForCpuPDSA entity to clone</param>
        /// <returns>A cloned CredentialToDelete_PanelLoadDataChangesForCpuPDSA object</returns>
        public CredentialToDelete_PanelLoadDataChangesForCpuPDSA CloneEntity(CredentialToDelete_PanelLoadDataChangesForCpuPDSA entityToClone)
        {
            CredentialToDelete_PanelLoadDataChangesForCpuPDSA newEntity = new CredentialToDelete_PanelLoadDataChangesForCpuPDSA();

            newEntity.CredentialToDeleteFromCpuUid = entityToClone.CredentialToDeleteFromCpuUid;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.CardBinaryData = entityToClone.CardBinaryData;
            newEntity.DeletedFromDatabaseDate = entityToClone.DeletedFromDatabaseDate;
            newEntity.DeletedFromCpuDate = entityToClone.DeletedFromCpuDate;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
