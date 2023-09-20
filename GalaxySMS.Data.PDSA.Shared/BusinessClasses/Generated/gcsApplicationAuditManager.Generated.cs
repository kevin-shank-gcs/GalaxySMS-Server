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
    /// This class is used when you need to add, edit, delete, select and validate data for the gcsApplicationAuditPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class gcsApplicationAuditPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the gcsApplicationAuditPDSAManager class
        /// </summary>
        public gcsApplicationAuditPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsApplicationAuditPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public gcsApplicationAuditPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the gcsApplicationAuditPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public gcsApplicationAuditPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private gcsApplicationAuditPDSA _Entity = null;
        private gcsApplicationAuditPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public gcsApplicationAuditPDSA Entity
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
        public gcsApplicationAuditPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new gcsApplicationAuditPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public gcsApplicationAuditPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public gcsApplicationAuditPDSAData DataObject { get; set; }
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
                Entity = new gcsApplicationAuditPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new gcsApplicationAuditPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new gcsApplicationAuditPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "gcsApplicationAuditPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public gcsApplicationAuditPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            gcsApplicationAuditPDSA ret = new gcsApplicationAuditPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.AuditId))
                ret.AuditId = PDSAProperty.ConvertToGuid(values[gcsApplicationAuditPDSAValidator.ColumnNames.AuditId]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationAuditTypeId))
                ret.ApplicationAuditTypeId = PDSAProperty.ConvertToGuid(values[gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationAuditTypeId]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.TransactionId))
                ret.TransactionId = PDSAProperty.ConvertToGuid(values[gcsApplicationAuditPDSAValidator.ColumnNames.TransactionId]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationId))
                ret.ApplicationId = PDSAProperty.ConvertToGuid(values[gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationId]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.UserId))
                ret.UserId = PDSAProperty.ConvertToGuid(values[gcsApplicationAuditPDSAValidator.ColumnNames.UserId]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationName))
                ret.ApplicationName = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationName]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationVersion))
                ret.ApplicationVersion = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.ApplicationVersion]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.MachineName))
                ret.MachineName = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.MachineName]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.LoginName))
                ret.LoginName = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.LoginName]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.WindowsUserName))
                ret.WindowsUserName = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.WindowsUserName]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.AuditDetails))
                ret.AuditDetails = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.AuditDetails]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.AuditXml))
                ret.AuditXml = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.AuditXml]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[gcsApplicationAuditPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(gcsApplicationAuditPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[gcsApplicationAuditPDSAValidator.ColumnNames.InsertDate]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of gcsApplicationAuditPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>gcsApplicationAuditPDSACollection</returns>
        public gcsApplicationAuditPDSACollection BuildCollection()
        {
            gcsApplicationAuditPDSACollection coll = new gcsApplicationAuditPDSACollection();
            gcsApplicationAuditPDSA entity = null;
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
        /// <returns>A collection of gcsApplicationAuditPDSA objects</returns>
        public gcsApplicationAuditPDSACollection BuildCollection(DataSet ds)
        {
            gcsApplicationAuditPDSACollection coll = new gcsApplicationAuditPDSACollection();

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
        /// <returns>A collection of gcsApplicationAuditPDSA objects</returns>
        public gcsApplicationAuditPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of gcsApplicationAuditPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(gcsApplicationAuditPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = gcsApplicationAuditPDSAData.SelectFilters.Search;

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
        /// gcsApplicationAuditPDSA.SearchEntity = mgr.InitSearchFilter(gcsApplicationAuditPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A gcsApplicationAuditPDSA object</param>
        /// <returns>An gcsApplicationAuditPDSA object</returns>
        public gcsApplicationAuditPDSA InitSearchFilter(gcsApplicationAuditPDSA searchEntity)
        {
            searchEntity.ApplicationName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = gcsApplicationAuditPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.gcsApplicationAudit table
        /// </summary>
        /// <param name="entity">An gcsApplicationAuditPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(gcsApplicationAuditPDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.Insert();
            if (ret >= 1)
                TrackChanges("Insert");

            return ret;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Updates an entity in the GCS.gcsApplicationAudit table
        /// </summary>
        /// <param name="entity">An gcsApplicationAuditPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(gcsApplicationAuditPDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.Update();
            if (ret >= 1)
                TrackChanges("Update");

            return ret;
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Deletes an entity from the GCS.gcsApplicationAudit table
        /// </summary>
        /// <param name="entity">An gcsApplicationAuditPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(gcsApplicationAuditPDSA entity)
        {
            int ret = 0;

            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AuditId);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion

        #region GetgcsApplicationAuditPDSAsByApplicationAuditTypeId Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsApplicationAuditPDSACollection GetgcsApplicationAuditPDSAsByApplicationAuditTypeId()
        {
            DataObject.WhereFilter = gcsApplicationAuditPDSAData.WhereFilters.ApplicationAuditTypeId;

            return BuildCollection();
        }
        #endregion

        #region GetgcsApplicationAuditPDSAsByApplicationName Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsApplicationAuditPDSACollection GetgcsApplicationAuditPDSAsByApplicationName()
        {
            DataObject.WhereFilter = gcsApplicationAuditPDSAData.WhereFilters.ApplicationName;

            return BuildCollection();
        }
        #endregion

        #region GetgcsApplicationAuditPDSAsByLikeApplicationName Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsApplicationAuditPDSACollection GetgcsApplicationAuditPDSAsByLikeApplicationName()
        {
            DataObject.WhereFilter = gcsApplicationAuditPDSAData.WhereFilters.LikeApplicationName;

            return BuildCollection();
        }
        #endregion

        #region GetgcsApplicationAuditPDSAsByPrimaryKey Method
        /// <summary>
        /// Sets the specified WhereFilter and calls the BuildCollection() method
        /// Assumes you have set the appropriate column(s) in the Entity object
        /// prior to calling this method. Ex. mgr.Entity.'ColumName' = 'Value'
        /// </summary>
        public gcsApplicationAuditPDSACollection GetgcsApplicationAuditPDSAsByPrimaryKey()
        {
            DataObject.WhereFilter = gcsApplicationAuditPDSAData.WhereFilters.PrimaryKey;

            return BuildCollection();
        }
        #endregion

        #region GetgcsApplicationAuditPDSAsByFK_ApplicationAuditApplicationAuditTypeEntity Method
        public gcsApplicationAuditPDSACollection GetgcsApplicationAuditPDSAsByFK_ApplicationAuditApplicationAuditTypeEntity(gcsApplicationAuditTypePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = gcsApplicationAuditPDSAData.SelectFilters.ByApplicationAuditTypeId;
                    }
                    else
                    {
                        DataObject.WhereFilter = gcsApplicationAuditPDSAData.WhereFilters.ApplicationAuditTypeId;
                    }

                    Entity.ApplicationAuditTypeId = entity.ApplicationAuditTypeId;
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
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new gcsApplicationAuditPDSACollection();
        }
        #endregion

        #region GetgcsApplicationAuditPDSAsByFK_ApplicationAuditApplicationAuditType Method
        public gcsApplicationAuditPDSACollection GetgcsApplicationAuditPDSAsByFK_ApplicationAuditApplicationAuditType(Guid applicationAuditTypeId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = gcsApplicationAuditPDSAData.SelectFilters.ByApplicationAuditTypeId;
                }
                else
                {
                    DataObject.WhereFilter = gcsApplicationAuditPDSAData.WhereFilters.ApplicationAuditTypeId;
                }

                Entity.ApplicationAuditTypeId = applicationAuditTypeId;
            }
            catch (Exception ex)
            {
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

