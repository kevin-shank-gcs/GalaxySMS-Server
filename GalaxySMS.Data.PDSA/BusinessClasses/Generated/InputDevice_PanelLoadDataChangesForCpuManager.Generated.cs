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
    /// This class should be used when you need to select data for the InputDevice_PanelLoadDataChangesForCpuPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputDevice_PanelLoadDataChangesForCpuPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputDevice_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        public InputDevice_PanelLoadDataChangesForCpuPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the InputDevice_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputDevice_PanelLoadDataChangesForCpuPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the InputDevice_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputDevice_PanelLoadDataChangesForCpuPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputDevice_PanelLoadDataChangesForCpuPDSA _Entity = null;
        private InputDevice_PanelLoadDataChangesForCpuPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputDevice_PanelLoadDataChangesForCpuPDSA Entity
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
        public InputDevice_PanelLoadDataChangesForCpuPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputDevice_PanelLoadDataChangesForCpuPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputDevice_PanelLoadDataChangesForCpuPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputDevice_PanelLoadDataChangesForCpuPDSAData DataObject { get; set; }
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
                Entity = new InputDevice_PanelLoadDataChangesForCpuPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputDevice_PanelLoadDataChangesForCpuPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputDevice_PanelLoadDataChangesForCpuPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputDevice_PanelLoadDataChangesForCpuPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputDevice_PanelLoadDataChangesForCpuPDSA ret = new InputDevice_PanelLoadDataChangesForCpuPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceUid))
                ret.InputDeviceUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputName))
                ret.InputName = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputName]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsInputActive))
                ret.IsInputActive = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsInputActive]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsNodeActive))
                ret.IsNodeActive = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsNodeActive]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsModuleActive))
                ret.IsModuleActive = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsModuleActive]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardSectionMode))
                ret.InputDeviceBoardSectionMode = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardSectionMode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardSectionModeDisplay))
                ret.InputDeviceBoardSectionModeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardSectionModeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDevicePanelModelTypeCode))
                ret.InputDevicePanelModelTypeCode = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDevicePanelModelTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceCpuTypeCode))
                ret.InputDeviceCpuTypeCode = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceCpuTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardTypeModel))
                ret.InputDeviceBoardTypeModel = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardTypeModel]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardTypeTypeCode))
                ret.InputDeviceBoardTypeTypeCode = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardTypeTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardTypeDisplay))
                ret.InputDeviceBoardTypeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputDeviceBoardTypeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SupervisionTypeDisplay))
                ret.SupervisionTypeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SupervisionTypeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.HasSeriesResistor))
                ret.HasSeriesResistor = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.HasSeriesResistor]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.HasParallelResistor))
                ret.HasParallelResistor = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.HasParallelResistor]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsNormalOpen))
                ret.IsNormalOpen = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsNormalOpen]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.TroubleShortThreshold))
                ret.TroubleShortThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.TroubleShortThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.TroubleOpenThreshold))
                ret.TroubleOpenThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.TroubleOpenThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NormalChangeThreshold))
                ret.NormalChangeThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NormalChangeThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateNormalChangeThreshold))
                ret.AlternateNormalChangeThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateNormalChangeThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateTroubleOpenThreshold))
                ret.AlternateTroubleOpenThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateTroubleOpenThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateTroubleShortThreshold))
                ret.AlternateTroubleShortThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateTroubleShortThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateVoltagesEnabled))
                ret.AlternateVoltagesEnabled = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.AlternateVoltagesEnabled]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputModeDisplay))
                ret.GalaxyInputModeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputModeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputModeCode))
                ret.GalaxyInputModeCode = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputModeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputDelayTypeDisplay))
                ret.GalaxyInputDelayTypeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputDelayTypeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputDelayTypeCode))
                ret.GalaxyInputDelayTypeCode = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputDelayTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupTag))
                ret.MainIOGroupTag = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupTag]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupDisplay))
                ret.MainIOGroupDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupNumber))
                ret.MainIOGroupNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupIsLocal))
                ret.MainIOGroupIsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupIsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupOffset))
                ret.MainIOGroupOffset = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupOffset]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DelayDuration))
                ret.DelayDuration = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DelayDuration]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents))
                ret.DisableDisarmedOnOffLogEvents = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmControlScheduleDisplay))
                ret.ArmControlScheduleDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmControlScheduleDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmControlScheduleNumber))
                ret.ArmControlScheduleNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmControlScheduleNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup1Display))
                ret.ArmingIOGroup1Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup1Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber1))
                ret.ArmingIOGroupNumber1 = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber1]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup1IsLocal))
                ret.ArmingIOGroup1IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup1IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup2Display))
                ret.ArmingIOGroup2Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup2Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber2))
                ret.ArmingIOGroupNumber2 = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber2]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup2IsLocal))
                ret.ArmingIOGroup2IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup2IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup3Display))
                ret.ArmingIOGroup3Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup3Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber3))
                ret.ArmingIOGroupNumber3 = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber3]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup3IsLocal))
                ret.ArmingIOGroup3IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup3IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup4Display))
                ret.ArmingIOGroup4Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup4Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber4))
                ret.ArmingIOGroupNumber4 = Convert.ToInt32(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroupNumber4]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup4IsLocal))
                ret.ArmingIOGroup4IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup4IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputDevicePropertiesLastUpdated))
                ret.GalaxyInputDevicePropertiesLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInputDevicePropertiesLastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupLastUpdated))
                ret.MainIOGroupLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainIOGroupLastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup1LastUpdated))
                ret.ArmingIOGroup1LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup1LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup2LastUpdated))
                ret.ArmingIOGroup2LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup2LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup3LastUpdated))
                ret.ArmingIOGroup3LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup3LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup4LastUpdated))
                ret.ArmingIOGroup4LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ArmingIOGroup4LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainScheduleLastUpdated))
                ret.MainScheduleLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.MainScheduleLastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToBoolean(values[InputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputDevice_PanelLoadDataChangesForCpuPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputDevice_PanelLoadDataChangesForCpuPDSACollection</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSACollection BuildCollection()
        {
            InputDevice_PanelLoadDataChangesForCpuPDSACollection coll = new InputDevice_PanelLoadDataChangesForCpuPDSACollection();
            InputDevice_PanelLoadDataChangesForCpuPDSA entity = null;
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
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}", ex);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    this.Log().Error($"InnerException in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{innerEx}", innerEx);
                    //System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
}

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of InputDevice_PanelLoadDataChangesForCpuPDSA objects</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataSet ds)
        {
            InputDevice_PanelLoadDataChangesForCpuPDSACollection coll = new InputDevice_PanelLoadDataChangesForCpuPDSACollection();

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
        /// <returns>A collection of InputDevice_PanelLoadDataChangesForCpuPDSA objects</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputDevice_PanelLoadDataChangesForCpuPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputDevice_PanelLoadDataChangesForCpuPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputDevice_PanelLoadDataChangesForCpuPDSAData.SelectFilters.Search;

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
        /// InputDevice_PanelLoadDataChangesForCpuPDSA.SearchEntity = mgr.InitSearchFilter(InputDevice_PanelLoadDataChangesForCpuPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputDevice_PanelLoadDataChangesForCpuPDSA object</param>
        /// <returns>An InputDevice_PanelLoadDataChangesForCpuPDSA object</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSA InitSearchFilter(InputDevice_PanelLoadDataChangesForCpuPDSA searchEntity)
        {
            searchEntity.InputName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputDevice_PanelLoadDataChangesForCpuPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current InputDevice_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <returns>A cloned InputDevice_PanelLoadDataChangesForCpuPDSA object</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in InputDevice_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <param name="entityToClone">The InputDevice_PanelLoadDataChangesForCpuPDSA entity to clone</param>
        /// <returns>A cloned InputDevice_PanelLoadDataChangesForCpuPDSA object</returns>
        public InputDevice_PanelLoadDataChangesForCpuPDSA CloneEntity(InputDevice_PanelLoadDataChangesForCpuPDSA entityToClone)
        {
            InputDevice_PanelLoadDataChangesForCpuPDSA newEntity = new InputDevice_PanelLoadDataChangesForCpuPDSA();

            newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
            newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
            newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
            newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
            newEntity.InputName = entityToClone.InputName;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.ModuleNumber = entityToClone.ModuleNumber;
            newEntity.NodeNumber = entityToClone.NodeNumber;
            newEntity.IsInputActive = entityToClone.IsInputActive;
            newEntity.IsNodeActive = entityToClone.IsNodeActive;
            newEntity.IsModuleActive = entityToClone.IsModuleActive;
            newEntity.InputDeviceBoardSectionMode = entityToClone.InputDeviceBoardSectionMode;
            newEntity.InputDeviceBoardSectionModeDisplay = entityToClone.InputDeviceBoardSectionModeDisplay;
            newEntity.InputDevicePanelModelTypeCode = entityToClone.InputDevicePanelModelTypeCode;
            newEntity.InputDeviceCpuTypeCode = entityToClone.InputDeviceCpuTypeCode;
            newEntity.InputDeviceBoardTypeModel = entityToClone.InputDeviceBoardTypeModel;
            newEntity.InputDeviceBoardTypeTypeCode = entityToClone.InputDeviceBoardTypeTypeCode;
            newEntity.InputDeviceBoardTypeDisplay = entityToClone.InputDeviceBoardTypeDisplay;
            newEntity.SupervisionTypeDisplay = entityToClone.SupervisionTypeDisplay;
            newEntity.HasSeriesResistor = entityToClone.HasSeriesResistor;
            newEntity.HasParallelResistor = entityToClone.HasParallelResistor;
            newEntity.IsNormalOpen = entityToClone.IsNormalOpen;
            newEntity.TroubleShortThreshold = entityToClone.TroubleShortThreshold;
            newEntity.TroubleOpenThreshold = entityToClone.TroubleOpenThreshold;
            newEntity.NormalChangeThreshold = entityToClone.NormalChangeThreshold;
            newEntity.AlternateNormalChangeThreshold = entityToClone.AlternateNormalChangeThreshold;
            newEntity.AlternateTroubleOpenThreshold = entityToClone.AlternateTroubleOpenThreshold;
            newEntity.AlternateTroubleShortThreshold = entityToClone.AlternateTroubleShortThreshold;
            newEntity.AlternateVoltagesEnabled = entityToClone.AlternateVoltagesEnabled;
            newEntity.GalaxyInputModeDisplay = entityToClone.GalaxyInputModeDisplay;
            newEntity.GalaxyInputModeCode = entityToClone.GalaxyInputModeCode;
            newEntity.GalaxyInputDelayTypeDisplay = entityToClone.GalaxyInputDelayTypeDisplay;
            newEntity.GalaxyInputDelayTypeCode = entityToClone.GalaxyInputDelayTypeCode;
            newEntity.MainIOGroupTag = entityToClone.MainIOGroupTag;
            newEntity.MainIOGroupDisplay = entityToClone.MainIOGroupDisplay;
            newEntity.MainIOGroupNumber = entityToClone.MainIOGroupNumber;
            newEntity.MainIOGroupIsLocal = entityToClone.MainIOGroupIsLocal;
            newEntity.MainIOGroupOffset = entityToClone.MainIOGroupOffset;
            newEntity.DelayDuration = entityToClone.DelayDuration;
            newEntity.DisableDisarmedOnOffLogEvents = entityToClone.DisableDisarmedOnOffLogEvents;
            newEntity.ArmControlScheduleDisplay = entityToClone.ArmControlScheduleDisplay;
            newEntity.ArmControlScheduleNumber = entityToClone.ArmControlScheduleNumber;
            newEntity.ArmingIOGroup1Display = entityToClone.ArmingIOGroup1Display;
            newEntity.ArmingIOGroupNumber1 = entityToClone.ArmingIOGroupNumber1;
            newEntity.ArmingIOGroup1IsLocal = entityToClone.ArmingIOGroup1IsLocal;
            newEntity.ArmingIOGroup2Display = entityToClone.ArmingIOGroup2Display;
            newEntity.ArmingIOGroupNumber2 = entityToClone.ArmingIOGroupNumber2;
            newEntity.ArmingIOGroup2IsLocal = entityToClone.ArmingIOGroup2IsLocal;
            newEntity.ArmingIOGroup3Display = entityToClone.ArmingIOGroup3Display;
            newEntity.ArmingIOGroupNumber3 = entityToClone.ArmingIOGroupNumber3;
            newEntity.ArmingIOGroup3IsLocal = entityToClone.ArmingIOGroup3IsLocal;
            newEntity.ArmingIOGroup4Display = entityToClone.ArmingIOGroup4Display;
            newEntity.ArmingIOGroupNumber4 = entityToClone.ArmingIOGroupNumber4;
            newEntity.ArmingIOGroup4IsLocal = entityToClone.ArmingIOGroup4IsLocal;
            newEntity.GalaxyInputDevicePropertiesLastUpdated = entityToClone.GalaxyInputDevicePropertiesLastUpdated;
            newEntity.MainIOGroupLastUpdated = entityToClone.MainIOGroupLastUpdated;
            newEntity.ArmingIOGroup1LastUpdated = entityToClone.ArmingIOGroup1LastUpdated;
            newEntity.ArmingIOGroup2LastUpdated = entityToClone.ArmingIOGroup2LastUpdated;
            newEntity.ArmingIOGroup3LastUpdated = entityToClone.ArmingIOGroup3LastUpdated;
            newEntity.ArmingIOGroup4LastUpdated = entityToClone.ArmingIOGroup4LastUpdated;
            newEntity.MainScheduleLastUpdated = entityToClone.MainScheduleLastUpdated;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
