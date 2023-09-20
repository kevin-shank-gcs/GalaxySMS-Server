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
    /// This class should be used when you need to select data for the DateType_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class DateType_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the DateType_PanelLoadDataPDSAManager class
        /// </summary>
        public DateType_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the DateType_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public DateType_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the DateType_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public DateType_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private DateType_PanelLoadDataPDSA _Entity = null;
        private DateType_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public DateType_PanelLoadDataPDSA Entity
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
        public DateType_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new DateType_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public DateType_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public DateType_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new DateType_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new DateType_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new DateType_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "DateType_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public DateType_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            DateType_PanelLoadDataPDSA ret = new DateType_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid))
                ret.DateTypeUid = PDSAProperty.ConvertToGuid(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.DateTypeUid]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x))
                ret.Date_x = Convert.ToDateTime(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.Date_x]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName))
                ret.DayTypeName = PDSAString.ConvertToStringTrim(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.DayTypeName]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber))
                ret.PanelDayTypeNumber = Convert.ToInt16(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.PanelDayTypeNumber]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName))
                ret.EntityName = PDSAString.ConvertToStringTrim(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityName]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.ClusterName]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode))
                ret.ScheduleTypeCode = Convert.ToInt16(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeCode]);

            if (values.ContainsKey(DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay))
                ret.ScheduleTypeDisplay = PDSAString.ConvertToStringTrim(values[DateType_PanelLoadDataPDSAValidator.ColumnNames.ScheduleTypeDisplay]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of DateType_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>DateType_PanelLoadDataPDSACollection</returns>
        public DateType_PanelLoadDataPDSACollection BuildCollection()
        {
            DateType_PanelLoadDataPDSACollection coll = new DateType_PanelLoadDataPDSACollection();
            DateType_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of DateType_PanelLoadDataPDSA objects</returns>
        public DateType_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            DateType_PanelLoadDataPDSACollection coll = new DateType_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of DateType_PanelLoadDataPDSA objects</returns>
        public DateType_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of DateType_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(DateType_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = DateType_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// DateType_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(DateType_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A DateType_PanelLoadDataPDSA object</param>
        /// <returns>An DateType_PanelLoadDataPDSA object</returns>
        public DateType_PanelLoadDataPDSA InitSearchFilter(DateType_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.DayTypeName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = DateType_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current DateType_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned DateType_PanelLoadDataPDSA object</returns>
        public DateType_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in DateType_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The DateType_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned DateType_PanelLoadDataPDSA object</returns>
        public DateType_PanelLoadDataPDSA CloneEntity(DateType_PanelLoadDataPDSA entityToClone)
        {
            DateType_PanelLoadDataPDSA newEntity = new DateType_PanelLoadDataPDSA();

            newEntity.DateTypeUid = entityToClone.DateTypeUid;
            newEntity.Date_x = entityToClone.Date_x;
            newEntity.DayTypeName = entityToClone.DayTypeName;
            newEntity.PanelDayTypeNumber = entityToClone.PanelDayTypeNumber;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.ClusterName = entityToClone.ClusterName;
            newEntity.ScheduleTypeCode = entityToClone.ScheduleTypeCode;
            newEntity.ScheduleTypeDisplay = entityToClone.ScheduleTypeDisplay;

            return newEntity;
        }
        #endregion
    }
}
