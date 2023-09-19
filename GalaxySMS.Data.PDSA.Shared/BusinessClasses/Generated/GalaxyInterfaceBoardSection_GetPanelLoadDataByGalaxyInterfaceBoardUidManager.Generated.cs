using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAManager class
        /// </summary>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            Init();
        }
        #endregion

        #region Private variables
        private GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA _Entity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column returned from the stored procedure.
        /// Setting this property will also set the Entity class into the DataObject class too.
        /// </summary>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA Entity
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
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the logic for loading the Entity class with data returned from this stored procedure.
        /// </summary>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class if not created
            if (Entity == null)
                Entity = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA();

            // Create Validator Class if not created
            if (Validator == null)
                Validator = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAData(DataProvider, Entity, Validator);

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSAManager";
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection</returns>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection BuildCollection()
        {
            GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection coll = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection();
            GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA entity = null;
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
        /// <returns>A collection of GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA objects</returns>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection coll = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection();

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
        /// <returns>A collection of GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA objects</returns>
        public GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardUidPDSACollection), BuildCollection());
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
    }
}
