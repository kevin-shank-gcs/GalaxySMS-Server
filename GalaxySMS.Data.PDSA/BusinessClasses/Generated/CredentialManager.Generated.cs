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
    /// This class is used when you need to add, edit, delete, select and validate data for the CredentialPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class CredentialPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the CredentialPDSAManager class
        /// </summary>
        public CredentialPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public CredentialPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public CredentialPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private CredentialPDSA _Entity = null;
        private CredentialPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public CredentialPDSA Entity
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
        public CredentialPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new CredentialPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public CredentialPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public CredentialPDSAData DataObject { get; set; }
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
                Entity = new CredentialPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new CredentialPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new CredentialPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "CredentialPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public CredentialPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            CredentialPDSA ret = new CredentialPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CredentialUid))
                ret.CredentialUid = PDSAProperty.ConvertToGuid(values[CredentialPDSAValidator.ColumnNames.CredentialUid]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CredentialFormatUid))
                ret.CredentialFormatUid = PDSAProperty.ConvertToGuid(values[CredentialPDSAValidator.ColumnNames.CredentialFormatUid]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CardNumber))
                ret.CardNumber = PDSAString.ConvertToStringTrim(values[CredentialPDSAValidator.ColumnNames.CardNumber]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CardNumberIsHex))
                ret.CardNumberIsHex = Convert.ToBoolean(values[CredentialPDSAValidator.ColumnNames.CardNumberIsHex]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CardBinaryData))
                ret.CardBinaryData = PDSAProperty.ConvertToByteArray(values[CredentialPDSAValidator.ColumnNames.CardBinaryData]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[CredentialPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[CredentialPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[CredentialPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.BitCount))
                ret.BitCount = Convert.ToInt16(values[CredentialPDSAValidator.ColumnNames.BitCount]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.FacilityCode))
                ret.FacilityCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.FacilityCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.IdCode))
                ret.IdCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.IdCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.IssueCode))
                ret.IssueCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.IssueCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.AgencyCode))
                ret.AgencyCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.AgencyCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CredentialCode))
                ret.CredentialCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.CredentialCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.SiteCode))
                ret.SiteCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.SiteCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.Number1))
                ret.Number1 = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.Number1]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.CompanyCode))
                ret.CompanyCode = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.CompanyCode]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.Number2))
                ret.Number2 = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.Number2]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.Number3))
                ret.Number3 = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.Number3]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.Number4))
                ret.Number4 = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.Number4]);

            if (values.ContainsKey(CredentialPDSAValidator.ColumnNames.Number5))
                ret.Number5 = Convert.ToInt32(values[CredentialPDSAValidator.ColumnNames.Number5]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of CredentialPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>CredentialPDSACollection</returns>
        public CredentialPDSACollection BuildCollection()
        {
            CredentialPDSACollection coll = new CredentialPDSACollection();
            CredentialPDSA entity = null;
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
        /// <returns>A collection of CredentialPDSA objects</returns>
        public CredentialPDSACollection BuildCollection(DataSet ds)
        {
            CredentialPDSACollection coll = new CredentialPDSACollection();

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
        /// <returns>A collection of CredentialPDSA objects</returns>
        public CredentialPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of CredentialPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(CredentialPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = CredentialPDSAData.SelectFilters.Search;

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
        /// CredentialPDSA.SearchEntity = mgr.InitSearchFilter(CredentialPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A CredentialPDSA object</param>
        /// <returns>An CredentialPDSA object</returns>
        public CredentialPDSA InitSearchFilter(CredentialPDSA searchEntity)
        {
            searchEntity.CardNumber = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = CredentialPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.Credential table
        /// </summary>
        /// <param name="entity">An CredentialPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(CredentialPDSA entity)
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
        /// Updates an entity in the GCS.Credential table
        /// </summary>
        /// <param name="entity">An CredentialPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(CredentialPDSA entity)
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
        /// Deletes an entity from the GCS.Credential table
        /// </summary>
        /// <param name="entity">An CredentialPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(CredentialPDSA entity)
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



        #region GetCredentialPDSAsByFK_CredentialCredentialFormatEntity Method
        public CredentialPDSACollection GetCredentialPDSAsByFK_CredentialCredentialFormatEntity(CredentialFormatPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCredentialFormatUid;
                    }
                    else
                    {
                    }

                    Entity.CredentialFormatUid = entity.CredentialFormatUid;
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
                return new CredentialPDSACollection();
        }
        #endregion

        #region GetCredentialPDSAsByFK_CredentialCredentialFormat Method
        public CredentialPDSACollection GetCredentialPDSAsByFK_CredentialCredentialFormat(Guid credentialFormatUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = CredentialPDSAData.SelectFilters.ByCredentialFormatUid;
                }
                else
                {
                }

                Entity.CredentialFormatUid = credentialFormatUid;
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

