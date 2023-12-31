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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsUserRequirementsPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsUserRequirementsPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsUserRequirementsPDSAManager class
        /// </summary>
        public gcsUserRequirementsPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsUserRequirementsPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsUserRequirementsPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsUserRequirementsPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsUserRequirementsPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsUserRequirementsPDSA _Entity = null;
        private gcsUserRequirementsPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsUserRequirementsPDSA Entity
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
        public gcsUserRequirementsPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsUserRequirementsPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsUserRequirementsPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsUserRequirementsPDSAData DataObject { get; set; }
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
                Entity = new gcsUserRequirementsPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsUserRequirementsPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsUserRequirementsPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsUserRequirementsPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsUserRequirementsPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsUserRequirementsPDSA ret = new gcsUserRequirementsPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.UserRequirementsId))
                ret.UserRequirementsId = PDSAProperty.ConvertToGuid(values[gcsUserRequirementsPDSAValidator.ColumnNames.UserRequirementsId]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[gcsUserRequirementsPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.PasswordCannotContainName))
                ret.PasswordCannotContainName = Convert.ToBoolean(values[gcsUserRequirementsPDSAValidator.ColumnNames.PasswordCannotContainName]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.PasswordMinimumLength))
                ret.PasswordMinimumLength = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.PasswordMinimumLength]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.PasswordMaximumLength))
                ret.PasswordMaximumLength = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.PasswordMaximumLength]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.PasswordMinimumChangeCharacters))
                ret.PasswordMinimumChangeCharacters = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.PasswordMinimumChangeCharacters]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.MinimumPasswordAge))
                ret.MinimumPasswordAge = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.MinimumPasswordAge]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.MaximumPasswordAge))
                ret.MaximumPasswordAge = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.MaximumPasswordAge]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.MaintainPasswordHistoryCount))
                ret.MaintainPasswordHistoryCount = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.MaintainPasswordHistoryCount]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.DefaultExpirationDays))
                ret.DefaultExpirationDays = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.DefaultExpirationDays]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.LockoutUserIfInactiveForDays))
                ret.LockoutUserIfInactiveForDays = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.LockoutUserIfInactiveForDays]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.AllowPasswordChangeAttempt))
                ret.AllowPasswordChangeAttempt = Convert.ToBoolean(values[gcsUserRequirementsPDSAValidator.ColumnNames.AllowPasswordChangeAttempt]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.RequireLowerCaseLetterCount))
                ret.RequireLowerCaseLetterCount = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.RequireLowerCaseLetterCount]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.RequireUpperCaseLetterCount))
                ret.RequireUpperCaseLetterCount = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.RequireUpperCaseLetterCount]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.RequireNumericDigitCount))
                ret.RequireNumericDigitCount = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.RequireNumericDigitCount]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.RequireSpecialCharacterCount))
                ret.RequireSpecialCharacterCount = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.RequireSpecialCharacterCount]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.UseCustomRegEx))
                ret.UseCustomRegEx = Convert.ToBoolean(values[gcsUserRequirementsPDSAValidator.ColumnNames.UseCustomRegEx]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.PasswordCustomRegEx))
                ret.PasswordCustomRegEx = PDSAString.ConvertToStringTrim(values[gcsUserRequirementsPDSAValidator.ColumnNames.PasswordCustomRegEx]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.RegularExpressionDescription))
                ret.RegularExpressionDescription = PDSAString.ConvertToStringTrim(values[gcsUserRequirementsPDSAValidator.ColumnNames.RegularExpressionDescription]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsUserRequirementsPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsUserRequirementsPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsUserRequirementsPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[gcsUserRequirementsPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsUserRequirementsPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(gcsUserRequirementsPDSAValidator.ColumnNames.RequireTwoFactorAuthentication))
                ret.RequireTwoFactorAuthentication = Convert.ToBoolean(values[gcsUserRequirementsPDSAValidator.ColumnNames.RequireTwoFactorAuthentication]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsUserRequirementsPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsUserRequirementsPDSACollection</returns>
        public gcsUserRequirementsPDSACollection BuildCollection()
        {
            gcsUserRequirementsPDSACollection coll = new gcsUserRequirementsPDSACollection();
            gcsUserRequirementsPDSA entity = null;
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
        /// <returns>A collection of gcsUserRequirementsPDSA objects</returns>
        public gcsUserRequirementsPDSACollection BuildCollection(DataSet ds)
        {
            gcsUserRequirementsPDSACollection coll = new gcsUserRequirementsPDSACollection();

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
        /// <returns>A collection of gcsUserRequirementsPDSA objects</returns>
        public gcsUserRequirementsPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsUserRequirementsPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsUserRequirementsPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsUserRequirementsPDSAData.SelectFilters.Search;

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
        /// gcsUserRequirementsPDSA.SearchEntity = mgr.InitSearchFilter(gcsUserRequirementsPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsUserRequirementsPDSA object</param>
        /// <returns>An gcsUserRequirementsPDSA object</returns>
        public gcsUserRequirementsPDSA InitSearchFilter(gcsUserRequirementsPDSA searchEntity)
        {
            searchEntity.PasswordCustomRegEx = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsUserRequirementsPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsUserRequirements table
        /// </summary>
        /// <param name="entity">An gcsUserRequirementsPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsUserRequirementsPDSA entity)
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
        /// Updates an entity in the GCS.gcsUserRequirements table
        /// </summary>
        /// <param name="entity">An gcsUserRequirementsPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsUserRequirementsPDSA entity)
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
        /// Deletes an entity from the GCS.gcsUserRequirements table
        /// </summary>
        /// <param name="entity">An gcsUserRequirementsPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsUserRequirementsPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.UserRequirementsId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetgcsUserRequirementsPDSAsByFK_UserRequirementsEntityEntity Method
        public gcsUserRequirementsPDSACollection GetgcsUserRequirementsPDSAsByFK_UserRequirementsEntityEntity(gcsEntityPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsUserRequirementsPDSAData.SelectFilters.ByEntityId;
                    }
                    else
                    {
                    }

                    Entity.EntityId = entity.EntityId;
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
                return new gcsUserRequirementsPDSACollection();
        }
        #endregion

        #region GetgcsUserRequirementsPDSAsByFK_UserRequirementsEntity Method
        public gcsUserRequirementsPDSACollection GetgcsUserRequirementsPDSAsByFK_UserRequirementsEntity(Guid entityId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsUserRequirementsPDSAData.SelectFilters.ByEntityId;
                }
                else
                {
                }

                Entity.EntityId = entityId;
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

