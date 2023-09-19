using System;
using System.Data;
using System.Diagnostics;

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
    /// This class is used to call the stored procedure GalaxyCpu_UpdateInformationPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyCpu_UpdateInformationPDSAManager : PDSAStoredProcExecuteManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyCpu_UpdateInformationPDSAManager class
        /// </summary>
        public GalaxyCpu_UpdateInformationPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyCpu_UpdateInformationPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyCpu_UpdateInformationPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            Init();
        }
        #endregion

        #region Private variables
        private GalaxyCpu_UpdateInformationPDSA _Entity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each parameter in the stored procedure.
        /// Setting this property will also set the Entity class into the Validator and DataObject classes too.
        /// </summary>
        public GalaxyCpu_UpdateInformationPDSA Entity
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
        public GalaxyCpu_UpdateInformationPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyCpu_UpdateInformationPDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class
            if (Entity == null)
                Entity = new GalaxyCpu_UpdateInformationPDSA();

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyCpu_UpdateInformationPDSAValidator(Entity);

            // Create Data Class
            if (DataObject == null)
                DataObject = new GalaxyCpu_UpdateInformationPDSAData(DataProvider, Entity, Validator);

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "GalaxyCpu_UpdateInformationPDSAManager";
        }
        #endregion

        #region Execute Method
        public int Execute()
        {
            return this.DataObject.Execute();
        }
        #endregion
    }
}
