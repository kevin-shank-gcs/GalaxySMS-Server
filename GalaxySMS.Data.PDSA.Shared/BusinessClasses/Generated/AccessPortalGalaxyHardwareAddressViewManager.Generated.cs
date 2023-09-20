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
    /// This class should be used when you need to select data for the AccessPortalGalaxyHardwareAddressViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortalGalaxyHardwareAddressViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortalGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        public AccessPortalGalaxyHardwareAddressViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the AccessPortalGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortalGalaxyHardwareAddressViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the AccessPortalGalaxyHardwareAddressViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortalGalaxyHardwareAddressViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortalGalaxyHardwareAddressViewPDSA _Entity = null;
        private AccessPortalGalaxyHardwareAddressViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortalGalaxyHardwareAddressViewPDSA Entity
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
        public AccessPortalGalaxyHardwareAddressViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortalGalaxyHardwareAddressViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortalGalaxyHardwareAddressViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortalGalaxyHardwareAddressViewPDSAData DataObject { get; set; }
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
                Entity = new AccessPortalGalaxyHardwareAddressViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortalGalaxyHardwareAddressViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortalGalaxyHardwareAddressViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessPortalGalaxyHardwareAddressViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortalGalaxyHardwareAddressViewPDSA ret = new AccessPortalGalaxyHardwareAddressViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PortalName))
                ret.PortalName = PDSAString.ConvertToStringTrim(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PortalName]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.AccessPortalUid))
                ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.AccessPortalUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeUid))
                ret.ClusterTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeCode))
                ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterTypeCode]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelModelUid))
                ret.GalaxyPanelModelUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelModelUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode))
                ret.GalaxyPanelTypeCode = PDSAString.ConvertToStringTrim(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelTypeCode]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid))
                ret.InterfaceBoardTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode))
                ret.InterfaceBoardTypeCode = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardTypeCode]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardModel))
                ret.InterfaceBoardModel = PDSAString.ConvertToStringTrim(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardModel]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
                ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode))
                ret.InterfaceBoardSectionModeCode = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.InterfaceBoardSectionModeCode]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid))
                ret.GalaxyHardwareModuleTypeUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleTypeUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleTypeCode))
                ret.ModuleTypeCode = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ModuleTypeCode]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.DoorNumber))
                ret.DoorNumber = Convert.ToInt16(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.DoorNumber]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid))
                ret.GalaxyHardwareModuleUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyHardwareModuleUid]);

            if (values.ContainsKey(AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid))
                ret.GalaxyInterfaceBoardSectionNodeUid = PDSAProperty.ConvertToGuid(values[AccessPortalGalaxyHardwareAddressViewPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionNodeUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortalGalaxyHardwareAddressViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortalGalaxyHardwareAddressViewPDSACollection</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSACollection BuildCollection()
        {
            AccessPortalGalaxyHardwareAddressViewPDSACollection coll = new AccessPortalGalaxyHardwareAddressViewPDSACollection();
            AccessPortalGalaxyHardwareAddressViewPDSA entity = null;
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
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
        /// <returns>A collection of AccessPortalGalaxyHardwareAddressViewPDSA objects</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSACollection BuildCollection(DataSet ds)
        {
            AccessPortalGalaxyHardwareAddressViewPDSACollection coll = new AccessPortalGalaxyHardwareAddressViewPDSACollection();

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
        /// <returns>A collection of AccessPortalGalaxyHardwareAddressViewPDSA objects</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortalGalaxyHardwareAddressViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortalGalaxyHardwareAddressViewPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortalGalaxyHardwareAddressViewPDSAData.SelectFilters.Search;

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
        /// AccessPortalGalaxyHardwareAddressViewPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalGalaxyHardwareAddressViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortalGalaxyHardwareAddressViewPDSA object</param>
        /// <returns>An AccessPortalGalaxyHardwareAddressViewPDSA object</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSA InitSearchFilter(AccessPortalGalaxyHardwareAddressViewPDSA searchEntity)
        {
            searchEntity.PortalName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortalGalaxyHardwareAddressViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current AccessPortalGalaxyHardwareAddressViewPDSA
        /// </summary>
        /// <returns>A cloned AccessPortalGalaxyHardwareAddressViewPDSA object</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in AccessPortalGalaxyHardwareAddressViewPDSA
        /// </summary>
        /// <param name="entityToClone">The AccessPortalGalaxyHardwareAddressViewPDSA entity to clone</param>
        /// <returns>A cloned AccessPortalGalaxyHardwareAddressViewPDSA object</returns>
        public AccessPortalGalaxyHardwareAddressViewPDSA CloneEntity(AccessPortalGalaxyHardwareAddressViewPDSA entityToClone)
        {
            AccessPortalGalaxyHardwareAddressViewPDSA newEntity = new AccessPortalGalaxyHardwareAddressViewPDSA();

            newEntity.PortalName = entityToClone.PortalName;
            newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
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
            newEntity.DoorNumber = entityToClone.DoorNumber;
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
