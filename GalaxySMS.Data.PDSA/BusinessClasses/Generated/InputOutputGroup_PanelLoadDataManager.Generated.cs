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
    /// This class should be used when you need to select data for the InputOutputGroup_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputOutputGroup_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputOutputGroup_PanelLoadDataPDSAManager class
        /// </summary>
        public InputOutputGroup_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the InputOutputGroup_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputOutputGroup_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the InputOutputGroup_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputOutputGroup_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputOutputGroup_PanelLoadDataPDSA _Entity = null;
        private InputOutputGroup_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputOutputGroup_PanelLoadDataPDSA Entity
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
        public InputOutputGroup_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputOutputGroup_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputOutputGroup_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputOutputGroup_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new InputOutputGroup_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputOutputGroup_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputOutputGroup_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "InputOutputGroup_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputOutputGroup_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputOutputGroup_PanelLoadDataPDSA ret = new InputOutputGroup_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid))
                ret.InputOutputGroupUid = PDSAProperty.ConvertToGuid(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupUid]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName))
                ret.InputOutputGroupName = PDSAString.ConvertToStringTrim(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroupName]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber))
                ret.IOGroupNumber = Convert.ToInt32(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.IOGroupNumber]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber))
                ret.PanelScheduleNumber = Convert.ToInt32(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.PanelScheduleNumber]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup))
                ret.LocalIOGroup = Convert.ToBoolean(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.LocalIOGroup]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName))
                ret.TimeScheduleName = PDSAString.ConvertToStringTrim(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.TimeScheduleName]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName))
                ret.EntityName = PDSAString.ConvertToStringTrim(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityName]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[InputOutputGroup_PanelLoadDataPDSAValidator.ColumnNames.ClusterName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputOutputGroup_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputOutputGroup_PanelLoadDataPDSACollection</returns>
        public InputOutputGroup_PanelLoadDataPDSACollection BuildCollection()
        {
            InputOutputGroup_PanelLoadDataPDSACollection coll = new InputOutputGroup_PanelLoadDataPDSACollection();
            InputOutputGroup_PanelLoadDataPDSA entity = null;
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
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                this.Log().Error($"Exception in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{ex}", ex);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    this.Log().Error($"InnerException in {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{System.Reflection.MethodBase.GetCurrentMethod().Name}:{innerEx}", innerEx);
                    //System.Diagnostics.Debug.WriteLine(innerEx.Message);
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
        /// <returns>A collection of InputOutputGroup_PanelLoadDataPDSA objects</returns>
        public InputOutputGroup_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            InputOutputGroup_PanelLoadDataPDSACollection coll = new InputOutputGroup_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of InputOutputGroup_PanelLoadDataPDSA objects</returns>
        public InputOutputGroup_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputOutputGroup_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputOutputGroup_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputOutputGroup_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// InputOutputGroup_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(InputOutputGroup_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputOutputGroup_PanelLoadDataPDSA object</param>
        /// <returns>An InputOutputGroup_PanelLoadDataPDSA object</returns>
        public InputOutputGroup_PanelLoadDataPDSA InitSearchFilter(InputOutputGroup_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.InputOutputGroupName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputOutputGroup_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current InputOutputGroup_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned InputOutputGroup_PanelLoadDataPDSA object</returns>
        public InputOutputGroup_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in InputOutputGroup_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The InputOutputGroup_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned InputOutputGroup_PanelLoadDataPDSA object</returns>
        public InputOutputGroup_PanelLoadDataPDSA CloneEntity(InputOutputGroup_PanelLoadDataPDSA entityToClone)
        {
            InputOutputGroup_PanelLoadDataPDSA newEntity = new InputOutputGroup_PanelLoadDataPDSA();

            newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
            newEntity.InputOutputGroupName = entityToClone.InputOutputGroupName;
            newEntity.IOGroupNumber = entityToClone.IOGroupNumber;
            newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
            newEntity.LocalIOGroup = entityToClone.LocalIOGroup;
            newEntity.TimeScheduleName = entityToClone.TimeScheduleName;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.ClusterName = entityToClone.ClusterName;

            return newEntity;
        }
        #endregion
    }
}
