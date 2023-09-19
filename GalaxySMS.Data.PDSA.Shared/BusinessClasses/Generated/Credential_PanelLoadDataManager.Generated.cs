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

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class should be used when you need to select data for the Credential_PanelLoadDataPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class Credential_PanelLoadDataPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the Credential_PanelLoadDataPDSAManager class
        /// </summary>
        public Credential_PanelLoadDataPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the Credential_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public Credential_PanelLoadDataPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the Credential_PanelLoadDataPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public Credential_PanelLoadDataPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private Credential_PanelLoadDataPDSA _Entity = null;
        private Credential_PanelLoadDataPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public Credential_PanelLoadDataPDSA Entity
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
        public Credential_PanelLoadDataPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new Credential_PanelLoadDataPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public Credential_PanelLoadDataPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public Credential_PanelLoadDataPDSAData DataObject { get; set; }
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
                Entity = new Credential_PanelLoadDataPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new Credential_PanelLoadDataPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new Credential_PanelLoadDataPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "Credential_PanelLoadDataPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public Credential_PanelLoadDataPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            Credential_PanelLoadDataPDSA ret = new Credential_PanelLoadDataPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.FirstName))
                ret.FirstName = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.FirstName]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.LastName))
                ret.LastName = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.LastName]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonId))
                ret.PersonId = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonId]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonActivationDateTime))
                ret.PersonActivationDateTime = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonActivationDateTime]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonExpirationDateTime))
                ret.PersonExpirationDateTime = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonExpirationDateTime]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonTerminationDate))
                ret.PersonTerminationDate = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonTerminationDate]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.VeryImportantPerson))
                ret.VeryImportantPerson = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.VeryImportantPerson]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.HasPhysicalDisability))
                ret.HasPhysicalDisability = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.HasPhysicalDisability]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.HasVertigo))
                ret.HasVertigo = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.HasVertigo]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonInactiveState))
                ret.PersonInactiveState = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonInactiveState]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PINExempt))
                ret.PINExempt = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PINExempt]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PassbackExempt))
                ret.PassbackExempt = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PassbackExempt]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CanToggleLockState))
                ret.CanToggleLockState = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CanToggleLockState]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonAccessControlPropertiesIsActive))
                ret.PersonAccessControlPropertiesIsActive = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonAccessControlPropertiesIsActive]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PIN))
                ret.PIN = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PIN]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonAccessControlPropertiesAccessProfileUid))
                ret.PersonAccessControlPropertiesAccessProfileUid = PDSAProperty.ConvertToGuid(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonAccessControlPropertiesAccessProfileUid]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonCredentialUid))
                ret.PersonCredentialUid = PDSAProperty.ConvertToGuid(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonCredentialUid]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialUid))
                ret.CredentialUid = PDSAProperty.ConvertToGuid(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialUid]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialActivationDateTime))
                ret.CredentialActivationDateTime = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialActivationDateTime]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialExpirationDateTime))
                ret.CredentialExpirationDateTime = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialExpirationDateTime]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialUsageCount))
                ret.CredentialUsageCount = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialUsageCount]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.DuressEnabled))
                ret.DuressEnabled = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.DuressEnabled]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ReverseBits))
                ret.ReverseBits = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ReverseBits]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.TraceEnabled))
                ret.TraceEnabled = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.TraceEnabled]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonCredentialIsActive))
                ret.PersonCredentialIsActive = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonCredentialIsActive]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialRoleCode))
                ret.CredentialRoleCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialRoleCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialActivationModeCode))
                ret.CredentialActivationModeCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialActivationModeCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialExpirationModeCode))
                ret.CredentialExpirationModeCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialExpirationModeCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.NoServerReplyBehaviorCode))
                ret.NoServerReplyBehaviorCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.NoServerReplyBehaviorCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.DeferToServerBehaviorCode))
                ret.DeferToServerBehaviorCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.DeferToServerBehaviorCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.LastPanelImpactingChangeDate))
                ret.LastPanelImpactingChangeDate = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.LastPanelImpactingChangeDate]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialBits))
                ret.CredentialBits = PDSAProperty.ConvertToByteArray(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialBits]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialFormatDisplay))
                ret.CredentialFormatDisplay = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialFormatDisplay]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialFormatCode))
                ret.CredentialFormatCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialFormatCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.BitCount))
                ret.BitCount = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.BitCount]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CardBinaryData))
                ret.CardBinaryData = PDSAProperty.ConvertToByteArray(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CardBinaryData]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CardNumber))
                ret.CardNumber = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CardNumber]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CardNumberIsHex))
                ret.CardNumberIsHex = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CardNumberIsHex]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.FacCompSiteCode))
                ret.FacCompSiteCode = Convert.ToInt64(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.FacCompSiteCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.IdCode))
                ret.IdCode = Convert.ToInt64(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.IdCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.IssueCode))
                ret.IssueCode = Convert.ToInt64(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.IssueCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdStartingDate))
                ret.LcdStartingDate = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdStartingDate]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdEndingDate))
                ret.LcdEndingDate = Convert.ToDateTime(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdEndingDate]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdMessage))
                ret.LcdMessage = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdMessage]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdMessageDisplayModeCode))
                ret.LcdMessageDisplayModeCode = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.LcdMessageDisplayModeCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid))
                ret.ClusterUid = PDSAProperty.ConvertToGuid(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterUid]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterName]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterTypeCode))
                ret.ClusterTypeCode = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterTypeCode]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterIsActive))
                ret.ClusterIsActive = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ClusterIsActive]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialDataLength))
                ret.CredentialDataLength = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CredentialDataLength]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber))
                ret.CpuNumber = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CpuNumber]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup1))
                ret.AccessGroup1 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup1]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup2))
                ret.AccessGroup2 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup2]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup3))
                ret.AccessGroup3 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup3]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup4))
                ret.AccessGroup4 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.AccessGroup4]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber))
                ret.PersonalAccessGroupNumber = Convert.ToInt16(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.PersonalAccessGroupNumber]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup1))
                ret.InputOutputGroup1 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup1]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup2))
                ret.InputOutputGroup2 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup2]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup3))
                ret.InputOutputGroup3 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup3]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup4))
                ret.InputOutputGroup4 = Convert.ToInt32(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.InputOutputGroup4]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.OtisSplitGroupOperation))
                ret.OtisSplitGroupOperation = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.OtisSplitGroupOperation]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.OtisCimOverride))
                ret.OtisCimOverride = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.OtisCimOverride]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress))
                ret.ServerAddress = PDSAString.ConvertToStringTrim(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.ServerAddress]);

            if (values.ContainsKey(Credential_PanelLoadDataPDSAValidator.ColumnNames.IsConnected))
                ret.IsConnected = Convert.ToBoolean(values[Credential_PanelLoadDataPDSAValidator.ColumnNames.IsConnected]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of Credential_PanelLoadDataPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>Credential_PanelLoadDataPDSACollection</returns>
        public Credential_PanelLoadDataPDSACollection BuildCollection()
        {
            Credential_PanelLoadDataPDSACollection coll = new Credential_PanelLoadDataPDSACollection();
            Credential_PanelLoadDataPDSA entity = null;
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
        /// <returns>A collection of Credential_PanelLoadDataPDSA objects</returns>
        public Credential_PanelLoadDataPDSACollection BuildCollection(DataSet ds)
        {
            Credential_PanelLoadDataPDSACollection coll = new Credential_PanelLoadDataPDSACollection();

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
        /// <returns>A collection of Credential_PanelLoadDataPDSA objects</returns>
        public Credential_PanelLoadDataPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of Credential_PanelLoadDataPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(Credential_PanelLoadDataPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = Credential_PanelLoadDataPDSAData.SelectFilters.Search;

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
        /// Credential_PanelLoadDataPDSA.SearchEntity = mgr.InitSearchFilter(Credential_PanelLoadDataPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A Credential_PanelLoadDataPDSA object</param>
        /// <returns>An Credential_PanelLoadDataPDSA object</returns>
        public Credential_PanelLoadDataPDSA InitSearchFilter(Credential_PanelLoadDataPDSA searchEntity)
        {
            searchEntity.FirstName = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = Credential_PanelLoadDataPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current Credential_PanelLoadDataPDSA
        /// </summary>
        /// <returns>A cloned Credential_PanelLoadDataPDSA object</returns>
        public Credential_PanelLoadDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in Credential_PanelLoadDataPDSA
        /// </summary>
        /// <param name="entityToClone">The Credential_PanelLoadDataPDSA entity to clone</param>
        /// <returns>A cloned Credential_PanelLoadDataPDSA object</returns>
        public Credential_PanelLoadDataPDSA CloneEntity(Credential_PanelLoadDataPDSA entityToClone)
        {
            Credential_PanelLoadDataPDSA newEntity = new Credential_PanelLoadDataPDSA();

            newEntity.PersonUid = entityToClone.PersonUid;
            newEntity.FirstName = entityToClone.FirstName;
            newEntity.LastName = entityToClone.LastName;
            newEntity.PersonId = entityToClone.PersonId;
            newEntity.PersonActivationDateTime = entityToClone.PersonActivationDateTime;
            newEntity.PersonExpirationDateTime = entityToClone.PersonExpirationDateTime;
            newEntity.PersonTerminationDate = entityToClone.PersonTerminationDate;
            newEntity.VeryImportantPerson = entityToClone.VeryImportantPerson;
            newEntity.HasPhysicalDisability = entityToClone.HasPhysicalDisability;
            newEntity.HasVertigo = entityToClone.HasVertigo;
            newEntity.PersonInactiveState = entityToClone.PersonInactiveState;
            newEntity.PINExempt = entityToClone.PINExempt;
            newEntity.PassbackExempt = entityToClone.PassbackExempt;
            newEntity.CanToggleLockState = entityToClone.CanToggleLockState;
            newEntity.PersonAccessControlPropertiesIsActive = entityToClone.PersonAccessControlPropertiesIsActive;
            newEntity.PIN = entityToClone.PIN;
            newEntity.PersonAccessControlPropertiesAccessProfileUid = entityToClone.PersonAccessControlPropertiesAccessProfileUid;
            newEntity.PersonCredentialUid = entityToClone.PersonCredentialUid;
            newEntity.CredentialUid = entityToClone.CredentialUid;
            newEntity.CredentialActivationDateTime = entityToClone.CredentialActivationDateTime;
            newEntity.CredentialExpirationDateTime = entityToClone.CredentialExpirationDateTime;
            newEntity.CredentialUsageCount = entityToClone.CredentialUsageCount;
            newEntity.DuressEnabled = entityToClone.DuressEnabled;
            newEntity.ReverseBits = entityToClone.ReverseBits;
            newEntity.TraceEnabled = entityToClone.TraceEnabled;
            newEntity.PersonCredentialIsActive = entityToClone.PersonCredentialIsActive;
            newEntity.CredentialRoleCode = entityToClone.CredentialRoleCode;
            newEntity.CredentialActivationModeCode = entityToClone.CredentialActivationModeCode;
            newEntity.CredentialExpirationModeCode = entityToClone.CredentialExpirationModeCode;
            newEntity.NoServerReplyBehaviorCode = entityToClone.NoServerReplyBehaviorCode;
            newEntity.DeferToServerBehaviorCode = entityToClone.DeferToServerBehaviorCode;
            newEntity.LastPanelImpactingChangeDate = entityToClone.LastPanelImpactingChangeDate;
            newEntity.CredentialBits = entityToClone.CredentialBits;
            newEntity.CredentialFormatDisplay = entityToClone.CredentialFormatDisplay;
            newEntity.CredentialFormatCode = entityToClone.CredentialFormatCode;
            newEntity.BitCount = entityToClone.BitCount;
            newEntity.CardBinaryData = entityToClone.CardBinaryData;
            newEntity.CardNumber = entityToClone.CardNumber;
            newEntity.CardNumberIsHex = entityToClone.CardNumberIsHex;
            newEntity.FacCompSiteCode = entityToClone.FacCompSiteCode;
            newEntity.IdCode = entityToClone.IdCode;
            newEntity.IssueCode = entityToClone.IssueCode;
            newEntity.LcdStartingDate = entityToClone.LcdStartingDate;
            newEntity.LcdEndingDate = entityToClone.LcdEndingDate;
            newEntity.LcdMessage = entityToClone.LcdMessage;
            newEntity.LcdMessageDisplayModeCode = entityToClone.LcdMessageDisplayModeCode;
            newEntity.ClusterUid = entityToClone.ClusterUid;
            newEntity.ClusterName = entityToClone.ClusterName;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
            newEntity.ClusterIsActive = entityToClone.ClusterIsActive;
            newEntity.CredentialDataLength = entityToClone.CredentialDataLength;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.CpuNumber = entityToClone.CpuNumber;
            newEntity.AccessGroup1 = entityToClone.AccessGroup1;
            newEntity.AccessGroup2 = entityToClone.AccessGroup2;
            newEntity.AccessGroup3 = entityToClone.AccessGroup3;
            newEntity.AccessGroup4 = entityToClone.AccessGroup4;
            newEntity.PersonalAccessGroupNumber = entityToClone.PersonalAccessGroupNumber;
            newEntity.InputOutputGroup1 = entityToClone.InputOutputGroup1;
            newEntity.InputOutputGroup2 = entityToClone.InputOutputGroup2;
            newEntity.InputOutputGroup3 = entityToClone.InputOutputGroup3;
            newEntity.InputOutputGroup4 = entityToClone.InputOutputGroup4;
            newEntity.OtisSplitGroupOperation = entityToClone.OtisSplitGroupOperation;
            newEntity.OtisCimOverride = entityToClone.OtisCimOverride;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ServerAddress = entityToClone.ServerAddress;
            newEntity.IsConnected = entityToClone.IsConnected;

            return newEntity;
        }
        #endregion
    }
}
