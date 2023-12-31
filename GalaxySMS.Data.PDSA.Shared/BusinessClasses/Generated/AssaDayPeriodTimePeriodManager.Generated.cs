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

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used when you need to add, edit, delete, select and validate data for the AssaDayPeriodTimePeriodPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AssaDayPeriodTimePeriodPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AssaDayPeriodTimePeriodPDSAManager class
        /// </summary>
        public AssaDayPeriodTimePeriodPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AssaDayPeriodTimePeriodPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AssaDayPeriodTimePeriodPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AssaDayPeriodTimePeriodPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AssaDayPeriodTimePeriodPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AssaDayPeriodTimePeriodPDSA _Entity = null;
        private AssaDayPeriodTimePeriodPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AssaDayPeriodTimePeriodPDSA Entity
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
        public AssaDayPeriodTimePeriodPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AssaDayPeriodTimePeriodPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AssaDayPeriodTimePeriodPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AssaDayPeriodTimePeriodPDSAData DataObject { get; set; }
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
                Entity = new AssaDayPeriodTimePeriodPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AssaDayPeriodTimePeriodPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AssaDayPeriodTimePeriodPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AssaDayPeriodTimePeriodPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AssaDayPeriodTimePeriodPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AssaDayPeriodTimePeriodPDSA ret = new AssaDayPeriodTimePeriodPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid))
                ret.AssaDayPeriodTimePeriodUid = PDSAProperty.ConvertToGuid(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid))
                ret.AssaDayPeriodUid = PDSAProperty.ConvertToGuid(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid))
                ret.TimePeriodUid = PDSAProperty.ConvertToGuid(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AssaDayPeriodTimePeriodPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AssaDayPeriodTimePeriodPDSACollection</returns>
        public AssaDayPeriodTimePeriodPDSACollection BuildCollection()
        {
            AssaDayPeriodTimePeriodPDSACollection coll = new AssaDayPeriodTimePeriodPDSACollection();
            AssaDayPeriodTimePeriodPDSA entity = null;
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
        /// <returns>A collection of AssaDayPeriodTimePeriodPDSA objects</returns>
        public AssaDayPeriodTimePeriodPDSACollection BuildCollection(DataSet ds)
        {
            AssaDayPeriodTimePeriodPDSACollection coll = new AssaDayPeriodTimePeriodPDSACollection();

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
        /// <returns>A collection of AssaDayPeriodTimePeriodPDSA objects</returns>
        public AssaDayPeriodTimePeriodPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AssaDayPeriodTimePeriodPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AssaDayPeriodTimePeriodPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AssaDayPeriodTimePeriodPDSAData.SelectFilters.Search;

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
        /// AssaDayPeriodTimePeriodPDSA.SearchEntity = mgr.InitSearchFilter(AssaDayPeriodTimePeriodPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AssaDayPeriodTimePeriodPDSA object</param>
        /// <returns>An AssaDayPeriodTimePeriodPDSA object</returns>
        public AssaDayPeriodTimePeriodPDSA InitSearchFilter(AssaDayPeriodTimePeriodPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AssaDayPeriodTimePeriodPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AssaDayPeriodTimePeriod table
        /// </summary>
        /// <param name="entity">An AssaDayPeriodTimePeriodPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AssaDayPeriodTimePeriodPDSA entity)
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
        /// Updates an entity in the GCS.AssaDayPeriodTimePeriod table
        /// </summary>
        /// <param name="entity">An AssaDayPeriodTimePeriodPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AssaDayPeriodTimePeriodPDSA entity)
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
        /// Deletes an entity from the GCS.AssaDayPeriodTimePeriod table
        /// </summary>
        /// <param name="entity">An AssaDayPeriodTimePeriodPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AssaDayPeriodTimePeriodPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AssaDayPeriodTimePeriodUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetAssaDayPeriodTimePeriodPDSAsByFK_AssaDayPeriodTimePeriodAssaDayPeriodEntity Method
        public AssaDayPeriodTimePeriodPDSACollection GetAssaDayPeriodTimePeriodPDSAsByFK_AssaDayPeriodTimePeriodAssaDayPeriodEntity(AssaDayPeriodPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AssaDayPeriodTimePeriodPDSAData.SelectFilters.ByAssaDayPeriodUid;
                    }
                    else
                    {
                    }

                    Entity.AssaDayPeriodUid = entity.AssaDayPeriodUid;
                }
                catch (Exception ex)
                {                // This is here for design time exceptions
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    var innerEx = ex.InnerException;
                    while (innerEx != null)
                    {
                        System.Diagnostics.Debug.WriteLine(innerEx.Message);
                        innerEx = innerEx.InnerException;
                    }
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new AssaDayPeriodTimePeriodPDSACollection();
        }
        #endregion

        #region GetAssaDayPeriodTimePeriodPDSAsByFK_AssaDayPeriodTimePeriodAssaDayPeriod Method
        public AssaDayPeriodTimePeriodPDSACollection GetAssaDayPeriodTimePeriodPDSAsByFK_AssaDayPeriodTimePeriodAssaDayPeriod(Guid assaDayPeriodUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AssaDayPeriodTimePeriodPDSAData.SelectFilters.ByAssaDayPeriodUid;
                }
                else
                {
                }

                Entity.AssaDayPeriodUid = assaDayPeriodUid;
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


            return BuildCollection();
        }
        #endregion

    }
}

