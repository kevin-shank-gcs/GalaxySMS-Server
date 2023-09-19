using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.DataLayer;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAManager class
        /// </summary>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            Init();
        }
        #endregion

        #region Private variables
        private CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA _Entity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column returned from the stored procedure.
        /// Setting this property will also set the Entity class into the DataObject class too.
        /// </summary>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA Entity
        {
            get { return _Entity; }
            set
            {
                _Entity = value;
                if (DataObject != null)
                    DataObject.Entity = value;
            }
        }
        /// <summary>
        /// Get/Set the data class that contains the logic for loading the Entity class with data returned from this stored procedure.
        /// </summary>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class if not created
            if (Entity == null)
                Entity = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA();

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAData(DataProvider, Entity);

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSAManager";
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection</returns>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection BuildCollection()
        {
            CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection coll = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection();
            CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA entity = null;
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
        /// <returns>A collection of CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA objects</returns>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection BuildCollection(DataSet ds)
        {
            CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection coll = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection();

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
        /// <returns>A collection of CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA objects</returns>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSACollection), BuildCollection());
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
        #endregion

        #region Clone Entity Class
        /// <summary>
        /// Clones the current CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA
        /// </summary>
        /// <returns>A cloned CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA object</returns>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA
        /// </summary>
        /// <param name="entityToClone">The CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA entity to clone</param>
        /// <returns>A cloned CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA object</returns>
        public CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA CloneEntity(CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA entityToClone)
        {
            CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA newEntity = new CredentialToDeleteFromCpuPDSA_AllThatNeedDeletedPDSA();

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
