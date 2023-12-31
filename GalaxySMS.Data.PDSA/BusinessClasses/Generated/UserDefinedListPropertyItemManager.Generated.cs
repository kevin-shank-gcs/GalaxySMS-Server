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
    /// This class is used when you need to add, edit, delete, select and validate data for the UserDefinedListPropertyItemPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class UserDefinedListPropertyItemPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the UserDefinedListPropertyItemPDSAManager class
        /// </summary>
        public UserDefinedListPropertyItemPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the UserDefinedListPropertyItemPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public UserDefinedListPropertyItemPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the UserDefinedListPropertyItemPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public UserDefinedListPropertyItemPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private UserDefinedListPropertyItemPDSA _Entity = null;
        private UserDefinedListPropertyItemPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public UserDefinedListPropertyItemPDSA Entity
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
        public UserDefinedListPropertyItemPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new UserDefinedListPropertyItemPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public UserDefinedListPropertyItemPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public UserDefinedListPropertyItemPDSAData DataObject { get; set; }
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
                Entity = new UserDefinedListPropertyItemPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new UserDefinedListPropertyItemPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new UserDefinedListPropertyItemPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "UserDefinedListPropertyItemPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public UserDefinedListPropertyItemPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            UserDefinedListPropertyItemPDSA ret = new UserDefinedListPropertyItemPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.UserDefinedListPropertyItemUid))
                ret.UserDefinedListPropertyItemUid = PDSAProperty.ConvertToGuid(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.UserDefinedListPropertyItemUid]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.UserDefinedPropertyUid))
                ret.UserDefinedPropertyUid = PDSAProperty.ConvertToGuid(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.UserDefinedPropertyUid]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.ItemValue))
                ret.ItemValue = PDSAString.ConvertToStringTrim(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.ItemValue]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.DisplayOrder))
                ret.DisplayOrder = Convert.ToInt16(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.DisplayOrder]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.ItemImage))
                ret.ItemImage = PDSAProperty.ConvertToByteArray(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.ItemImage]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(UserDefinedListPropertyItemPDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[UserDefinedListPropertyItemPDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of UserDefinedListPropertyItemPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>UserDefinedListPropertyItemPDSACollection</returns>
        public UserDefinedListPropertyItemPDSACollection BuildCollection()
        {
            UserDefinedListPropertyItemPDSACollection coll = new UserDefinedListPropertyItemPDSACollection();
            UserDefinedListPropertyItemPDSA entity = null;
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
        /// <returns>A collection of UserDefinedListPropertyItemPDSA objects</returns>
        public UserDefinedListPropertyItemPDSACollection BuildCollection(DataSet ds)
        {
            UserDefinedListPropertyItemPDSACollection coll = new UserDefinedListPropertyItemPDSACollection();

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
        /// <returns>A collection of UserDefinedListPropertyItemPDSA objects</returns>
        public UserDefinedListPropertyItemPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of UserDefinedListPropertyItemPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(UserDefinedListPropertyItemPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = UserDefinedListPropertyItemPDSAData.SelectFilters.Search;

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
        /// UserDefinedListPropertyItemPDSA.SearchEntity = mgr.InitSearchFilter(UserDefinedListPropertyItemPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A UserDefinedListPropertyItemPDSA object</param>
        /// <returns>An UserDefinedListPropertyItemPDSA object</returns>
        public UserDefinedListPropertyItemPDSA InitSearchFilter(UserDefinedListPropertyItemPDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = UserDefinedListPropertyItemPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.UserDefinedListPropertyItem table
        /// </summary>
        /// <param name="entity">An UserDefinedListPropertyItemPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(UserDefinedListPropertyItemPDSA entity)
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
        /// Updates an entity in the GCS.UserDefinedListPropertyItem table
        /// </summary>
        /// <param name="entity">An UserDefinedListPropertyItemPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(UserDefinedListPropertyItemPDSA entity)
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
        /// Deletes an entity from the GCS.UserDefinedListPropertyItem table
        /// </summary>
        /// <param name="entity">An UserDefinedListPropertyItemPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(UserDefinedListPropertyItemPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.UserDefinedListPropertyItemUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetUserDefinedListPropertyItemPDSAsByFK_UserDefinedListPropertyItemUserDefinedPropertyEntity Method
        public UserDefinedListPropertyItemPDSACollection GetUserDefinedListPropertyItemPDSAsByFK_UserDefinedListPropertyItemUserDefinedPropertyEntity(UserDefinedPropertyPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = UserDefinedListPropertyItemPDSAData.SelectFilters.ByUserDefinedPropertyUid;
                    }
                    else
                    {
                    }

                    Entity.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
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
                return new UserDefinedListPropertyItemPDSACollection();
        }
        #endregion

        #region GetUserDefinedListPropertyItemPDSAsByFK_UserDefinedListPropertyItemUserDefinedProperty Method
        public UserDefinedListPropertyItemPDSACollection GetUserDefinedListPropertyItemPDSAsByFK_UserDefinedListPropertyItemUserDefinedProperty(Guid userDefinedPropertyUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = UserDefinedListPropertyItemPDSAData.SelectFilters.ByUserDefinedPropertyUid;
                }
                else
                {
                }

                Entity.UserDefinedPropertyUid = userDefinedPropertyUid;
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

