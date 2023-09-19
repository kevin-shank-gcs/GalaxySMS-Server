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
    /// This class should be used when you need to select data for the OutputDeviceGalaxyHardwareAddressViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class OutputDeviceGalaxyHardwareAddressViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the OutputDeviceGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        public OutputDeviceGalaxyHardwareAddressViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the OutputDeviceGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public OutputDeviceGalaxyHardwareAddressViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the OutputDeviceGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public OutputDeviceGalaxyHardwareAddressViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private OutputDeviceGalaxyHardwareAddressViewPDSA _Entity = null;
        private OutputDeviceGalaxyHardwareAddressViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public OutputDeviceGalaxyHardwareAddressViewPDSA Entity
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
        public OutputDeviceGalaxyHardwareAddressViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new OutputDeviceGalaxyHardwareAddressViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public OutputDeviceGalaxyHardwareAddressViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public OutputDeviceGalaxyHardwareAddressViewPDSAData DataObject { get; set; }
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
                Entity = new OutputDeviceGalaxyHardwareAddressViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new OutputDeviceGalaxyHardwareAddressViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new OutputDeviceGalaxyHardwareAddressViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "OutputDeviceGalaxyHardwareAddressViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            OutputDeviceGalaxyHardwareAddressViewPDSA ret = new OutputDeviceGalaxyHardwareAddressViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.OutputName))
                ret.OutputName = PDSAString.ConvertToStringTrim(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.OutputName]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.OutputDeviceUid))
                ret.OutputDeviceUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.OutputDeviceUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeUid))
                ret.ClusterTypeUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeCode))
                ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeCode]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelModelUid))
                ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelModelUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode))
                ret.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid))
                ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode))
                ret.InterfaceBoardTypeCode = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardModel))
                ret.InterfaceBoardModel = PDSAString.ConvertToStringTrim(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardModel]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
                ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
                ret.InterfaceBoardSectionModeCode = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid))
                ret.GalaxyHardwareModuleTypeUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleTypeCode))
                ret.ModuleTypeCode = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleTypeCode]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[OutputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of OutputDeviceGalaxyHardwareAddressViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>OutputDeviceGalaxyHardwareAddressViewPDSACollection</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSACollection BuildCollection()
        {
            OutputDeviceGalaxyHardwareAddressViewPDSACollection coll = new OutputDeviceGalaxyHardwareAddressViewPDSACollection();
            OutputDeviceGalaxyHardwareAddressViewPDSA entity = null;
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
        /// <returns>A collection of OutputDeviceGalaxyHardwareAddressViewPDSA objects</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSACollection BuildCollection(DataSet ds)
        {
            OutputDeviceGalaxyHardwareAddressViewPDSACollection coll = new OutputDeviceGalaxyHardwareAddressViewPDSACollection();

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
        /// <returns>A collection of OutputDeviceGalaxyHardwareAddressViewPDSA objects</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of OutputDeviceGalaxyHardwareAddressViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(OutputDeviceGalaxyHardwareAddressViewPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = OutputDeviceGalaxyHardwareAddressViewPDSAData.SelectFilters.Search;

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
        /// OutputDeviceGalaxyHardwareAddressViewPDSA.SearchEntity = mgr.InitSearchFilter(OutputDeviceGalaxyHardwareAddressViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A OutputDeviceGalaxyHardwareAddressViewPDSA object</param>
        /// <returns>An OutputDeviceGalaxyHardwareAddressViewPDSA object</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSA InitSearchFilter(OutputDeviceGalaxyHardwareAddressViewPDSA searchEntity)
        {
            searchEntity.OutputName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = OutputDeviceGalaxyHardwareAddressViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current OutputDeviceGalaxyHardwareAddressViewPDSA
        /// </summary>
        /// <returns>A cloned OutputDeviceGalaxyHardwareAddressViewPDSA object</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in OutputDeviceGalaxyHardwareAddressViewPDSA
        /// </summary>
        /// <param name="entityToClone">The OutputDeviceGalaxyHardwareAddressViewPDSA entity to clone</param>
        /// <returns>A cloned OutputDeviceGalaxyHardwareAddressViewPDSA object</returns>
        public OutputDeviceGalaxyHardwareAddressViewPDSA CloneEntity(OutputDeviceGalaxyHardwareAddressViewPDSA entityToClone)
        {
            OutputDeviceGalaxyHardwareAddressViewPDSA newEntity = new OutputDeviceGalaxyHardwareAddressViewPDSA();

            newEntity.OutputName = entityToClone.OutputName;
            newEntity.OutputDeviceUid = entityToClone.OutputDeviceUid;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterTypeUid = entityToClone.ClusterTypeUid;
            newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
            newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
            newEntity.GalaxyPanelTypeCode = entityToClone.GalaxyPanelTypeCode;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.InterfaceBoardTypeUid = entityToClone.InterfaceBoardTypeUid;
            newEntity.InterfaceBoardTypeCode = entityToClone.InterfaceBoardTypeCode;
            newEntity.InterfaceBoardModel = entityToClone.InterfaceBoardModel;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.InterfaceBoardSectionModeUid = entityToClone.InterfaceBoardSectionModeUid;
            newEntity.InterfaceBoardSectionModeCode = entityToClone.InterfaceBoardSectionModeCode;
            newEntity.ModuleNumber = entityToClone.ModuleNumber;
            newEntity.GalaxyHardwareModuleTypeUid = entityToClone.GalaxyHardwareModuleTypeUid;
            newEntity.ModuleTypeCode = entityToClone.ModuleTypeCode;
            newEntity.NodeNumber = entityToClone.NodeNumber;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
            newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
            newEntity.GalaxyHardwareModuleUid = entityToClone.GalaxyHardwareModuleUid;
            newEntity.GalaxyInterfaceBoardSectionNodeUid = entityToClone.GalaxyInterfaceBoardSectionNodeUid;

            return newEntity;
        }
        #endregion
    }
}
