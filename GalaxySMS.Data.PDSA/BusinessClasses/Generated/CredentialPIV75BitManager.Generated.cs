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
    /// This class is used when you need to add, edit, delete, select and validate data for the CredentialPIV75BitPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class CredentialPIV75BitPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the CredentialPIV75BitPDSAManager class
        /// </summary>
        public CredentialPIV75BitPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialPIV75BitPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public CredentialPIV75BitPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialPIV75BitPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public CredentialPIV75BitPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private CredentialPIV75BitPDSA _Entity = null;
        private CredentialPIV75BitPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public CredentialPIV75BitPDSA Entity
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
        public CredentialPIV75BitPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new CredentialPIV75BitPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public CredentialPIV75BitPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public CredentialPIV75BitPDSAData DataObject { get; set; }
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
                Entity = new CredentialPIV75BitPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new CredentialPIV75BitPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new CredentialPIV75BitPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "CredentialPIV75BitPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public CredentialPIV75BitPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            CredentialPIV75BitPDSA ret = new CredentialPIV75BitPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid))
                ret.CredentialUid = PDSAProperty.ConvertToGuid(values[CredentialPIV75BitPDSAValidator.ColumnNames.CredentialUid]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode))
                ret.AgencyCode = Convert.ToInt32(values[CredentialPIV75BitPDSAValidator.ColumnNames.AgencyCode]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode))
                ret.SiteCode = Convert.ToInt32(values[CredentialPIV75BitPDSAValidator.ColumnNames.SiteCode]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode))
                ret.CredentialCode = Convert.ToInt32(values[CredentialPIV75BitPDSAValidator.ColumnNames.CredentialCode]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[CredentialPIV75BitPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialPIV75BitPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[CredentialPIV75BitPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialPIV75BitPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[CredentialPIV75BitPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of CredentialPIV75BitPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>CredentialPIV75BitPDSACollection</returns>
        public CredentialPIV75BitPDSACollection BuildCollection()
        {
            CredentialPIV75BitPDSACollection coll = new CredentialPIV75BitPDSACollection();
            CredentialPIV75BitPDSA entity = null;
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
        /// <returns>A collection of CredentialPIV75BitPDSA objects</returns>
        public CredentialPIV75BitPDSACollection BuildCollection(DataSet ds)
        {
            CredentialPIV75BitPDSACollection coll = new CredentialPIV75BitPDSACollection();

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
        /// <returns>A collection of CredentialPIV75BitPDSA objects</returns>
        public CredentialPIV75BitPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of CredentialPIV75BitPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(CredentialPIV75BitPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = CredentialPIV75BitPDSAData.SelectFilters.Search;

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
        /// CredentialPIV75BitPDSA.SearchEntity = mgr.InitSearchFilter(CredentialPIV75BitPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A CredentialPIV75BitPDSA object</param>
        /// <returns>An CredentialPIV75BitPDSA object</returns>
        public CredentialPIV75BitPDSA InitSearchFilter(CredentialPIV75BitPDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = CredentialPIV75BitPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.CredentialPIV75Bit table
        /// </summary>
        /// <param name="entity">An CredentialPIV75BitPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(CredentialPIV75BitPDSA entity)
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
        /// Updates an entity in the GCS.CredentialPIV75Bit table
        /// </summary>
        /// <param name="entity">An CredentialPIV75BitPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(CredentialPIV75BitPDSA entity)
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
        /// Deletes an entity from the GCS.CredentialPIV75Bit table
        /// </summary>
        /// <param name="entity">An CredentialPIV75BitPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(CredentialPIV75BitPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.CredentialUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetCredentialPIV75BitPDSAsByFK_CredentialPIV75BitCredentialEntity Method
        public CredentialPIV75BitPDSACollection GetCredentialPIV75BitPDSAsByFK_CredentialPIV75BitCredentialEntity(CredentialPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = CredentialPIV75BitPDSAData.SelectFilters.ByCredentialUid;
                    }
                    else
                    {
                    }

                    Entity.CredentialUid = entity.CredentialUid;
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
                return new CredentialPIV75BitPDSACollection();
        }
        #endregion

        #region GetCredentialPIV75BitPDSAsByFK_CredentialPIV75BitCredential Method
        public CredentialPIV75BitPDSACollection GetCredentialPIV75BitPDSAsByFK_CredentialPIV75BitCredential(Guid credentialUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = CredentialPIV75BitPDSAData.SelectFilters.ByCredentialUid;
                }
                else
                {
                }

                Entity.CredentialUid = credentialUid;
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

