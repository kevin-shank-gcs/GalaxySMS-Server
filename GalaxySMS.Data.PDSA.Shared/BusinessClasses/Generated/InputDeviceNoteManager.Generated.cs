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
    /// This class is used when you need to add, edit, delete, select and validate data for the InputDeviceNotePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class InputDeviceNotePDSAManager : PDSADataClassManagerBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the InputDeviceNotePDSAManager class
        /// </summary>
        public InputDeviceNotePDSAManager() : base()
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputDeviceNotePDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public InputDeviceNotePDSAManager(PDSADataProvider dataProvider) : base(dataProvider)
        {
            // The base constructor calls the Init() method
        }

        /// <summary>
        /// Constructor for the InputDeviceNotePDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public InputDeviceNotePDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private InputDeviceNotePDSA _Entity = null;
        private InputDeviceNotePDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public InputDeviceNotePDSA Entity
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
        public InputDeviceNotePDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new InputDeviceNotePDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public InputDeviceNotePDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public InputDeviceNotePDSAData DataObject { get; set; }
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
                Entity = new InputDeviceNotePDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new InputDeviceNotePDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new InputDeviceNotePDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "InputDeviceNotePDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public InputDeviceNotePDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            InputDeviceNotePDSA ret = new InputDeviceNotePDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid))
                ret.InputDeviceNoteUid = PDSAProperty.ConvertToGuid(values[InputDeviceNotePDSAValidator.ColumnNames.InputDeviceNoteUid]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid))
                ret.InputDeviceUid = PDSAProperty.ConvertToGuid(values[InputDeviceNotePDSAValidator.ColumnNames.InputDeviceUid]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.NoteUid))
                ret.NoteUid = PDSAProperty.ConvertToGuid(values[InputDeviceNotePDSAValidator.ColumnNames.NoteUid]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[InputDeviceNotePDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[InputDeviceNotePDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[InputDeviceNotePDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[InputDeviceNotePDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[InputDeviceNotePDSAValidator.ColumnNames.ConcurrencyValue]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of InputDeviceNotePDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>InputDeviceNotePDSACollection</returns>
        public InputDeviceNotePDSACollection BuildCollection()
        {
            InputDeviceNotePDSACollection coll = new InputDeviceNotePDSACollection();
            InputDeviceNotePDSA entity = null;
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
        /// <returns>A collection of InputDeviceNotePDSA objects</returns>
        public InputDeviceNotePDSACollection BuildCollection(DataSet ds)
        {
            InputDeviceNotePDSACollection coll = new InputDeviceNotePDSACollection();

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
        /// <returns>A collection of InputDeviceNotePDSA objects</returns>
        public InputDeviceNotePDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of InputDeviceNotePDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(InputDeviceNotePDSACollection), BuildCollection());
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
            DataObject.SelectFilter = InputDeviceNotePDSAData.SelectFilters.Search;

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
        /// InputDeviceNotePDSA.SearchEntity = mgr.InitSearchFilter(InputDeviceNotePDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A InputDeviceNotePDSA object</param>
        /// <returns>An InputDeviceNotePDSA object</returns>
        public InputDeviceNotePDSA InitSearchFilter(InputDeviceNotePDSA searchEntity)
        {
            searchEntity.InsertName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = InputDeviceNotePDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion

        #region Insert Method
        /// <summary>
        /// Insert a new entity into the GCS.InputDeviceNote table
        /// </summary>
        /// <param name="entity">An InputDeviceNotePDSA entity object</param>
        /// <returns>Number of rows affected by the Insert</returns>
        public int Insert(InputDeviceNotePDSA entity)
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
        /// Updates an entity in the GCS.InputDeviceNote table
        /// </summary>
        /// <param name="entity">An InputDeviceNotePDSA entity object</param>
        /// <returns>Number of rows affected by the Update</returns>
        public int Update(InputDeviceNotePDSA entity)
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
        /// Deletes an entity from the GCS.InputDeviceNote table
        /// </summary>
        /// <param name="entity">An InputDeviceNotePDSA entity object</param>
        /// <returns>Number of rows affected by the Delete</returns>
        public int Delete(InputDeviceNotePDSA entity)
        {
            int ret = 0;

            Entity = entity;
            DataObject.Entity = entity;
            ret = DataObject.DeleteByPK(entity.InputDeviceNoteUid);
            if (ret >= 1)
                TrackChanges("Delete");

            return ret;
        }
        #endregion



        #region GetInputDeviceNotePDSAsByFK_InputDeviceNoteInputDeviceEntity Method
        public InputDeviceNotePDSACollection GetInputDeviceNotePDSAsByFK_InputDeviceNoteInputDeviceEntity(InputDevicePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = InputDeviceNotePDSAData.SelectFilters.ByInputDeviceUid;
                    }
                    else
                    {
                    }

                    Entity.InputDeviceUid = entity.InputDeviceUid;
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
                return new InputDeviceNotePDSACollection();
        }
        #endregion

        #region GetInputDeviceNotePDSAsByFK_InputDeviceNoteInputDevice Method
        public InputDeviceNotePDSACollection GetInputDeviceNotePDSAsByFK_InputDeviceNoteInputDevice(Guid inputDeviceUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = InputDeviceNotePDSAData.SelectFilters.ByInputDeviceUid;
                }
                else
                {
                }

                Entity.InputDeviceUid = inputDeviceUid;
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

        #region GetInputDeviceNotePDSAsByFK_InputDeviceNoteNoteEntity Method
        public InputDeviceNotePDSACollection GetInputDeviceNotePDSAsByFK_InputDeviceNoteNoteEntity(NotePDSA entity)
        {
            if (entity != null)
            {
                try
                {
                    if (DataObject.UseStoredProcs)
                    {
                        DataObject.SelectFilter = InputDeviceNotePDSAData.SelectFilters.ByNoteUid;
                    }
                    else
                    {
                    }

                    Entity.NoteUid = entity.NoteUid;
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
                return new InputDeviceNotePDSACollection();
        }
        #endregion

        #region GetInputDeviceNotePDSAsByFK_InputDeviceNoteNote Method
        public InputDeviceNotePDSACollection GetInputDeviceNotePDSAsByFK_InputDeviceNoteNote(Guid noteUid)
        {
            try
            {
                if (DataObject.UseStoredProcs)
                {
                    DataObject.SelectFilter = InputDeviceNotePDSAData.SelectFilters.ByNoteUid;
                }
                else
                {
                }

                Entity.NoteUid = noteUid;
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

