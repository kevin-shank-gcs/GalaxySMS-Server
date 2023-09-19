using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Logger;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager class
        /// </summary>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            Init();
        }
        #endregion

        #region Private variables
        private InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA _Entity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column returned from the stored procedure.
        /// Setting this property will also set the Entity class into the DataObject class too.
        /// </summary>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA Entity
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
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the logic for loading the Entity class with data returned from this stored procedure.
        /// </summary>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class if not created
            if (Entity == null)
                Entity = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA();

            // Create Validator Class if not created
            if (Validator == null)
                Validator = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAData(DataProvider, Entity, Validator);

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager";
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection</returns>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection BuildCollection()
        {
            InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection coll = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection();
            InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA entity = null;
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
        /// <returns>A collection of InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA objects</returns>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection BuildCollection(DataSet ds)
        {
            InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection coll = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection();

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
        /// <returns>A collection of InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA objects</returns>
        public InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSACollection), BuildCollection());
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
