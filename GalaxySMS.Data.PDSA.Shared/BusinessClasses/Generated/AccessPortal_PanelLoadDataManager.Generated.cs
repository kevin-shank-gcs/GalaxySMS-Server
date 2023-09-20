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
    /// This class should be used when you need to select data for the AccessPortal_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortal_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortal_PanelLoadDataPDSAManager class
        /// </summary>
        public AccessPortal_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the AccessPortal_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortal_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the AccessPortal_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortal_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortal_PanelLoadDataPDSA _Entity = null;
        private AccessPortal_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortal_PanelLoadDataPDSA Entity
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
        public AccessPortal_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortal_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortal_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortal_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new AccessPortal_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortal_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortal_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "AccessPortal_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortal_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortal_PanelLoadDataPDSA ret = new AccessPortal_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalUid))
                ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PortalName))
                ret.PortalName = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PortalName]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber))
                ret.DoorNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalTypeDescription))
                ret.AccessPortalTypeDescription = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalTypeDescription]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ReaderTypeName))
                ret.ReaderTypeName = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ReaderTypeName]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelDataFormatCode))
                ret.PanelDataFormatCode = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PanelDataFormatCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DataFormatName))
                ret.DataFormatName = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DataFormatName]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardSectionMode))
                ret.AccessPortalBoardSectionMode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardSectionMode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardSectionModeDisplay))
                ret.AccessPortalBoardSectionModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardSectionModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalPanelModelTypeCode))
                ret.AccessPortalPanelModelTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalPanelModelTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalCpuTypeCode))
                ret.AccessPortalCpuTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalCpuTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeModel))
                ret.AccessPortalBoardTypeModel = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeModel]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeTypeCode))
                ret.AccessPortalBoardTypeTypeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeDisplay))
                ret.AccessPortalBoardTypeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalBoardTypeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockDelay))
                ret.UnlockDelay = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockDelay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockDuration))
                ret.UnlockDuration = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RecloseDuration))
                ret.RecloseDuration = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RecloseDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AllowPassbackAccess))
                ret.AllowPassbackAccess = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AllowPassbackAccess]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RequireTwoValidCredentials))
                ret.RequireTwoValidCredentials = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RequireTwoValidCredentials]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockOnREX))
                ret.UnlockOnREX = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockOnREX]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressIllegalOpenLog))
                ret.SuppressIllegalOpenLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressIllegalOpenLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressOpenTooLongLog))
                ret.SuppressOpenTooLongLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressOpenTooLongLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressClosedLog))
                ret.SuppressClosedLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressClosedLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressREXLog))
                ret.SuppressREXLog = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.SuppressREXLog]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GenerateDoorContactChangeLogs))
                ret.GenerateDoorContactChangeLogs = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.GenerateDoorContactChangeLogs]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockWhenDoorCloses))
                ret.LockWhenDoorCloses = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockWhenDoorCloses]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.EnableDuress))
                ret.EnableDuress = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.EnableDuress]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupNotify))
                ret.DoorGroupNotify = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupNotify]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupCanDisable))
                ret.DoorGroupCanDisable = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupCanDisable]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RelayOneOnDuringArmDelay))
                ret.RelayOneOnDuringArmDelay = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RelayOneOnDuringArmDelay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RequireValidAccessForAutoUnlock))
                ret.RequireValidAccessForAutoUnlock = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.RequireValidAccessForAutoUnlock]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PINSpecifiesRecloseDuration))
                ret.PINSpecifiesRecloseDuration = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PINSpecifiesRecloseDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ValidAccessRequiresDoorOpen))
                ret.ValidAccessRequiresDoorOpen = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ValidAccessRequiresDoorOpen]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DontDecrementLimitedSwipeExpireCount))
                ret.DontDecrementLimitedSwipeExpireCount = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DontDecrementLimitedSwipeExpireCount]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IgnoreNotInSystem))
                ret.IgnoreNotInSystem = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IgnoreNotInSystem]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ReaderSendsHeartbeat))
                ret.ReaderSendsHeartbeat = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ReaderSendsHeartbeat]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PropertiesLastUpdated))
                ret.PropertiesLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PropertiesLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AutoForgivePassbackCode))
                ret.AutoForgivePassbackCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AutoForgivePassbackCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AutoForgivePassbackDisplay))
                ret.AutoForgivePassbackDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AutoForgivePassbackDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredModeCode))
                ret.PinRequiredModeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredModeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredModeDisplay))
                ret.PinRequiredModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ContactSupervisionCode))
                ret.ContactSupervisionCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ContactSupervisionCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ContactSupervisionDisplay))
                ret.ContactSupervisionDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ContactSupervisionDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DeferToServerCode))
                ret.DeferToServerCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DeferToServerCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DeferToServerDisplay))
                ret.DeferToServerDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DeferToServerDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NoServerReplyCode))
                ret.NoServerReplyCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NoServerReplyCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NoServerReplyDisplay))
                ret.NoServerReplyDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.NoServerReplyDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockPushButtonCode))
                ret.LockPushButtonCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockPushButtonCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockPushButtonDisplay))
                ret.LockPushButtonDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockPushButtonDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MultiFactorMode))
                ret.MultiFactorMode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MultiFactorMode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MultiFactorModeDisplay))
                ret.MultiFactorModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MultiFactorModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorControlTypeCode))
                ret.ElevatorControlTypeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorControlTypeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorControlTypeDisplay))
                ret.ElevatorControlTypeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorControlTypeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorRelayBoardNumber))
                ret.ElevatorRelayBoardNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorRelayBoardNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorRelaySectionNumber))
                ret.ElevatorRelaySectionNumber = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ElevatorRelaySectionNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackIntoAreaNumber))
                ret.PassbackIntoAreaNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackIntoAreaNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackFromAreaNumber))
                ret.PassbackFromAreaNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackFromAreaNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.FreeAccessScheduleNumber))
                ret.FreeAccessScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.FreeAccessScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.FreeAccessScheduleDisplay))
                ret.FreeAccessScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.FreeAccessScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CrisisFreeAccessScheduleNumber))
                ret.CrisisFreeAccessScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CrisisFreeAccessScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CrisisFreeAccessScheduleDisplay))
                ret.CrisisFreeAccessScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CrisisFreeAccessScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredScheduleNumber))
                ret.PinRequiredScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredScheduleDisplay))
                ret.PinRequiredScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableForcedOpenScheduleNumber))
                ret.DisableForcedOpenScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableForcedOpenScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableForcedOpenScheduleDisplay))
                ret.DisableForcedOpenScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableForcedOpenScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableOpenTooLongScheduleNumber))
                ret.DisableOpenTooLongScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableOpenTooLongScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableOpenTooLongScheduleDisplay))
                ret.DisableOpenTooLongScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableOpenTooLongScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxiliaryOutputScheduleNumber))
                ret.AuxiliaryOutputScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxiliaryOutputScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxiliaryOutputScheduleDisplay))
                ret.AuxiliaryOutputScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxiliaryOutputScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ActivationDelay))
                ret.Relay2ActivationDelay = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ActivationDelay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ActivationDuration))
                ret.Relay2ActivationDuration = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ActivationDuration]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerAccessGranted))
                ret.Relay2TriggerAccessGranted = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerAccessGranted]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerDuress))
                ret.Relay2TriggerDuress = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerDuress]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerForcedOpen))
                ret.Relay2TriggerForcedOpen = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerForcedOpen]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerInvalidAttempt))
                ret.Relay2TriggerInvalidAttempt = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerInvalidAttempt]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerOpenTooLong))
                ret.Relay2TriggerOpenTooLong = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerOpenTooLong]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerPassbackViolation))
                ret.Relay2TriggerPassbackViolation = Convert.ToBoolean(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2TriggerPassbackViolation]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ModeCode))
                ret.Relay2ModeCode = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ModeCode]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ModeDisplay))
                ret.Relay2ModeDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ModeDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ScheduleNumber))
                ret.Relay2ScheduleNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ScheduleNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ScheduleDisplay))
                ret.Relay2ScheduleDisplay = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2ScheduleDisplay]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ForcedOpenIOGroupNumber))
                ret.ForcedOpenIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ForcedOpenIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ForcedOpenIOGroupOffset))
                ret.ForcedOpenIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ForcedOpenIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.OpenTooLongIOGroupNumber))
                ret.OpenTooLongIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.OpenTooLongIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.OpenTooLongIOGroupOffset))
                ret.OpenTooLongIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.OpenTooLongIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupNumber))
                ret.InvalidAccessAttemptIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupOffset))
                ret.InvalidAccessAttemptIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.InvalidAccessAttemptIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackViolationIOGroupNumber))
                ret.PassbackViolationIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackViolationIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackViolationIOGroupOffset))
                ret.PassbackViolationIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackViolationIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DuressIOGroupNumber))
                ret.DuressIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DuressIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DuressIOGroupOffset))
                ret.DuressIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DuressIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MissedHeartbeatIOGroupNumber))
                ret.MissedHeartbeatIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MissedHeartbeatIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MissedHeartbeatIOGroupOffset))
                ret.MissedHeartbeatIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MissedHeartbeatIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGrantedIOGroupNumber))
                ret.AccessGrantedIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGrantedIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGrantedIOGroupOffset))
                ret.AccessGrantedIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGrantedIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupIOGroupNumber))
                ret.DoorGroupIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupIOGroupOffset))
                ret.DoorGroupIOGroupOffset = Convert.ToInt16(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupIOGroupOffset]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockedByIOGroupNumber))
                ret.LockedByIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockedByIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockedByIOGroupNumber))
                ret.UnlockedByIOGroupNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockedByIOGroupNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber1))
                ret.DisarmIOGroupNumber1 = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber1]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber2))
                ret.DisarmIOGroupNumber2 = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber2]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber3))
                ret.DisarmIOGroupNumber3 = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber3]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.HardwareAddressLastUpdated))
                ret.HardwareAddressLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.HardwareAddressLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber4))
                ret.DisarmIOGroupNumber4 = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIOGroupNumber4]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackIntoAreaLastUpdated))
                ret.PassbackIntoAreaLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackIntoAreaLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalLastUpdated))
                ret.AccessPortalLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessPortalLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackFromAreaLastUpdated))
                ret.PassbackFromAreaLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackFromAreaLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.FreeAccessSchLastUpdated))
                ret.FreeAccessSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.FreeAccessSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CrisisFreeAccessSchLastUpdated))
                ret.CrisisFreeAccessSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CrisisFreeAccessSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredSchLastUpdated))
                ret.PinRequiredSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PinRequiredSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableForcedOpenSchLastUpdated))
                ret.DisableForcedOpenSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableForcedOpenSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableOpenTooLongSchLastUpdated))
                ret.DisableOpenTooLongSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisableOpenTooLongSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxOutputSchLastUpdated))
                ret.AuxOutputSchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxOutputSchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxOutputLastUpdated))
                ret.AuxOutputLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AuxOutputLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2SchLastUpdated))
                ret.Relay2SchLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.Relay2SchLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ForcedOpenAlertLastUpdated))
                ret.ForcedOpenAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ForcedOpenAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.OpenTooLongAlertLastUpdated))
                ret.OpenTooLongAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.OpenTooLongAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.InvalidAccessAttemptAlertLastUpdated))
                ret.InvalidAccessAttemptAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.InvalidAccessAttemptAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackViolationAlertLastUpdated))
                ret.PassbackViolationAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.PassbackViolationAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DuressAlertLastUpdated))
                ret.DuressAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DuressAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MissedHeartbeatAlertLastUpdated))
                ret.MissedHeartbeatAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.MissedHeartbeatAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGrantedAlertLastUpdated))
                ret.AccessGrantedAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.AccessGrantedAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupAlertLastUpdated))
                ret.DoorGroupAlertLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DoorGroupAlertLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockedByIogLastUpdated))
                ret.UnlockedByIogLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.UnlockedByIogLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockedByIogLastUpdated))
                ret.LockedByIogLastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.LockedByIogLastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog1LastUpdated))
                ret.DisarmIog1LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog1LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog2LastUpdated))
                ret.DisarmIog2LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog2LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog3LastUpdated))
                ret.DisarmIog3LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog3LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog4LastUpdated))
                ret.DisarmIog4LastUpdated = Convert.ToDateTime(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.DisarmIog4LastUpdated]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuUid]);
            //PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToInt32(values[AccessPortal_PanelLoadDataPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortal_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortal_PanelLoadDataPDSACollection</returns>
        public AccessPortal_PanelLoadDataPDSACollection BuildCollection()
        {
            AccessPortal_PanelLoadDataPDSACollection coll = new AccessPortal_PanelLoadDataPDSACollection();
            AccessPortal_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of AccessPortal_PanelLoadDataPDSA objects</returns>
        public AccessPortal_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            AccessPortal_PanelLoadDataPDSACollection coll = new AccessPortal_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of AccessPortal_PanelLoadDataPDSA objects</returns>
        public AccessPortal_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortal_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortal_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortal_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// AccessPortal_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortal_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortal_PanelLoadDataPDSA object</param>
        /// <returns>An AccessPortal_PanelLoadDataPDSA object</returns>
        public AccessPortal_PanelLoadDataPDSA InitSearchFilter(AccessPortal_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.PortalName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortal_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current AccessPortal_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned AccessPortal_PanelLoadDataPDSA object</returns>
        public AccessPortal_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in AccessPortal_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The AccessPortal_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned AccessPortal_PanelLoadDataPDSA object</returns>
        public AccessPortal_PanelLoadDataPDSA CloneEntity(AccessPortal_PanelLoadDataPDSA entityToClone)
        {
            AccessPortal_PanelLoadDataPDSA newEntity = new AccessPortal_PanelLoadDataPDSA();

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
            newEntity.HardwareAddressLastUpdated = entityToClone.HardwareAddressLastUpdated;
            newEntity.DisarmIOGroupNumber4 = entityToClone.DisarmIOGroupNumber4;
            newEntity.PassbackIntoAreaLastUpdated = entityToClone.PassbackIntoAreaLastUpdated;
            newEntity.AccessPortalLastUpdated = entityToClone.AccessPortalLastUpdated;
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
