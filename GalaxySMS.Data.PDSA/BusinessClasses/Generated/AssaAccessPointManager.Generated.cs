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
    /// This class is used when you need to add, edit, delete, select and validate data for the AssaAccessPointPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AssaAccessPointPDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AssaAccessPointPDSAManager class
        /// </summary>
        public AssaAccessPointPDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AssaAccessPointPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AssaAccessPointPDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the AssaAccessPointPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AssaAccessPointPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AssaAccessPointPDSA _Entity = null;
        private AssaAccessPointPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AssaAccessPointPDSA Entity
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
        public AssaAccessPointPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AssaAccessPointPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AssaAccessPointPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AssaAccessPointPDSAData DataObject { get; set; }
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
                Entity = new AssaAccessPointPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AssaAccessPointPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AssaAccessPointPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "AssaAccessPointPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AssaAccessPointPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AssaAccessPointPDSA ret = new AssaAccessPointPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.AssaAccessPointUid))
                ret.AssaAccessPointUid = PDSAProperty.ConvertToGuid(values[AssaAccessPointPDSAValidator.ColumnNames.AssaAccessPointUid]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.AssaDsrUid))
                ret.AssaDsrUid = PDSAProperty.ConvertToGuid(values[AssaAccessPointPDSAValidator.ColumnNames.AssaDsrUid]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.AssaAccessPointTypeUid))
                ret.AssaAccessPointTypeUid = PDSAProperty.ConvertToGuid(values[AssaAccessPointPDSAValidator.ColumnNames.AssaAccessPointTypeUid]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.SerialNumber))
                ret.SerialNumber = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.SerialNumber]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.AccessPointName))
                ret.AccessPointName = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.AccessPointName]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.FirmwareVersion))
                ret.FirmwareVersion = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.FirmwareVersion]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AssaAccessPointPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[AssaAccessPointPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[AssaAccessPointPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.SiteUid))
                ret.SiteUid = PDSAProperty.ConvertToGuid(values[AssaAccessPointPDSAValidator.ColumnNames.SiteUid]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.AssaUniqueId))
                ret.AssaUniqueId = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.AssaUniqueId]);

            if (values.ContainsKey(AssaAccessPointPDSAValidator.ColumnNames.AccessPointTypeDescription))
                ret.AccessPointTypeDescription = PDSAString.ConvertToStringTrim(values[AssaAccessPointPDSAValidator.ColumnNames.AccessPointTypeDescription]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AssaAccessPointPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AssaAccessPointPDSACollection</returns>
        public AssaAccessPointPDSACollection BuildCollection()
        {
            AssaAccessPointPDSACollection coll = new AssaAccessPointPDSACollection();
            AssaAccessPointPDSA entity = null;
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
        /// <returns>A collection of AssaAccessPointPDSA objects</returns>
        public AssaAccessPointPDSACollection BuildCollection(DataSet ds)
        {
            AssaAccessPointPDSACollection coll = new AssaAccessPointPDSACollection();

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
        /// <returns>A collection of AssaAccessPointPDSA objects</returns>
        public AssaAccessPointPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AssaAccessPointPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AssaAccessPointPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.Search;

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
        /// AssaAccessPointPDSA.SearchEntity = mgr.InitSearchFilter(AssaAccessPointPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AssaAccessPointPDSA object</param>
        /// <returns>An AssaAccessPointPDSA object</returns>
        public AssaAccessPointPDSA InitSearchFilter(AssaAccessPointPDSA searchEntity)
        {
            searchEntity.SerialNumber = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.AssaAccessPoint table
        /// </summary>
        /// <param name="entity">An AssaAccessPointPDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(AssaAccessPointPDSA entity)
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
        /// Updates an entity in the GCS.AssaAccessPoint table
        /// </summary>
        /// <param name="entity">An AssaAccessPointPDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(AssaAccessPointPDSA entity)
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
        /// Deletes an entity from the GCS.AssaAccessPoint table
        /// </summary>
        /// <param name="entity">An AssaAccessPointPDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(AssaAccessPointPDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.AssaAccessPointUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaAccessPointTypeEntity Method
        public AssaAccessPointPDSACollection GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaAccessPointTypeEntity(AssaAccessPointTypePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.ByAssaAccessPointTypeUid;
                    }
                    else
                    {
                    }

                    Entity.AssaAccessPointTypeUid = entity.AssaAccessPointTypeUid;
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
System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new AssaAccessPointPDSACollection();
        }
        #endregion

        #region GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaAccessPointType Method
        public AssaAccessPointPDSACollection GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaAccessPointType(Guid assaAccessPointTypeUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.ByAssaAccessPointTypeUid;
                }
                else
                {
                }

                Entity.AssaAccessPointTypeUid = assaAccessPointTypeUid;
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

        #region GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaDsrEntity Method
        public AssaAccessPointPDSACollection GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaDsrEntity(AssaDsrPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.ByAssaDsrUid;
                    }
                    else
                    {
                    }

                    Entity.AssaDsrUid = entity.AssaDsrUid;
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
System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new AssaAccessPointPDSACollection();
        }
        #endregion

        #region GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaDsr Method
        public AssaAccessPointPDSACollection GetAssaAccessPointPDSAsByFK_AssaAccessPointAssaDsr(Guid assaDsrUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.ByAssaDsrUid;
                }
                else
                {
                }

                Entity.AssaDsrUid = assaDsrUid;
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

        #region GetAssaAccessPointPDSAsByFK_AssaAccessPointSiteEntity Method
        public AssaAccessPointPDSACollection GetAssaAccessPointPDSAsByFK_AssaAccessPointSiteEntity(SitePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.BySiteUid;
                    }
                    else
                    {
                    }

                    Entity.SiteUid = entity.SiteUid;
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
System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                return BuildCollection();
            }
            else
                return new AssaAccessPointPDSACollection();
        }
        #endregion

        #region GetAssaAccessPointPDSAsByFK_AssaAccessPointSite Method
        public AssaAccessPointPDSACollection GetAssaAccessPointPDSAsByFK_AssaAccessPointSite(Guid siteUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = AssaAccessPointPDSAData.SelectFilters.BySiteUid;
                }
                else
                {
                }

                Entity.SiteUid = siteUid;
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

