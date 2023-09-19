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
    /// This class is used when you need to add, edit, delete, select and validate data for the GalaxyInputModePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class GalaxyInputModePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the GalaxyInputModePDSAManager class
        /// </summary>
        public GalaxyInputModePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInputModePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public GalaxyInputModePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the GalaxyInputModePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public GalaxyInputModePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private GalaxyInputModePDSA _Entity = null;
        private GalaxyInputModePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public GalaxyInputModePDSA Entity
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
        public GalaxyInputModePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new GalaxyInputModePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public GalaxyInputModePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public GalaxyInputModePDSAData DataObject { get; set; }
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
                Entity = new GalaxyInputModePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new GalaxyInputModePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new GalaxyInputModePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "GalaxyInputModePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public GalaxyInputModePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            GalaxyInputModePDSA ret = new GalaxyInputModePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.GalaxyInputModeUid))
                ret.GalaxyInputModeUid = PDSAProperty.ConvertToGuid(values[GalaxyInputModePDSAValidator.ColumnNames.GalaxyInputModeUid]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[GalaxyInputModePDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[GalaxyInputModePDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[GalaxyInputModePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[GalaxyInputModePDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.Code))
                ret.Code = Convert.ToInt16(values[GalaxyInputModePDSAValidator.ColumnNames.Code]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.DisplayOrder))
                ret.DisplayOrder = Convert.ToInt32(values[GalaxyInputModePDSAValidator.ColumnNames.DisplayOrder]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.IsDefault))
                ret.IsDefault = Convert.ToBoolean(values[GalaxyInputModePDSAValidator.ColumnNames.IsDefault]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[GalaxyInputModePDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[GalaxyInputModePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[GalaxyInputModePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[GalaxyInputModePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = GCS.Core.Common.Extensions.DateTimeExtensions.ToDateTimeOffset(values[GalaxyInputModePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[GalaxyInputModePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(GalaxyInputModePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[GalaxyInputModePDSAValidator.ColumnNames.CultureName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of GalaxyInputModePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>GalaxyInputModePDSACollection</returns>
        public GalaxyInputModePDSACollection BuildCollection()
        {
            GalaxyInputModePDSACollection coll = new GalaxyInputModePDSACollection();
            GalaxyInputModePDSA entity = null;
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
        /// <returns>A collection of GalaxyInputModePDSA objects</returns>
        public GalaxyInputModePDSACollection BuildCollection(DataSet ds)
        {
            GalaxyInputModePDSACollection coll = new GalaxyInputModePDSACollection();

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
        /// <returns>A collection of GalaxyInputModePDSA objects</returns>
        public GalaxyInputModePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of GalaxyInputModePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(GalaxyInputModePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = GalaxyInputModePDSAData.SelectFilters.Search;

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
        /// GalaxyInputModePDSA.SearchEntity = mgr.InitSearchFilter(GalaxyInputModePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A GalaxyInputModePDSA object</param>
        /// <returns>An GalaxyInputModePDSA object</returns>
        public GalaxyInputModePDSA InitSearchFilter(GalaxyInputModePDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = GalaxyInputModePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.GalaxyInputMode table
        /// </summary>
        /// <param name="entity">An GalaxyInputModePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(GalaxyInputModePDSA entity)
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
        /// Updates an entity in the GCS.GalaxyInputMode table
        /// </summary>
        /// <param name="entity">An GalaxyInputModePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(GalaxyInputModePDSA entity)
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
        /// Deletes an entity from the GCS.GalaxyInputMode table
        /// </summary>
        /// <param name="entity">An GalaxyInputModePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(GalaxyInputModePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.GalaxyInputModeUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        //#region GetGalaxyInputModePDSAsByFK_GalaxyInputModeDisplayResourceKeyEntity Method
        //public GalaxyInputModePDSACollection GetGalaxyInputModePDSAsByFK_GalaxyInputModeDisplayResourceKeyEntity(gcsResourceStringPDSA entity)
        //{
        //  if (entity != null)
        //  {
        //     try
        //     {
        //       if(DataObject.UseStoredProcs)
        //       {
        //         DataObject.SelectFilter = GalaxyInputModePDSAData.SelectFilters.ByDisplayResourceKey;
        //       }
        //       else
        //       {
        //       }

        //       Entity.DisplayResourceKey = entity.ResourceId;
        //     }
        //     catch (Exception ex)
        //     {
        //       // This is here for design time exceptions
        //       System.Diagnostics.Debug.WriteLine(ex.Message);
        // System.Diagnostics.Debug.WriteLine(ex.ToString());
        //     }

        //     return BuildCollection();
        //  }
        //  else
        //    return new GalaxyInputModePDSACollection();
        //}
        //#endregion

        //#region GetGalaxyInputModePDSAsByFK_GalaxyInputModeDisplayResourceKey Method
        //public GalaxyInputModePDSACollection GetGalaxyInputModePDSAsByFK_GalaxyInputModeDisplayResourceKey(Guid resourceId)
        //{
        //  try
        //  {
        //    if(DataObject.UseStoredProcs)
        //    {
        //      DataObject.SelectFilter = GalaxyInputModePDSAData.SelectFilters.ByDisplayResourceKey;
        //    }
        //    else
        //    {
        //    }

        //    Entity.DisplayResourceKey = resourceId;
        //  }
        //  catch (Exception ex)
        //  {
        //    // This is here for design time exceptions
        //    System.Diagnostics.Debug.WriteLine(ex.Message);
        //    System.Diagnostics.Debug.WriteLine(ex.ToString());
        //  }

        //  return BuildCollection();
        //}
        //#endregion

    }
}

