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
    /// This class should be used when you need to select data for the AcknowledgedAlarmsWithResponsesPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class AcknowledgedAlarmsWithResponsesPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the AcknowledgedAlarmsWithResponsesPDSAManager class
        /// </summary>
        public AcknowledgedAlarmsWithResponsesPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the AcknowledgedAlarmsWithResponsesPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public AcknowledgedAlarmsWithResponsesPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the AcknowledgedAlarmsWithResponsesPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public AcknowledgedAlarmsWithResponsesPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private AcknowledgedAlarmsWithResponsesPDSA _Entity = null;
        private AcknowledgedAlarmsWithResponsesPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public AcknowledgedAlarmsWithResponsesPDSA Entity
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
        public AcknowledgedAlarmsWithResponsesPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new AcknowledgedAlarmsWithResponsesPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public AcknowledgedAlarmsWithResponsesPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public AcknowledgedAlarmsWithResponsesPDSAData DataObject { get; set; }
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
                Entity = new AcknowledgedAlarmsWithResponsesPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new AcknowledgedAlarmsWithResponsesPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new AcknowledgedAlarmsWithResponsesPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "AcknowledgedAlarmsWithResponsesPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public AcknowledgedAlarmsWithResponsesPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            AcknowledgedAlarmsWithResponsesPDSA ret = new AcknowledgedAlarmsWithResponsesPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ActivityEventUid))
                ret.ActivityEventUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ActivityEventUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ClusterGroupId))
                ret.ClusterGroupId = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ClusterGroupId]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ClusterNumber))
                ret.ClusterNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ClusterNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PanelNumber))
                ret.PanelNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PanelNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CpuId))
                ret.CpuId = Convert.ToInt16(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CpuId]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.BoardNumber))
                ret.BoardNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.BoardNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.SectionNumber))
                ret.SectionNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.SectionNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ModuleNumber))
                ret.ModuleNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ModuleNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.NodeNumber))
                ret.NodeNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.NodeNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CpuModel))
                ret.CpuModel = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CpuModel]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DateTime_x))
                ret.DateTime_x = Convert.ToDateTime(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DateTime_x]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.BufferIndex))
                ret.BufferIndex = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.BufferIndex]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PanelActivityType))
                ret.PanelActivityType = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PanelActivityType]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.InputOutputGroupNumber))
                ret.InputOutputGroupNumber = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.InputOutputGroupNumber]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.MultiFactorMode))
                ret.MultiFactorMode = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.MultiFactorMode]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DeviceDescription))
                ret.DeviceDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DeviceDescription]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.EventDescription))
                ret.EventDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.EventDescription]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DeviceEntityId))
                ret.DeviceEntityId = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DeviceEntityId]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DeviceUid))
                ret.DeviceUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.DeviceUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CpuUid))
                ret.CpuUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CpuUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ClusterName))
                ret.ClusterName = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.ClusterName]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.IsAlarmEvent))
                ret.IsAlarmEvent = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.IsAlarmEvent]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AlarmPriority))
                ret.AlarmPriority = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AlarmPriority]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Instructions))
                ret.Instructions = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Instructions]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.InstructionsNoteUid))
                ret.InstructionsNoteUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.InstructionsNoteUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AudioBinaryResourceUid))
                ret.AudioBinaryResourceUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AudioBinaryResourceUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.RawData))
                ret.RawData = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.RawData]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Color))
                ret.Color = Convert.ToInt32(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Color]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CredentialUid))
                ret.CredentialUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CredentialUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PersonDescription))
                ret.PersonDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.PersonDescription]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CredentialDescription))
                ret.CredentialDescription = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.CredentialDescription]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Trace))
                ret.Trace = Convert.ToBoolean(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Trace]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid))
                ret.AccessPortalAlarmEventAcknowledgmentUid = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AccessPortalAlarmEventAcknowledgmentUid]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Response))
                ret.Response = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.Response]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedByUserId))
                ret.AckedByUserId = PDSAProperty.ConvertToGuid(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedByUserId]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedByUserDisplayName))
                ret.AckedByUserDisplayName = PDSAString.ConvertToStringTrim(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedByUserDisplayName]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedDateTime))
                ret.AckedDateTime = Convert.ToDateTime(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedDateTime]);

            if (values.ContainsKey(AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedUpdatedDateTime))
                ret.AckedUpdatedDateTime = Convert.ToDateTime(values[AcknowledgedAlarmsWithResponsesPDSAValidator.ColumnNames.AckedUpdatedDateTime]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of AcknowledgedAlarmsWithResponsesPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>AcknowledgedAlarmsWithResponsesPDSACollection</returns>
        public AcknowledgedAlarmsWithResponsesPDSACollection BuildCollection()
        {
            AcknowledgedAlarmsWithResponsesPDSACollection coll = new AcknowledgedAlarmsWithResponsesPDSACollection();
            AcknowledgedAlarmsWithResponsesPDSA entity = null;
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
        /// <returns>A collection of AcknowledgedAlarmsWithResponsesPDSA objects</returns>
        public AcknowledgedAlarmsWithResponsesPDSACollection BuildCollection(DataSet ds)
        {
            AcknowledgedAlarmsWithResponsesPDSACollection coll = new AcknowledgedAlarmsWithResponsesPDSACollection();

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
        /// <returns>A collection of AcknowledgedAlarmsWithResponsesPDSA objects</returns>
        public AcknowledgedAlarmsWithResponsesPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of AcknowledgedAlarmsWithResponsesPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(AcknowledgedAlarmsWithResponsesPDSACollection), BuildCollection());
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
            DataObject.SelectFilter = AcknowledgedAlarmsWithResponsesPDSAData.SelectFilters.Search;

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
        /// AcknowledgedAlarmsWithResponsesPDSA.SearchEntity = mgr.InitSearchFilter(AcknowledgedAlarmsWithResponsesPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A AcknowledgedAlarmsWithResponsesPDSA object</param>
        /// <returns>An AcknowledgedAlarmsWithResponsesPDSA object</returns>
        public AcknowledgedAlarmsWithResponsesPDSA InitSearchFilter(AcknowledgedAlarmsWithResponsesPDSA searchEntity)
        {
            searchEntity.ClusterGroupId = 0;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = AcknowledgedAlarmsWithResponsesPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current AcknowledgedAlarmsWithResponsesPDSA
        /// </summary>
        /// <returns>A cloned AcknowledgedAlarmsWithResponsesPDSA object</returns>
        public AcknowledgedAlarmsWithResponsesPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in AcknowledgedAlarmsWithResponsesPDSA
        /// </summary>
        /// <param name="entityToClone">The AcknowledgedAlarmsWithResponsesPDSA entity to clone</param>
        /// <returns>A cloned AcknowledgedAlarmsWithResponsesPDSA object</returns>
        public AcknowledgedAlarmsWithResponsesPDSA CloneEntity(AcknowledgedAlarmsWithResponsesPDSA entityToClone)
        {
            AcknowledgedAlarmsWithResponsesPDSA newEntity = new AcknowledgedAlarmsWithResponsesPDSA();

            newEntity.ActivityEventUid = entityToClone.ActivityEventUid;
            newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
            newEntity.ClusterNumber = entityToClone.ClusterNumber;
            newEntity.PanelNumber = entityToClone.PanelNumber;
            newEntity.CpuId = entityToClone.CpuId;
            newEntity.BoardNumber = entityToClone.BoardNumber;
            newEntity.SectionNumber = entityToClone.SectionNumber;
            newEntity.ModuleNumber = entityToClone.ModuleNumber;
            newEntity.NodeNumber = entityToClone.NodeNumber;
            newEntity.CpuModel = entityToClone.CpuModel;
            newEntity.DateTime_x = entityToClone.DateTime_x;
            newEntity.BufferIndex = entityToClone.BufferIndex;
            newEntity.PanelActivityType = entityToClone.PanelActivityType;
            newEntity.InputOutputGroupNumber = entityToClone.InputOutputGroupNumber;
            newEntity.MultiFactorMode = entityToClone.MultiFactorMode;
            newEntity.DeviceDescription = entityToClone.DeviceDescription;
            newEntity.EventDescription = entityToClone.EventDescription;
            newEntity.DeviceEntityId = entityToClone.DeviceEntityId;
            newEntity.DeviceUid = entityToClone.DeviceUid;
            newEntity.CpuUid = entityToClone.CpuUid;
            newEntity.ClusterName = entityToClone.ClusterName;
            newEntity.IsAlarmEvent = entityToClone.IsAlarmEvent;
            newEntity.AlarmPriority = entityToClone.AlarmPriority;
            newEntity.Instructions = entityToClone.Instructions;
            newEntity.InstructionsNoteUid = entityToClone.InstructionsNoteUid;
            newEntity.AudioBinaryResourceUid = entityToClone.AudioBinaryResourceUid;
            newEntity.RawData = entityToClone.RawData;
            newEntity.Color = entityToClone.Color;
            newEntity.PersonUid = entityToClone.PersonUid;
            newEntity.CredentialUid = entityToClone.CredentialUid;
            newEntity.PersonDescription = entityToClone.PersonDescription;
            newEntity.CredentialDescription = entityToClone.CredentialDescription;
            newEntity.Trace = entityToClone.Trace;
            newEntity.AccessPortalAlarmEventAcknowledgmentUid = entityToClone.AccessPortalAlarmEventAcknowledgmentUid;
            newEntity.Response = entityToClone.Response;
            newEntity.AckedByUserId = entityToClone.AckedByUserId;
            newEntity.AckedByUserDisplayName = entityToClone.AckedByUserDisplayName;
            newEntity.AckedDateTime = entityToClone.AckedDateTime;
            newEntity.AckedUpdatedDateTime = entityToClone.AckedUpdatedDateTime;

            return newEntity;
        }
        #endregion
    }
}
