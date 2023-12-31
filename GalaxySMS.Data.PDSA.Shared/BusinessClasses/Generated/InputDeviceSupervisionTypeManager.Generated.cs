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
    /// This class is used when you need to add, edit, delete, select and validate data for the InputDeviceSupervisionTypePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputDeviceSupervisionTypePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputDeviceSupervisionTypePDSAManager class
        /// </summary>
        public InputDeviceSupervisionTypePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputDeviceSupervisionTypePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputDeviceSupervisionTypePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputDeviceSupervisionTypePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputDeviceSupervisionTypePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputDeviceSupervisionTypePDSA _Entity = null;
        private InputDeviceSupervisionTypePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputDeviceSupervisionTypePDSA Entity
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
        public InputDeviceSupervisionTypePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputDeviceSupervisionTypePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputDeviceSupervisionTypePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputDeviceSupervisionTypePDSAData DataObject { get; set; }
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
                Entity = new InputDeviceSupervisionTypePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputDeviceSupervisionTypePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputDeviceSupervisionTypePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputDeviceSupervisionTypePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputDeviceSupervisionTypePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputDeviceSupervisionTypePDSA ret = new InputDeviceSupervisionTypePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid))
                ret.InputDeviceSupervisionTypeUid = PDSAProperty.ConvertToGuid(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.InputDeviceSupervisionTypeUid]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.Display))
                ret.Display = PDSAString.ConvertToStringTrim(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.Display]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.DisplayResourceKey))
                ret.DisplayResourceKey = PDSAProperty.ConvertToGuid(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.DisplayResourceKey]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.Description))
                ret.Description = PDSAString.ConvertToStringTrim(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.Description]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.DescriptionResourceKey))
                ret.DescriptionResourceKey = PDSAProperty.ConvertToGuid(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.DescriptionResourceKey]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.HasSeriesResistor))
                ret.HasSeriesResistor = Convert.ToBoolean(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.HasSeriesResistor]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.HasParallelResistor))
                ret.HasParallelResistor = Convert.ToBoolean(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.HasParallelResistor]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.IsNormalOpen))
                ret.IsNormalOpen = Convert.ToBoolean(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.IsNormalOpen]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.TroubleShortThreshold))
                ret.TroubleShortThreshold = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.TroubleShortThreshold]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.NormalChangeThreshold))
                ret.NormalChangeThreshold = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.NormalChangeThreshold]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.TroubleOpenThreshold))
                ret.TroubleOpenThreshold = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.TroubleOpenThreshold]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateVoltagesEnabled))
                ret.AlternateVoltagesEnabled = Convert.ToBoolean(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateVoltagesEnabled]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateTroubleShortThreshold))
                ret.AlternateTroubleShortThreshold = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateTroubleShortThreshold]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateNormalChangeThreshold))
                ret.AlternateNormalChangeThreshold = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateNormalChangeThreshold]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold))
                ret.AlternateTroubleOpenThreshold = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.AlternateTroubleOpenThreshold]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.DisplayOrder))
                ret.DisplayOrder = Convert.ToInt32(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.DisplayOrder]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.IsDefault))
                ret.IsDefault = Convert.ToBoolean(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.IsDefault]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.IsActive))
                ret.IsActive = Convert.ToBoolean(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.IsActive]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.BinaryResourceUid))
                ret.BinaryResourceUid = PDSAProperty.ConvertToGuid(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.BinaryResourceUid]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.CultureName))
                ret.CultureName = PDSAString.ConvertToStringTrim(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.CultureName]);

            if (values.ContainsKey(InputDeviceSupervisionTypePDSAValidator.ColumnNames.InputDeviceUid))
                ret.InputDeviceUid = PDSAProperty.ConvertToGuid(values[InputDeviceSupervisionTypePDSAValidator.ColumnNames.InputDeviceUid]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputDeviceSupervisionTypePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputDeviceSupervisionTypePDSACollection</returns>
        public InputDeviceSupervisionTypePDSACollection BuildCollection()
        {
            InputDeviceSupervisionTypePDSACollection coll = new InputDeviceSupervisionTypePDSACollection();
            InputDeviceSupervisionTypePDSA entity = null;
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
            }

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of InputDeviceSupervisionTypePDSA objects</returns>
        public InputDeviceSupervisionTypePDSACollection BuildCollection(DataSet ds)
        {
            InputDeviceSupervisionTypePDSACollection coll = new InputDeviceSupervisionTypePDSACollection();

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
        /// <returns>A collection of InputDeviceSupervisionTypePDSA objects</returns>
        public InputDeviceSupervisionTypePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputDeviceSupervisionTypePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputDeviceSupervisionTypePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.Search;

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
        /// InputDeviceSupervisionTypePDSA.SearchEntity = mgr.InitSearchFilter(InputDeviceSupervisionTypePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputDeviceSupervisionTypePDSA object</param>
        /// <returns>An InputDeviceSupervisionTypePDSA object</returns>
        public InputDeviceSupervisionTypePDSA InitSearchFilter(InputDeviceSupervisionTypePDSA searchEntity)
        {
            searchEntity.Display = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.InputDeviceSupervisionType table
        /// </summary>
        /// <param name="entity">An InputDeviceSupervisionTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(InputDeviceSupervisionTypePDSA entity)
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
        /// Updates an entity in the GCS.InputDeviceSupervisionType table
        /// </summary>
        /// <param name="entity">An InputDeviceSupervisionTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(InputDeviceSupervisionTypePDSA entity)
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
        /// Deletes an entity from the GCS.InputDeviceSupervisionType table
        /// </summary>
        /// <param name="entity">An InputDeviceSupervisionTypePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(InputDeviceSupervisionTypePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.InputDeviceSupervisionTypeUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetInputDeviceSupervisionTypePDSAsByFK_InputDeviceSupervisionTypeDisplayResourceKeyEntity Method
        public InputDeviceSupervisionTypePDSACollection GetInputDeviceSupervisionTypePDSAsByFK_InputDeviceSupervisionTypeDisplayResourceKeyEntity(gcsResourceStringPDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.ByDisplayResourceKey;
                    }
                    else
                    {
                    }

                    Entity.DisplayResourceKey = entity.ResourceId;
                }
                catch (Exception ex)
                {
                    // This is here for design time exceptions
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
                return new InputDeviceSupervisionTypePDSACollection();
        }
        #endregion

        #region GetInputDeviceSupervisionTypePDSAsByFK_InputDeviceSupervisionTypeDisplayResourceKey Method
        public InputDeviceSupervisionTypePDSACollection GetInputDeviceSupervisionTypePDSAsByFK_InputDeviceSupervisionTypeDisplayResourceKey(Guid resourceId)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.ByDisplayResourceKey;
                }
                else
                {
                }

                Entity.DisplayResourceKey = resourceId;
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
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
        #endregion

    }
}

