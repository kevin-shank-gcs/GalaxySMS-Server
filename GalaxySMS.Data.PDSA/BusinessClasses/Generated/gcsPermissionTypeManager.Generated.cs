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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsPermissionTypePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsPermissionTypePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsPermissionTypePDSAManager class
        /// </summary>
        public gcsPermissionTypePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsPermissionTypePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsPermissionTypePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsPermissionTypePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsPermissionTypePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsPermissionTypePDSA _Entity = null;
        private gcsPermissionTypePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsPermissionTypePDSA Entity
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
        public gcsPermissionTypePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsPermissionTypePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsPermissionTypePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsPermissionTypePDSAData DataObject { get; set; }
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
                Entity = new gcsPermissionTypePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsPermissionTypePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsPermissionTypePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsPermissionTypePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsPermissionTypePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsPermissionTypePDSA ret = new gcsPermissionTypePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.PermissionTypeId))
                ret.PermissionTypeId = PDSAProperty.ConvertToGuid(values[gcsPermissionTypePDSAValidator.ColumnNames.PermissionTypeId]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[gcsPermissionTypePDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[gcsPermissionTypePDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.PermissionTypeCode))
                ret.PermissionTypeCode = Convert.ToInt16(values[gcsPermissionTypePDSAValidator.ColumnNames.PermissionTypeCode]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[gcsPermissionTypePDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[gcsPermissionTypePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsPermissionTypePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[gcsPermissionTypePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsPermissionTypePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[gcsPermissionTypePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsPermissionTypePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(gcsPermissionTypePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[gcsPermissionTypePDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsPermissionTypePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsPermissionTypePDSACollection</returns>
        public gcsPermissionTypePDSACollection BuildCollection()
        {
            gcsPermissionTypePDSACollection coll = new gcsPermissionTypePDSACollection();
            gcsPermissionTypePDSA entity = null;
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
        /// <returns>A collection of gcsPermissionTypePDSA objects</returns>
        public gcsPermissionTypePDSACollection BuildCollection(DataSet ds)
        {
            gcsPermissionTypePDSACollection coll = new gcsPermissionTypePDSACollection();

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
        /// <returns>A collection of gcsPermissionTypePDSA objects</returns>
        public gcsPermissionTypePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsPermissionTypePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsPermissionTypePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsPermissionTypePDSAData.SelectFilters.Search;

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
        /// gcsPermissionTypePDSA.SearchEntity = mgr.InitSearchFilter(gcsPermissionTypePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsPermissionTypePDSA object</param>
        /// <returns>An gcsPermissionTypePDSA object</returns>
        public gcsPermissionTypePDSA InitSearchFilter(gcsPermissionTypePDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsPermissionTypePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsPermissionType table
        /// </summary>
        /// <param name="entity">An gcsPermissionTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsPermissionTypePDSA entity)
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
        /// Updates an entity in the GCS.gcsPermissionType table
        /// </summary>
        /// <param name="entity">An gcsPermissionTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsPermissionTypePDSA entity)
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
        /// Deletes an entity from the GCS.gcsPermissionType table
        /// </summary>
        /// <param name="entity">An gcsPermissionTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsPermissionTypePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.PermissionTypeId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetgcsPermissionTypePDSAsByFK_PermissionTypeDisplayResourceKeyEntity Method
        public gcsPermissionTypePDSACollection GetgcsPermissionTypePDSAsByFK_PermissionTypeDisplayResourceKeyEntity(gcsResourceStringPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsPermissionTypePDSAData.SelectFilters.ByDisplayResourceKey;
                    }
                    else
                    {
                    }

                    Entity.DisplayResourceKey = entity.ResourceId;
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

                return BuildCollection();
            }
            else
                return new gcsPermissionTypePDSACollection();
        }
        #endregion

        #region GetgcsPermissionTypePDSAsByFK_PermissionTypeDisplayResourceKey Method
        public gcsPermissionTypePDSACollection GetgcsPermissionTypePDSAsByFK_PermissionTypeDisplayResourceKey(Guid resourceId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsPermissionTypePDSAData.SelectFilters.ByDisplayResourceKey;
                }
                else
                {
                }

                Entity.DisplayResourceKey = resourceId;
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

