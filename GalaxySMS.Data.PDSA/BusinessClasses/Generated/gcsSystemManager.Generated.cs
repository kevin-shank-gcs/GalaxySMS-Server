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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsSystemPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsSystemPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsSystemPDSAManager class
        /// </summary>
        public gcsSystemPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsSystemPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsSystemPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsSystemPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsSystemPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsSystemPDSA _Entity = null;
        private gcsSystemPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsSystemPDSA Entity
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
        public gcsSystemPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsSystemPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsSystemPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsSystemPDSAData DataObject { get; set; }
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
                Entity = new gcsSystemPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsSystemPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsSystemPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsSystemPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsSystemPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsSystemPDSA ret = new gcsSystemPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SystemId))
                ret.SystemId = PDSAProperty.ConvertToGuid(values[gcsSystemPDSAValidator.ColumnNames.SystemId]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SystemName))
                ret.SystemName = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.SystemName]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.CompanyName))
                ret.CompanyName = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.CompanyName]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SupportCompany))
                ret.SupportCompany = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.SupportCompany]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SupportContact))
                ret.SupportContact = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.SupportContact]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SupportPhone))
                ret.SupportPhone = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.SupportPhone]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SupportEmail))
                ret.SupportEmail = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.SupportEmail]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SupportUrl))
                ret.SupportUrl = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.SupportUrl]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SupportImage))
                ret.SupportImage = PDSAProperty.ConvertToByteArray(values[gcsSystemPDSAValidator.ColumnNames.SupportImage]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.SystemImage))
                ret.SystemImage = PDSAProperty.ConvertToByteArray(values[gcsSystemPDSAValidator.ColumnNames.SystemImage]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.License))
                ret.License = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.License]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[gcsSystemPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[gcsSystemPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[gcsSystemPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(gcsSystemPDSAValidator.ColumnNames.PublicKey))
                ret.PublicKey = PDSAString.ConvertToStringTrim(values[gcsSystemPDSAValidator.ColumnNames.PublicKey]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsSystemPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsSystemPDSACollection</returns>
        public gcsSystemPDSACollection BuildCollection()
        {
            gcsSystemPDSACollection coll = new gcsSystemPDSACollection();
            gcsSystemPDSA entity = null;
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
        /// <returns>A collection of gcsSystemPDSA objects</returns>
        public gcsSystemPDSACollection BuildCollection(DataSet ds)
        {
            gcsSystemPDSACollection coll = new gcsSystemPDSACollection();

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
        /// <returns>A collection of gcsSystemPDSA objects</returns>
        public gcsSystemPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsSystemPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsSystemPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsSystemPDSAData.SelectFilters.Search;

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
        /// gcsSystemPDSA.SearchEntity = mgr.InitSearchFilter(gcsSystemPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsSystemPDSA object</param>
        /// <returns>An gcsSystemPDSA object</returns>
        public gcsSystemPDSA InitSearchFilter(gcsSystemPDSA searchEntity)
        {
            searchEntity.SystemName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsSystemPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsSystem table
        /// </summary>
        /// <param name="entity">An gcsSystemPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsSystemPDSA entity)
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
        /// Updates an entity in the GCS.gcsSystem table
        /// </summary>
        /// <param name="entity">An gcsSystemPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsSystemPDSA entity)
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
        /// Deletes an entity from the GCS.gcsSystem table
        /// </summary>
        /// <param name="entity">An gcsSystemPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsSystemPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.SystemId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



    }
}

