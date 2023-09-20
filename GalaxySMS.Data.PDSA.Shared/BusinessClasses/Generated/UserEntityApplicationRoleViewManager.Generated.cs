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
    /// This class should be used when you need to select data for the UserEntityApplicationRoleViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class UserEntityApplicationRoleViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the UserEntityApplicationRoleViewPDSAManager class
        /// </summary>
        public UserEntityApplicationRoleViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the UserEntityApplicationRoleViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public UserEntityApplicationRoleViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the UserEntityApplicationRoleViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public UserEntityApplicationRoleViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private UserEntityApplicationRoleViewPDSA _Entity = null;
        private UserEntityApplicationRoleViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public UserEntityApplicationRoleViewPDSA Entity
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
        public UserEntityApplicationRoleViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new UserEntityApplicationRoleViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public UserEntityApplicationRoleViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public UserEntityApplicationRoleViewPDSAData DataObject { get; set; }
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
                Entity = new UserEntityApplicationRoleViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new UserEntityApplicationRoleViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new UserEntityApplicationRoleViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "UserEntityApplicationRoleViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public UserEntityApplicationRoleViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            UserEntityApplicationRoleViewPDSA ret = new UserEntityApplicationRoleViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.UserName))
                ret.UserName = PDSAString.ConvertToStringTrim(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.UserName]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.EntityName))
                ret.EntityName = PDSAString.ConvertToStringTrim(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.EntityName]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.ApplicationName))
                ret.ApplicationName = PDSAString.ConvertToStringTrim(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.ApplicationName]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.RoleName))
                ret.RoleName = PDSAString.ConvertToStringTrim(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.RoleName]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.UserEntityApplicationRoleId))
                ret.UserEntityApplicationRoleId = PDSAProperty.ConvertToGuid(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.UserEntityApplicationRoleId]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.EntityApplicationRoleId))
                ret.EntityApplicationRoleId = PDSAProperty.ConvertToGuid(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.EntityApplicationRoleId]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.UserId))
                ret.UserId = PDSAProperty.ConvertToGuid(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.UserId]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.ApplicationId))
                ret.ApplicationId = PDSAProperty.ConvertToGuid(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.ApplicationId]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.RoleId))
                ret.RoleId = PDSAProperty.ConvertToGuid(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.RoleId]);

            if (values.ContainsKey(UserEntityApplicationRoleViewPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[UserEntityApplicationRoleViewPDSAValidator.ColumnNames.EntityId]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of UserEntityApplicationRoleViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>UserEntityApplicationRoleViewPDSACollection</returns>
        public UserEntityApplicationRoleViewPDSACollection BuildCollection()
        {
            UserEntityApplicationRoleViewPDSACollection coll = new UserEntityApplicationRoleViewPDSACollection();
            UserEntityApplicationRoleViewPDSA entity = null;
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
                //                System.Diagnostics.Debug.WriteLine(ex.Message);
                //var innerEx = ex.InnerException;
                //while (innerEx != null)
                //{
                //    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                //    innerEx = innerEx.InnerException;
                //}
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of UserEntityApplicationRoleViewPDSA objects</returns>
        public UserEntityApplicationRoleViewPDSACollection BuildCollection(DataSet ds)
        {
            UserEntityApplicationRoleViewPDSACollection coll = new UserEntityApplicationRoleViewPDSACollection();

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
        /// <returns>A collection of UserEntityApplicationRoleViewPDSA objects</returns>
        public UserEntityApplicationRoleViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of UserEntityApplicationRoleViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(UserEntityApplicationRoleViewPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = UserEntityApplicationRoleViewPDSAData.SelectFilters.Search;

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
        /// UserEntityApplicationRoleViewPDSA.SearchEntity = mgr.InitSearchFilter(UserEntityApplicationRoleViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A UserEntityApplicationRoleViewPDSA object</param>
        /// <returns>An UserEntityApplicationRoleViewPDSA object</returns>
        public UserEntityApplicationRoleViewPDSA InitSearchFilter(UserEntityApplicationRoleViewPDSA searchEntity)
        {
            searchEntity.UserName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = UserEntityApplicationRoleViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current UserEntityApplicationRoleViewPDSA
        /// </summary>
        /// <returns>A cloned UserEntityApplicationRoleViewPDSA object</returns>
        public UserEntityApplicationRoleViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in UserEntityApplicationRoleViewPDSA
        /// </summary>
        /// <param name="entityToClone">The UserEntityApplicationRoleViewPDSA entity to clone</param>
        /// <returns>A cloned UserEntityApplicationRoleViewPDSA object</returns>
        public UserEntityApplicationRoleViewPDSA CloneEntity(UserEntityApplicationRoleViewPDSA entityToClone)
        {
            UserEntityApplicationRoleViewPDSA newEntity = new UserEntityApplicationRoleViewPDSA();

            newEntity.UserName = entityToClone.UserName;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.ApplicationName = entityToClone.ApplicationName;
            newEntity.RoleName = entityToClone.RoleName;
            newEntity.UserEntityApplicationRoleId = entityToClone.UserEntityApplicationRoleId;
            newEntity.EntityApplicationRoleId = entityToClone.EntityApplicationRoleId;
            newEntity.UserId = entityToClone.UserId;
            newEntity.ApplicationId = entityToClone.ApplicationId;
            newEntity.RoleId = entityToClone.RoleId;
            newEntity.EntityId = entityToClone.EntityId;

            return newEntity;
        }
        #endregion
    }
}
