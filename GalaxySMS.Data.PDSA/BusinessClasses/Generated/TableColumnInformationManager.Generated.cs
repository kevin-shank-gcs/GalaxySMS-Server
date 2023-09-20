using System;
using System.Collections.Generic;
using System.Data;

using PDSA;
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
    /// This class should be used when you need to select data for the TableColumnInformationPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class TableColumnInformationPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the TableColumnInformationPDSAManager class
        /// </summary>
        public TableColumnInformationPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the TableColumnInformationPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public TableColumnInformationPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the TableColumnInformationPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public TableColumnInformationPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private TableColumnInformationPDSA _Entity = null;
        private TableColumnInformationPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public TableColumnInformationPDSA Entity
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
        public TableColumnInformationPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new TableColumnInformationPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public TableColumnInformationPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public TableColumnInformationPDSAData DataObject { get; set; }
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
                Entity = new TableColumnInformationPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new TableColumnInformationPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new TableColumnInformationPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }

            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;
            ClassName = "TableColumnInformationPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public TableColumnInformationPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            TableColumnInformationPDSA ret = new TableColumnInformationPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.DatabaseName))
                ret.DatabaseName = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.DatabaseName]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.TableSchema))
                ret.TableSchema = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.TableSchema]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.TableName))
                ret.TableName = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.TableName]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.ColumnName))
                ret.ColumnName = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.ColumnName]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.IsNullable))
                ret.IsNullable = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.IsNullable]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.ColumnOrdinalPosition))
                ret.ColumnOrdinalPosition = Convert.ToInt32(values[TableColumnInformationPDSAValidator.ColumnNames.ColumnOrdinalPosition]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.DefaultValue))
                ret.DefaultValue = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.DefaultValue]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.DataType))
                ret.DataType = PDSAString.ConvertToStringTrim(values[TableColumnInformationPDSAValidator.ColumnNames.DataType]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.CharacterMaximumLength))
                ret.CharacterMaximumLength = Convert.ToInt32(values[TableColumnInformationPDSAValidator.ColumnNames.CharacterMaximumLength]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.NumericPrecision))
                ret.NumericPrecision = Convert.ToInt16(values[TableColumnInformationPDSAValidator.ColumnNames.NumericPrecision]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.NumericPrecisionRadix))
                ret.NumericPrecisionRadix = Convert.ToInt16(values[TableColumnInformationPDSAValidator.ColumnNames.NumericPrecisionRadix]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.NumericScale))
                ret.NumericScale = Convert.ToInt32(values[TableColumnInformationPDSAValidator.ColumnNames.NumericScale]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.DateTimePrecision))
                ret.DateTimePrecision = Convert.ToInt16(values[TableColumnInformationPDSAValidator.ColumnNames.DateTimePrecision]);

            if (values.ContainsKey(TableColumnInformationPDSAValidator.ColumnNames.IsComputed))
                ret.IsComputed = Convert.ToInt32(values[TableColumnInformationPDSAValidator.ColumnNames.IsComputed]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of TableColumnInformationPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>TableColumnInformationPDSACollection</returns>
        public TableColumnInformationPDSACollection BuildCollection()
        {
            TableColumnInformationPDSACollection coll = new TableColumnInformationPDSACollection();
            TableColumnInformationPDSA entity = null;
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
        /// <returns>A collection of TableColumnInformationPDSA objects</returns>
        public TableColumnInformationPDSACollection BuildCollection(DataSet ds)
        {
            TableColumnInformationPDSACollection coll = new TableColumnInformationPDSACollection();

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
        /// <returns>A collection of TableColumnInformationPDSA objects</returns>
        public TableColumnInformationPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of TableColumnInformationPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(TableColumnInformationPDSACollection), BuildCollection());
        }
        #endregion

        #region GetDataSet Method
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
            DataObject.SelectFilter = TableColumnInformationPDSAData.SelectFilters.Search;

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
        /// TableColumnInformationPDSA.SearchEntity = mgr.InitSearchFilter(TableColumnInformationPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A TableColumnInformationPDSA object</param>
        /// <returns>An TableColumnInformationPDSA object</returns>
        public TableColumnInformationPDSA InitSearchFilter(TableColumnInformationPDSA searchEntity)
        {
            searchEntity.DatabaseName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = TableColumnInformationPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current TableColumnInformationPDSA
        /// </summary>
        /// <returns>A cloned TableColumnInformationPDSA object</returns>
        public TableColumnInformationPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in TableColumnInformationPDSA
        /// </summary>
        /// <param name="entityToClone">The TableColumnInformationPDSA entity to clone</param>
        /// <returns>A cloned TableColumnInformationPDSA object</returns>
        public TableColumnInformationPDSA CloneEntity(TableColumnInformationPDSA entityToClone)
        {
            TableColumnInformationPDSA newEntity = new TableColumnInformationPDSA();

            newEntity.DatabaseName = entityToClone.DatabaseName;
            newEntity.TableSchema = entityToClone.TableSchema;
            newEntity.TableName = entityToClone.TableName;
            newEntity.ColumnName = entityToClone.ColumnName;
            newEntity.IsNullable = entityToClone.IsNullable;
            newEntity.ColumnOrdinalPosition = entityToClone.ColumnOrdinalPosition;
            newEntity.DefaultValue = entityToClone.DefaultValue;
            newEntity.DataType = entityToClone.DataType;
            newEntity.CharacterMaximumLength = entityToClone.CharacterMaximumLength;
            newEntity.NumericPrecision = entityToClone.NumericPrecision;
            newEntity.NumericPrecisionRadix = entityToClone.NumericPrecisionRadix;
            newEntity.NumericScale = entityToClone.NumericScale;
            newEntity.DateTimePrecision = entityToClone.DateTimePrecision;
            newEntity.IsComputed = entityToClone.IsComputed;

            return newEntity;
        }
        #endregion
    }
}
