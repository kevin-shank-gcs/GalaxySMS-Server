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
    /// This class is used when you need to add, edit, delete, select and validate data for the FeatureItemPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class FeatureItemPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the FeatureItemPDSAManager class
        /// </summary>
        public FeatureItemPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the FeatureItemPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public FeatureItemPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the FeatureItemPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public FeatureItemPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private FeatureItemPDSA _Entity = null;
        private FeatureItemPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public FeatureItemPDSA Entity
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
        public FeatureItemPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new FeatureItemPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public FeatureItemPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public FeatureItemPDSAData DataObject { get; set; }
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
                Entity = new FeatureItemPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new FeatureItemPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new FeatureItemPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "FeatureItemPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public FeatureItemPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            FeatureItemPDSA ret = new FeatureItemPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.FeatureItemUid))
                ret.FeatureItemUid = PDSAProperty.ConvertToGuid(values[FeatureItemPDSAValidator.ColumnNames.FeatureItemUid]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.FeatureUid))
                ret.FeatureUid = PDSAProperty.ConvertToGuid(values[FeatureItemPDSAValidator.ColumnNames.FeatureUid]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.Value))
                ret.Value = PDSAString.ConvertToStringTrim(values[FeatureItemPDSAValidator.ColumnNames.Value]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.Code))
                ret.Code = PDSAString.ConvertToStringTrim(values[FeatureItemPDSAValidator.ColumnNames.Code]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[FeatureItemPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[FeatureItemPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[FeatureItemPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[FeatureItemPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(FeatureItemPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[FeatureItemPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of FeatureItemPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>FeatureItemPDSACollection</returns>
        public FeatureItemPDSACollection BuildCollection()
        {
            FeatureItemPDSACollection coll = new FeatureItemPDSACollection();
            FeatureItemPDSA entity = null;
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
        /// <returns>A collection of FeatureItemPDSA objects</returns>
        public FeatureItemPDSACollection BuildCollection(DataSet ds)
        {
            FeatureItemPDSACollection coll = new FeatureItemPDSACollection();

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
        /// <returns>A collection of FeatureItemPDSA objects</returns>
        public FeatureItemPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of FeatureItemPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(FeatureItemPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = FeatureItemPDSAData.SelectFilters.Search;

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
        /// FeatureItemPDSA.SearchEntity = mgr.InitSearchFilter(FeatureItemPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A FeatureItemPDSA object</param>
        /// <returns>An FeatureItemPDSA object</returns>
        public FeatureItemPDSA InitSearchFilter(FeatureItemPDSA searchEntity)
        {
            searchEntity.Value = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = FeatureItemPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.FeatureItem table
        /// </summary>
        /// <param name="entity">An FeatureItemPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(FeatureItemPDSA entity)
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
        /// Updates an entity in the GCS.FeatureItem table
        /// </summary>
        /// <param name="entity">An FeatureItemPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(FeatureItemPDSA entity)
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
        /// Deletes an entity from the GCS.FeatureItem table
        /// </summary>
        /// <param name="entity">An FeatureItemPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(FeatureItemPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.FeatureItemUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetFeatureItemPDSAsByFK_FeatureItemFeatureEntity Method
        public FeatureItemPDSACollection GetFeatureItemPDSAsByFK_FeatureItemFeatureEntity(FeaturePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = FeatureItemPDSAData.SelectFilters.ByFeatureUid;
                    }
                    else
                    {
                    }

                    Entity.FeatureUid = entity.FeatureUid;
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
                return new FeatureItemPDSACollection();
        }
        #endregion

        #region GetFeatureItemPDSAsByFK_FeatureItemFeature Method
        public FeatureItemPDSACollection GetFeatureItemPDSAsByFK_FeatureItemFeature(Guid featureUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = FeatureItemPDSAData.SelectFilters.ByFeatureUid;
                }
                else
                {
                }

                Entity.FeatureUid = featureUid;
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

