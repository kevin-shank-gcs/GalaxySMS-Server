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
    /// This class should be used when you need to select data for the GalaxyInterfaceBoardSection_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager class
        /// </summary>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyInterfaceBoardSection_PanelLoadDataPDSA _Entity = null;
        private GalaxyInterfaceBoardSection_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSA Entity
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
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyInterfaceBoardSection_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new GalaxyInterfaceBoardSection_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyInterfaceBoardSection_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyInterfaceBoardSection_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyInterfaceBoardSection_PanelLoadDataPDSA ret = new GalaxyInterfaceBoardSection_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid))
                ret.GalaxyInterfaceBoardSectionUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid))
                ret.GalaxyInterfaceBoardUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid))
                ret.InterfaceBoardSectionModeUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt16(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.IsSectionActive))
                ret.IsSectionActive = Convert.ToBoolean(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.IsSectionActive]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt16(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardSectionMode))
                ret.BoardSectionMode = Convert.ToInt16(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardSectionMode]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardSectionModeDisplay))
                ret.BoardSectionModeDisplay = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardSectionModeDisplay]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.PanelModelTypeCode))
                ret.PanelModelTypeCode = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.PanelModelTypeCode]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.CpuTypeCode))
                ret.CpuTypeCode = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.CpuTypeCode]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardTypeModel))
                ret.BoardTypeModel = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardTypeModel]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardTypeTypeCode))
                ret.BoardTypeTypeCode = Convert.ToInt16(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardTypeTypeCode]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardTypeDisplay))
                ret.BoardTypeDisplay = PDSAString.ConvertToStringTrim(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.BoardTypeDisplay]);

            if (values.ContainsKey(GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[GalaxyInterfaceBoardSection_PanelLoadDataPDSAValidator.ColumnNames.EntityId]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardSection_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection BuildCollection()
        {
            GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection coll = new GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection();
            GalaxyInterfaceBoardSection_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of GalaxyInterfaceBoardSection_PanelLoadDataPDSA objects</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection coll = new GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of GalaxyInterfaceBoardSection_PanelLoadDataPDSA objects</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyInterfaceBoardSection_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyInterfaceBoardSection_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyInterfaceBoardSection_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// GalaxyInterfaceBoardSection_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(GalaxyInterfaceBoardSection_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyInterfaceBoardSection_PanelLoadDataPDSA object</param>
        /// <returns>An GalaxyInterfaceBoardSection_PanelLoadDataPDSA object</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSA InitSearchFilter(GalaxyInterfaceBoardSection_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyInterfaceBoardSection_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current GalaxyInterfaceBoardSection_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned GalaxyInterfaceBoardSection_PanelLoadDataPDSA object</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in GalaxyInterfaceBoardSection_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The GalaxyInterfaceBoardSection_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned GalaxyInterfaceBoardSection_PanelLoadDataPDSA object</returns>
        public GalaxyInterfaceBoardSection_PanelLoadDataPDSA CloneEntity(GalaxyInterfaceBoardSection_PanelLoadDataPDSA entityToClone)
        {
            GalaxyInterfaceBoardSection_PanelLoadDataPDSA newEntity = new GalaxyInterfaceBoardSection_PanelLoadDataPDSA();

            newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
            newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
            newEntity.InterfaceBoardSectionModeUid = entityToClone.InterfaceBoardSectionModeUid;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.IsSectionActive = entityToClone.IsSectionActive;
            newEntity.InsertName = entityToClone.InsertName;
            newEntity.InsertDate = entityToClone.InsertDate;
            newEntity.UpdateName = entityToClone.UpdateName;
            newEntity.UpdateDate = entityToClone.UpdateDate;
            newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.BoardSectionMode = entityToClone.BoardSectionMode;
            newEntity.BoardSectionModeDisplay = entityToClone.BoardSectionModeDisplay;
            newEntity.PanelModelTypeCode = entityToClone.PanelModelTypeCode;
            newEntity.CpuTypeCode = entityToClone.CpuTypeCode;
            newEntity.BoardTypeModel = entityToClone.BoardTypeModel;
            newEntity.BoardTypeTypeCode = entityToClone.BoardTypeTypeCode;
            newEntity.BoardTypeDisplay = entityToClone.BoardTypeDisplay;
            newEntity.EntityId = entityToClone.EntityId;

            return newEntity;
        }
        #endregion
    }
}
