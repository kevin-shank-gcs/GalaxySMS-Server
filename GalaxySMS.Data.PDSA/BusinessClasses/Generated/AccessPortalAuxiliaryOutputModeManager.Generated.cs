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
    /// This class is used when you need to add, edit, delete, select and validate data for the AccessPortalAuxiliaryOutputModePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AccessPortalAuxiliaryOutputModePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AccessPortalAuxiliaryOutputModePDSAManager class
        /// </summary>
        public AccessPortalAuxiliaryOutputModePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalAuxiliaryOutputModePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AccessPortalAuxiliaryOutputModePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AccessPortalAuxiliaryOutputModePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AccessPortalAuxiliaryOutputModePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AccessPortalAuxiliaryOutputModePDSA _Entity = null;
        private AccessPortalAuxiliaryOutputModePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AccessPortalAuxiliaryOutputModePDSA Entity
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
        public AccessPortalAuxiliaryOutputModePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AccessPortalAuxiliaryOutputModePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AccessPortalAuxiliaryOutputModePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AccessPortalAuxiliaryOutputModePDSAData DataObject { get; set; }
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
                Entity = new AccessPortalAuxiliaryOutputModePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AccessPortalAuxiliaryOutputModePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AccessPortalAuxiliaryOutputModePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AccessPortalAuxiliaryOutputModePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AccessPortalAuxiliaryOutputModePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AccessPortalAuxiliaryOutputModePDSA ret = new AccessPortalAuxiliaryOutputModePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid))
                ret.AccessPortalAuxiliaryOutputModeUid = PDSAProperty.ConvertToGuid(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.AccessPortalAuxiliaryOutputModeUid]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code))
                ret.Code = Convert.ToInt16(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.Code]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder))
                ret.DisplayOrder = Convert.ToInt32(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.DisplayOrder]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault))
                ret.IsDefault = Convert.ToBoolean(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsDefault]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[AccessPortalAuxiliaryOutputModePDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AccessPortalAuxiliaryOutputModePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AccessPortalAuxiliaryOutputModePDSACollection</returns>
        public AccessPortalAuxiliaryOutputModePDSACollection BuildCollection()
        {
            AccessPortalAuxiliaryOutputModePDSACollection coll = new AccessPortalAuxiliaryOutputModePDSACollection();
            AccessPortalAuxiliaryOutputModePDSA entity = null;
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
        /// <returns>A collection of AccessPortalAuxiliaryOutputModePDSA objects</returns>
        public AccessPortalAuxiliaryOutputModePDSACollection BuildCollection(DataSet ds)
        {
            AccessPortalAuxiliaryOutputModePDSACollection coll = new AccessPortalAuxiliaryOutputModePDSACollection();

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
        /// <returns>A collection of AccessPortalAuxiliaryOutputModePDSA objects</returns>
        public AccessPortalAuxiliaryOutputModePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AccessPortalAuxiliaryOutputModePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AccessPortalAuxiliaryOutputModePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AccessPortalAuxiliaryOutputModePDSAData.SelectFilters.Search;

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
        /// AccessPortalAuxiliaryOutputModePDSA.SearchEntity = mgr.InitSearchFilter(AccessPortalAuxiliaryOutputModePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AccessPortalAuxiliaryOutputModePDSA object</param>
        /// <returns>An AccessPortalAuxiliaryOutputModePDSA object</returns>
        public AccessPortalAuxiliaryOutputModePDSA InitSearchFilter(AccessPortalAuxiliaryOutputModePDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AccessPortalAuxiliaryOutputModePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AccessPortalAuxiliaryOutputMode table
        /// </summary>
        /// <param name="entity">An AccessPortalAuxiliaryOutputModePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AccessPortalAuxiliaryOutputModePDSA entity)
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
        /// Updates an entity in the GCS.AccessPortalAuxiliaryOutputMode table
        /// </summary>
        /// <param name="entity">An AccessPortalAuxiliaryOutputModePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AccessPortalAuxiliaryOutputModePDSA entity)
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
        /// Deletes an entity from the GCS.AccessPortalAuxiliaryOutputMode table
        /// </summary>
        /// <param name="entity">An AccessPortalAuxiliaryOutputModePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AccessPortalAuxiliaryOutputModePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AccessPortalAuxiliaryOutputModeUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

