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
    /// This class is used when you need to add, edit, delete, select and validate data for the PersonalAccessGroupAccessPortalPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class PersonalAccessGroupAccessPortalPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the PersonalAccessGroupAccessPortalPDSAManager class
        /// </summary>
        public PersonalAccessGroupAccessPortalPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the PersonalAccessGroupAccessPortalPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public PersonalAccessGroupAccessPortalPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the PersonalAccessGroupAccessPortalPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public PersonalAccessGroupAccessPortalPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private PersonalAccessGroupAccessPortalPDSA _Entity = null;
        private PersonalAccessGroupAccessPortalPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public PersonalAccessGroupAccessPortalPDSA Entity
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
        public PersonalAccessGroupAccessPortalPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new PersonalAccessGroupAccessPortalPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public PersonalAccessGroupAccessPortalPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public PersonalAccessGroupAccessPortalPDSAData DataObject { get; set; }
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
                Entity = new PersonalAccessGroupAccessPortalPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new PersonalAccessGroupAccessPortalPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new PersonalAccessGroupAccessPortalPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "PersonalAccessGroupAccessPortalPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public PersonalAccessGroupAccessPortalPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            PersonalAccessGroupAccessPortalPDSA ret = new PersonalAccessGroupAccessPortalPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid))
                ret.PersonalAccessGroupAccessPortalUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonalAccessGroupAccessPortalUid]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.AccessPortalUid))
                ret.AccessPortalUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.AccessPortalUid]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonClusterPermissionUid))
                ret.PersonClusterPermissionUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonClusterPermissionUid]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonCredentialUid))
                ret.PersonCredentialUid = PDSAProperty.ConvertToGuid(values[PersonalAccessGroupAccessPortalPDSAValidator.ColumnNames.PersonCredentialUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of PersonalAccessGroupAccessPortalPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>PersonalAccessGroupAccessPortalPDSACollection</returns>
        public PersonalAccessGroupAccessPortalPDSACollection BuildCollection()
        {
            PersonalAccessGroupAccessPortalPDSACollection coll = new PersonalAccessGroupAccessPortalPDSACollection();
            PersonalAccessGroupAccessPortalPDSA entity = null;
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
        /// <returns>A collection of PersonalAccessGroupAccessPortalPDSA objects</returns>
        public PersonalAccessGroupAccessPortalPDSACollection BuildCollection(DataSet ds)
        {
            PersonalAccessGroupAccessPortalPDSACollection coll = new PersonalAccessGroupAccessPortalPDSACollection();

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
        /// <returns>A collection of PersonalAccessGroupAccessPortalPDSA objects</returns>
        public PersonalAccessGroupAccessPortalPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of PersonalAccessGroupAccessPortalPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(PersonalAccessGroupAccessPortalPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = PersonalAccessGroupAccessPortalPDSAData.SelectFilters.Search;

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
        /// PersonalAccessGroupAccessPortalPDSA.SearchEntity = mgr.InitSearchFilter(PersonalAccessGroupAccessPortalPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A PersonalAccessGroupAccessPortalPDSA object</param>
        /// <returns>An PersonalAccessGroupAccessPortalPDSA object</returns>
        public PersonalAccessGroupAccessPortalPDSA InitSearchFilter(PersonalAccessGroupAccessPortalPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = PersonalAccessGroupAccessPortalPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.PersonalAccessGroupAccessPortal table
        /// </summary>
        /// <param name="entity">An PersonalAccessGroupAccessPortalPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(PersonalAccessGroupAccessPortalPDSA entity)
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
        /// Updates an entity in the GCS.PersonalAccessGroupAccessPortal table
        /// </summary>
        /// <param name="entity">An PersonalAccessGroupAccessPortalPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(PersonalAccessGroupAccessPortalPDSA entity)
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
        /// Deletes an entity from the GCS.PersonalAccessGroupAccessPortal table
        /// </summary>
        /// <param name="entity">An PersonalAccessGroupAccessPortalPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(PersonalAccessGroupAccessPortalPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.PersonalAccessGroupAccessPortalUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetPersonalAccessGroupAccessPortalPDSAsByFK_PesonalAccessGroupAccessPortalAccessPortalEntity Method
        public PersonalAccessGroupAccessPortalPDSACollection GetPersonalAccessGroupAccessPortalPDSAsByFK_PesonalAccessGroupAccessPortalAccessPortalEntity(AccessPortalPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = PersonalAccessGroupAccessPortalPDSAData.SelectFilters.ByAccessPortalUid;
                    }
                    else
                    {
                    }

                    Entity.AccessPortalUid = entity.AccessPortalUid;
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
                return new PersonalAccessGroupAccessPortalPDSACollection();
        }
        #endregion

        #region GetPersonalAccessGroupAccessPortalPDSAsByFK_PesonalAccessGroupAccessPortalAccessPortal Method
        public PersonalAccessGroupAccessPortalPDSACollection GetPersonalAccessGroupAccessPortalPDSAsByFK_PesonalAccessGroupAccessPortalAccessPortal(Guid accessPortalUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = PersonalAccessGroupAccessPortalPDSAData.SelectFilters.ByAccessPortalUid;
                }
                else
                {
                }

                Entity.AccessPortalUid = accessPortalUid;
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

