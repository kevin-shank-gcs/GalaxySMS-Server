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
    /// This class should be used when you need to select data for the AccessPortal_PanelLoadDataChangesForCpuPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortal_PanelLoadDataChangesForCpuPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortal_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        public AccessPortal_PanelLoadDataChangesForCpuPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the AccessPortal_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortal_PanelLoadDataChangesForCpuPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the AccessPortal_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortal_PanelLoadDataChangesForCpuPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortal_PanelLoadDataChangesForCpuPDSA _Entity = null;
        private AccessPortal_PanelLoadDataChangesForCpuPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortal_PanelLoadDataChangesForCpuPDSA Entity
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
        public AccessPortal_PanelLoadDataChangesForCpuPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortal_PanelLoadDataChangesForCpuPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortal_PanelLoadDataChangesForCpuPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortal_PanelLoadDataChangesForCpuPDSAData DataObject { get; set; }
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
                Entity = new AccessPortal_PanelLoadDataChangesForCpuPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortal_PanelLoadDataChangesForCpuPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortal_PanelLoadDataChangesForCpuPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "AccessPortal_PanelLoadDataChangesForCpuPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortal_PanelLoadDataChangesForCpuPDSA ret = new AccessPortal_PanelLoadDataChangesForCpuPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalUid))
                ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PortalName))
                ret.PortalName = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PortalName]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorNumber))
                ret.DoorNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalTypeDescription))
                ret.AccessPortalTypeDescription = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalTypeDescription]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ReaderTypeName))
                ret.ReaderTypeName = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ReaderTypeName]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelDataFormatCode))
                ret.PanelDataFormatCode = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelDataFormatCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DataFormatName))
                ret.DataFormatName = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DataFormatName]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardSectionMode))
                ret.AccessPortalBoardSectionMode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardSectionMode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardSectionModeDisplay))
                ret.AccessPortalBoardSectionModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardSectionModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalPanelModelTypeCode))
                ret.AccessPortalPanelModelTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalPanelModelTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalCpuTypeCode))
                ret.AccessPortalCpuTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalCpuTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardTypeModel))
                ret.AccessPortalBoardTypeModel = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardTypeModel]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardTypeTypeCode))
                ret.AccessPortalBoardTypeTypeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardTypeTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardTypeDisplay))
                ret.AccessPortalBoardTypeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalBoardTypeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockDelay))
                ret.UnlockDelay = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockDelay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockDuration))
                ret.UnlockDuration = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RecloseDuration))
                ret.RecloseDuration = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RecloseDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AllowPassbackAccess))
                ret.AllowPassbackAccess = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AllowPassbackAccess]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RequireTwoValidCredentials))
                ret.RequireTwoValidCredentials = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RequireTwoValidCredentials]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockOnREX))
                ret.UnlockOnREX = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockOnREX]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressIllegalOpenLog))
                ret.SuppressIllegalOpenLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressIllegalOpenLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressOpenTooLongLog))
                ret.SuppressOpenTooLongLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressOpenTooLongLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressClosedLog))
                ret.SuppressClosedLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressClosedLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressREXLog))
                ret.SuppressREXLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SuppressREXLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GenerateDoorContactChangeLogs))
                ret.GenerateDoorContactChangeLogs = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GenerateDoorContactChangeLogs]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockWhenDoorCloses))
                ret.LockWhenDoorCloses = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockWhenDoorCloses]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.EnableDuress))
                ret.EnableDuress = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.EnableDuress]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupNotify))
                ret.DoorGroupNotify = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupNotify]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupCanDisable))
                ret.DoorGroupCanDisable = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupCanDisable]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RelayOneOnDuringArmDelay))
                ret.RelayOneOnDuringArmDelay = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RelayOneOnDuringArmDelay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RequireValidAccessForAutoUnlock))
                ret.RequireValidAccessForAutoUnlock = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.RequireValidAccessForAutoUnlock]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PINSpecifiesRecloseDuration))
                ret.PINSpecifiesRecloseDuration = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PINSpecifiesRecloseDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ValidAccessRequiresDoorOpen))
                ret.ValidAccessRequiresDoorOpen = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ValidAccessRequiresDoorOpen]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DontDecrementLimitedSwipeExpireCount))
                ret.DontDecrementLimitedSwipeExpireCount = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DontDecrementLimitedSwipeExpireCount]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IgnoreNotInSystem))
                ret.IgnoreNotInSystem = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IgnoreNotInSystem]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ReaderSendsHeartbeat))
                ret.ReaderSendsHeartbeat = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ReaderSendsHeartbeat]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PropertiesLastUpdated))
                ret.PropertiesLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PropertiesLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AutoForgivePassbackCode))
                ret.AutoForgivePassbackCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AutoForgivePassbackCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AutoForgivePassbackDisplay))
                ret.AutoForgivePassbackDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AutoForgivePassbackDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredModeCode))
                ret.PinRequiredModeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredModeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredModeDisplay))
                ret.PinRequiredModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ContactSupervisionCode))
                ret.ContactSupervisionCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ContactSupervisionCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ContactSupervisionDisplay))
                ret.ContactSupervisionDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ContactSupervisionDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeferToServerCode))
                ret.DeferToServerCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeferToServerCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeferToServerDisplay))
                ret.DeferToServerDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DeferToServerDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NoServerReplyCode))
                ret.NoServerReplyCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NoServerReplyCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NoServerReplyDisplay))
                ret.NoServerReplyDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NoServerReplyDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockPushButtonCode))
                ret.LockPushButtonCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockPushButtonCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockPushButtonDisplay))
                ret.LockPushButtonDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockPushButtonDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MultiFactorMode))
                ret.MultiFactorMode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MultiFactorMode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MultiFactorModeDisplay))
                ret.MultiFactorModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MultiFactorModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorControlTypeCode))
                ret.ElevatorControlTypeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorControlTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorControlTypeDisplay))
                ret.ElevatorControlTypeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorControlTypeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorRelayBoardNumber))
                ret.ElevatorRelayBoardNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorRelayBoardNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorRelaySectionNumber))
                ret.ElevatorRelaySectionNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ElevatorRelaySectionNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackIntoAreaNumber))
                ret.PassbackIntoAreaNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackIntoAreaNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackFromAreaNumber))
                ret.PassbackFromAreaNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackFromAreaNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.FreeAccessScheduleNumber))
                ret.FreeAccessScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.FreeAccessScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.FreeAccessScheduleDisplay))
                ret.FreeAccessScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.FreeAccessScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisFreeAccessScheduleNumber))
                ret.CrisisFreeAccessScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisFreeAccessScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisFreeAccessScheduleDisplay))
                ret.CrisisFreeAccessScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisFreeAccessScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredScheduleNumber))
                ret.PinRequiredScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredScheduleDisplay))
                ret.PinRequiredScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableForcedOpenScheduleNumber))
                ret.DisableForcedOpenScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableForcedOpenScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableForcedOpenScheduleDisplay))
                ret.DisableForcedOpenScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableForcedOpenScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableOpenTooLongScheduleNumber))
                ret.DisableOpenTooLongScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableOpenTooLongScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableOpenTooLongScheduleDisplay))
                ret.DisableOpenTooLongScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableOpenTooLongScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxiliaryOutputScheduleNumber))
                ret.AuxiliaryOutputScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxiliaryOutputScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxiliaryOutputScheduleDisplay))
                ret.AuxiliaryOutputScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxiliaryOutputScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ActivationDelay))
                ret.Relay2ActivationDelay = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ActivationDelay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ActivationDuration))
                ret.Relay2ActivationDuration = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ActivationDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerAccessGranted))
                ret.Relay2TriggerAccessGranted = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerAccessGranted]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerDuress))
                ret.Relay2TriggerDuress = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerDuress]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerForcedOpen))
                ret.Relay2TriggerForcedOpen = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerForcedOpen]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerInvalidAttempt))
                ret.Relay2TriggerInvalidAttempt = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerInvalidAttempt]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerOpenTooLong))
                ret.Relay2TriggerOpenTooLong = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerOpenTooLong]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerPassbackViolation))
                ret.Relay2TriggerPassbackViolation = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2TriggerPassbackViolation]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ModeCode))
                ret.Relay2ModeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ModeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ModeDisplay))
                ret.Relay2ModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ScheduleNumber))
                ret.Relay2ScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ScheduleDisplay))
                ret.Relay2ScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2ScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ForcedOpenIOGroupNumber))
                ret.ForcedOpenIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ForcedOpenIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ForcedOpenIOGroupOffset))
                ret.ForcedOpenIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ForcedOpenIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OpenTooLongIOGroupNumber))
                ret.OpenTooLongIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OpenTooLongIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OpenTooLongIOGroupOffset))
                ret.OpenTooLongIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OpenTooLongIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupNumber))
                ret.InvalidAccessAttemptIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupOffset))
                ret.InvalidAccessAttemptIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackViolationIOGroupNumber))
                ret.PassbackViolationIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackViolationIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackViolationIOGroupOffset))
                ret.PassbackViolationIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackViolationIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DuressIOGroupNumber))
                ret.DuressIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DuressIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DuressIOGroupOffset))
                ret.DuressIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DuressIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MissedHeartbeatIOGroupNumber))
                ret.MissedHeartbeatIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MissedHeartbeatIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MissedHeartbeatIOGroupOffset))
                ret.MissedHeartbeatIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MissedHeartbeatIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGrantedIOGroupNumber))
                ret.AccessGrantedIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGrantedIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGrantedIOGroupOffset))
                ret.AccessGrantedIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGrantedIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupIOGroupNumber))
                ret.DoorGroupIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupIOGroupOffset))
                ret.DoorGroupIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockedByIOGroupNumber))
                ret.LockedByIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockedByIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockedByIOGroupNumber))
                ret.UnlockedByIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockedByIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber1))
                ret.DisarmIOGroupNumber1 = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber1]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber2))
                ret.DisarmIOGroupNumber2 = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber2]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber3))
                ret.DisarmIOGroupNumber3 = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber3]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber4))
                ret.DisarmIOGroupNumber4 = Convert.ToInt32(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIOGroupNumber4]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalLastUpdated))
                ret.AccessPortalLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessPortalLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.HardwareAddressLastUpdated))
                ret.HardwareAddressLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.HardwareAddressLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackIntoAreaLastUpdated))
                ret.PassbackIntoAreaLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackIntoAreaLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackFromAreaLastUpdated))
                ret.PassbackFromAreaLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackFromAreaLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.FreeAccessSchLastUpdated))
                ret.FreeAccessSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.FreeAccessSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisFreeAccessSchLastUpdated))
                ret.CrisisFreeAccessSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CrisisFreeAccessSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredSchLastUpdated))
                ret.PinRequiredSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PinRequiredSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableForcedOpenSchLastUpdated))
                ret.DisableForcedOpenSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableForcedOpenSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableOpenTooLongSchLastUpdated))
                ret.DisableOpenTooLongSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableOpenTooLongSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxOutputSchLastUpdated))
                ret.AuxOutputSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxOutputSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxOutputLastUpdated))
                ret.AuxOutputLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AuxOutputLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2SchLastUpdated))
                ret.Relay2SchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Relay2SchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ForcedOpenAlertLastUpdated))
                ret.ForcedOpenAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ForcedOpenAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OpenTooLongAlertLastUpdated))
                ret.OpenTooLongAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OpenTooLongAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvalidAccessAttemptAlertLastUpdated))
                ret.InvalidAccessAttemptAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvalidAccessAttemptAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackViolationAlertLastUpdated))
                ret.PassbackViolationAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PassbackViolationAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DuressAlertLastUpdated))
                ret.DuressAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DuressAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MissedHeartbeatAlertLastUpdated))
                ret.MissedHeartbeatAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MissedHeartbeatAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGrantedAlertLastUpdated))
                ret.AccessGrantedAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AccessGrantedAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupAlertLastUpdated))
                ret.DoorGroupAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DoorGroupAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockedByIogLastUpdated))
                ret.UnlockedByIogLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.UnlockedByIogLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockedByIogLastUpdated))
                ret.LockedByIogLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.LockedByIogLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog1LastUpdated))
                ret.DisarmIog1LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog1LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog2LastUpdated))
                ret.DisarmIog2LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog2LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog3LastUpdated))
                ret.DisarmIog3LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog3LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog4LastUpdated))
                ret.DisarmIog4LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisarmIog4LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToBoolean(values[AccessPortal_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortal_PanelLoadDataChangesForCpuPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortal_PanelLoadDataChangesForCpuPDSACollection</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSACollection BuildCollection()
        {
            AccessPortal_PanelLoadDataChangesForCpuPDSACollection coll = new AccessPortal_PanelLoadDataChangesForCpuPDSACollection();
            AccessPortal_PanelLoadDataChangesForCpuPDSA entity = null;
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
        /// <returns>A collection of AccessPortal_PanelLoadDataChangesForCpuPDSA objects</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataSet ds)
        {
            AccessPortal_PanelLoadDataChangesForCpuPDSACollection coll = new AccessPortal_PanelLoadDataChangesForCpuPDSACollection();

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
        /// <returns>A collection of AccessPortal_PanelLoadDataChangesForCpuPDSA objects</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortal_PanelLoadDataChangesForCpuPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortal_PanelLoadDataChangesForCpuPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortal_PanelLoadDataChangesForCpuPDSAData.SelectFilters.Search;

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
        /// AccessPortal_PanelLoadDataChangesForCpuPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortal_PanelLoadDataChangesForCpuPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortal_PanelLoadDataChangesForCpuPDSA object</param>
        /// <returns>An AccessPortal_PanelLoadDataChangesForCpuPDSA object</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSA InitSearchFilter(AccessPortal_PanelLoadDataChangesForCpuPDSA searchEntity)
        {
            searchEntity.PortalName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortal_PanelLoadDataChangesForCpuPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current AccessPortal_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <returns>A cloned AccessPortal_PanelLoadDataChangesForCpuPDSA object</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in AccessPortal_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <param name="entityToClone">The AccessPortal_PanelLoadDataChangesForCpuPDSA entity to clone</param>
        /// <returns>A cloned AccessPortal_PanelLoadDataChangesForCpuPDSA object</returns>
        public AccessPortal_PanelLoadDataChangesForCpuPDSA CloneEntity(AccessPortal_PanelLoadDataChangesForCpuPDSA entityToClone)
        {
            AccessPortal_PanelLoadDataChangesForCpuPDSA newEntity = new AccessPortal_PanelLoadDataChangesForCpuPDSA();

            newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
            newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
            newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
            newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
            newEntity.PortalName = entityToClone.PortalName;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.ModuleNumber = entityToClone.ModuleNumber;
            newEntity.NodeNumber = entityToClone.NodeNumber;
            newEntity.DoorNumber = entityToClone.DoorNumber;
            newEntity.AccessPortalTypeDescription = entityToClone.AccessPortalTypeDescription;
            newEntity.ReaderTypeName = entityToClone.ReaderTypeName;
            newEntity.PanelDataFormatCode = entityToClone.PanelDataFormatCode;
            newEntity.DataFormatName = entityToClone.DataFormatName;
            newEntity.AccessPortalBoardSectionMode = entityToClone.AccessPortalBoardSectionMode;
            newEntity.AccessPortalBoardSectionModeDisplay = entityToClone.AccessPortalBoardSectionModeDisplay;
            newEntity.AccessPortalPanelModelTypeCode = entityToClone.AccessPortalPanelModelTypeCode;
            newEntity.AccessPortalCpuTypeCode = entityToClone.AccessPortalCpuTypeCode;
            newEntity.AccessPortalBoardTypeModel = entityToClone.AccessPortalBoardTypeModel;
            newEntity.AccessPortalBoardTypeTypeCode = entityToClone.AccessPortalBoardTypeTypeCode;
            newEntity.AccessPortalBoardTypeDisplay = entityToClone.AccessPortalBoardTypeDisplay;
            newEntity.UnlockDelay = entityToClone.UnlockDelay;
            newEntity.UnlockDuration = entityToClone.UnlockDuration;
            newEntity.RecloseDuration = entityToClone.RecloseDuration;
            newEntity.AllowPassbackAccess = entityToClone.AllowPassbackAccess;
            newEntity.RequireTwoValidCredentials = entityToClone.RequireTwoValidCredentials;
            newEntity.UnlockOnREX = entityToClone.UnlockOnREX;
            newEntity.SuppressIllegalOpenLog = entityToClone.SuppressIllegalOpenLog;
            newEntity.SuppressOpenTooLongLog = entityToClone.SuppressOpenTooLongLog;
            newEntity.SuppressClosedLog = entityToClone.SuppressClosedLog;
            newEntity.SuppressREXLog = entityToClone.SuppressREXLog;
            newEntity.GenerateDoorContactChangeLogs = entityToClone.GenerateDoorContactChangeLogs;
            newEntity.LockWhenDoorCloses = entityToClone.LockWhenDoorCloses;
            newEntity.EnableDuress = entityToClone.EnableDuress;
            newEntity.DoorGroupNotify = entityToClone.DoorGroupNotify;
            newEntity.DoorGroupCanDisable = entityToClone.DoorGroupCanDisable;
            newEntity.RelayOneOnDuringArmDelay = entityToClone.RelayOneOnDuringArmDelay;
            newEntity.RequireValidAccessForAutoUnlock = entityToClone.RequireValidAccessForAutoUnlock;
            newEntity.PINSpecifiesRecloseDuration = entityToClone.PINSpecifiesRecloseDuration;
            newEntity.ValidAccessRequiresDoorOpen = entityToClone.ValidAccessRequiresDoorOpen;
            newEntity.DontDecrementLimitedSwipeExpireCount = entityToClone.DontDecrementLimitedSwipeExpireCount;
            newEntity.IgnoreNotInSystem = entityToClone.IgnoreNotInSystem;
            newEntity.ReaderSendsHeartbeat = entityToClone.ReaderSendsHeartbeat;
            newEntity.PropertiesLastUpdated = entityToClone.PropertiesLastUpdated;
            newEntity.AutoForgivePassbackCode = entityToClone.AutoForgivePassbackCode;
            newEntity.AutoForgivePassbackDisplay = entityToClone.AutoForgivePassbackDisplay;
            newEntity.PinRequiredModeCode = entityToClone.PinRequiredModeCode;
            newEntity.PinRequiredModeDisplay = entityToClone.PinRequiredModeDisplay;
            newEntity.ContactSupervisionCode = entityToClone.ContactSupervisionCode;
            newEntity.ContactSupervisionDisplay = entityToClone.ContactSupervisionDisplay;
            newEntity.DeferToServerCode = entityToClone.DeferToServerCode;
            newEntity.DeferToServerDisplay = entityToClone.DeferToServerDisplay;
            newEntity.NoServerReplyCode = entityToClone.NoServerReplyCode;
            newEntity.NoServerReplyDisplay = entityToClone.NoServerReplyDisplay;
            newEntity.LockPushButtonCode = entityToClone.LockPushButtonCode;
            newEntity.LockPushButtonDisplay = entityToClone.LockPushButtonDisplay;
            newEntity.MultiFactorMode = entityToClone.MultiFactorMode;
            newEntity.MultiFactorModeDisplay = entityToClone.MultiFactorModeDisplay;
            newEntity.ElevatorControlTypeCode = entityToClone.ElevatorControlTypeCode;
            newEntity.ElevatorControlTypeDisplay = entityToClone.ElevatorControlTypeDisplay;
            newEntity.ElevatorRelayBoardNumber = entityToClone.ElevatorRelayBoardNumber;
            newEntity.ElevatorRelaySectionNumber = entityToClone.ElevatorRelaySectionNumber;
            newEntity.PassbackIntoAreaNumber = entityToClone.PassbackIntoAreaNumber;
            newEntity.PassbackFromAreaNumber = entityToClone.PassbackFromAreaNumber;
            newEntity.FreeAccessScheduleNumber = entityToClone.FreeAccessScheduleNumber;
            newEntity.FreeAccessScheduleDisplay = entityToClone.FreeAccessScheduleDisplay;
            newEntity.CrisisFreeAccessScheduleNumber = entityToClone.CrisisFreeAccessScheduleNumber;
            newEntity.CrisisFreeAccessScheduleDisplay = entityToClone.CrisisFreeAccessScheduleDisplay;
            newEntity.PinRequiredScheduleNumber = entityToClone.PinRequiredScheduleNumber;
            newEntity.PinRequiredScheduleDisplay = entityToClone.PinRequiredScheduleDisplay;
            newEntity.DisableForcedOpenScheduleNumber = entityToClone.DisableForcedOpenScheduleNumber;
            newEntity.DisableForcedOpenScheduleDisplay = entityToClone.DisableForcedOpenScheduleDisplay;
            newEntity.DisableOpenTooLongScheduleNumber = entityToClone.DisableOpenTooLongScheduleNumber;
            newEntity.DisableOpenTooLongScheduleDisplay = entityToClone.DisableOpenTooLongScheduleDisplay;
            newEntity.AuxiliaryOutputScheduleNumber = entityToClone.AuxiliaryOutputScheduleNumber;
            newEntity.AuxiliaryOutputScheduleDisplay = entityToClone.AuxiliaryOutputScheduleDisplay;
            newEntity.Relay2ActivationDelay = entityToClone.Relay2ActivationDelay;
            newEntity.Relay2ActivationDuration = entityToClone.Relay2ActivationDuration;
            newEntity.Relay2TriggerAccessGranted = entityToClone.Relay2TriggerAccessGranted;
            newEntity.Relay2TriggerDuress = entityToClone.Relay2TriggerDuress;
            newEntity.Relay2TriggerForcedOpen = entityToClone.Relay2TriggerForcedOpen;
            newEntity.Relay2TriggerInvalidAttempt = entityToClone.Relay2TriggerInvalidAttempt;
            newEntity.Relay2TriggerOpenTooLong = entityToClone.Relay2TriggerOpenTooLong;
            newEntity.Relay2TriggerPassbackViolation = entityToClone.Relay2TriggerPassbackViolation;
            newEntity.Relay2ModeCode = entityToClone.Relay2ModeCode;
            newEntity.Relay2ModeDisplay = entityToClone.Relay2ModeDisplay;
            newEntity.Relay2ScheduleNumber = entityToClone.Relay2ScheduleNumber;
            newEntity.Relay2ScheduleDisplay = entityToClone.Relay2ScheduleDisplay;
            newEntity.ForcedOpenIOGroupNumber = entityToClone.ForcedOpenIOGroupNumber;
            newEntity.ForcedOpenIOGroupOffset = entityToClone.ForcedOpenIOGroupOffset;
            newEntity.OpenTooLongIOGroupNumber = entityToClone.OpenTooLongIOGroupNumber;
            newEntity.OpenTooLongIOGroupOffset = entityToClone.OpenTooLongIOGroupOffset;
            newEntity.InvalidAccessAttemptIOGroupNumber = entityToClone.InvalidAccessAttemptIOGroupNumber;
            newEntity.InvalidAccessAttemptIOGroupOffset = entityToClone.InvalidAccessAttemptIOGroupOffset;
            newEntity.PassbackViolationIOGroupNumber = entityToClone.PassbackViolationIOGroupNumber;
            newEntity.PassbackViolationIOGroupOffset = entityToClone.PassbackViolationIOGroupOffset;
            newEntity.DuressIOGroupNumber = entityToClone.DuressIOGroupNumber;
            newEntity.DuressIOGroupOffset = entityToClone.DuressIOGroupOffset;
            newEntity.MissedHeartbeatIOGroupNumber = entityToClone.MissedHeartbeatIOGroupNumber;
            newEntity.MissedHeartbeatIOGroupOffset = entityToClone.MissedHeartbeatIOGroupOffset;
            newEntity.AccessGrantedIOGroupNumber = entityToClone.AccessGrantedIOGroupNumber;
            newEntity.AccessGrantedIOGroupOffset = entityToClone.AccessGrantedIOGroupOffset;
            newEntity.DoorGroupIOGroupNumber = entityToClone.DoorGroupIOGroupNumber;
            newEntity.DoorGroupIOGroupOffset = entityToClone.DoorGroupIOGroupOffset;
            newEntity.LockedByIOGroupNumber = entityToClone.LockedByIOGroupNumber;
            newEntity.UnlockedByIOGroupNumber = entityToClone.UnlockedByIOGroupNumber;
            newEntity.DisarmIOGroupNumber1 = entityToClone.DisarmIOGroupNumber1;
            newEntity.DisarmIOGroupNumber2 = entityToClone.DisarmIOGroupNumber2;
            newEntity.DisarmIOGroupNumber3 = entityToClone.DisarmIOGroupNumber3;
            newEntity.DisarmIOGroupNumber4 = entityToClone.DisarmIOGroupNumber4;
            newEntity.AccessPortalLastUpdated = entityToClone.AccessPortalLastUpdated;
            newEntity.HardwareAddressLastUpdated = entityToClone.HardwareAddressLastUpdated;
            newEntity.PassbackIntoAreaLastUpdated = entityToClone.PassbackIntoAreaLastUpdated;
            newEntity.PassbackFromAreaLastUpdated = entityToClone.PassbackFromAreaLastUpdated;
            newEntity.FreeAccessSchLastUpdated = entityToClone.FreeAccessSchLastUpdated;
            newEntity.CrisisFreeAccessSchLastUpdated = entityToClone.CrisisFreeAccessSchLastUpdated;
            newEntity.PinRequiredSchLastUpdated = entityToClone.PinRequiredSchLastUpdated;
            newEntity.DisableForcedOpenSchLastUpdated = entityToClone.DisableForcedOpenSchLastUpdated;
            newEntity.DisableOpenTooLongSchLastUpdated = entityToClone.DisableOpenTooLongSchLastUpdated;
            newEntity.AuxOutputSchLastUpdated = entityToClone.AuxOutputSchLastUpdated;
            newEntity.AuxOutputLastUpdated = entityToClone.AuxOutputLastUpdated;
            newEntity.Relay2SchLastUpdated = entityToClone.Relay2SchLastUpdated;
            newEntity.ForcedOpenAlertLastUpdated = entityToClone.ForcedOpenAlertLastUpdated;
            newEntity.OpenTooLongAlertLastUpdated = entityToClone.OpenTooLongAlertLastUpdated;
            newEntity.InvalidAccessAttemptAlertLastUpdated = entityToClone.InvalidAccessAttemptAlertLastUpdated;
            newEntity.PassbackViolationAlertLastUpdated = entityToClone.PassbackViolationAlertLastUpdated;
            newEntity.DuressAlertLastUpdated = entityToClone.DuressAlertLastUpdated;
            newEntity.MissedHeartbeatAlertLastUpdated = entityToClone.MissedHeartbeatAlertLastUpdated;
            newEntity.AccessGrantedAlertLastUpdated = entityToClone.AccessGrantedAlertLastUpdated;
            newEntity.DoorGroupAlertLastUpdated = entityToClone.DoorGroupAlertLastUpdated;
            newEntity.UnlockedByIogLastUpdated = entityToClone.UnlockedByIogLastUpdated;
            newEntity.LockedByIogLastUpdated = entityToClone.LockedByIogLastUpdated;
            newEntity.DisarmIog1LastUpdated = entityToClone.DisarmIog1LastUpdated;
            newEntity.DisarmIog2LastUpdated = entityToClone.DisarmIog2LastUpdated;
            newEntity.DisarmIog3LastUpdated = entityToClone.DisarmIog3LastUpdated;
            newEntity.DisarmIog4LastUpdated = entityToClone.DisarmIog4LastUpdated;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
