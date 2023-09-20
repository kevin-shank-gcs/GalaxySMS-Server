using System;
using System.Collections.Generic;
using System.Data;

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
    /// This class is used when you need to add, edit, delete, select and validate data for the AssaDsrTimeScheduleMapPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AssaDsrTimeScheduleMapPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AssaDsrTimeScheduleMapPDSAManager class
        /// </summary>
        public AssaDsrTimeScheduleMapPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AssaDsrTimeScheduleMapPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AssaDsrTimeScheduleMapPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AssaDsrTimeScheduleMapPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AssaDsrTimeScheduleMapPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AssaDsrTimeScheduleMapPDSA _Entity = null;
        private AssaDsrTimeScheduleMapPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AssaDsrTimeScheduleMapPDSA Entity
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
        public AssaDsrTimeScheduleMapPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AssaDsrTimeScheduleMapPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AssaDsrTimeScheduleMapPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AssaDsrTimeScheduleMapPDSAData DataObject { get; set; }
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
                Entity = new AssaDsrTimeScheduleMapPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AssaDsrTimeScheduleMapPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AssaDsrTimeScheduleMapPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AssaDsrTimeScheduleMapPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AssaDsrTimeScheduleMapPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AssaDsrTimeScheduleMapPDSA ret = new AssaDsrTimeScheduleMapPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.AssaDsrTimeScheduleMapUid))
                ret.AssaDsrTimeScheduleMapUid = PDSAProperty.ConvertToGuid(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.AssaDsrTimeScheduleMapUid]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.TimeScheduleUid))
                ret.TimeScheduleUid = PDSAProperty.ConvertToGuid(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.TimeScheduleUid]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.AssaDsrUid))
                ret.AssaDsrUid = PDSAProperty.ConvertToGuid(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.AssaDsrUid]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.AssaDsrScheduleId))
                ret.AssaDsrScheduleId = PDSAString.ConvertToStringTrim(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.AssaDsrScheduleId]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AssaDsrTimeScheduleMapPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AssaDsrTimeScheduleMapPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AssaDsrTimeScheduleMapPDSACollection</returns>
        public AssaDsrTimeScheduleMapPDSACollection BuildCollection()
        {
            AssaDsrTimeScheduleMapPDSACollection coll = new AssaDsrTimeScheduleMapPDSACollection();
            AssaDsrTimeScheduleMapPDSA entity = null;
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
        /// <returns>A collection of AssaDsrTimeScheduleMapPDSA objects</returns>
        public AssaDsrTimeScheduleMapPDSACollection BuildCollection(DataSet ds)
        {
            AssaDsrTimeScheduleMapPDSACollection coll = new AssaDsrTimeScheduleMapPDSACollection();

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
        /// <returns>A collection of AssaDsrTimeScheduleMapPDSA objects</returns>
        public AssaDsrTimeScheduleMapPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AssaDsrTimeScheduleMapPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AssaDsrTimeScheduleMapPDSACollection), BuildCollection());
        }
        #endregion

        #region GetDataSet Methods
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
            DataObject.SelectFilter = AssaDsrTimeScheduleMapPDSAData.SelectFilters.Search;

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
        /// AssaDsrTimeScheduleMapPDSA.SearchEntity = mgr.InitSearchFilter(AssaDsrTimeScheduleMapPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AssaDsrTimeScheduleMapPDSA object</param>
        /// <returns>An AssaDsrTimeScheduleMapPDSA object</returns>
        public AssaDsrTimeScheduleMapPDSA InitSearchFilter(AssaDsrTimeScheduleMapPDSA searchEntity)
        {
            searchEntity.AssaDsrScheduleId = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AssaDsrTimeScheduleMapPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AssaDsrTimeScheduleMap table
        /// </summary>
        /// <param name="entity">An AssaDsrTimeScheduleMapPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AssaDsrTimeScheduleMapPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.Insert();
            if (ret >= 1)
                TrackChanges("Insert");

            return ret;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Updates an entity in the GCS.AssaDsrTimeScheduleMap table
        /// </summary>
        /// <param name="entity">An AssaDsrTimeScheduleMapPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AssaDsrTimeScheduleMapPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.Update();
            if (ret >= 1)
                TrackChanges("Update");

            return ret;
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Deletes an entity from the GCS.AssaDsrTimeScheduleMap table
        /// </summary>
        /// <param name="entity">An AssaDsrTimeScheduleMapPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AssaDsrTimeScheduleMapPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AssaDsrTimeScheduleMapUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetAssaDsrTimeScheduleMapPDSAsByFK_AssaDsrTimeScheduleMapAssaDsrEntity Method
        public AssaDsrTimeScheduleMapPDSACollection GetAssaDsrTimeScheduleMapPDSAsByFK_AssaDsrTimeScheduleMapAssaDsrEntity(AssaDsrPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AssaDsrTimeScheduleMapPDSAData.SelectFilters.ByAssaDsrUid;
                    }
                    else
                    {
                    }

                    Entity.AssaDsrUid = entity.AssaDsrUid;
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
System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new AssaDsrTimeScheduleMapPDSACollection();
        }
        #endregion

        #region GetAssaDsrTimeScheduleMapPDSAsByFK_AssaDsrTimeScheduleMapAssaDsr Method
        public AssaDsrTimeScheduleMapPDSACollection GetAssaDsrTimeScheduleMapPDSAsByFK_AssaDsrTimeScheduleMapAssaDsr(Guid assaDsrUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AssaDsrTimeScheduleMapPDSAData.SelectFilters.ByAssaDsrUid;
                }
                else
                {
                }

                Entity.AssaDsrUid = assaDsrUid;
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


            return BuildCollection();
        }
        #endregion

    }
}

