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
    /// This class is used to call the stored procedure PanelDataPacketLog_InsertPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class PanelDataPacketLog_InsertPDSAManager : PDSAStoredProcExecuteManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the PanelDataPacketLog_InsertPDSAManager class
        /// </summary>
        public PanelDataPacketLog_InsertPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the PanelDataPacketLog_InsertPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public PanelDataPacketLog_InsertPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            Init();
        }
        #endregion

        #region Private variables
        private PanelDataPacketLog_InsertPDSA _Entity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each parameter in the stored procedure.
        /// Setting this property will also set the Entity class into the Validator and DataObject classes too.
        /// </summary>
        public PanelDataPacketLog_InsertPDSA Entity
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
        public PanelDataPacketLog_InsertPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public PanelDataPacketLog_InsertPDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class
            if (Entity == null)
                Entity = new PanelDataPacketLog_InsertPDSA();

            // Create Validator Class
            if (Validator == null)
                Validator = new PanelDataPacketLog_InsertPDSAValidator(Entity);

            // Create Data Class
            if (DataObject == null)
                DataObject = new PanelDataPacketLog_InsertPDSAData(DataProvider, Entity, Validator);

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "PanelDataPacketLog_InsertPDSAManager";
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
