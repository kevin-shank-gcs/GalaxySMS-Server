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
    /// This class should be used when you need to select data for the OutputDevice_PanelLoadDataChangesForCpuPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class OutputDevice_PanelLoadDataChangesForCpuPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the OutputDevice_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        public OutputDevice_PanelLoadDataChangesForCpuPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the OutputDevice_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public OutputDevice_PanelLoadDataChangesForCpuPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the OutputDevice_PanelLoadDataChangesForCpuPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public OutputDevice_PanelLoadDataChangesForCpuPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private OutputDevice_PanelLoadDataChangesForCpuPDSA _Entity = null;
        private OutputDevice_PanelLoadDataChangesForCpuPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public OutputDevice_PanelLoadDataChangesForCpuPDSA Entity
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
        public OutputDevice_PanelLoadDataChangesForCpuPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new OutputDevice_PanelLoadDataChangesForCpuPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public OutputDevice_PanelLoadDataChangesForCpuPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public OutputDevice_PanelLoadDataChangesForCpuPDSAData DataObject { get; set; }
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
                Entity = new OutputDevice_PanelLoadDataChangesForCpuPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new OutputDevice_PanelLoadDataChangesForCpuPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new OutputDevice_PanelLoadDataChangesForCpuPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "OutputDevice_PanelLoadDataChangesForCpuPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            OutputDevice_PanelLoadDataChangesForCpuPDSA ret = new OutputDevice_PanelLoadDataChangesForCpuPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceUid))
                ret.OutputDeviceUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputName))
                ret.OutputName = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputName]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsOutputActive))
                ret.IsOutputActive = Convert.ToBoolean(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsOutputActive]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsNodeActive))
                ret.IsNodeActive = Convert.ToBoolean(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsNodeActive]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsModuleActive))
                ret.IsModuleActive = Convert.ToBoolean(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsModuleActive]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardSectionMode))
                ret.OutputDeviceBoardSectionMode = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardSectionMode]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardSectionModeDisplay))
                ret.OutputDeviceBoardSectionModeDisplay = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardSectionModeDisplay]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDevicePanelModelTypeCode))
                ret.OutputDevicePanelModelTypeCode = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDevicePanelModelTypeCode]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceCpuTypeCode))
                ret.OutputDeviceCpuTypeCode = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceCpuTypeCode]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardTypeModel))
                ret.OutputDeviceBoardTypeModel = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardTypeModel]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardTypeTypeCode))
                ret.OutputDeviceBoardTypeTypeCode = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardTypeTypeCode]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardTypeDisplay))
                ret.OutputDeviceBoardTypeDisplay = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.OutputDeviceBoardTypeDisplay]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyOutputModeDisplay))
                ret.GalaxyOutputModeDisplay = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyOutputModeDisplay]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyOutputModeCode))
                ret.GalaxyOutputModeCode = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyOutputModeCode]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputSourceRelationshipDisplay))
                ret.InputSourceRelationshipDisplay = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputSourceRelationshipDisplay]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputSourceRelationshipCode))
                ret.InputSourceRelationshipCode = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InputSourceRelationshipCode]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.TimeoutDuration))
                ret.TimeoutDuration = Convert.ToInt32(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.TimeoutDuration]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Limit))
                ret.Limit = Convert.ToInt32(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.Limit]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvertOutput))
                ret.InvertOutput = Convert.ToBoolean(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.InvertOutput]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ScheduleDisplay))
                ret.ScheduleDisplay = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ScheduleDisplay]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ScheduleNumber))
                ret.ScheduleNumber = Convert.ToInt32(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ScheduleNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyOutputDevicePropertiesLastUpdated))
                ret.GalaxyOutputDevicePropertiesLastUpdated = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.GalaxyOutputDevicePropertiesLastUpdated]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt16(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToBoolean(values[OutputDevice_PanelLoadDataChangesForCpuPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of OutputDevice_PanelLoadDataChangesForCpuPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>OutputDevice_PanelLoadDataChangesForCpuPDSACollection</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSACollection BuildCollection()
        {
            OutputDevice_PanelLoadDataChangesForCpuPDSACollection coll = new OutputDevice_PanelLoadDataChangesForCpuPDSACollection();
            OutputDevice_PanelLoadDataChangesForCpuPDSA entity = null;
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
        /// <returns>A collection of OutputDevice_PanelLoadDataChangesForCpuPDSA objects</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataSet ds)
        {
            OutputDevice_PanelLoadDataChangesForCpuPDSACollection coll = new OutputDevice_PanelLoadDataChangesForCpuPDSACollection();

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
        /// <returns>A collection of OutputDevice_PanelLoadDataChangesForCpuPDSA objects</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of OutputDevice_PanelLoadDataChangesForCpuPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(OutputDevice_PanelLoadDataChangesForCpuPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = OutputDevice_PanelLoadDataChangesForCpuPDSAData.SelectFilters.Search;

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
        /// OutputDevice_PanelLoadDataChangesForCpuPDSA.SearchEntity = mgr.InitSearchFilter(OutputDevice_PanelLoadDataChangesForCpuPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A OutputDevice_PanelLoadDataChangesForCpuPDSA object</param>
        /// <returns>An OutputDevice_PanelLoadDataChangesForCpuPDSA object</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSA InitSearchFilter(OutputDevice_PanelLoadDataChangesForCpuPDSA searchEntity)
        {
            searchEntity.OutputName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = OutputDevice_PanelLoadDataChangesForCpuPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current OutputDevice_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <returns>A cloned OutputDevice_PanelLoadDataChangesForCpuPDSA object</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in OutputDevice_PanelLoadDataChangesForCpuPDSA
        /// </summary>
        /// <param name="entityToClone">The OutputDevice_PanelLoadDataChangesForCpuPDSA entity to clone</param>
        /// <returns>A cloned OutputDevice_PanelLoadDataChangesForCpuPDSA object</returns>
        public OutputDevice_PanelLoadDataChangesForCpuPDSA CloneEntity(OutputDevice_PanelLoadDataChangesForCpuPDSA entityToClone)
        {
            OutputDevice_PanelLoadDataChangesForCpuPDSA newEntity = new OutputDevice_PanelLoadDataChangesForCpuPDSA();

            newEntity.OutputDeviceUid = entityToClone.OutputDeviceUid;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
            newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
            newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
            newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;
            newEntity.OutputName = entityToClone.OutputName;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.ModuleNumber = entityToClone.ModuleNumber;
            newEntity.NodeNumber = entityToClone.NodeNumber;
            newEntity.IsOutputActive = entityToClone.IsOutputActive;
            newEntity.IsNodeActive = entityToClone.IsNodeActive;
            newEntity.IsModuleActive = entityToClone.IsModuleActive;
            newEntity.OutputDeviceBoardSectionMode = entityToClone.OutputDeviceBoardSectionMode;
            newEntity.OutputDeviceBoardSectionModeDisplay = entityToClone.OutputDeviceBoardSectionModeDisplay;
            newEntity.OutputDevicePanelModelTypeCode = entityToClone.OutputDevicePanelModelTypeCode;
            newEntity.OutputDeviceCpuTypeCode = entityToClone.OutputDeviceCpuTypeCode;
            newEntity.OutputDeviceBoardTypeModel = entityToClone.OutputDeviceBoardTypeModel;
            newEntity.OutputDeviceBoardTypeTypeCode = entityToClone.OutputDeviceBoardTypeTypeCode;
            newEntity.OutputDeviceBoardTypeDisplay = entityToClone.OutputDeviceBoardTypeDisplay;
            newEntity.GalaxyOutputModeDisplay = entityToClone.GalaxyOutputModeDisplay;
            newEntity.GalaxyOutputModeCode = entityToClone.GalaxyOutputModeCode;
            newEntity.InputSourceRelationshipDisplay = entityToClone.InputSourceRelationshipDisplay;
            newEntity.InputSourceRelationshipCode = entityToClone.InputSourceRelationshipCode;
            newEntity.TimeoutDuration = entityToClone.TimeoutDuration;
            newEntity.Limit = entityToClone.Limit;
            newEntity.InvertOutput = entityToClone.InvertOutput;
            newEntity.ScheduleDisplay = entityToClone.ScheduleDisplay;
            newEntity.ScheduleNumber = entityToClone.ScheduleNumber;
            newEntity.GalaxyOutputDevicePropertiesLastUpdated = entityToClone.GalaxyOutputDevicePropertiesLastUpdated;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
