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
    /// This class is used when you need to add, edit, delete, select and validate data for the PersonLcdMessagePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class PersonLcdMessagePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the PersonLcdMessagePDSAManager class
        /// </summary>
        public PersonLcdMessagePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the PersonLcdMessagePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public PersonLcdMessagePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the PersonLcdMessagePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public PersonLcdMessagePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private PersonLcdMessagePDSA _Entity = null;
        private PersonLcdMessagePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public PersonLcdMessagePDSA Entity
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
        public PersonLcdMessagePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new PersonLcdMessagePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public PersonLcdMessagePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public PersonLcdMessagePDSAData DataObject { get; set; }
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
                Entity = new PersonLcdMessagePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new PersonLcdMessagePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new PersonLcdMessagePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "PersonLcdMessagePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public PersonLcdMessagePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            PersonLcdMessagePDSA ret = new PersonLcdMessagePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.PersonLcdMessageUid))
                ret.PersonLcdMessageUid = PDSAProperty.ConvertToGuid(values[PersonLcdMessagePDSAValidator.ColumnNames.PersonLcdMessageUid]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.PersonLcdMessageDisplayModeUid))
                ret.PersonLcdMessageDisplayModeUid = PDSAProperty.ConvertToGuid(values[PersonLcdMessagePDSAValidator.ColumnNames.PersonLcdMessageDisplayModeUid]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[PersonLcdMessagePDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.Message))
                ret.Message = PDSAString.ConvertToStringTrim(values[PersonLcdMessagePDSAValidator.ColumnNames.Message]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.StartingDate))
                ret.StartingDate = Convert.ToDateTime(values[PersonLcdMessagePDSAValidator.ColumnNames.StartingDate]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.EndingDate))
                ret.EndingDate = Convert.ToDateTime(values[PersonLcdMessagePDSAValidator.ColumnNames.EndingDate]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[PersonLcdMessagePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[PersonLcdMessagePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[PersonLcdMessagePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[PersonLcdMessagePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(PersonLcdMessagePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[PersonLcdMessagePDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of PersonLcdMessagePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>PersonLcdMessagePDSACollection</returns>
        public PersonLcdMessagePDSACollection BuildCollection()
        {
            PersonLcdMessagePDSACollection coll = new PersonLcdMessagePDSACollection();
            PersonLcdMessagePDSA entity = null;
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
        /// <returns>A collection of PersonLcdMessagePDSA objects</returns>
        public PersonLcdMessagePDSACollection BuildCollection(DataSet ds)
        {
            PersonLcdMessagePDSACollection coll = new PersonLcdMessagePDSACollection();

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
        /// <returns>A collection of PersonLcdMessagePDSA objects</returns>
        public PersonLcdMessagePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of PersonLcdMessagePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(PersonLcdMessagePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = PersonLcdMessagePDSAData.SelectFilters.Search;

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
        /// PersonLcdMessagePDSA.SearchEntity = mgr.InitSearchFilter(PersonLcdMessagePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A PersonLcdMessagePDSA object</param>
        /// <returns>An PersonLcdMessagePDSA object</returns>
        public PersonLcdMessagePDSA InitSearchFilter(PersonLcdMessagePDSA searchEntity)
        {
            searchEntity.Message = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = PersonLcdMessagePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.PersonLcdMessage table
        /// </summary>
        /// <param name="entity">An PersonLcdMessagePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(PersonLcdMessagePDSA entity)
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
        /// Updates an entity in the GCS.PersonLcdMessage table
        /// </summary>
        /// <param name="entity">An PersonLcdMessagePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(PersonLcdMessagePDSA entity)
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
        /// Deletes an entity from the GCS.PersonLcdMessage table
        /// </summary>
        /// <param name="entity">An PersonLcdMessagePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(PersonLcdMessagePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.PersonLcdMessageUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetPersonLcdMessagePDSAsByFK_PersonLcdMessagePersonEntity Method
        public PersonLcdMessagePDSACollection GetPersonLcdMessagePDSAsByFK_PersonLcdMessagePersonEntity(PersonPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = PersonLcdMessagePDSAData.SelectFilters.ByPersonUid;
                    }
                    else
                    {
                    }

                    Entity.PersonUid = entity.PersonUid;
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
                return new PersonLcdMessagePDSACollection();
        }
        #endregion

        #region GetPersonLcdMessagePDSAsByFK_PersonLcdMessagePerson Method
        public PersonLcdMessagePDSACollection GetPersonLcdMessagePDSAsByFK_PersonLcdMessagePerson(Guid personUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = PersonLcdMessagePDSAData.SelectFilters.ByPersonUid;
                }
                else
                {
                }

                Entity.PersonUid = personUid;
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

