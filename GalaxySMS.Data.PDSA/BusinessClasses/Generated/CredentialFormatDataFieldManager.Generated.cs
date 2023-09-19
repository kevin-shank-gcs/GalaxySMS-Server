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
    /// This class is used when you need to add, edit, delete, select and validate data for the CredentialFormatDataFieldPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class CredentialFormatDataFieldPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the CredentialFormatDataFieldPDSAManager class
        /// </summary>
        public CredentialFormatDataFieldPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialFormatDataFieldPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public CredentialFormatDataFieldPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the CredentialFormatDataFieldPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public CredentialFormatDataFieldPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private CredentialFormatDataFieldPDSA _Entity = null;
        private CredentialFormatDataFieldPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public CredentialFormatDataFieldPDSA Entity
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
        public CredentialFormatDataFieldPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new CredentialFormatDataFieldPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public CredentialFormatDataFieldPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public CredentialFormatDataFieldPDSAData DataObject { get; set; }
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
                Entity = new CredentialFormatDataFieldPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new CredentialFormatDataFieldPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new CredentialFormatDataFieldPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "CredentialFormatDataFieldPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public CredentialFormatDataFieldPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            CredentialFormatDataFieldPDSA ret = new CredentialFormatDataFieldPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.CredentialFormatDataFieldUid))
                ret.CredentialFormatDataFieldUid = PDSAProperty.ConvertToGuid(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.CredentialFormatDataFieldUid]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.CredentialFormatUid))
                ret.CredentialFormatUid = PDSAProperty.ConvertToGuid(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.CredentialFormatUid]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.FieldName))
                ret.FieldName = PDSAString.ConvertToStringTrim(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.FieldName]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.StartsAt))
                ret.StartsAt = Convert.ToInt16(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.StartsAt]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.BitLength))
                ret.BitLength = Convert.ToInt16(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.BitLength]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.MinimumValue))
                ret.MinimumValue = Convert.ToUInt64(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.MinimumValue]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.MaximumValue))
                ret.MaximumValue = Convert.ToUInt64(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.MaximumValue]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.FieldNumber))
                ret.FieldNumber = Convert.ToInt16(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.FieldNumber]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.IsReadOnly))
                ret.IsReadOnly = Convert.ToBoolean(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.IsReadOnly]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.IsVisible))
                ret.IsVisible = Convert.ToBoolean(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.IsVisible]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.DefaultValue))
                ret.DefaultValue = Convert.ToUInt64(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.DefaultValue]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(CredentialFormatDataFieldPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[CredentialFormatDataFieldPDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of CredentialFormatDataFieldPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>CredentialFormatDataFieldPDSACollection</returns>
        public CredentialFormatDataFieldPDSACollection BuildCollection()
        {
            CredentialFormatDataFieldPDSACollection coll = new CredentialFormatDataFieldPDSACollection();
            CredentialFormatDataFieldPDSA entity = null;
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
        /// <returns>A collection of CredentialFormatDataFieldPDSA objects</returns>
        public CredentialFormatDataFieldPDSACollection BuildCollection(DataSet ds)
        {
            CredentialFormatDataFieldPDSACollection coll = new CredentialFormatDataFieldPDSACollection();

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
        /// <returns>A collection of CredentialFormatDataFieldPDSA objects</returns>
        public CredentialFormatDataFieldPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of CredentialFormatDataFieldPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(CredentialFormatDataFieldPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = CredentialFormatDataFieldPDSAData.SelectFilters.Search;

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
        /// CredentialFormatDataFieldPDSA.SearchEntity = mgr.InitSearchFilter(CredentialFormatDataFieldPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A CredentialFormatDataFieldPDSA object</param>
        /// <returns>An CredentialFormatDataFieldPDSA object</returns>
        public CredentialFormatDataFieldPDSA InitSearchFilter(CredentialFormatDataFieldPDSA searchEntity)
        {
            searchEntity.FieldName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = CredentialFormatDataFieldPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.CredentialFormatDataField table
        /// </summary>
        /// <param name="entity">An CredentialFormatDataFieldPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(CredentialFormatDataFieldPDSA entity)
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
        /// Updates an entity in the GCS.CredentialFormatDataField table
        /// </summary>
        /// <param name="entity">An CredentialFormatDataFieldPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(CredentialFormatDataFieldPDSA entity)
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
        /// Deletes an entity from the GCS.CredentialFormatDataField table
        /// </summary>
        /// <param name="entity">An CredentialFormatDataFieldPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(CredentialFormatDataFieldPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.CredentialFormatDataFieldUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetCredentialFormatDataFieldPDSAsByFK_CredentialFormatDataFieldCredentialFormatEntity Method
        public CredentialFormatDataFieldPDSACollection GetCredentialFormatDataFieldPDSAsByFK_CredentialFormatDataFieldCredentialFormatEntity(CredentialFormatPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = CredentialFormatDataFieldPDSAData.SelectFilters.ByCredentialFormatUid;
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
                return new CredentialFormatDataFieldPDSACollection();
        }
        #endregion

        #region GetCredentialFormatDataFieldPDSAsByFK_CredentialFormatDataFieldCredentialFormat Method
        public CredentialFormatDataFieldPDSACollection GetCredentialFormatDataFieldPDSAsByFK_CredentialFormatDataFieldCredentialFormat(Guid credentialFormatUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = CredentialFormatDataFieldPDSAData.SelectFilters.ByCredentialFormatUid;
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

