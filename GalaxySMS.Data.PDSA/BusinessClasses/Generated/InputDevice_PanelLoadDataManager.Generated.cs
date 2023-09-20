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
    /// This class should be used when you need to select data for the InputDevice_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputDevice_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputDevice_PanelLoadDataPDSAManager class
        /// </summary>
        public InputDevice_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the InputDevice_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputDevice_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the InputDevice_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputDevice_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputDevice_PanelLoadDataPDSA _Entity = null;
        private InputDevice_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputDevice_PanelLoadDataPDSA Entity
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
        public InputDevice_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputDevice_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputDevice_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputDevice_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new InputDevice_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputDevice_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputDevice_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputDevice_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputDevice_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputDevice_PanelLoadDataPDSA ret = new InputDevice_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceUid))
                ret.InputDeviceUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputName))
                ret.InputName = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputName]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsInputActive))
                ret.IsInputActive = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsInputActive]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardSectionMode))
                ret.InputDeviceBoardSectionMode = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardSectionMode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsNodeActive))
                ret.IsNodeActive = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsNodeActive]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardSectionModeDisplay))
                ret.InputDeviceBoardSectionModeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardSectionModeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsModuleActive))
                ret.IsModuleActive = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsModuleActive]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDevicePanelModelTypeCode))
                ret.InputDevicePanelModelTypeCode = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDevicePanelModelTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceCpuTypeCode))
                ret.InputDeviceCpuTypeCode = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceCpuTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardTypeModel))
                ret.InputDeviceBoardTypeModel = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardTypeModel]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardTypeTypeCode))
                ret.InputDeviceBoardTypeTypeCode = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardTypeTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardTypeDisplay))
                ret.InputDeviceBoardTypeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.InputDeviceBoardTypeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.SupervisionTypeDisplay))
                ret.SupervisionTypeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.SupervisionTypeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.HasSeriesResistor))
                ret.HasSeriesResistor = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.HasSeriesResistor]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.HasParallelResistor))
                ret.HasParallelResistor = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.HasParallelResistor]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsNormalOpen))
                ret.IsNormalOpen = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsNormalOpen]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.TroubleShortThreshold))
                ret.TroubleShortThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.TroubleShortThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.TroubleOpenThreshold))
                ret.TroubleOpenThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.TroubleOpenThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.NormalChangeThreshold))
                ret.NormalChangeThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.NormalChangeThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateNormalChangeThreshold))
                ret.AlternateNormalChangeThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateNormalChangeThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateTroubleOpenThreshold))
                ret.AlternateTroubleOpenThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateTroubleOpenThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateTroubleShortThreshold))
                ret.AlternateTroubleShortThreshold = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateTroubleShortThreshold]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateVoltagesEnabled))
                ret.AlternateVoltagesEnabled = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.AlternateVoltagesEnabled]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputModeDisplay))
                ret.GalaxyInputModeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputModeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputModeCode))
                ret.GalaxyInputModeCode = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputModeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputDelayTypeDisplay))
                ret.GalaxyInputDelayTypeDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputDelayTypeDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputDelayTypeCode))
                ret.GalaxyInputDelayTypeCode = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputDelayTypeCode]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupTag))
                ret.MainIOGroupTag = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupTag]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupDisplay))
                ret.MainIOGroupDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupNumber))
                ret.MainIOGroupNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupIsLocal))
                ret.MainIOGroupIsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupIsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupOffset))
                ret.MainIOGroupOffset = Convert.ToInt16(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupOffset]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.DelayDuration))
                ret.DelayDuration = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.DelayDuration]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents))
                ret.DisableDisarmedOnOffLogEvents = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.DisableDisarmedOnOffLogEvents]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmControlScheduleDisplay))
                ret.ArmControlScheduleDisplay = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmControlScheduleDisplay]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputDevicePropertiesLastUpdated))
                ret.GalaxyInputDevicePropertiesLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInputDevicePropertiesLastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupLastUpdated))
                ret.MainIOGroupLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainIOGroupLastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup1LastUpdated))
                ret.ArmingIOGroup1LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup1LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup2LastUpdated))
                ret.ArmingIOGroup2LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup2LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmControlScheduleNumber))
                ret.ArmControlScheduleNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmControlScheduleNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup3LastUpdated))
                ret.ArmingIOGroup3LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup3LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup4LastUpdated))
                ret.ArmingIOGroup4LastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup4LastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainScheduleLastUpdated))
                ret.MainScheduleLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.MainScheduleLastUpdated]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup1Display))
                ret.ArmingIOGroup1Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup1Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber1))
                ret.ArmingIOGroupNumber1 = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber1]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup1IsLocal))
                ret.ArmingIOGroup1IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup1IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup2Display))
                ret.ArmingIOGroup2Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup2Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber2))
                ret.ArmingIOGroupNumber2 = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber2]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup2IsLocal))
                ret.ArmingIOGroup2IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup2IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup3Display))
                ret.ArmingIOGroup3Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup3Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber3))
                ret.ArmingIOGroupNumber3 = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber3]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup3IsLocal))
                ret.ArmingIOGroup3IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup3IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup4Display))
                ret.ArmingIOGroup4Display = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup4Display]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber4))
                ret.ArmingIOGroupNumber4 = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroupNumber4]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup4IsLocal))
                ret.ArmingIOGroup4IsLocal = Convert.ToBoolean(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ArmingIOGroup4IsLocal]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToInt32(values[InputDevice_PanelLoadDataPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputDevice_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputDevice_PanelLoadDataPDSACollection</returns>
        public InputDevice_PanelLoadDataPDSACollection BuildCollection()
        {
            InputDevice_PanelLoadDataPDSACollection coll = new InputDevice_PanelLoadDataPDSACollection();
            InputDevice_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of InputDevice_PanelLoadDataPDSA objects</returns>
        public InputDevice_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            InputDevice_PanelLoadDataPDSACollection coll = new InputDevice_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of InputDevice_PanelLoadDataPDSA objects</returns>
        public InputDevice_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputDevice_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputDevice_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputDevice_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// InputDevice_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(InputDevice_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputDevice_PanelLoadDataPDSA object</param>
        /// <returns>An InputDevice_PanelLoadDataPDSA object</returns>
        public InputDevice_PanelLoadDataPDSA InitSearchFilter(InputDevice_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.InputName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputDevice_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current InputDevice_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned InputDevice_PanelLoadDataPDSA object</returns>
        public InputDevice_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in InputDevice_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The InputDevice_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned InputDevice_PanelLoadDataPDSA object</returns>
        public InputDevice_PanelLoadDataPDSA CloneEntity(InputDevice_PanelLoadDataPDSA entityToClone)
        {
            InputDevice_PanelLoadDataPDSA newEntity = new InputDevice_PanelLoadDataPDSA();

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
            newEntity.InputDeviceBoardSectionMode = entityToClone.InputDeviceBoardSectionMode;
            newEntity.IsNodeActive = entityToClone.IsNodeActive;
            newEntity.InputDeviceBoardSectionModeDisplay = entityToClone.InputDeviceBoardSectionModeDisplay;
            newEntity.IsModuleActive = entityToClone.IsModuleActive;
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
            newEntity.GalaxyInputDevicePropertiesLastUpdated = entityToClone.GalaxyInputDevicePropertiesLastUpdated;
            newEntity.MainIOGroupLastUpdated = entityToClone.MainIOGroupLastUpdated;
            newEntity.ArmingIOGroup1LastUpdated = entityToClone.ArmingIOGroup1LastUpdated;
            newEntity.ArmingIOGroup2LastUpdated = entityToClone.ArmingIOGroup2LastUpdated;
            newEntity.ArmControlScheduleNumber = entityToClone.ArmControlScheduleNumber;
            newEntity.ArmingIOGroup3LastUpdated = entityToClone.ArmingIOGroup3LastUpdated;
            newEntity.ArmingIOGroup4LastUpdated = entityToClone.ArmingIOGroup4LastUpdated;
            newEntity.MainScheduleLastUpdated = entityToClone.MainScheduleLastUpdated;
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
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
