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
    /// This class should be used when you need to select data for the InputDeviceGalaxyHardwareAddressViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputDeviceGalaxyHardwareAddressViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputDeviceGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        public InputDeviceGalaxyHardwareAddressViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the InputDeviceGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputDeviceGalaxyHardwareAddressViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the InputDeviceGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputDeviceGalaxyHardwareAddressViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputDeviceGalaxyHardwareAddressViewPDSA _Entity = null;
        private InputDeviceGalaxyHardwareAddressViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputDeviceGalaxyHardwareAddressViewPDSA Entity
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
        public InputDeviceGalaxyHardwareAddressViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputDeviceGalaxyHardwareAddressViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputDeviceGalaxyHardwareAddressViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputDeviceGalaxyHardwareAddressViewPDSAData DataObject { get; set; }
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
                Entity = new InputDeviceGalaxyHardwareAddressViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputDeviceGalaxyHardwareAddressViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputDeviceGalaxyHardwareAddressViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputDeviceGalaxyHardwareAddressViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputDeviceGalaxyHardwareAddressViewPDSA ret = new InputDeviceGalaxyHardwareAddressViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InputName))
                ret.InputName = PDSAString.ConvertToStringTrim(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InputName]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InputDeviceUid))
                ret.InputDeviceUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InputDeviceUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeUid))
                ret.ClusterTypeUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeCode))
                ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeCode]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelModelUid))
                ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelModelUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode))
                ret.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid))
                ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode))
                ret.InterfaceBoardTypeCode = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardModel))
                ret.InterfaceBoardModel = PDSAString.ConvertToStringTrim(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardModel]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
                ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
                ret.InterfaceBoardSectionModeCode = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid))
                ret.GalaxyHardwareModuleTypeUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleTypeCode))
                ret.ModuleTypeCode = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleTypeCode]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[InputDeviceGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputDeviceGalaxyHardwareAddressViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputDeviceGalaxyHardwareAddressViewPDSACollection</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSACollection BuildCollection()
        {
            InputDeviceGalaxyHardwareAddressViewPDSACollection coll = new InputDeviceGalaxyHardwareAddressViewPDSACollection();
            InputDeviceGalaxyHardwareAddressViewPDSA entity = null;
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
        /// <returns>A collection of InputDeviceGalaxyHardwareAddressViewPDSA objects</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSACollection BuildCollection(DataSet ds)
        {
            InputDeviceGalaxyHardwareAddressViewPDSACollection coll = new InputDeviceGalaxyHardwareAddressViewPDSACollection();

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
        /// <returns>A collection of InputDeviceGalaxyHardwareAddressViewPDSA objects</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputDeviceGalaxyHardwareAddressViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputDeviceGalaxyHardwareAddressViewPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputDeviceGalaxyHardwareAddressViewPDSAData.SelectFilters.Search;

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
        /// InputDeviceGalaxyHardwareAddressViewPDSA.SearchEntity = mgr.InitSearchFilter(InputDeviceGalaxyHardwareAddressViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputDeviceGalaxyHardwareAddressViewPDSA object</param>
        /// <returns>An InputDeviceGalaxyHardwareAddressViewPDSA object</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSA InitSearchFilter(InputDeviceGalaxyHardwareAddressViewPDSA searchEntity)
        {
            searchEntity.InputName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputDeviceGalaxyHardwareAddressViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current InputDeviceGalaxyHardwareAddressViewPDSA
        /// </summary>
        /// <returns>A cloned InputDeviceGalaxyHardwareAddressViewPDSA object</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in InputDeviceGalaxyHardwareAddressViewPDSA
        /// </summary>
        /// <param name="entityToClone">The InputDeviceGalaxyHardwareAddressViewPDSA entity to clone</param>
        /// <returns>A cloned InputDeviceGalaxyHardwareAddressViewPDSA object</returns>
        public InputDeviceGalaxyHardwareAddressViewPDSA CloneEntity(InputDeviceGalaxyHardwareAddressViewPDSA entityToClone)
        {
            InputDeviceGalaxyHardwareAddressViewPDSA newEntity = new InputDeviceGalaxyHardwareAddressViewPDSA();

            newEntity.InputName = entityToClone.InputName;
            newEntity.InputDeviceUid = entityToClone.InputDeviceUid;
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
