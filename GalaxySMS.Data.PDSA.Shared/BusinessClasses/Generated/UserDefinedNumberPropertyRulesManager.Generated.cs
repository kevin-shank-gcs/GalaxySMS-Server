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
    /// This class is used when you need to add, edit, delete, select and validate data for the UserDefinedNumberPropertyRulesPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class UserDefinedNumberPropertyRulesPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the UserDefinedNumberPropertyRulesPDSAManager class
        /// </summary>
        public UserDefinedNumberPropertyRulesPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the UserDefinedNumberPropertyRulesPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public UserDefinedNumberPropertyRulesPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the UserDefinedNumberPropertyRulesPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public UserDefinedNumberPropertyRulesPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private UserDefinedNumberPropertyRulesPDSA _Entity = null;
        private UserDefinedNumberPropertyRulesPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public UserDefinedNumberPropertyRulesPDSA Entity
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
        public UserDefinedNumberPropertyRulesPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new UserDefinedNumberPropertyRulesPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public UserDefinedNumberPropertyRulesPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public UserDefinedNumberPropertyRulesPDSAData DataObject { get; set; }
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
                Entity = new UserDefinedNumberPropertyRulesPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new UserDefinedNumberPropertyRulesPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new UserDefinedNumberPropertyRulesPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "UserDefinedNumberPropertyRulesPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public UserDefinedNumberPropertyRulesPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            UserDefinedNumberPropertyRulesPDSA ret = new UserDefinedNumberPropertyRulesPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid))
                ret.UserDefinedPropertyUid = PDSAProperty.ConvertToGuid(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.IsRequired))
                ret.IsRequired = Convert.ToBoolean(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.IsRequired]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.MinimumValue))
                ret.MinimumValue = Convert.ToInt64(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.MinimumValue]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.MaximumValue))
                ret.MaximumValue = Convert.ToInt64(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.MaximumValue]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx))
                ret.ValidationRegEx = PDSAString.ConvertToStringTrim(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.DefaultValue))
                ret.DefaultValue = Convert.ToInt32(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.DefaultValue]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.EmptyContent))
                ret.EmptyContent = PDSAString.ConvertToStringTrim(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.EmptyContent]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage))
                ret.ValidationErrorMessage = PDSAString.ConvertToStringTrim(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[UserDefinedNumberPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of UserDefinedNumberPropertyRulesPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>UserDefinedNumberPropertyRulesPDSACollection</returns>
        public UserDefinedNumberPropertyRulesPDSACollection BuildCollection()
        {
            UserDefinedNumberPropertyRulesPDSACollection coll = new UserDefinedNumberPropertyRulesPDSACollection();
            UserDefinedNumberPropertyRulesPDSA entity = null;
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
            }

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of UserDefinedNumberPropertyRulesPDSA objects</returns>
        public UserDefinedNumberPropertyRulesPDSACollection BuildCollection(DataSet ds)
        {
            UserDefinedNumberPropertyRulesPDSACollection coll = new UserDefinedNumberPropertyRulesPDSACollection();

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
        /// <returns>A collection of UserDefinedNumberPropertyRulesPDSA objects</returns>
        public UserDefinedNumberPropertyRulesPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of UserDefinedNumberPropertyRulesPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(UserDefinedNumberPropertyRulesPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = UserDefinedNumberPropertyRulesPDSAData.SelectFilters.Search;

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
        /// UserDefinedNumberPropertyRulesPDSA.SearchEntity = mgr.InitSearchFilter(UserDefinedNumberPropertyRulesPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A UserDefinedNumberPropertyRulesPDSA object</param>
        /// <returns>An UserDefinedNumberPropertyRulesPDSA object</returns>
        public UserDefinedNumberPropertyRulesPDSA InitSearchFilter(UserDefinedNumberPropertyRulesPDSA searchEntity)
        {
            searchEntity.ValidationRegEx = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = UserDefinedNumberPropertyRulesPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.UserDefinedNumberPropertyRules table
        /// </summary>
        /// <param name="entity">An UserDefinedNumberPropertyRulesPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(UserDefinedNumberPropertyRulesPDSA entity)
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
        /// Updates an entity in the GCS.UserDefinedNumberPropertyRules table
        /// </summary>
        /// <param name="entity">An UserDefinedNumberPropertyRulesPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(UserDefinedNumberPropertyRulesPDSA entity)
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
        /// Deletes an entity from the GCS.UserDefinedNumberPropertyRules table
        /// </summary>
        /// <param name="entity">An UserDefinedNumberPropertyRulesPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(UserDefinedNumberPropertyRulesPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.UserDefinedPropertyUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetUserDefinedNumberPropertyRulesPDSAsByFK_UserDefinedNumberPropertyRulesUserDefinedPropertyEntity Method
        public UserDefinedNumberPropertyRulesPDSACollection GetUserDefinedNumberPropertyRulesPDSAsByFK_UserDefinedNumberPropertyRulesUserDefinedPropertyEntity(UserDefinedPropertyPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = UserDefinedNumberPropertyRulesPDSAData.SelectFilters.ByUserDefinedPropertyUid;
                    }
                    else
                    {
                    }

                    Entity.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
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
                }

                return BuildCollection();
            }
            else
                return new UserDefinedNumberPropertyRulesPDSACollection();
        }
        #endregion

        #region GetUserDefinedNumberPropertyRulesPDSAsByFK_UserDefinedNumberPropertyRulesUserDefinedProperty Method
        public UserDefinedNumberPropertyRulesPDSACollection GetUserDefinedNumberPropertyRulesPDSAsByFK_UserDefinedNumberPropertyRulesUserDefinedProperty(Guid userDefinedPropertyUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = UserDefinedNumberPropertyRulesPDSAData.SelectFilters.ByUserDefinedPropertyUid;
                }
                else
                {
                }

                Entity.UserDefinedPropertyUid = userDefinedPropertyUid;
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
            }

            return BuildCollection();
        }
        #endregion

    }
}

