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
    /// This class is used when you need to add, edit, delete, select and validate data for the AccessPortalNoServerReplyBehaviorPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortalNoServerReplyBehaviorPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortalNoServerReplyBehaviorPDSAManager class
        /// </summary>
        public AccessPortalNoServerReplyBehaviorPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalNoServerReplyBehaviorPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortalNoServerReplyBehaviorPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalNoServerReplyBehaviorPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortalNoServerReplyBehaviorPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortalNoServerReplyBehaviorPDSA _Entity = null;
        private AccessPortalNoServerReplyBehaviorPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortalNoServerReplyBehaviorPDSA Entity
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
        public AccessPortalNoServerReplyBehaviorPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortalNoServerReplyBehaviorPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortalNoServerReplyBehaviorPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortalNoServerReplyBehaviorPDSAData DataObject { get; set; }
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
                Entity = new AccessPortalNoServerReplyBehaviorPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortalNoServerReplyBehaviorPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortalNoServerReplyBehaviorPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessPortalNoServerReplyBehaviorPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortalNoServerReplyBehaviorPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortalNoServerReplyBehaviorPDSA ret = new AccessPortalNoServerReplyBehaviorPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.AccessPortalNoServerReplyBehaviorUid))
                ret.AccessPortalNoServerReplyBehaviorUid = PDSAProperty.ConvertToGuid(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.AccessPortalNoServerReplyBehaviorUid]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.Code))
                ret.Code = Convert.ToInt16(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.Code]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.DisplayOrder))
                ret.DisplayOrder = Convert.ToInt32(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.DisplayOrder]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.IsDefault))
                ret.IsDefault = Convert.ToBoolean(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.IsDefault]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[AccessPortalNoServerReplyBehaviorPDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortalNoServerReplyBehaviorPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortalNoServerReplyBehaviorPDSACollection</returns>
        public AccessPortalNoServerReplyBehaviorPDSACollection BuildCollection()
        {
            AccessPortalNoServerReplyBehaviorPDSACollection coll = new AccessPortalNoServerReplyBehaviorPDSACollection();
            AccessPortalNoServerReplyBehaviorPDSA entity = null;
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
        /// <returns>A collection of AccessPortalNoServerReplyBehaviorPDSA objects</returns>
        public AccessPortalNoServerReplyBehaviorPDSACollection BuildCollection(DataSet ds)
        {
            AccessPortalNoServerReplyBehaviorPDSACollection coll = new AccessPortalNoServerReplyBehaviorPDSACollection();

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
        /// <returns>A collection of AccessPortalNoServerReplyBehaviorPDSA objects</returns>
        public AccessPortalNoServerReplyBehaviorPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortalNoServerReplyBehaviorPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortalNoServerReplyBehaviorPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortalNoServerReplyBehaviorPDSAData.SelectFilters.Search;

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
        /// AccessPortalNoServerReplyBehaviorPDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalNoServerReplyBehaviorPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortalNoServerReplyBehaviorPDSA object</param>
        /// <returns>An AccessPortalNoServerReplyBehaviorPDSA object</returns>
        public AccessPortalNoServerReplyBehaviorPDSA InitSearchFilter(AccessPortalNoServerReplyBehaviorPDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortalNoServerReplyBehaviorPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AccessPortalNoServerReplyBehavior table
        /// </summary>
        /// <param name="entity">An AccessPortalNoServerReplyBehaviorPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AccessPortalNoServerReplyBehaviorPDSA entity)
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
        /// Updates an entity in the GCS.AccessPortalNoServerReplyBehavior table
        /// </summary>
        /// <param name="entity">An AccessPortalNoServerReplyBehaviorPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AccessPortalNoServerReplyBehaviorPDSA entity)
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
        /// Deletes an entity from the GCS.AccessPortalNoServerReplyBehavior table
        /// </summary>
        /// <param name="entity">An AccessPortalNoServerReplyBehaviorPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AccessPortalNoServerReplyBehaviorPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AccessPortalNoServerReplyBehaviorUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

