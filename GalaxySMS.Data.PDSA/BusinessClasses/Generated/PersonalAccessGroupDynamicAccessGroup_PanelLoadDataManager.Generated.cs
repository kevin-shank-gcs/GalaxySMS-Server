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
    /// This class should be used when you need to select data for the PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager class
        /// </summary>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA _Entity = null;
        private PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA Entity
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
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA ret = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid))
                ret.GalaxyPanelUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.GalaxyPanelUid]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber))
                ret.PersonalAccessGroupNumber = Convert.ToInt32(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber))
                ret.PanelScheduleNumber = Convert.ToInt32(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber))
                ret.DoorNumber = Convert.ToInt16(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.DoorNumber]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay))
                ret.AccessGroupDisplay = PDSAString.ConvertToStringTrim(values[PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAValidator.ColumnNames.AccessGroupDisplay]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection BuildCollection()
        {
            PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection coll = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection();
            PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA entity = null;
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
            {                // This is here for design time exceptions
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
        /// <returns>A collection of PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA objects</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection coll = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA objects</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA object</param>
        /// <returns>An PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA object</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA InitSearchFilter(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.ClusterGroupId = 0;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA object</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA object</returns>
        public PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA CloneEntity(PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA entityToClone)
        {
            PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA newEntity = new PersonalAccessGroupDynamicAccessGroup_PanelLoadDataPDSA();

            newEntity.PersonUid = entityToClone.PersonUid;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
            newEntity.PersonalAccessGroupNumber = entityToClone.PersonalAccessGroupNumber;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
            newEntity.DoorNumber = entityToClone.DoorNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.AccessGroupDisplay = entityToClone.AccessGroupDisplay;

            return newEntity;
        }
        #endregion
    }
}
